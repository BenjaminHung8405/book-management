namespace book_management.UI.Controls
{
    partial class DashboardControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panelKpiContainer = new System.Windows.Forms.Panel();
            this.panelKpiKhachHang = new System.Windows.Forms.Panel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.lblNewCustomersValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelKpiDonHang = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblNewOrdersValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMonthlyOrdersTotal = new System.Windows.Forms.Label();
            this.panelKpiSachHet = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockThreshold = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelKpiDoanhThu = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblTodayRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueComparison = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMidContainer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label15 = new System.Windows.Forms.Label();
            this.panelQuickActions = new System.Windows.Forms.Panel();
            this.btnAddNewCustomer = new FontAwesome.Sharp.IconButton();
            this.btnAddNewBook = new FontAwesome.Sharp.IconButton();
            this.btnAddBill = new FontAwesome.Sharp.IconButton();
            this.label14 = new System.Windows.Forms.Label();
            this.panelRecentSales = new System.Windows.Forms.Panel();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiTiet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.panelKpiContainer.SuspendLayout();
            this.panelKpiKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.panelKpiDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.panelKpiSachHet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.panelKpiDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelMidContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panelQuickActions.SuspendLayout();
            this.panelRecentSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.label1.Size = new System.Drawing.Size(215, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng Quan";
            // 
            // panelKpiContainer
            // 
            this.panelKpiContainer.Controls.Add(this.panelKpiKhachHang);
            this.panelKpiContainer.Controls.Add(this.panelKpiDonHang);
            this.panelKpiContainer.Controls.Add(this.panelKpiSachHet);
            this.panelKpiContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpiContainer.Location = new System.Drawing.Point(24, 90);
            this.panelKpiContainer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.panelKpiContainer.Name = "panelKpiContainer";
            this.panelKpiContainer.Size = new System.Drawing.Size(979, 154);
            this.panelKpiContainer.TabIndex = 1;
            // 
            // panelKpiKhachHang
            // 
            this.panelKpiKhachHang.BackColor = System.Drawing.Color.White;
            this.panelKpiKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelKpiKhachHang.Controls.Add(this.iconPictureBox4);
            this.panelKpiKhachHang.Controls.Add(this.lblNewCustomersValue);
            this.panelKpiKhachHang.Controls.Add(this.label11);
            this.panelKpiKhachHang.Controls.Add(this.label12);
            this.panelKpiKhachHang.Location = new System.Drawing.Point(995, 0);
            this.panelKpiKhachHang.Name = "panelKpiKhachHang";
            this.panelKpiKhachHang.Padding = new System.Windows.Forms.Padding(16);
            this.panelKpiKhachHang.Size = new System.Drawing.Size(307, 130);
            this.panelKpiKhachHang.TabIndex = 0;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.White;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.iconPictureBox4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 72;
            this.iconPictureBox4.Location = new System.Drawing.Point(212, 29);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(72, 72);
            this.iconPictureBox4.TabIndex = 1;
            this.iconPictureBox4.TabStop = false;
            // 
            // lblNewCustomersValue
            // 
            this.lblNewCustomersValue.AutoEllipsis = true;
            this.lblNewCustomersValue.AutoSize = true;
            this.lblNewCustomersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomersValue.Location = new System.Drawing.Point(19, 51);
            this.lblNewCustomersValue.Name = "lblNewCustomersValue";
            this.lblNewCustomersValue.Size = new System.Drawing.Size(27, 29);
            this.lblNewCustomersValue.TabIndex = 0;
            this.lblNewCustomersValue.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Khách hàng mới";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label12.Location = new System.Drawing.Point(19, 93);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Trong hôm nay";
            // 
            // panelKpiDonHang
            // 
            this.panelKpiDonHang.BackColor = System.Drawing.Color.White;
            this.panelKpiDonHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelKpiDonHang.Controls.Add(this.iconPictureBox2);
            this.panelKpiDonHang.Controls.Add(this.lblNewOrdersValue);
            this.panelKpiDonHang.Controls.Add(this.label5);
            this.panelKpiDonHang.Controls.Add(this.lblMonthlyOrdersTotal);
            this.panelKpiDonHang.Location = new System.Drawing.Point(332, 0);
            this.panelKpiDonHang.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelKpiDonHang.Name = "panelKpiDonHang";
            this.panelKpiDonHang.Padding = new System.Windows.Forms.Padding(16);
            this.panelKpiDonHang.Size = new System.Drawing.Size(307, 130);
            this.panelKpiDonHang.TabIndex = 0;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 72;
            this.iconPictureBox2.Location = new System.Drawing.Point(212, 29);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(72, 72);
            this.iconPictureBox2.TabIndex = 1;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblNewOrdersValue
            // 
            this.lblNewOrdersValue.AutoEllipsis = true;
            this.lblNewOrdersValue.AutoSize = true;
            this.lblNewOrdersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrdersValue.Location = new System.Drawing.Point(19, 51);
            this.lblNewOrdersValue.Name = "lblNewOrdersValue";
            this.lblNewOrdersValue.Size = new System.Drawing.Size(41, 29);
            this.lblNewOrdersValue.TabIndex = 0;
            this.lblNewOrdersValue.Text = "82";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đơn hàng mới";
            // 
            // lblMonthlyOrdersTotal
            // 
            this.lblMonthlyOrdersTotal.AutoSize = true;
            this.lblMonthlyOrdersTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyOrdersTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblMonthlyOrdersTotal.Location = new System.Drawing.Point(19, 93);
            this.lblMonthlyOrdersTotal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.lblMonthlyOrdersTotal.Name = "lblMonthlyOrdersTotal";
            this.lblMonthlyOrdersTotal.Size = new System.Drawing.Size(181, 20);
            this.lblMonthlyOrdersTotal.TabIndex = 0;
            this.lblMonthlyOrdersTotal.Text = "Tổng 562 đơn tháng này";
            // 
            // panelKpiSachHet
            // 
            this.panelKpiSachHet.BackColor = System.Drawing.Color.White;
            this.panelKpiSachHet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelKpiSachHet.Controls.Add(this.iconPictureBox3);
            this.panelKpiSachHet.Controls.Add(this.lblLowStockValue);
            this.panelKpiSachHet.Controls.Add(this.lblLowStockThreshold);
            this.panelKpiSachHet.Controls.Add(this.label9);
            this.panelKpiSachHet.Location = new System.Drawing.Point(664, 0);
            this.panelKpiSachHet.Name = "panelKpiSachHet";
            this.panelKpiSachHet.Padding = new System.Windows.Forms.Padding(16);
            this.panelKpiSachHet.Size = new System.Drawing.Size(307, 130);
            this.panelKpiSachHet.TabIndex = 0;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 72;
            this.iconPictureBox3.Location = new System.Drawing.Point(212, 29);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(72, 72);
            this.iconPictureBox3.TabIndex = 1;
            this.iconPictureBox3.TabStop = false;
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoEllipsis = true;
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockValue.Location = new System.Drawing.Point(19, 51);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(41, 29);
            this.lblLowStockValue.TabIndex = 0;
            this.lblLowStockValue.Text = "15";
            // 
            // lblLowStockThreshold
            // 
            this.lblLowStockThreshold.AutoSize = true;
            this.lblLowStockThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.lblLowStockThreshold.Location = new System.Drawing.Point(19, 93);
            this.lblLowStockThreshold.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.lblLowStockThreshold.Name = "lblLowStockThreshold";
            this.lblLowStockThreshold.Size = new System.Drawing.Size(158, 20);
            this.lblLowStockThreshold.TabIndex = 0;
            this.lblLowStockThreshold.Text = "Số lượng dưới 5 cuốn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sách sắp hết";
            // 
            // panelKpiDoanhThu
            // 
            this.panelKpiDoanhThu.BackColor = System.Drawing.Color.White;
            this.panelKpiDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelKpiDoanhThu.Controls.Add(this.iconPictureBox1);
            this.panelKpiDoanhThu.Controls.Add(this.lblTodayRevenueValue);
            this.panelKpiDoanhThu.Controls.Add(this.lblRevenueComparison);
            this.panelKpiDoanhThu.Controls.Add(this.label2);
            this.panelKpiDoanhThu.Location = new System.Drawing.Point(24, 92);
            this.panelKpiDoanhThu.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelKpiDoanhThu.Name = "panelKpiDoanhThu";
            this.panelKpiDoanhThu.Padding = new System.Windows.Forms.Padding(16);
            this.panelKpiDoanhThu.Size = new System.Drawing.Size(307, 130);
            this.panelKpiDoanhThu.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 72;
            this.iconPictureBox1.Location = new System.Drawing.Point(212, 29);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(72, 72);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblTodayRevenueValue
            // 
            this.lblTodayRevenueValue.AutoEllipsis = true;
            this.lblTodayRevenueValue.AutoSize = true;
            this.lblTodayRevenueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayRevenueValue.Location = new System.Drawing.Point(19, 51);
            this.lblTodayRevenueValue.Name = "lblTodayRevenueValue";
            this.lblTodayRevenueValue.Size = new System.Drawing.Size(154, 29);
            this.lblTodayRevenueValue.TabIndex = 0;
            this.lblTodayRevenueValue.Text = "00.000.000₫";
            // 
            // lblRevenueComparison
            // 
            this.lblRevenueComparison.AutoSize = true;
            this.lblRevenueComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueComparison.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblRevenueComparison.Location = new System.Drawing.Point(19, 93);
            this.lblRevenueComparison.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.lblRevenueComparison.Name = "lblRevenueComparison";
            this.lblRevenueComparison.Size = new System.Drawing.Size(160, 20);
            this.lblRevenueComparison.TabIndex = 0;
            this.lblRevenueComparison.Text = "+15% so với hôm qua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doanh thu hôm nay";
            // 
            // panelMidContainer
            // 
            this.panelMidContainer.Controls.Add(this.panel2);
            this.panelMidContainer.Controls.Add(this.panelQuickActions);
            this.panelMidContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMidContainer.Location = new System.Drawing.Point(24, 244);
            this.panelMidContainer.Margin = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.panelMidContainer.Name = "panelMidContainer";
            this.panelMidContainer.Size = new System.Drawing.Size(979, 344);
            this.panelMidContainer.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chartDoanhThu);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(442, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16);
            this.panel2.Size = new System.Drawing.Size(860, 320);
            this.panel2.TabIndex = 1;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(24, 71);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 3;
            series1.MarkerSize = 10;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Doanh Thu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(814, 228);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "v";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(243, 29);
            this.label15.TabIndex = 0;
            this.label15.Text = "Doanh thu 7 ngày qua";
            // 
            // panelQuickActions
            // 
            this.panelQuickActions.BackColor = System.Drawing.Color.White;
            this.panelQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuickActions.Controls.Add(this.btnAddNewCustomer);
            this.panelQuickActions.Controls.Add(this.btnAddNewBook);
            this.panelQuickActions.Controls.Add(this.btnAddBill);
            this.panelQuickActions.Controls.Add(this.label14);
            this.panelQuickActions.Location = new System.Drawing.Point(0, 0);
            this.panelQuickActions.Name = "panelQuickActions";
            this.panelQuickActions.Padding = new System.Windows.Forms.Padding(16);
            this.panelQuickActions.Size = new System.Drawing.Size(418, 320);
            this.panelQuickActions.TabIndex = 0;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddNewCustomer.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAddNewCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddNewCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddNewCustomer.IconSize = 36;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(25, 235);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(367, 52);
            this.btnAddNewCustomer.TabIndex = 1;
            this.btnAddNewCustomer.Text = "Thêm khách hàng";
            this.btnAddNewCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewCustomer.UseVisualStyleBackColor = false;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // btnAddNewBook
            // 
            this.btnAddNewBook.BackColor = System.Drawing.Color.White;
            this.btnAddNewBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddNewBook.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnAddNewBook.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAddNewBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddNewBook.IconSize = 36;
            this.btnAddNewBook.Location = new System.Drawing.Point(25, 153);
            this.btnAddNewBook.Name = "btnAddNewBook";
            this.btnAddNewBook.Size = new System.Drawing.Size(367, 52);
            this.btnAddNewBook.TabIndex = 1;
            this.btnAddNewBook.Text = "Thêm sách mới";
            this.btnAddNewBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewBook.UseVisualStyleBackColor = false;
            this.btnAddNewBook.Click += new System.EventHandler(this.btnAddNewBook_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnAddBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBill.ForeColor = System.Drawing.Color.White;
            this.btnAddBill.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddBill.IconColor = System.Drawing.Color.White;
            this.btnAddBill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddBill.IconSize = 36;
            this.btnAddBill.Location = new System.Drawing.Point(25, 71);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(367, 52);
            this.btnAddBill.TabIndex = 1;
            this.btnAddBill.Text = "Tạo hóa đơn mới";
            this.btnAddBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBill.UseVisualStyleBackColor = false;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "Tác vụ nhanh";
            // 
            // panelRecentSales
            // 
            this.panelRecentSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelRecentSales.Controls.Add(this.dataGridViewSales);
            this.panelRecentSales.Controls.Add(this.label16);
            this.panelRecentSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecentSales.Location = new System.Drawing.Point(24, 588);
            this.panelRecentSales.Name = "panelRecentSales";
            this.panelRecentSales.Padding = new System.Windows.Forms.Padding(16);
            this.panelRecentSales.Size = new System.Drawing.Size(979, 480);
            this.panelRecentSales.TabIndex = 3;
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeColumns = false;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHoaDon,
            this.colKhachHang,
            this.colNgayTao,
            this.colTongTien,
            this.colTrangThai,
            this.colChiTiet});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSales.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSales.EnableHeadersVisualStyles = false;
            this.dataGridViewSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dataGridViewSales.Location = new System.Drawing.Point(16, 69);
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(947, 395);
            this.dataGridViewSales.TabIndex = 1;
            this.dataGridViewSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSales_CellContentClick);
            this.dataGridViewSales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSales_CellFormatting);
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.DataPropertyName = "MaHoaDon";
            this.colMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            this.colMaHoaDon.Width = 150;
            // 
            // colKhachHang
            // 
            this.colKhachHang.DataPropertyName = "TenKhachHang";
            this.colKhachHang.HeaderText = "Khách hàng";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            this.colKhachHang.Width = 250;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "NgayTao";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.colNgayTao.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            this.colNgayTao.Width = 200;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTongTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            this.colTongTien.Width = 150;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 180;
            // 
            // colChiTiet
            // 
            this.colChiTiet.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.colChiTiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChiTiet.HeaderText = "";
            this.colChiTiet.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.colChiTiet.Name = "colChiTiet";
            this.colChiTiet.ReadOnly = true;
            this.colChiTiet.Text = "Chi tiết";
            this.colChiTiet.TrackVisitedState = false;
            this.colChiTiet.UseColumnTextForLinkValue = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 16);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 0, 3, 24);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.label16.Size = new System.Drawing.Size(194, 53);
            this.label16.TabIndex = 0;
            this.label16.Text = "Hóa đơn gần đây";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.panelRecentSales);
            this.Controls.Add(this.panelMidContainer);
            this.Controls.Add(this.panelKpiDoanhThu);
            this.Controls.Add(this.panelKpiContainer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DashboardControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1027, 830);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.panelKpiContainer.ResumeLayout(false);
            this.panelKpiKhachHang.ResumeLayout(false);
            this.panelKpiKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.panelKpiDonHang.ResumeLayout(false);
            this.panelKpiDonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.panelKpiSachHet.ResumeLayout(false);
            this.panelKpiSachHet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.panelKpiDoanhThu.ResumeLayout(false);
            this.panelKpiDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelMidContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panelQuickActions.ResumeLayout(false);
            this.panelQuickActions.PerformLayout();
            this.panelRecentSales.ResumeLayout(false);
            this.panelRecentSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelKpiContainer;
        private System.Windows.Forms.Panel panelKpiDoanhThu;
        private System.Windows.Forms.Panel panelKpiDonHang;
        private System.Windows.Forms.Panel panelKpiSachHet;
        private System.Windows.Forms.Panel panelKpiKhachHang;
        private System.Windows.Forms.Panel panelMidContainer;
        private System.Windows.Forms.Panel panelQuickActions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTodayRevenueValue;
        private System.Windows.Forms.Label lblRevenueComparison;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label lblNewOrdersValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMonthlyOrdersTotal;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Label lblLowStockThreshold;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label lblNewCustomersValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnAddBill;
        private System.Windows.Forms.Label label14;
        private FontAwesome.Sharp.IconButton btnAddNewCustomer;
        private FontAwesome.Sharp.IconButton btnAddNewBook;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelRecentSales;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewLinkColumn colChiTiet;
    }
}
