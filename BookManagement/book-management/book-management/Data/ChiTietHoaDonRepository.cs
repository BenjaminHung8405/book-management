// book-management\Data\ChiTietHoaDonRepository.cs
using book_management.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using book_management.Data;
using System;
namespace book_management.DataAccess
{
    public static class ChiTietHoaDonRepository
    {
        public static List<ChiTietHoaDon> GetChiTietHoaDon(int hoaDonId)
        {
            var chiTietList = new List<ChiTietHoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT ct.hoadon_id, ct.sach_id, s.ten_sach, 
                               ct.don_gia, ct.so_luong, ct.thanh_tien, ct.tien_giam
                        FROM ChiTietHoaDon ct
                        JOIN Sach s ON ct.sach_id = s.sach_id
                        WHERE ct.hoadon_id = @HoaDonId", conn); 
                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDonId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chiTietList.Add(new ChiTietHoaDon
                            {
                              
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                SachId = Convert.ToInt32(reader["sach_id"]),
                                TenSach = reader["ten_sach"].ToString(),

                                DonGia = Convert.ToDecimal(reader["don_gia"]),
                                SoLuong = Convert.ToInt32(reader["so_luong"]),
                                ThanhTien = Convert.ToDecimal(reader["thanh_tien"]),

                                TienGiam = Convert.ToDecimal(reader["tien_giam"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn " + ex.Message);
            }
            return chiTietList;
        }
        public static List<ChiTietHoaDon> GetChiTietByHoaDonId(int hoaDonId)
        {
            var chiTietList = new List<ChiTietHoaDon>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT ct.cthd_id, ct.hoadon_id, ct.sach_id, s.ten_sach, 
                        ct.so_luong, ct.don_gia, 
                        ISNULL(ct.khuyenmai_id, 0) as khuyenmai_id,
                        ISNULL(ct.tien_giam, 0) as tien_giam, 
                        ct.thanh_tien
                        FROM ChiTietHoaDon ct
                        JOIN Sach s ON ct.sach_id = s.sach_id
                        WHERE ct.hoadon_id = @HoaDonId
                        ORDER BY ct.cthd_id", conn);

                    cmd.Parameters.AddWithValue("@HoaDonId", hoaDonId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chiTietList.Add(new ChiTietHoaDon
                            {
                                CthdId = Convert.ToInt32(reader["cthd_id"]),
                                HoaDonId = Convert.ToInt32(reader["hoadon_id"]),
                                SachId = Convert.ToInt32(reader["sach_id"]),
                                TenSach = reader["ten_sach"].ToString(),
                                SoLuong = Convert.ToInt32(reader["so_luong"]),
                                DonGia = Convert.ToDecimal(reader["don_gia"]),
                                KhuyenMaiId = reader["khuyenmai_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["khuyenmai_id"]),
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