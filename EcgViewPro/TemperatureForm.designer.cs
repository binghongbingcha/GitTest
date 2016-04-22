namespace EcgViewPro
{
    partial class TemperatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureForm));
            this.plRight = new System.Windows.Forms.Panel();
            this.txtBoxNotice = new System.Windows.Forms.TextBox();
            this.lbToop = new System.Windows.Forms.Label();
            this.pBoxC = new System.Windows.Forms.PictureBox();
            this.plLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_range = new System.Windows.Forms.Label();
            this.lbrange = new System.Windows.Forms.Label();
            this.lbclassify = new System.Windows.Forms.Label();
            this.lb_classify = new System.Windows.Forms.Label();
            this.lbLow = new System.Windows.Forms.Label();
            this.lb_Superhot = new System.Windows.Forms.Label();
            this.lb_Low = new System.Windows.Forms.Label();
            this.lbSuperhot = new System.Windows.Forms.Label();
            this.lbnormal = new System.Windows.Forms.Label();
            this.lb_LowThermal = new System.Windows.Forms.Label();
            this.lb_normal = new System.Windows.Forms.Label();
            this.lbLowThermal = new System.Windows.Forms.Label();
            this.lbheat = new System.Windows.Forms.Label();
            this.lb_High = new System.Windows.Forms.Label();
            this.lb_heat = new System.Windows.Forms.Label();
            this.lbHigh = new System.Windows.Forms.Label();
            this.panelTemperatureBottom = new System.Windows.Forms.Panel();
            this.txtBoxTemId = new System.Windows.Forms.TextBox();
            this.lbTemId = new System.Windows.Forms.Label();
            this.btnTemp = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbSplit = new System.Windows.Forms.Label();
            this.lb_CF = new System.Windows.Forms.Label();
            this.lb_C = new System.Windows.Forms.Label();
            this.lbCF = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbC = new System.Windows.Forms.Label();
            this.timer_Tem = new System.Windows.Forms.Timer(this.components);
            this.plRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxC)).BeginInit();
            this.plLeft.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelTemperatureBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // plRight
            // 
            this.plRight.BackColor = System.Drawing.Color.White;
            this.plRight.Controls.Add(this.txtBoxNotice);
            this.plRight.Controls.Add(this.lbToop);
            this.plRight.Controls.Add(this.pBoxC);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRight.Location = new System.Drawing.Point(882, 0);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(216, 688);
            this.plRight.TabIndex = 1;
            // 
            // txtBoxNotice
            // 
            this.txtBoxNotice.BackColor = System.Drawing.Color.White;
            this.txtBoxNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxNotice.Enabled = false;
            this.txtBoxNotice.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtBoxNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxNotice.Location = new System.Drawing.Point(0, 180);
            this.txtBoxNotice.Multiline = true;
            this.txtBoxNotice.Name = "txtBoxNotice";
            this.txtBoxNotice.ReadOnly = true;
            this.txtBoxNotice.Size = new System.Drawing.Size(216, 508);
            this.txtBoxNotice.TabIndex = 4;
            this.txtBoxNotice.TabStop = false;
            this.txtBoxNotice.Text = "1、打开红外体温计的电池盖，将2节7号电池安装好并盖好电池盖，按下《ON/OFF》开机键\r\n2、待界面上设备连接状态显示为“设备已连接”，将体温计的红外探头垂直放" +
    "入被检查人的耳道部分\r\n3、按下体温计后背的按钮，必要时可适当调整角度，在经过1秒，听到长“滴”一声后，测量完成\r\n4、待测量结果上传后，点击“保存”按钮即可保" +
    "存测量结果";
            // 
            // lbToop
            // 
            this.lbToop.BackColor = System.Drawing.Color.White;
            this.lbToop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbToop.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lbToop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(144)))), ((int)(((byte)(223)))));
            this.lbToop.Location = new System.Drawing.Point(0, 139);
            this.lbToop.Name = "lbToop";
            this.lbToop.Size = new System.Drawing.Size(216, 41);
            this.lbToop.TabIndex = 3;
            this.lbToop.Text = "温馨提示";
            this.lbToop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBoxC
            // 
            this.pBoxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBoxC.Image = ((System.Drawing.Image)(resources.GetObject("pBoxC.Image")));
            this.pBoxC.Location = new System.Drawing.Point(0, 0);
            this.pBoxC.Name = "pBoxC";
            this.pBoxC.Size = new System.Drawing.Size(216, 139);
            this.pBoxC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxC.TabIndex = 2;
            this.pBoxC.TabStop = false;
            // 
            // plLeft
            // 
            this.plLeft.BackColor = System.Drawing.Color.White;
            this.plLeft.Controls.Add(this.tableLayoutPanel3);
            this.plLeft.Controls.Add(this.panelTemperatureBottom);
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
            this.tableLayoutPanel3.Controls.Add(this.lb_range, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbrange, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbclassify, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_classify, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbLow, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_Superhot, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.lb_Low, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbSuperhot, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbnormal, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lb_LowThermal, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lb_normal, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbLowThermal, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbheat, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_High, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.lb_heat, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbHigh, 2, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(22, 321);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(816, 292);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lb_range
            // 
            this.lb_range.AutoSize = true;
            this.lb_range.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lb_range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_range.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lb_range.ForeColor = System.Drawing.Color.White;
            this.lb_range.Location = new System.Drawing.Point(610, 1);
            this.lb_range.Margin = new System.Windows.Forms.Padding(0);
            this.lb_range.Name = "lb_range";
            this.lb_range.Size = new System.Drawing.Size(205, 71);
            this.lb_range.TabIndex = 8;
            this.lb_range.Text = "范围";
            this.lb_range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbrange
            // 
            this.lbrange.AutoSize = true;
            this.lbrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbrange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbrange.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbrange.ForeColor = System.Drawing.Color.White;
            this.lbrange.Location = new System.Drawing.Point(204, 1);
            this.lbrange.Margin = new System.Windows.Forms.Padding(0);
            this.lbrange.Name = "lbrange";
            this.lbrange.Size = new System.Drawing.Size(202, 71);
            this.lbrange.TabIndex = 7;
            this.lbrange.Text = "范围";
            this.lbrange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbclassify
            // 
            this.lbclassify.AutoSize = true;
            this.lbclassify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbclassify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbclassify.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbclassify.ForeColor = System.Drawing.Color.White;
            this.lbclassify.Location = new System.Drawing.Point(1, 1);
            this.lbclassify.Margin = new System.Windows.Forms.Padding(0);
            this.lbclassify.Name = "lbclassify";
            this.lbclassify.Size = new System.Drawing.Size(202, 71);
            this.lbclassify.TabIndex = 0;
            this.lbclassify.Text = "分类";
            this.lbclassify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_classify
            // 
            this.lb_classify.AutoSize = true;
            this.lb_classify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lb_classify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_classify.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lb_classify.ForeColor = System.Drawing.Color.White;
            this.lb_classify.Location = new System.Drawing.Point(407, 1);
            this.lb_classify.Margin = new System.Windows.Forms.Padding(0);
            this.lb_classify.Name = "lb_classify";
            this.lb_classify.Size = new System.Drawing.Size(202, 71);
            this.lb_classify.TabIndex = 1;
            this.lb_classify.Text = "分类";
            this.lb_classify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLow
            // 
            this.lbLow.AutoSize = true;
            this.lbLow.BackColor = System.Drawing.Color.White;
            this.lbLow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbLow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbLow.Location = new System.Drawing.Point(1, 73);
            this.lbLow.Margin = new System.Windows.Forms.Padding(0);
            this.lbLow.Name = "lbLow";
            this.lbLow.Size = new System.Drawing.Size(202, 71);
            this.lbLow.TabIndex = 7;
            this.lbLow.Text = "低温";
            this.lbLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Superhot
            // 
            this.lb_Superhot.AutoSize = true;
            this.lb_Superhot.BackColor = System.Drawing.Color.White;
            this.lb_Superhot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Superhot.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_Superhot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_Superhot.Location = new System.Drawing.Point(610, 217);
            this.lb_Superhot.Margin = new System.Windows.Forms.Padding(0);
            this.lb_Superhot.Name = "lb_Superhot";
            this.lb_Superhot.Size = new System.Drawing.Size(205, 74);
            this.lb_Superhot.TabIndex = 7;
            this.lb_Superhot.Text = "41℃<T";
            this.lb_Superhot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Low
            // 
            this.lb_Low.AutoSize = true;
            this.lb_Low.BackColor = System.Drawing.Color.White;
            this.lb_Low.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Low.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_Low.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_Low.Location = new System.Drawing.Point(204, 73);
            this.lb_Low.Margin = new System.Windows.Forms.Padding(0);
            this.lb_Low.Name = "lb_Low";
            this.lb_Low.Size = new System.Drawing.Size(202, 71);
            this.lb_Low.TabIndex = 7;
            this.lb_Low.Text = "T<36℃";
            this.lb_Low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSuperhot
            // 
            this.lbSuperhot.AutoSize = true;
            this.lbSuperhot.BackColor = System.Drawing.Color.White;
            this.lbSuperhot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSuperhot.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbSuperhot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbSuperhot.Location = new System.Drawing.Point(407, 217);
            this.lbSuperhot.Margin = new System.Windows.Forms.Padding(0);
            this.lbSuperhot.Name = "lbSuperhot";
            this.lbSuperhot.Size = new System.Drawing.Size(202, 74);
            this.lbSuperhot.TabIndex = 7;
            this.lbSuperhot.Text = "超高热";
            this.lbSuperhot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbnormal
            // 
            this.lbnormal.AutoSize = true;
            this.lbnormal.BackColor = System.Drawing.Color.White;
            this.lbnormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbnormal.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbnormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbnormal.Location = new System.Drawing.Point(1, 145);
            this.lbnormal.Margin = new System.Windows.Forms.Padding(0);
            this.lbnormal.Name = "lbnormal";
            this.lbnormal.Size = new System.Drawing.Size(202, 71);
            this.lbnormal.TabIndex = 7;
            this.lbnormal.Text = "正常";
            this.lbnormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_LowThermal
            // 
            this.lb_LowThermal.AutoSize = true;
            this.lb_LowThermal.BackColor = System.Drawing.Color.White;
            this.lb_LowThermal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_LowThermal.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_LowThermal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_LowThermal.Location = new System.Drawing.Point(204, 217);
            this.lb_LowThermal.Margin = new System.Windows.Forms.Padding(0);
            this.lb_LowThermal.Name = "lb_LowThermal";
            this.lb_LowThermal.Size = new System.Drawing.Size(202, 74);
            this.lb_LowThermal.TabIndex = 7;
            this.lb_LowThermal.Text = "37℃<T<=38℃";
            this.lb_LowThermal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_normal
            // 
            this.lb_normal.AutoSize = true;
            this.lb_normal.BackColor = System.Drawing.Color.White;
            this.lb_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_normal.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_normal.Location = new System.Drawing.Point(204, 145);
            this.lb_normal.Margin = new System.Windows.Forms.Padding(0);
            this.lb_normal.Name = "lb_normal";
            this.lb_normal.Size = new System.Drawing.Size(202, 71);
            this.lb_normal.TabIndex = 7;
            this.lb_normal.Text = "36℃<T<=37℃";
            this.lb_normal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLowThermal
            // 
            this.lbLowThermal.AutoSize = true;
            this.lbLowThermal.BackColor = System.Drawing.Color.White;
            this.lbLowThermal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLowThermal.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbLowThermal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbLowThermal.Location = new System.Drawing.Point(1, 217);
            this.lbLowThermal.Margin = new System.Windows.Forms.Padding(0);
            this.lbLowThermal.Name = "lbLowThermal";
            this.lbLowThermal.Size = new System.Drawing.Size(202, 74);
            this.lbLowThermal.TabIndex = 7;
            this.lbLowThermal.Text = "低热";
            this.lbLowThermal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbheat
            // 
            this.lbheat.AutoSize = true;
            this.lbheat.BackColor = System.Drawing.Color.White;
            this.lbheat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbheat.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbheat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbheat.Location = new System.Drawing.Point(407, 73);
            this.lbheat.Margin = new System.Windows.Forms.Padding(0);
            this.lbheat.Name = "lbheat";
            this.lbheat.Size = new System.Drawing.Size(202, 71);
            this.lbheat.TabIndex = 7;
            this.lbheat.Text = "中度发热";
            this.lbheat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_High
            // 
            this.lb_High.AutoSize = true;
            this.lb_High.BackColor = System.Drawing.Color.White;
            this.lb_High.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_High.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_High.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_High.Location = new System.Drawing.Point(610, 145);
            this.lb_High.Margin = new System.Windows.Forms.Padding(0);
            this.lb_High.Name = "lb_High";
            this.lb_High.Size = new System.Drawing.Size(205, 71);
            this.lb_High.TabIndex = 7;
            this.lb_High.Text = "39℃<T<=41℃";
            this.lb_High.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_heat
            // 
            this.lb_heat.AutoSize = true;
            this.lb_heat.BackColor = System.Drawing.Color.White;
            this.lb_heat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_heat.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lb_heat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_heat.Location = new System.Drawing.Point(610, 73);
            this.lb_heat.Margin = new System.Windows.Forms.Padding(0);
            this.lb_heat.Name = "lb_heat";
            this.lb_heat.Size = new System.Drawing.Size(205, 71);
            this.lb_heat.TabIndex = 7;
            this.lb_heat.Text = "38℃<T<=39℃";
            this.lb_heat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHigh
            // 
            this.lbHigh.AutoSize = true;
            this.lbHigh.BackColor = System.Drawing.Color.White;
            this.lbHigh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHigh.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbHigh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbHigh.Location = new System.Drawing.Point(407, 145);
            this.lbHigh.Margin = new System.Windows.Forms.Padding(0);
            this.lbHigh.Name = "lbHigh";
            this.lbHigh.Size = new System.Drawing.Size(202, 71);
            this.lbHigh.TabIndex = 7;
            this.lbHigh.Text = "高热";
            this.lbHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTemperatureBottom
            // 
            this.panelTemperatureBottom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTemperatureBottom.BackColor = System.Drawing.Color.White;
            this.panelTemperatureBottom.Controls.Add(this.txtBoxTemId);
            this.panelTemperatureBottom.Controls.Add(this.lbTemId);
            this.panelTemperatureBottom.Controls.Add(this.btnTemp);
            this.panelTemperatureBottom.Location = new System.Drawing.Point(22, 619);
            this.panelTemperatureBottom.Name = "panelTemperatureBottom";
            this.panelTemperatureBottom.Size = new System.Drawing.Size(816, 63);
            this.panelTemperatureBottom.TabIndex = 5;
            // 
            // txtBoxTemId
            // 
            this.txtBoxTemId.Enabled = false;
            this.txtBoxTemId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtBoxTemId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxTemId.Location = new System.Drawing.Point(122, 8);
            this.txtBoxTemId.Multiline = true;
            this.txtBoxTemId.Name = "txtBoxTemId";
            this.txtBoxTemId.Size = new System.Drawing.Size(285, 45);
            this.txtBoxTemId.TabIndex = 2;
            this.txtBoxTemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbTemId
            // 
            this.lbTemId.AutoSize = true;
            this.lbTemId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbTemId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbTemId.Location = new System.Drawing.Point(5, 15);
            this.lbTemId.Name = "lbTemId";
            this.lbTemId.Size = new System.Drawing.Size(110, 31);
            this.lbTemId.TabIndex = 1;
            this.lbTemId.Text = "身份证：";
            // 
            // btnTemp
            // 
            this.btnTemp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemp.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTemp.ForeColor = System.Drawing.Color.White;
            this.btnTemp.Location = new System.Drawing.Point(518, 4);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(155, 55);
            this.btnTemp.TabIndex = 0;
            this.btnTemp.Text = "保存";
            this.btnTemp.UseVisualStyleBackColor = false;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            this.btnTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTemp_MouseDown);
            this.btnTemp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTemp_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbTitle.Location = new System.Drawing.Point(321, 267);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(243, 51);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "正常值参考范围";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lbSplit);
            this.panelTop.Controls.Add(this.lb_CF);
            this.panelTop.Controls.Add(this.lb_C);
            this.panelTop.Controls.Add(this.lbCF);
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.lbC);
            this.panelTop.Location = new System.Drawing.Point(22, 22);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(816, 242);
            this.panelTop.TabIndex = 3;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lbSplit
            // 
            this.lbSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSplit.AutoSize = true;
            this.lbSplit.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbSplit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbSplit.Location = new System.Drawing.Point(435, 102);
            this.lbSplit.Name = "lbSplit";
            this.lbSplit.Size = new System.Drawing.Size(34, 52);
            this.lbSplit.TabIndex = 0;
            this.lbSplit.Text = "|";
            // 
            // lb_CF
            // 
            this.lb_CF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_CF.AutoSize = true;
            this.lb_CF.BackColor = System.Drawing.Color.White;
            this.lb_CF.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.lb_CF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(155)))), ((int)(((byte)(1)))));
            this.lb_CF.Location = new System.Drawing.Point(511, 92);
            this.lb_CF.Name = "lb_CF";
            this.lb_CF.Size = new System.Drawing.Size(173, 83);
            this.lb_CF.TabIndex = 36;
            this.lb_CF.Text = "——";
            // 
            // lb_C
            // 
            this.lb_C.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_C.AutoSize = true;
            this.lb_C.BackColor = System.Drawing.Color.White;
            this.lb_C.Font = new System.Drawing.Font("微软雅黑", 48F);
            this.lb_C.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(155)))), ((int)(((byte)(1)))));
            this.lb_C.Location = new System.Drawing.Point(116, 92);
            this.lb_C.Name = "lb_C";
            this.lb_C.Size = new System.Drawing.Size(173, 83);
            this.lb_C.TabIndex = 36;
            this.lb_C.Text = "——";
            // 
            // lbCF
            // 
            this.lbCF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCF.AutoSize = true;
            this.lbCF.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbCF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbCF.Location = new System.Drawing.Point(733, 111);
            this.lbCF.Name = "lbCF";
            this.lbCF.Size = new System.Drawing.Size(63, 52);
            this.lbCF.TabIndex = 1;
            this.lbCF.Text = "℉";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(113, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(697, 65);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lbC
            // 
            this.lbC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbC.AutoSize = true;
            this.lbC.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.lbC.Location = new System.Drawing.Point(317, 111);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(63, 52);
            this.lbC.TabIndex = 1;
            this.lbC.Text = "℃";
            // 
            // timer_Tem
            // 
            this.timer_Tem.Enabled = true;
            this.timer_Tem.Interval = 1000;
            this.timer_Tem.Tick += new System.EventHandler(this.timer_Tem_Tick);
            // 
            // TemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.plLeft);
            this.Controls.Add(this.plRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemperatureForm";
            this.Text = "体温检测值";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Temperature_Load);
            this.plRight.ResumeLayout(false);
            this.plRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxC)).EndInit();
            this.plLeft.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelTemperatureBottom.ResumeLayout(false);
            this.panelTemperatureBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.TextBox txtBoxNotice;
        private System.Windows.Forms.Label lbToop;
        private System.Windows.Forms.PictureBox pBoxC;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbclassify;
        private System.Windows.Forms.Label lb_classify;
        private System.Windows.Forms.Label lbLow;
        private System.Windows.Forms.Label lb_Superhot;
        private System.Windows.Forms.Label lb_Low;
        private System.Windows.Forms.Label lbSuperhot;
        private System.Windows.Forms.Label lbnormal;
        private System.Windows.Forms.Label lb_LowThermal;
        private System.Windows.Forms.Label lb_normal;
        private System.Windows.Forms.Label lbLowThermal;
        private System.Windows.Forms.Label lbheat;
        private System.Windows.Forms.Label lb_High;
        private System.Windows.Forms.Label lb_heat;
        private System.Windows.Forms.Label lbHigh;
        private System.Windows.Forms.Panel panelTemperatureBottom;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lbSplit;
        private System.Windows.Forms.Label lb_CF;
        private System.Windows.Forms.Label lb_C;
        private System.Windows.Forms.Label lbCF;
        private System.Windows.Forms.Label lbC;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_range;
        private System.Windows.Forms.Label lbrange;
        private System.Windows.Forms.TextBox txtBoxTemId;
        private System.Windows.Forms.Label lbTemId;
        private System.Windows.Forms.Timer timer_Tem;
    }
}