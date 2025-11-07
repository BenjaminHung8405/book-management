using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.UI.Modal;
using System.Collections.Generic; // Thêm thư viện này

namespace book_management.UI.Controls
{
    // Đảm bảo có 'partial'
    public partial class BooksControl : System.Windows.Forms.UserControl
    {
        // Pagination state
        private int currentPage = 1;
        private int pageSize = 5;
        private int totalRecords = 0;
        private int totalPages = 1;

        public BooksControl()
        {
            // Hàm này sẽ gọi code từ file .Designer.cs
            InitializeComponent();

            // SỬA LỖI: Gán sự kiện PHẢI được đặt ở hàm khởi tạo
            this.Load += BooksControl_Load;
            this.dgvBooks.CellFormatting += dgvBooks_CellFormatting;
            this.dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
        }

        // SỬA LỖI: Hàm Load chỉ để tải dữ liệu, không gán sự kiện
        private void BooksControl_Load(object sender, EventArgs e)
        {
            LoadBookData(currentPage);
            dgvBooks.AutoGenerateColumns = false;
        }

        private void LoadBookData(int page)
        {
            if (page < 1) page = 1;
            currentPage = page;
            var all = BookRepository.GetAllBooks();
            totalRecords = all.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (currentPage > totalPages) currentPage = totalPages > 0 ? totalPages : 1;

            var pageData = all.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var transformed = pageData.Select(b =>
            {
                var value = new
                {
                    AnhBia = (Image)null,
                    TenSach = b.TenSach,
                    TenTacGia = b.TacGia ?? (b.TenTacGia ?? string.Empty),
                    TenTheLoai = b.TheLoai ?? string.Empty,
                    Gia = b.Gia,
                    SoLuong = (b.SoLuong != null) ? (int)b.SoLuong : 10,
                    TrangThaiText = ((b.SoLuong != null && (int)b.SoLuong <= 0) ? "Hết hàng" : "Còn hàng"),
                };
                return value;
            }).ToList();

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = transformed;

            StyleBooksGrid();
            UpdatePaginationUI(currentPage, totalPages, totalRecords, pageSize);
        }

        private void UpdatePaginationUI(int currentPage, int totalPages, int totalRecords, int pageSize)
        {
            int startRecord = ((currentPage - 1) * pageSize) + 1;
            int endRecord = Math.Min(currentPage * pageSize, totalRecords);
            if (totalRecords == 0)
            {
                lblPageInfo.Text = "Hiển thị 0-0 của 0";
            }
            else
            {
                lblPageInfo.Text = $"Hiển thị {startRecord}-{endRecord} của {totalRecords}";
            }

            flowPaginationButtons.Controls.Clear();

            Button btnNext = new Button { Text = "Sau", Size = new Size(60, 30), Margin = new Padding(1, 0, 1, 0), Tag = currentPage + 1 };
            btnNext.Click += PaginationButton_Click;
            btnNext.Enabled = (currentPage < totalPages);
            flowPaginationButtons.Controls.Add(btnNext);

            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, currentPage + 2);

            for (int i = endPage; i >= startPage; i--)
            {
                Button btnPage = new Button { Text = i.ToString(), Size = new Size(30, 30), Margin = new Padding(1, 0, 1, 0), Tag = i };
                btnPage.Click += PaginationButton_Click;
                if (i == currentPage)
                {
                    btnPage.BackColor = Color.LightBlue;
                    btnPage.ForeColor = Color.Indigo;
                    btnPage.Font = new Font(btnPage.Font, FontStyle.Bold);
                }
                flowPaginationButtons.Controls.Add(btnPage);
            }

            Button btnPrev = new Button { Text = "Trước", Size = new Size(60, 30), Margin = new Padding(1, 0, 1, 0), Tag = currentPage - 1 };
            btnPrev.Click += PaginationButton_Click;
            btnPrev.Enabled = (currentPage > 1);
            flowPaginationButtons.Controls.Add(btnPrev);
        }

        private void PaginationButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int pageToGo = (int)clickedButton.Tag;

            if (pageToGo < 1) pageToGo = 1;
            if (pageToGo > totalPages) pageToGo = totalPages;

            LoadBookData(pageToGo);
        }

        private void StyleBooksGrid()
        {
            if (dgvBooks == null) return;

            var headerStyle = dgvBooks.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(249, 250, 251);
            headerStyle.ForeColor = Color.FromArgb(55, 65, 81);
            headerStyle.Font = new Font("Inter", 9F, FontStyle.Bold);
            headerStyle.Padding = new Padding(10, 8, 10, 8);
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBooks.ColumnHeadersHeight = 45;

            var cellStyle = dgvBooks.DefaultCellStyle;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Inter", 9F, FontStyle.Regular);
            cellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            cellStyle.Padding = new Padding(10, 0, 10, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            cellStyle.SelectionForeColor = Color.Black;

            dgvBooks.RowTemplate.Height = 75;

            if (dgvBooks.Columns.Contains("colTenSach"))
                dgvBooks.Columns["colTenSach"].DefaultCellStyle.ForeColor = Color.Black;
            if (dgvBooks.Columns.Contains("colGiaBan"))
                dgvBooks.Columns["colGiaBan"].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.BackColor = Color.Transparent;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Inter", 8F, FontStyle.Bold);

                if (status.Equals("Còn hàng", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                }
                else if (status.Equals("Hết hàng", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                }
                e.FormattingApplied = true;
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBooks.Columns[e.ColumnIndex].Name == "colEdit")
            {
                MessageBox.Show("Sửa sách (chức năng chưa triển khai)");
            }
            else if (dgvBooks.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show("Xóa sách (chức năng chưa triển khai)");
                }
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddEditBook())
            {
                form.ShowDialog();
            }
            LoadBookData(currentPage);
        }
    }
}