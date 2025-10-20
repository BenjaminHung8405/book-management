using System;

namespace book_management.Models
{
    public class LichSuTonKho
    {
        public int LsId { get; set; }
        public int SachId { get; set; }
        public DateTime NgayThayDoi { get; set; }
        public string LoaiThayDoi { get; set; }
        public int SoLuongThayDoi { get; set; }
        public int SoLuongSauThayDoi { get; set; }
        public string GhiChu { get; set; }
    }
}