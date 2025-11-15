using System;
using System.Configuration;
using System.Data.SqlClient;  // Thay đổi từ Microsoft.Data.SqlClient

namespace book_management.Data
{
    public static class DatabaseConnection
    {
        // Connection string sử dụng Windows Authentication
        private static readonly string connectionString =

        @"Server=LAPOFTH;Database=BookManagement;Integrated Security=true;";

        //@"Server=DESKTOP-UFG81JC\SQLEXPRESS;Database=book-management;Integrated Security=true;";

        /// <summary>
        /// Tạo và trả về SqlConnection mới
        /// </summary>
        /// <returns>SqlConnection với Windows Authentication</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể tạo kết nối đến database: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra kết nối đến database
        /// </summary>
        /// <returns>True nếu kết nối thành công, False nếu thất bại</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy connection string hiện tại
        /// </summary>
        /// <returns>Connection string</returns>
        public static string GetConnectionString()
        {
            return connectionString;
        }

        /// <summary>
        /// Tạo kết nối với custom server name
        /// </summary>
        /// <param name="serverName">Tên server SQL</param>
        /// <param name="databaseName">Tên database</param>
        /// <returns>SqlConnection</returns>
        public static SqlConnection GetConnection(string serverName, string databaseName)
        {
            try
            {
                string customConnectionString =
                   $@"Server={serverName};Database={databaseName};Integrated Security=true;";

                var connection = new SqlConnection(customConnectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể tạo kết nối đến database: {ex.Message}", ex);
            }
        }
    }
}