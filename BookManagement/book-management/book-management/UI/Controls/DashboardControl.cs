using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using book_management.Data; // Thư viện cho DashboardRepository
using book_management.DataAccess; // Thư viện cho ChiTietHoaDonRepository
using book_management.Models;
using book_management.UI.Modal; // Thư viện cho Model ChiTietHoaDon

namespace book_management.UI.Controls
{
    public partial class DashboardControl : System.Windows.Forms.UserControl
    {
        public event EventHandler CreateInvoiceClicked;
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            try
            {
                // Load dữ liệu
                LoadRevenueChart();
                StyleDataGridView();
                LoadRecentSales();
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu dashboard:\n{ex.Message}",
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadMockDataFallback();
            }
        }

        /// <summary>
        /// Load thống kê tổng quan vào 4 thẻ
        /// </summary>
        private void LoadDashboardStats()
        {
            var stats = DashboardRepository.GetDashboardStats();
            if (stats != null)
            {
                // 1. Thẻ Doanh thu hôm nay
                lblTodayRevenueValue.Text = stats.DoanhThuHomNay.ToString("N0") + " đ";

                // Tính % tăng trưởng
                decimal revenueToday = stats.DoanhThuHomNay;
                decimal revenueYesterday = stats.DoanhThuHomQua;
                double percentageChange = 0;
                if (revenueYesterday > 0)
                {
                    percentageChange = (double)((revenueToday - revenueYesterday) / revenueYesterday) * 100;
                }
                else if (revenueToday > 0)
                {
                    percentageChange = 100; // Tăng 100% nếu hôm qua là 0
                }

                if (percentageChange > 0)
                {
                    lblRevenueComparison.Text = $"+{percentageChange:F1}% so với hôm qua";
                    lblRevenueComparison.ForeColor = Color.Green;
                }
                else
                {
                    lblRevenueComparison.Text = $"{percentageChange:F1}% so với hôm qua";
                    lblRevenueComparison.ForeColor = Color.Red;
                }

                // 2. Thẻ Đơn hàng mới
                lblNewOrdersValue.Text = stats.DonHangMoi.ToString();
                lblMonthlyOrdersTotal.Text = $"Tổng {stats.DonHangThangNay} đơn tháng này";

                // 3. Thẻ Sách sắp hết
                lblLowStockValue.Text = stats.SachSapHet.ToString();

                // 4. Thẻ Khách hàng mới
                lblNewCustomersValue.Text = stats.KhachHangMoi.ToString();
            }
        }

