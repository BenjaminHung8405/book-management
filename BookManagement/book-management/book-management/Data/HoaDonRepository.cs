using book_management.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using book_management.Data;
using System;
using System.Text;

namespace book_management.DataAccess
{
    public static class HoaDonRepository
    {
        private static string RemoveAccents(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string normalized = input.Normalize(System.Text.NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

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

        // === HÀM TÌM KIẾM ===
        public static List<HoaDon> SearchInvoices(string searchTerm, string status, DateTime? fromDate, DateTime? toDate)
        {
            var list = new List<HoaDon>();
            string searchTermNoAccent = null;
            try
            {
                //using đảm bảo conn.Dispose() gọi khi rời scope(đóng kết nối tự động)
                using (var conn = DatabaseConnection.GetConnection())
                {
                    //ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) AS ten_nguoi_mua — nếu có khách hàng(KhachHang) thì dùng ten_khach,
                    //nếu không(khách vãng lai) dùng ten_khach_vang_lai từ bảng HoaDon.
                    conn.Open();
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
                        WHERE 1=1";
                    if (fromDate.HasValue)
                    {
                        query += " AND hd.ngay_lap >= @FromDate";
                    }
                    if (toDate.HasValue)
                    {
                        query += " AND hd.ngay_lap < @ToDate";
                    }
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        // Chuẩn hóa searchTerm thành không dấu để tìm kiếm tốt hơn
                        searchTermNoAccent = RemoveAccents(searchTerm);

                        // nối thêm điều kiện - tìm kiếm cả có dấu và không dấu
                        query += @" AND (CAST(hd.hoadon_id AS VARCHAR) LIKE @SearchTerm 
                            OR ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) COLLATE Latin1_General_CI_AI LIKE @SearchTerm
                            OR nd.ho_ten COLLATE Latin1_General_CI_AI LIKE @SearchTerm
                            OR ISNULL(kh.ten_khach, hd.ten_khach_vang_lai) COLLATE Latin1_General_CI_AI LIKE @SearchTermNoAccent
                            OR nd.ho_ten COLLATE Latin1_General_CI_AI LIKE @SearchTermNoAccent)";
                    }

                    // Trim status once and decide whether to apply filter
                    status = status?.Trim();
                    bool applyStatusFilter = !string.IsNullOrWhiteSpace(status)
                     && !status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase)
                     && !status.Equals("TatCa", StringComparison.OrdinalIgnoreCase);

                    // Declare these here so they are in scope both when building the query and when binding parameters
                    string statusCode = null;
                    string statusDisplay = null;
                    string statusRaw = status;

                    if (applyStatusFilter)
                    {
                        // Map known code <-> display variants so both DB storage styles are supported

                        if (status.Equals("DaThanhToan", StringComparison.OrdinalIgnoreCase) || status.IndexOf("dathanhtoan", StringComparison.OrdinalIgnoreCase) >= 0 || status.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                        {
                            statusCode = "DaThanhToan";
                            statusDisplay = "Đã thanh toán";
                        }
                        else if (status.Equals("ChuaThanhToan", StringComparison.OrdinalIgnoreCase) || status.IndexOf("chuathanhtoan", StringComparison.OrdinalIgnoreCase) >= 0 || status.Equals("Chưa thanh toán", StringComparison.OrdinalIgnoreCase))
                        {
                            statusCode = "ChuaThanhToan";
                            statusDisplay = "Chưa thanh toán";
                        }
                        else if (status.Equals("DaHuy", StringComparison.OrdinalIgnoreCase) || status.IndexOf("dahuy", StringComparison.OrdinalIgnoreCase) >= 0 || status.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase))
                        {
                            statusCode = "DaHuy";
                            statusDisplay = "Đã hủy";
                        }
                        else
                        {
                            statusCode = statusRaw;
                            statusDisplay = statusRaw;
                        }
                        // Use accent-insensitive comparison by using database default collation on both sides.
                        query += " AND (LTRIM(RTRIM(hd.trang_thai)) COLLATE DATABASE_DEFAULT = LTRIM(RTRIM(@StatusCode)) COLLATE DATABASE_DEFAULT";
                        query += " OR LTRIM(RTRIM(hd.trang_thai)) COLLATE DATABASE_DEFAULT = LTRIM(RTRIM(@StatusDisplay)) COLLATE DATABASE_DEFAULT";
                        query += " OR LTRIM(RTRIM(hd.trang_thai)) COLLATE DATABASE_DEFAULT = LTRIM(RTRIM(@StatusRaw)) COLLATE DATABASE_DEFAULT)";
                    }

                    query += " ORDER BY hd.ngay_lap DESC";

                    var cmd = new SqlCommand(query, conn);

                    // Debug: log query and status info to Output window
                    try
                    {
                        string debugSearchTermNoAccent = string.IsNullOrWhiteSpace(searchTerm) ? "" : searchTermNoAccent;
                        System.Diagnostics.Debug.WriteLine($"[HoaDonRepository.SearchInvoices] From={fromDate}, To={toDate}, SearchTerm='{searchTerm}', SearchTermNoAccent='{debugSearchTermNoAccent}', StatusPassed='{status}', ApplyStatusFilter={applyStatusFilter}");
                        System.Diagnostics.Debug.WriteLine($"[HoaDonRepository.SearchInvoices] SQL={query}");
                    }
                    catch { }

                    // Ensure date parameters are DateTime (no string c onversions)
                    if (fromDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Value);
                    }
                    if (toDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        cmd.Parameters.AddWithValue("@SearchTermNoAccent", "%" + searchTermNoAccent + "%");
                    }

