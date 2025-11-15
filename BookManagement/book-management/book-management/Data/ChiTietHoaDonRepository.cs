// book-management\Data\ChiTietHoaDonRepository.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using book_management.Data;
using book_management.Models;
namespace book_management.DataAccess
{
    public static class ChiTietHoaDonRepository
    {
        
        public static List<ChiTietHoaDon> GetChiTietByHoaDonId(int hoaDonId)
        {
            var chiTietList = new List<ChiTietHoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT 
                            cthd.ten_sach, 
                            cthd.so_luong, 
                            cthd.don_gia, 
                            cthd.tien_giam, 
                            cthd.thanh_tien
                        FROM ChiTietHoaDon cthd
                        WHERE cthd.hoadon_id = @HoaDonId", conn);
                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDonId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chiTietList.Add(new ChiTietHoaDon
                            {
                                TenSach = reader["ten_sach"].ToString(), // Lấy từ CTHD
                                SoLuong = Convert.ToInt32(reader["so_luong"]),
                                DonGia = Convert.ToDecimal(reader["don_gia"]), // Lấy từ CTHD
                                TienGiam = Convert.ToDecimal(reader["tien_giam"]),
                                ThanhTien = Convert.ToDecimal(reader["thanh_tien"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
            return chiTietList;
        }

    }
}