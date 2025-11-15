using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using book_management.Models;

namespace book_management.Data
{
    public class WareHouseRepository
    {
        public static PhieuNhap GetWareHouse(int phid)
        {
            PhieuNhap wareHouse = null;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy thông tin phiếu nhập
                    var cmd = new SqlCommand(@"
                        SELECT pn.pn_id, pn.ngay_nhap, pn.tong_tien, nd.ho_ten, pn.user_id
                        FROM PhieuNhap as pn
                        LEFT JOIN NguoiDung as nd ON pn.user_id = nd.user_id
                        WHERE pn.pn_id = @Phid", conn);
                    cmd.Parameters.AddWithValue("@Phid", phid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            wareHouse = new PhieuNhap
                            {
                                TenNguoiNhap = Convert.ToString(reader["ho_ten"]),
                                PnId = Convert.ToInt32(reader["pn_id"]),
                                NgayNhap = reader["ngay_nhap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ngay_nhap"]),
                                TongTien = reader["tong_tien"] == DBNull.Value ?0m : Convert.ToDecimal(reader["tong_tien"]),
                                UserId = reader["user_id"] == DBNull.Value ?0 : Convert.ToInt32(reader["user_id"])
                            };
                        }
                    }

                    if (wareHouse != null)
                    {
                        // Lấy chi tiết phiếu nhập: chỉ đọc dữ liệu trực tiếp từ bảng ChiTietPhieuNhap
                        var cmdDetails = new SqlCommand(@"
                            SELECT ctpn.ctpn_id, ctpn.pn_id, ctpn.sach_id, ctpn.so_luong, ctpn.don_gia, ctpn.thanh_tien, ctpn.ten_sach
                            FROM ChiTietPhieuNhap ctpn
                            WHERE ctpn.pn_id = @Phid
                            ORDER BY ctpn.ctpn_id", conn);
                        cmdDetails.Parameters.AddWithValue("@Phid", phid);

                        using (var reader = cmdDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var chiTiet = new ChiTietPhieuNhap
                                {
                                    CtpnId = Convert.ToInt32(reader["ctpn_id"]),
                                    PnId = Convert.ToInt32(reader["pn_id"]),
                                    SachId = Convert.ToInt32(reader["sach_id"]),
                                    SoLuong = Convert.ToInt32(reader["so_luong"]),
                                    DonGia = Convert.ToDecimal(reader["don_gia"]),
                                    ThanhTien =Convert.ToDecimal(reader["thanh_tien"]),
                                    TenSach = reader["ten_sach"].ToString()
                                };

                                // Do not populate Sach object here — keep data coming only from ChiTietPhieuNhap
                                wareHouse.ChiTietPhieuNhaps.Add(chiTiet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy kho hàng: " + ex.Message);
            }
            return wareHouse;
        }

        public static List<PhieuNhap> GetAllWareHouses()
        {
            var list = new List<PhieuNhap>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT pn.pn_id, pn.ngay_nhap, pn.tong_tien, nd.ho_ten,
                        (
                            SELECT TOP 1 n.ten_nxb
                            FROM ChiTietPhieuNhap c
                            JOIN Sach s2 ON c.sach_id = s2.sach_id
                            LEFT JOIN NhaXuatBan n ON s2.nxb_id = n.nxb_id
                            WHERE c.pn_id = pn.pn_id AND n.ten_nxb IS NOT NULL
                        ) AS ten_nxb
                        FROM PhieuNhap as pn LEFT JOIN NguoiDung as nd ON pn.user_id = nd.user_id
                        ORDER BY pn_id", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PhieuNhap
                            {
                                TenNguoiNhap = Convert.ToString(reader["ho_ten"]),
                                TenNXB = reader["ten_nxb"] == DBNull.Value ? string.Empty : reader["ten_nxb"].ToString(),
                                PnId = Convert.ToInt32(reader["pn_id"]),
                                NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách kho hàng: " + ex.Message);
            }
            return list;
        }

        // tim kiem theo ngay nhap
        public static List<PhieuNhap> SearchWareHousesByDateRange(DateTime startDate, DateTime endDate)
        {
            var list = new List<PhieuNhap>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT pn.pn_id, pn.ngay_nhap, pn.tong_tien, nd.ho_ten,
                        (
                            SELECT TOP 1 n.ten_nxb
                            FROM ChiTietPhieuNhap c
                            JOIN Sach s2 ON c.sach_id = s2.sach_id
                            LEFT JOIN NhaXuatBan n ON s2.nxb_id = n.nxb_id
                            WHERE c.pn_id = pn.pn_id AND n.ten_nxb IS NOT NULL
                        ) AS ten_nxb
                        FROM PhieuNhap as pn 
                        LEFT JOIN NguoiDung as nd ON pn.user_id = nd.user_id
                        WHERE pn.ngay_nhap BETWEEN @StartDate AND @EndDate
                        ORDER BY pn_id", conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PhieuNhap
                            {
                                TenNguoiNhap = Convert.ToString(reader["ho_ten"]),
                                PnId = Convert.ToInt32(reader["pn_id"]),
                                NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]),
                                TongTien = Convert.ToDecimal(reader["tong_tien"]),
                                TenNXB = reader["ten_nxb"] == DBNull.Value ? string.Empty : reader["ten_nxb"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm kho hàng: " + ex.Message);
            }
            return list;
        }

        // method delete ware house by id
        public static void DeleteWareHouseById(int pnId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM PhieuNhap WHERE pn_id = @PnId", conn);
                    cmd.Parameters.AddWithValue("@PnId", pnId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected ==0)
                    {
                        throw new Exception("Không tìm thấy kho hàng với ID đã cho.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa kho hàng: " + ex.Message);
            }
        }

        public static void UpdateWareHouse(PhieuNhap phieuNhap)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"UPDATE PhieuNhap SET ngay_nhap = @NgayNhap, tong_tien = @TongTien WHERE pn_id = @PnId", conn);
                    cmd.Parameters.AddWithValue("@NgayNhap", phieuNhap.NgayNhap);
                    cmd.Parameters.AddWithValue("@TongTien", phieuNhap.TongTien);
                    cmd.Parameters.AddWithValue("@PnId", phieuNhap.PnId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phiếu nhập: " + ex.Message);
            }
        }