                    if (applyStatusFilter)
                    {
                        // Bind the three mapped status variants used in the query
                        var pCode = new SqlParameter("@StatusCode", System.Data.SqlDbType.NVarChar, 200) { Value = (object)statusCode ?? DBNull.Value };
                        var pDisplay = new SqlParameter("@StatusDisplay", System.Data.SqlDbType.NVarChar, 200) { Value = (object)statusDisplay ?? DBNull.Value };
                        var pRaw = new SqlParameter("@StatusRaw", System.Data.SqlDbType.NVarChar, 200) { Value = (object)statusRaw ?? DBNull.Value };
                        cmd.Parameters.Add(pCode);
                        cmd.Parameters.Add(pDisplay);
                        cmd.Parameters.Add(pRaw);
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

        public static HoaDon GetInvoiceById(int hoaDonId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
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
                                NguoiLap = reader["nguoi_lap"]?.ToString() ?? "",

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
        public static bool CreateInvoice(HoaDon hoaDon, List<ChiTietHoaDon> details)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // bat dau 1 giao dịch
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    //tao hoa don va lay id vua tao
                    var cmdHoaDon = new SqlCommand(@"
                        INSERT INTO HoaDon (user_id, kh_id, ten_khach_vang_lai, tong_tien, trang_thai)
                        VALUES (@UserId, @KhId, @TenKhachVangLai, @TongTien, @TrangThai);
                        SELECT SCOPE_IDENTITY();", conn, transaction);// lay id vua tao
                    cmdHoaDon.Parameters.AddWithValue("@UserId", (object)hoaDon.UserId ?? DBNull.Value);
                    cmdHoaDon.Parameters.AddWithValue("@KhId", (object)hoaDon.KhId ?? DBNull.Value);
                    cmdHoaDon.Parameters.AddWithValue("@TenKhachVangLai", (object)hoaDon.TenNguoiMua ?? DBNull.Value);
                    cmdHoaDon.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    cmdHoaDon.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai);
                    // Thực thi và lấy ID mới
                    int newHoaDonId = Convert.ToInt32(cmdHoaDon.ExecuteScalar());

                    // Tao cac dong chiTiet hoa don    
                    foreach (var item in details)
                    {
                        // 'thanh_tien' may be a computed column in the database (don_gia * so_luong - tien_giam).
                        // Do not attempt to insert into it. Insert don_gia, so_luong, tien_giam and optional khuyenmai_id.
                        var cmdChiTiet = new SqlCommand(@"
                            INSERT INTO ChiTietHoaDon (hoadon_id, sach_id, so_luong, don_gia, khuyenmai_id, tien_giam)
                            VALUES (@HoaDonId, @SachId, @SoLuong, @DonGia, @KhuyenMaiId, @TienGiam);", conn, transaction);
                        cmdChiTiet.Parameters.AddWithValue("@HoaDonId", newHoaDonId);
                        cmdChiTiet.Parameters.AddWithValue("@SachId", item.SachId);
                        cmdChiTiet.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdChiTiet.Parameters.AddWithValue("@DonGia", item.DonGia);
                        cmdChiTiet.Parameters.AddWithValue("@KhuyenMaiId", (object)item.KhuyenMaiId ?? DBNull.Value);
                        cmdChiTiet.Parameters.AddWithValue("@TienGiam", item.TienGiam);
                        cmdChiTiet.ExecuteNonQuery();
                        // tru so luong sach trong kho
                        var cmdUpdateStock = new SqlCommand(@"
                            UPDATE Sach
                            SET so_luong = so_luong - @SoLuong
                            WHERE sach_id = @SachId;", conn, transaction);
                        cmdUpdateStock.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdUpdateStock.Parameters.AddWithValue("@SachId", item.SachId);
                        // tru ton kho
                        cmdUpdateStock.ExecuteNonQuery();
                    }
                    // neu ko co loi thi commit
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // nếu có lỗi thì rollback
                    transaction.Rollback();
                    throw new Exception("Lỗi khi tạo hóa đơn: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Tìm kh_id mặc định cho user dựa trên hóa đơn gần nhất
        /// </summary>
        /// <param name="userId">ID của user</param>
        /// <returns>kh_id nếu tìm thấy, 0 nếu không tìm thấy</returns>
        public static int GetDefaultKhIdForUser(int userId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Tìm kh_id từ hóa đơn gần nhất của user này
                    var cmd = new SqlCommand(@"
                      SELECT TOP 1 kh_id 
                      FROM HoaDon 
                      WHERE user_id = @UserId 
                      AND kh_id IS NOT NULL 
                      ORDER BY ngay_lap DESC", conn);

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết, nhưng không throw exception
                // vì đây là hàm hỗ trợ, không nên làm crash ứng dụng
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tìm kh_id mặc định: {ex.Message}");
            }

            return 0; // Trả về 0 nếu không tìm thấy hoặc có lỗi
        }

        /// <summary>
        /// Cập nhật thông tin hóa đơn
        /// </summary>
        /// <param name="hoaDon">Thông tin hóa đơn cần cập nhật</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        public static bool UpdateInvoice(HoaDon hoaDon)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        UPDATE HoaDon 
                        SET ngay_lap = @NgayLap,
                        ten_khach_vang_lai = @TenKhachVangLai,
                        tong_tien = @TongTien,
                        trang_thai = @TrangThai
                        WHERE hoadon_id = @HoaDonId", conn);

                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDon.HoaDonId);
                    cmd.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                    cmd.Parameters.AddWithValue("@TenKhachVangLai", (object)hoaDon.TenNguoiMua ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    cmd.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
        }

        public static bool UpdateInvoiceStatus(int hoaDonId, int trangThai)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Map internal integer codes to database string values
                    // DB CHECK constraint expects textual values like 'DaThanhToan', 'ChuaThanhToan', 'DaHuy'
                    string trangThaiDb;
                    switch (trangThai)
                    {
                        case 1:
                            trangThaiDb = "DaThanhToan"; // Đã thanh toán
                            break;
                        case 0:
                            trangThaiDb = "ChuaThanhToan"; // Chưa thanh toán
                            break;
                        case 2:
                            trangThaiDb = "DaHuy"; // Đã hủy
                            break;
                        default:
                            throw new ArgumentException("Giá trị trạng thái không hợp lệ: " + trangThai);
                    }

                    var cmd = new SqlCommand(@"
                        UPDATE HoaDon 
                        SET trang_thai = @TrangThai
                        WHERE hoadon_id = @HoaDonId", conn);

                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDonId);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiDb);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException sqlEx)
                    {
                        // If the update failed due to a CHECK constraint on trang_thai, try accented variants and retry once
                        if (sqlEx.Message != null && sqlEx.Message.IndexOf("CHECK constraint", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            // Prepare accented candidates
                            string retryTrangThai = trangThaiDb;
                            if (trangThai == 1) retryTrangThai = "Đã thanh toán";
                            else if (trangThai == 0) retryTrangThai = "Chưa thanh toán";
                            else if (trangThai == 2) retryTrangThai = "Đã hủy";

                            // Retry update with accented value
                            cmd.Parameters["@TrangThai"].Value = retryTrangThai;
                            int retryRows = cmd.ExecuteNonQuery();
                            return retryRows > 0;
                        }

                        throw; // rethrow if not a CHECK constraint issue
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái hóa đơn: " + ex.Message);
            }
        }
    }
}