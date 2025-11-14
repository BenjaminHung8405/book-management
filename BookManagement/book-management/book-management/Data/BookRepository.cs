using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using book_management.Models;

namespace book_management.Data
{
    public class BookRepository
    {

        public static List<dynamic> GetAllBooks()
        {
            var books = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                     SELECT DISTINCT
                          s.sach_id,
                          s.ten_sach,
                          s.gia,
                          s.so_luong,
                          s.anh_bia_url,
                          s.nam_xuat_ban,
                          s.so_trang,
                          s.mo_ta,
                          s.ngon_ngu,
                          s.trang_thai,
                          n.ten_nxb,

                       STUFF((
                     SELECT ', ' + tg.ten_tacgia
                        FROM Sach_TacGia st
                      INNER JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
                       WHERE st.sach_id = s.sach_id
                    FOR XML PATH('')), 1, 2, '') AS tacgia_names,
                         STUFF((
                    SELECT ', ' + tl.ten_theloai
                        FROM Sach_TheLoai stl
                         INNER JOIN TheLoai tl ON stl.theloai_id = tl.theloai_id
                       WHERE stl.sach_id = s.sach_id
                       FOR XML PATH('')), 1, 2, '') AS theloai_names
                          FROM Sach s
                       INNER JOIN NhaXuatBan n ON s.nxb_id = n.nxb_id
                               WHERE s.trang_thai = 1
                     ORDER BY s.sach_id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic book = new System.Dynamic.ExpandoObject();
                                book.SachId = reader["sach_id"];
                                book.TenSach = reader["ten_sach"]?.ToString() ?? "";
                                book.TacGia = reader["tacgia_names"]?.ToString() ?? "";
                                book.TheLoai = reader["theloai_names"]?.ToString() ?? "";
                                book.NhaXuatBan = reader["ten_nxb"]?.ToString() ?? "";
                                book.Gia = reader["gia"] != DBNull.Value ? Convert.ToDecimal(reader["gia"]) : 0m;
                                book.SoLuong = reader["so_luong"] != DBNull.Value ? Convert.ToInt32(reader["so_luong"]) : 0;
                                book.AnhBiaUrl = reader["anh_bia_url"]?.ToString() ?? "";
                                book.NamXuatBan = reader["nam_xuat_ban"] != DBNull.Value ? Convert.ToInt32(reader["nam_xuat_ban"]) : 0;
                                book.SoTrang = reader["so_trang"] != DBNull.Value ? Convert.ToInt32(reader["so_trang"]) : 0;
                                book.MoTa = reader["mo_ta"]?.ToString() ?? "";
                                book.NgonNgu = reader["ngon_ngu"]?.ToString() ?? "";
                                book.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi lay danh sách sách: {ex.Message}", ex);
            }

            return books;
        }

