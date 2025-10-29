using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data; // Thêm namespace để sử dụng UserRepository và CurrentUser

namespace book_management
{
    public partial class LoginForm : Form
    {
        private bool _isVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            // Thêm event handlers cho KeyDown
            txtUsername.KeyDown += txtUsername_KeyDown;
            txtPassword.KeyDown += txtPassword_KeyDown;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin đăng nhập từ form
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Xác thực người dùng từ database
                var user = UserRepository.AuthenticateUser(username, password);
              
                if (user != null)
                {
                    // Đăng nhập thành công
                    CurrentUser.Login(user);
           
                    // Hiển thị thông báo chào mừng
                    MessageBox.Show($"Chào mừng {CurrentUser.GetDisplayInfo()}!", "Đăng nhập thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    // Mở MainForm và ẩn LoginForm
                    var main = new UI.MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    // Đăng nhập thất bại
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    // Clear password field
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối database
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}\n\nVui lòng kiểm tra kết nối và thử lại.", 
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                // Log error for debugging
                System.Diagnostics.Debug.WriteLine($"Login error: {ex}");
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (_isVisible)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnTogglePasswordVisibility.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                _isVisible = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                btnTogglePasswordVisibility.IconChar = FontAwesome.Sharp.IconChar.Eye;
                _isVisible = true;
            }
        }


        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong textbox username
        /// </summary>
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong textbox password
        /// </summary>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Override xử lý khi form đóng để đảm bảo ứng dụng thoát hoàn toàn
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void linkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
