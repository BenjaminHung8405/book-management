using System;

namespace book_management.Models
{
    public class Sach
    {
        public int SachId { get; set; }
        public string TenSach { get; set; }
        public int TacgiaId { get; set; }
        public int TheloaiId { get; set; }
        public int NxbId { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public int? NamXuatBan { get; set; }
        public int? SoTrang { get; set; }
        public string NgonNgu { get; set; }
        public string MoTa { get; set; }
        public string AnhBiaUrl { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TrangThai { get; set; }
    }
}