        /// <summary>
        /// Format trạng thái hóa đơn để hiển thị
        /// </summary>
        private string FormatOrderStatus(string status)
        {
            switch (status?.ToLower())
            {
                case "dathanhtoan":
                    return "Đã thanh toán";
                case "chuathanhtoan":
                    return "Chờ xử lý";
                default:
                    return status ?? "Không xác định";
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào link "Xem" (colChiTiet)
        /// </summary>
        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.dataGridViewSales.Columns[e.ColumnIndex].Name == "colChiTiet")
            {
                try
                {
                    // Lấy ID hóa đơn từ cột "colMaHoaDon"
                    // Cần parse lại ID (loại bỏ "HD-")
                    string maHoaDonText = this.dataGridViewSales.Rows[e.RowIndex].Cells["colMaHoaDon"].Value.ToString();
                    int hoaDonId = int.Parse(maHoaDonText.Replace("HD-", ""));

                    // G gọi Repository để lấy Chi Tiết Hóa Đơn
                    List<ChiTietHoaDon> chiTietHD = ChiTietHoaDonRepository.GetChiTietHoaDon(hoaDonId);

                    // Mở form chi tiết và truyền dữ liệu vào
                    OrderDetailForm frmDetail = new OrderDetailForm(chiTietHD);
                    frmDetail.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Load biểu đồ doanh thu từ database (7 ngày gần nhất)
        /// </summary>
        private void LoadRevenueChart()
        {
            chartDoanhThu.Series.Clear();
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");
            seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            var revenueData = DashboardRepository.GetLast7DaysRevenue();
            foreach (dynamic revenue in revenueData)
            {
                DateTime date = revenue.Ngay;
                decimal amount = revenue.DoanhThu;
                string dateLabel = date.ToString("dd/MM");
                seriesDoanhThu.Points.AddXY(dateLabel, (double)amount);
            }
            chartDoanhThu.Series.Add(seriesDoanhThu);
            ConfigureChart();
        }

        /// <summary>
        /// Cấu hình chart để hiển thị đẹp hơn
        /// </summary>
        private void ConfigureChart()
        {
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            chartDoanhThu.Series[0].Color = Color.FromArgb(74, 144, 226);
            chartDoanhThu.Series[0].BorderWidth = 3;
            chartDoanhThu.Series[0].IsValueShownAsLabel = true;
            chartDoanhThu.Series[0].LabelFormat = "C0";
        }

        /// <summary>
        /// Load dữ liệu hóa đơn gần đây từ database
        /// </summary>
        private void LoadRecentSales()
        {
            if (dataGridViewSales.DataSource != null) return;
            dataGridViewSales.Rows.Clear();
            var recentOrders = DashboardRepository.GetRecentOrders(10);
            foreach (dynamic order in recentOrders)
            {
                string maHoaDon = $"HD-{order.HoaDonId:D4}";
                string trangThaiDisplay = FormatOrderStatus(order.TrangThai);
                dataGridViewSales.Rows.Add(
                    maHoaDon,
                    order.TenKhach,
                    order.NgayLap,
                    order.TongTien,
                    trangThaiDisplay,
                    "" // Giá trị cho cột colChiTiet (link)
                );
            }
        }

        /// <summary>
        /// Fallback về mock data nếu database không khả dụng
        /// </summary>
        private void LoadMockDataFallback()
        {
            chartDoanhThu.Series.Clear();
            var seriesDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");
            seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesDoanhThu.Points.AddXY("Ngày 1", 150000);
            seriesDoanhThu.Points.AddXY("Ngày 2", 300000);
            seriesDoanhThu.Points.AddXY("Ngày 3", 250000);
            seriesDoanhThu.Points.AddXY("Ngày 4", 400000);
            seriesDoanhThu.Points.AddXY("Ngày 5", 350000);
            seriesDoanhThu.Points.AddXY("Ngày 6", 500000);
            seriesDoanhThu.Points.AddXY("Ngày 7", 450000);
            chartDoanhThu.Series.Add(seriesDoanhThu);
            PopulateMockSales();
        }

        /// <summary>
        /// Định dạng giao diện cho DataGridView
        /// </summary>
        private void StyleDataGridView()
        {
            var headerStyle = dataGridViewSales.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(249, 250, 251);
            headerStyle.ForeColor = Color.FromArgb(55, 65, 81);
            headerStyle.Font = new Font("Inter", 9F, FontStyle.Bold);
            headerStyle.Padding = new Padding(10, 8, 10, 8);
            dataGridViewSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewSales.ColumnHeadersHeight = 45;
            var cellStyle = dataGridViewSales.DefaultCellStyle;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Inter", 9F, FontStyle.Regular);
            cellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            cellStyle.Padding = new Padding(10, 0, 10, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            cellStyle.SelectionForeColor = Color.Black;
            dataGridViewSales.RowTemplate.Height = 45;
        }

        /// <summary>
        /// Thêm mock data mẫu cho dataGridViewSales (chỉ dùng khi fallback)
        /// </summary>
        private void PopulateMockSales()
        {
            if (dataGridViewSales.DataSource != null) return;
            dataGridViewSales.Rows.Clear();
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
                dataGridViewSales.Rows.Add(
                    mockRows[i, 0],
                    mockRows[i, 1],
                    mockRows[i, 2],
                    mockRows[i, 3],
                    mockRows[i, 4],
                    mockRows[i, 5]
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

        /// <summary>
        /// Định dạng màu sắc cho ô Trạng Thái
        /// </summary>
        private void dataGridViewSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewSales.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                        e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    else if (status.Equals("Chờ xử lý", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                        e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);
                    }
                    else if (status.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                        e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                    }
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Lấy giá trị doanh thu hôm nay
        /// </summary>
        private int TodayRevenueValue()
        {
            var stats = DashboardRepository.GetDashboardStats();
            return stats != null ? (int)stats.DoanhThuHomNay : 0;
        }

        /// <summary>
        /// Xử lý sự kiện click nút Tạo Hóa Đơn Mới (Tác vụ nhanh)
        /// </summary>
        private void btnAddBill_Click(object sender, EventArgs e)
        {
            //CreateInvoiceClicked?.Invoke(this, EventArgs.Empty);

        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBook frmAddBook = new frmAddEditBook();
                if (frmAddBook.ShowDialog() == DialogResult.OK)
                {
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm sách:\n{ex.Message}", 
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditUser frmAddBook = new frmAddEditUser();
                if (frmAddBook.ShowDialog() == DialogResult.OK)
                {
                    RefreshDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm khách hàng:\n{ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}