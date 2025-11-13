namespace book_management.UI.Controls
{
    partial class EditWareHouseControl
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblWareHouseId = new System.Windows.Forms.Label();
            this.txtWareHouseId = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvChiTiet);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Size = new System.Drawing.Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colPublisher,
            this.colQuantity,
            this.colUnitPrice,
            this.colTotalPrice});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 92);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(776, 416);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChiTiet_CellFormatting);
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "ProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colPublisher
            // 
            this.colPublisher.HeaderText = "NXB";
            this.colPublisher.Name = "colPublisher";
            this.colPublisher.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.HeaderText = "Thành tiền";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblWareHouseId);
            this.panelTop.Controls.Add(this.txtWareHouseId);
            this.panelTop.Controls.Add(this.lblNgayLap);
            this.panelTop.Controls.Add(this.dtpNgayLap);
            this.panelTop.Controls.Add(this.lblNguoiLap);
            this.panelTop.Controls.Add(this.txtNguoiLap);
            this.panelTop.Controls.Add(this.lblTrangThai);
            this.panelTop.Controls.Add(this.cmbTrangThai);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(12, 12);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(776, 80);
            this.panelTop.TabIndex = 1;
            // 
            // lblWareHouseId
            // 
            this.lblWareHouseId.AutoSize = true;
            this.lblWareHouseId.Location = new System.Drawing.Point(6, 9);
            this.lblWareHouseId.Name = "lblWareHouseId";
            this.lblWareHouseId.Size = new System.Drawing.Size(62, 13);
            this.lblWareHouseId.TabIndex = 0;
            this.lblWareHouseId.Text = "Mã phiếu:";
            // 
            // txtWareHouseId
            // 
            this.txtWareHouseId.Location = new System.Drawing.Point(74, 6);
            this.txtWareHouseId.Name = "txtWareHouseId";
            this.txtWareHouseId.ReadOnly = true;
            this.txtWareHouseId.Size = new System.Drawing.Size(120, 20);
            this.txtWareHouseId.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Location = new System.Drawing.Point(210, 9);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(50, 13);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayLap.Location = new System.Drawing.Point(266, 6);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(180, 20);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Location = new System.Drawing.Point(6, 38);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(54, 13);
            this.lblNguoiLap.TabIndex = 4;
            this.lblNguoiLap.Text = "Người lập:";
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(74, 35);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.Size = new System.Drawing.Size(200, 20);
            this.txtNguoiLap.TabIndex = 5;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(300, 38);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(55, 13);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Chưa nhập",
            "Đã nhập"});
            this.cmbTrangThai.Location = new System.Drawing.Point(361, 34);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(120, 21);
            this.cmbTrangThai.TabIndex = 7;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtTongTien);
            this.panelBottom.Controls.Add(this.lblTongTien);
            this.panelBottom.Controls.Add(this.btnUpdateQuantity);
            this.panelBottom.Controls.Add(this.btnRemoveItem);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(12, 508);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(776, 80);
            this.panelBottom.TabIndex = 2;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(600, 15);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(160, 20);
            this.txtTongTien.TabIndex = 0;
            this.txtTongTien.Text = "0 đ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(540, 18);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(56, 13);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Location = new System.Drawing.Point(9, 12);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateQuantity.TabIndex = 2;
            this.btnUpdateQuantity.Text = "Cập nhật SL";
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(140, 12);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(120, 30);
            this.btnRemoveItem.TabIndex = 3;
            this.btnRemoveItem.Text = "Xóa";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(420, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(560, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditWareHouseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditWareHouseControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa phiếu kho";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblWareHouseId;
        private System.Windows.Forms.TextBox txtWareHouseId;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNguoiLap;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
    }
}