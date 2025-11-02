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
        private ToolTip toolTip;

        public ucBookCard()
        {
            InitializeComponent();
            
            // Khởi tạo ToolTip
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000; // Thời gian hiển thị tooltip
            toolTip.InitialDelay = 500;  // Độ trễ trước khi hiển thị
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            // *** GIẢI PHÁP: Chuyển tiếp sự kiện Click từ control con sang control cha ***
            this.pictureBox1.Click += (s, e) => this.OnClick(e);
            this.lbTenSach.Click += (s, e) => this.OnClick(e);
            this.lbTacGia.Click += (s, e) => this.OnClick(e);
            this.label1.Click += (s, e) => this.OnClick(e);
        }

        // Simple helper to populate card UI
        public void SetBookData(string title, string author, decimal price, string coverUrl)
        {
            // Gán text và tooltip cho tên sách
            lbTenSach.Text = title;
            toolTip.SetToolTip(lbTenSach, title);

            // Gán text và tooltip cho tác giả
            lbTacGia.Text = author;
            toolTip.SetToolTip(lbTacGia, author);

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
