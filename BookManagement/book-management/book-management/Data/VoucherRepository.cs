using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_management.Data;
using book_management.Models;

namespace book_management.DataAccess
{
    public static class VoucherRepository
    {
        /// <summary>
        /// Lấy tất cả Khuyến mãi (Voucher)
        /// </summary>
        public static List<KhuyenMai> GetAllVouchers()
        {
            var list = new List<KhuyenMai>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT km_id, ten_km, mo_ta, phan_tram_giam, ngay_bat_dau, ngay_ket_thuc
                        FROM KhuyenMai
                        ORDER BY ngay_bat_dau DESC", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KhuyenMai
                            {
                                KmId = Convert.ToInt32(reader["km_id"]),
                                TenKm = reader["ten_km"].ToString(),
                                MoTa = reader["mo_ta"] != DBNull.Value ? reader["mo_ta"].ToString() : "",
                                PhanTramGiam = Convert.ToDecimal(reader["phan_tram_giam"]),
                                NgayBatDau = Convert.ToDateTime(reader["ngay_bat_dau"]),
                                NgayKetThuc = Convert.ToDateTime(reader["ngay_ket_thuc"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khuyến mãi: " + ex.Message);
            }
            return list;
        }

        /// <summary>
        /// Lấy khuyến mãi theo ID
        /// </summary>
        public static KhuyenMai GetVoucherById(int kmId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT km_id, ten_km, mo_ta, phan_tram_giam, ngay_bat_dau, ngay_ket_thuc
                        FROM KhuyenMai
                        WHERE km_id = @km_id", conn);

                    cmd.Parameters.AddWithValue("@km_id", kmId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhuyenMai
                            {
                                KmId = Convert.ToInt32(reader["km_id"]),
                                TenKm = reader["ten_km"].ToString(),
                                MoTa = reader["mo_ta"] != DBNull.Value ? reader["mo_ta"].ToString() : "",
                                PhanTramGiam = Convert.ToDecimal(reader["phan_tram_giam"]),
                                NgayBatDau = Convert.ToDateTime(reader["ngay_bat_dau"]),
                                NgayKetThuc = Convert.ToDateTime(reader["ngay_ket_thuc"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khuyến mãi: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Thêm khuyến mãi mới
        /// </summary>
        public static bool AddVoucher(KhuyenMai voucher)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        INSERT INTO KhuyenMai (ten_km, mo_ta, phan_tram_giam, ngay_bat_dau, ngay_ket_thuc)
                        VALUES (@ten_km, @mo_ta, @phan_tram_giam, @ngay_bat_dau, @ngay_ket_thuc)", conn);

                    cmd.Parameters.AddWithValue("@ten_km", voucher.TenKm);
                    cmd.Parameters.AddWithValue("@mo_ta", voucher.MoTa ?? "");
                    cmd.Parameters.AddWithValue("@phan_tram_giam", voucher.PhanTramGiam);
                    cmd.Parameters.AddWithValue("@ngay_bat_dau", voucher.NgayBatDau);
                    cmd.Parameters.AddWithValue("@ngay_ket_thuc", voucher.NgayKetThuc);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khuyến mãi: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật khuyến mãi
        /// </summary>
        public static bool UpdateVoucher(KhuyenMai voucher)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        UPDATE KhuyenMai
                        SET ten_km = @ten_km, mo_ta = @mo_ta, phan_tram_giam = @phan_tram_giam, 
                            ngay_bat_dau = @ngay_bat_dau, ngay_ket_thuc = @ngay_ket_thuc
                        WHERE km_id = @km_id", conn);

                    cmd.Parameters.AddWithValue("@km_id", voucher.KmId);
                    cmd.Parameters.AddWithValue("@ten_km", voucher.TenKm);
                    cmd.Parameters.AddWithValue("@mo_ta", voucher.MoTa ?? "");
                    cmd.Parameters.AddWithValue("@phan_tram_giam", voucher.PhanTramGiam);
                    cmd.Parameters.AddWithValue("@ngay_bat_dau", voucher.NgayBatDau);
                    cmd.Parameters.AddWithValue("@ngay_ket_thuc", voucher.NgayKetThuc);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khuyến mãi: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa khuyến mãi
        /// </summary>
        public static bool DeleteVoucher(int kmId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM KhuyenMai WHERE km_id = @km_id", conn);
                    cmd.Parameters.AddWithValue("@km_id", kmId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khuyến mãi: " + ex.Message);
            }
        }
    }
}
