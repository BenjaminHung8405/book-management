using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.UI.Modal;

namespace book_management.UI.Controls
{
    public class BooksControl : System.Windows.Forms.UserControl
    {
        private Panel panelMainContent;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtSearchBook;
        private ComboBox cmbCategoryFilter;
        private ComboBox cmbStatusFilter;
        private FontAwesome.Sharp.IconButton btnAddBook;
        private Panel panelPagination;
        private FlowLayoutPanel flowPaginationButtons;
        private Label lblPageInfo;
        private DataGridView dgvBooks;
        private Panel panelTopBar;

        // Pagination state
        private int currentPage = 1;
        private int pageSize = 5; // default page size
        
        private int totalRecords = 0;
        private DataGridViewImageColumn colAnhBia;
        private DataGridViewTextBoxColumn colTenSach;
        private DataGridViewTextBoxColumn colTacGia;
        private DataGridViewTextBoxColumn colTheLoai;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colTonKho;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private int totalPages = 1;

        public BooksControl()
        {
            InitializeComponent();

            // Hook load event so we can style grid after data is loaded
            this.Load += BooksControl_Load;

            // Hook DataGridView events (safe even if columns/data not yet bound)
            this.dgvBooks.CellFormatting += dgvBooks_CellFormatting;
            this.dgvBooks.CellContentClick += dgvBooks_CellContentClick;
        }

        private void BooksControl_Load(object sender, EventArgs e)
        {
            // Load first page then style
            LoadBookData(currentPage);

            // Apply visual styles after data is loaded
            StyleBooksGrid();
        }
        private void LoadBookData(int page)
        {
            if (page < 1) page = 1;
            currentPage = page;
            var all = BookRepository.GetAllBooks();
            totalRecords = all.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Ensure currentPage within bounds
            if (currentPage > totalPages) currentPage = totalPages > 0 ? totalPages : 1;

            var pageData = all.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            
            // Transform mock data so property names match the DataGridView's DataPropertyName
            // DataGridView expects: "AnhBia", "TenSach", "TenTacGia", "TenTheLoai", "Gia", "SoLuong", "TrangThaiText"
            var transformed = pageData.Select(b =>
            {
                var value = new
                {
                    // We don't load images from URL in mock, keep null (column has NullValue placeholder)
                    AnhBia = (Image)null,
                    TenSach = b.TenSach,
                    TenTacGia = b.TacGia ?? (b.TenTacGia ?? string.Empty),
                    TenTheLoai = b.TheLoai ?? string.Empty,
                    Gia = b.Gia,
                    // Provide a mock stock value and derive status text
                    SoLuong = (b.SoLuong != null) ? (int)b.SoLuong : 10,
                    TrangThaiText = ((b.SoLuong != null && (int)b.SoLuong <= 0) ? "Hết hàng" : "Còn hàng"),
                    SachId = b.SachId
                };
                return value;
            }).ToList();

            // Bind to grid
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = transformed;

            // Update pagination UI
            UpdatePaginationUI(currentPage, totalPages, totalRecords, pageSize);
        }
        private void UpdatePaginationUI(int currentPage, int totalPages, int totalRecords, int pageSize)
        {
            // Cập nhật Label thông tin
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

            // Xóa các nút cũ
            flowPaginationButtons.Controls.Clear();

            // Add "Next" (FlowDirection is RightToLeft so add first)
            Button btnNext = new Button { Text = "Sau", Size = new Size(60, 30), Margin = new Padding(1, 0, 1, 0), Tag = currentPage + 1 };
            btnNext.Click += PaginationButton_Click;
            btnNext.Enabled = (currentPage < totalPages);
            flowPaginationButtons.Controls.Add(btnNext);

            // Thêm các nút số trang (ví dụ: chỉ hiện 5 nút)
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, currentPage + 2);

