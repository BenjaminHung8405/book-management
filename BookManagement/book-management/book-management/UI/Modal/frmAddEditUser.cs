using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data; // for UserRepository

namespace book_management.UI.Modal
{
    public partial class frmAddEditUser : Form
    {
        private int? _userId = null;
        public frmAddEditUser()
        {
            InitializeComponent();
            // Wire up the save button click here to avoid editing Designer file
            this.btnSaveBook.Click += BtnSaveBook_Click;
        }

        /// <summary>
        /// Constructor for edit mode
        /// </summary>
        /// <param name="userId"></param>
        public frmAddEditUser(int userId) : this()
        {
            _userId = userId;
            // Change label to edit mode
            label1.Text = "Sửa thông tin người dùng";
            // Load user data
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                if (!_userId.HasValue) return;
                var user = UserRepository.GetUserById(_userId.Value);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtHoTen.Text = user.HoTen?.ToString() ?? "";
                txtUsername.Text = user.Username?.ToString() ?? "";
                txtUsername.Enabled = false; // Do not allow editing username
                txtEmail.Text = user.Email?.ToString() ?? "";
                txtSDT.Text = user.SoDienThoai?.ToString() ?? "";

                var role = (user.VaiTro ?? "").ToString();
                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox1.SelectedItem = "Admin";
                    comboBox1.Enabled = true;
                }
                else if (role.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox1.SelectedItem = "Nhân Viên";
                    comboBox1.Enabled = true;
                }
                else
                {
                    // fallback
                    comboBox1.SelectedItem = "Nhân Viên";
                    comboBox1.Enabled = true;
                }

                // clear password fields
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = (txtHoTen.Text ?? "").Trim();
                string username = (txtUsername.Text ?? "").Trim();
                string password = (txtPassword.Text ?? "").Trim();
                string confirmPass = (txtConfirmPass.Text ?? "").Trim();
                string email = (txtEmail.Text ?? "").Trim();
                string sdt = (txtSDT.Text ?? "").Trim();
                var roleText = comboBox1.SelectedItem?.ToString() ?? "Nhân Viên";
                // Map UI display roles to DB stored canonical values
                string vaiTro;
                if (roleText.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    vaiTro = "Admin";
                }
                else if (roleText.IndexOf("nhân", StringComparison.OrdinalIgnoreCase) >= 0 || roleText.IndexOf("nhan", StringComparison.OrdinalIgnoreCase) >= 0 || roleText.IndexOf("staff", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    vaiTro = "NhanVien";
                }
                // No 'KhachHang' role allowed in Add/Edit User form; map only Admin or NhanVien
                else
                {
                    // default fallback
                    vaiTro = "NhanVien";
                }

                // Basic validation
                if (!_userId.HasValue)
                {
                    // create mode requires username and password
                    if (string.IsNullOrEmpty(username))
                    {
                        MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Focus();
                        return;
                    }

                    if (password != confirmPass)
                    {
                        MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtConfirmPass.Focus();
                        return;
                    }
                }
                else
                {
                    // update mode: require hoTen
                    if (string.IsNullOrWhiteSpace(hoTen))
                    {
                        MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtHoTen.Focus();
                        return;
                    }

                    // edit mode: only check passwords if provided
                    if (!string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirmPass))
                    {
                        if (password != confirmPass)
                        {
                            MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtConfirmPass.Focus();
                            return;
                        }
                    }
                }

                // Normalize phone
                string cleanedPhone = null;
                if (!string.IsNullOrWhiteSpace(sdt))
                {
                    cleanedPhone = System.Text.RegularExpressions.Regex.Replace(sdt, @"[ \-()]", "");
                    var existingPhone = UserRepository.GetUserByPhone(cleanedPhone);
                    if (existingPhone != null)
                    {
                        try
                        {
                            int existingId = Convert.ToInt32(existingPhone.UserId);
                            if (!_userId.HasValue || existingId != _userId.Value)
                            {
                                MessageBox.Show("Số điện thoại đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSDT.Focus();
                                return;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSDT.Focus();
                            return;
                        }
                    }
                }

                // check username uniqueness only in create mode
                if (!_userId.HasValue)
                {
                    var users = UserRepository.GetAllUsers();
                    var existingUser = users.Find(u => (u.Username?.ToString() ?? "").Equals(username, StringComparison.OrdinalIgnoreCase));
                    if (existingUser != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus();
                        return;
                    }
                }

                if (!_userId.HasValue)
                {
                    // Create the user
                    int newId = UserRepository.AddUser(username, password, hoTen, string.IsNullOrWhiteSpace(email) ? null : email, string.IsNullOrWhiteSpace(cleanedPhone) ? null : cleanedPhone, vaiTro);
                    if (newId > 0)
                    {
                        MessageBox.Show("Tạo người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể tạo người dùng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update existing user
                    // map role text back to DB value
                    var roleText2 = comboBox1.SelectedItem?.ToString() ?? "Nhân Viên";
                    string roleDb;
                    if (roleText2.Equals("Admin", StringComparison.OrdinalIgnoreCase)) roleDb = "Admin";
                    else if (roleText2.IndexOf("nhân", StringComparison.OrdinalIgnoreCase) >= 0 || roleText2.IndexOf("nhan", StringComparison.OrdinalIgnoreCase) >= 0 || roleText2.IndexOf("staff", StringComparison.OrdinalIgnoreCase) >= 0) roleDb = "NhanVien";
                    else if (roleText2.IndexOf("khách", StringComparison.OrdinalIgnoreCase) >= 0 || roleText2.IndexOf("khach", StringComparison.OrdinalIgnoreCase) >= 0) roleDb = "KhachHang";
                    else roleDb = "NhanVien";

                    bool updated = UserRepository.UpdateUser(_userId.Value, hoTen, string.IsNullOrWhiteSpace(email) ? null : email, string.IsNullOrWhiteSpace(cleanedPhone) ? null : cleanedPhone, roleDb);
                    if (!updated)
                    {
                        MessageBox.Show("Cập nhật người dùng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // change password if provided
                    if (!string.IsNullOrEmpty(password))
                    {
                        bool passChanged = UserRepository.ChangePassword(_userId.Value, password);
                        if (!passChanged)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
