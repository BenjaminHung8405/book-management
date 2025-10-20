using System;

namespace book_management.Models
{
    public class NguoiDung
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string VaiTro { get; set; } // Admin, NhanVien
        public DateTime NgayTao { get; set; }
    }
}