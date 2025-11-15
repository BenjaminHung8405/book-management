using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data;
using book_management.Helpers;

namespace book_management.UI.Modal
{
    public partial class frmAddEditBook : Form
    {
        #region Fields
        private int? sachId = null; // null = Add mode, có giá trị = Edit mode
        private dynamic currentBook = null; // Lưu thông tin sách hiện tại để edit
        private bool isEditMode = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor cho Add mode
        /// </summary>
        public frmAddEditBook()
        {
            InitializeComponent();
            InitializeForm();
            LoadComboBoxData();

            // Add mode
            isEditMode = false;
            label1.Text = "Thêm sách mới";
        }

        /// <summary>
        /// Constructor cho Edit mode
        /// </summary>
        public frmAddEditBook(int bookId) : this()
        {
            sachId = bookId;
            isEditMode = true;
            label1.Text = "Sửa thông tin sách";

            // Load dữ liệu sách
            LoadBookData();
        }
        #endregion

        #region Initialization
        private void InitializeForm()
        {
            // Set properties for Cancel button
            btnCancelModal.DialogResult = DialogResult.Cancel;
            btnCancelModal.Click += btnCancelModal_Click;

            // Set properties for Save button
            btnSaveBook.DialogResult = DialogResult.None;
            btnSaveBook.Click += btnSaveBook_Click;

            // Initialize auto-add events for ComboBoxes
            InitializeAutoAddEvents();
        }

        /// <summary>
        /// Initialize auto-add events for ComboBoxes
        /// </summary>
        private void InitializeAutoAddEvents()
        {
            // Auto-add for authors
            cbTacGia.KeyDown += cbTacGia_KeyDown;
            cbTacGia.Leave += cbTacGia_Leave;

            // Auto-add for categories
            cbTheLoai.KeyDown += cbTheLoai_KeyDown;
            cbTheLoai.Leave += cbTheLoai_Leave;
        }

