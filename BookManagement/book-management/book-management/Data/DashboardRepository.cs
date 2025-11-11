using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Dynamic;

namespace book_management.Data
{
    public class DashboardRepository
    {
        // Dùng cho "Hóa đơn gần đây"
        public static List<dynamic> GetRecentOrders(int top = 10)
        {
            var orders = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = $@"
                        SELECT TOP {top}
                            hd.hoadon_id,
                            CASE 
                                WHEN hd.kh_id IS NOT NULL THEN kh.ten_khach
                                WHEN hd.ten_khach_vang_lai IS NOT NULL THEN hd.ten_khach_vang_lai
                                ELSE N'Khách lẻ'
                            END as ten_khach,
                            hd.ngay_lap,
                            hd.tong_tien,
                            hd.trang_thai
                        FROM HoaDon hd
                        LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
                        ORDER BY hd.ngay_lap DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic order = new ExpandoObject();
                                order.HoaDonId = reader["hoadon_id"];
                                order.TenKhach = reader["ten_khach"]?.ToString() ?? "Khách lẻ";
                                order.NgayLap = reader["ngay_lap"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_lap"]) : DateTime.MinValue;
                                order.TongTien = reader["tong_tien"] != DBNull.Value ? Convert.ToDecimal(reader["tong_tien"]) : 0m;
                                order.TrangThai = reader["trang_thai"]?.ToString() ?? "ChuaThanhToan";
                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}", ex);
            }
            return orders;
        }

