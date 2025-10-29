﻿namespace book_management.UI.Controls
{
    partial class StoreControl
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
            this.panelBookSelection = new System.Windows.Forms.Panel();
            this.flowPanelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearchBook = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panelOrderDetails = new System.Windows.Forms.Panel();
            this.flowPanelOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOrderFooter = new System.Windows.Forms.Panel();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panelTotals = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.panelOrderHeader = new System.Windows.Forms.Panel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panelCustomerSearch = new System.Windows.Forms.Panel();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new FontAwesome.Sharp.IconButton();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.panelBookSelection.SuspendLayout();
            this.panelSearchBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelOrderDetails.SuspendLayout();
            this.panelOrderFooter.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.panelTotals.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelOrderHeader.SuspendLayout();
            this.panelCustomerSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBookSelection
            // 
            this.panelBookSelection.Controls.Add(this.flowPanelBooks);
            this.panelBookSelection.Controls.Add(this.panelSearchBook);
            this.panelBookSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBookSelection.Location = new System.Drawing.Point(24, 24);
            this.panelBookSelection.Name = "panelBookSelection";
            this.panelBookSelection.Size = new System.Drawing.Size(767, 782);
            this.panelBookSelection.TabIndex = 2;
            // 
            // flowPanelBooks
            // 
            this.flowPanelBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelBooks.Location = new System.Drawing.Point(0, 40);
            this.flowPanelBooks.Name = "flowPanelBooks";
            this.flowPanelBooks.Size = new System.Drawing.Size(767, 742);
            this.flowPanelBooks.TabIndex = 3;
            // 
            // panelSearchBook
            // 
            this.panelSearchBook.BackColor = System.Drawing.Color.White;
            this.panelSearchBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearchBook.Controls.Add(this.textBox1);
            this.panelSearchBook.Controls.Add(this.iconPictureBox1);
            this.panelSearchBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchBook.Location = new System.Drawing.Point(0, 0);
            this.panelSearchBook.Name = "panelSearchBook";
            this.panelSearchBook.Padding = new System.Windows.Forms.Padding(8);
            this.panelSearchBook.Size = new System.Drawing.Size(767, 40);
            this.panelSearchBook.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(40, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(714, 20);
            this.textBox1.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(2, 2);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // panelOrderDetails
            // 
            this.panelOrderDetails.BackColor = System.Drawing.Color.White;
            this.panelOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderDetails.Controls.Add(this.flowPanelOrderItems);
            this.panelOrderDetails.Controls.Add(this.panelOrderFooter);
            this.panelOrderDetails.Controls.Add(this.panelOrderHeader);
            this.panelOrderDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOrderDetails.Location = new System.Drawing.Point(815, 24);
            this.panelOrderDetails.Name = "panelOrderDetails";
            this.panelOrderDetails.Size = new System.Drawing.Size(511, 782);
            this.panelOrderDetails.TabIndex = 3;
            // 
            // flowPanelOrderItems
            // 
            this.flowPanelOrderItems.AutoScroll = true;
            this.flowPanelOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelOrderItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelOrderItems.Location = new System.Drawing.Point(0, 140);
            this.flowPanelOrderItems.Name = "flowPanelOrderItems";
            this.flowPanelOrderItems.Padding = new System.Windows.Forms.Padding(16);
            this.flowPanelOrderItems.Size = new System.Drawing.Size(509, 470);
            this.flowPanelOrderItems.TabIndex = 2;
            this.flowPanelOrderItems.WrapContents = false;
            // 
            // panelOrderFooter
            // 
            this.panelOrderFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderFooter.Controls.Add(this.tableLayoutPanelButtons);
            this.panelOrderFooter.Controls.Add(this.panelTotals);
            this.panelOrderFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrderFooter.Location = new System.Drawing.Point(0, 610);
            this.panelOrderFooter.Name = "panelOrderFooter";
            this.panelOrderFooter.Padding = new System.Windows.Forms.Padding(16);
            this.panelOrderFooter.Size = new System.Drawing.Size(509, 170);
            this.panelOrderFooter.TabIndex = 1;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.Controls.Add(this.btnCancelOrder, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.iconButton1, 1, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(16, 116);
            this.tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(475, 36);
            this.tableLayoutPanelButtons.TabIndex = 1;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(0, 0);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(229, 36);
            this.btnCancelOrder.TabIndex = 0;
            this.btnCancelOrder.Text = "Hủy";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 35;
            this.iconButton1.Location = new System.Drawing.Point(245, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(230, 36);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Thanh Toán";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // panelTotals
            // 
            this.panelTotals.AutoScroll = true;
            this.panelTotals.Controls.Add(this.panel3);
            this.panelTotals.Controls.Add(this.panel2);
            this.panelTotals.Controls.Add(this.panel1);
            this.panelTotals.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTotals.Location = new System.Drawing.Point(16, 16);
            this.panelTotals.Name = "panelTotals";
            this.panelTotals.Size = new System.Drawing.Size(475, 100);
            this.panelTotals.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTotalValue);
            this.panel3.Controls.Add(this.lblTotalLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel3.Size = new System.Drawing.Size(475, 25);
            this.panel3.TabIndex = 4;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalValue.Location = new System.Drawing.Point(442, 0);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(33, 24);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0₫";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLabel.Location = new System.Drawing.Point(0, 0);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(103, 24);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "Tổng cộng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDiscountValue);
            this.panel2.Controls.Add(this.lblDiscountLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel2.Size = new System.Drawing.Size(475, 33);
            this.panel2.TabIndex = 3;
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblDiscountValue.Location = new System.Drawing.Point(442, 0);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(33, 24);
            this.lblDiscountValue.TabIndex = 1;
            this.lblDiscountValue.Text = "0₫";
            this.lblDiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.AutoSize = true;
            this.lblDiscountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountLabel.Location = new System.Drawing.Point(0, 0);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(110, 24);
            this.lblDiscountLabel.TabIndex = 0;
            this.lblDiscountLabel.Text = "Khuyến mãi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSubtotalValue);
            this.panel1.Controls.Add(this.lblSubtotalLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 33);
            this.panel1.TabIndex = 2;
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSubtotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalValue.Location = new System.Drawing.Point(442, 0);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(33, 24);
            this.lblSubtotalValue.TabIndex = 1;
            this.lblSubtotalValue.Text = "0₫";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalLabel.Location = new System.Drawing.Point(0, 0);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(83, 24);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Tạm tính";
            // 
            // panelOrderHeader
            // 
            this.panelOrderHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderHeader.Controls.Add(this.lblCustomerName);
            this.panelOrderHeader.Controls.Add(this.panelCustomerSearch);
            this.panelOrderHeader.Controls.Add(this.lblOrderId);
            this.panelOrderHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderHeader.Location = new System.Drawing.Point(0, 0);
            this.panelOrderHeader.Name = "panelOrderHeader";
            this.panelOrderHeader.Padding = new System.Windows.Forms.Padding(16);
            this.panelOrderHeader.Size = new System.Drawing.Size(509, 140);
            this.panelOrderHeader.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(16, 95);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(98, 20);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Khách hàng:";
            // 
            // panelCustomerSearch
            // 
            this.panelCustomerSearch.Controls.Add(this.txtCustomerSearch);
            this.panelCustomerSearch.Controls.Add(this.btnAddCustomer);
            this.panelCustomerSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerSearch.Location = new System.Drawing.Point(16, 52);
            this.panelCustomerSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelCustomerSearch.Name = "panelCustomerSearch";
            this.panelCustomerSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelCustomerSearch.Size = new System.Drawing.Size(475, 43);
            this.panelCustomerSearch.TabIndex = 1;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerSearch.Location = new System.Drawing.Point(0, 0);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(435, 31);
            this.txtCustomerSearch.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnAddCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddCustomer.IconSize = 28;
            this.btnAddCustomer.Location = new System.Drawing.Point(435, 0);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(40, 35);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderId.Location = new System.Drawing.Point(16, 16);
            this.lblOrderId.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Padding = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.lblOrderId.Size = new System.Drawing.Size(131, 36);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Hóa Đơn #HD1";
            // 
            // StoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.panelBookSelection);
            this.Controls.Add(this.panelOrderDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "StoreControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1350, 830);
            this.panelBookSelection.ResumeLayout(false);
            this.panelSearchBook.ResumeLayout(false);
            this.panelSearchBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelOrderDetails.ResumeLayout(false);
            this.panelOrderFooter.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.panelTotals.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelOrderHeader.ResumeLayout(false);
            this.panelOrderHeader.PerformLayout();
            this.panelCustomerSearch.ResumeLayout(false);
            this.panelCustomerSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBookSelection;
        private System.Windows.Forms.FlowLayoutPanel flowPanelBooks;
        private System.Windows.Forms.Panel panelSearchBook;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panelOrderDetails;
        private System.Windows.Forms.FlowLayoutPanel flowPanelOrderItems;
        private System.Windows.Forms.Panel panelOrderFooter;
        private System.Windows.Forms.Panel panelOrderHeader;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Panel panelCustomerSearch;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private FontAwesome.Sharp.IconButton btnAddCustomer;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Panel panelTotals;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Button btnCancelOrder;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
