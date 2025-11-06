using System;
using System.Data;
using System.Data.SqlClient;

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

        /// <summary>
        /// L?y thông tin ng??i dùng theo ID
        /// </summary>
        /// <param name="userId">ID ng??i dùng</param>
        /// <returns>Thông tin ng??i dùng</returns>
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
                FROM NguoiDung 
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

        /// <summary>
        /// Thêm ng??i dùng m?i
        /// </summary>
        /// <param name="username">Tên ??ng nh?p</param>
        /// <param name="password">M?t kh?u</param>
        /// <param name="hoTen">H? tên</param>
        /// <param name="email">Email</param>
        /// <param name="soDienThoai">S? ?i?n tho?i</param>
        /// <param name="vaiTro">Vai trò</param>
        /// <returns>ID ng??i dùng v?a t?o</returns>
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

        /// <summary>
        /// C?p nh?t thông tin ng??i dùng
        /// </summary>
        /// <param name="userId">ID ng??i dùng</param>
        /// <param name="hoTen">H? tên</param>
        /// <param name="email">Email</param>
        /// <param name="soDienThoai">S? ?i?n tho?i</param>
        /// <param name="vaiTro">Vai trò</param>
        /// <returns>True n?u c?p nh?t thành công</returns>
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

        /// <summary>
        /// Thay ??i m?t kh?u ng??i dùng
        /// </summary>
        /// <param name="userId">ID ng??i dùng</param>
        /// <param name="newPassword">M?t kh?u m?i</param>
        /// <returns>True n?u thay ??i thành công</returns>
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

        /// <summary>
        /// Vô hi?u hóa/kích ho?t ng??i dùng
        /// </summary>
        /// <param name="userId">ID ng??i dùng</param>
        /// <param name="isActive">True ?? kích ho?t, False ?? vô hi?u hóa</param>
        /// <returns>True n?u c?p nh?t thành công</returns>
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
    }
}