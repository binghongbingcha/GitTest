namespace EcgViewPro
{
    partial class EcgGatherFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                try
                {
                    _bmp.Dispose();
                    components.Dispose();
                }
                catch { }
            }
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EcgGatherFrm));
            this.lbBPMTab = new System.Windows.Forms.Label();
            this.lb_BPM = new System.Windows.Forms.Label();
            this.lbBPM = new System.Windows.Forms.Label();
            this.lb_Age = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lb_Sex = new System.Windows.Forms.Label();
            this.lbSex = new System.Windows.Forms.Label();
            this.lb_Name = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.timer_Record = new System.Windows.Forms.Timer(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.lb_RecordTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Speed = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.timer_BPM = new System.Windows.Forms.Timer(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lb_Title = new System.Windows.Forms.Label();
            this.pictureEdit1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolSbtn_Repeat = new System.Windows.Forms.Button();
            this.toolSbtn_Ecg = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBPMTab
            // 
            this.lbBPMTab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBPMTab.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbBPMTab.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbBPMTab.Location = new System.Drawing.Point(547, 17);
            this.lbBPMTab.Name = "lbBPMTab";
            this.lbBPMTab.Size = new System.Drawing.Size(403, 28);
            this.lbBPMTab.TabIndex = 37;
            this.lbBPMTab.Text = "导联状态";
            this.lbBPMTab.Visible = false;
            // 
            // lb_BPM
            // 
            this.lb_BPM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_BPM.AutoSize = true;
            this.lb_BPM.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_BPM.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_BPM.Location = new System.Drawing.Point(903, 17);
            this.lb_BPM.Name = "lb_BPM";
            this.lb_BPM.Size = new System.Drawing.Size(46, 23);
            this.lb_BPM.TabIndex = 36;
            this.lb_BPM.Text = "——";
            // 
            // lbBPM
            // 
            this.lbBPM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbBPM.AutoSize = true;
            this.lbBPM.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lbBPM.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbBPM.Location = new System.Drawing.Point(963, 17);
            this.lbBPM.Name = "lbBPM";
            this.lbBPM.Size = new System.Drawing.Size(48, 23);
            this.lbBPM.TabIndex = 0;
            this.lbBPM.Text = "bpm";
            // 
            // lb_Age
            // 
            this.lb_Age.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_Age.AutoSize = true;
            this.lb_Age.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_Age.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_Age.Location = new System.Drawing.Point(405, 17);
            this.lb_Age.Name = "lb_Age";
            this.lb_Age.Size = new System.Drawing.Size(27, 23);
            this.lb_Age.TabIndex = 7;
            this.lb_Age.Text = "无";
            // 
            // lbAge
            // 
            this.lbAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lbAge.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbAge.Location = new System.Drawing.Point(324, 17);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(68, 23);
            this.lbAge.TabIndex = 6;
            this.lbAge.Text = "年    龄:";
            // 
            // lb_Sex
            // 
            this.lb_Sex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_Sex.AutoSize = true;
            this.lb_Sex.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_Sex.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_Sex.Location = new System.Drawing.Point(232, 17);
            this.lb_Sex.Name = "lb_Sex";
            this.lb_Sex.Size = new System.Drawing.Size(27, 23);
            this.lb_Sex.TabIndex = 5;
            this.lb_Sex.Text = "无";
            // 
            // lbSex
            // 
            this.lbSex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSex.AutoSize = true;
            this.lbSex.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lbSex.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbSex.Location = new System.Drawing.Point(153, 17);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(68, 23);
            this.lbSex.TabIndex = 4;
            this.lbSex.Text = "性    别:";
            // 
            // lb_Name
            // 
            this.lb_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_Name.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_Name.Location = new System.Drawing.Point(86, 17);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(27, 23);
            this.lb_Name.TabIndex = 3;
            this.lb_Name.Text = "无";
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lbName.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbName.Location = new System.Drawing.Point(8, 17);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(68, 23);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "姓    名:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel3.Controls.Add(this.radioButton4, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(119, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(65, 16);
            this.radioButton4.TabIndex = 15;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "20mm/mv";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(-20, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(1, 8);
            this.radioButton5.TabIndex = 14;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "10";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // timer_Record
            // 
            this.timer_Record.Interval = 1000;
            this.timer_Record.Tick += new System.EventHandler(this.timer_Record_Tick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.lb_RecordTime);
            this.panelTop.Controls.Add(this.lbName);
            this.panelTop.Controls.Add(this.lbBPM);
            this.panelTop.Controls.Add(this.lb_Name);
            this.panelTop.Controls.Add(this.lbSex);
            this.panelTop.Controls.Add(this.lb_Sex);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.lb_Speed);
            this.panelTop.Controls.Add(this.lbSpeed);
            this.panelTop.Controls.Add(this.lb_Age);
            this.panelTop.Controls.Add(this.lbAge);
            this.panelTop.Controls.Add(this.lb_BPM);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1350, 54);
            this.panelTop.TabIndex = 31;
            // 
            // lb_RecordTime
            // 
            this.lb_RecordTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_RecordTime.AutoSize = true;
            this.lb_RecordTime.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_RecordTime.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_RecordTime.Location = new System.Drawing.Point(1048, 17);
            this.lb_RecordTime.Name = "lb_RecordTime";
            this.lb_RecordTime.Size = new System.Drawing.Size(95, 23);
            this.lb_RecordTime.TabIndex = 38;
            this.lb_RecordTime.Text = "记录倒计时";
            this.lb_RecordTime.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.label2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label2.Location = new System.Drawing.Point(756, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "10mm/mV";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.label1.ForeColor = System.Drawing.Color.LawnGreen;
            this.label1.Location = new System.Drawing.Point(675, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "增    益:";
            // 
            // lb_Speed
            // 
            this.lb_Speed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_Speed.AutoSize = true;
            this.lb_Speed.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lb_Speed.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_Speed.Location = new System.Drawing.Point(570, 17);
            this.lb_Speed.Name = "lb_Speed";
            this.lb_Speed.Size = new System.Drawing.Size(77, 23);
            this.lb_Speed.TabIndex = 7;
            this.lb_Speed.Text = "25mm/s";
            // 
            // lbSpeed
            // 
            this.lbSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.lbSpeed.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbSpeed.Location = new System.Drawing.Point(489, 17);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(68, 23);
            this.lbSpeed.TabIndex = 6;
            this.lbSpeed.Text = "走    速:";
            // 
            // timer_BPM
            // 
            this.timer_BPM.Enabled = true;
            this.timer_BPM.Interval = 500;
            this.timer_BPM.Tick += new System.EventHandler(this.timer_BPM_Tick);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Black;
            this.panelBottom.Controls.Add(this.btnExit);
            this.panelBottom.Controls.Add(this.toolSbtn_Repeat);
            this.panelBottom.Controls.Add(this.toolSbtn_Ecg);
            this.panelBottom.Controls.Add(this.lbBPMTab);
            this.panelBottom.Controls.Add(this.lb_Title);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 667);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1350, 62);
            this.panelBottom.TabIndex = 35;
            // 
            // lb_Title
            // 
            this.lb_Title.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lb_Title.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_Title.Location = new System.Drawing.Point(973, 17);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(303, 28);
            this.lb_Title.TabIndex = 33;
            this.lb_Title.Text = "心电数据正在记录，请稍候再关闭";
            this.lb_Title.Visible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackColor = System.Drawing.Color.Black;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 54);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(1350, 613);
            this.pictureEdit1.TabIndex = 34;
            this.pictureEdit1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(354, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 55);
            this.btnExit.TabIndex = 40;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseDown);
            this.btnExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseUp);
            // 
            // toolSbtn_Repeat
            // 
            this.toolSbtn_Repeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolSbtn_Repeat.BackgroundImage")));
            this.toolSbtn_Repeat.Enabled = false;
            this.toolSbtn_Repeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolSbtn_Repeat.Location = new System.Drawing.Point(178, 4);
            this.toolSbtn_Repeat.Name = "toolSbtn_Repeat";
            this.toolSbtn_Repeat.Size = new System.Drawing.Size(155, 55);
            this.toolSbtn_Repeat.TabIndex = 39;
            this.toolSbtn_Repeat.UseVisualStyleBackColor = true;
            this.toolSbtn_Repeat.Click += new System.EventHandler(this.toolSbtn_Repeat_Click);
            this.toolSbtn_Repeat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolSbtn_Repeat_MouseDown);
            this.toolSbtn_Repeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolSbtn_Repeat_MouseUp);
            // 
            // toolSbtn_Ecg
            // 
            this.toolSbtn_Ecg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolSbtn_Ecg.BackgroundImage")));
            this.toolSbtn_Ecg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolSbtn_Ecg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolSbtn_Ecg.Location = new System.Drawing.Point(2, 4);
            this.toolSbtn_Ecg.Name = "toolSbtn_Ecg";
            this.toolSbtn_Ecg.Size = new System.Drawing.Size(155, 55);
            this.toolSbtn_Ecg.TabIndex = 38;
            this.toolSbtn_Ecg.UseVisualStyleBackColor = true;
            this.toolSbtn_Ecg.Click += new System.EventHandler(this.toolSbtn_Ecg_Click);
            // 
            // EcgGatherFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcgGatherFrm";
            this.Text = "多参一体机(版本V2.1)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EcgGatherFrm_FormClosing);
            this.Load += new System.EventHandler(this.EcgGather_Frm_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Timer timer_Record;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lb_Sex;
        private System.Windows.Forms.Label lbSex;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lb_BPM;
        private System.Windows.Forms.Label lbBPM;
        private System.Windows.Forms.Label lb_Age;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Timer timer_BPM;
        private System.Windows.Forms.Label lbBPMTab;
        private System.Windows.Forms.PictureBox pictureEdit1;
        private int _dCount = 0;
        private System.Windows.Forms.Label lb_RecordTime;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Speed;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Button toolSbtn_Repeat;
        private System.Windows.Forms.Button toolSbtn_Ecg;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Button btnExit;
    }
}

