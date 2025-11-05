namespace book_management.UI.Modal
{
    partial class frmAddEditBook
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
            this.tableLayoutPanelInputs = new System.Windows.Forms.TableLayoutPanel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtNgonNgu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.numNamXB = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.numSoTrang = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbTacGia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnCancelModal = new System.Windows.Forms.Button();
            this.btnSaveBook = new FontAwesome.Sharp.IconButton();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanelInputs.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTrang)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(314, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm sách mới\" / \"Sửa thông tin sách";
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
            this.panelBody.Controls.Add(this.tableLayoutPanelInputs);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(1, 62);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(24);
            this.panelBody.Size = new System.Drawing.Size(898, 575);
            this.panelBody.TabIndex = 1;
            // 
            // tableLayoutPanelInputs
            // 
            this.tableLayoutPanelInputs.ColumnCount = 2;
            this.tableLayoutPanelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInputs.Controls.Add(this.panel13, 1, 5);
            this.tableLayoutPanelInputs.Controls.Add(this.panel12, 0, 5);
            this.tableLayoutPanelInputs.Controls.Add(this.panel11, 1, 4);
            this.tableLayoutPanelInputs.Controls.Add(this.panel10, 0, 4);
            this.tableLayoutPanelInputs.Controls.Add(this.panel9, 1, 3);
            this.tableLayoutPanelInputs.Controls.Add(this.panel7, 1, 2);
            this.tableLayoutPanelInputs.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanelInputs.Controls.Add(this.panel8, 0, 3);
            this.tableLayoutPanelInputs.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanelInputs.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanelInputs.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanelInputs.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanelInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelInputs.Location = new System.Drawing.Point(24, 24);
            this.tableLayoutPanelInputs.Name = "tableLayoutPanelInputs";
            this.tableLayoutPanelInputs.RowCount = 6;
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInputs.Size = new System.Drawing.Size(833, 591);
            this.tableLayoutPanelInputs.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.txtURL);
            this.panel13.Controls.Add(this.label13);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(419, 493);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(8);
            this.panel13.Size = new System.Drawing.Size(411, 95);
            this.panel13.TabIndex = 14;
            // 
            // txtURL
            // 
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtURL.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtURL.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(8, 35);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(395, 27);
            this.txtURL.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 8);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label13.Size = new System.Drawing.Size(88, 27);
            this.label13.TabIndex = 0;
            this.label13.Text = "URL Ảnh bìa";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtMoTa);
            this.panel12.Controls.Add(this.label12);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(3, 493);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(8);
            this.panel12.Size = new System.Drawing.Size(410, 95);
            this.panel12.TabIndex = 13;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoTa.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(8, 35);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(394, 52);
            this.txtMoTa.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 8);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label12.Size = new System.Drawing.Size(46, 27);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mô tả";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.cbTrangThai);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(419, 395);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(8);
            this.panel11.Size = new System.Drawing.Size(411, 92);
            this.panel11.TabIndex = 12;
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTrangThai.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(8, 35);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(395, 27);
            this.cbTrangThai.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label11.Size = new System.Drawing.Size(75, 27);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trạng thái";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtNgonNgu);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 395);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(8);
            this.panel10.Size = new System.Drawing.Size(410, 92);
            this.panel10.TabIndex = 11;
            // 
            // txtNgonNgu
            // 
            this.txtNgonNgu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgonNgu.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNgonNgu.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgonNgu.Location = new System.Drawing.Point(8, 35);
            this.txtNgonNgu.Name = "txtNgonNgu";
            this.txtNgonNgu.Size = new System.Drawing.Size(394, 27);
            this.txtNgonNgu.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 8);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label10.Size = new System.Drawing.Size(71, 27);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngôn ngữ";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.numNamXB);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(419, 297);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(8);
            this.panel9.Size = new System.Drawing.Size(411, 92);
            this.panel9.TabIndex = 10;
            // 
            // numNamXB
            // 
            this.numNamXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.numNamXB.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNamXB.Location = new System.Drawing.Point(8, 35);
            this.numNamXB.Name = "numNamXB";
            this.numNamXB.Size = new System.Drawing.Size(395, 27);
            this.numNamXB.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label9.Size = new System.Drawing.Size(99, 27);
            this.label9.TabIndex = 0;
            this.label9.Text = "Năm xuất bản";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.numSoTrang);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(419, 199);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(8);
            this.panel7.Size = new System.Drawing.Size(411, 92);
            this.panel7.TabIndex = 9;
            // 
            // numSoTrang
            // 
            this.numSoTrang.Dock = System.Windows.Forms.DockStyle.Top;
            this.numSoTrang.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoTrang.Location = new System.Drawing.Point(8, 35);
            this.numSoTrang.Name = "numSoTrang";
            this.numSoTrang.Size = new System.Drawing.Size(395, 27);
            this.numSoTrang.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label7.Size = new System.Drawing.Size(64, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số trang";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.numSL);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(419, 101);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(8);
            this.panel5.Size = new System.Drawing.Size(411, 92);
            this.panel5.TabIndex = 8;
            // 
            // numSL
            // 
            this.numSL.Dock = System.Windows.Forms.DockStyle.Top;
            this.numSL.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSL.Location = new System.Drawing.Point(8, 35);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(395, 27);
            this.numSL.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số lượng";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtNXB);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 297);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(8);
            this.panel8.Size = new System.Drawing.Size(410, 92);
            this.panel8.TabIndex = 7;
            // 
            // txtNXB
            // 
            this.txtNXB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNXB.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNXB.Location = new System.Drawing.Point(8, 35);
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.Size = new System.Drawing.Size(394, 27);
            this.txtNXB.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label8.Size = new System.Drawing.Size(95, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nhà xuất bản";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbTheLoai);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 199);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(8);
            this.panel6.Size = new System.Drawing.Size(410, 92);
            this.panel6.TabIndex = 4;
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTheLoai.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Location = new System.Drawing.Point(8, 35);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(394, 27);
            this.cbTheLoai.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label6.Size = new System.Drawing.Size(60, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thể loại";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbTacGia);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 101);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8);
            this.panel4.Size = new System.Drawing.Size(410, 92);
            this.panel4.TabIndex = 2;
            // 
            // cbTacGia
            // 
            this.cbTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTacGia.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTacGia.FormattingEnabled = true;
            this.cbTacGia.Location = new System.Drawing.Point(8, 35);
            this.cbTacGia.Name = "cbTacGia";
            this.cbTacGia.Size = new System.Drawing.Size(394, 27);
            this.cbTacGia.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label4.Size = new System.Drawing.Size(56, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tác giả";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numGia);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(419, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(411, 92);
            this.panel3.TabIndex = 1;
            // 
            // numGia
            // 
            this.numGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.numGia.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGia.Location = new System.Drawing.Point(8, 35);
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(395, 27);
            this.numGia.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label3.Size = new System.Drawing.Size(58, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá bán";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTenSach);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(410, 92);
            this.panel2.TabIndex = 0;
            // 
            // txtTenSach
            // 
            this.txtTenSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTenSach.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(8, 35);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(394, 27);
            this.txtTenSach.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label2.Size = new System.Drawing.Size(66, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sách";
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
            // frmAddEditBook
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
            this.Name = "frmAddEditBook";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanelInputs.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTrang)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbTacGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtNgonNgu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.NumericUpDown numNamXB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.NumericUpDown numSoTrang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label12;
    }
}