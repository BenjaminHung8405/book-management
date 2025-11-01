// book-management\Models\HoaDon.cs
using System;

namespace book_management.Models
{
    public class HoaDon
    {
        public int HoaDonId { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } // dã thanh toán, dã huy, etc.
        public int UserId { get; set; }  // ID cua khách hàng

        public string TenNguoiMua { get; set; }  // Tên khách hàng hoặc tên khách vãng lai
        public string NguoiLap { get; set; }  // Nhân viên lap hóa don
        public string GhiChu { get; set; }
    }
}