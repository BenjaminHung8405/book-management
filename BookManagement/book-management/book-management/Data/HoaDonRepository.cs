using book_management.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using book_management.Data;
using System;

namespace book_management.DataAccess
{
    public static class HoaDonRepository
    {
        // Hàm này của bạn đã đúng (giữ nguyên)
        public static List<HoaDon> GetHoaDonsByUserId(int userId)
        {
            var list = new List<HoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT hd.hoadon_id, hd.ngay_lap, hd.tong_tien, hd.trang_thai,
                               ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) AS ten_nguoi_mua
                        FROM HoaDon hd
                        LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
                        WHERE hd.user_id = @UserId
                        ORDER BY hd.ngay_lap DESC", conn);

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDon
                            {
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                NgayLap = Convert.ToDateTime(reader["ngay_lap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                                TrangThai = reader["trang_thai"].ToString(),
                                TenNguoiMua = reader["ten_nguoi_mua"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
            return list;
        }

        // Hàm này của bạn đã đúng (giữ nguyên)
        public static List<HoaDon> GetAllInvoices()
        {
            var list = new List<HoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT 
                            hd.hoadon_id, 
                            hd.ngay_lap, 
                            hd.tong_tien, 
                            hd.trang_thai,
                            ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) AS ten_nguoi_mua,
                            nd.ho_ten AS nguoi_lap 
                        FROM HoaDon hd
                        LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
                        LEFT JOIN NguoiDung nd ON hd.user_id = nd.user_id
                        ORDER BY hd.ngay_lap DESC", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDon
                            {
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                NgayLap = Convert.ToDateTime(reader["ngay_lap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                                TrangThai = reader["trang_thai"].ToString(),
                                TenNguoiMua = reader["ten_nguoi_mua"]?.ToString() ?? "",
                                NguoiLap = reader["nguoi_lap"]?.ToString() ?? "",
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả hóa đơn: " + ex.Message);
            }
            return list;
        }

        // === SỬA HÀM TÌM KIẾM NÀY ===
        public static List<HoaDon> SearchInvoices(string searchTerm, string status, DateTime fromDate, DateTime toDate)
        {
            var list = new List<HoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // SỬA SQL: Thêm 'nguoi_lap' và JOIN NguoiDung
                    var query = @"
                        SELECT 
                            hd.hoadon_id, 
                            hd.ngay_lap, 
                            hd.tong_tien, 
                            hd.trang_thai,
                            ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) AS ten_nguoi_mua,
                            nd.ho_ten AS nguoi_lap
                        FROM HoaDon hd
                        LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
                        LEFT JOIN NguoiDung nd ON hd.user_id = nd.user_id
                        WHERE hd.ngay_lap >= @FromDate AND hd.ngay_lap < @ToDate";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        // SỬA SQL: Thêm tìm kiếm theo nd.ho_ten (nguoi_lap)
                        query += @" AND (CAST(hd.hoadon_id AS VARCHAR) LIKE @SearchTerm 
                                    OR ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) LIKE @SearchTerm
                                    OR nd.ho_ten LIKE @SearchTerm)";
                    }

                    if (!string.IsNullOrEmpty(status) && status != "Tất cả")
                    {
                        query += " AND hd.trang_thai = @Status";
                    }

                    query += " ORDER BY hd.ngay_lap DESC";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    if (!string.IsNullOrEmpty(status) && status != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDon
                            {
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                NgayLap = Convert.ToDateTime(reader["ngay_lap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                                TrangThai = reader["trang_thai"].ToString(),
                                TenNguoiMua = reader["ten_nguoi_mua"]?.ToString() ?? "",

                                // Dòng này bây giờ đã an toàn vì SQL đã SELECT 'nguoi_lap'
                                NguoiLap = reader["nguoi_lap"]?.ToString() ?? "",
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
            return list;
        }

        // Hàm này của bạn đã đúng (giữ nguyên)
        public static bool DeleteInvoice(int hoaDonId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdDeleteDetails = new SqlCommand(@"
                            DELETE FROM ChiTietHoaDon WHERE hoadon_id = @HoaDonId", conn, transaction);
                        cmdDeleteDetails.Parameters.AddWithValue("@HoaDonId", hoaDonId);
                        cmdDeleteDetails.ExecuteNonQuery();

                        var cmdDeleteInvoice = new SqlCommand(@"
                            DELETE FROM HoaDon WHERE hoadon_id = @HoaDonId", conn, transaction);
                        cmdDeleteInvoice.Parameters.AddWithValue("@HoaDonId", hoaDonId);

                        var result = cmdDeleteInvoice.ExecuteNonQuery() > 0;
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // === SỬA HÀM GetInvoiceById ===
        public static HoaDon GetInvoiceById(int hoaDonId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // SỬA SQL: Thêm 'nguoi_lap' và JOIN NguoiDung
                    var cmd = new SqlCommand(@"
                        SELECT 
                            hd.hoadon_id, hd.ngay_lap, hd.tong_tien, hd.trang_thai,
                            hd.user_id,
                            ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) AS ten_nguoi_mua,
                            nd.ho_ten AS nguoi_lap
                        FROM HoaDon hd
                        LEFT JOIN KhachHang kh ON hd.kh_id = kh.kh_id
                        LEFT JOIN NguoiDung nd ON hd.user_id = nd.user_id
                        WHERE hd.hoadon_id = @HoaDonId", conn);

                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDonId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HoaDon
                            {
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                NgayLap = Convert.ToDateTime(reader["ngay_lap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                                TrangThai = reader["trang_thai"].ToString(),
                                TenNguoiMua = reader["ten_nguoi_mua"]?.ToString() ?? "",

                                // Dòng này bây giờ đã an toàn
                                NguoiLap = reader["nguoi_lap"]?.ToString() ?? "",

                                // SỬA LỖI: Cột user_id có thể là NULL, cần kiểm tra DBNull
                                UserId = (int)(reader["user_id"] != DBNull.Value ? Convert.ToInt32(reader["user_id"]) : (int?)null)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
            }
            return null;
        }
    }
}