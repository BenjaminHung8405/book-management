using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using book_management.Models;

namespace book_management.Data
{
    public class SqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess()
        {
            // Default connection string; replace with your actual connection if needed
            _connectionString = "Data Source=.;Initial Catalog=BookManagement;Integrated Security=True;";
        }

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Example: Get user by username
        public NguoiDung GetNguoiDungByUsername(string username)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT user_id, username, password_hash, ho_ten, email, so_dien_thoai, vai_tro, ngay_tao FROM NguoiDung WHERE username = @username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NguoiDung
                        {
                            UserId = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2),
                            HoTen = reader.GetString(3),
                            Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                            SoDienThoai = reader.IsDBNull(5) ? null : reader.GetString(5),
                            VaiTro = reader.GetString(6),
                            NgayTao = reader.GetDateTime(7)
                        };
                    }
                }
            }
            return null;
        }

        // Example: Insert a new TacGia
        public int InsertTacGia(TacGia tacgia)
        {
            const string sql = "INSERT INTO TacGia (ten_tacgia, quoc_tich, nam_sinh, nam_mat) OUTPUT INSERTED.tacgia_id VALUES (@ten, @quoc, @namsinh, @nammat)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ten", tacgia.TenTacgia);
                cmd.Parameters.AddWithValue("@quoc", (object)tacgia.QuocTich ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@namsinh", (object)tacgia.NamSinh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nammat", (object)tacgia.NamMat ?? DBNull.Value);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Example: Get all Sach
        public List<Sach> GetAllSach()
        {
            var list = new List<Sach>();
            const string sql = "SELECT sach_id, ten_sach, tacgia_id, theloai_id, nxb_id, gia, so_luong, nam_xuat_ban, so_trang, ngon_ngu, mo_ta, anh_bia_url, ngay_nhap, trang_thai FROM Sach";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sach
                        {
                            SachId = reader.GetInt32(0),
                            TenSach = reader.GetString(1),
                            TacgiaId = reader.GetInt32(2),
                            TheloaiId = reader.GetInt32(3),
                            NxbId = reader.GetInt32(4),
                            Gia = reader.GetDecimal(5),
                            SoLuong = reader.GetInt32(6),
                            NamXuatBan = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                            SoTrang = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                            NgonNgu = reader.IsDBNull(9) ? null : reader.GetString(9),
                            MoTa = reader.IsDBNull(10) ? null : reader.GetString(10),
                            AnhBiaUrl = reader.IsDBNull(11) ? null : reader.GetString(11),
                            NgayNhap = reader.GetDateTime(12),
                            TrangThai = reader.IsDBNull(13) ? null : reader.GetString(13)
                        });
                    }
                }
            }
            return list;
        }

        // More CRUD methods can be added similarly for other entities.
    }
}
