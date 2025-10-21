using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public class PurchasesControl : UserControl
    {
        public PurchasesControl()
        {
            var lbl = new Label();
            lbl.Text = "Quản lý nhập hàng";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16);
            this.Controls.Add(lbl);
        }
    }
}