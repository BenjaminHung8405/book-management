using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            var lbl = new Label();
            lbl.Text = "Báo cáo";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16);
            this.Controls.Add(lbl);
        }
    }
}