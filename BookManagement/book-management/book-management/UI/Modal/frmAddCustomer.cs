using System;
using System.Windows.Forms;
using book_management.Data;
using book_management.Models;

namespace book_management.UI.Modal
{
    public partial class frmAddCustomer : Form
    {
        // Expose the created customer to the caller
        public KhachHang CreatedCustomer { get; private set; }

        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string name = (txtName.Text ?? "").Trim();
                string phone = (txtPhone.Text ?? "").Trim();
                string address = (txtAddress.Text ?? "").Trim();

                // Require at least a name or a phone number
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng nhập tên hoặc số điện thoại của khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                // Nếu nhập số điện thoại thì kiểm tra trùng
                if (!string.IsNullOrEmpty(phone))
                {
                    // Validate phone format (allow digits, spaces, + and hyphens). Normalize for length check.
                    if (!IsValidPhone(phone))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập đúng 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPhone.Focus();
                        return;
                    }

                    // Normalize phone (remove spaces/hyphens/parentheses) for comparison and storage
                    var cleanedPhone = System.Text.RegularExpressions.Regex.Replace(phone, @"[ \-()]", "");
                    var existingCustomer = CustomerRepository.GetCustomerByPhone(cleanedPhone);
                    if (existingCustomer != null)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPhone.Focus();
                        return;
                    }
                }

                // Validate address length (optional)
                if (!string.IsNullOrEmpty(address) && address.Length > 500)
                {
                    MessageBox.Show("Địa chỉ quá dài (tối đa 500 ký tự). Vui lòng rút gọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                // Tạo đối tượng KhachHang (không tạo 'Khách vãng lai' tự động ở form này).
                // If phone was provided, use the normalized version
                string phoneToSave = null;
                if (!string.IsNullOrEmpty(phone))
                {
                    phoneToSave = System.Text.RegularExpressions.Regex.Replace(phone, @"[ \-()]", "");
                }

                var newCustomer = new KhachHang
                {
                    TenKhach = string.IsNullOrEmpty(name) ? null : name,
                    SoDienThoai = string.IsNullOrEmpty(phoneToSave) ? null : phoneToSave,
                    // Use the address textbox value if provided; store null when empty to match DB expectations
                    DiaChi = string.IsNullOrWhiteSpace(address) ? null : address,
                    NgayTao = DateTime.Now
                };

                bool created = CustomerRepository.CreateCustomer(newCustomer);
                if (created)
                {
                    CreatedCustomer = newCustomer;

                    MessageBox.Show("Tạo khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo khách hàng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validate phone number: exactly 10 digits after removing spaces/hyphens/parentheses.
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            // Remove spaces, parentheses and hyphens for length check.
            var cleaned = System.Text.RegularExpressions.Regex.Replace(phone, @"[ \-()]", "");
            // Disallow leading + for local 10-digit requirement
            if (cleaned.StartsWith("+")) return false;
            // Require exactly 10 digits
            if (!System.Text.RegularExpressions.Regex.IsMatch(cleaned, "^\\d{10}$")) return false;
            return true;
        }
    }
}
