namespace book_management.Models
{
    public class ChiTietHoaDon
    {
        public int CthdId { get; set; }
        public int HoaDonId { get; set; }
        public int SachId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int? KhuyenmaiId { get; set; }
        public decimal TienGiam { get; set; }
        public decimal ThanhTien { get; set; }
    }
}