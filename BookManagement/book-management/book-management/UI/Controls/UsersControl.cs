using book_management.UI.Modal;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public partial class UsersControl : System.Windows.Forms.UserControl
    {
        public UsersControl()
        {
            InitializeComponent();
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
