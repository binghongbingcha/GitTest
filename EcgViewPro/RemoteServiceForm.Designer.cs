namespace EcgViewPro
{
    partial class RemoteServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteServiceForm));
            this.cBoxLevel = new System.Windows.Forms.ComboBox();
            this.txtBoxUrlPassWord = new System.Windows.Forms.TextBox();
            this.txtBoxUrlUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEditAppUrl = new DevExpress.XtraEditors.TextEdit();
            this.lbLevel = new System.Windows.Forms.Label();
            this.lbAppUrl = new System.Windows.Forms.Label();
            this.panelWebSet = new System.Windows.Forms.Panel();
            this.btnResetUrl = new System.Windows.Forms.Button();
            this.btnSaveUrl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditAppUrl.Properties)).BeginInit();
            this.panelWebSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxLevel
            // 
            this.cBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxLevel.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cBoxLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cBoxLevel.FormattingEnabled = true;
            this.cBoxLevel.Items.AddRange(new object[] {
            "初审",
            "复审",
            "终审"});
            this.cBoxLevel.Location = new System.Drawing.Point(173, 148);
            this.cBoxLevel.Name = "cBoxLevel";
            this.cBoxLevel.Size = new System.Drawing.Size(121, 35);
            this.cBoxLevel.TabIndex = 14;
            // 
            // txtBoxUrlPassWord
            // 
            this.txtBoxUrlPassWord.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.txtBoxUrlPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxUrlPassWord.Location = new System.Drawing.Point(173, 105);
            this.txtBoxUrlPassWord.Name = "txtBoxUrlPassWord";
            this.txtBoxUrlPassWord.PasswordChar = '*';
            this.txtBoxUrlPassWord.Size = new System.Drawing.Size(463, 34);
            this.txtBoxUrlPassWord.TabIndex = 13;
            // 
            // txtBoxUrlUserName
            // 
            this.txtBoxUrlUserName.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.txtBoxUrlUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxUrlUserName.Location = new System.Drawing.Point(173, 61);
            this.txtBoxUrlUserName.Name = "txtBoxUrlUserName";
            this.txtBoxUrlUserName.Size = new System.Drawing.Size(463, 34);
            this.txtBoxUrlUserName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(92, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(72, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "用户名：";
            // 
            // txtEditAppUrl
            // 
            this.txtEditAppUrl.Location = new System.Drawing.Point(173, 15);
            this.txtEditAppUrl.Name = "txtEditAppUrl";
            this.txtEditAppUrl.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.txtEditAppUrl.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtEditAppUrl.Properties.Appearance.Options.UseFont = true;
            this.txtEditAppUrl.Properties.Appearance.Options.UseForeColor = true;
            this.txtEditAppUrl.Size = new System.Drawing.Size(463, 34);
            this.txtEditAppUrl.TabIndex = 4;
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbLevel.Location = new System.Drawing.Point(12, 151);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(152, 27);
            this.lbLevel.TabIndex = 0;
            this.lbLevel.Text = "远程申请级别：";
            // 
            // lbAppUrl
            // 
            this.lbAppUrl.AutoSize = true;
            this.lbAppUrl.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lbAppUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbAppUrl.Location = new System.Drawing.Point(14, 18);
            this.lbAppUrl.Name = "lbAppUrl";
            this.lbAppUrl.Size = new System.Drawing.Size(150, 27);
            this.lbAppUrl.TabIndex = 0;
            this.lbAppUrl.Text = "远程判读URL：";
            // 
            // panelWebSet
            // 
            this.panelWebSet.BackColor = System.Drawing.Color.White;
            this.panelWebSet.Controls.Add(this.btnResetUrl);
            this.panelWebSet.Controls.Add(this.btnSaveUrl);
            this.panelWebSet.Controls.Add(this.cBoxLevel);
            this.panelWebSet.Controls.Add(this.txtBoxUrlPassWord);
            this.panelWebSet.Controls.Add(this.lbAppUrl);
            this.panelWebSet.Controls.Add(this.txtBoxUrlUserName);
            this.panelWebSet.Controls.Add(this.lbLevel);
            this.panelWebSet.Controls.Add(this.label2);
            this.panelWebSet.Controls.Add(this.txtEditAppUrl);
            this.panelWebSet.Controls.Add(this.label1);
            this.panelWebSet.Location = new System.Drawing.Point(0, 0);
            this.panelWebSet.Name = "panelWebSet";
            this.panelWebSet.Size = new System.Drawing.Size(758, 225);
            this.panelWebSet.TabIndex = 3;
            // 
            // btnResetUrl
            // 
            this.btnResetUrl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnResetUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetUrl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetUrl.ForeColor = System.Drawing.Color.White;
            this.btnResetUrl.Location = new System.Drawing.Point(539, 163);
            this.btnResetUrl.Margin = new System.Windows.Forms.Padding(0);
            this.btnResetUrl.Name = "btnResetUrl";
            this.btnResetUrl.Size = new System.Drawing.Size(155, 55);
            this.btnResetUrl.TabIndex = 99;
            this.btnResetUrl.TabStop = false;
            this.btnResetUrl.Text = "重置";
            this.btnResetUrl.UseVisualStyleBackColor = false;
            this.btnResetUrl.Click += new System.EventHandler(this.btnResetUrl_Click);
            this.btnResetUrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnResetUrl_MouseDown);
            this.btnResetUrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnResetUrl_MouseUp);
            // 
            // btnSaveUrl
            // 
            this.btnSaveUrl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSaveUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUrl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveUrl.ForeColor = System.Drawing.Color.White;
            this.btnSaveUrl.Location = new System.Drawing.Point(351, 163);
            this.btnSaveUrl.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveUrl.Name = "btnSaveUrl";
            this.btnSaveUrl.Size = new System.Drawing.Size(155, 55);
            this.btnSaveUrl.TabIndex = 99;
            this.btnSaveUrl.TabStop = false;
            this.btnSaveUrl.Text = "保存";
            this.btnSaveUrl.UseVisualStyleBackColor = false;
            this.btnSaveUrl.Click += new System.EventHandler(this.btnSaveUrl_Click);
            this.btnSaveUrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSaveUrl_MouseDown);
            this.btnSaveUrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSaveUrl_MouseUp);
            // 
            // RemoteServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(758, 225);
            this.Controls.Add(this.panelWebSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteServiceForm";
            this.Text = "远程服务";
            this.Load += new System.EventHandler(this.RemoteServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEditAppUrl.Properties)).EndInit();
            this.panelWebSet.ResumeLayout(false);
            this.panelWebSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxLevel;
        private System.Windows.Forms.TextBox txtBoxUrlPassWord;
        private System.Windows.Forms.TextBox txtBoxUrlUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtEditAppUrl;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbAppUrl;
        private System.Windows.Forms.Panel panelWebSet;
        private System.Windows.Forms.Button btnResetUrl;
        private System.Windows.Forms.Button btnSaveUrl;
    }
}