namespace book_management.UI.Controls
{
    partial class ucBookCard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbTacGia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoEllipsis = true;
            this.lbTenSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(0, 160);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lbTenSach.Size = new System.Drawing.Size(173, 48); // Giảm chiều cao từ 56 xuống 48
            this.lbTenSach.TabIndex = 1;
            this.lbTenSach.Text = "Tên sách rất dài để kiểm tra chức năng tự động rút gọn";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoEllipsis = true;
            this.lbTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTacGia.Location = new System.Drawing.Point(0, 208); // Cập nhật vị trí
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTacGia.Size = new System.Drawing.Size(173, 24); // Giảm chiều cao từ 28 xuống 24
            this.lbTacGia.TabIndex = 1;
            this.lbTacGia.Text = "Tên tác giả";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(0, 232); // Cập nhật vị trí
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0); // Giảm padding top
            this.label1.Size = new System.Drawing.Size(173, 28); // Cập nhật Size
            this.label1.TabIndex = 2;
            this.label1.Text = "Giá tiền";
            // 
            // ucBookCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTacGia);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucBookCard";
            this.Size = new System.Drawing.Size(173, 260); // Tăng chiều cao tổng thể
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label label1;
    }
}
