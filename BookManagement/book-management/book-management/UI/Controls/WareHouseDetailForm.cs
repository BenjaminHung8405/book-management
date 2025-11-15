using System;
using System.Collections.Generic;
using System.Windows.Forms;
using book_management.Data;
using book_management.Models;

namespace book_management.UI.Controls
{
    public partial class WareHouseDetailForm : Form
    {
        private int _pnId;
        private PhieuNhap _phieuNhap;

        public WareHouseDetailForm(int pnId)
        {
            InitializeComponent();
            _pnId = pnId;
            SetupGridColumns();
        }

        private void WareHouseDetailForm_Load(object sender, EventArgs e)
        {
            LoadPhieuNhapDetails();
        }

        private void SetupGridColumns()
        {
            dgvDetails.Columns.Clear();

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSach",
                HeaderText = "Tên sách",
                DataPropertyName = "TenSach",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
        }

        private void LoadPhieuNhapDetails()
        {
            try
            {
                _phieuNhap = WareHouseRepository.GetWareHouse(_pnId);
                if (_phieuNhap == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                lblPnId.Text = $"Mã PN: {_phieuNhap.PnId}";
                lblNguoiNhap.Text = $"Người nhập: {_phieuNhap.TenNguoiNhap}";
                lblNgayNhap.Text = $"Ngày nhập: {_phieuNhap.NgayNhap:dd/MM/yyyy HH:mm}";
                lblNXB.Text = $"NXB: {_phieuNhap.TenNXB}";
                lblTongTien.Text = $"Tổng tiền: {_phieuNhap.TongTien:N0} đ";

                dgvDetails.Rows.Clear();

                foreach (var ct in _phieuNhap.ChiTietPhieuNhaps)
                {
                    dgvDetails.Rows.Add(ct.TenSach ?? string.Empty, ct.DonGia.ToString("N0") + " đ", ct.SoLuong, ct.ThanhTien.ToString("N0") + " đ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
