using book_management.UI.Controls;
using System;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using book_management.UI.Theme;
using book_management.Data; // Thêm namespace để sử dụng DatabaseTestForm và CurrentUser

namespace book_management.UI
{
    public partial class MainForm : Form
    {
        private bool _isSelected = false;
        private IconButton _currentButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigureButtonsByRole();
            if (CurrentUser.IsCustomer)
            {
                LoadControl(new StoreControl());
                //// Highlight default button on load
                ActivateButton(btnSales);
            }
            else
            {
                ShowDashboard();
            }
            // Hiển thị thông tin người dùng hiện tại
            UpdateUserInfo();
        }
        ///
        private void ConfigureButtonsByRole()
        {

            switch (CurrentUser.Role)
            {
                case "Admin":
                    // Admin có quyền truy cập tất cả
                    ShowAllButtons();
                    break;
                case "NhanVien":
                    // Nhân viên không có quyền truy cập quản lý người dùng và báo cáo
                    btnUser.Visible = false;
                    btnReport.Visible = false;
                    break;
                default:
                    // Vai trò không xác định, ẩn tất cả các nút chức năng nhạy cảm
                    HideSensitiveButtons();
                    break;
            }
        }
        /// 

        /// Hiện thị tất cả các nút chức năng
        private void ShowAllButtons()
        {
            btnDashboard.Visible = true;
            btnSales.Visible = true;
            btnUser.Visible = true;
            btnReport.Visible = true;
            btnBooks.Visible = true;
            btnInvoice.Visible = true;
        }
        ///

        /// ẩn các nút chuc năng nhạy cảm
        private void HideSensitiveButtons()
        {
            btnBooks.Visible = false;
            btnUser.Visible = false;
            btnReport.Visible = false;
            btnInvoice.Visible = false;
            btnCustomer.Visible = false;
        }
        /// 

        /// <summary>
        /// Tạo, đăng ký sự kiện, và tải DashboardControl
        /// </summary>
        private void ShowDashboard()
        {
            // 1. Tạo control MỚI
            DashboardControl dashboard = new DashboardControl();

            // 2. Đăng ký lại sự kiện (QUAN TRỌNG NHẤT)
            dashboard.CreateInvoiceClicked += Dashboard_CreateInvoiceClicked;

            // 3. Tải control
            LoadControl(dashboard);
            ActivateButton(btnDashboard);
        }

        /// <summary>
        /// Cập nhật thông tin người dùng hiển thị trên giao diện
        /// </summary>
        private void UpdateUserInfo()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lbUsername.Text = CurrentUser.FullName ?? CurrentUser.Username;
                lbRole.Text = CurrentUser.GetRoleDisplayName();

