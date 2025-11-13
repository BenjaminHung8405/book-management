using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.DataAccess;
using book_management.Models; 
using book_management.UI.Modal;
using book_management.Services;
using book_management.Helpers;
namespace book_management.UI.Controls
{
    public partial class StoreControl : UserControl
    {
        // Biến lưu ID hồ sơ khách hàng (kh_id)
        private int _currentCustomerId = 0;
        private string currentSearchKeyword = "";
        private decimal _currentDiscount = 0; // Biến lưu tiền giảm giá hiện tại
        // Lưu trữ danh sách KM để tính toán
        private List<KhuyenMai> _availablePromotions;
        private List<dynamic> allBooks; // Tất cả sách từ database
        private List<dynamic> filteredBooks; // Sách sau khi filter

        // Biến lưu giỏ hàng
        private List<CartItem> _cart = new List<CartItem>();

        public StoreControl()
        {
            InitializeComponent();
            InitializeSearchEvents();
            LoadBooks();

            // Thêm hàm thiết lập DataGridView cho giỏ hàng
            SetupCartGrid();
            LoadPromotions();
            
            // Gắn sự kiện cho ComboBox khuyến mãi để cập nhật lại tổng khi người dùng đổi khuyến mãi
            this.cmbPromotions.SelectedIndexChanged += this.cmbPromotions_SelectedIndexChanged;
            
            // Cập nhật hiển thị tổng ban đầu
            UpdateTotals();
            // Gắn event cho nút thanh toán (ibtnThanhToan) tới handler hiện có
            this.ibtnThanhToan.Click += this.btnThanhToan_Click;
        }
        /// <summary>
        /// Khởi tạo events cho tìm kiếm - Tương tự BooksControl
        /// </summary>
        private void InitializeSearchEvents()
        {

            this.iconSearchBook.Click += iconSearchBook_Click;
            SetSearchPlaceholder();
        }
        private void StoreControl_Load(object sender, EventArgs e)
        {
            // Tự động tải thông tin khách hàng khi form load
            LoadCustomerInfo();
            try
            {
                // Dọn dẹp khách vãng lai cũ khi load form
                CustomerRepository.CleanupExpiredTemporaryCustomers();
            }
            catch (Exception ex)
            {
                // Log lỗi nhưng không hiện thông báo cho user
                System.Diagnostics.Debug.WriteLine($"Cleanup error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tự động tìm kh_id (mã khách hàng) dựa trên user_id
        /// </summary>
        private void LoadCustomerInfo()
        {
            try
            {
                // Tìm kh_id dựa trên user_id ()
                var customer = CustomerRepository.GetCustomerByUserId(CurrentUser.UserId);

                if (customer != null)
                {

                    _currentCustomerId = customer.KhId;
                    lblCustomerInfo.Text = $"Giao đến: {customer.TenKhach} | SĐT: {customer.SoDienThoai}";
                    rtbAddressDelivery.Text = customer.DiaChi;
                    ibtnThanhToan.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPromotions()
        {
            try
            {
                // 1. Lấy dữ liệu
                _availablePromotions = KhuyenMaiRepository.GetAvailablePromotions();

                // 2. Tạo một item "Không chọn"
                var displayList = new List<KhuyenMai>();
                displayList.Add(new KhuyenMai { KmId = 0, TenKm = "--- Chọn khuyến mãi ---" });
                displayList.AddRange(_availablePromotions);

                // 3. Nạp vào ComboBox
                cmbPromotions.DataSource = displayList;
                cmbPromotions.DisplayMember = "TenKm"; // Hiển thị tên (VD: "Giảm10%")
                cmbPromotions.ValueMember = "KmId"; // Lưu lại ID
                // Đặt lựa chọn mặc định về phần tử đầu và cập nhật tổng
                cmbPromotions.SelectedIndex =0;
                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khuyến mãi: " + ex.Message);
            }
        }
        /// <summary>
        /// Thiết lập placeholder cho search textbox
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
        /// Tìm kiếm sách - Sử dụng SearchService
        /// </summary>
        private void SearchBooks()
        {
            try
            {
                currentSearchKeyword = txtSearchBook.Text.Trim();

                if (currentSearchKeyword == "Tìm kiếm theo tên sách, tác giả..." || string.IsNullOrEmpty(currentSearchKeyword))
                {
                    currentSearchKeyword = "";
                }
                System.Diagnostics.Debug.WriteLine($"Searching with keyword: '{currentSearchKeyword}'");
                System.Diagnostics.Debug.WriteLine($"Total books available: {allBooks?.Count ?? 0}");
                
                 filteredBooks = BookSearchService.SearchAndFilter(
                      allBooks,
                      currentSearchKeyword
                      );
                System.Diagnostics.Debug.WriteLine($"Search results: {filteredBooks.Count} books found");

                // Refresh display
                RefreshBookDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sách: {ex.Message}",
                         "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        /// <summary>
        // Lớp nội bộ để giữ thông tin giỏ hàng
        /// </summary>
        internal class CartItem
        {
            public int BookId { get; set; }
            public string BookName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public int AvailableStock { get; set; } // Thêm tồn kho
            public decimal Total { get { return Price * Quantity; } }
        }

        /// <summary>
        /// Tải danh sách sách (Thẻ)
        /// </summary>
        private void LoadBooks()
        {
            try
            {
                 //1. Clear existing data
                //flowPanelBooks.Controls.Clear();

                // 2. Load all books từ database: Gán vào allBooks
                allBooks = BookRepository.GetAllBooks();
                if (allBooks == null)
                {
                    allBooks = new List<dynamic>();
                }

                // 3. Initialize filtered books - Ban đầu hiển thị tất cả
                filteredBooks = allBooks.ToList();
                System.Diagnostics.Debug.WriteLine($"LoadBooks: Loaded {allBooks.Count} books from database");

                // 4. Display books trong FlowPanel
                RefreshBookDisplay();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadBooks error: {ex}");
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback: Initialize empty lists để tránh null reference
                allBooks = new List<dynamic>();
                filteredBooks = new List<dynamic>();
            }
        }
        /// <summary>
        /// Refresh hiển thị sách trong FlowPanel
        /// </summary>
        private void RefreshBookDisplay()
        {
            try
            {
                flowPanelBooks.Controls.Clear();
                // Kiểm tra null safety
                if (filteredBooks == null || filteredBooks.Count == 0)
                {
                    return;
                }
                System.Diagnostics.Debug.WriteLine($"RefreshBookDisplay: Displaying {filteredBooks.Count} books");
            
                // Sử dụng filteredBooks
                foreach (dynamic sach in filteredBooks)
                {
                    try
                    {
                        ucBookCard card = new ucBookCard();
                        string title = sach.TenSach?.ToString() ?? "";
                        string author = sach.TacGia?.ToString() ?? "";
                        string cover = sach.AnhBiaUrl?.ToString() ?? "";
                        decimal price = 0;
                        try
                        {
                            if (sach.Gia != null)
                                price = Convert.ToDecimal(sach.Gia);
                        }
                        catch (Exception priceEx)
                        {
                            System.Diagnostics.Debug.WriteLine($"Price conversion error: {priceEx.Message}");
                        }

                        card.SetBookData(title, author, price, cover);
                        card.Click += BookCard_Click;
                        card.Tag = sach;
                        flowPanelBooks.Controls.Add(card);
                    }
                    catch (Exception cardEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error creating book card: {cardEx.Message}");
                       
                    }
                }


                System.Diagnostics.Debug.WriteLine($"RefreshBookDisplay completed: {flowPanelBooks.Controls.Count} cards added");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RefreshBookDisplay error: {ex}");
                MessageBox.Show($"Lỗi khi hiển thị sách: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Hàm xử lý khi người dùng click vào một thẻ sách 
        /// </summary>
        private void BookCard_Click(object sender, EventArgs e)
        {
            try
            {
                ucBookCard clickedCard = (ucBookCard)sender;
                dynamic selectedSach = clickedCard.Tag;

                int bookId = selectedSach.SachId;
                int availableStock = selectedSach.SoLuong;

                if (availableStock <= 0)
                {
                    MessageBox.Show("Sách này đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem sách đã có trong giỏ chưa
                var existingItem = _cart.FirstOrDefault(item => item.BookId == bookId);

                if (existingItem != null)
                {
                    // Đã có: Tăng số lượng (kiểm tra tồn kho)
                    if (existingItem.Quantity + 1 > availableStock)
                    {
                        MessageBox.Show("Số lượng trong giỏ đã đạt tồn kho tối đa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        existingItem.Quantity++;
                    }
                }
                else
                {
                    // Chưa có: Thêm mới
                    _cart.Add(new CartItem
                    {
                        BookId = bookId,
                        BookName = selectedSach.TenSach,
                        Price = selectedSach.Gia,
                        Quantity = 1,
                        AvailableStock = availableStock
                    });
                }

                // Cập nhật lại DataGridView và Tổng tiền
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm vào giỏ hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbPromotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn một khuyến mãi, tính toán lại tổng tiền
            UpdateTotals();
        }
        /// <summary>
        /// Mở form thêm khách hàng (Nút tìm kiếm khách hàng)
        /// </summary>
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // Mở form thêm khách hàng dạng modal
            using (var form = new frmAddCustomer())
            {
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK && form.CreatedCustomer != null)
                {
                    try
                    {
                        // Dùng customer vừa tạo để điền ngay vào các toolbox
                        var created = form.CreatedCustomer;
                        _currentCustomerId = created.KhId;
                        lblCustomerInfo.Text = $"Giao đến: { (string.IsNullOrEmpty(created.TenKhach) ? "Khách vãng lai" : created.TenKhach) } | SĐT: {created.SoDienThoai}";
                        rtbAddressDelivery.Text = created.DiaChi ?? "";
                        // Điền số điện thoại vào ô tìm kiếm để dễ theo dõi
                        txtCustomerSearch.Text = created.SoDienThoai ?? "";

                        ibtnThanhToan.Enabled = true;

                        // Nếu đã có sản phẩm trong giỏ, hỏi người dùng có muốn tiến hành thanh toán ngay
                        if (_cart.Count >0)
                        {
                            var ask = MessageBox.Show("Khách hàng được tạo thành công. Bạn có muốn tiến hành thanh toán ngay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ask == DialogResult.Yes)
                            {
                                // Gọi handler thanh toán
                                btnThanhToan_Click(this, EventArgs.Empty);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã tạo khách hàng nhưng có lỗi khi cập nhật giao diện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dr == DialogResult.OK)
                {
                    // Nếu DialogResult.OK nhưng không có CreatedCustomer, fallback load
                    LoadCustomerInfo();
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click cho nút "Thanh Toán"
        /// </summary>
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra giỏ hàng
                if (_cart.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng của bạn đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. SỬA LỖI: Kiểm tra _currentCustomerId
                if (_currentCustomerId == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng của bạn. Vui lòng liên kết tài khoản của bạn với một hồ sơ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Xác nhận
                decimal tongTien = _cart.Sum(item => item.Total);
                
                // Lấy khuyến mãi đang chọn (nếu có) và tính tiền giảm
                var selectedPromo = cmbPromotions.SelectedItem as KhuyenMai;
                decimal discount =0m;
                decimal percent =0m;
                if (selectedPromo != null && selectedPromo.KmId >0)
                {
                    percent = selectedPromo.PhanTramGiam /100m;
                    discount = Math.Round(tongTien * percent,2);
                }
                
                decimal netTotal = tongTien - discount;
                
                var result = MessageBox.Show($"Xác nhận thanh toán {netTotal:N0} đ?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 4. Chuẩn bị HoaDon (lưu tổng tiền sau giảm)
                    HoaDon newBill = new HoaDon
                    {
                        UserId = CurrentUser.UserId,
                        TongTien = netTotal,
                        TrangThai = "DaThanhToan",
                        DiaChiGiaoHang = null,
                        KhId = _currentCustomerId,
                        TenNguoiMua = null
                    };

                    // 5. Chuẩn bị ChiTietHoaDon: phân bổ tiền giảm theo tỉ lệ phần trăm (hoặc theo percent)
                    var details = new List<ChiTietHoaDon>();
                    foreach (var item in _cart)
                    {
                        decimal itemTotal = item.Total;
                        decimal itemDiscount = 0m;
                        if (percent >0)
                        {
                            itemDiscount = Math.Round(itemTotal * percent,2);
                        }
                        
                        var detail = new ChiTietHoaDon
                        {
                            SachId = item.BookId,
                            SoLuong = item.Quantity,
                            DonGia = item.Price,
                            TienGiam = itemDiscount,
                            KhuyenMaiId = (selectedPromo != null && selectedPromo.KmId >0) ? (int?)selectedPromo.KmId : null,
                            ThanhTien = (itemTotal - itemDiscount)
                        };
                        details.Add(detail);
                    }

                    // 6. Gọi Repository 
                    bool success = HoaDonRepository.CreateInvoice(newBill, details);

                    if (success)
                    {
                        MessageBox.Show("Thanh toán thành công! Cảm ơn bạn đã mua hàng.", "Thành công",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _cart.Clear();
                        RefreshCart();
                        LoadBooks(); // Tải lại sách để cập nhật Tồn kho
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Cart UI Methods (Hàm giao diện giỏ hàng)

        /// <summary>
        /// Cấu hình DataGridView giỏ hàng (dgvCart)
        /// </summary>
        private void SetupCartGrid()
        {
            // Giả sử dgvCart là tên DataGridView bên phải
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.ColumnHeadersVisible = false;
            dgvCart.RowHeadersVisible = false;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBookName",
                HeaderText = "Tên sách",
                DataPropertyName = "BookName",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "SL",
                DataPropertyName = "Quantity",
                ReadOnly = false,
                Width = 40
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Thành tiền",
                DataPropertyName = "Total",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 80
            });

            var colDelete = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                Text = "X",
                UseColumnTextForButtonValue = true,
                Width = 30,
                FlatStyle = FlatStyle.Flat,
            };
            colDelete.DefaultCellStyle.BackColor = Color.LightGray;
            dgvCart.Columns.Add(colDelete);

            // Gán sự kiện
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            dgvCart.CellValueChanged += dgvCart_CellValueChanged;
        }

        /// <summary>
        /// Cập nhật DataGridView của giỏ hàng
        /// </summary>
        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            if (_cart.Count > 0)
            {
                dgvCart.DataSource = _cart.ToList();
            }
            UpdateTotals();
        }

        /// <summary>
        /// Tính toán và cập nhật các Label tổng tiền
        /// </summary>
        private void UpdateTotals()
        {
            decimal subtotal = _cart.Sum(item => item.Total);
            decimal discount = 0; // Đặt lại KM về 0

            // Lấy Khuyến mãi đang được chọn
            var selectedPromo = cmbPromotions.SelectedItem as KhuyenMai;

            if (selectedPromo != null && selectedPromo.KmId > 0)
            {
                // Tính toán khuyến mãi
                // VÍ DỤ: Giảm %
                decimal percent = selectedPromo.PhanTramGiam / 100;
                discount = subtotal * percent;

                // TODO: Thêm logic "Giảm tối đa" (maxMoney) nếu CSDL có
                // decimal maxDiscount = selectedPromo.MaxDiscount;
                // if (discount > maxDiscount) { discount = maxDiscount; }
            }

            _currentDiscount = discount; 
            decimal total = subtotal - discount;

            lblSubtotal.Text = subtotal.ToString("N0") + "đ";
            lblDiscountValue.Text = discount.ToString("N0") + "đ"; // Hiển thị tiền giảm
            lblTotalValue.Text = total.ToString("N0") + "đ";
        }

        /// <summary>
        /// Xử lý khi bấm nút Xóa (X) trong giỏ hàng
        /// </summary>
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colDelete"].Index && e.RowIndex >= 0)
            {
                int bookId = _cart[e.RowIndex].BookId;
                var itemToRemove = _cart.FirstOrDefault(item => item.BookId == bookId);
                if (itemToRemove != null)
                {
                    _cart.Remove(itemToRemove);
                    RefreshCart();
                }
            }
        }

        /// <summary>
        /// Xử lý khi sửa số lượng trong giỏ hàng
        /// </summary>
        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colQuantity"].Index && e.RowIndex >= 0)
            {
                try
                {
                    var item = _cart[e.RowIndex];
                    int newQuantity = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["colQuantity"].Value);

                    if (newQuantity <= 0)
                    {
                        _cart.Remove(item);
                    }
                    else if (newQuantity > item.AvailableStock)
                    {
                        MessageBox.Show("Số lượng vượt quá tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCart.Rows[e.RowIndex].Cells["colQuantity"].Value = item.Quantity; // Hoàn tác
                    }
                    else
                    {
                        item.Quantity = newQuantity;
                    }
                }
                catch (Exception)
                {
                    RefreshCart(); // Hoàn tác nếu nhập bậy (ví dụ: chữ)
                }
                finally
                {
                    RefreshCart(); // Cập nhật lại tổng tiền
                }
            }
        }

        #endregion


        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var customerPhone = CustomerRepository.GetCustomerByPhone(txtCustomerSearch.Text);
                if (customerPhone != null)
                {
                    _currentCustomerId = customerPhone.KhId;
                    lblCustomerInfo.Text = $"Giao đến: {customerPhone.TenKhach} | SĐT: {customerPhone.SoDienThoai}";
                    rtbAddressDelivery.Text = customerPhone.DiaChi;
                    ibtnThanhToan.Enabled = true;
                }
                else
                {
                    txtCustomerSearch.Text = "";
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iconSearchBook_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }
    }
}