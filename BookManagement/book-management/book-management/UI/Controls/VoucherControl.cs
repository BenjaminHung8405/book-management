using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.UI.Modal;
using book_management.Data;
using book_management.Models;
using book_management.DataAccess;

namespace book_management.UI.Controls
{
    public partial class VoucherControl : System.Windows.Forms.UserControl
    {
        #region Class Variables
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;
        #endregion

        #region Constructor
        public VoucherControl()
        {
            InitializeComponent();

            // Configure DataGridView
            dgvVouchers.AutoGenerateColumns = false;

            // Initialize ComboBox
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Tất cả");
            cmbStatusFilter.Items.Add("Đang diễn ra");
            cmbStatusFilter.Items.Add("Sắp diễn ra");
            cmbStatusFilter.Items.Add("Đã kết thúc");
            cmbStatusFilter.SelectedIndex = 0;

            // Hook up events
            this.Load += VoucherControl_Load;
            dgvVouchers.CellFormatting += DgvVouchers_CellFormatting;
            dgvVouchers.CellContentClick += DgvVouchers_CellContentClick;
            btnAddVoucher.Click += BtnAddVoucher_Click;
            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
            txtSearchVoucher.TextChanged += TxtSearchVoucher_TextChanged;
        }
        #endregion

        #region Event Handlers
        private void VoucherControl_Load(object sender, EventArgs e)
        {
            LoadVouchers(1);
        }

        private void DgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is "colTrangThai" (Status column)
            if (dgvVouchers.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value == null)
                    return;

                string status = e.Value.ToString();

