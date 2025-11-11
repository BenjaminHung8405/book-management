using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.DataAccess;
using book_management.Models;
using book_management.UI.Theme;

namespace book_management.UI.Controls
{
    public partial class EditInvoiceControl : Form
    {
        private readonly int _hoaDonId;
        private HoaDon _currentInvoice;
        private List<ChiTietHoaDon> _chiTietList;

        public EditInvoiceControl(int hoaDonId)
        {
            _hoaDonId = hoaDonId;
            InitializeComponent();
            LoadInvoiceData();
        }

        private void LoadInvoiceData()
        {
            try
            {
                _currentInvoice = HoaDonRepository.GetInvoiceById(_hoaDonId);
                _chiTietList = ChiTietHoaDonRepository.GetChiTietHoaDon(_hoaDonId);

                if (_currentInvoice != null)
                {
                    // Load thông tin hóa đơn vào controls
                    txtHoaDonId.Text = _currentInvoice.HoaDonId.ToString();
                    dtpNgayLap.Value = _currentInvoice.NgayLap;
                    txtTenNguoiMua.Text = _currentInvoice.TenNguoiMua;
                    txtNguoiLap.Text = _currentInvoice.NguoiLap;

                    // Set trạng thái
                    switch (_currentInvoice.TrangThai)
                    {
                        case "DaThanhToan":
                            cmbTrangThai.SelectedItem = "Đã thanh toán";
                            break;
                        case "ChuaThanhToan":
                            cmbTrangThai.SelectedItem = "Chưa thanh toán";
                            break;
                        case "DaHuy":
                            cmbTrangThai.SelectedItem = "Đã hủy";
                            break;
                        default:
                            cmbTrangThai.SelectedIndex = 0;
                            break;
                    }

                    LoadChiTietHoaDon();
                    UpdateTotalAmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu hóa đơn: {ex.Message}",
       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietHoaDon()
        {
            dgvChiTiet.Rows.Clear();
            foreach (var item in _chiTietList)
            {
                dgvChiTiet.Rows.Add(
                    item.SachId,
                    item.TenSach,
                    item.SoLuong,
                    item.DonGia.ToString("N0"),
                    item.TienGiam.ToString("N0"),
                    item.ThanhTien.ToString("N0")
                );
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = _chiTietList.Sum(x => x.ThanhTien);
            txtTongTien.Text = total.ToString("N0") + " đ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    // Cập nhật thông tin hóa đơn
                    _currentInvoice.NgayLap = dtpNgayLap.Value;
                    _currentInvoice.TenNguoiMua = txtTenNguoiMua.Text.Trim();

                    // Chuyển đổi trạng thái về database format
                    string selectedStatus = cmbTrangThai.SelectedItem.ToString();
                    switch (selectedStatus)
                    {
                        case "Đã thanh toán":
                            _currentInvoice.TrangThai = "DaThanhToan";
                            break;
                        case "Chưa thanh toán":
                            _currentInvoice.TrangThai = "ChuaThanhToan";
                            break;
                        case "Đã hủy":
                            _currentInvoice.TrangThai = "DaHuy";
                            break;
                    }

                    // Cập nhật tổng tiền
                    _currentInvoice.TongTien = _chiTietList.Sum(x => x.ThanhTien);

                    // Lưu vào database
                    HoaDonRepository.UpdateInvoice(_currentInvoice);

                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNguoiMua.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người mua!", "Cảnh báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtTenNguoiMua.Focus();
                return false;
            }

            if (cmbTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái hóa đơn!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTrangThai.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                int sachId = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["SachId"].Value);
                var chiTiet = _chiTietList.FirstOrDefault(x => x.SachId == sachId);

                if (chiTiet != null)
                {
                    using (var inputForm = new QuantityInputDialog(chiTiet.SoLuong))
                    {
                        if (inputForm.ShowDialog() == DialogResult.OK)
                        {
                            int newQuantity = inputForm.Quantity;
                            if (newQuantity > 0)
                            {
                                chiTiet.SoLuong = newQuantity;
                                chiTiet.ThanhTien = (chiTiet.DonGia - chiTiet.TienGiam) * newQuantity;

                                LoadChiTietHoaDon();
                                UpdateTotalAmount();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                int sachId = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["SachId"].Value);

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi hóa đơn?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _chiTietList.RemoveAll(x => x.SachId == sachId);
                    LoadChiTietHoaDon();
                    UpdateTotalAmount();
                }
            }
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format tiền tệ cho các cột
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 5 && e.Value != null)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }

    // Dialog tùy chỉnh để nhập số lượng
    public partial class QuantityInputDialog : Form
    {
        public int Quantity { get; private set; }

        public QuantityInputDialog(int currentQuantity)
        {
            InitializeComponent();
            numQuantity.Value = currentQuantity;
            numQuantity.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Quantity = (int)numQuantity.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số lượng:";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numQuantity.Location = new System.Drawing.Point(20, 50);
            this.numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(200, 29);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(20, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(130, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QuantityInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuantityInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật số lượng";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
