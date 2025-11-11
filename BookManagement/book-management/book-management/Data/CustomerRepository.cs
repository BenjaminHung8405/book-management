using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_management.Models;

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
                                DiaChi = reader["dia_chi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"])
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

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        /// <returns>Danh sách tất cả khách hàng</returns>
        public static List<KhachHang> GetAllCustomers()
        {
            var customers = new List<KhachHang>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
     SELECT kh_id, ten_khach, so_dien_thoai, dia_chi, ngay_tao 
   FROM KhachHang 
 ORDER BY ngay_tao DESC", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new KhachHang
                            {
                                KhId = Convert.ToInt32(reader["kh_id"]),
                                TenKhach = reader["ten_khach"]?.ToString() ?? "",
                                SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "",
                                DiaChi = reader["dia_chi"]?.ToString() ?? "",
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
            return customers;
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo từ khóa
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm (tên, số điện thoại, địa chỉ)</param>
        /// <returns>Danh sách khách hàng phù hợp</returns>
        public static List<KhachHang> SearchCustomers(string keyword)
        {
            var customers = new List<KhachHang>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
       SELECT kh_id, ten_khach, so_dien_thoai, dia_chi, ngay_tao 
    FROM KhachHang 
      WHERE ten_khach LIKE @Keyword 
         OR so_dien_thoai LIKE @Keyword 
    OR dia_chi LIKE @Keyword
          ORDER BY ngay_tao DESC", conn);

                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new KhachHang
                            {
                                KhId = Convert.ToInt32(reader["kh_id"]),
                                TenKhach = reader["ten_khach"]?.ToString() ?? "",
                                SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "",
                                DiaChi = reader["dia_chi"]?.ToString() ?? "",
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
            return customers;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần cập nhật</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public static bool UpdateCustomer(KhachHang customer)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
            UPDATE KhachHang 
  SET ten_khach = @TenKhach, 
                 so_dien_thoai = @SoDienThoai, 
    dia_chi = @DiaChi 
WHERE kh_id = @KhId", conn);

                    cmd.Parameters.AddWithValue("@KhId", customer.KhId);
                    cmd.Parameters.AddWithValue("@TenKhach", customer.TenKhach ?? "");
                    cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa khách hàng (chỉ được phép khi không có hóa đơn nào liên kết)
        /// </summary>
        /// <param name="khId">ID khách hàng cần xóa</param>
        /// <returns>True nếu xóa thành công</returns>
        public static bool DeleteCustomer(int khId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Kiểm tra xem có hóa đơn nào liên kết không
                    var checkCmd = new SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE kh_id = @KhId", conn, transaction);
                    checkCmd.Parameters.AddWithValue("@KhId", khId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        throw new Exception("Không thể xóa khách hàng này vì đã có hóa đơn liên kết.");
                    }

                    // Xóa khách hàng
                    var deleteCmd = new SqlCommand("DELETE FROM KhachHang WHERE kh_id = @KhId", conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@KhId", khId);

                    bool result = deleteCmd.ExecuteNonQuery() > 0;
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi xóa khách hàng: " + ex.Message);
                }
            }
        }

        public static bool CreateCustomer(KhachHang customer)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Xóa khách hàng vãng lai cũ (quá 30 ngày)
                    DeleteExpiredTemporaryCustomers(conn, transaction);

                    // Kiểm tra xem có phải khách vãng lai không
                    bool isTemporaryCustomer = string.IsNullOrEmpty(customer.TenKhach) ||
                 customer.TenKhach.Trim().ToLower() == "khách vãng lai";

                    // INSERT không bao gồm kh_id vì nó là IDENTITY
                    var cmd = new SqlCommand(@"INSERT INTO KhachHang (ten_khach, so_dien_thoai, dia_chi, ngay_tao) 
        VALUES (@TenKhach, @SoDienThoai, @DiaChi, @NgayTao);
                SELECT SCOPE_IDENTITY();", conn, transaction);

                    cmd.Parameters.AddWithValue("@TenKhach", customer.TenKhach ?? "Khách vãng lai");
                    cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");
                    cmd.Parameters.AddWithValue("@NgayTao", customer.NgayTao);

                    // Lấy ID của khách hàng vừa tạo
                    int newKhId = Convert.ToInt32(cmd.ExecuteScalar());
                    customer.KhId = newKhId;

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction.Rollback();
                    throw new Exception("Lỗi khi tạo khách hàng: " + ex.Message);
                }
            }
        }

        // Phương thức xóa khách hàng vãng lai đã hết hạn
        private static void DeleteExpiredTemporaryCustomers(SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                // Xóa khách vãng lai đã quá 30 ngày và không có hóa đơn
                var deleteCmd = new SqlCommand(@"
      DELETE FROM KhachHang 
            WHERE (ten_khach = 'Khách vãng lai' OR ten_khach IS NULL OR ten_khach = '')
       AND DATEDIFF(day, ngay_tao, GETDATE()) > 10
             AND kh_id NOT IN (SELECT DISTINCT kh_id FROM HoaDon WHERE kh_id IS NOT NULL)",
                conn, transaction);

                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log lỗi nhưng không throw để không ảnh hưởng đến việc tạo khách hàng mới
                System.Diagnostics.Debug.WriteLine($"Lỗi khi xóa khách vãng lai: {ex.Message}");
            }
        }

        // Phương thức công khai để xóa khách vãng lai (có thể gọi từ scheduled job)
        public static void CleanupExpiredTemporaryCustomers()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    DeleteExpiredTemporaryCustomers(conn, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi dọn dẹp khách vãng lai: " + ex.Message);
                }
            }
        }

        // Thêm hàm này vào KhachHangRepository.cs
        public static KhachHang GetCustomerByUserId(int userId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Tìm KhachHang có SĐT trùng với SĐT của NguoiDung
                    var cmd = new SqlCommand(@"
    SELECT kh.* FROM KhachHang kh
          JOIN NguoiDung nd ON kh.so_dien_thoai = nd.so_dien_thoai
  WHERE nd.user_id = @UserId", conn);

                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHang
                            {
                                KhId = Convert.ToInt32(reader["kh_id"]),
                                TenKhach = reader["ten_khach"].ToString(),
                                SoDienThoai = reader["so_dien_thoai"].ToString(),
                                DiaChi = reader["dia_chi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm khách hàng theo User ID: " + ex.Message);
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
                                DiaChi = reader["dia_chi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"])
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
