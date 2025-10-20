using System;
using System.Collections.Generic;

namespace book_management.Models
{
    public class HoaDon
    {
        public int HoaDonId { get; set; }
        public int UserId { get; set; }
        public int? KhId { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public List<ChiTietHoaDon> ChiTiet { get; set; }
    }
}