namespace EcgViewPro
{
    partial class SystemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemForm));
            this.panelSystemFill = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSystemMod = new System.Windows.Forms.Button();
            this.txtBoxNewOkPassword = new System.Windows.Forms.TextBox();
            this.lbNewOkPassword = new System.Windows.Forms.Label();
            this.txtBoxNewPassword = new System.Windows.Forms.TextBox();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.txtBoxOldPassword = new System.Windows.Forms.TextBox();
            this.lbOldPassword = new System.Windows.Forms.Label();
            this.panelSystemFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSystemFill
            // 
            this.panelSystemFill.BackColor = System.Drawing.Color.White;
            this.panelSystemFill.Controls.Add(this.label3);
            this.panelSystemFill.Controls.Add(this.btnSystemMod);
            this.panelSystemFill.Controls.Add(this.txtBoxNewOkPassword);
            this.panelSystemFill.Controls.Add(this.lbNewOkPassword);
            this.panelSystemFill.Controls.Add(this.txtBoxNewPassword);
            this.panelSystemFill.Controls.Add(this.lbNewPassword);
            this.panelSystemFill.Controls.Add(this.txtBoxOldPassword);
            this.panelSystemFill.Controls.Add(this.lbOldPassword);
            this.panelSystemFill.Location = new System.Drawing.Point(-1, 5);
            this.panelSystemFill.Name = "panelSystemFill";
            this.panelSystemFill.Size = new System.Drawing.Size(577, 302);
            this.panelSystemFill.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "建议使用8位字母和数字的组合，可以大幅提升帐号安全";
            // 
            // btnSystemMod
            // 
            this.btnSystemMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSystemMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemMod.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystemMod.ForeColor = System.Drawing.Color.White;
            this.btnSystemMod.Location = new System.Drawing.Point(152, 190);
            this.btnSystemMod.Name = "btnSystemMod";
            this.btnSystemMod.Size = new System.Drawing.Size(155, 55);
            this.btnSystemMod.TabIndex = 2;
            this.btnSystemMod.Text = "修改密码";
            this.btnSystemMod.UseVisualStyleBackColor = false;
            this.btnSystemMod.Click += new System.EventHandler(this.btnSystemMod_Click);
            this.btnSystemMod.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSystemMod_MouseDown);
            this.btnSystemMod.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSystemMod_MouseUp);
            // 
            // txtBoxNewOkPassword
            // 
            this.txtBoxNewOkPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxNewOkPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxNewOkPassword.Location = new System.Drawing.Point(152, 129);
            this.txtBoxNewOkPassword.MaxLength = 8;
            this.txtBoxNewOkPassword.Name = "txtBoxNewOkPassword";
            this.txtBoxNewOkPassword.PasswordChar = '●';
            this.txtBoxNewOkPassword.Size = new System.Drawing.Size(295, 34);
            this.txtBoxNewOkPassword.TabIndex = 1;
            this.txtBoxNewOkPassword.Click += new System.EventHandler(this.txtBoxOldPassword_Click);
            this.txtBoxNewOkPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxNewOkPassword_KeyPress);
            // 
            // lbNewOkPassword
            // 
            this.lbNewOkPassword.AutoSize = true;
            this.lbNewOkPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNewOkPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbNewOkPassword.Location = new System.Drawing.Point(21, 133);
            this.lbNewOkPassword.Name = "lbNewOkPassword";
            this.lbNewOkPassword.Size = new System.Drawing.Size(112, 27);
            this.lbNewOkPassword.TabIndex = 0;
            this.lbNewOkPassword.Text = "确认密码：";
            // 
            // txtBoxNewPassword
            // 
            this.txtBoxNewPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxNewPassword.Location = new System.Drawing.Point(152, 73);
            this.txtBoxNewPassword.MaxLength = 8;
            this.txtBoxNewPassword.Name = "txtBoxNewPassword";
            this.txtBoxNewPassword.PasswordChar = '●';
            this.txtBoxNewPassword.Size = new System.Drawing.Size(295, 34);
            this.txtBoxNewPassword.TabIndex = 1;
            this.txtBoxNewPassword.Click += new System.EventHandler(this.txtBoxOldPassword_Click);
            this.txtBoxNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxNewPassword_KeyPress);
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbNewPassword.Location = new System.Drawing.Point(41, 77);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(92, 27);
            this.lbNewPassword.TabIndex = 0;
            this.lbNewPassword.Text = "新密码：";
            // 
            // txtBoxOldPassword
            // 
            this.txtBoxOldPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxOldPassword.Location = new System.Drawing.Point(152, 21);
            this.txtBoxOldPassword.MaxLength = 8;
            this.txtBoxOldPassword.Name = "txtBoxOldPassword";
            this.txtBoxOldPassword.PasswordChar = '●';
            this.txtBoxOldPassword.Size = new System.Drawing.Size(295, 34);
            this.txtBoxOldPassword.TabIndex = 1;
            this.txtBoxOldPassword.Click += new System.EventHandler(this.txtBoxOldPassword_Click);
            this.txtBoxOldPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxOldPassword_KeyPress);
            // 
            // lbOldPassword
            // 
            this.lbOldPassword.AutoSize = true;
            this.lbOldPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbOldPassword.Location = new System.Drawing.Point(21, 25);
            this.lbOldPassword.Name = "lbOldPassword";
            this.lbOldPassword.Size = new System.Drawing.Size(112, 27);
            this.lbOldPassword.TabIndex = 0;
            this.lbOldPassword.Text = "当前密码：";
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 431);
            this.Controls.Add(this.panelSystemFill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemForm";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SystemForm_Load);
            this.panelSystemFill.ResumeLayout(false);
            this.panelSystemFill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSystemFill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSystemMod;
        private System.Windows.Forms.TextBox txtBoxNewOkPassword;
        private System.Windows.Forms.Label lbNewOkPassword;
        private System.Windows.Forms.TextBox txtBoxNewPassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox txtBoxOldPassword;
        private System.Windows.Forms.Label lbOldPassword;
    }
}