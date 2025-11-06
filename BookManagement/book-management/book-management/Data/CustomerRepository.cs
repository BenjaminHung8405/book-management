using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_management.Data.Models;

namespace book_management.Data
{
    internal class CustomerRepository
    {
        public static KhachHang GetCustomerById(int id_kh)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT * FROM KhachHang WHERE kh_id = @KhId", conn);
                    cmd.Parameters.AddWithValue("@KhId", id_kh);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHang
                            {
                                KhId = Convert.ToInt32(reader["kh_id"]),
                                TenKhach = reader["ten_khach"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                DiaChi = reader["dia_chi"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm khách hàng: " + ex.Message);
            }
            return null; // Không tìm thấy
        }
        public static KhachHang GetCustomerByPhone(string phone)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT * FROM KhachHang WHERE so_dien_thoai = @Phone", conn);
                    cmd.Parameters.AddWithValue("@Phone", phone);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHang
                            {
                                KhId = Convert.ToInt32(reader["kh_id"]),
                                TenKhach = reader["ten_khach"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                DiaChi = reader["dia_chi"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm khách hàng: " + ex.Message);
            }
            return null; // Không tìm thấy
        }
    }
}
