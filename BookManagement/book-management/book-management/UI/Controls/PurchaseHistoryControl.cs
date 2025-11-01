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
        private readonly int _userId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn ChiTiet;
        private DataGridView dgvPurchaseHistory;

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
        private void InitializeComponent()
        {
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.ChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ChiTiet});
            this.dgvPurchaseHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(546, 208);
            this.dgvPurchaseHistory.TabIndex = 0;
            // 
            // ChiTiet
            // 
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.Text = "Xem chi tiết";
            this.ChiTiet.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã hóa đơn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ngày mua";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // PurchaseHistoryControl
            // 
            this.Controls.Add(this.dgvPurchaseHistory);
            this.Name = "PurchaseHistoryControl";
            this.Size = new System.Drawing.Size(546, 208);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.ResumeLayout(false);

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
                var chiTietHD = ChiTietHoaDonRepository.GetChiTietHoaDon(hoaDonId);
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
