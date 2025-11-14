using System.Drawing;
using System.Windows.Forms;
using book_management.UI.Theme;

namespace book_management.UI.Controls
{
    // SỬA 1: Thêm 'partial'
    partial class InvoiceDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private Panel mainPanel;
        private Label lblTitle;
        private Panel pnlInvoiceInfo;
        private Label lblNgayLapValue;
        private Label lblKhachHangValue;
        private Label lblTrangThaiValue;
        private Label lblNguoiLapValue;
        private DataGridView dgvDetailsGrid;
        private Panel pnlSummary;
        private Label lblTongTien;
        private Button btnClose;
        private Button btnExport;
        private Button btnPrint;
        private ToolTip toolTip1;

        // DataGridView columns (explicitly declared for designer compatibility)
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInvoiceInfo = new System.Windows.Forms.Panel();
            this.lblNgayLapValue = new System.Windows.Forms.Label();
            this.lblKhachHangValue = new System.Windows.Forms.Label();
            this.lblTrangThaiValue = new System.Windows.Forms.Label();
            this.lblNguoiLapValue = new System.Windows.Forms.Label();
            this.dgvDetailsGrid = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip();

            // create explicit column instances
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // mainPanel
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsGrid)).BeginInit();
            this.pnlInvoiceInfo.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();

            // mainPanel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(16);
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Text = "CHI TIẾT HÓA ĐƠN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(34, 88, 196);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 56;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlInvoiceInfo
            this.pnlInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInvoiceInfo.Height = 120;
            this.pnlInvoiceInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlInvoiceInfo.BackColor = System.Drawing.Color.White;
            this.pnlInvoiceInfo.Padding = new System.Windows.Forms.Padding(10);

            // labels inside pnlInvoiceInfo - use small labels and value labels
            Label lblNgayLap = new Label();
            lblNgayLap.Text = "Ngày lập:";
            lblNgayLap.AutoSize = true;
            lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            lblNgayLap.Location = new System.Drawing.Point(8, 8);

            this.lblNgayLapValue.Location = new System.Drawing.Point(90, 6);
            this.lblNgayLapValue.AutoSize = true;
            this.lblNgayLapValue.Font = new System.Drawing.Font("Segoe UI", 10F);

            Label lblKhachHang = new Label();
            lblKhachHang.Text = "Khách hàng:";
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblKhachHang.Location = new System.Drawing.Point(8, 36);

            this.lblKhachHangValue.Location = new System.Drawing.Point(90, 34);
            this.lblKhachHangValue.AutoSize = true;
            this.lblKhachHangValue.Font = new System.Drawing.Font("Segoe UI", 10F);

            Label lblTrangThai = new Label();
            lblTrangThai.Text = "Trạng thái:";
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTrangThai.Location = new System.Drawing.Point(420, 8);

            this.lblTrangThaiValue.Location = new System.Drawing.Point(500, 6);
            this.lblTrangThaiValue.AutoSize = true;
            this.lblTrangThaiValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            Label lblNguoiLap = new Label();
            lblNguoiLap.Text = "Người lập:";
            lblNguoiLap.AutoSize = true;
            lblNguoiLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblNguoiLap.Location = new System.Drawing.Point(420, 36);

            this.lblNguoiLapValue.Location = new System.Drawing.Point(500, 34);
            this.lblNguoiLapValue.AutoSize = true;
            this.lblNguoiLapValue.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.pnlInvoiceInfo.Controls.Add(lblNgayLap);
            this.pnlInvoiceInfo.Controls.Add(this.lblNgayLapValue);
            this.pnlInvoiceInfo.Controls.Add(lblKhachHang);
            this.pnlInvoiceInfo.Controls.Add(this.lblKhachHangValue);
            this.pnlInvoiceInfo.Controls.Add(lblTrangThai);
            this.pnlInvoiceInfo.Controls.Add(this.lblTrangThaiValue);
            this.pnlInvoiceInfo.Controls.Add(lblNguoiLap);
            this.pnlInvoiceInfo.Controls.Add(this.lblNguoiLapValue);

            // dgvDetailsGrid
            this.dgvDetailsGrid.Name = "dgvDetailsGrid";
            this.dgvDetailsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailsGrid.MultiSelect = false;
            this.dgvDetailsGrid.AllowUserToAddRows = false;
            this.dgvDetailsGrid.AllowUserToDeleteRows = false;
            this.dgvDetailsGrid.ReadOnly = true;
            this.dgvDetailsGrid.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetailsGrid.ColumnHeadersHeight = 48;
            this.dgvDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailsGrid.EnableHeadersVisualStyles = false;
            this.dgvDetailsGrid.RowHeadersVisible = false;
            this.dgvDetailsGrid.AllowUserToResizeRows = false;
            this.dgvDetailsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 252);
            this.dgvDetailsGrid.GridColor = Color.FromArgb(236, 239, 241);

            // Style header
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 88, 196);
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDetailsGrid.RowTemplate.Height = 42;

            // Configure explicit columns
            // colSTT
            this.colSTT.Name = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSTT.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.colSTT.Width = 60;

            // colTenSach
            this.colTenSach.Name = "TenSach";
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTenSach.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // colSoLuong
            this.colSoLuong.Name = "SoLuong";
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.colSoLuong.Width = 70;

            // colDonGia
            this.colDonGia.Name = "DonGia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // colTienGiam
            this.colTienGiam.Name = "TienGiam";
            this.colTienGiam.HeaderText = "Giảm giá";
            this.colTienGiam.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTienGiam.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // colThanhTien
            this.colThanhTien.Name = "ThanhTien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThanhTien.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Add columns to grid
            this.dgvDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenSach,
            this.colSoLuong,
            this.colDonGia,
            this.colTienGiam,
            this.colThanhTien
            });

            // pnlSummary
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Height = 64;
            this.pnlSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(8);

            this.lblTongTien.Location = new System.Drawing.Point(0, 18);
            this.lblTongTien.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTongTien.AutoSize = false;
            this.lblTongTien.Width = 300;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.FromArgb(34, 88, 196);
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Right;

            // Export button
            this.btnExport.Text = "Export";
            this.btnExport.Width = 90;
            this.btnExport.Height = 32;
            this.btnExport.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.BackColor = Color.FromArgb(245, 245, 247);
            this.btnExport.ForeColor = Color.FromArgb(34, 88, 196);
            this.btnExport.Margin = new Padding(6, 8, 6, 8);
            this.toolTip1.SetToolTip(this.btnExport, "Export danh sách chi tiết (CSV)");

            // Print button
            this.btnPrint.Text = "In";
            this.btnPrint.Width = 60;
            this.btnPrint.Height = 32;
            this.btnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.BackColor = Color.FromArgb(34, 88, 196);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Margin = new Padding(6, 8, 6, 8);
            this.toolTip1.SetToolTip(this.btnPrint, "In hóa đơn");

            // Close button
            this.btnClose.Text = "Đóng";
            this.btnClose.Width = 90;
            this.btnClose.Height = 32;
            this.btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = Color.FromArgb(51, 51, 51);
            this.btnClose.ForeColor = Color.White;

            // Layout: add controls
            FlowLayoutPanel rightButtons = new FlowLayoutPanel();
            rightButtons.FlowDirection = FlowDirection.RightToLeft;
            rightButtons.Dock = DockStyle.Right;
            rightButtons.Width = 260;
            rightButtons.Padding = new Padding(0, 12, 0, 12);
            rightButtons.Controls.Add(this.btnClose);
            rightButtons.Controls.Add(this.btnPrint);
            rightButtons.Controls.Add(this.btnExport);

            this.pnlSummary.Controls.Add(this.lblTongTien);
            this.pnlSummary.Controls.Add(rightButtons);

            // Add controls to mainPanel
            this.mainPanel.Controls.Add(this.dgvDetailsGrid);
            this.mainPanel.Controls.Add(this.pnlInvoiceInfo);
            this.mainPanel.Controls.Add(this.pnlSummary);
            this.mainPanel.Controls.Add(this.lblTitle);

            // Form
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.mainPanel);
            this.Name = "InvoiceDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn";

            this.pnlSummary.ResumeLayout(false);
            this.pnlInvoiceInfo.ResumeLayout(false);
            this.pnlInvoiceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsGrid)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}