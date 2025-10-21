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
    public partial class ucBookCard : UserControl
    {
        public ucBookCard()
        {
            InitializeComponent();
        }

        // Simple helper to populate card UI
        public void SetBookData(string title, string author, decimal price, string coverUrl)
        {
            lbTenSach.Text = title;
            lbTacGia.Text = author;
            label1.Text = price.ToString("N0") + "₫";

            if (!string.IsNullOrEmpty(coverUrl))
            {
                try
                {
                    var req = System.Net.WebRequest.Create(coverUrl);
                    using (var resp = req.GetResponse())
                    using (var stream = resp.GetResponseStream())
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    // ignore — leave default blank image
                }
            }
        }
    }
}
