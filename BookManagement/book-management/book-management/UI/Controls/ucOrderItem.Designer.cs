namespace book_management.UI.Controls
{
    partial class ucOrderItem
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
            this.picBookCover = new System.Windows.Forms.PictureBox();
            this.panelBookInfo = new System.Windows.Forms.Panel();
            this.lblBookPrice = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnDecrease = new FontAwesome.Sharp.IconButton();
            this.btnIncrease = new FontAwesome.Sharp.IconButton();
            this.panelQuantity = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLineTotal = new System.Windows.Forms.Label();
            this.btnRemoveItem = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBookCover)).BeginInit();
            this.panelBookInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelQuantity.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBookCover
            // 
            this.picBookCover.BackColor = System.Drawing.Color.White;
            this.picBookCover.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBookCover.Location = new System.Drawing.Point(0, 0);
            this.picBookCover.Name = "picBookCover";
            this.picBookCover.Size = new System.Drawing.Size(48, 80);
            this.picBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBookCover.TabIndex = 0;
            this.picBookCover.TabStop = false;
            // 
            // panelBookInfo
            // 
            this.panelBookInfo.Controls.Add(this.lblBookPrice);
            this.panelBookInfo.Controls.Add(this.lblBookTitle);
            this.panelBookInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBookInfo.Location = new System.Drawing.Point(48, 0);
            this.panelBookInfo.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.panelBookInfo.Name = "panelBookInfo";
            this.panelBookInfo.Size = new System.Drawing.Size(150, 80);
            this.panelBookInfo.TabIndex = 1;
            // 
            // lblBookPrice
            // 
            this.lblBookPrice.AutoSize = true;
            this.lblBookPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblBookPrice.Location = new System.Drawing.Point(0, 28);
            this.lblBookPrice.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblBookPrice.Name = "lblBookPrice";
            this.lblBookPrice.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblBookPrice.Size = new System.Drawing.Size(105, 24);
            this.lblBookPrice.TabIndex = 2;
            this.lblBookPrice.Text = "Đơn giá: 18.350đ";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.Location = new System.Drawing.Point(0, 0);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblBookTitle.Size = new System.Drawing.Size(127, 28);
            this.lblBookTitle.TabIndex = 2;
            this.lblBookTitle.Text = "Đắc Nhân Tâm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDecrease, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnIncrease, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(88, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(26, 26);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(36, 26);
            this.txtQuantity.TabIndex = 0;
            this.txtQuantity.Text = "1";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDecrease
            // 
            this.btnDecrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecrease.FlatAppearance.BorderSize = 0;
            this.btnDecrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrease.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnDecrease.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDecrease.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDecrease.IconSize = 25;
            this.btnDecrease.Location = new System.Drawing.Point(0, 25);
            this.btnDecrease.Margin = new System.Windows.Forms.Padding(0);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(22, 28);
            this.btnDecrease.TabIndex = 3;
            this.btnDecrease.UseVisualStyleBackColor = true;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncrease.FlatAppearance.BorderSize = 0;
            this.btnIncrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncrease.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnIncrease.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnIncrease.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIncrease.IconSize = 25;
            this.btnIncrease.Location = new System.Drawing.Point(66, 25);
            this.btnIncrease.Margin = new System.Windows.Forms.Padding(0);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(22, 28);
            this.btnIncrease.TabIndex = 3;
            this.btnIncrease.UseVisualStyleBackColor = true;
            // 
            // panelQuantity
            // 
            this.panelQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuantity.Controls.Add(this.tableLayoutPanel1);
            this.panelQuantity.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelQuantity.Location = new System.Drawing.Point(198, 0);
            this.panelQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.panelQuantity.Name = "panelQuantity";
            this.panelQuantity.Size = new System.Drawing.Size(90, 80);
            this.panelQuantity.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lblLineTotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveItem, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(288, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 80);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblLineTotal
            // 
            this.lblLineTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLineTotal.AutoSize = true;
            this.lblLineTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineTotal.Location = new System.Drawing.Point(19, 30);
            this.lblLineTotal.Name = "lblLineTotal";
            this.lblLineTotal.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblLineTotal.Size = new System.Drawing.Size(75, 20);
            this.lblLineTotal.TabIndex = 0;
            this.lblLineTotal.Text = "99.000₫";
            this.lblLineTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnRemoveItem.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnRemoveItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveItem.IconSize = 32;
            this.btnRemoveItem.Location = new System.Drawing.Point(117, 20);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(40, 40);
            this.btnRemoveItem.TabIndex = 1;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // ucOrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelQuantity);
            this.Controls.Add(this.panelBookInfo);
            this.Controls.Add(this.picBookCover);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ucOrderItem";
            this.Size = new System.Drawing.Size(450, 80);
            ((System.ComponentModel.ISupportInitialize)(this.picBookCover)).EndInit();
            this.panelBookInfo.ResumeLayout(false);
            this.panelBookInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelQuantity.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBookCover;
        private System.Windows.Forms.Panel panelBookInfo;
        private System.Windows.Forms.Label lblBookPrice;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelQuantity;
        private FontAwesome.Sharp.IconButton btnDecrease;
        private FontAwesome.Sharp.IconButton btnIncrease;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLineTotal;
        private FontAwesome.Sharp.IconButton btnRemoveItem;
    }
}
