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

            // TODO: Viết code để thêm sách này vào hóa đơn (khu vực bên phải)
            MessageBox.Show("Bạn đã chọn: " + selectedSach.TenSach);
        }
    }
}
