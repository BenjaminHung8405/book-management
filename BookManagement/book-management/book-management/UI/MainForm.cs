using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.UI.Controls;

namespace book_management.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Load default control
            LoadControl(new OverviewControl());
        }

        private void LoadControl(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            LoadControl(new OverviewControl());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            LoadControl(new SalesControl());
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            LoadControl(new BooksControl());
        }

        private void btnQuanLyNhapHang_Click(object sender, EventArgs e)
        {
            LoadControl(new PurchasesControl());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportsControl());
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            LoadControl(new UsersControl());
        }
    }
}
