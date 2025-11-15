using book_management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Modal
{
    public partial class frmAddImport : System.Windows.Forms.Form
    {
        private dynamic _bookToEdit;
        private List<dynamic> _publishers = new List<dynamic>();
        private List<dynamic> _booksForSelectedPublisher = new List<dynamic>();
        private List<dynamic> _users = new List<dynamic>();

        public frmAddImport(dynamic bookToEdit = null)
        {
            InitializeComponent();
            // Initialize publishers and events
            InitializePublishersAndBooks();
        }

        private void InitializePublishersAndBooks()
        {
            try
            {
                // Load publishers and map to anonymous objects for reliable binding
                _publishers = BookRepository.GetAllPublishers();
                if (_publishers != null && _publishers.Count > 0)
                {
                    var publisherItems = _publishers.Select(p => new
                    {
                        NxbId = Convert.ToInt32(((object)p.NxbId)),
                        TenNxb = (p.TenNxb ?? "").ToString()
                    }).ToList();

                    comboBox1.DisplayMember = "TenNxb";
                    comboBox1.ValueMember = "NxbId";
                    comboBox1.DataSource = publisherItems;
                    comboBox1.SelectedIndex = -1;
                }

                // Setup employee (nhân viên) combo box
                try
                {
                    _users = UserRepository.GetUsersByRole("NhanVien") ?? UserRepository.GetAllUsers();
                    var userItems = (_users ?? new List<dynamic>()).Select(u => new
                    {
                        UserId = Convert.ToInt32(((object)u.UserId)),
                        HoTen = (u.HoTen ?? "").ToString()
                    }).ToList();

                    // cbNhanVien is placed in designer instead of txtTenSach
                    cbNhanVien.DisplayMember = "HoTen";
                    cbNhanVien.ValueMember = "UserId";
                    cbNhanVien.DataSource = userItems;
                    cbNhanVien.SelectedIndex = -1;
                }
                catch { }

                // Setup books combo box
                cbBooks.DisplayMember = "TenSach";
                cbBooks.ValueMember = "SachId";
                cbBooks.DropDownStyle = ComboBoxStyle.DropDownList;

                // Wire events
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                btnAddItem.Click += BtnAddItem_Click;
                dgvBooks.CellContentClick += DgvBooks_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhà xuất bản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null) return;
                int nxbId = 0;
                try { nxbId = Convert.ToInt32(((dynamic)comboBox1.SelectedItem).NxbId); } catch { }
                if (nxbId <= 0) return;
                LoadBooksForPublisher(nxbId);
            }
            catch { }
        }

        private void LoadBooksForPublisher(int nxbId)
        {
            try
            {
                _booksForSelectedPublisher = BookRepository.GetBooksByPublisher(nxbId) ?? new List<dynamic>();
                var bookItems = _booksForSelectedPublisher.Select(b => new
                {
                    SachId = Convert.ToInt32(((object)b.SachId)),
                    TenSach = (b.TenSach ?? "").ToString(),
                    Gia = b.Gia != null ? Convert.ToDecimal(b.Gia) : 0m
                }).ToList();

                cbBooks.DisplayMember = "TenSach";
                cbBooks.ValueMember = "SachId";
                cbBooks.DataSource = bookItems;
                cbBooks.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sách của NXB: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbBooks.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sách để thêm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selected = (dynamic)cbBooks.SelectedItem;
                int sachId = Convert.ToInt32(selected.SachId);
                string tenSach = selected.TenSach?.ToString() ?? string.Empty;
                decimal donGia = selected.Gia != null ? Convert.ToDecimal(selected.Gia) : 0m;

                // If book exists in grid, increment quantity
                foreach (DataGridViewRow row in dgvBooks.Rows)
                {
                    if (row.IsNewRow) continue;
                    var idObj = row.Cells["colBookID"].Value;
                    if (idObj == null) continue;
                    if (int.TryParse(idObj.ToString(), out int existingId) && existingId == sachId)
                    {
                        // increment quantity by 1
                        if (int.TryParse(row.Cells["colSoLuong"].Value?.ToString() ?? "0", out int curQty))
                        {
                            curQty += 1;
                            row.Cells["colSoLuong"].Value = curQty;
                            var thanh = curQty * donGia;
                            row.Cells["colThanhTien"].Value = thanh.ToString("N0") + " đ";
                            UpdateTotalFromGrid();
                            return;
                        }
                    }
                }

                // Add new row
                var index = dgvBooks.Rows.Add(sachId, tenSach, 1, donGia.ToString("N0"), (1 * donGia).ToString("N0") + " đ", "Xóa");
                dgvBooks.Rows[index].Tag = sachId;
                UpdateTotalFromGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sách vào phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                var column = dgvBooks.Columns[e.ColumnIndex];
                if (column.Name == "colDelete")
                {
                    dgvBooks.Rows.RemoveAt(e.RowIndex);
                    UpdateTotalFromGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thao tác trên bảng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalFromGrid()
        {
            try
            {
                decimal total = 0m;
                foreach (DataGridViewRow row in dgvBooks.Rows)
                {
                    if (row.IsNewRow) continue;
                    var qtyObj = row.Cells["colSoLuong"].Value;
                    var priceObj = row.Cells["colDonGia"].Value;
                    if (!TryParseInt(qtyObj, out int qty)) continue;
                    if (!TryParseDecimal(priceObj, out decimal price)) continue;
                    total += qty * price;
                }
                lblTotalImportAmount.Text = total.ToString("N0", CultureInfo.CurrentCulture) + " đ";
            }
            catch { }
        }
        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            btnSaveBook.Enabled = false;
            try
            {
                // Basic header validation: require selecting a nhân viên (or fallback current user)
                if ((cbNhanVien == null || cbNhanVien.SelectedItem == null) && (!Data.CurrentUser.IsLoggedIn || Data.CurrentUser.UserId <= 0))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên hoặc đăng nhập bằng tài khoản hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvBooks.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sách vào phiếu.", "Thiếu chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Build PhieuNhap object
                var phieuNhap = new Models.PhieuNhap();
                phieuNhap.NgayNhap = DateTime.Now;
                // If a user (nhân viên) is selected, use that user's id; otherwise fallback to current user
                try
                {
                    if (cbNhanVien != null && cbNhanVien.SelectedItem != null)
                    {
                        var sel = (dynamic)cbNhanVien.SelectedItem;
                        phieuNhap.UserId = Convert.ToInt32(sel.UserId);
                        phieuNhap.TenNguoiNhap = sel.HoTen?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        phieuNhap.UserId = Data.CurrentUser.UserId;
                        phieuNhap.TenNguoiNhap = Data.CurrentUser.FullName ?? string.Empty;
                    }
                }
                catch
                {
                    phieuNhap.UserId = Data.CurrentUser.UserId;
                    phieuNhap.TenNguoiNhap = Data.CurrentUser.FullName ?? string.Empty;
                }

                decimal tong = 0m;

                foreach (DataGridViewRow row in dgvBooks.Rows)
                {
                    // Expect colBookID, colSoLuong, colDonGia
                    if (row.IsNewRow) continue;

                    var idObj = row.Cells["colBookID"].Value;
                    var qtyObj = row.Cells["colSoLuong"].Value;
                    var priceObj = row.Cells["colDonGia"].Value;

                    if (idObj == null || qtyObj == null || priceObj == null)
                    {
                        MessageBox.Show("Dữ liệu chi tiết không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!TryParseInt(idObj, out int sachId))
                    {
                        MessageBox.Show("ID sách không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!TryParseInt(qtyObj, out int soLuong) || soLuong <=0)
                    {
                        MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!TryParseDecimal(priceObj, out decimal donGia) || donGia <=0)
                    {
                        MessageBox.Show("Đơn giá phải là số dương.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // get TenSach from the row if present
                    string tenSach = string.Empty;
                    try
                    {
                        var tenObj = row.Cells["colTenSach"].Value;
                        tenSach = tenObj?.ToString() ?? string.Empty;
                    }
                    catch { tenSach = string.Empty; }

                    var thanhTien = soLuong * donGia;
                    tong += thanhTien;

                    phieuNhap.ChiTietPhieuNhaps.Add(new Models.ChiTietPhieuNhap
                    {
                        SachId = sachId,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = thanhTien,
                        TenSach = tenSach // ensure TenSach set so SQL parameter is supplied
                    });
                }

                phieuNhap.TongTien = tong;

                // Update total label in UI
                try
                {
                    lblTotalImportAmount.Text = tong.ToString("N0", CultureInfo.CurrentCulture) + " đ";
                }
                catch { }

                // Call repository to create in DB
                int newId = WareHouseRepository.CreateWareHouseWithDetails(phieuNhap);
                MessageBox.Show($"Tạo phiếu nhập thành công. Mã PN: {newId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaveBook.Enabled = true;
            }
        }


        private bool TryParseInt(object obj, out int value)
        {
            value = 0;
            if (obj == null) return false;
            if (obj is int i)
            {
                value = i;
                return true;
            }
            var s = obj.ToString().Trim();
            // remove non-digit characters except minus
            s = System.Text.RegularExpressions.Regex.Replace(s, "[^0-9-]", "");
            return int.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
        }

        private bool TryParseDecimal(object obj, out decimal value)
        {
            value = 0m;
            if (obj == null) return false;
            if (obj is decimal d)
            {
                value = d;
                return true;
            }
            if (obj is double db)
            {
                value = Convert.ToDecimal(db);
                return true;
            }
            var s = obj.ToString().Trim();
            // remove currency symbol (đ) and spaces
            s = s.Replace("đ", "").Replace(" ", "");
            // Try parse with current culture first
            if (decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out value))
            {
                return true;
            }
            // Fallback: remove any non-digit, non-decimal chars and try invariant
            s = System.Text.RegularExpressions.Regex.Replace(s, "[^0-9.,-]", "");
            s = s.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "," ? "," : ".");
            return decimal.TryParse(s, NumberStyles.Number | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out value);
        }
        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}