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
    public partial class PurchaseHistoryControl : UserControl
    {
      private readonly int _userId;

        public PurchaseHistoryControl(int _userid)
        {
         InitializeComponent();
            _userId = _userid;
      this.Load += PurchaseHistoryControl_Load;
   }

      private void PurchaseHistoryControl_Load(object sender, EventArgs e)
 {
    LoadPurchaseHistory();
        }

  private void LoadPurchaseHistory()
        {
            try
  {
            var hoaDons = HoaDonRepository.GetHoaDonsByUserId(_userId);
//dgvPurchaseHistory.Rows.Clear();

                foreach (var hd in hoaDons)
       {
       dgvPurchaseHistory.Rows.Add(
       hd.HoaDonId,
           hd.NgayLap.ToString("dd/MM/yyyy"),
      hd.TongTien.ToString("N0") + " đ",
            hd.TrangThai,
     null
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
         int hoaDonId = Convert.ToInt32(dgvPurchaseHistory.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value);
                ShowOrderDetail(hoaDonId);
            }
      }

   private void ShowOrderDetail(int hoaDonId)
        {
        try
        {
  var chiTietHD = ChiTietHoaDonRepository.GetChiTietByHoaDonId(hoaDonId);
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