        /// <summary>
        /// Load dữ liệu cho các ComboBox
        /// </summary>
        private void LoadComboBoxData()
        {
            try
            {
                // Load Tác giả
                cbTacGia.Items.Clear();
                cbTacGia.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép edit để nhập tác giả mới
                var authors = BookRepository.GetAllAuthors();
                foreach (var author in authors)
                {
                    cbTacGia.Items.Add(author.TenTacGia);
                }

                // Load Thể loại
                cbTheLoai.Items.Clear();
                cbTheLoai.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép edit để nhập thể loại mới
                var categories = BookRepository.GetAllCategories();
                foreach (var category in categories)
                {
                    cbTheLoai.Items.Add(category.TenTheLoai);
                }

                // Load Trạng thái
                cbTrangThai.Items.Clear();
                cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList; // Chỉ cho phép chọn
                cbTrangThai.Items.AddRange(new string[] { "Hoạt động", "Ngừng bán", "Hết hàng" });
                cbTrangThai.SelectedIndex = 0; // Default: Hoạt động

                // Set default values cho NumericUpDowns
                numGia.Maximum = 999999999;
                numGia.Minimum = 0;
                numGia.DecimalPlaces = 0; // Giá là số nguyên

                numSL.Maximum = 999999;
                numSL.Minimum = 0;

                numSoTrang.Maximum = 9999;
                numSoTrang.Minimum = 0;

                numNamXB.Minimum = 1900;
                numNamXB.Maximum = DateTime.Now.Year + 5; // Cho phép sách sắp xuất bản
                numNamXB.Value = DateTime.Now.Year;

                // Set default ngôn ngữ
                txtNgonNgu.Text = "Tiếng Việt";

                System.Diagnostics.Debug.WriteLine("ComboBox data loaded successfully");
                System.Diagnostics.Debug.WriteLine($"Authors loaded: {authors.Count}");
                System.Diagnostics.Debug.WriteLine($"Categories loaded: {categories.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu ComboBox: {ex.Message}", "Lỗi",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Data Loading for Edit Mode
        /// <summary>
        /// Load dữ liệu sách để edit
        /// </summary>
        private void LoadBookData()
        {
            try
            {
                if (!sachId.HasValue) return;

                System.Diagnostics.Debug.WriteLine($"Loading book data for ID: {sachId.Value}");

                // Lấy thông tin sách từ database
                currentBook = BookRepository.GetBookById(sachId.Value);
                if (currentBook == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sách!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Fill dữ liệu vào form
                PopulateFormFields();

                System.Diagnostics.Debug.WriteLine("Book data loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sách: {ex.Message}", "Lỗi",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Điền dữ liệu sách vào các trường trong form
        /// </summary>
        private void PopulateFormFields()
        {
            try
            {
                if (currentBook == null) return;

                System.Diagnostics.Debug.WriteLine("Populating form fields...");

                // Text fields - mapping với properties từ BookRepository
                txtTenSach.Text = currentBook.TenSach?.ToString() ?? "";
                txtNXB.Text = currentBook.NhaXuatBan?.ToString() ?? "";
                txtNgonNgu.Text = currentBook.NgonNgu?.ToString() ?? "Tiếng Việt";
                txtMoTa.Text = currentBook.MoTa?.ToString() ?? "";
                txtURL.Text = currentBook.AnhBiaUrl?.ToString() ?? ""; // Note: AnhBiaUrl trong DB

                // Numeric fields with safe conversion
                try
                {
                    if (currentBook.Gia != null)
                        numGia.Value = Math.Min(Convert.ToDecimal(currentBook.Gia), numGia.Maximum);
                    else
                        numGia.Value = 0;
                    System.Diagnostics.Debug.WriteLine($"Price set to: {numGia.Value}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error setting price: {ex.Message}");
                    numGia.Value = 0;
                }

                try
                {
                    if (currentBook.SoLuong != null)
                        numSL.Value = Math.Min(Convert.ToDecimal(currentBook.SoLuong), numSL.Maximum);
                    else
                        numSL.Value = 0;
                    System.Diagnostics.Debug.WriteLine($"Quantity set to: {numSL.Value}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error setting quantity: {ex.Message}");
                    numSL.Value = 0;
                }

                try
                {
                    if (currentBook.SoTrang != null)
                        numSoTrang.Value = Math.Min(Convert.ToDecimal(currentBook.SoTrang), numSoTrang.Maximum);
                    else
                        numSoTrang.Value = 0;
                    System.Diagnostics.Debug.WriteLine($"Pages set to: {numSoTrang.Value}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error setting pages: {ex.Message}");
                    numSoTrang.Value = 0;
                }

                try
                {
                    if (currentBook.NamXuatBan != null)
                    {
                        var year = Convert.ToInt32(currentBook.NamXuatBan);
                        numNamXB.Value = Math.Max(numNamXB.Minimum, Math.Min(year, numNamXB.Maximum));
                    }
                    else
                    {
                        numNamXB.Value = DateTime.Now.Year;
                    }
                    System.Diagnostics.Debug.WriteLine($"Publication year set to: {numNamXB.Value}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error setting publication year: {ex.Message}");
                    numNamXB.Value = DateTime.Now.Year;
                }

                // ComboBox selections - mapping với properties từ BookRepository
                SetComboBoxSelection(cbTacGia, currentBook.TacGia?.ToString());
                SetComboBoxSelection(cbTheLoai, currentBook.TheLoai?.ToString());

                // Trạng thái - convert từ boolean sang text
                string trangThaiText = "Hoạt động";
                try
                {
                    if (currentBook.TrangThai != null)
                    {
                        bool trangThai = Convert.ToBoolean(currentBook.TrangThai);
                        trangThaiText = trangThai ? "Hoạt động" : "Ngừng bán";
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error converting status: {ex.Message}");
                }
                SetComboBoxSelection(cbTrangThai, trangThaiText);

                System.Diagnostics.Debug.WriteLine("Form fields populated successfully");

                // Debug: In ra tất cả giá trị đã được set
                System.Diagnostics.Debug.WriteLine("=== Form Field Values ===");
                System.Diagnostics.Debug.WriteLine($"Name: {txtTenSach.Text}");
                System.Diagnostics.Debug.WriteLine($"Author: {cbTacGia.Text}");
                System.Diagnostics.Debug.WriteLine($"Category: {cbTheLoai.Text}");
                System.Diagnostics.Debug.WriteLine($"Publisher: {txtNXB.Text}");
                System.Diagnostics.Debug.WriteLine($"Price: {numGia.Value}");
                System.Diagnostics.Debug.WriteLine($"Quantity: {numSL.Value}");
                System.Diagnostics.Debug.WriteLine($"Pages: {numSoTrang.Value}");
                System.Diagnostics.Debug.WriteLine($"Year: {numNamXB.Value}");
                System.Diagnostics.Debug.WriteLine($"Language: {txtNgonNgu.Text}");
                System.Diagnostics.Debug.WriteLine($"Status: {cbTrangThai.Text}");
                System.Diagnostics.Debug.WriteLine($"Description: {txtMoTa.Text}");
                System.Diagnostics.Debug.WriteLine($"Image URL: {txtURL.Text}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error populating form fields: {ex.Message}");
                MessageBox.Show($"Lỗi khi điền dữ liệu vào form: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Event Handlers
        private void btnCancelModal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate form
                if (!ValidateForm())
                    return;

                if (isEditMode)
                {
                    UpdateBook();
                }
                else
                {
                    AddNewBook();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu sách: {ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbTacGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TryAddAuthorFromCombo();
            }
        }

        private void cbTacGia_Leave(object sender, EventArgs e)
        {
            TryAddAuthorFromCombo();
        }

        private void cbTheLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TryAddCategoryFromCombo();
            }
        }

        private void cbTheLoai_Leave(object sender, EventArgs e)
        {
            TryAddCategoryFromCombo();
        }
        #endregion

        #region Validation and Save Methods
        /// <summary>
        /// Validate form data
        /// </summary>
        private bool ValidateForm()
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return false;
            }

            if (numGia.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!", "Thông báo",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGia.Focus();
                return false;
            }

            if (cbTacGia.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cbTacGia.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tác giả!", "Thông báo",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTacGia.Focus();
                return false;
            }

            if (cbTheLoai.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cbTheLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập thể loại!", "Thông báo",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTheLoai.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Thêm sách mới
        /// </summary>
        private void AddNewBook()
        {
            try
            {
                // Lấy dữ liệu từ form
                string tenSach = txtTenSach.Text.Trim();
                string nxbName = txtNXB.Text.Trim();

                if (string.IsNullOrEmpty(nxbName))
                {
                    MessageBox.Show("Vui lòng nhập nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNXB.Focus();
                    return;
                }

                // Tìm hoặc tạo nhà xuất bản
                int nxbId =0;
                var publishers = PublisherRepository.GetAllPublishers();
                var found = publishers.FirstOrDefault(p => (p.TenNxb ?? "").ToString().Equals(nxbName, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    try { nxbId = Convert.ToInt32(found.NxbId); } catch { nxbId =0; }
                }
                else
                {
                    // Tạo mới nhà xuất bản và lấy ID
                    nxbId = PublisherRepository.AddPublisher(nxbName);
                }

                decimal gia = numGia.Value;
                int soLuong = Convert.ToInt32(numSL.Value);
                string anhBiaUrl = txtURL.Text.Trim();
                int? namXuatBan = (int?)numNamXB.Value;
                int? soTrang = (int?)numSoTrang.Value;
                string moTa = txtMoTa.Text.Trim();
                string ngonNgu = txtNgonNgu.Text.Trim();

                // Map authors and categories from text (comma separated) to IDs, create new ones if necessary
                var authorIds = new List<int>();
                var categoryIds = new List<int>();

                string authorsText = cbTacGia.Text?.Trim() ?? "";
                if (!string.IsNullOrEmpty(authorsText))
                {
                    var authorNames = authorsText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var allAuthors = BookRepository.GetAllAuthors();
                    foreach (var name in authorNames)
                    {
                        var a = allAuthors.FirstOrDefault(x => (x.TenTacGia ?? "").ToString().Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (a != null)
                        {
                            try { authorIds.Add(Convert.ToInt32(a.TacGiaId)); } catch { }
                        }
                        else
                        {
                            // Nếu không tồn tại thì thêm mới vào CSDL
                            int newAuthorId = AuthorRepository.AddAuthor(name);
                            if (newAuthorId >0) authorIds.Add(newAuthorId);
                        }
                    }
                }

                string categoriesText = cbTheLoai.Text?.Trim() ?? "";
                if (!string.IsNullOrEmpty(categoriesText))
                {
                    var categoryNames = categoriesText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var allCategories = BookRepository.GetAllCategories();
                    foreach (var name in categoryNames)
                    {
                        var c = allCategories.FirstOrDefault(x => (x.TenTheLoai ?? "").ToString().Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (c != null)
                        {
                            try { categoryIds.Add(Convert.ToInt32(c.TheLoaiId)); } catch { }
                        }
                        else
                        {
                            int newCatId = CategoryRepository.AddCategory(name);
                            if (newCatId >0) categoryIds.Add(newCatId);
                        }
                    }
                }

                // Gọi repository để thêm sách mới
                int newSachId = BookRepository.AddBook(tenSach, nxbId, gia, soLuong, anhBiaUrl, authorIds, categoryIds, namXuatBan, soTrang, moTa, ngonNgu);

                if (newSachId >0)
                {
                    MessageBox.Show("Thêm sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sách mới: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin sách
        /// </summary>
        private void UpdateBook()
        {
            try
            {
                if (!sachId.HasValue) return;

                // Lấy dữ liệu từ form
                string tenSach = txtTenSach.Text.Trim();
                string nxbName = txtNXB.Text.Trim();

                if (string.IsNullOrEmpty(nxbName))
                {
                    MessageBox.Show("Vui lòng nhập nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNXB.Focus();
                    return;
                }

                // Tìm hoặc tạo nhà xuất bản
                int nxbId = 0;
                var publishers = PublisherRepository.GetAllPublishers();
                var found = publishers.FirstOrDefault(p => (p.TenNxb ?? "").ToString().Equals(nxbName, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    try { nxbId = Convert.ToInt32(found.NxbId); } catch { nxbId = 0; }
                }
                else
                {
                    // Tạo mới nhà xuất bản và lấy ID
                    nxbId = PublisherRepository.AddPublisher(nxbName);
                }

                decimal gia = numGia.Value;
                int soLuong = Convert.ToInt32(numSL.Value);
                string anhBiaUrl = txtURL.Text.Trim();
                int? namXuatBan = (int?)numNamXB.Value;
                int? soTrang = (int?)numSoTrang.Value;
                string moTa = txtMoTa.Text.Trim();
                string ngonNgu = txtNgonNgu.Text.Trim();

                // Map authors and categories from text (comma separated) to IDs using repository lists
                var authorIds = new List<int>();
                var categoryIds = new List<int>();

                string authorsText = cbTacGia.Text?.Trim() ?? "";
                if (!string.IsNullOrEmpty(authorsText))
                {
                    var authorNames = authorsText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var allAuthors = BookRepository.GetAllAuthors();
                    foreach (var name in authorNames)
                    {
                        var a = allAuthors.FirstOrDefault(x => (x.TenTacGia ?? "").ToString().Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (a != null)
                        {
                            try { authorIds.Add(Convert.ToInt32(a.TacGiaId)); } catch { }
                        }
                        // If author not found, skip. Adding new authors not implemented here.
                    }
                }

                string categoriesText = cbTheLoai.Text?.Trim() ?? "";
                if (!string.IsNullOrEmpty(categoriesText))
                {
                    var categoryNames = categoriesText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var allCategories = BookRepository.GetAllCategories();
                    foreach (var name in categoryNames)
                    {
                        var c = allCategories.FirstOrDefault(x => (x.TenTheLoai ?? "").ToString().Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (c != null)
                        {
                            try { categoryIds.Add(Convert.ToInt32(c.TheLoaiId)); } catch { }
                        }
                    }
                }

                // Gọi repository để cập nhật
                bool updated = BookRepository.UpdateBook(sachId.Value, tenSach, nxbId, gia, soLuong, anhBiaUrl, authorIds, categoryIds, namXuatBan, soTrang, moTa, ngonNgu);

                if (updated)
                {
                    MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật sách thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật sách: {ex.Message}");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get book data from form (for external use)
        /// </summary>
        public dynamic GetBookData()
        {
            return new
            {
                SachId = sachId,
                TenSach = txtTenSach.Text.Trim(),
                TacGia = cbTacGia.Text.Trim(),
                TheLoai = cbTheLoai.Text.Trim(),
                Gia = numGia.Value,
                SoLuong = numSL.Value,
                NhaXuatBan = txtNXB.Text.Trim(),
                SoTrang = numSoTrang.Value,
                NamXuatBan = numNamXB.Value,
                NgonNgu = txtNgonNgu.Text.Trim(),
                TrangThai = cbTrangThai.Text,
                MoTa = txtMoTa.Text.Trim(),
                URLAnhBia = txtURL.Text.Trim()
            };
        }
        #endregion

        #region Auto-Add Methods
        /// <summary>
        /// Try to add new author from ComboBox text
        /// </summary>
        private void TryAddAuthorFromCombo()
        {
            try
            {
                string authorName = cbTacGia.Text?.Trim();
                if (string.IsNullOrEmpty(authorName))
                    return;

                // Check if author already exists
                bool exists = false;
                foreach (var item in cbTacGia.Items)
                {
                    if (item.ToString().Equals(authorName, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    // Add to database
                    int newId = AuthorRepository.AddAuthor(authorName);
                    if (newId > 0)
                    {
                        // Add to ComboBox
                        cbTacGia.Items.Add(authorName);
                        cbTacGia.Text = authorName;
                        System.Diagnostics.Debug.WriteLine($"Added new author: {authorName} (ID: {newId})");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm tác giả mới!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding author: {ex.Message}");
                MessageBox.Show($"Lỗi khi thêm tác giả: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Try to add new category from ComboBox text
        /// </summary>
        private void TryAddCategoryFromCombo()
        {
            try
            {
                string categoryName = cbTheLoai.Text?.Trim();
                if (string.IsNullOrEmpty(categoryName))
                    return;

                // Check if category already exists
                bool exists = false;
                foreach (var item in cbTheLoai.Items)
                {
                    if (item.ToString().Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    // Add to database
                    int newId = CategoryRepository.AddCategory(categoryName);
                    if (newId > 0)
                    {
                        // Add to ComboBox
                        cbTheLoai.Items.Add(categoryName);
                        cbTheLoai.Text = categoryName;
                        System.Diagnostics.Debug.WriteLine($"Added new category: {categoryName} (ID: {newId})");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm thể loại mới!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding category: {ex.Message}");
                MessageBox.Show($"Lỗi khi thêm thể loại: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ComboBox Helper Methods
        /// <summary>
        /// Set selection cho ComboBox based on text value
        /// </summary>
        private void SetComboBoxSelection(ComboBox comboBox, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    comboBox.SelectedIndex = -1;
                    return;
                }

                // Tìm exact match trước
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    if (comboBox.Items[i].ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        comboBox.SelectedIndex = i;
                        System.Diagnostics.Debug.WriteLine($"Exact match found for '{value}' at index {i}");
                        return;
                    }
                }

                // Nếu không tìm thấy exact match, tìm partial match
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    if (comboBox.Items[i].ToString().Contains(value, StringComparison.OrdinalIgnoreCase))
                    {
                        comboBox.SelectedIndex = i;
                        System.Diagnostics.Debug.WriteLine($"Partial match found for '{value}' at index {i}");
                        return;
                    }
                }

                // Nếu không tìm thấy gì, set text cho editable ComboBox hoặc để trống
                if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
                {
                    comboBox.Text = value;
                    System.Diagnostics.Debug.WriteLine($"Set text '{value}' for editable ComboBox {comboBox.Name}");
                }
                else
                {
                    comboBox.SelectedIndex = -1;
                    System.Diagnostics.Debug.WriteLine($"No match found for '{value}' in ComboBox {comboBox.Name}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting ComboBox selection for {comboBox.Name}: {ex.Message}");
                comboBox.SelectedIndex = -1;
            }
        }
        #endregion
    }
}
