using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace book_management.Data
{
    public class AuthorRepository
    {
        /// <summary>
        /// Lấy tất cả tác giả
        /// </summary>
        public static List<dynamic> GetAllAuthors()
        {
            var authors = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
       SELECT 
        tacgia_id, 
 ten_tacgia, 
       quoc_tich, 
         nam_sinh, 
     nam_mat,
   (SELECT COUNT(*) FROM Sach_TacGia WHERE tacgia_id = t.tacgia_id) as so_sach
           FROM TacGia t 
    ORDER BY ten_tacgia";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic author = new System.Dynamic.ExpandoObject();
                                author.TacGiaId = reader["tacgia_id"];
                                author.TenTacGia = reader["ten_tacgia"]?.ToString() ?? "";
                                author.QuocTich = reader["quoc_tich"]?.ToString() ?? "";
                                author.NamSinh = reader["nam_sinh"] != DBNull.Value ? (int?)Convert.ToInt32(reader["nam_sinh"]) : null;
                                author.NamMat = reader["nam_mat"] != DBNull.Value ? (int?)Convert.ToInt32(reader["nam_mat"]) : null;
                                author.SoSach = reader["so_sach"] != DBNull.Value ? Convert.ToInt32(reader["so_sach"]) : 0;
                                authors.Add(author);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách tác giả: {ex.Message}", ex);
            }
            return authors;
        }

        /// <summary>
        /// Thêm tác giả mới
        /// </summary>
        public static int AddAuthor(string tenTacGia, string quocTich = null, int? namSinh = null, int? namMat = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
        INSERT INTO TacGia (ten_tacgia, quoc_tich, nam_sinh, nam_mat)
    VALUES (@TenTacGia, @QuocTich, @NamSinh, @NamMat);
          SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                        command.Parameters.AddWithValue("@QuocTich", (object)quocTich ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NamSinh", (object)namSinh ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NamMat", (object)namMat ?? DBNull.Value);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm tác giả: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin tác giả
        /// </summary>
        public static bool UpdateAuthor(int tacGiaId, string tenTacGia, string quocTich = null, int? namSinh = null, int? namMat = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
    
                    string query = @"
    UPDATE TacGia 
    SET ten_tacgia = @TenTacGia,
             quoc_tich = @QuocTich,
             nam_sinh = @NamSinh,
             nam_mat = @NamMat
    WHERE tacgia_id = @TacGiaId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TacGiaId", tacGiaId);
                        command.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                        command.Parameters.AddWithValue("@QuocTich", (object)quocTich ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NamSinh", (object)namSinh ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NamMat", (object)namMat ?? DBNull.Value);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật tác giả: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa tác giả (chỉ được phép khi không có sách nào liên kết)
        /// </summary>
        public static bool DeleteAuthor(int tacGiaId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra xem có sách nào liên kết không
                    string checkQuery = "SELECT COUNT(*) FROM Sach_TacGia WHERE tacgia_id = @TacGiaId";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TacGiaId", tacGiaId);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            throw new Exception("Không thể xóa tác giả này vì đang có sách liên kết.");
                        }
                    }

                    string deleteQuery = "DELETE FROM TacGia WHERE tacgia_id = @TacGiaId";
                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TacGiaId", tacGiaId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa tác giả: {ex.Message}", ex);
            }
        }
    }

    public class CategoryRepository
    {
        /// <summary>
        /// Lấy tất cả thể loại
        /// </summary>
        public static List<dynamic> GetAllCategories()
        {
            var categories = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
        SELECT 
         theloai_id, 
         ten_theloai,
         (SELECT COUNT(*) FROM Sach_TheLoai WHERE theloai_id = t.theloai_id) as so_sach
            FROM TheLoai t 
                ORDER BY ten_theloai";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic category = new System.Dynamic.ExpandoObject();
                                category.TheLoaiId = reader["theloai_id"];
                                category.TenTheLoai = reader["ten_theloai"]?.ToString() ?? "";
                                category.SoSach = reader["so_sach"] != DBNull.Value ? Convert.ToInt32(reader["so_sach"]) : 0;
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách thể loại: {ex.Message}", ex);
            }
            return categories;
        }

        /// <summary>
        /// Thêm thể loại mới
        /// </summary>
        public static int AddCategory(string tenTheLoai)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
 INSERT INTO TheLoai (ten_theloai)
   VALUES (@TenTheLoai);
              SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm thể loại: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thể loại
        /// </summary>
        public static bool UpdateCategory(int theLoaiId, string tenTheLoai)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE TheLoai SET ten_theloai = @TenTheLoai WHERE theloai_id = @TheLoaiId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TheLoaiId", theLoaiId);
                        command.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thể loại: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa thể loại
        /// </summary>
        public static bool DeleteCategory(int theLoaiId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra xem có sách nào liên kết không
                    string checkQuery = "SELECT COUNT(*) FROM Sach_TheLoai WHERE theloai_id = @TheLoaiId";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TheLoaiId", theLoaiId);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            throw new Exception("Không thể xóa thể loại này vì đang có sách liên kết.");
                        }
                    }

                    string deleteQuery = "DELETE FROM TheLoai WHERE theloai_id = @TheLoaiId";
                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TheLoaiId", theLoaiId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thể loại: {ex.Message}", ex);
            }
        }
    }

    public class PublisherRepository
    {
        /// <summary>
        /// Lấy tất cả nhà xuất bản
        /// </summary>
        public static List<dynamic> GetAllPublishers()
        {
            var publishers = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
          SELECT 
          nxb_id, 
     ten_nxb, 
     dia_chi, 
    so_dien_thoai, 
       email,
        (SELECT COUNT(*) FROM Sach WHERE nxb_id = n.nxb_id AND trang_thai = 1) as so_sach
         FROM NhaXuatBan n 
    ORDER BY ten_nxb";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic publisher = new System.Dynamic.ExpandoObject();
                                publisher.NxbId = reader["nxb_id"];
                                publisher.TenNxb = reader["ten_nxb"]?.ToString() ?? "";
                                publisher.DiaChi = reader["dia_chi"]?.ToString() ?? "";
                                publisher.SoDienThoai = reader["so_dien_thoai"]?.ToString() ?? "";
                                publisher.Email = reader["email"]?.ToString() ?? "";
                                publisher.SoSach = reader["so_sach"] != DBNull.Value ? Convert.ToInt32(reader["so_sach"]) : 0;
                                publishers.Add(publisher);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhà xuất bản: {ex.Message}", ex);
            }
            return publishers;
        }

        /// <summary>
        /// Thêm nhà xuất bản mới
        /// </summary>
        public static int AddPublisher(string tenNxb, string diaChi = null, string soDienThoai = null, string email = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
   INSERT INTO NhaXuatBan (ten_nxb, dia_chi, so_dien_thoai, email)
        VALUES (@TenNxb, @DiaChi, @SoDienThoai, @Email);
          SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenNxb", tenNxb);
                        command.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoDienThoai", (object)soDienThoai ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm nhà xuất bản: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật nhà xuất bản
        /// </summary>
        public static bool UpdatePublisher(int nxbId, string tenNxb, string diaChi = null, string soDienThoai = null, string email = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
            UPDATE NhaXuatBan 
     SET ten_nxb = @TenNxb,
  dia_chi = @DiaChi,
         so_dien_thoai = @SoDienThoai,
      email = @Email
   WHERE nxb_id = @NxbId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NxbId", nxbId);
                        command.Parameters.AddWithValue("@TenNxb", tenNxb);
                        command.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoDienThoai", (object)soDienThoai ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhà xuất bản: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa nhà xuất bản
        /// </summary>
        public static bool DeletePublisher(int nxbId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra xem có sách nào liên kết không
                    string checkQuery = "SELECT COUNT(*) FROM Sach WHERE nxb_id = @NxbId AND trang_thai = 1";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@NxbId", nxbId);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            throw new Exception("Không thể xóa nhà xuất bản này vì đang có sách liên kết.");
                        }
                    }

                    string deleteQuery = "DELETE FROM NhaXuatBan WHERE nxb_id = @NxbId";
                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NxbId", nxbId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa nhà xuất bản: {ex.Message}", ex);
            }
        }
    }
}