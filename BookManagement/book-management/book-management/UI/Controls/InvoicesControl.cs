using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using book_management.Data;
using book_management.DataAccess;
using book_management.Models;
using book_management.UI.Theme;
using FontAwesome.Sharp;

namespace book_management.UI.Controls
{
    public partial class InvoicesControl : UserControl
    {
      

        // SỬA LỖI: Di chuyển dòng này từ trong hàm ra ngoài đây
        private string placeholderText = "Tìm theo mã HD, tên khách...";

        // --- CÁC HÀM (METHODS) ---
        private DataGridView dgvInvoices;
        private Panel panelTop;
        private Panel panelMain;
        private TextBox txtSearch;
        private ComboBox cmbStatusFilter;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private IconButton btnSearch;
        private IconButton btnAddInvoice;
        private IconButton btnRefresh;
        private Label lblTotalAmount;
        private Label lblTotalInvoices;

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 1;

        public InvoicesControl()
        {
            InitializeComponent();
            LoadInvoices();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Main panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            // Top panel for search and filters
            panelTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            CreateTopPanel();
            CreateDataGridView();
            CreateSummaryPanel();

            panelMain.Controls.Add(dgvInvoices);
            this.Controls.Add(panelMain);
            this.Controls.Add(panelTop);

            this.ResumeLayout(false);
        }

