namespace EcgViewPro
{
    partial class SystemSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSetForm));
            this.xtraTabControlSystem = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageHospital = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPagePasswordSet = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageLeadSet = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageColorSet = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageRemoteService = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageAboutUs = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlSystem)).BeginInit();
            this.xtraTabControlSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControlSystem
            // 
            this.xtraTabControlSystem.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.xtraTabControlSystem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.xtraTabControlSystem.Appearance.Options.UseBackColor = true;
            this.xtraTabControlSystem.Appearance.Options.UseForeColor = true;
            this.xtraTabControlSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlSystem.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabControlSystem.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlSystem.Name = "xtraTabControlSystem";
            this.xtraTabControlSystem.SelectedTabPage = this.xtraTabPageHospital;
            this.xtraTabControlSystem.Size = new System.Drawing.Size(1098, 688);
            this.xtraTabControlSystem.TabIndex = 0;
            this.xtraTabControlSystem.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageHospital,
            this.xtraTabPagePasswordSet,
            this.xtraTabPageLeadSet,
            this.xtraTabPageColorSet,
            this.xtraTabPageRemoteService,
            this.xtraTabPageAboutUs});
            this.xtraTabControlSystem.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlSystem_SelectedPageChanged);
            // 
            // xtraTabPageHospital
            // 
            this.xtraTabPageHospital.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabPageHospital.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageHospital.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xtraTabPageHospital.Name = "xtraTabPageHospital";
            this.xtraTabPageHospital.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPageHospital.Text = "医院信息";
            // 
            // xtraTabPagePasswordSet
            // 
            this.xtraTabPagePasswordSet.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.xtraTabPagePasswordSet.Appearance.Header.Options.UseFont = true;
            this.xtraTabPagePasswordSet.Font = new System.Drawing.Font("宋体", 9F);
            this.xtraTabPagePasswordSet.Name = "xtraTabPagePasswordSet";
            this.xtraTabPagePasswordSet.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPagePasswordSet.Text = "修改密码";
            // 
            // xtraTabPageLeadSet
            // 
            this.xtraTabPageLeadSet.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.xtraTabPageLeadSet.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageLeadSet.Font = new System.Drawing.Font("宋体", 9F);
            this.xtraTabPageLeadSet.Name = "xtraTabPageLeadSet";
            this.xtraTabPageLeadSet.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPageLeadSet.Text = "节律导联";
            // 
            // xtraTabPageColorSet
            // 
            this.xtraTabPageColorSet.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.xtraTabPageColorSet.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageColorSet.Font = new System.Drawing.Font("宋体", 9F);
            this.xtraTabPageColorSet.Name = "xtraTabPageColorSet";
            this.xtraTabPageColorSet.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPageColorSet.Text = "显示颜色";
            // 
            // xtraTabPageRemoteService
            // 
            this.xtraTabPageRemoteService.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.xtraTabPageRemoteService.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageRemoteService.Font = new System.Drawing.Font("宋体", 9F);
            this.xtraTabPageRemoteService.Name = "xtraTabPageRemoteService";
            this.xtraTabPageRemoteService.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPageRemoteService.Text = "远程服务";
            // 
            // xtraTabPageAboutUs
            // 
            this.xtraTabPageAboutUs.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.xtraTabPageAboutUs.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageAboutUs.Name = "xtraTabPageAboutUs";
            this.xtraTabPageAboutUs.Size = new System.Drawing.Size(1092, 646);
            this.xtraTabPageAboutUs.Text = "关于我们";
            // 
            // SystemSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.xtraTabControlSystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemSetForm";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SystemSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlSystem)).EndInit();
            this.xtraTabControlSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlSystem;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageHospital;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePasswordSet;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLeadSet;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageColorSet;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRemoteService;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAboutUs;
    }
}