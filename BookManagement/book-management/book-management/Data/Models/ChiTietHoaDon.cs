// book-management\Models\ChiTietHoaDon.cs
using book_management.Data.Models;

namespace book_management.Models
{
    public class ChiTietHoaDon
    {
        public int CthdId { get; set; }

        public int HoaDonId { get; set; }
        public int SachId { get; set; }

        public int? KhuyenMaiId { get; set; }

        public string TenSach { get; set; }

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal TienGiam { get; set; }   
        public decimal ThanhTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual Sach Sach { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
    }
}