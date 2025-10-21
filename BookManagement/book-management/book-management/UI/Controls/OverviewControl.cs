using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace book_management.UI.Controls
{
    public class OverviewControl : UserControl
    {
        public OverviewControl()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Padding = new Padding(12);

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Top: stat cards (4 columns)
            var stats = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                Margin = new Padding(0, 0, 0, 12)
            };
            for (int i = 0; i < 4; i++)
                stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            stats.Controls.Add(CreateStatCard("Doanh thu hôm nay", "15.2M", Color.FromArgb(227, 242, 253), IconChar.DollarSign), 0, 0);
            stats.Controls.Add(CreateStatCard("Đơn hàng mới", "125", Color.FromArgb(232, 245, 233), IconChar.ShoppingBag), 1, 0);
            stats.Controls.Add(CreateStatCard("Sách đã bán", "350", Color.FromArgb(255, 244, 229), IconChar.Book), 2, 0);
            stats.Controls.Add(CreateStatCard("Khách hàng mới", "32", Color.FromArgb(243, 230, 249), IconChar.UserPlus), 3, 0);

            // Bottom: left = low-stock table, right = pie chart placeholder
            var bottom = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                ColumnStyles = { new ColumnStyle(SizeType.Percent, 66F), new ColumnStyle(SizeType.Absolute, 12F), new ColumnStyle(SizeType.Percent, 34F) }
            };

            // Left panel with DataGridView
            var leftPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12) };
            var leftHeader = new Label { Text = "Sách sắp hết hàng (Tồn kho < 10)", Dock = DockStyle.Top, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Height = 28 };
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add("colName", "Tên Sách");
            dgv.Columns.Add("colAuthor", "Tác Giả");
            var stockCol = new DataGridViewTextBoxColumn { Name = "colStock", HeaderText = "Tồn Kho", DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } };
            dgv.Columns.Add(stockCol);

            dgv.Rows.Add("Nhà Giả Kim", "Paulo Coelho", "8");
            dgv.Rows.Add("Cây Cam Ngọt Của Tôi", "José Mauro", "5");
            dgv.Rows.Add("Bắt Trẻ Đồng Xanh", "J.D. Salinger", "10");

            leftPanel.Controls.Add(dgv);
            leftPanel.Controls.Add(leftHeader);

            // Right panel with pie chart placeholder
            var rightPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12) };
            var rightHeader = new Label { Text = "Thể loại bán chạy", Dock = DockStyle.Top, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Height = 28 };
            var pic = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom };
            // use placeholder image URL
            try
            {
                pic.Load("https://placehold.co/400x400/FFFFFF/4A90E2?text=Pie+Chart");
            }
            catch
            {
                // ignore if network unavailable
            }

            rightPanel.Controls.Add(pic);
            rightPanel.Controls.Add(rightHeader);

            bottom.Controls.Add(leftPanel, 0, 0);
            // gap column left empty at index 1
            bottom.Controls.Add(rightPanel, 2, 0);

            main.Controls.Add(stats, 0, 0);
            main.Controls.Add(bottom, 0, 1);

            this.Controls.Add(main);
        }

        private Control CreateStatCard(string label, string value, Color iconBg, IconChar iconChar)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12), Margin = new Padding(6) };
            var inner = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            inner.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            var icon = new IconPictureBox { Width = 56, Height = 56, BackColor = iconBg, IconChar = iconChar, IconColor = Color.DimGray, IconSize = 28, Padding = new Padding(8) };

            var lblTitle = new Label { Text = label, Dock = DockStyle.Top, ForeColor = Color.FromArgb(100, 100, 100), Font = new Font("Segoe UI", 9F) };
            var lblValue = new Label { Text = value, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Color.FromArgb(40, 40, 40) };

            var rightPanel = new Panel { Dock = DockStyle.Fill };
            rightPanel.Controls.Add(lblValue);
            rightPanel.Controls.Add(lblTitle);

            inner.Controls.Add(icon);
            inner.Controls.Add(rightPanel);

            card.Controls.Add(inner);
            card.BorderStyle = BorderStyle.None;
            return card;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OverviewControl
            // 
            this.Name = "OverviewControl";
            this.Size = new System.Drawing.Size(597, 360);
            this.ResumeLayout(false);

        }
    }
}