                switch (status)
                {
                    case "Đang diễn ra":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "Sắp diễn ra":
                        e.CellStyle.BackColor = Color.LightYellow;
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                    case "Đã kết thúc":
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkGray;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void DgvVouchers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dgvVouchers.Columns[e.ColumnIndex].Name;

            try
            {
                // Get the voucher ID from the km_id column (colTenKM is first, but we need to get km_id properly)
                object kmIdObj = dgvVouchers.Rows[e.RowIndex].Cells["colTenKM"].Value;

                if (kmIdObj == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Try to get km_id from the data - since we use anonymous objects, we need to get it differently
                // The km_id is stored in the data source, let's get it from current row's tag or first column
                var rowData = dgvVouchers.Rows[e.RowIndex].DataBoundItem;

                if (rowData == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get km_id from the anonymous object
                var kmIdProperty = rowData.GetType().GetProperty("km_id");
                if (kmIdProperty == null)
                {
                    MessageBox.Show("Không thể lấy ID khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kmId = Convert.ToInt32(kmIdProperty.GetValue(rowData));

                if (columnName == "colEdit")
                {
                    try
                    {
                        // Get voucher data
                        var voucher = KhuyenMaiRepository.GetVoucherById(kmId);
                        if (voucher != null)
                        {
                            // Open edit form with voucher data (reuse frmAddVoucher)
                            using (var form = new frmAddVoucher(voucher))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    LoadVouchers(currentPage);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khuyến mãi để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (columnName == "colDelete")
                {
                    try
                    {
                        // Get voucher name from the data object
                        var tenKmProperty = rowData.GetType().GetProperty("ten_km");
                        if (tenKmProperty == null)
                        {
                            MessageBox.Show("Không thể lấy tên khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string tenKm = tenKmProperty.GetValue(rowData).ToString();

                        // Confirm deletion
                        DialogResult result = MessageBox.Show(
                            $"Bạn có chắc muốn xóa khuyến mãi '{tenKm}' không?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            bool success = KhuyenMaiRepository.DeleteVoucher(kmId);
                            if (success)
                            {
                                MessageBox.Show("Xóa khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadVouchers(currentPage);
                            }
                            else
                            {
                                MessageBox.Show("Xóa khuyến mãi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddVoucher_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddVoucher())
            {
                form.ShowDialog();
            }

            // Refresh the data after dialog closes
            LoadVouchers(currentPage);
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset to page 1 when filter changes
            LoadVouchers(1);
        }

        private void TxtSearchVoucher_TextChanged(object sender, EventArgs e)
        {
            // Reset to page 1 when search text changes
            LoadVouchers(1);
        }
        #endregion

        #region Data Loading
        private void LoadVouchers(int page)
        {
            try
            {
                // Get all vouchers from repository
                var allVouchers = KhuyenMaiRepository.GetAllVouchers();

                if (allVouchers == null)
                    allVouchers = new List<KhuyenMai>();

                // Apply search filter
                string searchText = txtSearchVoucher.Text.ToLower();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    allVouchers = allVouchers.Where(v =>
                        v.TenKm.ToLower().Contains(searchText) ||
                        v.MoTa.ToLower().Contains(searchText)
                    ).ToList();
                }

                // Apply status filter
                string selectedStatus = cmbStatusFilter.SelectedItem?.ToString() ?? "Tất cả";
                if (selectedStatus != "Tất cả")
                {
                    allVouchers = allVouchers.Where(v => ComputeTrangThai(v) == selectedStatus).ToList();
                }

                if (allVouchers.Count == 0)
                {
                    dgvVouchers.DataSource = null;
                    totalRecords = 0;
                    totalPages = 0;
                    currentPage = 1;
                    UpdatePaginationUI(1, 0, 0);
                    StyleGrid();
                    return;
                }

                totalRecords = allVouchers.Count;
                totalPages = (totalRecords + pageSize - 1) / pageSize;

                // Ensure page is within valid range
                if (page < 1) page = 1;
                if (page > totalPages) page = totalPages;

                currentPage = page;

                // Perform pagination
                var pageData = allVouchers
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(v => new
                    {
                        km_id = v.KmId,
                        ten_km = v.TenKm,
                        mo_ta = v.MoTa,
                        phan_tram_giam = v.PhanTramGiam,
                        ngay_bat_dau = v.NgayBatDau,
                        ngay_ket_thuc = v.NgayKetThuc,
                        TrangThaiText = ComputeTrangThai(v)
                    })
                    .ToList();

                // Bind data to grid
                dgvVouchers.DataSource = null;
                dgvVouchers.DataSource = pageData;

                // Update pagination UI
                UpdatePaginationUI(page, totalPages, totalRecords);

                // Style the grid
                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ComputeTrangThai(KhuyenMai voucher)
        {
            DateTime now = DateTime.Now;

            if (voucher.NgayKetThuc < now)
            {
                return "Đã kết thúc";
            }
            else if (voucher.NgayBatDau > now)
            {
                return "Sắp diễn ra";
            }
            else
            {
                return "Đang diễn ra";
            }
        }
        #endregion

        #region Pagination
        private void UpdatePaginationUI(int page, int pages, int records)
        {
            // Clear existing pagination buttons
            flowPaginationButtons.Controls.Clear();

            // Update page info label
            if (records == 0)
            {
                lblPageInfo.Text = "Không có dữ liệu";
                return;
            }

            int startRecord = (page - 1) * pageSize + 1;
            int endRecord = Math.Min(page * pageSize, records);
            lblPageInfo.Text = $"Hiển thị {startRecord}-{endRecord} của {records}";

            if (pages <= 1)
                return;

            // Create "Trước" (Previous) button
            if (page > 1)
            {
                Button btnPrev = CreatePaginationButton("Trước", page - 1);
                flowPaginationButtons.Controls.Add(btnPrev);
            }

            // Create page number buttons
            int startPage = Math.Max(1, page - 2);
            int endPage = Math.Min(pages, page + 2);

            if (startPage > 1)
            {
                Button btn1 = CreatePaginationButton("1", 1);
                flowPaginationButtons.Controls.Add(btn1);

                if (startPage > 2)
                {
                    Button btnEllipsis = CreatePaginationButton("...", -1);
                    btnEllipsis.Enabled = false;
                    flowPaginationButtons.Controls.Add(btnEllipsis);
                }
            }

            for (int i = startPage; i <= endPage; i++)
            {
                Button btnPage = CreatePaginationButton(i.ToString(), i);
                if (i == page)
                {
                    btnPage.BackColor = Color.FromArgb(74, 144, 226);
                    btnPage.ForeColor = Color.White;
                }
                flowPaginationButtons.Controls.Add(btnPage);
            }

            if (endPage < pages)
            {
                if (endPage < pages - 1)
                {
                    Button btnEllipsis = CreatePaginationButton("...", -1);
                    btnEllipsis.Enabled = false;
                    flowPaginationButtons.Controls.Add(btnEllipsis);
                }

                Button btnLast = CreatePaginationButton(pages.ToString(), pages);
                flowPaginationButtons.Controls.Add(btnLast);
            }

            // Create "Sau" (Next) button
            if (page < pages)
            {
                Button btnNext = CreatePaginationButton("Sau", page + 1);
                flowPaginationButtons.Controls.Add(btnNext);
            }
        }

        private Button CreatePaginationButton(string text, int pageNumber)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = pageNumber,
                Width = 45,
                Height = 35,
                Font = new Font("Microsoft Sans Serif", 8F),
                ForeColor = Color.Black,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
            };

            btn.Click += PaginationButton_Click;
            return btn;
        }

        private void PaginationButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int pageNumber && pageNumber > 0)
            {
                LoadVouchers(pageNumber);
            }
        }
        #endregion

        #region Styling
        private void StyleGrid()
        {
            // Set column header styles
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 144, 226),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(5)
            };

            dgvVouchers.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvVouchers.ColumnHeadersHeight = 40;

            // Set row height
            dgvVouchers.RowTemplate.Height = 35;

            // Center align status column
            foreach (DataGridViewColumn col in dgvVouchers.Columns)
            {
                if (col.Name == "colTrangThai" || col.Name == "colEdit" || col.Name == "colDelete")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        #endregion
    }
}
