using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using book_management.Models;

namespace book_management.Data
{
    public class UserRepository
    {
        /// <summary>

        public static dynamic AuthenticateUser(string username, string password)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                      SELECT 
                        user_id,
                        username,
                        ho_ten,
                        email,
                        so_dien_thoai,
                        vai_tro,
                        trang_thai
                        FROM NguoiDung 
                      WHERE username = @Username 
                      AND password_hash = @Password 
                      AND trang_thai = 1";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xác thực người dùng: {ex.Message}", ex);
            }

            return null;
        }
        public static dynamic GetUserByPhone(string soDienThoai)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                    user_id,
                    username,
                    ho_ten,
                    email,
                    so_dien_thoai,
                    vai_tro,
                    ngay_tao,
                    trang_thai
                    FROM NguoiDung 
                    WHERE so_dien_thoai = @SoDienThoai";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.NgayTao = reader["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_tao"]) : DateTime.MinValue;
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;
                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin người dùng: {ex.Message}", ex);
            }
            return null;
        }
        public static dynamic GetUserById(int userId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                    user_id,
                    username,
                    ho_ten,
                    email,
                    so_dien_thoai,
                    vai_tro,
                    ngay_tao,
                    trang_thai
                    FROM NguoiDung 
                    WHERE user_id = @UserId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.NgayTao = reader["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_tao"]) : DateTime.MinValue;
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin người dùng: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>

        public static System.Collections.Generic.List<dynamic> GetAllUsers()
        {
            var users = new System.Collections.Generic.List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                         SELECT 
                         user_id,
                         username,
                         ho_ten,
                         email,
                         so_dien_thoai,
                         vai_tro,
                         ngay_tao,
                         trang_thai
                         FROM NguoiDung WHERE trang_thai <> 0
                         ORDER BY ho_ten";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.NgayTao = reader["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_tao"]) : DateTime.MinValue;
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách người dùng: {ex.Message}", ex);
            }

            return users;
        }


        public static int AddUser(string username, string password, string hoTen, string email = null, string soDienThoai = null, string vaiTro = "NhanVien")
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
            INSERT INTO NguoiDung (username, password_hash, ho_ten, email, so_dien_thoai, vai_tro)
         VALUES (@Username, @Password, @HoTen, @Email, @SoDienThoai, @VaiTro);
            SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoDienThoai", (object)soDienThoai ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VaiTro", vaiTro);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm người dùng: {ex.Message}", ex);
            }
        }


        public static bool UpdateUser(int userId, string hoTen, string email = null, string soDienThoai = null, string vaiTro = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
 UPDATE NguoiDung 
         SET ho_ten = @HoTen,
             email = @Email,
  so_dien_thoai = @SoDienThoai,
            vai_tro = @VaiTro
        WHERE user_id = @UserId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoDienThoai", (object)soDienThoai ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VaiTro", vaiTro ?? "NhanVien");

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật người dùng: {ex.Message}", ex);
            }
        }


        public static bool ChangePassword(int userId, string newPassword)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE NguoiDung SET password_hash = @Password WHERE user_id = @UserId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Password", newPassword);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thay đổi mật khẩu: {ex.Message}", ex);
            }
        }
        public static List<dynamic> SearchUser(string keyword)
        {
            var users = new List<dynamic>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                SELECT 
                    user_id, 
                    username, 
                    ho_ten, 
                    email, 
                    so_dien_thoai, 
                    vai_tro, 
                    ngay_tao, 
                    trang_thai
                FROM NguoiDung
                WHERE 
                    username LIKE @Keyword 
                    OR so_dien_thoai LIKE @Keyword 
                    OR ho_ten LIKE @Keyword
                ORDER BY ngay_tao DESC", conn);

                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            users.Add(new NguoiDung
                            {
                                UserId = Convert.ToInt32(reader["user_id"]),
                                HoTen = reader["ho_ten"]?.ToString() ?? "",
                                Username = reader["username"]?.ToString() ?? "",
                                Email = reader["email"]?.ToString() ?? "",
                                SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "",
                                VaiTro = reader["vai_tro"]?.ToString() ?? "",
                                NgayTao = Convert.ToDateTime(reader["ngay_tao"]),
                                TrangThai = Convert.ToBoolean(reader["trang_thai"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
            return users;
        }
        public static bool SetUserStatus(int userId, bool isActive)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE NguoiDung SET trang_thai = @TrangThai WHERE user_id = @UserId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@TrangThai", isActive);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái người dùng {ex.Message}", ex);
            }
        }
        // tim kiem theo trang thai
        public static bool GetUsersByStatus(bool status)
        {
            var users = new System.Collections.Generic.List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            user_id, username, ho_ten, email, so_dien_thoai, 
                            vai_tro, ngay_tao, trang_thai
                        FROM NguoiDung 
                        WHERE trang_thai = @TrangThai -- Lọc theo vai trò
                        ORDER BY ho_ten";

                    using (var command = new SqlCommand(query, connection))
                    {
                        // Gán tham số cho @TrangThai
                        command.Parameters.AddWithValue("@TrangThai", status);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.NgayTao = reader["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_tao"]) : DateTime.MinValue;
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách người dùng theo vai trò: {ex.Message}", ex);
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra xem user có hóa đơn liên quan không
        /// </summary>
        public static bool UserHasInvoices(int userId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM HoaDon WHERE user_id = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        var result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra hóa đơn của người dùng: {ex.Message}", ex);
            }
        }
        /// <summary>
        /// Lấy danh sách người dùng ĐÃ LỌC theo vai trò
        /// </summary>
        public static System.Collections.Generic.List<dynamic> GetUsersByRole(string vaiTro)
        {
            var users = new System.Collections.Generic.List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Câu query này có thêm mệnh đề WHERE
                    string query = @"
                        SELECT 
                            user_id, username, ho_ten, email, so_dien_thoai, 
                            vai_tro, ngay_tao, trang_thai
                        FROM NguoiDung 
                        WHERE vai_tro = @VaiTro  -- Lọc theo vai trò
                        ORDER BY ho_ten";

                    using (var command = new SqlCommand(query, connection))
                    {
                        // Gán tham số cho @VaiTro
                        command.Parameters.AddWithValue("@VaiTro", vaiTro);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic user = new System.Dynamic.ExpandoObject();
                                user.UserId = reader["user_id"];
                                user.Username = reader["username"]?.ToString() ?? "";
                                user.HoTen = reader["ho_ten"]?.ToString() ?? "";
                                user.Email = reader["email"]?.ToString() ?? "";
                                user.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                user.VaiTro = reader["vai_tro"]?.ToString() ?? "";
                                user.NgayTao = reader["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_tao"]) : DateTime.MinValue;
                                user.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách người dùng theo vai trò: {ex.Message}", ex);
            }

            return users;
        }
        public static bool DeleteUser(int userId)
        {
            try
            {
                // Check if user has invoices - do not delete if any invoices exist
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(1) FROM HoaDon WHERE user_id = @UserId";
                    using (var cmd = new SqlCommand(checkQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // There are invoices associated with this user - cannot delete
                            return false;
                        }
                    }
                }

                // Gọi hàm SetUserStatus để đánh dấu người dùng là không hoạt động (bị khóa)
                return UserRepository.SetUserStatus(userId, false);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng: " + ex.Message);
            }
        }
    }
}