using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data; // Thêm namespace để sử dụng DashboardRepository

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
            try
            {
                // Load dữ liệu chart và grid từ database
                LoadRevenueChart();
                StyleDataGridView();
                LoadRecentSales();

                // Load thống kê tổng quan (nếu có labels để hiển thị)
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu dashboard:\n{ex.Message}",
               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback to mock data if database fails
                LoadMockDataFallback();
            }
        }

        /// <summary>
        /// Load biểu đồ doanh thu từ database (7 ngày gần nhất)
        /// </summary>
        private void LoadRevenueChart()
        {
            // Xóa dữ liệu cũ
            chartDoanhThu.Series.Clear();

            // Tạo series mới
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");
            seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Lấy dữ liệu 7 ngày gần nhất từ database
            var revenueData = DashboardRepository.GetLast7DaysRevenue();

            foreach (dynamic revenue in revenueData)
            {
                DateTime date = revenue.Ngay;
                decimal amount = revenue.DoanhThu;

                // Format ngày hiển thị
                string dateLabel = date.ToString("dd/MM");

                seriesDoanhThu.Points.AddXY(dateLabel, (double)amount);
            }

            // Thêm series vào chart
            chartDoanhThu.Series.Add(seriesDoanhThu);

            // Cấu hình chart
            ConfigureChart();
        }

        /// <summary>
        /// Cấu hình chart để hiển thị đẹp hơn
        /// </summary>
        private void ConfigureChart()
        {
            // Cấu hình trục Y để hiển thị tiền tệ
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "C0"; // Currency format

            // Cấu hình màu sắc
            chartDoanhThu.Series[0].Color = Color.FromArgb(74, 144, 226);
            chartDoanhThu.Series[0].BorderWidth = 3;

            // Hiển thị giá trị trên điểm
            chartDoanhThu.Series[0].IsValueShownAsLabel = true;
            chartDoanhThu.Series[0].LabelFormat = "C0";
        }

        /// <summary>
        /// Load dữ liệu hóa đơn gần đây từ database
        /// </summary>
        private void LoadRecentSales()
        {
            // Nếu grid đang được bind tới DataSource khác, bỏ qua
            if (dataGridViewSales.DataSource != null) return;

            dataGridViewSales.Rows.Clear();

            // Lấy 10 hóa đơn gần nhất từ database
            var recentOrders = DashboardRepository.GetRecentOrders(10);

            foreach (dynamic order in recentOrders)
            {
                // Format mã hóa đơn
                string maHoaDon = $"HD-{order.HoaDonId:D4}";

                // Format trạng thái hiển thị
                string trangThaiDisplay = FormatOrderStatus(order.TrangThai);

                dataGridViewSales.Rows.Add(
  maHoaDon,  // colMaHoaDon
       order.TenKhach,    // colKhachHang
       order.NgayLap,            // colNgayTao
      order.TongTien,     // colTongTien
         trangThaiDisplay,       // colTrangThai
      ""      // colChiTiet (link column)
                );
            }
        }

        /// <summary>
        /// Format trạng thái hóa đơn để hiển thị
        /// </summary>
        private string FormatOrderStatus(string status)
        {
            switch (status?.ToLower())
            {
                case "dathanhtoans":
                    return "Đã thanh toán";
                case "chuathanhtoans":
                    return "Chờ xử lý";
                default:
                    return status ?? "Không xác định";
            }
        }

        /// <summary>
        /// Load thống kê tổng quan (có thể hiển thị trên labels hoặc cards)
        /// </summary>
        private void LoadDashboardStats()
        {
            var stats = DashboardRepository.GetDashboardStats();
            if (stats != null)
            {
                // Hiển thị thống kê trong console hoặc trên labels (nếu có)
                System.Diagnostics.Debug.WriteLine($"Doanh thu hôm nay: {stats.DoanhThuHomNay:C}");
                System.Diagnostics.Debug.WriteLine($"Doanh thu tháng này: {stats.DoanhThuThangNay:C}");
                System.Diagnostics.Debug.WriteLine($"Đơn hàng hôm nay: {stats.DonHangHomNay}");
                System.Diagnostics.Debug.WriteLine($"Tổng sách trong kho: {stats.TongSoSach}");
                System.Diagnostics.Debug.WriteLine($"Sách sắp hết: {stats.SachSapHet}");

                // TODO: Nếu có labels trên form, cập nhật tại đây
                // lblDoanhThuHomNay.Text = stats.DoanhThuHomNay.ToString("C");
                // lblDoanhThuThang.Text = stats.DoanhThuThangNay.ToString("C");
                // lblDonHangHomNay.Text = stats.DonHangHomNay.ToString();
                // lblTongSach.Text = stats.TongSoSach.ToString();
            }
        }

        /// <summary>
        /// Fallback về mock data nếu database không khả dụng
        /// </summary>
        private void LoadMockDataFallback()
        {
            // Load mock chart data
            chartDoanhThu.Series.Clear();
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");
            seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Mock data for 7 days
            seriesDoanhThu.Points.AddXY("Ngày 1", 150000);
            seriesDoanhThu.Points.AddXY("Ngày 2", 300000);
            seriesDoanhThu.Points.AddXY("Ngày 3", 250000);
            seriesDoanhThu.Points.AddXY("Ngày 4", 400000);
            seriesDoanhThu.Points.AddXY("Ngày 5", 350000);
            seriesDoanhThu.Points.AddXY("Ngày 6", 500000);
            seriesDoanhThu.Points.AddXY("Ngày 7", 450000);

            chartDoanhThu.Series.Add(seriesDoanhThu);

            // Load mock sales data
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

        // Thêm mock data mẫu cho dataGridViewSales (fallback only)
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

        /// <summary>
        /// Refresh dữ liệu dashboard
        /// </summary>
        public void RefreshDashboard()
        {
            try
            {
                LoadRevenueChart();
                LoadRecentSales();
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu dashboard:\n{ex.Message}",
              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddBill_Click(object sender, EventArgs e)
        {

        }
    }
}
