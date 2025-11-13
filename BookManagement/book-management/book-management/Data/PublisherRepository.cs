using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_management.Data
{
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
