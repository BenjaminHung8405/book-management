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
using book_management.Data.book_management.DataAccess;
using book_management.DataAccess; // Cần thêm
using book_management.Models; // Cần thêm
using book_management.UI.Modal;

namespace book_management.UI.Controls
{
    public partial class StoreControl : UserControl
    {
        // Biến lưu ID hồ sơ khách hàng (kh_id)
        private int _currentCustomerId = 0;
        
        // Lưu trữ danh sách KM để tính toán
        private List<KhuyenMai> _availablePromotions;

        // Biến lưu giá trị giảm giá hiện tại
        private decimal _currentDiscount = 0;

        // Biến lưu giỏ hàng
        private List<CartItem> _cart = new List<CartItem>();

        public StoreControl()
        {
            InitializeComponent();
            LoadBooks();

            // Thêm hàm thiết lập DataGridView cho giỏ hàng
            SetupCartGrid();
            LoadPromotions();
        }

        private void StoreControl_Load(object sender, EventArgs e)
        {
            // Tự động tải thông tin khách hàng khi form load
            LoadCustomerInfo();
        }

        /// <summary>
        /// Tự động tìm kh_id (mã khách hàng) dựa trên user_id
        /// </summary>
        private void LoadCustomerInfo()
        {
            try
            {
                // Tìm kh_id dựa trên user_id (dùng hàm mới trong Repository)
                // Giả sử: Chúng ta tìm kh_id mà user này đã dùng ở hóa đơn gần nhất
                _currentCustomerId = HoaDonRepository.GetDefaultKhIdForUser(CurrentUser.UserId);

                if (_currentCustomerId > 0)
                {
                    
                    var customer = CustomerRepository.GetCustomerById(_currentCustomerId);
                    
                }
                // Nếu _currentCustomerId = 0, hệ thống sẽ hiểu là có lỗi (hoặc user mới)
                // và btnThanhToan_Click sẽ báo lỗi (như hiện tại)
                // LƯU Ý: Cần có 1 User liên kết với 1 KhachHang
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
               // _availablePromotions = KhuyenMaiRepository.GetAvailablePromotions();

                // 2. Tạo một item "Không chọn"
                var displayList = new List<KhuyenMai>();
                displayList.Add(new KhuyenMai { KmId = 0, TenKm = "--- Chọn khuyến mãi ---" });
                displayList.AddRange(_availablePromotions);

                // 3. Nạp vào ComboBox
                cmbPromotions.DataSource = displayList;
                cmbPromotions.DisplayMember = "TenKm"; // Hiển thị tên (VD: "Giảm 10%")
                cmbPromotions.ValueMember = "KmId";   // Lưu lại ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khuyến mãi: " + ex.Message);
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
                flowPanelBooks.Controls.Clear();
                var danhSachSach = BookRepository.GetAllBooks();

                foreach (dynamic sach in danhSachSach)
                {
                    ucBookCard card = new ucBookCard();
                    string title = sach.TenSach;
                    string author = sach.TacGia;
                    decimal price = sach.Gia;
                    string cover = sach.AnhBiaUrl;

                    card.SetBookData(title, author, price, cover);
                    card.Click += BookCard_Click;
                    card.Tag = sach;
                    flowPanelBooks.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm xử lý khi người dùng click vào một thẻ sách (ĐÃ SỬA)
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
        /// Xử lý sự kiện click cho nút "Thanh Toán" (ĐÃ SỬA)
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
                var result = MessageBox.Show($"Xác nhận thanh toán {tongTien:N0} đ?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 4. Chuẩn bị HoaDon
                    HoaDon newBill = new HoaDon
                    {
                        UserId = CurrentUser.UserId,
                        TongTien = tongTien,
                        TrangThai = "DaThanhToan",

                        // SỬA LỖI: Gán KhId đã tìm được lúc Load
                        KhId = _currentCustomerId,
                        TenNguoiMua = null
                    };

                    // 5. Chuẩn bị ChiTietHoaDon
                    var details = _cart.Select(item => new ChiTietHoaDon
                    {
                        SachId = item.BookId,
                        SoLuong = item.Quantity,
                        DonGia = item.Price,
                        TienGiam = 0 // (Cần logic khuyến mãi nếu có)
                    }).ToList();

                    // 6. Gọi Repository (Hàm này đã được sửa ở tin nhắn trước)
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

                // TODO: Thêm logic "Giảm tối đa" (maxMoney) nếu CSDL của bạn có
                // decimal maxDiscount = selectedPromo.MaxDiscount;
                // if (discount > maxDiscount) { discount = maxDiscount; }
            }

            _currentDiscount = discount; // Lưu lại KM (Hàm ThanhToan sẽ dùng)
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

        private void StoreControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}