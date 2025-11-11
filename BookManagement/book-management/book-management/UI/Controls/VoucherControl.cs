using book_management.UI.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public partial class VoucherControl : UserControl
    {
        public VoucherControl()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddVoucher())
            {
                form.ShowDialog();
            }
        }
    }
}
