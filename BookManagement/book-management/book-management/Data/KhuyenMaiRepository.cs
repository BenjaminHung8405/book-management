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
        public static class KhuyenMaiRepository
        {
            /// <summary>
            /// Lấy tất cả Khuyến mãi CÒN HIỆU LỰC
            /// </summary>
            public static List<KhuyenMai> GetAvailablePromotions()
            {
                var list = new List<KhuyenMai>();
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        // Chỉ lấy các KM đang trong thời gian áp dụng
                        var cmd = new SqlCommand(@"
                        SELECT km_id, ten_km, phan_tram_giam
                        FROM KhuyenMai
                        WHERE GETDATE() BETWEEN ngay_bat_dau AND ngay_ket_thuc
                        ORDER BY phan_tram_giam DESC", conn);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new KhuyenMai
                                {
                                    KmId = Convert.ToInt32(reader["km_id"]),
                                    TenKm = reader["ten_km"].ToString(),
                                    PhanTramGiam = Convert.ToDecimal(reader["phan_tram_giam"])
                                    // TODO: Thêm các cột max_discount nếu CSDL có
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
        }
    }
