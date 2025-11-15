using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data;
using book_management.Services;
using book_management.UI.Modal;
using book_management.Helpers;

namespace book_management.UI.Controls
{
    public partial class BooksControl : System.Windows.Forms.UserControl
    {
        #region Fields and Properties
        // Pagination state
        private int currentPage =1;
        private int pageSize =8;
        private int totalRecords =0;
        private int totalPages =1;

        // Filter data - Tương tự như CustomersControl
        private List<dynamic> allBooks; // Tất cả sách từ database
        private List<dynamic> filteredBooks; // Sách sau khi filter
        private string currentSearchKeyword = "";
        private string currentCategoryFilter = "";
        private string currentStatusFilter = "";
        private System.Windows.Forms.Timer filterTimer; // Timer để delay filter

        // Placeholder image for missing/failed loads
        private Image placeholderCover;
        #endregion

        #region Constructor
        public BooksControl()
        {
            InitializeComponent();

            // Assign events in constructor
            this.Load += BooksControl_Load;
            this.VisibleChanged += BooksControl_VisibleChanged;
            this.dgvBooks.CellFormatting += dgvBooks_CellFormatting;
            this.dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            this.dgvBooks.DataError += dgvBooks_DataError;
            this.btnAddBook.Click += btnAddBook_Click;

            // Initialize placeholder (optional): small blank bitmap
            placeholderCover = new Bitmap(1,1);

            // Initialize filter events - Tương tự CustomersControl
            InitializeFilterEvents();
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Khởi tạo các sự kiện filter
        /// </summary>
        private void InitializeFilterEvents()
        {
            // Events cho combobox filters
            cmbCategoryFilter.SelectedIndexChanged += CmbCategoryFilter_SelectedIndexChanged;
            cmbCategoryFilter.KeyDown += CmbCategoryFilter_KeyDown;
            cmbCategoryFilter.Leave += CmbCategoryFilter_Leave;
            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
            txtSearchBook.TextChanged += txtSearchBook_TextChanged;
            txtSearchBook.KeyDown += TxtSearchBook_KeyDown;
            SetSearchPlaceholder();
            // Load filter data
            LoadFilterData();
        }

        /// <summary>
        /// Load dữ liệu cho các combobox filter
        /// </summary>
        private void LoadFilterData()
        {
            try
            {
                // Load categories
                cmbCategoryFilter.Items.Clear();
                cmbCategoryFilter.Items.Add("Tất cả thể loại");
                // hien thi sach thong qua combobox tat ca the loai
                var categories = BookRepository.GetAllCategories();
                foreach (var category in categories)
                {
                    cmbCategoryFilter.Items.Add(category.TenTheLoai);
                }
                cmbCategoryFilter.SelectedIndex =0;

                // Load status options
                cmbStatusFilter.Items.Clear();
                cmbStatusFilter.Items.Add("Tất cả trạng thái");
                cmbStatusFilter.Items.Add("Còn hàng");
                cmbStatusFilter.Items.Add("Hết hàng");
                cmbStatusFilter.Items.Add("Sắp hết");
                cmbStatusFilter.SelectedIndex =0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading filter data: {ex.Message}");
            }
        }

        private void BooksControl_Load(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("=== BooksControl_Load ===");
                InitializeDataGridView();

                // Load books - Tương tự CustomersControl
                LoadBooks();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BooksControl_Load Error: {ex}");
                MessageBox.Show($"Lỗi khi load BooksControl: {ex.Message}", "Lỗi",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Thiết lập placeholder cho textbox tìm kiếm
        /// </summary>
        private void SetSearchPlaceholder()
        {
            txtSearchBook.Text = "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...";
            txtSearchBook.ForeColor = Color.Gray;

            txtSearchBook.GotFocus += (s, e) =>
            {
                if (txtSearchBook.Text == "Tìm kiếm theo tên, số điện thoại hoặc địa chỉ...")
                {
                    txtSearchBook.Text = "";
                    txtSearchBook.ForeColor = Color.Black;
                }
            };

            txtSearchBook.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchBook.Text))
                {
                    txtSearchBook.Text = "Tìm kiếm theo tên, thể loại, trạng thái...";
                    txtSearchBook.ForeColor = Color.Gray;
                }
            };
        }
        /// <summary>
        /// Tìm kiếm sach
        /// </summary>
        private void SearchBooks()
        {
            try
            {
                currentSearchKeyword = txtSearchBook.Text.Trim();

                if (currentSearchKeyword == "Tìm kiếm theo tên, thể loại, trạng thái...")
                {
                    currentSearchKeyword = "";
                }

                // Sử dụng SearchService
                filteredBooks = BookSearchService.SearchBooks(allBooks, currentSearchKeyword);

                currentPage =1; // Reset về trang đầu
                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sách: {ex.Message}",
                         "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeDataGridView()
        {
            try
            {

                dgvBooks.AutoGenerateColumns = false;
                dgvBooks.AllowUserToAddRows = false;
                dgvBooks.AllowUserToDeleteRows = false;
                dgvBooks.AllowUserToResizeColumns = true;
                dgvBooks.AllowUserToResizeRows = false;
                dgvBooks.ReadOnly = true;
                dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBooks.MultiSelect = false;

                // Appearance settings
                dgvBooks.BackgroundColor = Color.White;
                dgvBooks.BorderStyle = BorderStyle.None;
                // duong vien ngang của column 
                dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvBooks.GridColor = Color.FromArgb(229,231,235);
                dgvBooks.EnableHeadersVisualStyles = false;

                // Scroll bars
                dgvBooks.ScrollBars = ScrollBars.Both;

                StyleBooksGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo DataGridView: {ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Data Loading 
        /// <summary>
        /// Load danh sách sách từ database
        /// </summary>
        private void LoadBooks()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Loading all books from database...");

                // Load tất cả sách từ database
                allBooks = BookRepository.GetAllBooks();
                if (allBooks == null)
                {
                    allBooks = new List<dynamic>();
                }

                // Ban đầu hiển thị tất cả
                filteredBooks = allBooks.ToList();

                System.Diagnostics.Debug.WriteLine($"Loaded {allBooks.Count} books total");

                // Reset về trang đầu và refresh
                currentPage =1;
                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load danh sách sách: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm/lọc sách
        /// </summary>
        private void FilterBooks()
        {
            try
            {
                // Lấy filter values
                currentCategoryFilter = cmbCategoryFilter.SelectedIndex >0 ?
                    cmbCategoryFilter.SelectedItem.ToString() : "";
                currentStatusFilter = cmbStatusFilter.SelectedIndex >0 ?
                    cmbStatusFilter.SelectedItem.ToString() : "";

                // Sử dụng SearchService
                filteredBooks = BookSearchService.SearchAndFilter(allBooks,
                    currentSearchKeyword, currentCategoryFilter, currentStatusFilter);

                currentPage =1;
                RefreshDataGridView();
                UpdatePageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sách: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật DataGridView với dữ liệu hiện tại - Tương tự RefreshDataGridView
        /// </summary>
        private void RefreshDataGridView()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Refreshing DataGridView for page {currentPage}");

                // Tính toán phân trang
                totalRecords = filteredBooks.Count;
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages ==0) totalPages =1;

                if (currentPage > totalPages)
                    currentPage = totalPages;

                // Lấy dữ liệu cho trang hiện tại
                var pageData = filteredBooks
                .Skip((currentPage -1) * pageSize)
                .Take(pageSize)
                .ToList();

                System.Diagnostics.Debug.WriteLine($"Page data contains {pageData.Count} books");

                // Clear existing data
                dgvBooks.Rows.Clear();

                // Add data to DataGridView
                foreach (var book in pageData)
                {
                    try
                    {
                        // Prepare data - Handle dynamic properties safely
                        string tenSach = book.TenSach?.ToString() ?? "";
                        string tacGia = book.TacGia?.ToString() ?? "";
                        string theLoai = book.TheLoai?.ToString() ?? "";
                        string anhBia = book.AnhBiaUrl?.ToString() ?? "";
                        // Format price - Safe conversion for dynamic objects
                        decimal gia =0;
                        try
                        {
                            if (book.Gia != null)
                                gia = Convert.ToDecimal(book.Gia);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Lỗi khi cập nhật gía: {e.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        string giaFormatted = gia.ToString("N0") + " đ";

                        // Format quantity - Safe conversion for dynamic objects
                        int soLuong =0;
                        try
                        {
                            if (book.SoLuong != null)
                                soLuong = Convert.ToInt32(book.SoLuong);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi cập nhật SL tồn kho: {ex.Message}",
                 "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Determine status
                        string trangThai = soLuong <=0 ? "Hết hàng" : "Còn hàng";

                        // Add row manually
                        var rowIndex = dgvBooks.Rows.Add();
                        var row = dgvBooks.Rows[rowIndex];

                        // Set cell values by column name
                        // gán ngay placeholderCover để xử lý đồng bộ load bóng mờ ngay, tránh ô trống trong lúc tải ảnh
                        row.Cells["colAnhBia"].Value = placeholderCover;
                        row.Cells["colTenSach"].Value = tenSach;
                        row.Cells["colTacGia"].Value = tacGia;
                        row.Cells["colTheLoai"].Value = theLoai;
                        row.Cells["colGiaBan"].Value = giaFormatted;
                        row.Cells["colTonKho"].Value = soLuong;
                        row.Cells["colTrangThai"].Value = trangThai;

                        // Store book ID in Tag for later use - Safe conversion for dynamic objects
                        try
                        {
                            if (book.SachId != null)
                                row.Tag = Convert.ToInt32(book.SachId);
                        }
                        catch { }

                        // check URL của ảnh có Rỗng không
                        if (!string.IsNullOrWhiteSpace(anhBia))
                        {
                            // capture local variables for closure
                            var cell = row.Cells["colAnhBia"] as DataGridViewImageCell;
                            var url = anhBia;

                            //khởi tạo tác vụ nền
                            //thực hiện lệnh dưới để không block UI thread
                            _ = Task.Run(async () =>
                            {
                                try
                                {
                                    var img = await ImageLoader.LoadImageAsync(url).ConfigureAwait(false);
                                    if (img != null)
                                    {
                                        // Ensure UI thread to set cell value
                                        if (dgvBooks.IsHandleCreated)
                                        {
                                            if (dgvBooks.InvokeRequired)
                                            {
                                                dgvBooks.Invoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        // Replace placeholder with a clone to avoid cross-thread issues
                                                        cell.Value = (Image)img.Clone();
                                                    }
                                                    catch { }
                                                    finally
                                                    {
                                                        img.Dispose();
                                                    }
                                                }));
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    cell.Value = (Image)img.Clone();
                                                }
                                                catch { }
                                                finally
                                                {
                                                    img.Dispose();
                                                }
                                            }
                                        }
                                        else
                                        {
                                          img.Dispose();
                                        }
                                    }
                                    else
                                    {
                                      img.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Error loading image for book '{tenSach}': {ex.Message}");
                                }
                            });
                        }
                    }
                    catch (Exception bookEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error adding book: {bookEx.Message}");
                    }
                }

                // Cập nhật pagination buttons
                UpdatePaginationButtons();
                StyleBooksGrid();
                dgvBooks.Refresh();

                System.Diagnostics.Debug.WriteLine($"RefreshDataGridView completed - Total rows: {dgvBooks.Rows.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật danh sách: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Filter Events
        /// <summary>
        /// Sự kiện thay đổi thể loại - Tương tự TxtSearchUser_TextChanged
        /// </summary>
        private void CmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Delay filter để tránh filter quá nhiều lần - tương tự searchTimer
            filterTimer?.Stop();
            filterTimer = new System.Windows.Forms.Timer();
            filterTimer.Interval =200; //300ms delay
            filterTimer.Tick += (s, args) =>
              {
                  filterTimer.Stop();
                  FilterBooks();
              };
            filterTimer.Start();
        }

        /// <summary>
        /// Sự kiện thay đổi trạng thái - Tương tự TxtSearchUser_TextChanged  
        /// </summary>
        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Delay filter để tránh filter quá nhiều lần
            filterTimer?.Stop();
            filterTimer = new System.Windows.Forms.Timer();
            filterTimer.Interval =300; //300ms delay
            filterTimer.Tick += (s, args) =>
            {
           filterTimer.Stop();
           FilterBooks();
            };
            filterTimer.Start();
        }

        private void CmbCategoryFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                TryAddCategoryFromCombo();
                // after attempting add, trigger filter
                CmbCategoryFilter_SelectedIndexChanged(sender, EventArgs.Empty);
            }
        }

        private void CmbCategoryFilter_Leave(object sender, EventArgs e)
        {
            TryAddCategoryFromCombo();
        }

        /// <summary>
        /// If user typed a new category into the combobox, add it to DB and to the combobox list.
        /// </summary>
        private void TryAddCategoryFromCombo()
        {
            try
            {
                var text = (cmbCategoryFilter.Text ?? "").Trim();
                if (string.IsNullOrEmpty(text)) return;
                if (text.Equals("Tất cả thể loại", StringComparison.OrdinalIgnoreCase)) return;

                // Check existing items case-insensitively
                bool exists = cmbCategoryFilter.Items.Cast<object>()
                    .Any(i => string.Equals(i?.ToString()?.Trim(), text, StringComparison.OrdinalIgnoreCase));
                if (exists)
                {
                    // Select the existing item
                    cmbCategoryFilter.SelectedItem = cmbCategoryFilter.Items.Cast<object>()
                        .First(i => string.Equals(i?.ToString()?.Trim(), text, StringComparison.OrdinalIgnoreCase));
                    return;
                }

                // Persist new category via repository
                int newId = CategoryRepository.AddCategory(text);
                if (newId >0)
                {
                    // Add to combobox and select it
                    cmbCategoryFilter.Items.Add(text);
                    cmbCategoryFilter.SelectedItem = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể thêm thể loại mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Pagination
        /// <summary>
        /// Cập nhật thông tin trang - Tương tự UpdatePageInfo
        /// </summary>
        private void UpdatePageInfo()
        {
            int fromRecord = filteredBooks.Count ==0 ?0 : (currentPage -1) * pageSize +1;
            int toRecord = Math.Min(currentPage * pageSize, filteredBooks.Count);

            lblPageInfo.Text = $"Hiển thị {fromRecord}-{toRecord} của {filteredBooks.Count} sách";
        }

        /// <summary>
        /// Cập nhật các nút phân trang - Tương tự UpdatePaginationButtons
        /// </summary>
        private void UpdatePaginationButtons()
        {
            flowPaginationButtons.Controls.Clear();

            if (totalPages <=1) return;

            // Nút Previous
            if (currentPage >1)
            {
                var btnPrev = CreatePaginationButton("‹ Trước", currentPage -1);
                flowPaginationButtons.Controls.Add(btnPrev);
            }

            // Các nút số trang
            int startPage = Math.Max(1, currentPage -2);
            int endPage = Math.Min(totalPages, currentPage +2);

            if (startPage >1)
            {
                flowPaginationButtons.Controls.Add(CreatePaginationButton("1",1));
                if (startPage >2)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
            }

            for (int i = startPage; i <= endPage; i++)
            {
                var btn = CreatePaginationButton(i.ToString(), i);
                if (i == currentPage)
                {
                    btn.BackColor = Color.FromArgb(74,144,226);
                    btn.ForeColor = Color.White;
                }
                flowPaginationButtons.Controls.Add(btn);
            }

            if (endPage < totalPages)
            {
                if (endPage < totalPages -1)
                {
                    var lblDots = new Label { Text = "...", AutoSize = true, Margin = new Padding(5) };
                    flowPaginationButtons.Controls.Add(lblDots);
                }
                flowPaginationButtons.Controls.Add(CreatePaginationButton(totalPages.ToString(), totalPages));
            }

            // Nút Next
            if (currentPage < totalPages)
            {
                var btnNext = CreatePaginationButton("Sau ›", currentPage +1);
                flowPaginationButtons.Controls.Add(btnNext);
            }
        }

        /// <summary>
        /// Tạo button phân trang - Tương tự CreatePaginationButton
        /// </summary>
        private Button CreatePaginationButton(string text, int pageNumber)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(text.Length >2 ?60 :35,30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(74,144,226),
                Tag = pageNumber,
                Cursor = System.Windows.Forms.Cursors.Hand,
                Font = new Font("Segoe UI",9F)
            };

            btn.FlatAppearance.BorderColor = Color.FromArgb(74,144,226);
            btn.FlatAppearance.BorderSize =1;

            btn.Click += (s, e) =>
         {
             currentPage = (int)btn.Tag;
             RefreshDataGridView();
             UpdatePageInfo();
         };

            return btn;
        }
        #endregion

        #region Existing Methods - Giữ nguyên
        private void BooksControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            try
            {
                StyleBooksGrid();
                if (dgvBooks.Rows.Count >0)
                {
                    dgvBooks.Refresh();
                    dgvBooks.Invalidate();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing UI: {ex.Message}");
            }
        }

        private void StyleBooksGrid()
        {
            if (dgvBooks == null) return;

            try
            {
                // Header styling
                var headerStyle = dgvBooks.ColumnHeadersDefaultCellStyle;
                headerStyle.BackColor = Color.FromArgb(249,250,251);
                headerStyle.ForeColor = Color.FromArgb(55,65,81);
                headerStyle.Font = new Font("Segoe UI",11F, FontStyle.Bold);
                headerStyle.Padding = new Padding(10,8,10,8);
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvBooks.ColumnHeadersHeight =45;
                dgvBooks.EnableHeadersVisualStyles = false;

                // Default cell styling
                var cellStyle = dgvBooks.DefaultCellStyle;
                cellStyle.BackColor = Color.White;
                cellStyle.Font = new Font("Segoe UI",10F, FontStyle.Regular);
                cellStyle.ForeColor = Color.FromArgb(55,65,81);
                cellStyle.Padding = new Padding(8,5,8,5);
                cellStyle.SelectionBackColor = Color.FromArgb(219,234,254);
                cellStyle.SelectionForeColor = Color.FromArgb(30,64,175);
                cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Row styling
                dgvBooks.RowTemplate.Height =60;
                dgvBooks.GridColor = Color.FromArgb(229,231,235);
                dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                // Style specific columns if they exist
                foreach (DataGridViewColumn col in dgvBooks.Columns)
                {
                    switch (col.Name)
                    {
                        case "colTenSach":
                            col.DefaultCellStyle.ForeColor = Color.FromArgb(17,24,39);
                            col.DefaultCellStyle.Font = new Font("Segoe UI",10F, FontStyle.Bold);
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            break;
                        case "colGiaBan":
                            col.DefaultCellStyle.ForeColor = Color.FromArgb(17,24,39);
                            col.DefaultCellStyle.Font = new Font("Segoe UI",10F, FontStyle.Bold);
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "colTonKho":
                            col.DefaultCellStyle.ForeColor = Color.FromArgb(17,24,39);
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.DefaultCellStyle.Font = new Font("Segoe UI",10F, FontStyle.Bold);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error styling grid: {ex.Message}");
            }
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex <0 || e.ColumnIndex <0) return;
                if (e.RowIndex >= dgvBooks.Rows.Count) return;
                if (e.ColumnIndex >= dgvBooks.Columns.Count) return;

                string columnName = dgvBooks.Columns[e.ColumnIndex].Name;

                if (columnName == "colTrangThai" && e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (!string.IsNullOrEmpty(status))
                    {
                        e.CellStyle.Font = new Font("Segoe UI",9F, FontStyle.Bold);
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (status.Equals("Còn hàng", StringComparison.OrdinalIgnoreCase))
                        {
                            e.CellStyle.BackColor = Color.FromArgb(220,252,231);
                            e.CellStyle.ForeColor = Color.FromArgb(22,101,52);
                        }
                        else if (status.Equals("Hết hàng", StringComparison.OrdinalIgnoreCase))
                        {
                            e.CellStyle.BackColor = Color.FromArgb(254,226,226);
                            e.CellStyle.ForeColor = Color.FromArgb(153,27,27);
                        }
                        e.FormattingApplied = true;
                    }
                }
                else if (columnName == "colTonKho" && e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int quantity))
                    {
                        e.CellStyle.Font = new Font("Segoe UI",10F, FontStyle.Bold);
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (quantity <=0)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(153,27,27);
                        }
                        else if (quantity <=10)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(217,119,6);
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(22,101,52);
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in cell formatting: {ex.Message}");
                e.FormattingApplied = false;
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <0 || e.ColumnIndex <0) return;
                if (e.RowIndex >= dgvBooks.Rows.Count) return;

                // Get SachId - Dual fallback method
                int sachId =0;

                // Method1: From Row.Tag
                if (dgvBooks.Rows[e.RowIndex].Tag != null)
                {
                    if (int.TryParse(dgvBooks.Rows[e.RowIndex].Tag.ToString(), out sachId))
                    {
                        System.Diagnostics.Debug.WriteLine($"Got SachId from Tag: {sachId}");
                    }
                }

                // Method2: From DataSource if Tag failed
                if (sachId ==0 && dgvBooks.DataSource != null)
                {
                    try
                    {
                        var dataSource = dgvBooks.DataSource as System.Collections.IList;
                        if (dataSource != null && e.RowIndex < dataSource.Count)
                        {
                            var item = dataSource[e.RowIndex];
                            var sachIdProperty = item.GetType().GetProperty("SachId");
                            if (sachIdProperty != null)
                            {
                                var value = sachIdProperty.GetValue(item);
                                if (value != null && int.TryParse(value.ToString(), out sachId))
                                {
                                    System.Diagnostics.Debug.WriteLine($"Got SachId from DataSource: {sachId}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error getting SachId from DataSource: {ex.Message}");
                    }
                }

                string tenSach = dgvBooks.Rows[e.RowIndex].Cells["colTenSach"].Value?.ToString() ?? "";
                string columnName = dgvBooks.Columns[e.ColumnIndex].Name;

                if (sachId ==0)
                {
                    MessageBox.Show("Không thể xác định ID của sách!", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (columnName == "colEdit")
                {
                    EditBook(sachId);
                }
                else if (columnName == "colDelete")
                {
                    DeleteBook(sachId, tenSach);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý click: {ex.Message}", "Lỗi",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBook(int sachId)
        {
            try
            {
                var book = BookRepository.GetBookById(sachId);
                if (book == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sách!", "Lỗi",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var editForm = new frmAddEditBook())
                    System.Diagnostics.Debug.WriteLine($"Found book: {book.TenSach}");

                // Mở form với constructor nhận sachId (Edit mode)
                using (var editForm = new frmAddEditBook(sachId))
                {
                    editForm.Text = $"Sửa thông tin sách - {book.TenSach}";

                    var result = editForm.ShowDialog();
                    System.Diagnostics.Debug.WriteLine($"Edit form result: {result}");

                    if (result == DialogResult.OK)
                    {
                        // Refresh data sau khi edit thành công
                        System.Diagnostics.Debug.WriteLine("Refreshing book list after edit...");
                        LoadBooks();

                        MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EditBook error: {ex.Message}");
                MessageBox.Show($"Lỗi khi sửa thông tin sách: {ex.Message}", "Lỗi",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBook(int sachId, string tenSach)
        {
            try
            {
                var result = MessageBox.Show(
                 $"Bạn có chắc chắn muốn xóa sách '{tenSach}'?\n\n" +
                       "Lưu ý: Sách sẽ được đánh dấu là không hoạt động.",
                     "Xác nhận xóa sách",
                      MessageBoxButtons.YesNo,
                          MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = BookRepository.DeleteBook(sachId);
                    if (success)
                    {
                        // Refresh data sau khi delete
                        LoadBooks();
                        MessageBox.Show("Xóa sách thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sách. Vui lòng thử lại!", "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sách: {ex.Message}", "Lỗi",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Opening Add Book form...");

                // Sử dụng constructor không có parameter cho Add mode
                using (var form = new frmAddEditBook())
                {
                    form.Text = "Thêm sách mới";

                    var result = form.ShowDialog();
                    System.Diagnostics.Debug.WriteLine($"Add form result: {result}");

                    if (result == DialogResult.OK)
                    {
                        // Refresh data sau khi add thành công
                        System.Diagnostics.Debug.WriteLine("Refreshing book list after add...");
                        LoadBooks();

                        MessageBox.Show("Thêm sách mới thành công!", "Thông báo",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"btnAddBook_Click error: {ex.Message}");
                MessageBox.Show($"Lỗi khi mở form thêm sách: {ex.Message}", "Lỗi",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshData()
        {
            LoadBooks();
        }

        private void dgvBooks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"DataGridView Error: {e.Exception?.Message}");
                e.Cancel = true;

                if (e.RowIndex >=0 && e.ColumnIndex >=0 &&
         e.RowIndex < dgvBooks.Rows.Count && e.ColumnIndex < dgvBooks.Columns.Count)
                {
                    string columnName = dgvBooks.Columns[e.ColumnIndex].Name;
                    switch (columnName)
                    {
                        case "colTonKho":
                            System.Diagnostics.Debug.WriteLine($"DataGridView Error at ({e.RowIndex}, {e.ColumnIndex}): {e.Exception?.Message}");
                            dgvBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ="0";
                            break;
                        case "colGiaBan":
                            dgvBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0 đ";
                            break;
                        case "colTrangThai":
                            dgvBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Không xác định";
                            break;
                        default:
                            dgvBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in DataError handler: {ex.Message}");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Refresh danh sách sách (có thể gọi từ form khác) - Tương tự RefreshCustomerList
        /// </summary>
        public void RefreshBookList()
        {
            LoadBooks();
        }
        #endregion

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            // Delay search để tránh tìm kiếm quá nhiều lần
            filterTimer?.Stop();
            filterTimer = new System.Windows.Forms.Timer();
            filterTimer.Interval =200; //500ms delay
            filterTimer.Tick += (s, args) =>
            {
                filterTimer.Stop();
                SearchBooks();
            };
            filterTimer.Start();
        }
        // su kien nhan nut enter de tim kiem ngay
        private void TxtSearchBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                filterTimer?.Stop();
                SearchBooks();
                e.Handled = true;
            }
        }
    }
}