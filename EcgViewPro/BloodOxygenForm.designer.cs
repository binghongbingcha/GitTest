namespace EcgViewPro
{
    partial class BloodOxygenForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodOxygenForm));
            this.plRight = new System.Windows.Forms.Panel();
            this.txtSpo2Notice = new System.Windows.Forms.TextBox();
            this.lbToop = new System.Windows.Forms.Label();
            this.pBoxToop = new System.Windows.Forms.PictureBox();
            this.plLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSpoTitle = new System.Windows.Forms.Label();
            this.lbHRTitle = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtBoxBloodOxygenId = new System.Windows.Forms.TextBox();
            this.lbBloodOxygenId = new System.Windows.Forms.Label();
            this.btnSpo2 = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lb_SpoCatch = new System.Windows.Forms.Label();
            this.lbHR = new System.Windows.Forms.Label();
            this.lbStandard = new System.Windows.Forms.Label();
            this.lbBloodOxygenBpm = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lb_Spo2 = new System.Windows.Forms.Label();
            this.lbbpm = new System.Windows.Forms.Label();
            this.lbSpo2 = new System.Windows.Forms.Label();
            this.timer_Spo2 = new System.Windows.Forms.Timer(this.components);
            this.plRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxToop)).BeginInit();
            this.plLeft.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // plRight
            // 
            this.plRight.BackColor = System.Drawing.Color.White;
            this.plRight.Controls.Add(this.txtSpo2Notice);
            this.plRight.Controls.Add(this.lbToop);
            this.plRight.Controls.Add(this.pBoxToop);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRight.Location = new System.Drawing.Point(882, 0);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(216, 688);
            this.plRight.TabIndex = 1;
            // 
            // txtSpo2Notice
            // 
            this.txtSpo2Notice.BackColor = System.Drawing.Color.White;
            this.txtSpo2Notice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSpo2Notice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpo2Notice.Enabled = false;
            this.txtSpo2Notice.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtSpo2Notice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSpo2Notice.Location = new System.Drawing.Point(0, 183);
            this.txtSpo2Notice.Multiline = true;
            this.txtSpo2Notice.Name = "txtSpo2Notice";
            this.txtSpo2Notice.ReadOnly = true;
            this.txtSpo2Notice.Size = new System.Drawing.Size(216, 505);
            this.txtSpo2Notice.TabIndex = 4;
            this.txtSpo2Notice.TabStop = false;
            this.txtSpo2Notice.Text = "1、根据标识正确佩戴血氧夹，探头线应该置于手背（指甲面朝上）。\r\n\r\n2、测量时请保持手部血液流通顺畅。\r\n\r\n3、放松身心，稳定情绪，不要移动测量设备，不要说话" +
    "。\r\n\r\n4、待测量结果稳定后，点击“保存”按钮保存测量结果。\r\n";
            // 
            // lbToop
            // 
            this.lbToop.BackColor = System.Drawing.Color.White;
            this.lbToop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbToop.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lbToop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbToop.Location = new System.Drawing.Point(0, 139);
            this.lbToop.Name = "lbToop";
            this.lbToop.Size = new System.Drawing.Size(216, 44);
            this.lbToop.TabIndex = 3;
            this.lbToop.Text = "温馨提示";
            this.lbToop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBoxToop
            // 
            this.pBoxToop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBoxToop.Image = global::EcgViewPro.Properties.Resources.Spo2;
            this.pBoxToop.Location = new System.Drawing.Point(0, 0);
            this.pBoxToop.Name = "pBoxToop";
            this.pBoxToop.Size = new System.Drawing.Size(216, 139);
            this.pBoxToop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxToop.TabIndex = 2;
            this.pBoxToop.TabStop = false;
            // 
            // plLeft
            // 
            this.plLeft.BackColor = System.Drawing.Color.White;
            this.plLeft.Controls.Add(this.tableLayoutPanel3);
            this.plLeft.Controls.Add(this.panelBottom);
            this.plLeft.Controls.Add(this.lbTitle);
            this.plLeft.Controls.Add(this.panelTop);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeft.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.plLeft.Size = new System.Drawing.Size(882, 688);
            this.plLeft.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.lbSpoTitle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbHRTitle, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label159, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label170, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.label160, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label169, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label161, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label168, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label162, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label167, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label163, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label166, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label164, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label165, 2, 2);
            this.tableLayoutPanel3.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(22, 326);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(816, 291);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lbSpoTitle
            // 
            this.lbSpoTitle.AutoSize = true;
            this.lbSpoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.tableLayoutPanel3.SetColumnSpan(this.lbSpoTitle, 2);
            this.lbSpoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpoTitle.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbSpoTitle.ForeColor = System.Drawing.Color.White;
            this.lbSpoTitle.Location = new System.Drawing.Point(1, 1);
            this.lbSpoTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbSpoTitle.Name = "lbSpoTitle";
            this.lbSpoTitle.Size = new System.Drawing.Size(405, 71);
            this.lbSpoTitle.TabIndex = 0;
            this.lbSpoTitle.Text = "SPO2";
            this.lbSpoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHRTitle
            // 
            this.lbHRTitle.AutoSize = true;
            this.lbHRTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.tableLayoutPanel3.SetColumnSpan(this.lbHRTitle, 2);
            this.lbHRTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHRTitle.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbHRTitle.ForeColor = System.Drawing.Color.White;
            this.lbHRTitle.Location = new System.Drawing.Point(407, 1);
            this.lbHRTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbHRTitle.Name = "lbHRTitle";
            this.lbHRTitle.Size = new System.Drawing.Size(408, 71);
            this.lbHRTitle.TabIndex = 1;
            this.lbHRTitle.Text = "HR";
            this.lbHRTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.BackColor = System.Drawing.Color.White;
            this.label159.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label159.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label159.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label159.Location = new System.Drawing.Point(1, 73);
            this.label159.Margin = new System.Windows.Forms.Padding(0);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(202, 71);
            this.label159.TabIndex = 7;
            this.label159.Text = "正常";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.BackColor = System.Drawing.Color.White;
            this.label170.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label170.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label170.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label170.Location = new System.Drawing.Point(610, 217);
            this.label170.Margin = new System.Windows.Forms.Padding(0);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(205, 73);
            this.label170.TabIndex = 7;
            this.label170.Text = ">100";
            this.label170.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.BackColor = System.Drawing.Color.White;
            this.label160.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label160.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label160.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label160.Location = new System.Drawing.Point(204, 73);
            this.label160.Margin = new System.Windows.Forms.Padding(0);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(202, 71);
            this.label160.TabIndex = 7;
            this.label160.Text = ">=94%";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.BackColor = System.Drawing.Color.White;
            this.label169.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label169.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label169.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label169.Location = new System.Drawing.Point(407, 217);
            this.label169.Margin = new System.Windows.Forms.Padding(0);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(202, 73);
            this.label169.TabIndex = 7;
            this.label169.Text = "HR偏高";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.BackColor = System.Drawing.Color.White;
            this.label161.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label161.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label161.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label161.Location = new System.Drawing.Point(1, 145);
            this.label161.Margin = new System.Windows.Forms.Padding(0);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(202, 71);
            this.label161.TabIndex = 7;
            this.label161.Text = "供氧不足";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.BackColor = System.Drawing.Color.White;
            this.label168.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label168.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label168.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label168.Location = new System.Drawing.Point(204, 217);
            this.label168.Margin = new System.Windows.Forms.Padding(0);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(202, 73);
            this.label168.TabIndex = 7;
            this.label168.Text = "<=90%";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.BackColor = System.Drawing.Color.White;
            this.label162.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label162.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label162.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label162.Location = new System.Drawing.Point(204, 145);
            this.label162.Margin = new System.Windows.Forms.Padding(0);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(202, 71);
            this.label162.TabIndex = 7;
            this.label162.Text = "90~94%";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.BackColor = System.Drawing.Color.White;
            this.label167.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label167.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label167.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label167.Location = new System.Drawing.Point(1, 217);
            this.label167.Margin = new System.Windows.Forms.Padding(0);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(202, 73);
            this.label167.TabIndex = 7;
            this.label167.Text = "低血氧症";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.BackColor = System.Drawing.Color.White;
            this.label163.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label163.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label163.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label163.Location = new System.Drawing.Point(407, 73);
            this.label163.Margin = new System.Windows.Forms.Padding(0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(202, 71);
            this.label163.TabIndex = 7;
            this.label163.Text = "正常";
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.BackColor = System.Drawing.Color.White;
            this.label166.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label166.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label166.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label166.Location = new System.Drawing.Point(610, 145);
            this.label166.Margin = new System.Windows.Forms.Padding(0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(205, 71);
            this.label166.TabIndex = 7;
            this.label166.Text = "<60";
            this.label166.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.BackColor = System.Drawing.Color.White;
            this.label164.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label164.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label164.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label164.Location = new System.Drawing.Point(610, 73);
            this.label164.Margin = new System.Windows.Forms.Padding(0);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(205, 71);
            this.label164.TabIndex = 7;
            this.label164.Text = "60~100";
            this.label164.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.BackColor = System.Drawing.Color.White;
            this.label165.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label165.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label165.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label165.Location = new System.Drawing.Point(407, 145);
            this.label165.Margin = new System.Windows.Forms.Padding(0);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(202, 71);
            this.label165.TabIndex = 7;
            this.label165.Text = "HR偏低";
            this.label165.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.txtBoxBloodOxygenId);
            this.panelBottom.Controls.Add(this.lbBloodOxygenId);
            this.panelBottom.Controls.Add(this.btnSpo2);
            this.panelBottom.Location = new System.Drawing.Point(24, 623);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(816, 63);
            this.panelBottom.TabIndex = 5;
            // 
            // txtBoxBloodOxygenId
            // 
            this.txtBoxBloodOxygenId.Enabled = false;
            this.txtBoxBloodOxygenId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtBoxBloodOxygenId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxBloodOxygenId.Location = new System.Drawing.Point(108, 10);
            this.txtBoxBloodOxygenId.Multiline = true;
            this.txtBoxBloodOxygenId.Name = "txtBoxBloodOxygenId";
            this.txtBoxBloodOxygenId.Size = new System.Drawing.Size(285, 44);
            this.txtBoxBloodOxygenId.TabIndex = 8;
            this.txtBoxBloodOxygenId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbBloodOxygenId
            // 
            this.lbBloodOxygenId.AutoSize = true;
            this.lbBloodOxygenId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbBloodOxygenId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbBloodOxygenId.Location = new System.Drawing.Point(7, 16);
            this.lbBloodOxygenId.Name = "lbBloodOxygenId";
            this.lbBloodOxygenId.Size = new System.Drawing.Size(92, 31);
            this.lbBloodOxygenId.TabIndex = 7;
            this.lbBloodOxygenId.Text = "身份证:";
            // 
            // btnSpo2
            // 
            this.btnSpo2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSpo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSpo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpo2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSpo2.ForeColor = System.Drawing.Color.White;
            this.btnSpo2.Location = new System.Drawing.Point(593, 4);
            this.btnSpo2.Name = "btnSpo2";
            this.btnSpo2.Size = new System.Drawing.Size(155, 55);
            this.btnSpo2.TabIndex = 0;
            this.btnSpo2.Text = "保存";
            this.btnSpo2.UseVisualStyleBackColor = false;
            this.btnSpo2.Click += new System.EventHandler(this.btnSpo2_Click);
            this.btnSpo2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSpo2_MouseDown);
            this.btnSpo2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSpo2_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbTitle.Location = new System.Drawing.Point(130, 281);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(622, 43);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "正常值参考范围";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lb_SpoCatch);
            this.panelTop.Controls.Add(this.lbHR);
            this.panelTop.Controls.Add(this.lbStandard);
            this.panelTop.Controls.Add(this.lbBloodOxygenBpm);
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.lb_Spo2);
            this.panelTop.Controls.Add(this.lbbpm);
            this.panelTop.Controls.Add(this.lbSpo2);
            this.panelTop.Location = new System.Drawing.Point(22, 16);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(816, 261);
            this.panelTop.TabIndex = 3;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lb_SpoCatch
            // 
            this.lb_SpoCatch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_SpoCatch.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lb_SpoCatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_SpoCatch.Location = new System.Drawing.Point(249, 216);
            this.lb_SpoCatch.Name = "lb_SpoCatch";
            this.lb_SpoCatch.Size = new System.Drawing.Size(195, 41);
            this.lb_SpoCatch.TabIndex = 37;
            // 
            // lbHR
            // 
            this.lbHR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbHR.AutoSize = true;
            this.lbHR.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.lbHR.ForeColor = System.Drawing.Color.Black;
            this.lbHR.Location = new System.Drawing.Point(476, 78);
            this.lbHR.Name = "lbHR";
            this.lbHR.Size = new System.Drawing.Size(84, 52);
            this.lbHR.TabIndex = 0;
            this.lbHR.Text = "HR";
            // 
            // lbStandard
            // 
            this.lbStandard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStandard.AutoSize = true;
            this.lbStandard.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.lbStandard.ForeColor = System.Drawing.Color.Black;
            this.lbStandard.Location = new System.Drawing.Point(136, 78);
            this.lbStandard.Name = "lbStandard";
            this.lbStandard.Size = new System.Drawing.Size(131, 52);
            this.lbStandard.TabIndex = 0;
            this.lbStandard.Text = "SPO2";
            // 
            // lbBloodOxygenBpm
            // 
            this.lbBloodOxygenBpm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBloodOxygenBpm.AutoSize = true;
            this.lbBloodOxygenBpm.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.lbBloodOxygenBpm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(155)))), ((int)(((byte)(1)))));
            this.lbBloodOxygenBpm.Location = new System.Drawing.Point(481, 128);
            this.lbBloodOxygenBpm.Name = "lbBloodOxygenBpm";
            this.lbBloodOxygenBpm.Size = new System.Drawing.Size(73, 83);
            this.lbBloodOxygenBpm.TabIndex = 36;
            this.lbBloodOxygenBpm.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(111, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(697, 65);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lb_Spo2
            // 
            this.lb_Spo2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_Spo2.AutoSize = true;
            this.lb_Spo2.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.lb_Spo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(155)))), ((int)(((byte)(1)))));
            this.lb_Spo2.Location = new System.Drawing.Point(139, 128);
            this.lb_Spo2.Name = "lb_Spo2";
            this.lb_Spo2.Size = new System.Drawing.Size(73, 83);
            this.lb_Spo2.TabIndex = 36;
            this.lb_Spo2.Text = "0";
            // 
            // lbbpm
            // 
            this.lbbpm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbbpm.AutoSize = true;
            this.lbbpm.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbbpm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbbpm.Location = new System.Drawing.Point(595, 158);
            this.lbbpm.Name = "lbbpm";
            this.lbbpm.Size = new System.Drawing.Size(112, 52);
            this.lbbpm.TabIndex = 1;
            this.lbbpm.Text = "bpm";
            // 
            // lbSpo2
            // 
            this.lbSpo2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSpo2.AutoSize = true;
            this.lbSpo2.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbSpo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbSpo2.Location = new System.Drawing.Point(263, 158);
            this.lbSpo2.Name = "lbSpo2";
            this.lbSpo2.Size = new System.Drawing.Size(83, 52);
            this.lbSpo2.TabIndex = 1;
            this.lbSpo2.Text = " % ";
            // 
            // timer_Spo2
            // 
            this.timer_Spo2.Enabled = true;
            this.timer_Spo2.Interval = 1000;
            this.timer_Spo2.Tick += new System.EventHandler(this.timer_Spo2_Tick);
            // 
            // BloodOxygenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.plLeft);
            this.Controls.Add(this.plRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BloodOxygenForm";
            this.Text = "血氧检测值";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Spo2_Load);
            this.plRight.ResumeLayout(false);
            this.plRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxToop)).EndInit();
            this.plLeft.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.TextBox txtSpo2Notice;
        private System.Windows.Forms.Label lbToop;
        private System.Windows.Forms.PictureBox pBoxToop;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbSpoTitle;
        private System.Windows.Forms.Label lbHRTitle;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSpo2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lb_SpoCatch;
        private System.Windows.Forms.Label lbHR;
        private System.Windows.Forms.Label lbStandard;
        private System.Windows.Forms.Label lbBloodOxygenBpm;
        private System.Windows.Forms.Label lb_Spo2;
        private System.Windows.Forms.Label lbbpm;
        private System.Windows.Forms.Label lbSpo2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBoxBloodOxygenId;
        private System.Windows.Forms.Label lbBloodOxygenId;
        private System.Windows.Forms.Timer timer_Spo2;
    }
}