using System;

namespace book_management.Models
{
    public class KhachHang
    {
        public int KhId { get; set; }
        public string TenKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayTao { get; set; }
    }
}