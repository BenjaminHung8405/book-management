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

                // Nếu không nhập tên và không nhập số điện thoại -> mặc định là Khách vãng lai
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
                {
                    name = "Khách vãng lai";
                }

                // Nếu nhập số điện thoại thì kiểm tra trùng
                if (!string.IsNullOrEmpty(phone))
                {
                    var existingCustomer = CustomerRepository.GetCustomerByPhone(phone);
                    if (existingCustomer != null)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPhone.Focus();
                        return;
                    }
                }

                // Tạo đối tượng KhachHang. Nếu name rỗng, CreateCustomer sẽ đặt 'Khách vãng lai'
                var newCustomer = new KhachHang
                {
                    TenKhach = string.IsNullOrEmpty(name) ? null : name,
                    SoDienThoai = string.IsNullOrEmpty(phone) ? null : phone,
                    DiaChi = null,
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
    }
}
