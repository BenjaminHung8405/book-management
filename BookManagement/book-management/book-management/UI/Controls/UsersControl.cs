using book_management.UI.Modal;
using book_management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Helpers;
namespace book_management.UI.Controls
{
    public partial class UsersControl : System.Windows.Forms.UserControl
    {
        private List<dynamic> allUsers;
        private List<dynamic> filteredUsers;

        private int currentPage = 1;
        private int pageSize = 8;
        private int totalPages = 1;
        private string currentSearchKeyword = "";
        private System.Windows.Forms.Timer searchTimer;

        public UsersControl()
        {
            InitializeComponent();
            // Assign events in constructor
            this.Load += UsersControl_Load;

            InitializeEvents();
        }
        private void UsersControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFilterData(); // Gọi trước để combobox có dữ liệu
                LoadUsers(); // Sau đó mới load user
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Khởi tạo các sự kiện
        /// </summary>
        private void InitializeEvents()
        {
            // Sự kiện tìm kiếm
            txtSearchUser.TextChanged += TxtSearchUser_TextChanged;
            txtSearchUser.KeyDown += TxtSearchUser_KeyDown;

            cmbRoleFilter.SelectedIndexChanged += CmbRoleFilter_SelectedIndexChanged;
            // Sự kiện DataGridView
            dgvUsers.CellClick += DgvUsers_CellClick;
            dgvUsers.CellFormatting += DgvUsers_CellFormatting;

            // Placeholder cho textbox tìm kiếm
            SetSearchPlaceholder();
        }
        /// <summary>
        /// Load dữ liệu cho các combobox filter
        /// </summary>
        private void LoadFilterData()
        {
            try
            {
                // Nạp dữ liệu cho ComboBox Role
                cmbRoleFilter.Items.Clear();
                cmbRoleFilter.Items.Add("Tất cả vai trò");
                cmbRoleFilter.Items.Add("Admin");
                cmbRoleFilter.Items.Add("Nhan Vien");
                cmbRoleFilter.Items.Add("Khach Hang");
                cmbRoleFilter.SelectedIndex = 0; // Đặt "Tất cả" làm mặc định
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading filter data: {ex.Message}");
            }
        }
        /// <summary>
        /// Thiết lập placeholder cho textbox tìm kiếm
        /// </summary>
        private void SetSearchPlaceholder()
        {
            txtSearchUser.Text = "Tìm kiếm theo tên, số điện thoại...";
            txtSearchUser.ForeColor = Color.Gray;

            txtSearchUser.GotFocus += (s, e) =>
            {
                if (txtSearchUser.Text == "Tìm kiếm theo tên, số điện thoại...")
                {
                    txtSearchUser.Text = "";
                    txtSearchUser.ForeColor = Color.Black;
                }
            };

            txtSearchUser.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchUser.Text))
                {
                    txtSearchUser.Text = "Tìm kiếm theo tên, số điện thoại...";
                    txtSearchUser.ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        /// Load danh sách khách hàng từ database
        /// </summary>
        private void LoadUsers()
        {
            try
            {
                // Load tất cả khách hàng
                allUsers = UserRepository.GetAllUsers();
                filteredUsers = allUsers.ToList();

                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khách hàng: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Lọc danh sách User (Kết hợp Search và ComboBox)
        /// </summary>
        private void FilterUsers()
        {
            try
            {
                currentSearchKeyword = txtSearchUser.Text.Trim();
                string selectedRole = cmbRoleFilter.SelectedItem?.ToString() ?? "Tất cả vai trò";

                if (currentSearchKeyword == "Tìm kiếm theo tên, số điện thoại...")
                {
                    currentSearchKeyword = "";
                }

                // 1. Bắt đầu với danh sách đầy đủ
                var tempList = allUsers;
                //2 tim theo vai tro
                if (selectedRole != "Tất cả vai trò")
                {
                    tempList = tempList.Where(u =>
                        (u.VaiTro?.ToString() ?? "").Equals(selectedRole, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                // 3. Lọc theo Từ khóa (TextBox)
                if (!string.IsNullOrEmpty(currentSearchKeyword))
                {
                    tempList = tempList.Where(u =>
                    (u.HoTen?.ToString() ?? "").IndexOf(currentSearchKeyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (u.Username?.ToString() ?? "").IndexOf(currentSearchKeyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (u.SoDienThoai?.ToString() ?? "").IndexOf(currentSearchKeyword, StringComparison.OrdinalIgnoreCase) >= 0
                     ).ToList();
                }

                // 4. Gán kết quả
                filteredUsers = tempList;

                currentPage = 1; // Reset về trang đầu
                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc người dùng: {ex.Message}",
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật DataGridView với dữ liệu hiện tại
        /// </summary>
        private void RefreshDataGridView()
        {
            try
            {
                dgvUsers.Rows.Clear();

                // Tính toán phân trang
                totalPages = (int)Math.Ceiling((double)filteredUsers.Count / pageSize);
                if (totalPages == 0) totalPages = 1;
                // Lấy dữ liệu cho trang hiện tại
                var pageData = filteredUsers
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Thêm dữ liệu vào DataGridView
                foreach (var customer in pageData)
                {
                    dgvUsers.Rows.Add(
                    customer.HoTen,
                    customer.Username,
                    customer.Email,
                    customer.SoDienThoai,
                    customer.VaiTro,
                    customer.NgayTao.ToString("dd/MM/yyyy")
                   );

                    // Lưu UserId vào Tag của row để sử dụng sau
                    dgvUsers.Rows[dgvUsers.Rows.Count -1].Tag = customer.UserId;
                }

                // Cập nhật pagination buttons
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật danh sách: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật thông tin trang
        /// </summary>
        private void UpdatePageInfo()
        {
            int fromRecord = filteredUsers.Count == 0 ? 0 : (currentPage - 1) * pageSize + 1;
            int toRecord = Math.Min(currentPage * pageSize, filteredUsers.Count);

            lblPageInfo.Text = $"Hiển thị {fromRecord}-{toRecord} của {filteredUsers.Count} khách hàng";
        }

        /// <summary>
        /// Cập nhật các nút phân trang
        /// </summary>
        private void UpdatePaginationButtons()
        {
            flowPaginationButtons.Controls.Clear();

            if (totalPages <= 1) return;

            // Nút Previous
            if (currentPage > 1)
            {
                var btnPrev = CreatePaginationButton("‹", currentPage - 1);
                flowPaginationButtons.Controls.Add(btnPrev);
            }

            // Các nút số trang
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, currentPage + 2);

            if (startPage > 1)
            {
                flowPaginationButtons.Controls.Add(CreatePaginationButton("1", 1));
                if (startPage > 2)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
            }

            for (int i = startPage; i <= endPage; i++)
            {
                var btn = CreatePaginationButton(i.ToString(), i);
                if (i == currentPage)
                {
                    btn.BackColor = Color.FromArgb(74, 144, 226);
                    btn.ForeColor = Color.White;
                }
                flowPaginationButtons.Controls.Add(btn);
            }

            if (endPage < totalPages)
            {
                if (endPage < totalPages - 1)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
                flowPaginationButtons.Controls.Add(CreatePaginationButton(totalPages.ToString(), totalPages));
            }

            // Nút Next
            if (currentPage < totalPages)
            {
                var btnNext = CreatePaginationButton("›", currentPage + 1);
                flowPaginationButtons.Controls.Add(btnNext);
            }
        }

        /// <summary>
        /// Tạo button phân trang
        /// </summary>
        private Button CreatePaginationButton(string text, int pageNumber)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(74, 144, 226),
                Tag = pageNumber,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btn.FlatAppearance.BorderSize = 1;

            btn.Click += (s, e) =>
            {
                currentPage = (int)btn.Tag;
                RefreshDataGridView();
                UpdatePageInfo();
            };

            return btn;
        }

        /// <summary>
        /// Sự kiện tìm kiếm khi nhập text
        /// </summary>
        private void TxtSearchUser_TextChanged(object sender, EventArgs e)
        {
            searchTimer?.Stop();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval =200;
            searchTimer.Tick += (s, args) =>
            {
                searchTimer.Stop();
                FilterUsers(); // Chỉ gọi1 hàm filter duy nhất
            };
            searchTimer.Start();
        }

        /// <summary>
        /// Sự kiện nhấn Enter để tìm kiếm
        /// </summary>
        private void TxtSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                searchTimer?.Stop();
                FilterUsers(); // Chỉ gọi 1 hàm filter duy nhất
                e.Handled = true;
            }
        }

        /// <summary>
        /// Sự kiện click vào DataGridView
        /// </summary>
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var khId = (int)dgvUsers.Rows[e.RowIndex].Tag;
            string columnName = dgvUsers.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "colEdit":
                    EditUser(khId);
                    break;
                case "colDelete":
                    DeleteUser(khId);
                    break;
            }
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        private void EditUser(int khId)
        {
            try
            {
                var user = UserRepository.GetUserById(khId);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo form edit (có thể tái sử dụng frmAddCustomer)
                using (var editForm = new EditUserControl())
                {
                    editForm.Text = "Sửa thông tin khách hàng";
                    // editForm.SetCustomerInfo(customer); // Cần implement method này

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa thông tin khách hàng: {ex.Message}",
             "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        private void DeleteUser(int khId)
        {
            try
            {
                var user = UserRepository.GetUserById(khId);
                if (user == null)
                {
                    return;
                }

                var result = MessageBox.Show(
                 $"Bạn có chắc chắn muốn xóa khách hàng '{user.HoTen}'?\n" +
                          "Lưu ý: Chỉ có thể xóa khách hàng chưa có hóa đơn nào.",
                 "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = UserRepository.DeleteUser(khId);
                    if (success)
                    {
                        LoadUsers();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}",
          "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format hiển thị cho DataGridView
        /// </summary>
        private void DgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Format cho cột ngày tạo
                if (dgvUsers.Columns[e.ColumnIndex].Name == "colNgayTao" && e.Value != null)
                {
                    if (DateTime.TryParse(e.Value.ToString(), out DateTime date))
                    {
                        e.Value = date.ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                }

                // Highlight khách vãng lai
                if (e.RowIndex >= 0)
                {
                    var tenKhach = dgvUsers.Rows[e.RowIndex].Cells["colHoTen"].Value?.ToString();
                    if (tenKhach == "Khách vãng lai" || string.IsNullOrEmpty(tenKhach))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 248, 220); // Light yellow
                        e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14); // Dark yellow
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi formatting: {ex.Message}");
            }
        }
        private void CmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTimer?.Stop();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 200;
            searchTimer.Tick += (s, args) =>
            {
                searchTimer.Stop();
                FilterUsers(); // Gọi hàm lọc tổng hợp
            };
            searchTimer.Start();
        }
        /// <summary>
        /// Refresh danh sách (có thể gọi từ form khác)
        /// </summary>
        public void RefreshCustomerList()
        {
            LoadUsers();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddEditUser())
            {
                form.ShowDialog();
            }
        }


    }
}
