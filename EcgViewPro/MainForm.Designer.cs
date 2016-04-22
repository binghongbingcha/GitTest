namespace EcgViewPro
{
    partial class MainForm
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
                _openBlood.Dispose();
                _getTask.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbDoctorName = new System.Windows.Forms.Label();
            this.pBoxRightLogo = new System.Windows.Forms.PictureBox();
            this.pBoxFormLogo = new System.Windows.Forms.PictureBox();
            this.panelFill = new System.Windows.Forms.Panel();
            this.fLPanelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnPatientInfos = new System.Windows.Forms.Button();
            this.btnEcg = new System.Windows.Forms.Button();
            this.btnMmhg = new System.Windows.Forms.Button();
            this.btnSpo2 = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnMmol = new System.Windows.Forms.Button();
            this.btnUrine = new System.Windows.Forms.Button();
            this.btnDoctorInfos = new System.Windows.Forms.Button();
            this.btnSystemInfo = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRightLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFormLogo)).BeginInit();
            this.fLPanelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panelTop.Controls.Add(this.lbTime);
            this.panelTop.Controls.Add(this.lbDoctorName);
            this.panelTop.Controls.Add(this.pBoxRightLogo);
            this.panelTop.Controls.Add(this.pBoxFormLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1366, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(1235, 52);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(124, 22);
            this.lbTime.TabIndex = 4;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDoctorName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbDoctorName.ForeColor = System.Drawing.Color.White;
            this.lbDoctorName.Location = new System.Drawing.Point(1235, 11);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(124, 35);
            this.lbDoctorName.TabIndex = 3;
            this.lbDoctorName.Text = "医生姓名";
            this.lbDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDoctorName.Click += new System.EventHandler(this.lbDoctorName_Click);
            // 
            // pBoxRightLogo
            // 
            this.pBoxRightLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pBoxRightLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBoxRightLogo.Location = new System.Drawing.Point(1140, 9);
            this.pBoxRightLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBoxRightLogo.Name = "pBoxRightLogo";
            this.pBoxRightLogo.Size = new System.Drawing.Size(90, 60);
            this.pBoxRightLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRightLogo.TabIndex = 2;
            this.pBoxRightLogo.TabStop = false;
            // 
            // pBoxFormLogo
            // 
            this.pBoxFormLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBoxFormLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBoxFormLogo.Image = global::EcgViewPro.Properties.Resources.Formlogo;
            this.pBoxFormLogo.Location = new System.Drawing.Point(0, 0);
            this.pBoxFormLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBoxFormLogo.Name = "pBoxFormLogo";
            this.pBoxFormLogo.Size = new System.Drawing.Size(174, 80);
            this.pBoxFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxFormLogo.TabIndex = 1;
            this.pBoxFormLogo.TabStop = false;
            // 
            // panelFill
            // 
            this.panelFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(270, 80);
            this.panelFill.Margin = new System.Windows.Forms.Padding(0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1096, 688);
            this.panelFill.TabIndex = 2;
            // 
            // fLPanelLeft
            // 
            this.fLPanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.fLPanelLeft.Controls.Add(this.btnInfo);
            this.fLPanelLeft.Controls.Add(this.btnPatientInfos);
            this.fLPanelLeft.Controls.Add(this.btnEcg);
            this.fLPanelLeft.Controls.Add(this.btnMmhg);
            this.fLPanelLeft.Controls.Add(this.btnSpo2);
            this.fLPanelLeft.Controls.Add(this.btnC);
            this.fLPanelLeft.Controls.Add(this.btnMmol);
            this.fLPanelLeft.Controls.Add(this.btnUrine);
            this.fLPanelLeft.Controls.Add(this.btnDoctorInfos);
            this.fLPanelLeft.Controls.Add(this.btnSystemInfo);
            this.fLPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.fLPanelLeft.Location = new System.Drawing.Point(0, 80);
            this.fLPanelLeft.Name = "fLPanelLeft";
            this.fLPanelLeft.Size = new System.Drawing.Size(270, 688);
            this.fLPanelLeft.TabIndex = 0;
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = global::EcgViewPro.Properties.Resources.xinxiAfter;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(0, 0);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(270, 66);
            this.btnInfo.TabIndex = 0;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnPatientInfos
            // 
            this.btnPatientInfos.BackgroundImage = global::EcgViewPro.Properties.Resources.jiankuang;
            this.btnPatientInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientInfos.Location = new System.Drawing.Point(0, 66);
            this.btnPatientInfos.Margin = new System.Windows.Forms.Padding(0);
            this.btnPatientInfos.Name = "btnPatientInfos";
            this.btnPatientInfos.Size = new System.Drawing.Size(270, 66);
            this.btnPatientInfos.TabIndex = 1;
            this.btnPatientInfos.UseVisualStyleBackColor = true;
            this.btnPatientInfos.Click += new System.EventHandler(this.btnPatientInfos_Click);
            // 
            // btnEcg
            // 
            this.btnEcg.BackgroundImage = global::EcgViewPro.Properties.Resources.xindian;
            this.btnEcg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEcg.Location = new System.Drawing.Point(0, 132);
            this.btnEcg.Margin = new System.Windows.Forms.Padding(0);
            this.btnEcg.Name = "btnEcg";
            this.btnEcg.Size = new System.Drawing.Size(270, 66);
            this.btnEcg.TabIndex = 2;
            this.btnEcg.UseVisualStyleBackColor = true;
            this.btnEcg.Click += new System.EventHandler(this.btnEcg_Click);
            // 
            // btnMmhg
            // 
            this.btnMmhg.BackgroundImage = global::EcgViewPro.Properties.Resources.xueya;
            this.btnMmhg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMmhg.Location = new System.Drawing.Point(0, 198);
            this.btnMmhg.Margin = new System.Windows.Forms.Padding(0);
            this.btnMmhg.Name = "btnMmhg";
            this.btnMmhg.Size = new System.Drawing.Size(270, 66);
            this.btnMmhg.TabIndex = 3;
            this.btnMmhg.UseVisualStyleBackColor = true;
            this.btnMmhg.Click += new System.EventHandler(this.btnMmhg_Click);
            // 
            // btnSpo2
            // 
            this.btnSpo2.BackgroundImage = global::EcgViewPro.Properties.Resources.xueyang;
            this.btnSpo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpo2.Location = new System.Drawing.Point(0, 264);
            this.btnSpo2.Margin = new System.Windows.Forms.Padding(0);
            this.btnSpo2.Name = "btnSpo2";
            this.btnSpo2.Size = new System.Drawing.Size(270, 66);
            this.btnSpo2.TabIndex = 4;
            this.btnSpo2.UseVisualStyleBackColor = true;
            this.btnSpo2.Click += new System.EventHandler(this.btnSpo2_Click);
            // 
            // btnC
            // 
            this.btnC.BackgroundImage = global::EcgViewPro.Properties.Resources.tiwen;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Location = new System.Drawing.Point(0, 330);
            this.btnC.Margin = new System.Windows.Forms.Padding(0);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(270, 66);
            this.btnC.TabIndex = 5;
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnMmol
            // 
            this.btnMmol.BackgroundImage = global::EcgViewPro.Properties.Resources.xuetang;
            this.btnMmol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMmol.Location = new System.Drawing.Point(0, 396);
            this.btnMmol.Margin = new System.Windows.Forms.Padding(0);
            this.btnMmol.Name = "btnMmol";
            this.btnMmol.Size = new System.Drawing.Size(270, 66);
            this.btnMmol.TabIndex = 6;
            this.btnMmol.UseVisualStyleBackColor = true;
            this.btnMmol.Click += new System.EventHandler(this.btnMmol_Click);
            // 
            // btnUrine
            // 
            this.btnUrine.BackgroundImage = global::EcgViewPro.Properties.Resources.niaochanggui;
            this.btnUrine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrine.Location = new System.Drawing.Point(0, 462);
            this.btnUrine.Margin = new System.Windows.Forms.Padding(0);
            this.btnUrine.Name = "btnUrine";
            this.btnUrine.Size = new System.Drawing.Size(270, 66);
            this.btnUrine.TabIndex = 7;
            this.btnUrine.UseVisualStyleBackColor = true;
            this.btnUrine.Click += new System.EventHandler(this.btnUrine_Click);
            // 
            // btnDoctorInfos
            // 
            this.btnDoctorInfos.BackgroundImage = global::EcgViewPro.Properties.Resources.yisheng;
            this.btnDoctorInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctorInfos.Location = new System.Drawing.Point(0, 528);
            this.btnDoctorInfos.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoctorInfos.Name = "btnDoctorInfos";
            this.btnDoctorInfos.Size = new System.Drawing.Size(270, 66);
            this.btnDoctorInfos.TabIndex = 8;
            this.btnDoctorInfos.UseVisualStyleBackColor = true;
            this.btnDoctorInfos.Visible = false;
            this.btnDoctorInfos.Click += new System.EventHandler(this.btnDoctorInfos_Click);
            // 
            // btnSystemInfo
            // 
            this.btnSystemInfo.BackgroundImage = global::EcgViewPro.Properties.Resources.xitong;
            this.btnSystemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemInfo.Location = new System.Drawing.Point(0, 594);
            this.btnSystemInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnSystemInfo.Name = "btnSystemInfo";
            this.btnSystemInfo.Size = new System.Drawing.Size(270, 66);
            this.btnSystemInfo.TabIndex = 9;
            this.btnSystemInfo.UseVisualStyleBackColor = true;
            this.btnSystemInfo.Click += new System.EventHandler(this.btnSystemInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.fLPanelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "主窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRightLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFormLogo)).EndInit();
            this.fLPanelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Button btnSystemInfo;
        private System.Windows.Forms.Button btnDoctorInfos;
        private System.Windows.Forms.Button btnUrine;
        private System.Windows.Forms.Button btnMmol;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnSpo2;
        private System.Windows.Forms.Button btnMmhg;
        private System.Windows.Forms.Button btnEcg;
        private System.Windows.Forms.Button btnPatientInfos;
        private System.Windows.Forms.PictureBox pBoxFormLogo;
        private System.Windows.Forms.FlowLayoutPanel fLPanelLeft;
        private System.Windows.Forms.PictureBox pBoxRightLogo;
        private System.Windows.Forms.Label lbDoctorName;
        private System.Windows.Forms.Label lbTime;
    }
}