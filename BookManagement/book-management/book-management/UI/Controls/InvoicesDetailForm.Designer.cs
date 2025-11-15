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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvDetailsGrid = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInvoiceInfo = new System.Windows.Forms.Panel();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblNgayLapValue = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblKhachHangValue = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTrangThaiValue = new System.Windows.Forms.Label();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.lblNguoiLapValue = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.rightButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsGrid)).BeginInit();
            this.pnlInvoiceInfo.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.rightButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.dgvDetailsGrid);
            this.mainPanel.Controls.Add(this.pnlInvoiceInfo);
            this.mainPanel.Controls.Add(this.pnlSummary);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(16);
            this.mainPanel.Size = new System.Drawing.Size(900, 700);
            this.mainPanel.TabIndex = 0;
            // 
            // dgvDetailsGrid
            // 
            this.dgvDetailsGrid.AllowUserToAddRows = false;
            this.dgvDetailsGrid.AllowUserToDeleteRows = false;
            this.dgvDetailsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDetailsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvDetailsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetailsGrid.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(196)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvDetailsGrid.ColumnHeadersHeight = 48;
            this.dgvDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TenSach,
            this.SoLuong,
            this.DonGia,
            this.TienGiam,
            this.ThanhTien});
            this.dgvDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailsGrid.EnableHeadersVisualStyles = false;
            this.dgvDetailsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.dgvDetailsGrid.Location = new System.Drawing.Point(16, 192);
            this.dgvDetailsGrid.MultiSelect = false;
            this.dgvDetailsGrid.Name = "dgvDetailsGrid";
            this.dgvDetailsGrid.ReadOnly = true;
            this.dgvDetailsGrid.RowHeadersVisible = false;
            this.dgvDetailsGrid.RowTemplate.Height = 42;
            this.dgvDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailsGrid.Size = new System.Drawing.Size(868, 428);
            this.dgvDetailsGrid.TabIndex = 0;
            // 
            // STT
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.STT.DefaultCellStyle = dataGridViewCellStyle19;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenSach
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TenSach.DefaultCellStyle = dataGridViewCellStyle20;
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            // 
            // SoLuong
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle21;
            this.SoLuong.HeaderText = "SL";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle22;
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // TienGiam
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TienGiam.DefaultCellStyle = dataGridViewCellStyle23;
            this.TienGiam.HeaderText = "Giảm giá";
            this.TienGiam.Name = "TienGiam";
            this.TienGiam.ReadOnly = true;
            // 
            // ThanhTien
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ThanhTien.DefaultCellStyle = dataGridViewCellStyle24;
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // pnlInvoiceInfo
            // 
            this.pnlInvoiceInfo.BackColor = System.Drawing.Color.White;
            this.pnlInvoiceInfo.Controls.Add(this.lblNgayLap);
            this.pnlInvoiceInfo.Controls.Add(this.lblNgayLapValue);
            this.pnlInvoiceInfo.Controls.Add(this.lblKhachHang);
            this.pnlInvoiceInfo.Controls.Add(this.lblKhachHangValue);
            this.pnlInvoiceInfo.Controls.Add(this.lblTrangThai);
            this.pnlInvoiceInfo.Controls.Add(this.lblTrangThaiValue);
            this.pnlInvoiceInfo.Controls.Add(this.lblNguoiLap);
            this.pnlInvoiceInfo.Controls.Add(this.lblNguoiLapValue);
            this.pnlInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInvoiceInfo.Location = new System.Drawing.Point(16, 72);
            this.pnlInvoiceInfo.Name = "pnlInvoiceInfo";
            this.pnlInvoiceInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInvoiceInfo.Size = new System.Drawing.Size(868, 120);
            this.pnlInvoiceInfo.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLap.Location = new System.Drawing.Point(8, 8);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(66, 19);
            this.lblNgayLap.TabIndex = 0;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // lblNgayLapValue
            // 
            this.lblNgayLapValue.AutoSize = true;
            this.lblNgayLapValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayLapValue.Location = new System.Drawing.Point(90, 6);
            this.lblNgayLapValue.Name = "lblNgayLapValue";
            this.lblNgayLapValue.Size = new System.Drawing.Size(0, 19);
            this.lblNgayLapValue.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhachHang.Location = new System.Drawing.Point(8, 36);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(84, 19);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // lblKhachHangValue
            // 
            this.lblKhachHangValue.AutoSize = true;
            this.lblKhachHangValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhachHangValue.Location = new System.Drawing.Point(90, 34);
            this.lblKhachHangValue.Name = "lblKhachHangValue";
            this.lblKhachHangValue.Size = new System.Drawing.Size(0, 19);
            this.lblKhachHangValue.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(420, 8);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(73, 19);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // lblTrangThaiValue
            // 
            this.lblTrangThaiValue.AutoSize = true;
            this.lblTrangThaiValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiValue.Location = new System.Drawing.Point(500, 6);
            this.lblTrangThaiValue.Name = "lblTrangThaiValue";
            this.lblTrangThaiValue.Size = new System.Drawing.Size(0, 19);
            this.lblTrangThaiValue.TabIndex = 5;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiLap.Location = new System.Drawing.Point(420, 36);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(71, 19);
            this.lblNguoiLap.TabIndex = 6;
            this.lblNguoiLap.Text = "Người lập:";
            // 
            // lblNguoiLapValue
            // 
            this.lblNguoiLapValue.AutoSize = true;
            this.lblNguoiLapValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiLapValue.Location = new System.Drawing.Point(500, 34);
            this.lblNguoiLapValue.Name = "lblNguoiLapValue";
            this.lblNguoiLapValue.Size = new System.Drawing.Size(0, 19);
            this.lblNguoiLapValue.TabIndex = 7;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSummary.Controls.Add(this.lblTongTien);
            this.pnlSummary.Controls.Add(this.rightButtons);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(16, 620);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSummary.Size = new System.Drawing.Size(868, 64);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(196)))));
            this.lblTongTien.Location = new System.Drawing.Point(300, 8);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(300, 48);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rightButtons
            // 
            this.rightButtons.Controls.Add(this.btnClose);
            this.rightButtons.Controls.Add(this.btnPrint);
            this.rightButtons.Controls.Add(this.btnExport);
            this.rightButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.rightButtons.Location = new System.Drawing.Point(600, 8);
            this.rightButtons.Name = "rightButtons";
            this.rightButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.rightButtons.Size = new System.Drawing.Size(260, 48);
            this.rightButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(98, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(196)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(98, 20);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 32);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In";
            this.toolTip1.SetToolTip(this.btnPrint, "In hóa đơn");
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(196)))));
            this.btnExport.Location = new System.Drawing.Point(164, 68);
            this.btnExport.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 32);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.toolTip1.SetToolTip(this.btnExport, "Export danh sách chi tiết (CSV)");
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(88)))), ((int)(((byte)(196)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(868, 56);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "CHI TIẾT HÓA ĐƠN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InvoiceDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.mainPanel);
            this.Name = "InvoiceDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsGrid)).EndInit();
            this.pnlInvoiceInfo.ResumeLayout(false);
            this.pnlInvoiceInfo.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.rightButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn TenSach;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn TienGiam;
        private DataGridViewTextBoxColumn ThanhTien;
        private Label lblNgayLap;
        private Label lblKhachHang;
        private Label lblTrangThai;
        private Label lblNguoiLap;
        private FlowLayoutPanel rightButtons;
    }
}