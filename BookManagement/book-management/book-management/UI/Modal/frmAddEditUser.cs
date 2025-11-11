using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Modal
{
    public partial class frmAddEditUser : Form
    {
        public frmAddEditUser()
        {
            InitializeComponent();
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            itemNhanVien.Checked = true;
            lbTitle.Text = "Thêm nhân viên mới";
            lbInput1.Enabled = true;
            lbInput1.Text = "Tên nhân viên:";
            txtInput1.Enabled = true;
            lbInput2.Enabled = true;
            lbInput2.Text = "Tên đăng nhập:";
            txtInput2.Enabled = true;
            lbInput3.Enabled = true;
            lbInput3.Text = "Email:";
            txtInput3.Enabled = true;
            lbInput4.Enabled = true;
            lbInput4.Text = "Số điện thoại:";
            txtInput4.Enabled = true;
            lbInput5.Enabled = true;
            lbInput5.Text = "Vai trò:";
            cbInput1.Enabled = true;
            lbInput6.Enabled = true;
            lbInput6.Text = "Mật khẩu:";
            txtInput6.Enabled = true;
            lbInput7.Enabled = true;
            lbInput7.Text = "Xác nhận mật khẩu:";
            txtInput7.Enabled = true;
        }

        private void itemNhanVien_Click(object sender, EventArgs e)
        {
            itemNhanVien.Checked = true;
            itemKhachHang.Checked = false;
            lbTitle.Text = "Thêm nhân viên mới";
            lbInput1.Text = "Tên nhân viên:";
            txtInput1.Enabled = true;
            lbInput2.Text = "Tên đăng nhập:";
            txtInput2.Enabled = true;
            lbInput3.Text = "Email:";
            txtInput3.Enabled = true;
            lbInput4.Visible = true;
            txtInput4.Visible = true;
            lbInput5.Visible = true;
            cbInput1.Visible = true;
            lbInput6.Visible = true;
            txtInput6.Visible = true;
            lbInput7.Visible = true;
            txtInput7.Visible = true;
        }

        private void itemKhachHang_Click(object sender, EventArgs e)
        {
            itemKhachHang.Checked = true;
            itemNhanVien.Checked = false;
            lbTitle.Text = "Thêm khách hàng mới";
            lbInput1.Text = "Tên khách hàng:";
            txtInput1.Enabled = true;
            lbInput2.Text = "Số điện thoại:";
            txtInput2.Enabled = true;
            lbInput3.Text = "Địa chỉ:";
            txtInput3.Enabled = true;
            lbInput4.Visible = false;
            txtInput4.Visible = false;
            lbInput5.Visible = false;
            cbInput1.Visible = false;
            lbInput6.Visible = false;
            txtInput6.Visible = false;
            lbInput7.Visible = false;
            txtInput7.Visible = false;
        }
    }
}
