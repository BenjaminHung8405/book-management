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
using book_management.UI.Modal; // thêm using để dùng frmAddCustomer

namespace book_management.UI.Controls
{
    public partial class StoreControl : UserControl
    {
        public StoreControl()
        {
            InitializeComponent();
            // Load books on control creation for UI testing
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                // 1. Xóa tất cả sách cũ
                flowPanelBooks.Controls.Clear();

                // 2. Lấy danh sách sách từ BookRepository (dynamic)
                var danhSachSach = BookRepository.GetAllBooks();

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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý khi người dùng click vào một thẻ sách
        private void BookCard_Click(object sender, EventArgs e)
        {
            // Lấy UserControl đã được click
            ucBookCard clickedCard = (ucBookCard)sender;

            // Lấy thông tin sách đã lưu trong Tag
            dynamic selectedSach = clickedCard.Tag;

            // Hiển thị thông tin sách được chọn
            MessageBox.Show($"Bạn đã chọn: {selectedSach.TenSach}\nTác giả: {selectedSach.TacGia}\nGiá: {selectedSach.Gia:C}",
                "Thông tin sách", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Implement thêm sách vào hóa đơn khi có UI đầy đủ
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // Mở form thêm khách hàng dạng modal
            using (var form = new frmAddCustomer())
            {
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // Nếu cần refresh dữ liệu khách hàng hoặc UI liên quan thì gọi ở đây
                    // Ví dụ: RefreshCustomerList();
                }
            }
        }
    }
}
