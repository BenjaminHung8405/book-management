// book-management\Data\ChiTietHoaDonRepository.cs
using book_management.Models;
using System.Data.SqlClient;

namespace book_management.DataAccess
{
    public static class ChiTietHoaDonRepository
    {
        public static List<ChiTietHoaDon> GetChiTietHoaDon(string maHD)
        {
            var chiTietList = new List<ChiTietHoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT ct.mahd, ct.masach, s.tensach, 
                               ct.dongia, ct.soluong, ct.thanhtien, ct.giamgia
                        FROM ChiTietHoaDon ct
                        JOIN Sach s ON ct.masach = s.masach
                        WHERE ct.mahd = @MaHD", conn);

                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chiTietList.Add(new ChiTietHoaDon
                            {
                                MaHD = reader["mahd"].ToString(),
                                MaSach = reader["masach"].ToString(),
                                TenSach = reader["tensach"].ToString(),
                                DonGia = Convert.ToDecimal(reader["dongia"]),
                                SoLuong = Convert.ToInt32(reader["soluong"]),
                                ThanhTien = Convert.ToDecimal(reader["thanhtien"]),
                                GiamGia = Convert.ToDecimal(reader["giamgia"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?y chi ti?t hóa ??n: " + ex.Message);
            }
            return chiTietList;
        }
    }
}