        // Dùng cho Biểu đồ
        public static List<dynamic> GetRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            var revenueData = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            CAST(hd.ngay_lap AS DATE) as ngay,
                            SUM(hd.tong_tien) as doanh_thu,
                            COUNT(hd.hoadon_id) as so_don_hang
                        FROM HoaDon hd
                        WHERE hd.trang_thai = N'DaThanhToan'
                            AND CAST(hd.ngay_lap AS DATE) BETWEEN @FromDate AND @ToDate
                        GROUP BY CAST(hd.ngay_lap AS DATE)
                        ORDER BY CAST(hd.ngay_lap AS DATE)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        command.Parameters.AddWithValue("@ToDate", toDate.Date);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic revenue = new ExpandoObject();
                                revenue.Ngay = reader["ngay"] != DBNull.Value ? Convert.ToDateTime(reader["ngay"]) : DateTime.MinValue;
                                revenue.DoanhThu = reader["doanh_thu"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu"]) : 0m;
                                revenue.SoDonHang = reader["so_don_hang"] != DBNull.Value ? Convert.ToInt32(reader["so_don_hang"]) : 0;
                                revenueData.Add(revenue);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo ngày: {ex.Message}", ex);
            }
            return revenueData;
        }

        // Dùng cho 4 thẻ thống kê
        public static dynamic GetDashboardStats()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            -- 1. Doanh thu hôm nay
                            (SELECT ISNULL(SUM(tong_tien), 0) 
                             FROM HoaDon 
                             WHERE trang_thai = N'DaThanhToan' 
                               AND CAST(ngay_lap AS DATE) = CAST(GETDATE() AS DATE)) as DoanhThuHomNay,
                            
                            -- 1b. Doanh thu hôm qua (để so sánh % tăng trưởng)
                            (SELECT ISNULL(SUM(tong_tien), 0) 
                             FROM HoaDon 
                             WHERE trang_thai = N'DaThanhToan' 
                               AND CAST(ngay_lap AS DATE) = CAST(GETDATE()-1 AS DATE)) as DoanhThuHomQua,

                            -- 2. Đơn hàng mới (hôm nay)
                            (SELECT COUNT(*) 
                             FROM HoaDon 
                             WHERE CAST(ngay_lap AS DATE) = CAST(GETDATE() AS DATE)) as DonHangMoi,
                             
                            -- 2b. Tổng đơn hàng tháng này
                            (SELECT COUNT(*) 
                             FROM HoaDon 
                             WHERE MONTH(ngay_lap) = MONTH(GETDATE()) 
                               AND YEAR(ngay_lap) = YEAR(GETDATE())) as DonHangThangNay,

                            -- 3. Sách sắp hết (Số lượng dưới 5)
                            (SELECT COUNT(*) 
                             FROM Sach 
                             WHERE trang_thai = 1 AND so_luong < 5) as SachSapHet, 
                             
                            -- 4. Khách hàng mới (hôm nay)
                            (SELECT COUNT(*) 
                             FROM KhachHang 
                             WHERE CAST(ngay_tao AS DATE) = CAST(GETDATE() AS DATE)) as KhachHangMoi";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dynamic stats = new ExpandoObject();
                                // Đọc các giá trị đã truy vấn
                                stats.DoanhThuHomNay = Convert.ToDecimal(reader["DoanhThuHomNay"]);
                                stats.DoanhThuHomQua = Convert.ToDecimal(reader["DoanhThuHomQua"]);
                                stats.DonHangMoi = Convert.ToInt32(reader["DonHangMoi"]);
                                stats.DonHangThangNay = Convert.ToInt32(reader["DonHangThangNay"]);
                                stats.SachSapHet = Convert.ToInt32(reader["SachSapHet"]);
                                stats.KhachHangMoi = Convert.ToInt32(reader["KhachHangMoi"]);

                                return stats;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê dashboard: {ex.Message}", ex);
            }
            return null;
        }

        // Dùng cho Biểu đồ
        public static List<dynamic> GetLast7DaysRevenue()
        {
            var fromDate = DateTime.Today.AddDays(-6);
            var toDate = DateTime.Today;

            var result = new List<dynamic>();
            // Tối ưu: Chỉ gọi GetRevenueByDate 1 LẦN
            List<dynamic> revenueData = GetRevenueByDate(fromDate, toDate);

            var revenueLookup = revenueData.ToDictionary(
                item => ((DateTime)item.Ngay).Date,
                item => item);

            for (int i = 0; i < 7; i++)
            {
                var currentDate = fromDate.AddDays(i).Date;
                if (revenueLookup.TryGetValue(currentDate, out dynamic existingData))
                {
                    result.Add(existingData);
                }
                else
                {
                    dynamic emptyData = new ExpandoObject();
                    emptyData.Ngay = currentDate;
                    emptyData.DoanhThu = 0m;
                    emptyData.SoDonHang = 0;
                    result.Add(emptyData);
                }
            }
            return result;
        }
        // dùng nó ở trang Thống kê (ReportControl).
        public static List<dynamic> GetTopSellingBooks(int top = 5)
        {
            var topBooks = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = $@"
                    SELECT TOP {top}
                    s.sach_id,
                    s.ten_sach,
                    SUM(cthd.so_luong) as tong_ban,
                    SUM(cthd.thanh_tien) as doanh_thu,
                    STUFF((
                    SELECT ', ' + tg.ten_tacgia
                    FROM Sach_TacGia st
                    INNER JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
                    WHERE st.sach_id = s.sach_id     
                    FOR XML PATH('')), 1, 2, '') AS tac_gia
                    FROM Sach s
                    INNER JOIN ChiTietHoaDon cthd ON s.sach_id = cthd.sach_id
                    INNER JOIN HoaDon hd ON cthd.hoadon_id = hd.hoadon_id
                    WHERE hd.trang_thai = N'DaThanhToan'
                    GROUP BY s.sach_id, s.ten_sach
                    ORDER BY SUM(cthd.so_luong) DESC";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic book = new System.Dynamic.ExpandoObject();
                                book.SachId = reader["sach_id"];
                                book.TenSach = reader["ten_sach"]?.ToString() ?? "";
                                book.TongBan = reader["tong_ban"] != DBNull.Value ? Convert.ToInt32(reader["tong_ban"]) : 0;
                                book.DoanhThu = reader["doanh_thu"] != DBNull.Value ? Convert.ToDecimal(reader["doanh_thu"]) : 0m;
                                book.TacGia = reader["tac_gia"]?.ToString() ?? "";
                                topBooks.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy top sách bán chạy: {ex.Message}", ex);
            }
            return topBooks;
        }
    }
}