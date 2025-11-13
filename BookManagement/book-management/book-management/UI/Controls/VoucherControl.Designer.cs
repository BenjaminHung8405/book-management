namespace book_management.UI.Controls
{
    partial class VoucherControl
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
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchVoucher = new System.Windows.Forms.TextBox();
            this.btnAddBook = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.flowPaginationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.colTenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.panelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.panelMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(868, 13);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(179, 33);
            this.cmbStatusFilter.TabIndex = 3;
            // 
            // txtSearchVoucher
            // 
            this.txtSearchVoucher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearchVoucher.Location = new System.Drawing.Point(8, 14);
            this.txtSearchVoucher.Name = "txtSearchVoucher";
            this.txtSearchVoucher.Size = new System.Drawing.Size(849, 31);
            this.txtSearchVoucher.TabIndex = 0;
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAddBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddBook.IconColor = System.Drawing.Color.White;
            this.btnAddBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddBook.IconSize = 28;
            this.btnAddBook.Location = new System.Drawing.Point(1054, 4);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(178, 52);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Thêm voucher mới";
            this.btnAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cmbStatusFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchVoucher, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddBook, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1236, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.tableLayoutPanel1);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(24, 24);
            this.panelTopBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1236, 60);
            this.panelTopBar.TabIndex = 0;
            // 
            // flowPaginationButtons
            // 
            this.flowPaginationButtons.AutoSize = true;
            this.flowPaginationButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPaginationButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowPaginationButtons.Location = new System.Drawing.Point(1236, 8);
            this.flowPaginationButtons.Name = "flowPaginationButtons";
            this.flowPaginationButtons.Size = new System.Drawing.Size(0, 42);
            this.flowPaginationButtons.TabIndex = 1;
            this.flowPaginationButtons.WrapContents = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(0, 8);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(160, 20);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "Hiển thị 1-10 của 100";
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.flowPaginationButtons);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(24, 667);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panelPagination.Size = new System.Drawing.Size(1236, 50);
            this.panelPagination.TabIndex = 1;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToResizeColumns = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenKM,
            this.colMoTa,
            this.colGiam,
            this.colNgayBatDau,
            this.colNgayKetThuc,
            this.colTrangThai,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvBooks.Location = new System.Drawing.Point(24, 84);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1236, 583);
            this.dgvBooks.TabIndex = 3;
            // 
            // colTenKM
            // 
            this.colTenKM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenKM.DataPropertyName = "ten_km";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenKM.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTenKM.FillWeight = 20F;
            this.colTenKM.HeaderText = "Tên Khuyến Mãi";
            this.colTenKM.Name = "colTenKM";
            this.colTenKM.ReadOnly = true;
            // 
            // colMoTa
            // 
            this.colMoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMoTa.DataPropertyName = "mo_ta";
            this.colMoTa.FillWeight = 20F;
            this.colMoTa.HeaderText = "Mô tả";
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.ReadOnly = true;
            // 
            // colGiam
            // 
            this.colGiam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGiam.DataPropertyName = "phan_tram_giam";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colGiam.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGiam.FillWeight = 10F;
            this.colGiam.HeaderText = "% Giảm";
            this.colGiam.Name = "colGiam";
            this.colGiam.ReadOnly = true;
            // 
            // colNgayBatDau
            // 
            this.colNgayBatDau.DataPropertyName = "ngay_bat_dau";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.colNgayBatDau.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNgayBatDau.FillWeight = 15F;
            this.colNgayBatDau.HeaderText = "Ngày Bắt Đầu";
            this.colNgayBatDau.Name = "colNgayBatDau";
            this.colNgayBatDau.ReadOnly = true;
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNgayKetThuc.DataPropertyName = "ngay_ket_thuc";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.colNgayKetThuc.DefaultCellStyle = dataGridViewCellStyle5;
            this.colNgayKetThuc.FillWeight = 15F;
            this.colNgayKetThuc.HeaderText = "Ngày Kết Thúc";
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            this.colNgayKetThuc.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThaiText";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTrangThai.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTrangThai.FillWeight = 4.851827F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 16, 4, 16);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEdit.FillWeight = 158.8549F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 40;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(4, 16, 0, 16);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDelete.FillWeight = 228.4264F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 40;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.White;
            this.panelMainContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainContent.Controls.Add(this.dgvBooks);
            this.panelMainContent.Controls.Add(this.panelPagination);
            this.panelMainContent.Controls.Add(this.panelTopBar);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(24, 24);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Padding = new System.Windows.Forms.Padding(24);
            this.panelMainContent.Size = new System.Drawing.Size(1286, 743);
            this.panelMainContent.TabIndex = 2;
            // 
            // VoucherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMainContent);
            this.Name = "VoucherControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1334, 791);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTopBar.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.panelMainContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.TextBox txtSearchVoucher;
        private FontAwesome.Sharp.IconButton btnAddBook;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.FlowLayoutPanel flowPaginationButtons;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}