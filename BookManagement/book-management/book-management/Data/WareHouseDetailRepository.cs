using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using book_management.Models;

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
                        SELECT ctpn.ctpn_id, ctpn.pn_id, ctpn.sach_id, s.ten_sach, s.nxb_id, n.ten_nxb, ctpn.so_luong, ctpn.don_gia, ctpn.thanh_tien
                        FROM ChiTietPhieuNhap ctpn
                        JOIN Sach s ON ctpn.sach_id = s.sach_id
                        LEFT JOIN NhaXuatBan n ON s.nxb_id = n.nxb_id
                        WHERE ctpn.pn_id = @PnId
                        ORDER BY ctpn.ctpn_id", conn);
                    cmd.Parameters.AddWithValue("@PnId", pnId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sachId = Convert.ToInt32(reader["sach_id"]);
                            var tenSach = reader["ten_sach"]?.ToString() ?? string.Empty;

                            int? nxbId = null;
                            string tenNxb = null;
                            if (reader["nxb_id"] != DBNull.Value)
                            {
                                nxbId = Convert.ToInt32(reader["nxb_id"]);
                                tenNxb = reader["ten_nxb"]?.ToString();
                            }

                            list.Add(new ChiTietPhieuNhap
                            {
                                CtpnId = Convert.ToInt32(reader["ctpn_id"]),
                                PnId = Convert.ToInt32(reader["pn_id"]),
                                SachId = sachId,
                                SoLuong = Convert.ToInt32(reader["so_luong"]),
                                DonGia = Convert.ToDecimal(reader["don_gia"]),
                                ThanhTien = Convert.ToDecimal(reader["thanh_tien"]),
                                Sach = new Sach
                                {
                                    SachId = sachId,
                                    TenSach = tenSach,
                                    NxbId = nxbId ?? 0,
                                    NhaXuatBan = nxbId.HasValue ? new NhaXuatBan { NxbId = nxbId.Value, TenNxb = tenNxb } : null
                                }
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
