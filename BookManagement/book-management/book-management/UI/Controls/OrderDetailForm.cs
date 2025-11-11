using System;
using System.Windows.Forms;
using book_management.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace book_management.UI
{
    public partial class OrderDetailForm : Form
    {
        private List<ChiTietHoaDon> _chiTietHD;

        public OrderDetailForm(List<ChiTietHoaDon> chiTietHD)
        {
            InitializeComponent(); // Gọi từ Designer.cs
            _chiTietHD = chiTietHD;
            SetupDataGridView(); // Setup columns
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails(); // Load data sau khi form đã load
        }

        private void SetupDataGridView()
        {
            try
            {
                // Clear existing columns nếu có
                dgvDetail.Columns.Clear();

                // Add columns
                dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenSach",
                    HeaderText = "Tên sách",
                    DataPropertyName = "TenSach",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 40
                });

                dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "DonGia",
                    HeaderText = "Đơn giá",
                    DataPropertyName = "DonGia",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0"
                    }
                });

                dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoLuong",
                    HeaderText = "Số lượng",
                    DataPropertyName = "SoLuong",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });

                dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "GiamGia",
                    HeaderText = "Giảm giá",
                    DataPropertyName = "TienGiam",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0"
                    }
                });

                dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThanhTien",
                    HeaderText = "Thành tiền",
                    DataPropertyName = "ThanhTien",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0",
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    }
                });

                // Style the header
                dgvDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
                dgvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDetail.EnableHeadersVisualStyles = false;

                // Row styling
                dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgvDetail.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                dgvDetail.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi setup DataGridView: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderDetails()
        {
            try
            {
                if (dgvDetail == null || _chiTietHD == null) return;

                dgvDetail.Rows.Clear();

                foreach (var item in _chiTietHD)
                {
                    dgvDetail.Rows.Add(
                        item.TenSach ?? "",
                        item.DonGia.ToString("N0") + " đ",
                        item.SoLuong,
                        item.TienGiam.ToString("N0") + " đ",
                        item.ThanhTien.ToString("N0") + " đ"
                    );
                }

                // Add summary row
                if (_chiTietHD.Count > 0)
                {
                    decimal tongTien = _chiTietHD.Sum(x => x.ThanhTien);
                    decimal tongGiam = _chiTietHD.Sum(x => x.TienGiam);
                    int tongSoLuong = _chiTietHD.Sum(x => x.SoLuong);

                    // Add empty row for spacing
                    dgvDetail.Rows.Add("", "", "", "", "");

                    // Add summary row
                    var summaryRow = dgvDetail.Rows.Add(
                        "TỔNG CỘNG",
                        "",
                        tongSoLuong,
                        tongGiam.ToString("N0") + " đ",
                        tongTien.ToString("N0") + " đ"
                    );

                    // Style summary row
                    dgvDetail.Rows[summaryRow].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgvDetail.Rows[summaryRow].DefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}