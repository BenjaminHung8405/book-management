using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data;

namespace book_management.UI.Modal
{
    public partial class frmAddCustomer : Form
    {
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
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            string phone = txtPhone.Text.Trim();
            var existingCustomer = CustomerRepository.GetCustomerByPhone(phone);

            if (existingCustomer != null)
            {
                MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            try
            {
                // Tạo đối tượng KhachHang
                var newCustomer = new Models.KhachHang
                {
                    TenKhach = txtName.Text.Trim(),
                    SoDienThoai = txtPhone.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    NgayTao = DateTime.Now
                };

                // Gọi method CreateCustomer
                bool success = CustomerRepository.CreateCustomer(newCustomer);

                if (success)
                {
                    MessageBox.Show("Tạo khách hàng thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
