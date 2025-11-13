using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Models;
using book_management.DataAccess;

namespace book_management.UI.Modal
{
    public partial class frmAddVoucher : Form
    {
        private KhuyenMai _originalVoucher = null;
        private bool _isEditMode = false;

        public frmAddVoucher()
        {
            InitializeComponent();
            _isEditMode = false;
        }

        public frmAddVoucher(KhuyenMai voucherToEdit)
        {
            InitializeComponent();
            _isEditMode = true;
            _originalVoucher = voucherToEdit;
            LoadVoucherData();
        }

        private void LoadVoucherData()
        {
            if (_originalVoucher == null)
                return;

            // Load data to controls
            txtVoucherName.Text = _originalVoucher.TenKm;
            textBox1.Text = _originalVoucher.MoTa ?? "";
            numDecreasePercent.Value = _originalVoucher.PhanTramGiam;
            dtpFromDate.Value = _originalVoucher.NgayBatDau;
            dtpToDate.Value = _originalVoucher.NgayKetThuc;

            // Update form title
            this.Text = "Chỉnh sửa Voucher";
            // Update button text if needed
            btnSaveBook.Text = "Cập nhật";
        }

        private bool HasChanges()
        {
            if (!_isEditMode)
                return true; // Always save for new vouchers

            if (_originalVoucher == null)
                return false;

            // Check if any field has changed
            bool nameChanged = txtVoucherName.Text.Trim() != _originalVoucher.TenKm;
            bool descChanged = textBox1.Text.Trim() != (_originalVoucher.MoTa ?? "");
            bool percentChanged = numDecreasePercent.Value != _originalVoucher.PhanTramGiam;
            bool startDateChanged = dtpFromDate.Value.Date != _originalVoucher.NgayBatDau.Date;
            bool endDateChanged = dtpToDate.Value.Date != _originalVoucher.NgayKetThuc.Date;

            return nameChanged || descChanged || percentChanged || startDateChanged || endDateChanged;
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtVoucherName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVoucherName.Focus();
                    return;
                }

                if (numDecreasePercent.Value <= 0)
                {
                    MessageBox.Show("Phần trăm giảm phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numDecreasePercent.Focus();
                    return;
                }

                if (dtpFromDate.Value >= dtpToDate.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpFromDate.Focus();
                    return;
                }

                // Check if there are any changes (for edit mode)
                if (_isEditMode && !HasChanges())
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Create/Update KhuyenMai object
                var voucher = new KhuyenMai
                {
                    KmId = _isEditMode ? _originalVoucher.KmId : 0,
                    TenKm = txtVoucherName.Text.Trim(),
                    MoTa = textBox1.Text.Trim(),
                    PhanTramGiam = numDecreasePercent.Value,
                    NgayBatDau = dtpFromDate.Value,
                    NgayKetThuc = dtpToDate.Value
                };

                bool success;
                string messageSuccess;

                if (_isEditMode)
                {
                    // Update to database
                    success = KhuyenMaiRepository.UpdateVoucher(voucher);
                    messageSuccess = "Cập nhật khuyến mãi thành công!";
                }
                else
                {
                    // Save to database
                    success = KhuyenMaiRepository.AddVoucher(voucher);
                    messageSuccess = "Thêm khuyến mãi thành công!";
                }

                if (success)
                {
                    MessageBox.Show(messageSuccess, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string messageError = _isEditMode ? "Cập nhật khuyến mãi thất bại!" : "Thêm khuyến mãi thất bại!";
                    MessageBox.Show(messageError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
