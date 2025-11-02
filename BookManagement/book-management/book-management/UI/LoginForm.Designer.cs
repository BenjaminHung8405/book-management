namespace book_management
{
    partial class LoginForm
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.iconLock = new FontAwesome.Sharp.IconPictureBox();
            this.btnTogglePasswordVisibility = new FontAwesome.Sharp.IconButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblClose = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.iconUser = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconLock)).BeginInit();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbLogo.Image = global::book_management.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(125, 30);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 200);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(127, 192);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(219, 37);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "ĐĂNG NHẬP";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(134, 230);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(207, 29);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Chào mừng trở lại!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(41, 299);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Tên đăng nhập";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(41, 401);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 20);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassword.Controls.Add(this.iconLock);
            this.pnlPassword.Controls.Add(this.btnTogglePasswordVisibility);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(45, 426);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(366, 49);
            this.pnlPassword.TabIndex = 4;
            // 
            // iconLock
            // 
            this.iconLock.BackColor = System.Drawing.Color.White;
            this.iconLock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconLock.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconLock.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconLock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconLock.IconSize = 40;
            this.iconLock.Location = new System.Drawing.Point(3, 2);
            this.iconLock.Name = "iconLock";
            this.iconLock.Size = new System.Drawing.Size(40, 40);
            this.iconLock.TabIndex = 8;
            this.iconLock.TabStop = false;
            // 
            // btnTogglePasswordVisibility
            // 
            this.btnTogglePasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePasswordVisibility.FlatAppearance.BorderSize = 0;
            this.btnTogglePasswordVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTogglePasswordVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnTogglePasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePasswordVisibility.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnTogglePasswordVisibility.IconColor = System.Drawing.Color.Black;
            this.btnTogglePasswordVisibility.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTogglePasswordVisibility.IconSize = 35;
            this.btnTogglePasswordVisibility.Location = new System.Drawing.Point(329, 7);
            this.btnTogglePasswordVisibility.Name = "btnTogglePasswordVisibility";
            this.btnTogglePasswordVisibility.Size = new System.Drawing.Size(30, 30);
            this.btnTogglePasswordVisibility.TabIndex = 2;
            this.btnTogglePasswordVisibility.UseVisualStyleBackColor = true;
            this.btnTogglePasswordVisibility.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(51, 9);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(267, 24);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(45, 560);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(366, 72);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.Location = new System.Drawing.Point(396, 21);
            this.lblClose.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(27, 25);
            this.lblClose.TabIndex = 7;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(51, 10);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(308, 24);
            this.txtUsername.TabIndex = 1;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsername.Controls.Add(this.iconUser);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(45, 324);
            this.pnlUsername.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(366, 49);
            this.pnlUsername.TabIndex = 2;
            // 
            // iconUser
            // 
            this.iconUser.BackColor = System.Drawing.Color.White;
            this.iconUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconUser.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconUser.IconSize = 40;
            this.iconUser.Location = new System.Drawing.Point(3, 3);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(40, 40);
            this.iconUser.TabIndex = 9;
            this.iconUser.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 800);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.pnlUsername);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconLock)).EndInit();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsername; 
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel pnlUsername;
        private FontAwesome.Sharp.IconButton btnTogglePasswordVisibility;
        private FontAwesome.Sharp.IconPictureBox iconLock;
        private FontAwesome.Sharp.IconPictureBox iconUser;
    }
}

