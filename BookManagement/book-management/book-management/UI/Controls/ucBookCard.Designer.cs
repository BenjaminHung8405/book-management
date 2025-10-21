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
            this.lbTenSach.AutoSize = true;
            this.lbTenSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTenSach.Font = new System.Drawing.Font("Roboto Cn", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(0, 160);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lbTenSach.Size = new System.Drawing.Size(55, 27);
            this.lbTenSach.TabIndex = 1;
            this.lbTenSach.Text = "label1";
            // 
            // lbTacGia
            // 
            this.lbTacGia.AutoSize = true;
            this.lbTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTacGia.Font = new System.Drawing.Font("Roboto Lt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTacGia.Location = new System.Drawing.Point(0, 187);
            this.lbTacGia.Name = "lbTacGia";
            this.lbTacGia.Size = new System.Drawing.Size(52, 19);
            this.lbTacGia.TabIndex = 1;
            this.lbTacGia.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(0, 206);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label1.Size = new System.Drawing.Size(48, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ucBookCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTacGia);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucBookCard";
            this.Size = new System.Drawing.Size(173, 248);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbTacGia;
        private System.Windows.Forms.Label label1;
    }
}
