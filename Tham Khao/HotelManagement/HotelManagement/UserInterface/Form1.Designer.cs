namespace HotelManagement
{
    partial class DangNhap
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
            this.txtMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btCancle = new DevComponents.DotNetBar.ButtonX();
            this.btLogin = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtMatKhau
            // 
            // 
            // 
            // 
            this.txtMatKhau.Border.Class = "TextBoxBorder";
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtMatKhau.Location = new System.Drawing.Point(268, 152);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(200, 29);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // txtTenDangNhap
            // 
            // 
            // 
            // 
            this.txtTenDangNhap.Border.Class = "TextBoxBorder";
            this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(268, 109);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(200, 29);
            this.txtTenDangNhap.TabIndex = 0;
            this.txtTenDangNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenDangNhap_KeyDown);
            // 
            // btCancle
            // 
            this.btCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btCancle.Location = new System.Drawing.Point(371, 190);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(97, 32);
            this.btCancle.TabIndex = 3;
            this.btCancle.Text = "Cancle";
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // btLogin
            // 
            this.btLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btLogin.Location = new System.Drawing.Point(268, 190);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(97, 32);
            this.btLogin.TabIndex = 2;
            this.btLogin.Text = "Login";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = global::HotelManagement.Properties.Resources.LoginBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(530, 250);
            this.ControlBox = false;
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btLogin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DangNhap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Controls.TextBoxX txtMatKhau;
        public DevComponents.DotNetBar.Controls.TextBoxX txtTenDangNhap;
        private DevComponents.DotNetBar.ButtonX btCancle;
        private DevComponents.DotNetBar.ButtonX btLogin;

    }
}

