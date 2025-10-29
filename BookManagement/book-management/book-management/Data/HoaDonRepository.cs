// book-management\Data\HoaDonRepository.cs
using book_management.Models;
using System.Data.SqlClient;

namespace book_management.DataAccess
{
    public static class HoaDonRepository
    {
        public static List<HoaDon> GetHoaDonsByKhachHang(int userId)
        {
            var hoaDons = new List<HoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT hd.mahd, hd.ngaylap, hd.tongtien, hd.trangthai, 
                               hd.nguoilap, hd.ghichu
                        FROM HoaDon hd
                        WHERE hd.user_id = @UserId
                        ORDER BY hd.ngaylap DESC", conn);

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hoaDons.Add(new HoaDon
                            {
                                MaHD = reader["mahd"].ToString(),
                                NgayLap = Convert.ToDateTime(reader["ngaylap"]),
                                TongTien = Convert.ToDecimal(reader["tongtien"]),
                                TrangThai = reader["trangthai"].ToString(),
                                NguoiLap = reader["nguoilap"].ToString(),
                                GhiChu = reader["ghichu"]?.ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?y danh sách hóa ??n: " + ex.Message);
            }
            return hoaDons;
        }
    }
}