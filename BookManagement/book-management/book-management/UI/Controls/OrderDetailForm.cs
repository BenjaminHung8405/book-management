using System.Windows.Forms;
using book_management.Models;
using System.Collections.Generic;
using System.Drawing;

namespace book_management.UI
{
    // SỬA 1: Thêm 'partial' (Dù không có file Designer,
    // đây là thói quen tốt để VS nhận diện nó là Form)
    public partial class OrderDetailForm : Form
    {
        private List<ChiTietHoaDon> _chiTietHD;

        // SỬA 2: Khai báo DataGridView ở cấp độ class
        private DataGridView dgvDetail;

        public OrderDetailForm(List<ChiTietHoaDon> chiTietHD)
        {
            InitializeComponent(); // Hàm này TẠO dgvDetail
            _chiTietHD = chiTietHD;
            LoadOrderDetails(); // Hàm này SỬ DỤNG dgvDetail
        }

        private void InitializeComponent()
        {
            this.Text = "Chi tiết hóa đơn";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // SỬA 3: Gán vào biến class (không dùng 'var')
            dgvDetail = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            dgvDetail.Columns.Add("TenSach", "Tên sách");
            dgvDetail.Columns.Add("DonGia", "Đơn giá");
            dgvDetail.Columns.Add("SoLuong", "Số lượng");
            dgvDetail.Columns.Add("GiamGia", "Giảm giá");
            dgvDetail.Columns.Add("ThanhTien", "Thành tiền");

            this.Controls.Add(dgvDetail);
        }

        private void LoadOrderDetails()
        {
            // SỬA 4: Sử dụng biến class trực tiếp, không cần 'Find'
            if (dgvDetail != null)
            {
                dgvDetail.Rows.Clear();
                foreach (var item in _chiTietHD)
                {
                    dgvDetail.Rows.Add(
                        item.TenSach,
                        item.DonGia.ToString("N0") + " đ", // Sửa ký tự '?' thành 'đ'
                        item.SoLuong,
                        item.TienGiam.ToString("N0") + " đ",
                        item.ThanhTien.ToString("N0") + " đ"
                    );
                }
            }
        }
    }
}