        private void CreateTopPanel()
        {
            // Title
            var lblTitle = new Label
            {
                Text = "QUẢN LÝ HÓA ĐƠN",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = AppColors.Primary,
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Search textbox
            txtSearch = new TextBox
            {
                Location = new Point(10, 45),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10),
            };
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            TxtSearch_LostFocus(txtSearch, null);

            // Thêm control vào Form
            this.Controls.Add(txtSearch);
            // Status filter
            cmbStatusFilter = new ComboBox
            {
                Location = new Point(220, 45),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatusFilter.Items.AddRange(new string[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cmbStatusFilter.SelectedIndex = 0;

            // Date filters
            var lblFromDate = new Label
            {
                Text = "Từ ngày:",
                Location = new Point(350, 45),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleLeft
            };

            dtpFromDate = new DateTimePicker
            {
                Location = new Point(410, 45),
                Size = new Size(120, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddMonths(-1)
            };

            var lblToDate = new Label
            {
                Text = "Đến ngày:",
                Location = new Point(540, 45),
                Size = new Size(70, 25),
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleLeft
            };

            dtpToDate = new DateTimePicker
            {
                Location = new Point(610, 45),
                Size = new Size(120, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            // Buttons
            btnSearch = new IconButton
            {
                Location = new Point(740, 45),
                Size = new Size(80, 30),
                Text = "Tìm kiếm",
                BackColor = AppColors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.Click += BtnSearch_Click;

            btnAddInvoice = new IconButton
            {
                Location = new Point(830, 45),
                Size = new Size(100, 30),
                Text = "Tạo hóa đơn",
                BackColor = AppColors.SuccessGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddInvoice.Click += BtnAddInvoice_Click;

            btnRefresh = new IconButton
            {
                Location = new Point(940, 45),
                Size = new Size(80, 30),
                Text = "Làm mới",
                BackColor = AppColors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += BtnRefresh_Click;

            // Summary labels
            lblTotalInvoices = new Label
            {
                Location = new Point(10, 85),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = AppColors.Primary
            };

            lblTotalAmount = new Label
            {
                Location = new Point(220, 85),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = AppColors.SuccessGreen
            };

            panelTop.Controls.AddRange(new Control[] {
     lblTitle, txtSearch, cmbStatusFilter,
                lblFromDate, dtpFromDate, lblToDate, dtpToDate,
       btnSearch, btnAddInvoice, btnRefresh,
                lblTotalInvoices, lblTotalAmount
        });
        }
        /// <summary>
        /// Xử lý khi người dùng nhấp vào TextBox
        /// </summary>
        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // Nếu text đang là placeholder thì xóa đi
            if (tb.Text == placeholderText)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black; // Đổi về màu chữ bình thường
            }
        }

        /// <summary>
        /// Xử lý khi người dùng nhấp ra ngoài TextBox
        /// </summary>
        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // Nếu text đang rỗng thì đặt lại placeholder
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholderText;
                tb.ForeColor = Color.Gray; // Đổi sang màu mờ
            }
        }
        private void CreateDataGridView()
        {
            dgvInvoices = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 40 }, // Chiều cao dòng
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10.5F), // Tăng Font chữ
                    Padding = new Padding(5, 0, 5, 0)   // Thêm đệm trái/phải
                }
            };

            // Style the header
            dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = AppColors.Primary;
            dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInvoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Add columns
            dgvInvoices.Columns.Add("HoaDonId", "Mã HD");
            dgvInvoices.Columns.Add("NgayLap", "Ngày lập");
            dgvInvoices.Columns.Add("TenNguoiMua", "Khách hàng");
            dgvInvoices.Columns.Add("TongTien", "Tổng tiền");
            dgvInvoices.Columns.Add("TrangThai", "Trạng thái");
            dgvInvoices.Columns.Add("NguoiLap", "Người lập");

            // Add action buttons
            var colViewDetail = new DataGridViewButtonColumn
            {
                Name = "ViewDetail",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvInvoices.Columns.Add(colViewDetail);

            var colEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "Sửa",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvInvoices.Columns.Add(colEdit);

            var colDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvInvoices.Columns.Add(colDelete);

            dgvInvoices.Columns["HoaDonId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["NgayLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["TongTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["NguoiLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["ViewDetail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInvoices.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Cột "Khách hàng" sẽ lấp đầy phần còn trống
            dgvInvoices.Columns["TenNguoiMua"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // SỬA 4: Thêm khối Căn chỉnh (Alignment)
            dgvInvoices.Columns["HoaDonId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TenNguoiMua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NgayLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tiền tệ nên được căn phải
            dgvInvoices.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInvoices.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NguoiLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Gán sự kiện (Giữ nguyên)
            dgvInvoices.CellClick += DgvInvoices_CellClick;
            dgvInvoices.CellFormatting += DgvInvoices_CellFormatting;
        }

        private void CreateSummaryPanel()
        {
            var panelSummary = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = AppColors.ContentBackground
            };

            panelMain.Controls.Add(panelSummary);
        }

        private void LoadInvoices()
        {
            try
            {
                var invoices = HoaDonRepository.GetAllInvoices();

                dgvInvoices.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var invoice in invoices)
                {
                    dgvInvoices.Rows.Add(
                    invoice.HoaDonId,
                    invoice.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    invoice.TenNguoiMua,
                    invoice.TongTien.ToString("N0") + " đ",
                    invoice.TrangThai,
                    invoice.NguoiLap
                   );
                    totalAmount += invoice.TongTien;
                }

                UpdateSummary(invoices.Count, totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary(int totalInvoices, decimal totalAmount)
        {
            lblTotalInvoices.Text = $"Tổng số hóa đơn: {totalInvoices}";
            lblTotalAmount.Text = $"Tổng doanh thu: {totalAmount:N0} đ";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchInvoices();
        }

        private void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            // Open create invoice form
            MessageBox.Show("Chức năng tạo hóa đơn sẽ được phát triển trong phiên bản sau",
      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void SearchInvoices()
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                var status = cmbStatusFilter.SelectedItem?.ToString();
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1);

                var invoices = HoaDonRepository.SearchInvoices(searchTerm, status, fromDate, toDate);

                dgvInvoices.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var invoice in invoices)
                {
                    dgvInvoices.Rows.Add(
                    invoice.HoaDonId,
                    invoice.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    invoice.TenNguoiMua,
                    invoice.TongTien.ToString("N0") + " đ",
                    invoice.TrangThai,
                    invoice.NguoiLap
                    );
                    totalAmount += invoice.TongTien;
                }

                UpdateSummary(invoices.Count, totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}",
                         "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var hoaDonId = Convert.ToInt32(dgvInvoices.Rows[e.RowIndex].Cells["HoaDonId"].Value);

            switch (dgvInvoices.Columns[e.ColumnIndex].Name)
            {
                case "ViewDetail":
                    ViewInvoiceDetail(hoaDonId);
                    break;
                case "Edit":
                    EditInvoice(hoaDonId);
                    break;
                case "Delete":
                    DeleteInvoice(hoaDonId);
                    break;
            }
        }

        private void DgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoices.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                var status = e.Value.ToString();
                switch (status)
                {
                    case "DaThanhToan":
                        e.Value = "Đã thanh toán";
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "ChuaThanhToan":
                        e.Value = "Chưa thanh toán";
                        e.CellStyle.BackColor = Color.LightYellow;
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        break;
                    case "DaHuy":
                        e.Value = "Đã hủy";
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }

        private void ViewInvoiceDetail(int hoaDonId)
        {
            try
            {
                var chiTietList = ChiTietHoaDonRepository.GetChiTietByHoaDonId(hoaDonId);
                var detailForm = new InvoiceDetailForm(hoaDonId, chiTietList);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}",
                     "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditInvoice(int hoaDonId)
        {
            MessageBox.Show($"Chức năng sửa hóa đơn {hoaDonId} sẽ được phát triển",
      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteInvoice(int hoaDonId)
        {
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {hoaDonId}?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HoaDonRepository.DeleteInvoice(hoaDonId);
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}",
              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
