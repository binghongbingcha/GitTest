namespace EcgViewPro
{
    partial class FormLogin
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
            this.cBoxUsername = new System.Windows.Forms.ComboBox();
            this.txtBox_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.cbRember = new System.Windows.Forms.CheckBox();
            this.pBoxLoginImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLoginImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxUsername
            // 
            this.cBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBoxUsername.DropDownHeight = 90;
            this.cBoxUsername.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cBoxUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cBoxUsername.IntegralHeight = false;
            this.cBoxUsername.ItemHeight = 25;
            this.cBoxUsername.Location = new System.Drawing.Point(980, 250);
            this.cBoxUsername.Name = "cBoxUsername";
            this.cBoxUsername.Size = new System.Drawing.Size(277, 33);
            this.cBoxUsername.TabIndex = 5;
            this.cBoxUsername.SelectedValueChanged += new System.EventHandler(this.cBoxUsername_SelectedValueChanged);
            this.cBoxUsername.Click += new System.EventHandler(this.cBoxUsername_Click);
            // 
            // txtBox_Password
            // 
            this.txtBox_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBox_Password.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtBox_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBox_Password.Location = new System.Drawing.Point(980, 325);
            this.txtBox_Password.Name = "txtBox_Password";
            this.txtBox_Password.PasswordChar = '●';
            this.txtBox_Password.Size = new System.Drawing.Size(277, 32);
            this.txtBox_Password.TabIndex = 1;
            this.txtBox_Password.Click += new System.EventHandler(this.cBoxUsername_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(228)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(899, 466);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(361, 60);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            this.btn_Login.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Login_MouseDown);
            this.btn_Login.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Login_MouseUp);
            // 
            // cbRember
            // 
            this.cbRember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRember.BackColor = System.Drawing.Color.White;
            this.cbRember.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cbRember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cbRember.Location = new System.Drawing.Point(903, 406);
            this.cbRember.Name = "cbRember";
            this.cbRember.Size = new System.Drawing.Size(108, 29);
            this.cbRember.TabIndex = 4;
            this.cbRember.Text = "记住密码";
            this.cbRember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRember.UseVisualStyleBackColor = false;
            // 
            // pBoxLoginImage
            // 
            this.pBoxLoginImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBoxLoginImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(228)))));
            this.pBoxLoginImage.BackgroundImage = global::EcgViewPro.Properties.Resources.login;
            this.pBoxLoginImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pBoxLoginImage.Location = new System.Drawing.Point(1, 1);
            this.pBoxLoginImage.Name = "pBoxLoginImage";
            this.pBoxLoginImage.Size = new System.Drawing.Size(1370, 768);
            this.pBoxLoginImage.TabIndex = 8;
            this.pBoxLoginImage.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(130)))), ((int)(((byte)(219)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.cbRember);
            this.Controls.Add(this.txtBox_Password);
            this.Controls.Add(this.cBoxUsername);
            this.Controls.Add(this.pBoxLoginImage);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLoginImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxLoginImage;
        private System.Windows.Forms.CheckBox cbRember;
        private System.Windows.Forms.ComboBox cBoxUsername;
        private System.Windows.Forms.TextBox txtBox_Password;
        private System.Windows.Forms.Button btn_Login;
    }
}