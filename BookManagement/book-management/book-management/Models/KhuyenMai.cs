using System;

namespace book_management.Models
{
    public class KhuyenMai
    {
        public int KmId { get; set; }
        public string TenKm { get; set; }
        public string MoTa { get; set; }
        public decimal PhanTramGiam { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
    }
}