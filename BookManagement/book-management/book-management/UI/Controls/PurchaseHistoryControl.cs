using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.DataAccess;
using book_management.Models;

namespace book_management.UI.Controls
{
    public class PurchaseHistoryControl : UserControl
    {
        private DataGridView dgvPurchaseHistory;
        
        public PurchaseHistoryControl()
        {
            InitializeComponent();
            LoadPurchaseHistory();
        }

        private void InitializeComponent()
        {
            // Thiết lập DataGridView để hiển thị lịch sử mua hàng
            dgvPurchaseHistory = new DataGridView();
            dgvPurchaseHistory.Dock = DockStyle.Fill;
            
            // Thêm các cột
            dgvPurchaseHistory.Columns.Add("MaHD", "Mã hóa đơn");
            dgvPurchaseHistory.Columns.Add("NgayMua", "Ngày mua");
            dgvPurchaseHistory.Columns.Add("TongTien", "Tổng tiền");
            dgvPurchaseHistory.Columns.Add("TrangThai", "Trạng thái");
            
            // Thêm button xem chi tiết
            var btnDetail = new DataGridViewButtonColumn();
            btnDetail.Name = "ChiTiet";
            btnDetail.Text = "Xem chi tiết";
            btnDetail.UseColumnTextForButtonValue = true;
            dgvPurchaseHistory.Columns.Add(btnDetail);
            
            // Xử lý sự kiện click vào nút chi tiết
            dgvPurchaseHistory.CellClick += DgvPurchaseHistory_CellClick;
            
            this.Controls.Add(dgvPurchaseHistory);
        }

        private void LoadPurchaseHistory()
        {
            try
            {
                // Lấy danh sách hóa đơn của khách hàng hiện tại
                var hoaDons = HoaDonRepository.GetHoaDonsByKhachHang(CurrentUser.UserId);
                
                dgvPurchaseHistory.Rows.Clear();
                foreach (var hd in hoaDons)
                {
                    dgvPurchaseHistory.Rows.Add(
                        hd.MaHD,
                        hd.NgayLap.ToString("dd/MM/yyyy"),
                        hd.TongTien.ToString("N0") + " đ",
                        hd.TrangThai
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử mua hàng: " + ex.Message);
            }
        }

        private void DgvPurchaseHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào nút xem chi tiết
            if (e.ColumnIndex == dgvPurchaseHistory.Columns["ChiTiet"].Index && e.RowIndex >= 0)
            {
                string maHD = dgvPurchaseHistory.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                ShowOrderDetail(maHD);
            }
        }

        private void ShowOrderDetail(string maHD)
        {
            try
            {
                var chiTietHD = ChiTietHoaDonRepository.GetChiTietHoaDon(maHD);
                var frmDetail = new OrderDetailForm(chiTietHD);
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
