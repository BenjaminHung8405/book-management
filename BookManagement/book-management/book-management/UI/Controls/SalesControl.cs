using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace book_management.UI.Controls
{
    public class SalesControl : System.Windows.Forms.UserControl
    {
        private TextBox txtCustomerSearch;
        private TextBox txtCustomerName;
        private DataGridView dgvInvoice;
        private Label lblTotalValue;
        private Button btnPay;
        private TextBox txtProductSearch;
        private FlowLayoutPanel flpProducts;

        private List<Product> products = new List<Product>
        {
            new Product { Name = "Đắc Nhân Tâm", Author = "Dale Carnegie", Price = 99000m, ImageUrl = "https://placehold.co/60x80" },
            new Product { Name = "Nhà Giả Kim", Author = "Paulo Coelho", Price = 79000m, ImageUrl = "https://placehold.co/60x80" },
            new Product { Name = "Bắt Trẻ Đồng Xanh", Author = "J.D. Salinger", Price = 120000m, ImageUrl = "https://placehold.co/60x80" }
        };

        public SalesControl()
        {
            InitializeComponent();
            SetupUI();
            PopulateProducts(products);
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(12);
            this.BackColor = Color.FromArgb(245, 247, 250);

            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1 };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));

            // Left panel (invoice)
            var leftPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(0) };
            leftPanel.Margin = new Padding(0);

            // Header
            var header = new Panel { Dock = DockStyle.Top, Height = 100, Padding = new Padding(12) };
            var lblHeader = new Label { Text = "HÓA ĐƠN BÁN HÀNG", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Dock = DockStyle.Top, Height = 28 };
            var headerInputs = new TableLayoutPanel { Dock = DockStyle.Bottom, ColumnCount = 2, Height = 40 };
            headerInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            headerInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            txtCustomerSearch = new TextBox { Dock = DockStyle.Fill, Margin = new Padding(6) };
            SetPlaceholder(txtCustomerSearch, "Tìm khách hàng (SĐT)...");
            txtCustomerSearch.TextChanged += TxtCustomerSearch_TextChanged;
            txtCustomerName = new TextBox { Text = "Khách vãng lai", Dock = DockStyle.Fill, Margin = new Padding(6), Enabled = false, BackColor = Color.FromArgb(240, 240, 240) };

            headerInputs.Controls.Add(txtCustomerSearch, 0, 0);
            headerInputs.Controls.Add(txtCustomerName, 1, 0);

            header.Controls.Add(headerInputs);
            header.Controls.Add(lblHeader);

            // Middle: invoice items (DataGridView)
            dgvInvoice = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None
            };

            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProduct", HeaderText = "Sản phẩm" });
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQuantity", HeaderText = "Số lượng", Width = 80 });
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnitPrice", HeaderText = "Đơn giá", Width = 120 });
            dgvInvoice.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Thành tiền", Width = 120 });
            var btnCol = new DataGridViewButtonColumn { Name = "colRemove", HeaderText = "", Text = "X", UseColumnTextForButtonValue = true, Width = 40 };
            dgvInvoice.Columns.Add(btnCol);

            dgvInvoice.CellContentClick += DgvInvoice_CellContentClick;
            dgvInvoice.CellEndEdit += DgvInvoice_CellEndEdit;

            // Bottom: totals and pay
            var bottom = new Panel { Dock = DockStyle.Bottom, Height = 120, Padding = new Padding(12), BackColor = Color.FromArgb(250, 250, 250) };
            var totalPanel = new Panel { Dock = DockStyle.Top, Height = 40 };
            var lblTotalText = new Label { Text = "Tổng cộng:", Dock = DockStyle.Left, AutoSize = true, Font = new Font("Segoe UI", 10F) };
            lblTotalValue = new Label { Text = FormatCurrency(0m), Dock = DockStyle.Right, AutoSize = true, Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Color.FromArgb(74, 144, 226) };
            totalPanel.Controls.Add(lblTotalText);
            totalPanel.Controls.Add(lblTotalValue);

            btnPay = new Button { Text = "THANH TOÁN", Dock = DockStyle.Bottom, Height = 48, BackColor = Color.FromArgb(34, 197, 94), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            btnPay.Click += BtnPay_Click;

            bottom.Controls.Add(btnPay);
            bottom.Controls.Add(totalPanel);

            leftPanel.Controls.Add(dgvInvoice);
            leftPanel.Controls.Add(bottom);
            leftPanel.Controls.Add(header);

            // Right panel (product search)
            var rightPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(0) };
            var rightHeader = new Panel { Dock = DockStyle.Top, Height = 64, Padding = new Padding(12) };
            txtProductSearch = new TextBox { Dock = DockStyle.Fill };
            SetPlaceholder(txtProductSearch, "Tìm sách theo tên hoặc mã...");
            txtProductSearch.TextChanged += TxtProductSearch_TextChanged;
            rightHeader.Controls.Add(txtProductSearch);

            flpProducts = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(12), FlowDirection = FlowDirection.TopDown, WrapContents = false };

            rightPanel.Controls.Add(flpProducts);
            rightPanel.Controls.Add(rightHeader);

            main.Controls.Add(leftPanel, 0, 0);
            main.Controls.Add(new Panel(), 1, 0); // gap
            main.Controls.Add(rightPanel, 2, 0);

            this.Controls.Add(main);
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Tag = placeholder;
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;
            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == (string)tb.Tag)
                {
                    tb.Text = string.Empty;
                    tb.ForeColor = Color.Black;
                }
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = (string)tb.Tag;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private void TxtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            // placeholder for customer lookup; keep as vãng lai
        }

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            var q = txtProductSearch.Text?.Trim().ToLower() ?? string.Empty;
            var placeholder = txtProductSearch.Tag as string ?? string.Empty;
            if (q == placeholder.ToLower()) q = string.Empty;
            var filtered = products.Where(p => p.Name.ToLower().Contains(q) || p.Author.ToLower().Contains(q)).ToList();
            PopulateProducts(filtered);
        }

        private void PopulateProducts(List<Product> list)
        {
            flpProducts.Controls.Clear();
            foreach (var p in list)
            {
                var item = CreateProductItem(p);
                flpProducts.Controls.Add(item);
            }
        }

        private Control CreateProductItem(Product p)
        {
            var container = new Panel { Height = 72, Margin = new Padding(0, 0, 0, 8), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Dock = DockStyle.Top };

            var pic = new PictureBox { Width = 48, Height = 64, Left = 8, Top = 4, SizeMode = PictureBoxSizeMode.Zoom };            
            try { pic.Load(p.ImageUrl); } catch { }

            var lblName = new Label { Text = p.Name, Left = 64, Top = 8, AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            var lblAuthor = new Label { Text = p.Author, Left = 64, Top = 28, AutoSize = true, Font = new Font("Segoe UI", 8F), ForeColor = Color.Gray };
            var lblPrice = new Label { Text = FormatCurrency(p.Price), Left = 64, Top = 46, AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(74, 144, 226) };

            var icon = new IconPictureBox { IconChar = IconChar.PlusCircle, IconColor = Color.FromArgb(74, 144, 226), Width = 28, Height = 28, Left = container.Width - 36, Top = 22, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            container.Controls.Add(pic);
            container.Controls.Add(lblName);
            container.Controls.Add(lblAuthor);
            container.Controls.Add(lblPrice);
            container.Controls.Add(icon);

            container.Cursor = Cursors.Hand;
            container.Click += (s, e) => AddProductToInvoice(p);
            // also hook child controls to propagate click
            foreach (Control c in container.Controls) c.Click += (s, e) => AddProductToInvoice(p);

            return container;
        }

        private void AddProductToInvoice(Product p)
        {
            // If exists, increase quantity
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.Cells[0].Value?.ToString() == p.Name)
                {
                    int q = ParseInt(row.Cells[1].Value) + 1;
                    row.Cells[1].Value = q.ToString();
                    UpdateRowTotal(row);
                    UpdateTotals();
                    return;
                }
            }

            var index = dgvInvoice.Rows.Add();
            var newRow = dgvInvoice.Rows[index];
            newRow.Cells[0].Value = p.Name;
            newRow.Cells[1].Value = "1";
            newRow.Cells[2].Value = FormatCurrency(p.Price);
            newRow.Cells[3].Value = FormatCurrency(p.Price);
            UpdateTotals();
        }

        private void DgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "colRemove")
            {
                dgvInvoice.Rows.RemoveAt(e.RowIndex);
                UpdateTotals();
            }
        }

        private void DgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvInvoice.Rows[e.RowIndex];
            if (e.ColumnIndex == 1) // quantity changed
            {
                int q = ParseInt(row.Cells[1].Value);
                if (q < 1) q = 1;
                row.Cells[1].Value = q.ToString();
                UpdateRowTotal(row);
                UpdateTotals();
            }
        }

        private void UpdateRowTotal(DataGridViewRow row)
        {
            decimal unit = ParseCurrency(row.Cells[2].Value?.ToString());
            int q = ParseInt(row.Cells[1].Value);
            row.Cells[3].Value = FormatCurrency(unit * q);
        }

        private void UpdateTotals()
        {
            decimal sum = 0m;
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                sum += ParseCurrency(row.Cells[3].Value?.ToString());
            }
            lblTotalValue.Text = FormatCurrency(sum);
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Thanh toán thành công: {lblTotalValue.Text}", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvInvoice.Rows.Clear();
            UpdateTotals();
        }

        private int ParseInt(object value)
        {
            if (value == null) return 0;
            int.TryParse(value.ToString(), out int r);
            return r;
        }

        private decimal ParseCurrency(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0m;
            // remove non digits
            var cleaned = new string(text.Where(c => char.IsDigit(c)).ToArray());
            if (decimal.TryParse(cleaned, out decimal v))
            {
                return v;
            }
            return 0m;
        }

        private string FormatCurrency(decimal value)
        {
            // format like 277.000đ
            return string.Format(CultureInfo.InvariantCulture, "{0:N0}đ", value);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SalesControl
            // 
            this.Name = "SalesControl";
            this.Size = new System.Drawing.Size(597, 360);
            this.ResumeLayout(false);

        }

        private class Product
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}