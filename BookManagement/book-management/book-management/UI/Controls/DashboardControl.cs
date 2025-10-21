using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management.UI.Controls
{
    public partial class DashboardControl : System.Windows.Forms.UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            // Xóa dữ liệu mẫu (nếu có)
            chartDoanhThu.Series.Clear();

            // 1. Tạo một Series (dãy dữ liệu) mới
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");

            // 2. Set loại biểu đồ là Line
            seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // 3. Thêm dữ liệu (X, Y)
            seriesDoanhThu.Points.AddXY("Ngày 1", 150000);
            seriesDoanhThu.Points.AddXY("Ngày 2", 300000);
            seriesDoanhThu.Points.AddXY("Ngày 3", 250000);
            seriesDoanhThu.Points.AddXY("Ngày 4", 400000);
            seriesDoanhThu.Points.AddXY("Ngày 5", 350000);
            seriesDoanhThu.Points.AddXY("Ngày 6", 500000);
            seriesDoanhThu.Points.AddXY("Ngày 7", 450000);

            // 4. Thêm Series này vào Chart
            chartDoanhThu.Series.Add(seriesDoanhThu);

            StyleDataGridView();

            // Populate mock data for recent sales
            PopulateMockSales();
        }

        private void StyleDataGridView()
        {
            // --- Style cho Header (Tiêu đề cột) ---
            var headerStyle = dataGridViewSales.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(249, 250, 251); // bg-gray-50
            headerStyle.ForeColor = Color.FromArgb(55, 65, 81);    // text-gray-700
            headerStyle.Font = new Font("Inter", 9F, FontStyle.Bold); // text-xs, uppercase (Bold)
            headerStyle.Padding = new Padding(10, 8, 10, 8); // px-6 py-3
            dataGridViewSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewSales.ColumnHeadersHeight = 45; // Chiều cao header

            // --- Style cho Dòng (Row) ---
            var cellStyle = dataGridViewSales.DefaultCellStyle;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Inter", 9F, FontStyle.Regular);
            cellStyle.ForeColor = Color.FromArgb(107, 114, 128); // text-gray-500
            cellStyle.Padding = new Padding(10, 0, 10, 0); // px-6

            // Style khi chọn dòng (hover:bg-gray-50)
            cellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            cellStyle.SelectionForeColor = Color.Black;

            // Set chiều cao dòng
            dataGridViewSales.RowTemplate.Height = 45; // py-4
        }

        // Thêm mock data mẫu cho dataGridViewSales
        private void PopulateMockSales()
        {
            // Nếu grid đang được bind tới DataSource khác, bỏ qua (để tránh lỗi)
            if (dataGridViewSales.DataSource != null) return;

            dataGridViewSales.Rows.Clear();

            // Các trạng thái mẫu: "Đã thanh toán", "Chờ xử lý", "Đã hủy"
            var mockRows = new object[,]
            {
                { "HD-0001", "Nguyễn Văn A", DateTime.Now.AddHours(-2), 150000, "Đã thanh toán", "" },
                { "HD-0002", "Trần Thị B", DateTime.Now.AddDays(-1).AddHours(-3), 320000, "Chờ xử lý", "" },
                { "HD-0003", "Lê Văn C", DateTime.Now.AddDays(-2), 450000, "Đã thanh toán", "" },
                { "HD-0004", "Phạm Thị D", DateTime.Now.AddDays(-3).AddHours(-6), 78000, "Đã hủy", "" },
                { "HD-0005", "Hoàng Văn E", DateTime.Now.AddHours(-5), 220000, "Chờ xử lý", "" },
                { "HD-0006", "Võ Thị F", DateTime.Now.AddDays(-7), 99000, "Đã thanh toán", "" }
            };

            for (int i = 0; i < mockRows.GetLength(0); i++)
            {
                // Rows.Add theo thứ tự cột: colMaHoaDon, colKhachHang, colNgayTao, colTongTien, colTrangThai, colChiTiet
                dataGridViewSales.Rows.Add(
                    mockRows[i, 0], // MaHoaDon
                    mockRows[i, 1], // TenKhachHang
                    mockRows[i, 2], // NgayTao (DateTime -> sẽ format theo DefaultCellStyle)
                    mockRows[i, 3], // TongTien (number)
                    mockRows[i, 4], // TrangThai
                    mockRows[i, 5]  // ChiTiet (link column uses column text)
                );
            }
        }

        private void dataGridViewSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Chỉ áp dụng cho cột "colTrangThai"
            if (this.dataGridViewSales.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    // (bg-green-100, text-green-800)
                    if (status.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                        e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    // (bg-yellow-100, text-yellow-800)
                    else if (status.Equals("Chờ xử lý", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                        e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);
                    }
                    // (bg-red-100, text-red-800)
                    else if (status.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                        e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                    }

                    // Căn giữa chữ trong ô trạng thái
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold); // font-medium
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo click không phải là header và là cột "colChiTiet"
            if (e.RowIndex >= 0 && this.dataGridViewSales.Columns[e.ColumnIndex].Name == "colChiTiet")
            {
                // Lấy Mã Hóa Đơn từ cột đầu tiên của dòng được click
                string maHoaDon = this.dataGridViewSales.Rows[e.RowIndex].Cells["colMaHoaDon"].Value.ToString();

                MessageBox.Show("Mở chi tiết cho hóa đơn: " + maHoaDon);

                // TODO: Viết code mở FormChiTietHoaDon tại đây
                // FormChiTietHoaDon f = new FormChiTietHoaDon(maHoaDon);
                // f.ShowDialog();
            }
        }
    }
}