            for (int i = endPage; i >= startPage; i--)
            {
                Button btnPage = new Button { Text = i.ToString(), Size = new Size(30, 30), Margin = new Padding(1, 0, 1, 0), Tag = i };
                btnPage.Click += PaginationButton_Click;
                if (i == currentPage)
                {
                    btnPage.BackColor = Color.LightBlue; // Highlight trang hiện tại
                    btnPage.ForeColor = Color.Indigo;
                    btnPage.Font = new Font(btnPage.Font, FontStyle.Bold);
                }
                flowPaginationButtons.Controls.Add(btnPage);
            }

            // Thêm nút "Trước"
            Button btnPrev = new Button { Text = "Trước", Size = new Size(60, 30), Margin = new Padding(1, 0, 1, 0), Tag = currentPage - 1 };
            btnPrev.Click += PaginationButton_Click;
            btnPrev.Enabled = (currentPage > 1);
            flowPaginationButtons.Controls.Add(btnPrev);
        }
        private void PaginationButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int pageToGo = (int)clickedButton.Tag;

            // Guard page bounds
            if (pageToGo < 1) pageToGo = 1;
            if (pageToGo > totalPages) pageToGo = totalPages;

            // Tải dữ liệu cho trang pageToGo và cập nhật lại UI phân trang
            LoadBookData(pageToGo);
        }
        private void StyleBooksGrid()
        {
            if (dgvBooks == null) return;

            // --- Header Style ---
            var headerStyle = dgvBooks.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(249, 250, 251); // bg-gray-50
            headerStyle.ForeColor = Color.FromArgb(55, 65, 81);    // text-gray-700
            headerStyle.Font = new Font("Inter", 9F, FontStyle.Bold); // text-xs, uppercase (Bold)
            headerStyle.Padding = new Padding(10, 8, 10, 8); // px-6 py-3
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBooks.ColumnHeadersHeight = 45;

            // --- Row/Cell Style ---
            var cellStyle = dgvBooks.DefaultCellStyle;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Inter", 9F, FontStyle.Regular);
            cellStyle.ForeColor = Color.FromArgb(107, 114, 128); // text-gray-500
            cellStyle.Padding = new Padding(10, 0, 10, 0); // px-6
            cellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251); // hover:bg-gray-50
            cellStyle.SelectionForeColor = Color.Black;

            // Set Row Height (py-4 for image needs more height)
            dgvBooks.RowTemplate.Height = 75; // Adjust as needed for image + padding

            // Specific column styles (guarded in case columns not present yet)
            if (dgvBooks.Columns.Contains("colTenSach"))
                dgvBooks.Columns["colTenSach"].DefaultCellStyle.ForeColor = Color.Black; // font-medium text-gray-900
            if (dgvBooks.Columns.Contains("colGiaBan"))
                dgvBooks.Columns["colGiaBan"].DefaultCellStyle.ForeColor = Color.Black; // font-semibold
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                // Clear previous formatting
                e.CellStyle.BackColor = Color.Transparent;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Inter", 8F, FontStyle.Bold); // text-xs font-medium

                if (status.Equals("Còn hàng", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // bg-green-100
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);   // text-green-800
                }
                else if (status.Equals("Hết hàng", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // bg-red-100
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);   // text-red-800
                }
                e.FormattingApplied = true;
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on header
            if (e.RowIndex < 0) return;

            // Example: if you have a hidden ID column named "colBookId" you can retrieve it here.
            // int bookId = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells["colBookId"].Value);

            if (dgvBooks.Columns[e.ColumnIndex].Name == "colEdit")
            {
                MessageBox.Show("Sửa sách (chức năng chưa triển khai)");
                // Open edit form here
            }
            else if (dgvBooks.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show("Xóa sách (chức năng chưa triển khai)");
                    // Delete logic here and refresh data grid
                }
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.colAnhBia = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.flowPaginationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnAddBook = new FontAwesome.Sharp.IconButton();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.White;
            this.panelMainContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainContent.Controls.Add(this.dgvBooks);
            this.panelMainContent.Controls.Add(this.panelPagination);
            this.panelMainContent.Controls.Add(this.panelTopBar);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(24, 24);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Padding = new System.Windows.Forms.Padding(24);
            this.panelMainContent.Size = new System.Drawing.Size(1302, 782);
            this.panelMainContent.TabIndex = 1;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToResizeColumns = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAnhBia,
            this.colTenSach,
            this.colTacGia,
            this.colTheLoai,
            this.colGiaBan,
            this.colTonKho,
            this.colTrangThai,
            this.colEdit,
            this.colDelete});
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvBooks.Location = new System.Drawing.Point(24, 84);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1252, 622);
            this.dgvBooks.TabIndex = 3;
            // 
            // colAnhBia
            // 
            this.colAnhBia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnhBia.DataPropertyName = "AnhBia";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.colAnhBia.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAnhBia.FillWeight = 1.547949F;
            this.colAnhBia.HeaderText = "Ảnh bìa";
            this.colAnhBia.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colAnhBia.Name = "colAnhBia";
            this.colAnhBia.ReadOnly = true;
            // 
            // colTenSach
            // 
            this.colTenSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenSach.DataPropertyName = "TenSach";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTenSach.FillWeight = 36.25186F;
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            // 
            // colTacGia
            // 
            this.colTacGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTacGia.DataPropertyName = "TenTacGia";
            this.colTacGia.FillWeight = 24.1679F;
            this.colTacGia.HeaderText = "Tác giả";
            this.colTacGia.Name = "colTacGia";
            this.colTacGia.ReadOnly = true;
            // 
            // colTheLoai
            // 
            this.colTheLoai.DataPropertyName = "TenTheLoai";
            this.colTheLoai.FillWeight = 26.73945F;
            this.colTheLoai.HeaderText = "Thể loại";
            this.colTheLoai.Name = "colTheLoai";
            this.colTheLoai.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "Gia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = null;
            this.colGiaBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGiaBan.FillWeight = 15.16725F;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colTonKho
            // 
            this.colTonKho.DataPropertyName = "SoLuong";
            this.colTonKho.FillWeight = 25.66965F;
            this.colTonKho.HeaderText = "Tồn kho";
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThaiText";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTrangThai.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTrangThai.FillWeight = 26.88171F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 16, 4, 16);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colEdit.FillWeight = 158.8549F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 40;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(4, 16, 0, 16);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDelete.FillWeight = 228.4264F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 40;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.flowPaginationButtons);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(24, 706);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panelPagination.Size = new System.Drawing.Size(1252, 50);
            this.panelPagination.TabIndex = 1;
            // 
            // flowPaginationButtons
            // 
            this.flowPaginationButtons.AutoSize = true;
            this.flowPaginationButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPaginationButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowPaginationButtons.Location = new System.Drawing.Point(1252, 8);
            this.flowPaginationButtons.Name = "flowPaginationButtons";
            this.flowPaginationButtons.Size = new System.Drawing.Size(0, 42);
            this.flowPaginationButtons.TabIndex = 1;
            this.flowPaginationButtons.WrapContents = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(0, 8);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(160, 20);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "Hiển thị 1-10 của 100";
            // 
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.tableLayoutPanel1);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(24, 24);
            this.panelTopBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1252, 60);
            this.panelTopBar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.cmbStatusFilter, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBook, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCategoryFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddBook, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(878, 13);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(181, 33);
            this.cmbStatusFilter.TabIndex = 3;
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearchBook.Location = new System.Drawing.Point(14, 14);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(660, 31);
            this.txtSearchBook.TabIndex = 0;
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(691, 13);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(181, 33);
            this.cmbCategoryFilter.TabIndex = 2;
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAddBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddBook.IconColor = System.Drawing.Color.White;
            this.btnAddBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddBook.IconSize = 28;
            this.btnAddBook.Location = new System.Drawing.Point(1066, 4);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(182, 52);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Thêm sách mới";
            this.btnAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // BooksControl
            // 
            this.Controls.Add(this.panelMainContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Name = "BooksControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1350, 830);
            this.panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelTopBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new frmAddEditBook())
            {
                form.ShowDialog();
            }
            // Refresh data after adding/editing
            LoadBookData(currentPage);
        }
    }
}