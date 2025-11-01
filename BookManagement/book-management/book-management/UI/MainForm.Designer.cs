namespace book_management.UI
{
    partial class MainForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnBooks = new FontAwesome.Sharp.IconButton();
            this.btnUser = new FontAwesome.Sharp.IconButton();
            this.btnReport = new FontAwesome.Sharp.IconButton();
            this.btnHistoryBuy = new FontAwesome.Sharp.IconButton();
            this.btnInvoice = new FontAwesome.Sharp.IconButton();
            this.btnSales = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.pnUser = new System.Windows.Forms.Panel();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.iconDropDownMenuProfile = new FontAwesome.Sharp.IconDropDownButton();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.pnUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1600, 70);
            this.panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(62, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cửa hàng Sách";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::book_management.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.White;
            this.panelSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSidebar.Controls.Add(this.btnBooks);
            this.panelSidebar.Controls.Add(this.btnUser);
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnHistoryBuy);
            this.panelSidebar.Controls.Add(this.btnInvoice);
            this.panelSidebar.Controls.Add(this.btnSales);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.pnUser);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 70);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.panelSidebar.Size = new System.Drawing.Size(250, 830);
            this.panelSidebar.TabIndex = 2;
            // 
            // btnBooks
            // 
            this.btnBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnBooks.IconColor = System.Drawing.Color.White;
            this.btnBooks.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBooks.IconSize = 36;
            this.btnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.Location = new System.Drawing.Point(12, 330);
            this.btnBooks.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnBooks.Size = new System.Drawing.Size(224, 63);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Quản lý Sách";
            this.btnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUser.IconColor = System.Drawing.Color.White;
            this.btnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUser.IconSize = 36;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(12, 530);
            this.btnUser.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnUser.Size = new System.Drawing.Size(224, 63);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Người Dùng";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.btnReport.IconColor = System.Drawing.Color.White;
            this.btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReport.IconSize = 36;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(12, 630);
            this.btnReport.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnReport.Size = new System.Drawing.Size(224, 63);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Thống kê";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnHistoryBuy
            // 
            this.btnHistoryBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnHistoryBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryBuy.ForeColor = System.Drawing.Color.White;
            this.btnHistoryBuy.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnHistoryBuy.IconColor = System.Drawing.Color.White;
            this.btnHistoryBuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHistoryBuy.IconSize = 36;
            this.btnHistoryBuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoryBuy.Location = new System.Drawing.Point(12, 734);
            this.btnHistoryBuy.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnHistoryBuy.Name = "btnHistoryBuy";
            this.btnHistoryBuy.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnHistoryBuy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHistoryBuy.Size = new System.Drawing.Size(224, 75);
            this.btnHistoryBuy.TabIndex = 0;
            this.btnHistoryBuy.Text = "Lịch Sử Mua Hàng";
            this.btnHistoryBuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoryBuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistoryBuy.UseVisualStyleBackColor = false;
            this.btnHistoryBuy.Click += new System.EventHandler(this.btnHistoryBuy_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnInvoice.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnInvoice.IconColor = System.Drawing.Color.White;
            this.btnInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInvoice.IconSize = 36;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(12, 430);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnInvoice.Size = new System.Drawing.Size(224, 63);
            this.btnInvoice.TabIndex = 0;
            this.btnInvoice.Text = "Hóa Đơn";
            this.btnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.White;
            this.btnSales.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnSales.IconColor = System.Drawing.Color.White;
            this.btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSales.IconSize = 36;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(12, 230);
            this.btnSales.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnSales.Name = "btnSales";
            this.btnSales.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnSales.Size = new System.Drawing.Size(224, 63);
            this.btnSales.TabIndex = 0;
            this.btnSales.Text = "Bán Hàng";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 36;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(12, 130);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(258, 310, 258, 310);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnDashboard.Size = new System.Drawing.Size(224, 63);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnUser
            // 
            this.pnUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnUser.Controls.Add(this.lbRole);
            this.pnUser.Controls.Add(this.lbUsername);
            this.pnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnUser.Location = new System.Drawing.Point(12, 14);
            this.pnUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnUser.Name = "pnUser";
            this.pnUser.Padding = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.pnUser.Size = new System.Drawing.Size(224, 73);
            this.pnUser.TabIndex = 0;
            this.pnUser.Click += new System.EventHandler(this.pnUser_Click);
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbRole.Location = new System.Drawing.Point(7, 40);
            this.lbRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(96, 24);
            this.lbRole.TabIndex = 2;
            this.lbRole.Text = "Nhân viên";
            this.lbRole.Click += new System.EventHandler(this.pnUser_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoEllipsis = true;
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbUsername.Location = new System.Drawing.Point(6, 8);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(180, 25);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Nguyễn Phi Hùng";
            this.lbUsername.Click += new System.EventHandler(this.pnUser_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(250, 70);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1350, 830);
            this.panelContent.TabIndex = 3;
            // 
            // iconDropDownMenuProfile
            // 
            this.iconDropDownMenuProfile.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownMenuProfile.IconColor = System.Drawing.Color.Black;
            this.iconDropDownMenuProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownMenuProfile.Name = "iconDropDownMenuProfile";
            this.iconDropDownMenuProfile.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownMenuProfile.Text = "iconDropDownButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.pnUser.ResumeLayout(false);
            this.pnUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUsername;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Panel pnUser;
        private System.Windows.Forms.Label lbRole;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton btnInvoice;
        private FontAwesome.Sharp.IconButton btnUser;
        private FontAwesome.Sharp.IconButton btnReport;
        private FontAwesome.Sharp.IconButton btnBooks;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownMenuProfile;
        private FontAwesome.Sharp.IconButton btnHistoryBuy;
    }
}