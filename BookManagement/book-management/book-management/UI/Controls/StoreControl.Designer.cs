namespace book_management.UI.Controls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBookSelection = new System.Windows.Forms.Panel();
            this.flowPanelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearchBook = new System.Windows.Forms.Panel();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.iconSearchBook = new FontAwesome.Sharp.IconPictureBox();
            this.panelOrderDetails = new System.Windows.Forms.Panel();
            this.flowPanelOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.cmbPromotions = new System.Windows.Forms.ComboBox();
            this.panelOrderFooter = new System.Windows.Forms.Panel();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.ibtnThanhToan = new FontAwesome.Sharp.IconButton();
            this.panelTotals = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.panelOrderHeader = new System.Windows.Forms.Panel();
            this.rtbAddressDelivery = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panelCustomerSearch = new System.Windows.Forms.Panel();
            this.btnSearchCustomer = new FontAwesome.Sharp.IconButton();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new FontAwesome.Sharp.IconButton();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.panelBookSelection.SuspendLayout();
            this.panelSearchBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearchBook)).BeginInit();
            this.panelOrderDetails.SuspendLayout();
            this.flowPanelOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
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
            this.flowPanelBooks.AutoScroll = true;
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
            this.panelSearchBook.Controls.Add(this.txtSearchBook);
            this.panelSearchBook.Controls.Add(this.iconSearchBook);
            this.panelSearchBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchBook.Location = new System.Drawing.Point(0, 0);
            this.panelSearchBook.Name = "panelSearchBook";
            this.panelSearchBook.Padding = new System.Windows.Forms.Padding(8);
            this.panelSearchBook.Size = new System.Drawing.Size(767, 40);
            this.panelSearchBook.TabIndex = 2;
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchBook.Location = new System.Drawing.Point(40, 8);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(714, 26);
            this.txtSearchBook.TabIndex = 1;
            // 
            // iconSearchBook
            // 
            this.iconSearchBook.BackColor = System.Drawing.Color.White;
            this.iconSearchBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.iconSearchBook.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearchBook.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.iconSearchBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearchBook.Location = new System.Drawing.Point(2, 2);
            this.iconSearchBook.Name = "iconSearchBook";
            this.iconSearchBook.Size = new System.Drawing.Size(32, 32);
            this.iconSearchBook.TabIndex = 0;
            this.iconSearchBook.TabStop = false;
            this.iconSearchBook.Click += new System.EventHandler(this.iconSearchBook_Click);
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
            this.flowPanelOrderItems.Controls.Add(this.dgvCart);
            this.flowPanelOrderItems.Controls.Add(this.cmbPromotions);
            this.flowPanelOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelOrderItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelOrderItems.Location = new System.Drawing.Point(0, 210);
            this.flowPanelOrderItems.Name = "flowPanelOrderItems";
            this.flowPanelOrderItems.Padding = new System.Windows.Forms.Padding(16);
            this.flowPanelOrderItems.Size = new System.Drawing.Size(509, 400);
            this.flowPanelOrderItems.TabIndex = 2;
            this.flowPanelOrderItems.WrapContents = false;
            // 
            // dgvCart
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.Location = new System.Drawing.Point(19, 19);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(600, 400);
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCart.TabIndex = 0;
            // 
            // cmbPromotions
            // 
            this.cmbPromotions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPromotions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbPromotions.FormattingEnabled = true;
            this.cmbPromotions.Location = new System.Drawing.Point(19, 286);
            this.cmbPromotions.Name = "cmbPromotions";
            this.cmbPromotions.Size = new System.Drawing.Size(473, 28);
            this.cmbPromotions.Sorted = true;
            this.cmbPromotions.TabIndex = 5;
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
            this.tableLayoutPanelButtons.Controls.Add(this.ibtnThanhToan, 1, 0);
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
            // ibtnThanhToan
            // 
            this.ibtnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.ibtnThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibtnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.ibtnThanhToan.ForeColor = System.Drawing.Color.White;
            this.ibtnThanhToan.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.ibtnThanhToan.IconColor = System.Drawing.Color.White;
            this.ibtnThanhToan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThanhToan.IconSize = 35;
            this.ibtnThanhToan.Location = new System.Drawing.Point(245, 0);
            this.ibtnThanhToan.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.ibtnThanhToan.Name = "ibtnThanhToan";
            this.ibtnThanhToan.Size = new System.Drawing.Size(230, 36);
            this.ibtnThanhToan.TabIndex = 1;
            this.ibtnThanhToan.Text = "Thanh Toán";
            this.ibtnThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnThanhToan.UseVisualStyleBackColor = false;
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
            this.panel1.Controls.Add(this.lblSubtotal);
            this.panel1.Controls.Add(this.lblSubtotalLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 33);
            this.panel1.TabIndex = 2;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(442, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(33, 24);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "0₫";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.panelOrderHeader.Controls.Add(this.rtbAddressDelivery);
            this.panelOrderHeader.Controls.Add(this.label1);
            this.panelOrderHeader.Controls.Add(this.lblCustomerInfo);
            this.panelOrderHeader.Controls.Add(this.lblCustomerName);
            this.panelOrderHeader.Controls.Add(this.panelCustomerSearch);
            this.panelOrderHeader.Controls.Add(this.lblOrderId);
            this.panelOrderHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderHeader.Location = new System.Drawing.Point(0, 0);
            this.panelOrderHeader.Name = "panelOrderHeader";
            this.panelOrderHeader.Padding = new System.Windows.Forms.Padding(16);
            this.panelOrderHeader.Size = new System.Drawing.Size(509, 210);
            this.panelOrderHeader.TabIndex = 0;
            // 
            // rtbAddressDelivery
            // 
            this.rtbAddressDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rtbAddressDelivery.Location = new System.Drawing.Point(18, 151);
            this.rtbAddressDelivery.Name = "rtbAddressDelivery";
            this.rtbAddressDelivery.Size = new System.Drawing.Size(433, 38);
            this.rtbAddressDelivery.TabIndex = 5;
            this.rtbAddressDelivery.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Địa Chỉ Giao Hàng:";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCustomerInfo.Location = new System.Drawing.Point(110, 95);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(170, 20);
            this.lblCustomerInfo.TabIndex = 0;
            this.lblCustomerInfo.Text = "Thông tin khách hàng..";
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
            this.panelCustomerSearch.Controls.Add(this.btnSearchCustomer);
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
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearchCustomer.IconColor = System.Drawing.Color.White;
            this.btnSearchCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchCustomer.IconSize = 16;
            this.btnSearchCustomer.Location = new System.Drawing.Point(355, 0);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(80, 35);
            this.btnSearchCustomer.TabIndex = 3;
            this.btnSearchCustomer.Text = "Tìm";
            this.btnSearchCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
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
            this.btnAddCustomer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAddCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddCustomer.IconSize = 28;
            this.btnAddCustomer.Location = new System.Drawing.Point(435, 0);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(40, 35);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
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
            this.lblOrderId.Size = new System.Drawing.Size(217, 36);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Tìm kiếm SDT khách hàng\r\n";
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
            ((System.ComponentModel.ISupportInitialize)(this.iconSearchBook)).EndInit();
            this.panelOrderDetails.ResumeLayout(false);
            this.flowPanelOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
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
        private System.Windows.Forms.TextBox txtSearchBook;
        private FontAwesome.Sharp.IconPictureBox iconSearchBook;
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
        private FontAwesome.Sharp.IconButton ibtnThanhToan;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPromotions;
        private System.Windows.Forms.RichTextBox rtbAddressDelivery;
        private FontAwesome.Sharp.IconButton btnSearchCustomer;
    }
}
