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

namespace book_management.UI.Modal
{
    public partial class frmAddImport : System.Windows.Forms.Form
    {
        private dynamic _bookToEdit;

        public frmAddImport(dynamic bookToEdit = null)
        {
            InitializeComponent();
        }
        private void btnSaveBook_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}