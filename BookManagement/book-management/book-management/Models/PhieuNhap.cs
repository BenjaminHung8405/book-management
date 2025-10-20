using System;
using System.Collections.Generic;

namespace book_management.Models
{
    public class PhieuNhap
    {
        public int PnId { get; set; }
        public int NxbId { get; set; }
        public int UserId { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public List<ChiTietPhieuNhap> ChiTiet { get; set; }
    }
}