        /// <summary>
        /// L?y thông tin sách theo ID
        /// </summary>
        /// <param name="sachId">ID c?a sách</param>
        /// <returns>Dynamic object ch?a thông tin sách</returns>
        public static dynamic GetBookById(int sachId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                     SELECT DISTINCT
                         s.sach_id,
                         s.ten_sach,
                         s.gia,
                         s.so_luong,
                         s.anh_bia_url,
                         s.nam_xuat_ban,
                         s.so_trang,
                         s.mo_ta,
                         s.ngon_ngu,
                         s.trang_thai,
                         s.nxb_id,
                         n.ten_nxb,
                     STUFF((
                     SELECT ', ' + tg.ten_tacgia
                     FROM Sach_TacGia st
                     INNER JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
                     WHERE st.sach_id = s.sach_id
                     FOR XML PATH('')), 1, 2, '') AS tacgia_names,
                     STUFF((
                     SELECT ', ' + tl.ten_theloai
                     FROM Sach_TheLoai stl
                     INNER JOIN TheLoai tl ON stl.theloai_id = tl.theloai_id
                     WHERE stl.sach_id = s.sach_id
                     FOR XML PATH('')), 1, 2, '') AS theloai_names
                     FROM Sach s
                     INNER JOIN NhaXuatBan n ON s.nxb_id = n.nxb_id
                     WHERE s.sach_id = @SachId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SachId", sachId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dynamic book = new System.Dynamic.ExpandoObject();
                                book.SachId = reader["sach_id"];
                                book.TenSach = reader["ten_sach"]?.ToString() ?? "";
                                book.TacGia = reader["tacgia_names"]?.ToString() ?? "";
                                book.TheLoai = reader["theloai_names"]?.ToString() ?? "";
                                book.NhaXuatBan = reader["ten_nxb"]?.ToString() ?? "";
                                book.NxbId = reader["nxb_id"] != DBNull.Value ? Convert.ToInt32(reader["nxb_id"]) : 0;
                                book.Gia = reader["gia"] != DBNull.Value ? Convert.ToDecimal(reader["gia"]) : 0m;
                                book.SoLuong = reader["so_luong"] != DBNull.Value ? Convert.ToInt32(reader["so_luong"]) : 0;
                                book.AnhBiaUrl = reader["anh_bia_url"]?.ToString() ?? "";
                                book.NamXuatBan = reader["nam_xuat_ban"] != DBNull.Value ? Convert.ToInt32(reader["nam_xuat_ban"]) : 0;
                                book.SoTrang = reader["so_trang"] != DBNull.Value ? Convert.ToInt32(reader["so_trang"]) : 0;
                                book.MoTa = reader["mo_ta"]?.ToString() ?? "";
                                book.NgonNgu = reader["ngon_ngu"]?.ToString() ?? "";
                                book.TrangThai = reader["trang_thai"] != DBNull.Value ? Convert.ToBoolean(reader["trang_thai"]) : true;

                                return book;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin sách ID {sachId}: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>
        /// Thêm sách m?i vào database
        /// </summary>
        /// <param name="tenSach">Tên sách</param>
        /// <param name="nxbId">ID nhà xu?t b?n</param>
        /// <param name="gia">Giá sách</param>
        /// <param name="soLuong">S? l??ng</param>
        /// <param name="anhBiaUrl">URL ?nh bìa</param>
        /// <param name="tacGiaIds">Danh sách ID tác gi?</param>
        /// <param name="theLoaiIds">Danh sách ID th? lo?i</param>
        /// <param name="namXuatBan">N?m xu?t b?n</param>
        /// <param name="soTrang">S? trang</param>
        /// <param name="moTa">Mô t?</param>
        /// <param name="ngonNgu">Ngôn ng?</param>
        /// <returns>ID c?a sách v?a thêm</returns>
        public static int AddBook(string tenSach, int nxbId, decimal gia, int soLuong, string anhBiaUrl,
          List<int> tacGiaIds, List<int> theLoaiIds, int? namXuatBan = null,
            int? soTrang = null, string moTa = null, string ngonNgu = "Ti?ng Vi?t")
        {
            SqlTransaction transaction = null;
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // 1. Thêm sách
                    string insertBookQuery = @"
          INSERT INTO Sach (ten_sach, nxb_id, gia, so_luong, anh_bia_url, nam_xuat_ban, so_trang, mo_ta, ngon_ngu)
          VALUES (@TenSach, @NxbId, @Gia, @SoLuong, @AnhBiaUrl, @NamXuatBan, @SoTrang, @MoTa, @NgonNgu);
           SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(insertBookQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@TenSach", tenSach ?? "");
                        command.Parameters.AddWithValue("@NxbId", nxbId);
                        command.Parameters.AddWithValue("@Gia", gia);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@AnhBiaUrl", anhBiaUrl ?? "");
                        command.Parameters.AddWithValue("@NamXuatBan", (object)namXuatBan ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoTrang", (object)soTrang ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MoTa", moTa ?? "");
                        command.Parameters.AddWithValue("@NgonNgu", ngonNgu ?? "Ti?ng Vi?t");

                        var sachId = Convert.ToInt32(command.ExecuteScalar());

                        // 2. Thêm liên k?t tác gi?
                        if (tacGiaIds != null && tacGiaIds.Count > 0)
                        {
                            foreach (var tacGiaId in tacGiaIds)
                            {
                                string insertTacGiaQuery = "INSERT INTO Sach_TacGia (sach_id, tacgia_id) VALUES (@SachId, @TacGiaId)";
                                using (var tacGiaCommand = new SqlCommand(insertTacGiaQuery, connection, transaction))
                                {
                                    tacGiaCommand.Parameters.AddWithValue("@SachId", sachId);
                                    tacGiaCommand.Parameters.AddWithValue("@TacGiaId", tacGiaId);
                                    tacGiaCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 3. Thêm liên k?t th? lo?i
                        if (theLoaiIds != null && theLoaiIds.Count > 0)
                        {
                            foreach (var theLoaiId in theLoaiIds)
                            {
                                string insertTheLoaiQuery = "INSERT INTO Sach_TheLoai (sach_id, theloai_id) VALUES (@SachId, @TheLoaiId)";
                                using (var theLoaiCommand = new SqlCommand(insertTheLoaiQuery, connection, transaction))
                                {
                                    theLoaiCommand.Parameters.AddWithValue("@SachId", sachId);
                                    theLoaiCommand.Parameters.AddWithValue("@TheLoaiId", theLoaiId);
                                    theLoaiCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return sachId;
                    }
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Loi khi thêm sách moi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// C?p nh?t thông tin sách
        /// </summary>
        public static bool UpdateBook(int sachId, string tenSach, int nxbId, decimal gia, int soLuong, string anhBiaUrl,
        List<int> tacGiaIds, List<int> theLoaiIds, int? namXuatBan = null,
         int? soTrang = null, string moTa = null, string ngonNgu = "Ti?ng Vi?t")
        {
            SqlTransaction transaction = null;
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                   
                    string updateQuery = @"
                    UPDATE Sach 
                    SET ten_sach = @TenSach,
                    nxb_id = @NxbId,
                    gia = @Gia,
                    so_luong = @SoLuong,
                    anh_bia_url = @AnhBiaUrl,
                    nam_xuat_ban = @NamXuatBan,
                    so_trang = @SoTrang,
                    mo_ta = @MoTa,
                    ngon_ngu = @NgonNgu
                    WHERE sach_id = @SachId";

                    using (var command = new SqlCommand(updateQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@SachId", sachId);
                        command.Parameters.AddWithValue("@TenSach", tenSach ?? "");
                        command.Parameters.AddWithValue("@NxbId", nxbId);
                        command.Parameters.AddWithValue("@Gia", gia);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@AnhBiaUrl", anhBiaUrl ?? "");
                        command.Parameters.AddWithValue("@NamXuatBan", (object)namXuatBan ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SoTrang", (object)soTrang ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MoTa", moTa ?? "");
                        command.Parameters.AddWithValue("@NgonNgu", ngonNgu ?? "Ti?ng Vi?t");

                        command.ExecuteNonQuery();
                    }

                    using (var deleteCommand = new SqlCommand("DELETE FROM Sach_TacGia WHERE sach_id = @SachId", connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@SachId", sachId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    using (var deleteCommand = new SqlCommand("DELETE FROM Sach_TheLoai WHERE sach_id = @SachId", connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@SachId", sachId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    if (tacGiaIds != null && tacGiaIds.Count > 0)
                    {
                        foreach (var tacGiaId in tacGiaIds)
                        {
                            string insertTacGiaQuery = "INSERT INTO Sach_TacGia (sach_id, tacgia_id) VALUES (@SachId, @TacGiaId)";
                            using (var tacGiaCommand = new SqlCommand(insertTacGiaQuery, connection, transaction))
                            {
                                tacGiaCommand.Parameters.AddWithValue("@SachId", sachId);
                                tacGiaCommand.Parameters.AddWithValue("@TacGiaId", tacGiaId);
                                tacGiaCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    if (theLoaiIds != null && theLoaiIds.Count > 0)
                    {
                        foreach (var theLoaiId in theLoaiIds)
                        {
                            string insertTheLoaiQuery = "INSERT INTO Sach_TheLoai (sach_id, theloai_id) VALUES (@SachId, @TheLoaiId)";
                            using (var theLoaiCommand = new SqlCommand(insertTheLoaiQuery, connection, transaction))
                            {
                                theLoaiCommand.Parameters.AddWithValue("@SachId", sachId);
                                theLoaiCommand.Parameters.AddWithValue("@TheLoaiId", theLoaiId);
                                theLoaiCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Loi khi cap nhat  sách ID {sachId}: {ex.Message}", ex);
            }
        }

        /// <summary>
       
        /// </summary>
        /// <param name="sachId">I
        /// <returns>True neu xóa thành công</returns>
        public static bool DeleteBook(int sachId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();


                    string query = "UPDATE Sach SET trang_thai = 0 WHERE sach_id = @SachId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SachId", sachId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi xóa sách ID {sachId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lay danh sach tac gia
        /// </summary>
        public static List<dynamic> GetAllAuthors()
        {
            var authors = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT tacgia_id, ten_tacgia, quoc_tich, nam_sinh, nam_mat FROM TacGia ORDER BY ten_tacgia";

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
                                author.NamSinh = reader["nam_sinh"] != DBNull.Value ? Convert.ToInt32(reader["nam_sinh"]) : 0;
                                author.NamMat = reader["nam_mat"] != DBNull.Value ? Convert.ToInt32(reader["nam_mat"]) : 0;
                                authors.Add(author);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi lay danh sach tac gia: {ex.Message}", ex);
            }
            return authors;
        }

        /// <summary>
        /// L?y danh sách tat ca the loai
        /// </summary>
        public static List<dynamic> GetAllCategories()
        {
            var categories = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT theloai_id, ten_theloai FROM TheLoai ORDER BY ten_theloai";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic category = new System.Dynamic.ExpandoObject();
                                category.TheLoaiId = reader["theloai_id"];
                                category.TenTheLoai = reader["ten_theloai"]?.ToString() ?? "";
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi lay danh sach the loai: {ex.Message}", ex);
            }
            return categories;
        }

        /// <summary>
        /// Lay danh sach nxb
        /// </summary>
        public static List<dynamic> GetAllPublishers()
        {
            var publishers = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT nxb_id, ten_nxb, dia_chi, so_dien_thoai, email FROM NhaXuatBan ORDER BY ten_nxb";

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
                                publishers.Add(publisher);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi lay danh sach : {ex.Message}", ex);
            }
            return publishers;
        }

        /// <summary>
        /// Tìm kiem sach theo tu khoa
        /// </summary>
        public static List<dynamic> SearchBooks(string keyword)
        {
            var books = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                       SELECT DISTINCT
                            s.sach_id,
                            s.ten_sach,
                            s.gia,
                            s.so_luong,
                            s.anh_bia_url,
                            n.ten_nxb,
                     STUFF((
                            SELECT ', ' + tg.ten_tacgia
                            FROM Sach_TacGia st
                            INNER JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
                    WHERE st.sach_id = s.sach_id
                       FOR XML PATH('')), 1, 2, '') AS tacgia_names,
                    STUFF((
                    SELECT ', ' + tl.ten_theloai
                         FROM Sach_TheLoai stl
                         INNER JOIN TheLoai tl ON stl.theloai_id = tl.theloai_id
                    WHERE stl.sach_id = s.sach_id
                              FOR XML PATH('')), 1, 2, '') AS theloai_names
                    FROM Sach s
                    INNER JOIN NhaXuatBan n ON s.nxb_id = n.nxb_id
                    LEFT JOIN Sach_TacGia st ON s.sach_id = st.sach_id
                    LEFT JOIN TacGia tg ON st.tacgia_id = tg.tacgia_id
                    WHERE s.trang_thai = 1 
                    AND (s.ten_sach LIKE @Keyword OR tg.ten_tacgia LIKE @Keyword OR n.ten_nxb LIKE @Keyword)
                    ORDER BY s.sach_id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic book = new System.Dynamic.ExpandoObject();
                                book.SachId = reader["sach_id"];
                                book.TenSach = reader["ten_sach"]?.ToString() ?? "";
                                book.TacGia = reader["tacgia_names"]?.ToString() ?? "";
                                book.TheLoai = reader["theloai_names"]?.ToString() ?? "";
                                book.NhaXuatBan = reader["ten_nxb"]?.ToString() ?? "";
                                book.Gia = reader["gia"] != DBNull.Value ? Convert.ToDecimal(reader["gia"]) : 0m;
                                book.SoLuong = reader["so_luong"] != DBNull.Value ? Convert.ToInt32(reader["so_luong"]) : 0;
                                book.AnhBiaUrl = reader["anh_bia_url"]?.ToString() ?? "";
                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khi tim kiem sach: {ex.Message}", ex);
            }
            return books;
        }
    }
}