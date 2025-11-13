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
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.BackColor = System.Drawing.Color.White;

            // lblTitle
            // use standard property assignments to keep designer happy
            this.lblTitle.AutoSize = false;
            this.lblTitle.Text = "CHI TIẾT HÓA ĐƠN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI",16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(74,144,226);
            this.lblTitle.Location = new System.Drawing.Point(0,0);
            this.lblTitle.Size = new System.Drawing.Size(400,40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlInvoiceInfo
            this.pnlInvoiceInfo.Location = new System.Drawing.Point(5,50);
            this.pnlInvoiceInfo.Size = new System.Drawing.Size(840,140);
            this.pnlInvoiceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInvoiceInfo.BackColor = System.Drawing.Color.AliceBlue;

            // labels inside pnlInvoiceInfo
            Label lblNgayLap = new Label();
            lblNgayLap.Text = "Ngày lập:";
            lblNgayLap.Location = new System.Drawing.Point(10,10);
            lblNgayLap.Size = new System.Drawing.Size(80,25);
            lblNgayLap.Font = new System.Drawing.Font("Segoe UI",12F, System.Drawing.FontStyle.Bold);

            this.lblNgayLapValue.Location = new System.Drawing.Point(100,10);
            this.lblNgayLapValue.Size = new System.Drawing.Size(200,25);
            this.lblNgayLapValue.Font = new System.Drawing.Font("Segoe UI",12F);

            Label lblKhachHang = new Label();
            lblKhachHang.Text = "Khách hàng:";
            lblKhachHang.Location = new System.Drawing.Point(10,40);
            lblKhachHang.Size = new System.Drawing.Size(80,25);
            lblKhachHang.Font = new System.Drawing.Font("Segoe UI",12F, System.Drawing.FontStyle.Bold);

            this.lblKhachHangValue.Location = new System.Drawing.Point(100,40);
            this.lblKhachHangValue.Size = new System.Drawing.Size(300,25);
            this.lblKhachHangValue.Font = new System.Drawing.Font("Segoe UI",12F);

            Label lblTrangThai = new Label();
            lblTrangThai.Text = "Trạng thái:";
            lblTrangThai.Location = new System.Drawing.Point(420,10);
            lblTrangThai.Size = new System.Drawing.Size(80,25);
            lblTrangThai.Font = new System.Drawing.Font("Segoe UI",12F, System.Drawing.FontStyle.Bold);

            this.lblTrangThaiValue.Location = new System.Drawing.Point(510,10);
            this.lblTrangThaiValue.Size = new System.Drawing.Size(150,25);
            this.lblTrangThaiValue.Font = new System.Drawing.Font("Segoe UI",12F, System.Drawing.FontStyle.Bold);

            Label lblNguoiLap = new Label();
            lblNguoiLap.Text = "Người lập:";
            lblNguoiLap.Location = new System.Drawing.Point(420,40);
            lblNguoiLap.Size = new System.Drawing.Size(80,25);
            lblNguoiLap.Font = new System.Drawing.Font("Segoe UI",12F, System.Drawing.FontStyle.Bold);

            this.lblNguoiLapValue.Location = new System.Drawing.Point(510,40);
            this.lblNguoiLapValue.Size = new System.Drawing.Size(200,25);
            this.lblNguoiLapValue.Font = new System.Drawing.Font("Segoe UI",12F);

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
            this.dgvDetailsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailsGrid.ColumnHeadersHeight =60;
            this.dgvDetailsGrid.Location = new System.Drawing.Point(5,170);
            this.dgvDetailsGrid.Size = new System.Drawing.Size(840,350);

            // Style header
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(74,144,226);
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",13F, System.Drawing.FontStyle.Bold);
            this.dgvDetailsGrid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Configure explicit columns
            // colSTT
            this.colSTT.Name = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSTT.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);
            this.colSTT.Width =50;

            // colTenSach
            this.colTenSach.Name = "TenSach";
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTenSach.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);

            // colSoLuong
            this.colSoLuong.Name = "SoLuong";
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);
            this.colSoLuong.Width =60;

            // colDonGia
            this.colDonGia.Name = "DonGia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);

            // colTienGiam
            this.colTienGiam.Name = "TienGiam";
            this.colTienGiam.HeaderText = "Giảm giá";
            this.colTienGiam.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTienGiam.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);

            // colThanhTien
            this.colThanhTien.Name = "ThanhTien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThanhTien.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI",12F);

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
            this.pnlSummary.Location = new System.Drawing.Point(0,560);
            this.pnlSummary.Size = new System.Drawing.Size(840,40);
            this.pnlSummary.BackColor = System.Drawing.Color.LightGray;

            this.lblTongTien.Location = new System.Drawing.Point(600,10);
            this.lblTongTien.Size = new System.Drawing.Size(230,25);
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI",13F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.FromArgb(74,144,226);
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlSummary.Controls.Add(this.lblTongTien);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(740,610);
            this.btnClose.Size = new System.Drawing.Size(100,35);
            this.btnClose.Text = "Đóng";
            this.btnClose.BackColor = Color.FromArgb(51,51,51);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Add controls to mainPanel
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.pnlInvoiceInfo);
            this.mainPanel.Controls.Add(this.dgvDetailsGrid);
            this.mainPanel.Controls.Add(this.pnlSummary);
            this.mainPanel.Controls.Add(this.btnClose);

            // Form
            this.ClientSize = new System.Drawing.Size(850,700);
            this.Controls.Add(this.mainPanel);
            this.Name = "InvoiceDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hóa đơn";

            this.pnlSummary.ResumeLayout(false);
            this.pnlInvoiceInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsGrid)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}