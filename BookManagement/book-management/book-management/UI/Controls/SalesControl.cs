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

namespace book_management.UI.Controls
{
    public partial class SalesControl : UserControl
    {
        private List<CartItem> cartItems;
        private decimal totalAmount = 0;
        private int currentCustomerId = 0; // 0 = Khách vãng lai

        public SalesControl()
        {
            InitializeComponent();
            cartItems = new List<CartItem>();
        }

        private void SalesControl_Load(object sender, EventArgs e)
        {
            LoadBookData();
            SetupCartGrid();
            ResetForm();
        }

        #region Event Handlers (Xử lý sự kiện)

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void txtSearchBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBooks();
                e.Handled = true;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            AddSelectedBookToCart();
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddSelectedBookToCart();
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            RemoveSelectedCartItem();
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["colQuantity"].Index)
            {
                UpdateCartItemQuantity(e.RowIndex);
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm khách hàng mới đang được phát triển.",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            CreateNewBill();
        }

        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            CancelCurrentBill();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            PrintBill();
        }

        #endregion

        #region Methods (Hàm logic)

        private void LoadBookData()
        {
            try
            {
                // Giả sử BookRepository.GetAllBooks() hoạt động đúng
                var books = BookRepository.GetAllBooks();
                var bookList = books.Select(b => new
                {
                    SachId = b.SachId,
                    TenSach = b.TenSach,
                    TacGia = b.TacGia,
                    TheLoai = b.TheLoai,
                    Gia = b.Gia,
                    SoLuong = b.SoLuong
                }).ToList();

                dgvBooks.DataSource = bookList;
                StyleBooksGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBooks()
        {
            try
            {
                string keyword = txtSearchBook.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadBookData();
                    return;
                }
                // Giả sử BookRepository.SearchBooks(keyword) hoạt động đúng
                var books = BookRepository.SearchBooks(keyword);
                var bookList = books.Select(b => new
                {
                    SachId = b.SachId,
                    TenSach = b.TenSach,
                    TacGia = b.TacGia,
                    TheLoai = b.TheLoai,
                    Gia = b.Gia,
                    SoLuong = b.SoLuong
                }).ToList();

                dgvBooks.DataSource = bookList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sách: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSelectedBookToCart()
        {
            if (dgvBooks.CurrentRow == null) return;

            try
            {
                var row = dgvBooks.CurrentRow;
                int bookId = Convert.ToInt32(row.Cells["SachId"].Value);
                string bookName = row.Cells["TenSach"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Gia"].Value);
                int availableQty = Convert.ToInt32(row.Cells["SoLuong"].Value);

                if (availableQty <= 0)
                {
                    MessageBox.Show("Sách này đã hết hàng!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = cartItems.FirstOrDefault(x => x.BookId == bookId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity < availableQty)
                    {
                        existingItem.Quantity++;
                        existingItem.Total = existingItem.Quantity * existingItem.Price;
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm quá số lượng tồn kho!", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    cartItems.Add(new CartItem
                    {
                        BookId = bookId,
                        BookName = bookName,
                        Price = price,
                        Quantity = 1,
                        Total = price,
                        AvailableStock = availableQty // Lưu lại tồn kho
                    });
                }
                RefreshCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sách vào giỏ: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveSelectedCartItem()
        {
            if (dgvCart.CurrentRow == null) return;

            try
            {
                int index = dgvCart.CurrentRow.Index;
                if (index >= 0 && index < cartItems.Count)
                {
                    cartItems.RemoveAt(index);
                    RefreshCartDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartItemQuantity(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0 && rowIndex < cartItems.Count)
                {
                    var item = cartItems[rowIndex];
                    var newQty = Convert.ToInt32(dgvCart.Rows[rowIndex].Cells["colQuantity"].Value);

                    if (newQty <= 0)
                    {
                        cartItems.Remove(item);
                    }
                    else if (newQty > item.AvailableStock)
                    {
                        MessageBox.Show("Số lượng vượt quá tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCart.Rows[rowIndex].Cells["colQuantity"].Value = item.Quantity; // Hoàn tác
                    }
                    else
                    {
                        item.Quantity = newQty;
                        item.Total = item.Quantity * item.Price;
                    }
                    RefreshCartDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCustomer()
        {
            try
            {
                string phone = txtCustomerPhone.Text.Trim();
                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Giả sử bạn đã tạo file DataAccess/CustomerRepository.cs
                var customer = CustomerRepository.GetCustomerByPhone(phone);

                if (customer != null)
                {
                    txtCustomerName.Text = customer.TenKhach;
                    txtCustomerAddress.Text = customer.DiaChi;
                    currentCustomerId = customer.KhId;
                    txtCustomerPhone.Text = customer.SoDienThoai;
                    txtCustomerName.ReadOnly = true;
                    txtCustomerAddress.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng. Nhập thông tin khách vãng lai.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerName.Clear();
                    txtCustomerAddress.Clear();
                    currentCustomerId = 0; // Reset ID = 0 (khách vãng lai)
                    txtCustomerName.ReadOnly = false;
                    txtCustomerAddress.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewBill()
        {
            try
            {
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Tạo hóa đơn với tổng tiền {totalAmount:C0}?",
                                           "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 1. Chuẩn bị đối tượng HoaDon
                    HoaDon newBill = new HoaDon
                    {
                        // Giả sử bạn có class CurrentUser (người đang đăng nhập)
                        UserId = CurrentUser.UserId,
                        TongTien = totalAmount,
                        TrangThai = "DaThanhToan",

                        // SỬA LỖI 1: Gán NULL (không phải 0) cho khách vãng lai
                        KhId = (currentCustomerId > 0) ? (int?)currentCustomerId : null,

                        // SỬA LỖI 2: Gán tên khách vãng lai vào đúng thuộc tính
                        TenNguoiMua = (currentCustomerId == 0) ? txtCustomerName.Text.Trim() : null,
                    };

                    // 2. Chuyển đổi List<CartItem> sang List<ChiTietHoaDon>
                    var details = cartItems.Select(item => new ChiTietHoaDon
                    {
                        SachId = item.BookId,
                        SoLuong = item.Quantity,
                        DonGia = item.Price,
                        // SỬA LỖI 3: Gán TienGiam, KHÔNG GÁN ThanhTien (vì là cột tự động)
                        TienGiam = 0 // Tạm thời, bạn có thể thêm logic khuyến mãi ở đây
                    }).ToList();

                    // 3. Gọi Repository để lưu (hàm này sẽ tự động trừ kho)
                    bool success = HoaDonRepository.CreateInvoice(newBill, details);

                    if (success)
                    {
                        MessageBox.Show("Tạo hóa đơn thành công!",
                                      "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn: {ex.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelCurrentBill()
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn hiện tại?",
                                       "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void PrintBill()
        {
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển.",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshCartDisplay()
        {
            dgvCart.DataSource = null;
            if (cartItems.Any())
            {
                dgvCart.DataSource = cartItems.Select(item => new
                {
                    BookName = item.BookName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Total = item.Total
                }).ToList();
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            totalAmount = cartItems.Sum(x => x.Total);
            lblTotalAmount.Text = $"Tổng tiền: {totalAmount:C0}";
        }

        private void ResetForm()
        {
            cartItems.Clear();
            currentCustomerId = 0;
            totalAmount = 0;

            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtCustomerAddress.Clear();
            txtSearchBook.Clear();

            // Đặt lại trạng thái ReadOnly
            txtCustomerName.ReadOnly = false;
            txtCustomerAddress.ReadOnly = false;

            RefreshCartDisplay();
            LoadBookData();
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

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
                Name = "colPrice",
                HeaderText = "Đơn giá",
                DataPropertyName = "Price",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" },
             });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Số lượng",
                DataPropertyName = "Quantity",
                ReadOnly = false
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Thành tiền",
                DataPropertyName = "Total",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" }
            });
        }

        private void StyleBooksGrid()
        {
            if (dgvBooks.Columns.Count > 0)
            {
                dgvBooks.Columns["SachId"].Visible = false;
                dgvBooks.Columns["TenSach"].HeaderText = "Tên sách";
                dgvBooks.Columns["TacGia"].HeaderText = "Tác giả";
                dgvBooks.Columns["TheLoai"].HeaderText = "Thể loại";
                dgvBooks.Columns["Gia"].HeaderText = "Giá";
                dgvBooks.Columns["SoLuong"].HeaderText = "Tồn kho";
                dgvBooks.Columns["Gia"].DefaultCellStyle.Format = "C0";
            }
        }

        #endregion

        // Helper class for cart items
        private class CartItem
        {
            public int BookId { get; set; }
            public string BookName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Total { get; set; }
            public int AvailableStock { get; set; } // Thêm tồn kho
        }
    }
}