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
    public partial class frmAddEditBook : Form
    {
        public frmAddEditBook()
        {
            InitializeComponent();

            // Set properties for Cancel button
            btnCancelModal.DialogResult = DialogResult.Cancel;
            btnCancelModal.Click += btnCancelModal_Click;

            // Set properties for Save button
            btnSaveBook.DialogResult = DialogResult.OK;
            btnSaveBook.Click += btnSaveBook_Click;
        }

        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            // TODO: Add validation and saving logic here
            MessageBox.Show("Save logic not implemented yet.");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
