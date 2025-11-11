namespace book_management.UI.Modal
{
    partial class frmAddVoucher
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
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanelInputs = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numDecreasePercent = new System.Windows.Forms.NumericUpDown();
            this.t = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtVoucherName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnCancelModal = new System.Windows.Forms.Button();
            this.btnSaveBook = new FontAwesome.Sharp.IconButton();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanelInputs.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecreasePercent)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.iconButton1);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(1, 1);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(16);
            this.panelHeader.Size = new System.Drawing.Size(898, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 28;
            this.iconButton1.Location = new System.Drawing.Point(852, 16);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(30, 28);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Roboto Lt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạo Voucher mới";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 1);
            this.panel1.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.tableLayoutPanel1);
            this.panelBody.Controls.Add(this.panel5);
            this.panelBody.Controls.Add(this.tableLayoutPanelInputs);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(1, 62);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(24);
            this.panelBody.Size = new System.Drawing.Size(898, 575);
            this.panelBody.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 263);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 99);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtpToDate);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(428, 3);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(8);
            this.panel6.Size = new System.Drawing.Size(419, 93);
            this.panel6.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpToDate.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.dtpToDate.Location = new System.Drawing.Point(8, 35);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(403, 27);
            this.dtpToDate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label5.Size = new System.Drawing.Size(97, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày kết thúc";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dtpFromDate);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(8);
            this.panel7.Size = new System.Drawing.Size(419, 93);
            this.panel7.TabIndex = 0;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFromDate.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.dtpFromDate.Location = new System.Drawing.Point(8, 35);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(403, 27);
            this.dtpFromDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label6.Size = new System.Drawing.Size(95, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(24, 123);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(8);
            this.panel5.Size = new System.Drawing.Size(850, 140);
            this.panel5.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(834, 94);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label3.Size = new System.Drawing.Size(46, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mô tả";
            // 
            // tableLayoutPanelInputs
            // 
            this.tableLayoutPanelInputs.ColumnCount = 2;
            this.tableLayoutPanelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInputs.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanelInputs.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanelInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelInputs.Location = new System.Drawing.Point(24, 24);
            this.tableLayoutPanelInputs.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            this.tableLayoutPanelInputs.Name = "tableLayoutPanelInputs";
            this.tableLayoutPanelInputs.RowCount = 1;
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.Size = new System.Drawing.Size(850, 99);
            this.tableLayoutPanelInputs.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numDecreasePercent);
            this.panel3.Controls.Add(this.t);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(428, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(419, 93);
            this.panel3.TabIndex = 1;
            // 
            // numDecreasePercent
            // 
            this.numDecreasePercent.DecimalPlaces = 2;
            this.numDecreasePercent.Dock = System.Windows.Forms.DockStyle.Top;
            this.numDecreasePercent.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.numDecreasePercent.Location = new System.Drawing.Point(8, 35);
            this.numDecreasePercent.Name = "numDecreasePercent";
            this.numDecreasePercent.Size = new System.Drawing.Size(403, 27);
            this.numDecreasePercent.TabIndex = 3;
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Dock = System.Windows.Forms.DockStyle.Top;
            this.t.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t.Location = new System.Drawing.Point(8, 8);
            this.t.Name = "t";
            this.t.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.t.Size = new System.Drawing.Size(57, 27);
            this.t.TabIndex = 0;
            this.t.Text = "% Giảm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtVoucherName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(419, 93);
            this.panel2.TabIndex = 0;
            // 
            // txtVoucherName
            // 
            this.txtVoucherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtVoucherName.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherName.Location = new System.Drawing.Point(8, 35);
            this.txtVoucherName.Name = "txtVoucherName";
            this.txtVoucherName.Size = new System.Drawing.Size(403, 27);
            this.txtVoucherName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label2.Size = new System.Drawing.Size(86, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên voucher";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.btnCancelModal);
            this.panelFooter.Controls.Add(this.btnSaveBook);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(1, 629);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.panelFooter.Size = new System.Drawing.Size(898, 70);
            this.panelFooter.TabIndex = 2;
            // 
            // btnCancelModal
            // 
            this.btnCancelModal.AutoSize = true;
            this.btnCancelModal.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelModal.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancelModal.Location = new System.Drawing.Point(677, 14);
            this.btnCancelModal.Name = "btnCancelModal";
            this.btnCancelModal.Size = new System.Drawing.Size(87, 42);
            this.btnCancelModal.TabIndex = 2;
            this.btnCancelModal.Text = "Hủy bỏ";
            this.btnCancelModal.UseVisualStyleBackColor = true;
            this.btnCancelModal.Click += new System.EventHandler(this.btnCancelModal_Click);
            // 
            // btnSaveBook
            // 
            this.btnSaveBook.AutoSize = true;
            this.btnSaveBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnSaveBook.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveBook.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBook.ForeColor = System.Drawing.Color.White;
            this.btnSaveBook.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.btnSaveBook.IconColor = System.Drawing.Color.White;
            this.btnSaveBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveBook.IconSize = 24;
            this.btnSaveBook.Location = new System.Drawing.Point(764, 14);
            this.btnSaveBook.Margin = new System.Windows.Forms.Padding(36, 0, 0, 0);
            this.btnSaveBook.Name = "btnSaveBook";
            this.btnSaveBook.Size = new System.Drawing.Size(110, 42);
            this.btnSaveBook.TabIndex = 1;
            this.btnSaveBook.Text = "Lưu lại";
            this.btnSaveBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveBook.UseVisualStyleBackColor = false;
            this.btnSaveBook.Click += new System.EventHandler(this.btnSaveBook_Click);
            // 
            // frmAddVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddVoucher";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanelInputs.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecreasePercent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBody;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panelFooter;
        private FontAwesome.Sharp.IconButton btnSaveBook;
        private System.Windows.Forms.Button btnCancelModal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInputs;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVoucherName;
        private System.Windows.Forms.NumericUpDown numDecreasePercent;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}