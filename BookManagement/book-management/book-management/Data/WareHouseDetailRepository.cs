using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using book_management.Models;
using book_management.Data; // for BookRepository

namespace book_management.Data
{
    public static class WareHouseDetailRepository
    {
        public static List<ChiTietPhieuNhap> GetDetailsByPhieuNhapId(int pnId)
        {
            var list = new List<ChiTietPhieuNhap>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT ctpn.ctpn_id, ctpn.pn_id, ctpn.sach_id, ctpn.ten_sach, ctpn.so_luong, ctpn.don_gia, ctpn.thanh_tien
                        FROM ChiTietPhieuNhap ctpn
                        WHERE ctpn.pn_id = @PnId
                        ORDER BY ctpn.ctpn_id", conn);
                    cmd.Parameters.AddWithValue("@PnId", pnId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietPhieuNhap
                            {
                                CtpnId = Convert.ToInt32(reader["ctpn_id"]),
                                PnId = Convert.ToInt32(reader["pn_id"]),
                                SachId = Convert.ToInt32(reader["sach_id"]),
                                TenSach = reader["ten_sach"].ToString(),
                                SoLuong = Convert.ToInt32(reader["so_luong"]),
                                DonGia = Convert.ToDecimal(reader["don_gia"]),
                                ThanhTien = Convert.ToDecimal(reader["thanh_tien"]),
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết phiếu nhập: " + ex.Message);
            }
            return list;
        }
    }
}
