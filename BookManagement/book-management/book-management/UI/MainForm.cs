using book_management.UI.Controls;
using System;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using book_management.UI.Theme;

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
            LoadControl(new DashboardControl());
            // Highlight default button on load
            ActivateButton(btnDashboard);
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
            LoadControl(new DashboardControl());
            ActivateButton(btnDashboard);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadControl(new SalesControl());
            ActivateButton(btnSales);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            LoadControl(new BooksControl());
            ActivateButton(btnBook);
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
    }
}
