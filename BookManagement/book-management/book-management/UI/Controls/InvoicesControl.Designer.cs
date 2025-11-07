using System;
using System.Drawing;
using System.Windows.Forms;
using book_management.UI.Theme;
using FontAwesome.Sharp;

namespace book_management.UI.Controls
{
    // Đảm bảo có 'partial'
    partial class InvoicesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        // SỬA LỖI: Đây là code giao diện của bạn
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

        // --- TOÀN BỘ CODE TẠO GIAO DIỆN ---
        private void CreateTopPanel()
        {
            var lblTitle = new Label
            {
                Text = "QUẢN LÝ HÓA ĐƠN",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = AppColors.Primary,
                Location = new Point(10, 10),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Location = new Point(10, 45),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10),
            };

            cmbStatusFilter = new ComboBox
            {
                Location = new Point(220, 45),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatusFilter.Items.AddRange(new string[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cmbStatusFilter.SelectedIndex = 0;

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

            btnSearch = new IconButton
            {
                Location = new Point(740, 45),
                Size = new Size(80, 30),
                Text = "Tìm kiếm",
                BackColor = AppColors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnAddInvoice = new IconButton
            {
                Location = new Point(830, 45),
                Size = new Size(100, 30),
                Text = "Tạo hóa đơn",
                BackColor = AppColors.SuccessGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnRefresh = new IconButton
            {
                Location = new Point(940, 45),
                Size = new Size(80, 30),
                Text = "Làm mới",
                BackColor = AppColors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

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
                RowTemplate = { Height = 40 },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10.5F),
                    Padding = new Padding(5, 0, 5, 0)
                }
            };

            dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = AppColors.Primary;
            dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInvoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInvoices.Columns.Add("HoaDonId", "Mã HD");
            dgvInvoices.Columns.Add("NgayLap", "Ngày lập");
            dgvInvoices.Columns.Add("TenNguoiMua", "Khách hàng");
            dgvInvoices.Columns.Add("TongTien", "Tổng tiền");
            dgvInvoices.Columns.Add("TrangThai", "Trạng thái");
            dgvInvoices.Columns.Add("NguoiLap", "Người lập");

            var colViewDetail = new DataGridViewButtonColumn
            {
                Name = "ViewDetail",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true
            };
            dgvInvoices.Columns.Add(colViewDetail);

            var colEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "Sửa",
                UseColumnTextForButtonValue = true
            };
            dgvInvoices.Columns.Add(colEdit);

            var colDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true
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
            dgvInvoices.Columns["TenNguoiMua"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvInvoices.Columns["HoaDonId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TenNguoiMua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NgayLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns["NguoiLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        #endregion

        // Khai báo các control
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
    }
}