        // Tạo phiếu nhập và chi tiết của nó trong1 transaction
        public static int CreateWareHouseWithDetails(PhieuNhap phieuNhap)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                     List<ChiTietPhieuNhap> details = phieuNhap.ChiTietPhieuNhaps;
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert header
                            var cmd = new SqlCommand(@"
                                INSERT INTO PhieuNhap (user_id, ngay_nhap, tong_tien)
                                VALUES (@UserId, @NgayNhap, @TongTien);
                                SELECT SCOPE_IDENTITY();", conn, tx);
                            cmd.Parameters.AddWithValue("@UserId", phieuNhap.UserId);
                            cmd.Parameters.AddWithValue("@NgayNhap", phieuNhap.NgayNhap);
                            cmd.Parameters.AddWithValue("@TongTien", phieuNhap.TongTien);

                            var result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không thể tạo phiếu nhập.");
                            }
                            int newPnId = Convert.ToInt32(result);

                            // Insert each detail and update stock
                            foreach (var ct in details)
                            {
                                var cmdDetail = new SqlCommand(@"
                                    INSERT INTO ChiTietPhieuNhap (pn_id, sach_id, so_luong, don_gia, ten_sach)
                                    VALUES (@PnId, @SachId, @SoLuong, @DonGia, @TenSach)", conn, tx);
                                cmdDetail.Parameters.AddWithValue("@PnId", newPnId);
                                cmdDetail.Parameters.AddWithValue("@SachId", ct.SachId);
                                cmdDetail.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                cmdDetail.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmdDetail.Parameters.AddWithValue("@TenSach", ct.TenSach);
                                int detailRows = cmdDetail.ExecuteNonQuery();
                                if (detailRows ==0)
                                {
                                    throw new Exception($"Không thể chèn chi tiết phiếu nhập cho sách ID {ct.SachId}.");
                                }

                                // Update stock for the book
                                var cmdUpdate = new SqlCommand(@"
                                    UPDATE Sach
                                    SET so_luong = ISNULL(so_luong,0) + @Qty,
                                        ngay_nhap = @NgayNhap,
                                        gia = @DonGia
                                    WHERE sach_id = @SachId", conn, tx);
                                cmdUpdate.Parameters.AddWithValue("@Qty", ct.SoLuong);
                                cmdUpdate.Parameters.AddWithValue("@NgayNhap", phieuNhap.NgayNhap);
                                cmdUpdate.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmdUpdate.Parameters.AddWithValue("@SachId", ct.SachId);
                                int updatedRows = cmdUpdate.ExecuteNonQuery();
                                if (updatedRows ==0)
                                {
                                    throw new Exception($"Không tìm thấy sách với ID {ct.SachId} để cập nhật số lượng.");
                                }
                            }

                            tx.Commit();
                            return newPnId;
                        }
                        catch (Exception)
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo phiếu nhập: " + ex.Message);
            }
        }

    }
}
