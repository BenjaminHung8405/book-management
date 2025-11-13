using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.DataAccess;
using book_management.Models;
using book_management.UI.Theme;

namespace book_management.UI.Controls
{
    public partial class InvoiceDetailForm : Form
    {
        private readonly int _hoaDonId;
        private readonly List<ChiTietHoaDon> _chiTietList;
        private HoaDon _hoaDon;

        public InvoiceDetailForm(int hoaDonId, List<ChiTietHoaDon> chiTietList)
        {
            _hoaDonId = hoaDonId;
            _chiTietList = chiTietList;
            InitializeComponent();

            // Wire event handlers that designer shouldn't serialize
            if (btnClose != null)
                btnClose.Click += BtnClose_Click;

            LoadInvoiceInfo();
            LoadInvoiceDetails();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInvoiceInfo()
        {
            try
            {
                _hoaDon = HoaDonRepository.GetInvoiceById(_hoaDonId);
                if (_hoaDon != null)
                {
                    lblNgayLapValue.Text = _hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm");
                    lblKhachHangValue.Text = _hoaDon.TenNguoiMua;
                    lblNguoiLapValue.Text = _hoaDon.NguoiLap;

                    lblTrangThaiValue.Text = _hoaDon.TrangThai;
                    switch (_hoaDon.TrangThai)
                    {
                        case "DaThanhToan":
                            lblTrangThaiValue.ForeColor = Color.Green;
                            lblTrangThaiValue.Text = "Đã Thanh Toán";
                            break;
                        case "ChuaThanhToan":
                            lblTrangThaiValue.ForeColor = Color.Orange;
                            lblTrangThaiValue.Text = "Chưa Thanh Toán";
                            break;
                        case "DaHuy":
                            lblTrangThaiValue.ForeColor = Color.Red;
                            lblTrangThaiValue.Text = "Đã Hủy";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin hóa đơn: {ex.Message}",
        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceDetails()
        {
            try
            {
                var dgv = this.dgvDetailsGrid;
                if (dgv != null)
                {
                    dgv.Rows.Clear();
                    decimal tongTien = 0;
                    int stt = 1;

                    foreach (var item in _chiTietList)
                    {
                        dgv.Rows.Add(
                       stt++,
                          item.TenSach,
                               item.SoLuong,
                            item.DonGia.ToString("N0") + " đ",
                     item.TienGiam.ToString("N0") + " đ",
                           item.ThanhTien.ToString("N0") + " đ"
                          );
                        tongTien += item.ThanhTien;
                    }

                    lblTongTien.Text = $"TỔNG TIỀN: {tongTien:N0} đ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}",
                          "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}