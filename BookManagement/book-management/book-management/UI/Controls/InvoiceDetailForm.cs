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
            LoadInvoiceInfo();
            LoadInvoiceDetails();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InvoiceDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "InvoiceDetailForm";
            this.ResumeLayout(false);

        }

        private void CreateControls()
        {
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // Title
            var lblTitle = new Label
            {
                Text = $"CHI TIẾT HÓA ĐƠN #{_hoaDonId}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = AppColors.Primary,
                Location = new Point(0, 0),
                Size = new Size(400, 40),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Invoice info panel
            var pnlInvoiceInfo = CreateInvoiceInfoPanel();
            pnlInvoiceInfo.Location = new Point(0, 50);

            // Details grid
            var dgvDetails = CreateDetailsGrid();
            dgvDetails.Location = new Point(0, 200);
            dgvDetails.Size = new Size(840, 350);

            // Summary panel
            var pnlSummary = CreateSummaryPanel();
            pnlSummary.Location = new Point(0, 560);

            // Close button
            var btnClose = new Button
            {
                Text = "Đóng",
                Size = new Size(100, 35),
                Location = new Point(740, 610),
                BackColor = AppColors.TextPrimary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.Click += (s, e) => this.Close();

            mainPanel.Controls.AddRange(new Control[] {
          lblTitle, pnlInvoiceInfo, dgvDetails, pnlSummary, btnClose
            });

            this.Controls.Add(mainPanel);
        }

        private Panel CreateInvoiceInfoPanel()
        {
            var panel = new Panel
            {
                Size = new Size(840, 140),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.AliceBlue
            };

            var lblNgayLap = new Label
            {
                Text = "Ngày lập:",
                Location = new Point(10, 10),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblNgayLapValue = new Label
            {
                Name = "lblNgayLapValue",
                Location = new Point(100, 10),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10)
            };

            var lblKhachHang = new Label
            {
                Text = "Khách hàng:",
                Location = new Point(10, 40),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblKhachHangValue = new Label
            {
                Name = "lblKhachHangValue",
                Location = new Point(100, 40),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 10)
            };

            var lblTrangThai = new Label
            {
                Text = "Trạng thái:",
                Location = new Point(420, 10),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblTrangThaiValue = new Label
            {
                Name = "lblTrangThaiValue",
                Location = new Point(510, 10),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblNguoiLap = new Label
            {
                Text = "Người lập:",
                Location = new Point(420, 40),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblNguoiLapValue = new Label
            {
                Name = "lblNguoiLapValue",
                Location = new Point(510, 40),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10)
            };

            var txtGhiChu = new TextBox
            {
                Name = "txtGhiChu",
                Location = new Point(80, 70),
                Size = new Size(740, 60),
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };

            panel.Controls.AddRange(new Control[] {
         lblNgayLap, lblNgayLapValue,
        lblKhachHang, lblKhachHangValue,
     lblTrangThai, lblTrangThaiValue,
        lblNguoiLap, lblNguoiLapValue,
      
            });

            return panel;
        }

        private DataGridView CreateDetailsGrid()
        {
            var dgv = new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 }
            };

            // Style header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppColors.Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Add columns
            dgv.Columns.Add("STT", "STT");
            dgv.Columns.Add("TenSach", "Tên sách");
            dgv.Columns.Add("SoLuong", "SL");
            dgv.Columns.Add("DonGia", "Đơn giá");
            dgv.Columns.Add("TienGiam", "Giảm giá");
            dgv.Columns.Add("ThanhTien", "Thành tiền");

            // Set column widths
            dgv.Columns["STT"].Width = 50;
            dgv.Columns["TenSach"].Width = 300;
            dgv.Columns["SoLuong"].Width = 80;
            dgv.Columns["DonGia"].Width = 120;
            dgv.Columns["TienGiam"].Width = 120;
            dgv.Columns["ThanhTien"].Width = 150;

            // Style numeric columns
            dgv.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TienGiam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            return dgv;
        }

        private Panel CreateSummaryPanel()
        {
            var panel = new Panel
            {
                Size = new Size(840, 40),
                BackColor = Color.LightGray
            };

            var lblTongTien = new Label
            {
                Name = "lblTongTien",
                Location = new Point(600, 10),
                Size = new Size(230, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = AppColors.Primary,
                TextAlign = ContentAlignment.MiddleRight
            };

            panel.Controls.Add(lblTongTien);
            return panel;
        }

        private void LoadInvoiceInfo()
        {
            try
            {
                _hoaDon = HoaDonRepository.GetInvoiceById(_hoaDonId);
                if (_hoaDon != null)
                {
                    var lblNgayLapValue = this.Controls.Find("lblNgayLapValue", true)[0] as Label;
                    var lblKhachHangValue = this.Controls.Find("lblKhachHangValue", true)[0] as Label;
                    var lblTrangThaiValue = this.Controls.Find("lblTrangThaiValue", true)[0] as Label;
                    var lblNguoiLapValue = this.Controls.Find("lblNguoiLapValue", true)[0] as Label;

                    lblNgayLapValue.Text = _hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm");
                    lblKhachHangValue.Text = _hoaDon.TenNguoiMua;
                    lblNguoiLapValue.Text = _hoaDon.NguoiLap;

                    lblTrangThaiValue.Text = _hoaDon.TrangThai;
                    switch (_hoaDon.TrangThai)
                    {
                        case "Đã thanh toán":
                            lblTrangThaiValue.ForeColor = Color.Green;
                            break;
                        case "Chưa thanh toán":
                            lblTrangThaiValue.ForeColor = Color.Orange;
                            break;
                        case "Đã hủy":
                            lblTrangThaiValue.ForeColor = Color.Red;
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
                var dgv = this.Controls.Find("", true).OfType<DataGridView>().FirstOrDefault();
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

                    var lblTongTien = this.Controls.Find("lblTongTien", true)[0] as Label;
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