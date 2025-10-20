using System;

namespace book_management.Models
{
    public class TacGia
    {
        public int TacgiaId { get; set; }
        public string TenTacgia { get; set; }
        public string QuocTich { get; set; }
        public int? NamSinh { get; set; }
        public int? NamMat { get; set; }
    }
}