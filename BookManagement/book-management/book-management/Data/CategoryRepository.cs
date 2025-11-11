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
    public class CategoryRepository
    {
        public static List<TheLoai> GetAll()
        {
            var list = new List<TheLoai>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT theloai_id, ten_theloai FROM TheLoai", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TheLoai
                            {
                                TheLoaiId = Convert.ToInt32(reader["theloai_id"]),
                                TenTheLoai = reader["ten_theloai"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách thể loại: " + ex.Message);
            }
            return list;
        }
    }
}
