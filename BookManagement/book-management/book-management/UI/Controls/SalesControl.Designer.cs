namespace book_management.UI.Controls
{
    partial class SalesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBooks = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.panelBookSearch = new System.Windows.Forms.Panel();
            this.btnAddToCart = new FontAwesome.Sharp.IconButton();
            this.btnSearchBook = new FontAwesome.Sharp.IconButton();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.lblBookSearch = new System.Windows.Forms.Label();
            this.panelCart = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.panelCartActions = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnRemoveFromCart = new FontAwesome.Sharp.IconButton();
            this.lblCart = new System.Windows.Forms.Label();
            this.panelCustomer = new System.Windows.Forms.Panel();
            this.tableLayoutCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new FontAwesome.Sharp.IconButton();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.btnNewCustomer = new FontAwesome.Sharp.IconButton();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnPrintBill = new FontAwesome.Sharp.IconButton();
            this.btnCancelBill = new FontAwesome.Sharp.IconButton();
            this.btnCreateBill = new FontAwesome.Sharp.IconButton();
            this.panelMain.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.panelBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.panelBookSearch.SuspendLayout();
            this.panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelCartActions.SuspendLayout();
            this.panelCustomer.SuspendLayout();
            this.tableLayoutCustomer.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelMain.Controls.Add(this.tableLayoutMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1350, 830);
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMain.Controls.Add(this.panelBooks, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panelCart, 1, 0);
            this.tableLayoutMain.Controls.Add(this.panelCustomer, 0, 1);
            this.tableLayoutMain.Controls.Add(this.panelActions, 1, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1310, 790);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // panelBooks
            // 
            this.panelBooks.BackColor = System.Drawing.Color.White;
            this.panelBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBooks.Controls.Add(this.dgvBooks);
            this.panelBooks.Controls.Add(this.panelBookSearch);
            this.panelBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBooks.Location = new System.Drawing.Point(3, 3);
            this.panelBooks.Name = "panelBooks";
            this.panelBooks.Padding = new System.Windows.Forms.Padding(15);
            this.panelBooks.Size = new System.Drawing.Size(780, 547);
            this.panelBooks.TabIndex = 0;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(15, 85);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(748, 445);
            this.dgvBooks.TabIndex = 1;
            this.dgvBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellDoubleClick);
            // 
            // panelBookSearch
            // 
            this.panelBookSearch.Controls.Add(this.btnAddToCart);
            this.panelBookSearch.Controls.Add(this.btnSearchBook);
            this.panelBookSearch.Controls.Add(this.txtSearchBook);
            this.panelBookSearch.Controls.Add(this.lblBookSearch);
            this.panelBookSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBookSearch.Location = new System.Drawing.Point(15, 15);
            this.panelBookSearch.Name = "panelBookSearch";
            this.panelBookSearch.Size = new System.Drawing.Size(748, 70);
            this.panelBookSearch.TabIndex = 0;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.btnAddToCart.IconColor = System.Drawing.Color.White;
            this.btnAddToCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddToCart.IconSize = 20;
            this.btnAddToCart.Location = new System.Drawing.Point(618, 35);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(120, 30);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "Thêm vào giỏ";
            this.btnAddToCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearchBook.ForeColor = System.Drawing.Color.White;
            this.btnSearchBook.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearchBook.IconColor = System.Drawing.Color.White;
            this.btnSearchBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchBook.IconSize = 16;
            this.btnSearchBook.Location = new System.Drawing.Point(350, 35);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(80, 30);
            this.btnSearchBook.TabIndex = 2;
            this.btnSearchBook.Text = "Tìm";
            this.btnSearchBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchBook.UseVisualStyleBackColor = false;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchBook.Location = new System.Drawing.Point(0, 35);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(340, 26);
            this.txtSearchBook.TabIndex = 1;
            this.txtSearchBook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchBook_KeyPress);
            // 
            // lblBookSearch
            // 
            this.lblBookSearch.AutoSize = true;
            this.lblBookSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBookSearch.Location = new System.Drawing.Point(0, 5);
            this.lblBookSearch.Name = "lblBookSearch";
            this.lblBookSearch.Size = new System.Drawing.Size(166, 24);
            this.lblBookSearch.TabIndex = 0;
            this.lblBookSearch.Text = "Danh sách sách";
            // 
            // panelCart
            // 
            this.panelCart.BackColor = System.Drawing.Color.White;
            this.panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCart.Controls.Add(this.dgvCart);
            this.panelCart.Controls.Add(this.panelCartActions);
            this.panelCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCart.Location = new System.Drawing.Point(789, 3);
            this.panelCart.Name = "panelCart";
            this.panelCart.Padding = new System.Windows.Forms.Padding(15);
            this.panelCart.Size = new System.Drawing.Size(518, 547);
            this.panelCart.TabIndex = 1;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(15, 85);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(486, 375);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellValueChanged);
            // 
            // panelCartActions
            // 
            this.panelCartActions.Controls.Add(this.lblTotalAmount);
            this.panelCartActions.Controls.Add(this.btnRemoveFromCart);
            this.panelCartActions.Controls.Add(this.lblCart);
            this.panelCartActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCartActions.Location = new System.Drawing.Point(15, 15);
            this.panelCartActions.Name = "panelCartActions";
            this.panelCartActions.Size = new System.Drawing.Size(486, 70);
            this.panelCartActions.TabIndex = 0;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(0, 50);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(366, 20);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "Tổng tiền: 0 đ";
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnRemoveFromCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveFromCart.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromCart.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnRemoveFromCart.IconColor = System.Drawing.Color.White;
            this.btnRemoveFromCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveFromCart.IconSize = 16;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(366, 0);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(120, 70);
            this.btnRemoveFromCart.TabIndex = 1;
            this.btnRemoveFromCart.Text = "Xóa khỏi giỏ";
            this.btnRemoveFromCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblCart.Location = new System.Drawing.Point(0, 5);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(93, 24);
            this.lblCart.TabIndex = 0;
            this.lblCart.Text = "Giỏ hàng";
            // 
            // panelCustomer
            // 
            this.panelCustomer.BackColor = System.Drawing.Color.White;
            this.panelCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomer.Controls.Add(this.tableLayoutCustomer);
            this.panelCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomer.Location = new System.Drawing.Point(3, 556);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Padding = new System.Windows.Forms.Padding(15);
            this.panelCustomer.Size = new System.Drawing.Size(780, 231);
            this.panelCustomer.TabIndex = 2;
            // 
            // tableLayoutCustomer
            // 
            this.tableLayoutCustomer.ColumnCount = 4;
            this.tableLayoutCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutCustomer.Controls.Add(this.lblCustomerInfo, 0, 0);
            this.tableLayoutCustomer.Controls.Add(this.lblCustomerName, 0, 1);
            this.tableLayoutCustomer.Controls.Add(this.txtCustomerName, 1, 1);
            this.tableLayoutCustomer.Controls.Add(this.lblCustomerPhone, 0, 2);
            this.tableLayoutCustomer.Controls.Add(this.txtCustomerPhone, 1, 2);
            this.tableLayoutCustomer.Controls.Add(this.btnSearchCustomer, 2, 2);
            this.tableLayoutCustomer.Controls.Add(this.lblCustomerAddress, 0, 3);
            this.tableLayoutCustomer.Controls.Add(this.txtCustomerAddress, 1, 3);
            this.tableLayoutCustomer.Controls.Add(this.btnNewCustomer, 3, 2);
            this.tableLayoutCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCustomer.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutCustomer.Name = "tableLayoutCustomer";
            this.tableLayoutCustomer.RowCount = 4;
            this.tableLayoutCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutCustomer.Size = new System.Drawing.Size(748, 199);
            this.tableLayoutCustomer.TabIndex = 0;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.tableLayoutCustomer.SetColumnSpan(this.lblCustomerInfo, 4);
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfo.Location = new System.Drawing.Point(3, 8);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(191, 24);
            this.lblCustomerInfo.TabIndex = 0;
            this.lblCustomerInfo.Text = "Thông tin khách hàng";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 61);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(57, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Họ và tên:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(103, 58);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(382, 23);
            this.txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(3, 114);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(73, 13);
            this.lblCustomerPhone.TabIndex = 3;
            this.lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(103, 111);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(382, 23);
            this.txtCustomerPhone.TabIndex = 4;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearchCustomer.IconColor = System.Drawing.Color.White;
            this.btnSearchCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchCustomer.IconSize = 16;
            this.btnSearchCustomer.Location = new System.Drawing.Point(491, 105);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(123, 35);
            this.btnSearchCustomer.TabIndex = 5;
            this.btnSearchCustomer.Text = "Tìm kiếm";
            this.btnSearchCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(3, 167);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(43, 13);
            this.lblCustomerAddress.TabIndex = 6;
            this.lblCustomerAddress.Text = "Địa chỉ:";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutCustomer.SetColumnSpan(this.txtCustomerAddress, 3);
            this.txtCustomerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomerAddress.Location = new System.Drawing.Point(103, 164);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(642, 23);
            this.txtCustomerAddress.TabIndex = 7;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnNewCustomer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnNewCustomer.IconColor = System.Drawing.Color.White;
            this.btnNewCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewCustomer.IconSize = 16;
            this.btnNewCustomer.Location = new System.Drawing.Point(620, 105);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(125, 35);
            this.btnNewCustomer.TabIndex = 8;
            this.btnNewCustomer.Text = "Khách mới";
            this.btnNewCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.btnPrintBill);
            this.panelActions.Controls.Add(this.btnCancelBill);
            this.panelActions.Controls.Add(this.btnCreateBill);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(789, 556);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(15);
            this.panelActions.Size = new System.Drawing.Size(518, 231);
            this.panelActions.TabIndex = 3;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrintBill.ForeColor = System.Drawing.Color.White;
            this.btnPrintBill.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnPrintBill.IconColor = System.Drawing.Color.White;
            this.btnPrintBill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrintBill.IconSize = 24;
            this.btnPrintBill.Location = new System.Drawing.Point(18, 165);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(482, 45);
            this.btnPrintBill.TabIndex = 2;
            this.btnPrintBill.Text = "IN HÓA ĐƠN";
            this.btnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // btnCancelBill
            // 
            this.btnCancelBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnCancelBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelBill.ForeColor = System.Drawing.Color.White;
            this.btnCancelBill.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCancelBill.IconColor = System.Drawing.Color.White;
            this.btnCancelBill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelBill.IconSize = 24;
            this.btnCancelBill.Location = new System.Drawing.Point(18, 95);
            this.btnCancelBill.Name = "btnCancelBill";
            this.btnCancelBill.Size = new System.Drawing.Size(482, 45);
            this.btnCancelBill.TabIndex = 1;
            this.btnCancelBill.Text = "HỦY HÓA ĐƠN";
            this.btnCancelBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelBill.UseVisualStyleBackColor = false;
            this.btnCancelBill.Click += new System.EventHandler(this.btnCancelBill_Click);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnCreateBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateBill.ForeColor = System.Drawing.Color.White;
            this.btnCreateBill.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnCreateBill.IconColor = System.Drawing.Color.White;
            this.btnCreateBill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCreateBill.IconSize = 24;
            this.btnCreateBill.Location = new System.Drawing.Point(18, 25);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(482, 45);
            this.btnCreateBill.TabIndex = 0;
            this.btnCreateBill.Text = "TẠO HÓA ĐƠN";
            this.btnCreateBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateBill.UseVisualStyleBackColor = false;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // SalesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "SalesControl";
            this.Size = new System.Drawing.Size(1350, 830);
            this.Load += new System.EventHandler(this.SalesControl_Load);
            this.panelMain.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.panelBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.panelBookSearch.ResumeLayout(false);
            this.panelBookSearch.PerformLayout();
            this.panelCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelCartActions.ResumeLayout(false);
            this.panelCartActions.PerformLayout();
            this.panelCustomer.ResumeLayout(false);
            this.tableLayoutCustomer.ResumeLayout(false);
            this.tableLayoutCustomer.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #region Controls

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelBooks;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Panel panelBookSearch;
        private FontAwesome.Sharp.IconButton btnAddToCart;
        private FontAwesome.Sharp.IconButton btnSearchBook;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.Label lblBookSearch;
        private System.Windows.Forms.Panel panelCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel panelCartActions;
        private System.Windows.Forms.Label lblTotalAmount;
        private FontAwesome.Sharp.IconButton btnRemoveFromCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Panel panelCustomer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCustomer;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private FontAwesome.Sharp.IconButton btnSearchCustomer;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private FontAwesome.Sharp.IconButton btnNewCustomer;
        private System.Windows.Forms.Panel panelActions;
        private FontAwesome.Sharp.IconButton btnPrintBill;
        private FontAwesome.Sharp.IconButton btnCancelBill;
        private FontAwesome.Sharp.IconButton btnCreateBill;

        #endregion
    }
}