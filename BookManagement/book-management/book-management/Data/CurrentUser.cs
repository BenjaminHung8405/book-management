using System;
using System.ComponentModel.DataAnnotations;

namespace book_management.Data
{
    /// <summary>
    /// Quản lý thông tin phiên đăng nhập hiện tại
    /// </summary>
    public static class CurrentUser
    {
        private static dynamic _currentUser = null;

        /// <summary>
        /// Thông tin người dùng hiện tại
        /// </summary>
        public static dynamic User
        {
            get { return _currentUser; }
            private set { _currentUser = value; }
        }

        /// <summary>
        /// Kiểm tra xem có người dùng đang đăng nhập không
        /// </summary>
        public static bool IsLoggedIn => _currentUser != null;

        /// <summary>
        /// ID người dùng hiện tại
        /// </summary>
        public static int UserId => IsLoggedIn ? (int)_currentUser.UserId : 0;

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public static string Username => IsLoggedIn ? (string)_currentUser.Username : "";

        /// <summary>
        /// Họ tên người dùng
        /// </summary>
        public static string FullName => IsLoggedIn ? (string)_currentUser.HoTen : "";

        /// <summary>
        /// Vai trò người dùng
        /// </summary>
        public static string Role => IsLoggedIn ? (string)_currentUser.VaiTro : "";

        /// <summary>
        /// Email người dùng
        /// </summary>
        public static string Email => IsLoggedIn ? (string)_currentUser.Email : "";

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public static string Phone => IsLoggedIn ? (string)_currentUser.SoDienThoai : "";

        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="user">Thông tin người dùng</param>
        public static void Login(dynamic user)
        {
            User = user;
        }

        /// <summary>
        /// Đăng xuất người dùng
        /// </summary>
        public static void Logout()
        {
            User = null;
        }

        /// <summary>
        /// Kiểm tra quyền Admin
        /// </summary>
        public static bool IsAdmin => IsLoggedIn && Role == "Admin";

        /// <summary>
        /// Kiểm tra quyền Nhân viên
        /// </summary>
        public static bool IsEmployee => IsLoggedIn && (Role == "NhanVien" || Role == "Admin");

        /// <summary>
        /// Kiểm tra quyền Khách hàng
        /// </summary>
        public static bool IsCustomer => IsLoggedIn && Role == "KhachHang";

        /// <summary>
        /// Lấy thông tin hiển thị của người dùng
        /// </summary>
        /// <returns>Chuỗi hiển thị: "Họ tên (Vai trò)"</returns>
        public static string GetDisplayInfo()
        {
            if (!IsLoggedIn) return "Chưa đăng nhập";

            string displayName = !string.IsNullOrEmpty(FullName) ? FullName : Username;
            return $"{displayName} ({GetRoleDisplayName()})";
        }

        /// <summary>
        /// Lấy tên hiển thị của vai trò
        /// </summary>
        /// <returns>Tên vai trò tiếng Việt</returns>
        public static string GetRoleDisplayName()
        {
            switch (Role)
            {
                case "Admin":
                    return "Admin";
                case "NhanVien":
                    return "Employee";
                case "KhachHang":
                    return "Customer";
                default:
                    return "Không xác định";
            }
        }

        /// <summary>
        /// Cập nhật thông tin người dùng hiện tại
        /// </summary>
        public static void RefreshUserInfo()
        {
            if (IsLoggedIn)
            {
                try
                {
                    var updatedUser = UserRepository.GetUserById(UserId);
                    if (updatedUser != null)
                    {
                        User = updatedUser;
                    }
                }
                catch (Exception ex)
                {
                    // Log error but don't throw - keep current user info
                    System.Diagnostics.Debug.WriteLine($"Error refreshing user info: {ex.Message}");
                }
            }
        }

    }
}