namespace book_management.UI.Controls
{
    // Đảm bảo có 'partial'
    partial class BooksControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.colAnhBia = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.flowPaginationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnAddBook = new FontAwesome.Sharp.IconButton();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panelMainContent.Size = new System.Drawing.Size(1302, 782);
            this.panelMainContent.TabIndex = 1;
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
            this.colAnhBia,
            this.colTenSach,
            this.colTacGia,
            this.colTheLoai,
            this.colGiaBan,
            this.colTonKho,
            this.colTrangThai,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvBooks.Location = new System.Drawing.Point(24, 84);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1252, 622);
            this.dgvBooks.TabIndex = 3;
            // 
            // colAnhBia
            // 
            this.colAnhBia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnhBia.DataPropertyName = "AnhBia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.colAnhBia.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAnhBia.FillWeight = 10F;
            this.colAnhBia.HeaderText = "Ảnh bìa";
            this.colAnhBia.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colAnhBia.Name = "colAnhBia";
            this.colAnhBia.ReadOnly = true;
            // 
            // colTenSach
            // 
            this.colTenSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenSach.DataPropertyName = "TenSach";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenSach.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTenSach.FillWeight = 40F;
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            // 
            // colTacGia
            // 
            this.colTacGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTacGia.DataPropertyName = "TenTacGia";
            this.colTacGia.FillWeight = 40F;
            this.colTacGia.HeaderText = "Tác giả";
            this.colTacGia.Name = "colTacGia";
            this.colTacGia.ReadOnly = true;
            // 
            // colTheLoai
            // 
            this.colTheLoai.DataPropertyName = "TenTheLoai";
            this.colTheLoai.FillWeight = 40F;
            this.colTheLoai.HeaderText = "Thể loại";
            this.colTheLoai.Name = "colTheLoai";
            this.colTheLoai.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "Gia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = null;
            this.colGiaBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.colGiaBan.FillWeight = 40F;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colTonKho
            // 
            this.colTonKho.DataPropertyName = "SoLuong";
            this.colTonKho.FillWeight = 25F;
            this.colTonKho.HeaderText = "Tồn kho";
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThaiText";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTrangThai.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTrangThai.FillWeight = 40F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 16, 4, 16);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(4, 16, 0, 16);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDelete.FillWeight = 228.4264F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 40;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.flowPaginationButtons);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(24, 706);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panelPagination.Size = new System.Drawing.Size(1252, 50);
            this.panelPagination.TabIndex = 1;
            // 
            // flowPaginationButtons
            // 
            this.flowPaginationButtons.AutoSize = true;
            this.flowPaginationButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPaginationButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowPaginationButtons.Location = new System.Drawing.Point(1252, 8);
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
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.tableLayoutPanel1);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(24, 24);
            this.panelTopBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1252, 60);
            this.panelTopBar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.cmbStatusFilter, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBook, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCategoryFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddBook, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(878, 13);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(181, 33);
            this.cmbStatusFilter.TabIndex = 3;
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearchBook.Location = new System.Drawing.Point(14, 14);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(660, 31);
            this.txtSearchBook.TabIndex = 0;
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(691, 13);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(181, 33);
            this.cmbCategoryFilter.TabIndex = 2;
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
            this.btnAddBook.Location = new System.Drawing.Point(1066, 4);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(182, 52);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Thêm sách mới";
            this.btnAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBook.UseVisualStyleBackColor = false;
            // 
            // BooksControl
            // 
            this.Controls.Add(this.panelMainContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Name = "BooksControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1350, 830);
            this.panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelTopBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo các control
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.DataGridViewImageColumn colAnhBia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.FlowLayoutPanel flowPaginationButtons;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private FontAwesome.Sharp.IconButton btnAddBook;
    }
}