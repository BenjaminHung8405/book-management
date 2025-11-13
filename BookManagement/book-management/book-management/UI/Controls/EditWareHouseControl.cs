using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.Models;

namespace book_management.UI.Controls
{
    public partial class EditWareHouseControl : Form
    {
        private readonly int _wareHouseId;
        private PhieuNhap _currentWareHouse;
        private List<ChiTietPhieuNhap> _detailList;

        public EditWareHouseControl(int wareHouseId)
        {
            _wareHouseId = wareHouseId;
            InitializeComponent();
            LoadWareHouseData();
        }

        private void LoadWareHouseData()
        {
            try
            {
                _currentWareHouse = WareHouseRepository.GetWareHouse(_wareHouseId);
                _detailList = WareHouseDetailRepository.GetDetailsByPhieuNhapId(_wareHouseId) ?? new List<ChiTietPhieuNhap>();

                if (_currentWareHouse != null)
                {
                    txtWareHouseId.Text = _currentWareHouse.PnId.ToString();
                    dtpNgayLap.Value = _currentWareHouse.NgayNhap;
                    txtNguoiLap.Text = _currentWareHouse.TenNguoiNhap;

                    // Map status to user friendly text if you have TrangThai in PhieuNhap
                    if (!string.IsNullOrEmpty(_currentWareHouse.GetType().GetProperty("TrangThai")?.GetValue(_currentWareHouse)?.ToString()))
                    {
                        var val = _currentWareHouse.GetType().GetProperty("TrangThai")?.GetValue(_currentWareHouse)?.ToString();
                        if (val == "DaNhap") cmbTrangThai.SelectedItem = "Đã nhập";
                        else if (val == "ChuaNhap") cmbTrangThai.SelectedItem = "Chưa nhập";
                        else cmbTrangThai.SelectedIndex =0;
                    }

                    LoadDetailList();
                    UpdateTotalAmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu phiếu kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDetailList()
        {
            dgvChiTiet.Rows.Clear();
            if (_detailList == null) return;

            foreach (var item in _detailList)
            {
                var productName = item.Sach != null ? item.Sach.TenSach : string.Empty;
                var publisher = item.Sach?.NhaXuatBan?.TenNxb ?? string.Empty;
                dgvChiTiet.Rows.Add(
                    item.SachId,
                    productName,
                    publisher,
                    item.SoLuong,
                    item.DonGia.ToString("N0"),
                    item.ThanhTien.ToString("N0")
                );
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = _detailList?.Sum(x => x.ThanhTien) ??0m;
            txtTongTien.Text = total.ToString("N0") + " đ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    _currentWareHouse.NgayNhap = dtpNgayLap.Value;
                    _currentWareHouse.TenNguoiNhap = txtNguoiLap.Text.Trim();

                    // If PhieuNhap does not have TrangThai property this will be ignored
                    var selected = cmbTrangThai.SelectedItem?.ToString() ?? string.Empty;
                    var propTrangThai = _currentWareHouse.GetType().GetProperty("TrangThai");
                    if (propTrangThai != null)
                    {
                        propTrangThai.SetValue(_currentWareHouse, selected == "Đã nhập" ? "DaNhap" : "ChuaNhap");
                    }

                    _currentWareHouse.TongTien = _detailList?.Sum(x => x.ThanhTien) ??0m;

                    WareHouseRepository.UpdateWareHouse(_currentWareHouse);

                    MessageBox.Show("Cập nhật phiếu kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phiếu kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNguoiLap.Text))
            {
                MessageBox.Show("Vui lòng nhập người lập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiLap.Focus();
                return false;
            }
            if (cmbTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTrangThai.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                int sachId = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["ProductId"].Value);
                var detail = _detailList.FirstOrDefault(x => x.SachId == sachId);

                if (detail != null)
                {
                    using (var inputForm = new QuantityInputDialog(detail.SoLuong))
                    {
                        if (inputForm.ShowDialog() == DialogResult.OK)
                        {
                            int newQuantity = inputForm.Quantity;
                            if (newQuantity >0)
                            {
                                detail.SoLuong = newQuantity;
                                detail.ThanhTien = detail.DonGia * newQuantity;

                                LoadDetailList();
                                UpdateTotalAmount();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng phải lớn hơn0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                int sachId = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["ProductId"].Value);

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi phiếu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _detailList.RemoveAll(x => x.SachId == sachId);
                    LoadDetailList();
                    UpdateTotalAmount();
                }
            }
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format tiền tệ cho các cột (Đơn giá, Thành tiền)
            var colName = dgvChiTiet.Columns[e.ColumnIndex].Name;
            if ((colName == "colUnitPrice" || colName == "colTotalPrice") && e.Value != null)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}