                // Có thể thêm màu sắc khác nhau cho các vai trò
                switch (CurrentUser.Role)
                {
                    case "Admin":
                        lbRole.ForeColor = Color.Red;
                        break;
                    case "NhanVien":
                        lbRole.ForeColor = Color.Blue;
                        break;
                    case "KhachHang":
                        lbRole.ForeColor = Color.Green;
                        break;
                    default:
                        lbRole.ForeColor = Color.Black;
                        break;
                }
                ConfigureButtonsByRole();
            }
            else
            {
                lbUsername.Text = "Khách";
                lbRole.Text = "Chưa đăng nhập";
                lbRole.ForeColor = Color.Gray;
                HideSensitiveButtons();
            }
        }
        /// <summary>
        /// Xử lý đăng xuất người dùng
        /// </summary>
        private void Logout()
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đăng xuất người dùng hiện tại
                CurrentUser.Logout();

                // Đóng MainForm
                this.Hide();
                // Hiển thị lại LoginForm
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào dropdown menu
        /// </summary>
        private void iconDropDownMenuProfile_Click(object sender, EventArgs e)
        {
            // Tạo context menu cho dropdown
            var contextMenu = new ContextMenuStrip();

            // Thêm menu items
            var profileItem = new ToolStripMenuItem("Thông tin cá nhân");
            profileItem.Click += (s, args) => OpenProfileForm();

            var logoutItem = new ToolStripMenuItem("Đăng xuất");
            logoutItem.Click += (s, args) => Logout();

            contextMenu.Items.Add(profileItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(logoutItem);

            // Hiển thị context menu
            var button = sender as Control;
            contextMenu.Show(button, new Point(0, button.Height));
        }
        private void pnUser_Click(object sender, EventArgs e)
        {
            // Gọi cùng phương thức xử lý dropdown
            iconDropDownMenuProfile_Click(sender, e);
        }

        /// <summary>
        /// Mở form thông tin cá nhân
        /// </summary>
        private void OpenProfileForm()
        {
            try
            {
                MessageBox.Show($"Thông tin người dùng:\n\n" +
                    $"Tên đăng nhập: {CurrentUser.Username}\n" +
               $"Họ tên: {CurrentUser.FullName}\n" +
                $"Email: {CurrentUser.Email}\n" +
                     $"Số điện thoại: {CurrentUser.Phone}\n" +
               $"Vai trò: {CurrentUser.GetRoleDisplayName()}",
                   "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị thông tin: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Xử lý khi nút "Tạo hóa đơn" TỪ TRANG InvoicesControl được nhấn
        /// </summary>
        private void InvoicesControl_AddInvoiceClicked(object sender, EventArgs e)
        {
            // Chuyển sang trang SalesControl
            LoadControl(new SalesControl());

        }
        private void LoadControl(System.Windows.Forms.UserControl uc)
        {
            // Xóa bất kỳ control nào đang có trong panelContent
            this.panelContent.Controls.Clear();

            // Thêm UserControl mới vào
            uc.Dock = DockStyle.Fill; // Cho nó lấp đầy panel
            this.panelContent.Controls.Add(uc);
        }

        // Reset all IconButton controls under the given parent to inactive state
        private void ResetButtons(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is IconButton ib)
                {
                    ib.BackColor = AppColors.SidebarInactive;
                    ib.ForeColor = AppColors.TextPrimary;
                    ib.IconColor = AppColors.TextPrimary;
                }
                else if (ctrl.HasChildren)
                {
                    ResetButtons(ctrl);
                }
            }
        }

        private void ActivateButton(IconButton activeBtn)
        {
            if (activeBtn == null)
                return;

            // If the same button is clicked again, do nothing
            if (_currentButton == activeBtn)
                return;

            // Reset all sidebar buttons to default (inactive)
            ResetButtons(panelSidebar);

            // Highlight the new active button
            activeBtn.BackColor = AppColors.Primary;
            activeBtn.ForeColor = AppColors.OnPrimary;
            activeBtn.IconColor = AppColors.OnPrimary;

            _currentButton = activeBtn;
            _isSelected = true;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadControl(new StoreControl());
            ActivateButton(btnSales);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            LoadControl(new UsersControl());
            ActivateButton(btnUser);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportControl());
            ActivateButton(btnReport);
        }

        /// <summary>
        /// Override xử lý khi form đóng để đảm bảo đăng xuất người dùng
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CurrentUser.Logout();
            base.OnFormClosed(e);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            LoadControl(new BooksControl());
            ActivateButton(btnBooks);
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            // 1. Tạo control
            var invoicesControl = new InvoicesControl();

            // 2. ĐĂNG KÝ (Subscribe) sự kiện mới
            invoicesControl.AddInvoiceClicked += InvoicesControl_AddInvoiceClicked;

            // 3. Tải control
            LoadControl(invoicesControl);
            ActivateButton(btnInvoice);
        }
        private void Dashboard_CreateInvoiceClicked(object sender, EventArgs e)
        {
            LoadControl(new StoreControl());

            // Kích hoạt (highlight) nút Bán Hàng
            ActivateButton(btnSales);
        }
    }
}
