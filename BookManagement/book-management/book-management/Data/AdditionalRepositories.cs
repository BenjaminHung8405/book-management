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
}