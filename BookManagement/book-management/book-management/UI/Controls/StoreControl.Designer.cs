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
            this.panelBookSelection = new System.Windows.Forms.Panel();
            this.flowPanelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearchBook = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panelOrderDetails = new System.Windows.Forms.Panel();
            this.flowPanelOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOrderFooter = new System.Windows.Forms.Panel();
            this.panelOrderHeader = new System.Windows.Forms.Panel();
            this.panelBookSelection.SuspendLayout();
            this.panelSearchBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelOrderDetails.SuspendLayout();
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
            this.textBox1.Size = new System.Drawing.Size(714, 21);
            this.textBox1.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
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
            this.panelOrderFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrderFooter.Location = new System.Drawing.Point(0, 610);
            this.panelOrderFooter.Name = "panelOrderFooter";
            this.panelOrderFooter.Padding = new System.Windows.Forms.Padding(16);
            this.panelOrderFooter.Size = new System.Drawing.Size(509, 170);
            this.panelOrderFooter.TabIndex = 1;
            // 
            // panelOrderHeader
            // 
            this.panelOrderHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderHeader.Location = new System.Drawing.Point(0, 0);
            this.panelOrderHeader.Name = "panelOrderHeader";
            this.panelOrderHeader.Padding = new System.Windows.Forms.Padding(16);
            this.panelOrderHeader.Size = new System.Drawing.Size(509, 140);
            this.panelOrderHeader.TabIndex = 0;
            // 
            // StoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBookSelection);
            this.Controls.Add(this.panelOrderDetails);
            this.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "StoreControl";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Size = new System.Drawing.Size(1350, 830);
            this.panelBookSelection.ResumeLayout(false);
            this.panelSearchBook.ResumeLayout(false);
            this.panelSearchBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelOrderDetails.ResumeLayout(false);
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
    }
}
