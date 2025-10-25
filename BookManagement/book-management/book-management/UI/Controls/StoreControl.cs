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
using book_management.UI.Controls;

namespace book_management.UI.Controls
{
    public partial class StoreControl : UserControl
    {
        public StoreControl()
        {
            InitializeComponent();
            // Load books on control creation for UI testing
            LoadBooks();

            // Load sample order items for right side
            LoadSampleOrderItems();

            // Hook customer search
            txtCustomerSearch.TextChanged += txtCustomerSearch_TextChanged;
        }

        private void LoadBooks()
        {
            // 1. Xóa tất cả sách cũ
            flowPanelBooks.Controls.Clear();

            // 2. Lấy danh sách sách từ Mock Database (dynamic)
            var danhSachSach = Database.GetAllBooks();

            // 3. Lặp qua danh sách và tạo Card
            foreach (dynamic sach in danhSachSach)
            {
                // 3a. Tạo một Card mới
                ucBookCard card = new ucBookCard();

                // 3b. Gán dữ liệu cho Card
                string title = sach.TenSach;
                string author = sach.TacGia;
                decimal price = sach.Gia;
                string cover = sach.AnhBiaUrl;

                card.SetBookData(title, author, price, cover);

                // 3c. Thêm sự kiện click cho Card
                card.Click += BookCard_Click;
                card.Tag = sach; // Lưu trữ đối tượng dynamic để dùng khi click

                // 3d. Thêm Card vào FlowLayoutPanel
                flowPanelBooks.Controls.Add(card);
            }
        }

        // Hàm xử lý khi người dùng click vào một thẻ sách
        private void BookCard_Click(object sender, EventArgs e)
        {
            // Lấy UserControl đã được click
            ucBookCard clickedCard = (ucBookCard)sender;

            // Lấy thông tin sách đã lưu trong Tag
            dynamic selectedSach = clickedCard.Tag;

            // Thêm sách vào danh sách order (nếu đã có thì tăng số lượng)
            AddBookToOrder(selectedSach);
        }

        private void AddBookToOrder(dynamic sach)
        {
            // Kiểm tra nếu đã có trong flowPanelOrderItems thì tăng quantity
            foreach (Control c in flowPanelOrderItems.Controls)
            {
                if (c is ucOrderItem oi)
                {
                    if (oi.GetSachId() == (int)sach.SachId)
                    {
                        oi.AddQuantity(1);
                        RecalculateTotals();
                        return;
                    }
                }
            }

            // Nếu chưa có, tạo 1 order item từ sách
            dynamic it = new System.Dynamic.ExpandoObject();
            it.SachId = sach.SachId;
            it.TenSach = sach.TenSach;
            it.DonGia = sach.Gia;
            it.SoLuong = 1;
            it.ThanhTien = it.DonGia * it.SoLuong;
            it.AnhBiaUrl = sach.AnhBiaUrl;

            var uc = new ucOrderItem();
            uc.SetData(it);
            uc.QuantityChanged += (s, e) => RecalculateTotals();
            uc.Removed += (s, e) =>
            {
                flowPanelOrderItems.Controls.Remove(uc);
                RecalculateTotals();
            };

            flowPanelOrderItems.Controls.Add(uc);
            RecalculateTotals();
        }

        private void LoadSampleOrderItems()
        {
            flowPanelOrderItems.Controls.Clear();

            var items = Database.GetSampleOrderItems();
            foreach (dynamic it in items)
            {
                var uc = new ucOrderItem();
                uc.SetData(it);
                uc.QuantityChanged += (s, e) => RecalculateTotals();
                uc.Removed += (s, e) =>
                {
                    flowPanelOrderItems.Controls.Remove((Control)s);
                    RecalculateTotals();
                };
                flowPanelOrderItems.Controls.Add(uc);
            }

            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            decimal subtotal = 0m;
            foreach (Control c in flowPanelOrderItems.Controls)
            {
                if (c is ucOrderItem oi)
                {
                    subtotal += oi.GetLineTotal();
                }
            }

            lblSubtotalValue.Text = subtotal.ToString("N0") + "₫";

            // For mock: no discount
            lblDiscountValue.Text = "0₫";

            lblTotalValue.Text = subtotal.ToString("N0") + "₫";
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            var results = Database.SearchCustomers(txtCustomerSearch.Text);
            if (results.Count > 0)
                lblCustomerName.Text = "Khách hàng: " + results[0].TenKhach;
            else
                lblCustomerName.Text = "Khách hàng: (không tìm thấy)";
        }
    }
}
