using System;
using System.Collections.Generic;

namespace book_management.Data.Models
{
    public class TacGia
    {
        public int TacGiaId { get; set; }
        public string TenTacGia { get; set; }
        public string QuocTich { get; set; }
        public int? NamSinh { get; set; }
        public int? NamMat { get; set; }

        // Navigation properties
        public List<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class NhaXuatBan
    {
        public int NxbId { get; set; }
        public string TenNxb { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public List<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class TheLoai
    {
        public int TheLoaiId { get; set; }
        public string TenTheLoai { get; set; }

        // Navigation properties
        public List<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class Sach
    {
        public int SachId { get; set; }
        public string TenSach { get; set; }
        public int NxbId { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool TrangThai { get; set; }
        public int? NamXuatBan { get; set; }
        public int? SoTrang { get; set; }
        public string MoTa { get; set; }
        public string AnhBiaUrl { get; set; }
        public string NgonNgu { get; set; }

        // Navigation properties
        public NhaXuatBan NhaXuatBan { get; set; }
        public List<TacGia> TacGias { get; set; } = new List<TacGia>();
        public List<TheLoai> TheLoais { get; set; } = new List<TheLoai>();
    }

    public class NguoiDung
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
    }

    public class KhachHang
    {
        public int KhId { get; set; }
        public string TenKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class HoaDon
    {
        public int HoaDonId { get; set; }
        public int? UserId { get; set; }
        public int? KhId { get; set; }
        public string TenKhachVangLai { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }

        // Navigation properties
        public NguoiDung NguoiDung { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }

    public class ChiTietHoaDon
    {
        public int CthdId { get; set; }
        public int HoaDonId { get; set; }
        public int SachId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int? KhuyenMaiId { get; set; }
        public decimal TienGiam { get; set; }
        public decimal ThanhTien { get; set; }

        // Navigation properties
        public HoaDon HoaDon { get; set; }
        public Sach Sach { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
    }

    public class KhuyenMai
    {
        public int KmId { get; set; }
        public string TenKm { get; set; }
        public string MoTa { get; set; }
        public decimal PhanTramGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        // Navigation properties
        public List<Sach> Sachs { get; set; } = new List<Sach>();
    }

    public class PhieuNhap
    {
        public int PnId { get; set; }
        public int UserId { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }

        // Navigation properties
        public NguoiDung NguoiDung { get; set; }
        public List<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
    }

    public class ChiTietPhieuNhap
    {
        public int CtpnId { get; set; }
        public int PnId { get; set; }
        public int SachId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // Navigation properties
        public PhieuNhap PhieuNhap { get; set; }
        public Sach Sach { get; set; }
    }

    public class LichSuTonKho
    {
        public int LsId { get; set; }
        public int SachId { get; set; }
        public DateTime NgayThayDoi { get; set; }
        public string LoaiThayDoi { get; set; }
        public int SoLuongThayDoi { get; set; }
        public int SoLuongSauThayDoi { get; set; }
        public string GhiChu { get; set; }

        // Navigation properties
        public Sach Sach { get; set; }
    }
}