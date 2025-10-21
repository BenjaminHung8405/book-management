using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            var lbl = new Label();
            lbl.Text = "Cài đặt";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Segoe UI", 16);
            this.Controls.Add(lbl);
        }
    }
}