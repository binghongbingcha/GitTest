
using System.Windows.Forms;
namespace EcgViewPro
{
    partial class EcgViewFrm
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
                _bp.Dispose();
                _ecgBitMap.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EcgViewFrm));
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除选中记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBox_C = new System.Windows.Forms.GroupBox();
            this.lb_TEMP = new System.Windows.Forms.Label();
            this.gBox_SYS = new System.Windows.Forms.GroupBox();
            this.lbSYS = new System.Windows.Forms.Label();
            this.lb_SYS = new System.Windows.Forms.Label();
            this.lbDIA = new System.Windows.Forms.Label();
            this.lb_DIA = new System.Windows.Forms.Label();
            this.gBox_Mmol = new System.Windows.Forms.GroupBox();
            this.lb_Mmol = new System.Windows.Forms.Label();
            this.gBox_Spo2 = new System.Windows.Forms.GroupBox();
            this.lbSpo2 = new System.Windows.Forms.Label();
            this.lb_Spo2 = new System.Windows.Forms.Label();
            this.gBox_Urine = new System.Windows.Forms.GroupBox();
            this.lbLEU = new System.Windows.Forms.Label();
            this.lbBLD = new System.Windows.Forms.Label();
            this.lbPRO = new System.Windows.Forms.Label();
            this.lbNIT = new System.Windows.Forms.Label();
            this.lbUBG = new System.Windows.Forms.Label();
            this.lbPH = new System.Windows.Forms.Label();
            this.lbKET = new System.Windows.Forms.Label();
            this.lbBIL = new System.Windows.Forms.Label();
            this.lb_GLU = new System.Windows.Forms.Label();
            this.lbGLU = new System.Windows.Forms.Label();
            this.lb_BLD = new System.Windows.Forms.Label();
            this.lbVC = new System.Windows.Forms.Label();
            this.lb_UBG = new System.Windows.Forms.Label();
            this.lbSG = new System.Windows.Forms.Label();
            this.lb_SG = new System.Windows.Forms.Label();
            this.lb_BIL = new System.Windows.Forms.Label();
            this.lb_LEU = new System.Windows.Forms.Label();
            this.lb_PH = new System.Windows.Forms.Label();
            this.lb_PRO = new System.Windows.Forms.Label();
            this.lb_NIT = new System.Windows.Forms.Label();
            this.lb_KET = new System.Windows.Forms.Label();
            this.lb_VC = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lab_leadShow = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gBox_PatientInfo = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.lbDoctorDept = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbDoctorName = new System.Windows.Forms.Label();
            this.lb_Time = new System.Windows.Forms.Label();
            this.hScrollBar_Lead = new System.Windows.Forms.HScrollBar();
            this.tabControl1 = new System.Windows.Forms.Panel();
            this.pictureEdit3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gBox_C.SuspendLayout();
            this.gBox_SYS.SuspendLayout();
            this.gBox_Mmol.SuspendLayout();
            this.gBox_Spo2.SuspendLayout();
            this.gBox_Urine.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.gBox_PatientInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.gBox_C);
            this.groupBox1.Controls.Add(this.gBox_SYS);
            this.groupBox1.Controls.Add(this.gBox_Mmol);
            this.groupBox1.Controls.Add(this.gBox_Spo2);
            this.groupBox1.Controls.Add(this.gBox_Urine);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox15);
            this.groupBox1.Controls.Add(this.gBox_PatientInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1099, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 768);
            this.groupBox1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 510);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(267, 195);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "诊断结论";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsReturn = true;
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 14F);
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Multiline = true;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(261, 175);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 460);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 50);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参考记录";
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(3, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(261, 30);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除选中记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // 删除选中记录ToolStripMenuItem
            // 
            this.删除选中记录ToolStripMenuItem.Name = "删除选中记录ToolStripMenuItem";
            this.删除选中记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除选中记录ToolStripMenuItem.Text = "删除选中记录";
            this.删除选中记录ToolStripMenuItem.Click += new System.EventHandler(this.删除选中记录ToolStripMenuItem_Click);
            // 
            // gBox_C
            // 
            this.gBox_C.Controls.Add(this.lb_TEMP);
            this.gBox_C.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_C.Location = new System.Drawing.Point(0, 423);
            this.gBox_C.Name = "gBox_C";
            this.gBox_C.Size = new System.Drawing.Size(267, 37);
            this.gBox_C.TabIndex = 18;
            this.gBox_C.TabStop = false;
            this.gBox_C.Text = "体温";
            // 
            // lb_TEMP
            // 
            this.lb_TEMP.AutoSize = true;
            this.lb_TEMP.Location = new System.Drawing.Point(73, 17);
            this.lb_TEMP.Name = "lb_TEMP";
            this.lb_TEMP.Size = new System.Drawing.Size(17, 12);
            this.lb_TEMP.TabIndex = 45;
            this.lb_TEMP.Text = "无";
            // 
            // gBox_SYS
            // 
            this.gBox_SYS.Controls.Add(this.lbSYS);
            this.gBox_SYS.Controls.Add(this.lb_SYS);
            this.gBox_SYS.Controls.Add(this.lbDIA);
            this.gBox_SYS.Controls.Add(this.lb_DIA);
            this.gBox_SYS.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_SYS.Location = new System.Drawing.Point(0, 369);
            this.gBox_SYS.Name = "gBox_SYS";
            this.gBox_SYS.Size = new System.Drawing.Size(267, 54);
            this.gBox_SYS.TabIndex = 17;
            this.gBox_SYS.TabStop = false;
            this.gBox_SYS.Text = "血压";
            // 
            // lbSYS
            // 
            this.lbSYS.AutoSize = true;
            this.lbSYS.Location = new System.Drawing.Point(141, 26);
            this.lbSYS.Name = "lbSYS";
            this.lbSYS.Size = new System.Drawing.Size(53, 12);
            this.lbSYS.TabIndex = 46;
            this.lbSYS.Text = "舒张压：";
            // 
            // lb_SYS
            // 
            this.lb_SYS.AutoSize = true;
            this.lb_SYS.Location = new System.Drawing.Point(200, 26);
            this.lb_SYS.Name = "lb_SYS";
            this.lb_SYS.Size = new System.Drawing.Size(17, 12);
            this.lb_SYS.TabIndex = 49;
            this.lb_SYS.Text = "无";
            // 
            // lbDIA
            // 
            this.lbDIA.AutoSize = true;
            this.lbDIA.Location = new System.Drawing.Point(23, 26);
            this.lbDIA.Name = "lbDIA";
            this.lbDIA.Size = new System.Drawing.Size(53, 12);
            this.lbDIA.TabIndex = 46;
            this.lbDIA.Text = "收缩压：";
            // 
            // lb_DIA
            // 
            this.lb_DIA.AutoSize = true;
            this.lb_DIA.Location = new System.Drawing.Point(81, 26);
            this.lb_DIA.Name = "lb_DIA";
            this.lb_DIA.Size = new System.Drawing.Size(17, 12);
            this.lb_DIA.TabIndex = 49;
            this.lb_DIA.Text = "无";
            // 
            // gBox_Mmol
            // 
            this.gBox_Mmol.Controls.Add(this.lb_Mmol);
            this.gBox_Mmol.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_Mmol.Location = new System.Drawing.Point(0, 332);
            this.gBox_Mmol.Name = "gBox_Mmol";
            this.gBox_Mmol.Size = new System.Drawing.Size(267, 37);
            this.gBox_Mmol.TabIndex = 16;
            this.gBox_Mmol.TabStop = false;
            this.gBox_Mmol.Text = "血糖";
            // 
            // lb_Mmol
            // 
            this.lb_Mmol.AutoSize = true;
            this.lb_Mmol.Location = new System.Drawing.Point(69, 17);
            this.lb_Mmol.Name = "lb_Mmol";
            this.lb_Mmol.Size = new System.Drawing.Size(17, 12);
            this.lb_Mmol.TabIndex = 49;
            this.lb_Mmol.Text = "无";
            // 
            // gBox_Spo2
            // 
            this.gBox_Spo2.Controls.Add(this.lbSpo2);
            this.gBox_Spo2.Controls.Add(this.lb_Spo2);
            this.gBox_Spo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_Spo2.Location = new System.Drawing.Point(0, 295);
            this.gBox_Spo2.Name = "gBox_Spo2";
            this.gBox_Spo2.Size = new System.Drawing.Size(267, 37);
            this.gBox_Spo2.TabIndex = 15;
            this.gBox_Spo2.TabStop = false;
            this.gBox_Spo2.Text = "血氧";
            // 
            // lbSpo2
            // 
            this.lbSpo2.AutoSize = true;
            this.lbSpo2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSpo2.Location = new System.Drawing.Point(116, 17);
            this.lbSpo2.Name = "lbSpo2";
            this.lbSpo2.Size = new System.Drawing.Size(0, 12);
            this.lbSpo2.TabIndex = 46;
            // 
            // lb_Spo2
            // 
            this.lb_Spo2.AutoSize = true;
            this.lb_Spo2.Location = new System.Drawing.Point(69, 15);
            this.lb_Spo2.Name = "lb_Spo2";
            this.lb_Spo2.Size = new System.Drawing.Size(17, 12);
            this.lb_Spo2.TabIndex = 49;
            this.lb_Spo2.Text = "无";
            // 
            // gBox_Urine
            // 
            this.gBox_Urine.Controls.Add(this.lbLEU);
            this.gBox_Urine.Controls.Add(this.lbBLD);
            this.gBox_Urine.Controls.Add(this.lbPRO);
            this.gBox_Urine.Controls.Add(this.lbNIT);
            this.gBox_Urine.Controls.Add(this.lbUBG);
            this.gBox_Urine.Controls.Add(this.lbPH);
            this.gBox_Urine.Controls.Add(this.lbKET);
            this.gBox_Urine.Controls.Add(this.lbBIL);
            this.gBox_Urine.Controls.Add(this.lb_GLU);
            this.gBox_Urine.Controls.Add(this.lbGLU);
            this.gBox_Urine.Controls.Add(this.lb_BLD);
            this.gBox_Urine.Controls.Add(this.lbVC);
            this.gBox_Urine.Controls.Add(this.lb_UBG);
            this.gBox_Urine.Controls.Add(this.lbSG);
            this.gBox_Urine.Controls.Add(this.lb_SG);
            this.gBox_Urine.Controls.Add(this.lb_BIL);
            this.gBox_Urine.Controls.Add(this.lb_LEU);
            this.gBox_Urine.Controls.Add(this.lb_PH);
            this.gBox_Urine.Controls.Add(this.lb_PRO);
            this.gBox_Urine.Controls.Add(this.lb_NIT);
            this.gBox_Urine.Controls.Add(this.lb_KET);
            this.gBox_Urine.Controls.Add(this.lb_VC);
            this.gBox_Urine.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_Urine.Location = new System.Drawing.Point(0, 189);
            this.gBox_Urine.Name = "gBox_Urine";
            this.gBox_Urine.Padding = new System.Windows.Forms.Padding(0);
            this.gBox_Urine.Size = new System.Drawing.Size(267, 106);
            this.gBox_Urine.TabIndex = 13;
            this.gBox_Urine.TabStop = false;
            this.gBox_Urine.Text = "尿常规";
            // 
            // lbLEU
            // 
            this.lbLEU.AutoSize = true;
            this.lbLEU.Location = new System.Drawing.Point(11, 16);
            this.lbLEU.Name = "lbLEU";
            this.lbLEU.Size = new System.Drawing.Size(35, 12);
            this.lbLEU.TabIndex = 22;
            this.lbLEU.Text = "LEU：";
            // 
            // lbBLD
            // 
            this.lbBLD.AutoSize = true;
            this.lbBLD.Location = new System.Drawing.Point(198, 39);
            this.lbBLD.Name = "lbBLD";
            this.lbBLD.Size = new System.Drawing.Size(35, 12);
            this.lbBLD.TabIndex = 27;
            this.lbBLD.Text = "BLD：";
            // 
            // lbPRO
            // 
            this.lbPRO.AutoSize = true;
            this.lbPRO.Location = new System.Drawing.Point(11, 39);
            this.lbPRO.Name = "lbPRO";
            this.lbPRO.Size = new System.Drawing.Size(35, 12);
            this.lbPRO.TabIndex = 23;
            this.lbPRO.Text = "PRO：";
            // 
            // lbNIT
            // 
            this.lbNIT.AutoSize = true;
            this.lbNIT.Location = new System.Drawing.Point(103, 16);
            this.lbNIT.Name = "lbNIT";
            this.lbNIT.Size = new System.Drawing.Size(35, 12);
            this.lbNIT.TabIndex = 24;
            this.lbNIT.Text = "NIT：";
            // 
            // lbUBG
            // 
            this.lbUBG.AutoSize = true;
            this.lbUBG.Location = new System.Drawing.Point(198, 15);
            this.lbUBG.Name = "lbUBG";
            this.lbUBG.Size = new System.Drawing.Size(35, 12);
            this.lbUBG.TabIndex = 25;
            this.lbUBG.Text = "UBG：";
            // 
            // lbPH
            // 
            this.lbPH.AutoSize = true;
            this.lbPH.Location = new System.Drawing.Point(103, 40);
            this.lbPH.Name = "lbPH";
            this.lbPH.Size = new System.Drawing.Size(29, 12);
            this.lbPH.TabIndex = 26;
            this.lbPH.Text = "PH：";
            // 
            // lbKET
            // 
            this.lbKET.AutoSize = true;
            this.lbKET.Location = new System.Drawing.Point(11, 63);
            this.lbKET.Name = "lbKET";
            this.lbKET.Size = new System.Drawing.Size(35, 12);
            this.lbKET.TabIndex = 28;
            this.lbKET.Text = "KET：";
            // 
            // lbBIL
            // 
            this.lbBIL.AutoSize = true;
            this.lbBIL.Location = new System.Drawing.Point(105, 64);
            this.lbBIL.Name = "lbBIL";
            this.lbBIL.Size = new System.Drawing.Size(35, 12);
            this.lbBIL.TabIndex = 29;
            this.lbBIL.Text = "BIL：";
            // 
            // lb_GLU
            // 
            this.lb_GLU.AutoSize = true;
            this.lb_GLU.Location = new System.Drawing.Point(235, 63);
            this.lb_GLU.Name = "lb_GLU";
            this.lb_GLU.Size = new System.Drawing.Size(17, 12);
            this.lb_GLU.TabIndex = 44;
            this.lb_GLU.Text = "无";
            // 
            // lbGLU
            // 
            this.lbGLU.AutoSize = true;
            this.lbGLU.Location = new System.Drawing.Point(200, 63);
            this.lbGLU.Name = "lbGLU";
            this.lbGLU.Size = new System.Drawing.Size(35, 12);
            this.lbGLU.TabIndex = 30;
            this.lbGLU.Text = "GLU：";
            // 
            // lb_BLD
            // 
            this.lb_BLD.AutoSize = true;
            this.lb_BLD.Location = new System.Drawing.Point(233, 39);
            this.lb_BLD.Name = "lb_BLD";
            this.lb_BLD.Size = new System.Drawing.Size(17, 12);
            this.lb_BLD.TabIndex = 43;
            this.lb_BLD.Text = "无";
            // 
            // lbVC
            // 
            this.lbVC.AutoSize = true;
            this.lbVC.Location = new System.Drawing.Point(11, 86);
            this.lbVC.Name = "lbVC";
            this.lbVC.Size = new System.Drawing.Size(29, 12);
            this.lbVC.TabIndex = 31;
            this.lbVC.Text = "VC：";
            // 
            // lb_UBG
            // 
            this.lb_UBG.AutoSize = true;
            this.lb_UBG.Location = new System.Drawing.Point(233, 15);
            this.lb_UBG.Name = "lb_UBG";
            this.lb_UBG.Size = new System.Drawing.Size(17, 12);
            this.lb_UBG.TabIndex = 42;
            this.lb_UBG.Text = "无";
            // 
            // lbSG
            // 
            this.lbSG.AutoSize = true;
            this.lbSG.Location = new System.Drawing.Point(104, 87);
            this.lbSG.Name = "lbSG";
            this.lbSG.Size = new System.Drawing.Size(29, 12);
            this.lbSG.TabIndex = 32;
            this.lbSG.Text = "SG：";
            // 
            // lb_SG
            // 
            this.lb_SG.AutoSize = true;
            this.lb_SG.Location = new System.Drawing.Point(145, 87);
            this.lb_SG.Name = "lb_SG";
            this.lb_SG.Size = new System.Drawing.Size(17, 12);
            this.lb_SG.TabIndex = 41;
            this.lb_SG.Text = "无";
            // 
            // lb_BIL
            // 
            this.lb_BIL.AutoSize = true;
            this.lb_BIL.Location = new System.Drawing.Point(146, 64);
            this.lb_BIL.Name = "lb_BIL";
            this.lb_BIL.Size = new System.Drawing.Size(17, 12);
            this.lb_BIL.TabIndex = 40;
            this.lb_BIL.Text = "无";
            // 
            // lb_LEU
            // 
            this.lb_LEU.AutoSize = true;
            this.lb_LEU.Location = new System.Drawing.Point(54, 16);
            this.lb_LEU.Name = "lb_LEU";
            this.lb_LEU.Size = new System.Drawing.Size(17, 12);
            this.lb_LEU.TabIndex = 34;
            this.lb_LEU.Text = "无";
            // 
            // lb_PH
            // 
            this.lb_PH.AutoSize = true;
            this.lb_PH.Location = new System.Drawing.Point(144, 40);
            this.lb_PH.Name = "lb_PH";
            this.lb_PH.Size = new System.Drawing.Size(17, 12);
            this.lb_PH.TabIndex = 39;
            this.lb_PH.Text = "无";
            // 
            // lb_PRO
            // 
            this.lb_PRO.AutoSize = true;
            this.lb_PRO.Location = new System.Drawing.Point(55, 39);
            this.lb_PRO.Name = "lb_PRO";
            this.lb_PRO.Size = new System.Drawing.Size(17, 12);
            this.lb_PRO.TabIndex = 35;
            this.lb_PRO.Text = "无";
            // 
            // lb_NIT
            // 
            this.lb_NIT.AutoSize = true;
            this.lb_NIT.Location = new System.Drawing.Point(144, 16);
            this.lb_NIT.Name = "lb_NIT";
            this.lb_NIT.Size = new System.Drawing.Size(17, 12);
            this.lb_NIT.TabIndex = 38;
            this.lb_NIT.Text = "无";
            // 
            // lb_KET
            // 
            this.lb_KET.AutoSize = true;
            this.lb_KET.Location = new System.Drawing.Point(57, 63);
            this.lb_KET.Name = "lb_KET";
            this.lb_KET.Size = new System.Drawing.Size(17, 12);
            this.lb_KET.TabIndex = 36;
            this.lb_KET.Text = "无";
            // 
            // lb_VC
            // 
            this.lb_VC.AutoSize = true;
            this.lb_VC.Location = new System.Drawing.Point(56, 86);
            this.lb_VC.Name = "lb_VC";
            this.lb_VC.Size = new System.Drawing.Size(17, 12);
            this.lb_VC.TabIndex = 37;
            this.lb_VC.Text = "无";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lab_leadShow);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 83);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox6.Size = new System.Drawing.Size(267, 106);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "心电";
            // 
            // lab_leadShow
            // 
            this.lab_leadShow.AutoSize = true;
            this.lab_leadShow.Location = new System.Drawing.Point(100, 170);
            this.lab_leadShow.Name = "lab_leadShow";
            this.lab_leadShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lab_leadShow.Size = new System.Drawing.Size(47, 12);
            this.lab_leadShow.TabIndex = 2;
            this.lab_leadShow.Text = "label26";
            this.lab_leadShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_leadShow.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(161, 15);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "增益：10mm/mV";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 12);
            this.label28.TabIndex = 0;
            this.label28.Text = "走速：25mm/s";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.Location = new System.Drawing.Point(69, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "-mV";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F);
            this.label17.Location = new System.Drawing.Point(202, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 12);
            this.label17.TabIndex = 17;
            this.label17.Text = "-ms";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9F);
            this.label18.Location = new System.Drawing.Point(161, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 16;
            this.label18.Text = "QRS：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(52, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "bpm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(221, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "-°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F);
            this.label16.Location = new System.Drawing.Point(11, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 18;
            this.label16.Text = "RV5/SV1：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(161, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "QRS电轴：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(68, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "-ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(11, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "QT/QTc：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(11, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "HR：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.Location = new System.Drawing.Point(161, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "P-R：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(200, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "-ms";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnClose);
            this.groupBox15.Controls.Add(this.btn_Print);
            this.groupBox15.Controls.Add(this.lblMsg);
            this.groupBox15.Controls.Add(this.btnSave);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox15.Location = new System.Drawing.Point(0, 705);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(267, 63);
            this.groupBox15.TabIndex = 6;
            this.groupBox15.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F);
            this.btnClose.Location = new System.Drawing.Point(180, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_Print.Location = new System.Drawing.Point(93, 13);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(81, 28);
            this.btn_Print.TabIndex = 2;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsg.Location = new System.Drawing.Point(3, 48);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(65, 12);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "提示:暂无!";
            this.lblMsg.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSave.Location = new System.Drawing.Point(6, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gBox_PatientInfo
            // 
            this.gBox_PatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gBox_PatientInfo.Controls.Add(this.label14);
            this.gBox_PatientInfo.Controls.Add(this.label1);
            this.gBox_PatientInfo.Controls.Add(this.label19);
            this.gBox_PatientInfo.Controls.Add(this.label99);
            this.gBox_PatientInfo.Controls.Add(this.lbDoctorDept);
            this.gBox_PatientInfo.Controls.Add(this.label20);
            this.gBox_PatientInfo.Controls.Add(this.label100);
            this.gBox_PatientInfo.Controls.Add(this.label2);
            this.gBox_PatientInfo.Controls.Add(this.label13);
            this.gBox_PatientInfo.Controls.Add(this.lbDoctorName);
            this.gBox_PatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_PatientInfo.Location = new System.Drawing.Point(0, 0);
            this.gBox_PatientInfo.Name = "gBox_PatientInfo";
            this.gBox_PatientInfo.Size = new System.Drawing.Size(267, 83);
            this.gBox_PatientInfo.TabIndex = 14;
            this.gBox_PatientInfo.TabStop = false;
            this.gBox_PatientInfo.Text = "基本信息";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.Location = new System.Drawing.Point(11, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "性别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F);
            this.label19.Location = new System.Drawing.Point(135, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "-岁";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("宋体", 9F);
            this.label99.Location = new System.Drawing.Point(11, 61);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(41, 12);
            this.label99.TabIndex = 21;
            this.label99.Text = "科室：";
            // 
            // lbDoctorDept
            // 
            this.lbDoctorDept.AutoSize = true;
            this.lbDoctorDept.Font = new System.Drawing.Font("宋体", 9F);
            this.lbDoctorDept.Location = new System.Drawing.Point(56, 61);
            this.lbDoctorDept.Name = "lbDoctorDept";
            this.lbDoctorDept.Size = new System.Drawing.Size(0, 12);
            this.lbDoctorDept.TabIndex = 20;
            this.lbDoctorDept.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 9F);
            this.label20.Location = new System.Drawing.Point(86, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 14;
            this.label20.Text = "年龄：";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("宋体", 9F);
            this.label100.Location = new System.Drawing.Point(166, 63);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(41, 12);
            this.label100.TabIndex = 21;
            this.label100.Text = "医生：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(59, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.Location = new System.Drawing.Point(59, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "-";
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.AutoSize = true;
            this.lbDoctorName.Font = new System.Drawing.Font("宋体", 9F);
            this.lbDoctorName.Location = new System.Drawing.Point(216, 64);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(0, 12);
            this.lbDoctorName.TabIndex = 21;
            this.lbDoctorName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.BackColor = System.Drawing.Color.Transparent;
            this.lb_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_Time.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Time.ForeColor = System.Drawing.Color.Blue;
            this.lb_Time.Location = new System.Drawing.Point(1057, 0);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_Time.Size = new System.Drawing.Size(42, 16);
            this.lb_Time.TabIndex = 22;
            this.lb_Time.Text = "时间";
            this.lb_Time.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hScrollBar_Lead
            // 
            this.hScrollBar_Lead.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar_Lead.LargeChange = 1;
            this.hScrollBar_Lead.Location = new System.Drawing.Point(0, 753);
            this.hScrollBar_Lead.Name = "hScrollBar_Lead";
            this.hScrollBar_Lead.Size = new System.Drawing.Size(1099, 15);
            this.hScrollBar_Lead.TabIndex = 1;
            this.hScrollBar_Lead.ValueChanged += new System.EventHandler(this.hScrollBar_Lead_ValueChanged);
            this.hScrollBar_Lead.MouseEnter += new System.EventHandler(this.hScrollBar_Lead_MouseEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lb_Time);
            this.tabControl1.Controls.Add(this.pictureEdit3);
            this.tabControl1.Controls.Add(this.hScrollBar_Lead);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(1099, 768);
            this.tabControl1.TabIndex = 6;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit3.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Size = new System.Drawing.Size(1099, 753);
            this.pictureEdit3.TabIndex = 2;
            this.pictureEdit3.TabStop = false;
            this.pictureEdit3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureEdit3_Paint);
            // 
            // EcgViewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcgViewFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查阅与诊断";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EcgView_Frm_FormClosing);
            this.Load += new System.EventHandler(this.EcgView_Frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gBox_C.ResumeLayout(false);
            this.gBox_C.PerformLayout();
            this.gBox_SYS.ResumeLayout(false);
            this.gBox_SYS.PerformLayout();
            this.gBox_Mmol.ResumeLayout(false);
            this.gBox_Mmol.PerformLayout();
            this.gBox_Spo2.ResumeLayout(false);
            this.gBox_Spo2.PerformLayout();
            this.gBox_Urine.ResumeLayout(false);
            this.gBox_Urine.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.gBox_PatientInfo.ResumeLayout(false);
            this.gBox_PatientInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel tabControl1;
        
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDoctorDept;
        private System.Windows.Forms.Label lbDoctorName;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gBox_Urine;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lab_leadShow;
        private System.Windows.Forms.TextBox richTextBox1;
        private System.Windows.Forms.HScrollBar hScrollBar_Lead;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除选中记录ToolStripMenuItem;
        private Label lbBLD;
        private Label lbPH;
        private Label lbUBG;
        private Label lbNIT;
        private Label lbPRO;
        private Label lbLEU;
        private Label lbSG;
        private Label lbVC;
        private Label lbGLU;
        private Label lbBIL;
        private Label lbKET;
        private Label lb_VC;
        private Label lb_KET;
        private Label lb_PRO;
        private Label lb_LEU;
        private Label lb_TEMP;
        private Label lb_GLU;
        private Label lb_BLD;
        private Label lb_UBG;
        private Label lb_SG;
        private Label lb_BIL;
        private Label lb_PH;
        private Label lb_NIT;
        private Label lbSpo2;
        private Label lb_Spo2;
        private GroupBox gBox_PatientInfo;
        private GroupBox gBox_Mmol;
        private GroupBox gBox_Spo2;
        private GroupBox gBox_C;
        private GroupBox gBox_SYS;
        private Label lbSYS;
        private Label lb_SYS;
        private Label lbDIA;
        private Label lb_DIA;
        private Label lb_Mmol;
        private Label lb_Time;
        private PictureBox pictureEdit3;
        private Button btnClose;
     
    }
}