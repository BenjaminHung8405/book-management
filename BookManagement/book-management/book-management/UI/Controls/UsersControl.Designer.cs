namespace book_management.UI.Controls
{
    partial class UsersControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.flowPaginationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.btnAddUser = new FontAwesome.Sharp.IconButton();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.White;
            this.panelMainContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainContent.Controls.Add(this.dgvUsers);
            this.panelMainContent.Controls.Add(this.panelPagination);
            this.panelMainContent.Controls.Add(this.tableLayoutPanel1);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(24, 24);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Padding = new System.Windows.Forms.Padding(24);
            this.panelMainContent.Size = new System.Drawing.Size(1302, 782);
            this.panelMainContent.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoTen,
            this.colUsername,
            this.colEmail,
            this.colSdt,
            this.colVaiTro,
            this.colNgayTao,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvUsers.Location = new System.Drawing.Point(24, 84);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1400, 622);
            this.dgvUsers.TabIndex = 4;
            // 
            // colHoTen
            // 
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoTen.DataPropertyName = "ho_ten";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoTen.DefaultCellStyle = dataGridViewCellStyle8;
            this.colHoTen.FillWeight = 40F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colUsername
            // 
            this.colUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUsername.DataPropertyName = "username";
            this.colUsername.FillWeight = 40F;
            this.colUsername.HeaderText = "Tên đăng nhập";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "email";
            this.colEmail.FillWeight = 40F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colSdt
            // 
            this.colSdt.DataPropertyName = "so_dien_thoai";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.NullValue = null;
            this.colSdt.DefaultCellStyle = dataGridViewCellStyle9;
            this.colSdt.FillWeight = 40F;
            this.colSdt.HeaderText = "Số điện thoại";
            this.colSdt.Name = "colSdt";
            this.colSdt.ReadOnly = true;
            // 
            // colVaiTro
            // 
            this.colVaiTro.DataPropertyName = "vai_tro";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colVaiTro.DefaultCellStyle = dataGridViewCellStyle10;
            this.colVaiTro.FillWeight = 25F;
            this.colVaiTro.HeaderText = "Vai trò";
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "ngay_tao";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            this.colNgayTao.DefaultCellStyle = dataGridViewCellStyle11;
            this.colNgayTao.FillWeight = 40F;
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 30F;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 30F;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;
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
            this.panelPagination.TabIndex = 2;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.4128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.2936F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.2936F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cmbRoleFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddUser, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cmbRoleFilter
            // 
            this.cmbRoleFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRoleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoleFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cmbRoleFilter.FormattingEnabled = true;
            this.cmbRoleFilter.Location = new System.Drawing.Point(855, 13);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(181, 33);
            this.cmbRoleFilter.TabIndex = 3;
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearchUser.Location = new System.Drawing.Point(9, 14);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(825, 31);
            this.txtSearchUser.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAddUser.IconColor = System.Drawing.Color.White;
            this.btnAddUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddUser.IconSize = 28;
            this.btnAddUser.Location = new System.Drawing.Point(1051, 4);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(197, 52);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Thêm Người dùng";
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.panelMainContent);
            this.Name = "UsersControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1350, 830);
            this.Load += new System.EventHandler(this.UsersControl_Load);
            this.panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.TextBox txtSearchUser;
        private FontAwesome.Sharp.IconButton btnAddUser;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.FlowLayoutPanel flowPaginationButtons;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}
