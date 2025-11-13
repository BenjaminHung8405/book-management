using System;
using System.Windows.Forms;
using book_management.Data;

namespace book_management.UI.Controls
{
    public partial class EditUserControl : Form
    {
        private int? _userId = null;

        public EditUserControl()
        {
            InitializeComponent();

            // Ensure event handlers wired (designer may not serialize these)
            if (btnCancelModal != null)
                btnCancelModal.Click += btnCancelModal_Click;
            if (btnSaveBook != null)
                btnSaveBook.Click += BtnSaveBook_Click;
        }

        /// <summary>
        /// Constructor để mở form ở chế độ edit với userId
        /// </summary>
        public EditUserControl(int userId) : this()
        {
            _userId = userId;
            label1.Text = "Sửa Người dùng";
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
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Điền dữ liệu lên form
                txtHoTen.Text = user.HoTen?.ToString() ?? "";
                txtUsername.Text = user.Username?.ToString() ?? "";
                txtEmail.Text = user.Email?.ToString() ?? "";
                txtSDT.Text = user.SoDienThoai?.ToString() ?? "";

                // Disable username editing when chỉnh sửa
                txtUsername.Enabled = false;

                // Map vai tro
                var vaiTro = (user.VaiTro ?? "").ToString();
                if (vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    comboBox1.SelectedItem = "Admin";
                else
                    comboBox1.SelectedItem = "Nhân Viên";

                // Password fields left empty (do not show hash)
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
                // Validate required
                var hoTen = txtHoTen.Text.Trim();
                var email = txtEmail.Text.Trim();
                var sdt = txtSDT.Text.Trim();
                var password = txtPassword.Text;
                var confirm = txtConfirmPass.Text;
                var roleText = comboBox1.SelectedItem?.ToString() ?? "Nhân Viên";

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                // Nếu nhập mật khẩu thì phải xác nhận
                if (!string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirm))
                {
                    if (password != confirm)
                    {
                        MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Focus();
                        return;
                    }
                }

                // Kiểm tra số điện thoại không trùng với người khác
                if (!string.IsNullOrEmpty(sdt))
                {
                    var existing = UserRepository.GetUserByPhone(sdt);
                    if (existing != null)
                    {
                        try
                        {
                            int existingId = Convert.ToInt32(existing.UserId);
                            if (!_userId.HasValue || existingId != _userId.Value)
                            {
                                MessageBox.Show("Số điện thoại đã được sử dụng bởi người dùng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtSDT.Focus();
                                return;
                            }
                        }
                        catch
                        {
                            // ignore conversion error
                        }
                    }
                }

                // Map role text to stored value
                string vaiTro = roleText.Equals("Admin", StringComparison.OrdinalIgnoreCase) ? "Admin" : "NhanVien";

                if (_userId.HasValue)
                {
                    bool updated = UserRepository.UpdateUser(_userId.Value, hoTen, string.IsNullOrEmpty(email) ? null : email, string.IsNullOrEmpty(sdt) ? null : sdt, vaiTro);
                    if (!updated)
                    {
                        MessageBox.Show("Cập nhật người dùng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Nếu có mật khẩu mới thì đổi
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
                else
                {
                    // Không hỗ trợ thêm mới trong Edit form - nếu cần có thể dùng frmAddEditUser
                    MessageBox.Show("Không có user để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}