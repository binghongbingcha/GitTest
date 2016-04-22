namespace EcgViewPro
{
    partial class PatientManageFrm
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
                _getAppDataTask.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientManageFrm));
            this.plButtom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.qrCodePatientId = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl();
            this.btnSel = new System.Windows.Forms.Button();
            this.lb_DateTime = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbDateTtitle = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tbAgeEnd = new System.Windows.Forms.TextBox();
            this.lbSex = new System.Windows.Forms.Label();
            this.tbAgeStart = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbAgeTitle = new System.Windows.Forms.Label();
            this.panelBottomo = new System.Windows.Forms.Panel();
            this.panelOk = new System.Windows.Forms.Panel();
            this.btnSavePageSize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gc_PatientManage = new System.Windows.Forms.DataGridView();
            this.id_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EcgGather = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditPatient = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeletePatient = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_EcgList = new System.Windows.Forms.DataGridView();
            this.wardshipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EcgAnalisis = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InterpretationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongConnect = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ApplicationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wp = new EcgViewPro.Pager();
            this.plButtom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottomo.SuspendLayout();
            this.panelOk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_PatientManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_EcgList)).BeginInit();
            this.SuspendLayout();
            // 
            // plButtom
            // 
            this.plButtom.BackColor = System.Drawing.Color.White;
            this.plButtom.Controls.Add(this.panelTop);
            this.plButtom.Controls.Add(this.panelBottomo);
            this.plButtom.Controls.Add(this.gc_PatientManage);
            this.plButtom.Controls.Add(this.gc_EcgList);
            this.plButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plButtom.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.plButtom.Location = new System.Drawing.Point(0, 0);
            this.plButtom.Name = "plButtom";
            this.plButtom.Size = new System.Drawing.Size(1098, 688);
            this.plButtom.TabIndex = 6;
            this.plButtom.Text = " ";
            // 
            // panelTop
            // 
            this.panelTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTop.Controls.Add(this.qrCodePatientId);
            this.panelTop.Controls.Add(this.btnSel);
            this.panelTop.Controls.Add(this.lb_DateTime);
            this.panelTop.Controls.Add(this.lbName);
            this.panelTop.Controls.Add(this.dateTimePicker2);
            this.panelTop.Controls.Add(this.textBox1);
            this.panelTop.Controls.Add(this.dateTimePicker1);
            this.panelTop.Controls.Add(this.lbIP);
            this.panelTop.Controls.Add(this.lbDateTtitle);
            this.panelTop.Controls.Add(this.txtID);
            this.panelTop.Controls.Add(this.tbAgeEnd);
            this.panelTop.Controls.Add(this.lbSex);
            this.panelTop.Controls.Add(this.tbAgeStart);
            this.panelTop.Controls.Add(this.comboBox1);
            this.panelTop.Controls.Add(this.lbAge);
            this.panelTop.Controls.Add(this.lbAgeTitle);
            this.panelTop.Location = new System.Drawing.Point(42, 6);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1020, 164);
            this.panelTop.TabIndex = 4;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // qrCodePatientId
            // 
            this.qrCodePatientId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.qrCodePatientId.BackColor = System.Drawing.Color.White;
            this.qrCodePatientId.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qrCodePatientId.Location = new System.Drawing.Point(841, 9);
            this.qrCodePatientId.Name = "qrCodePatientId";
            this.qrCodePatientId.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Four;
            this.qrCodePatientId.Size = new System.Drawing.Size(165, 152);
            this.qrCodePatientId.TabIndex = 29;
            this.qrCodePatientId.Visible = false;
            // 
            // btnSel
            // 
            this.btnSel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSel.ForeColor = System.Drawing.Color.White;
            this.btnSel.Location = new System.Drawing.Point(664, 97);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(155, 55);
            this.btnSel.TabIndex = 14;
            this.btnSel.Text = "查询";
            this.btnSel.UseVisualStyleBackColor = false;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            this.btnSel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSel_MouseDown);
            this.btnSel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSel_MouseUp);
            // 
            // lb_DateTime
            // 
            this.lb_DateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_DateTime.AutoSize = true;
            this.lb_DateTime.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lb_DateTime.Location = new System.Drawing.Point(371, 57);
            this.lb_DateTime.Name = "lb_DateTime";
            this.lb_DateTime.Size = new System.Drawing.Size(99, 28);
            this.lb_DateTime.TabIndex = 28;
            this.lb_DateTime.Text = "日    期：";
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbName.Location = new System.Drawing.Point(22, 58);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(99, 28);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "姓    名：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(666, 52);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(153, 35);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBox1.Location = new System.Drawing.Point(134, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 35);
            this.textBox1.TabIndex = 2;
            this.textBox1.Click += new System.EventHandler(this.txtID_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(475, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 35);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // lbIP
            // 
            this.lbIP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbIP.AutoSize = true;
            this.lbIP.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbIP.Location = new System.Drawing.Point(22, 12);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(108, 28);
            this.lbIP.TabIndex = 1;
            this.lbIP.Text = "身 份 证：";
            // 
            // lbDateTtitle
            // 
            this.lbDateTtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDateTtitle.AutoSize = true;
            this.lbDateTtitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateTtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDateTtitle.Location = new System.Drawing.Point(629, 57);
            this.lbDateTtitle.Name = "lbDateTtitle";
            this.lbDateTtitle.Size = new System.Drawing.Size(33, 28);
            this.lbDateTtitle.TabIndex = 17;
            this.lbDateTtitle.Text = "至";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtID.Location = new System.Drawing.Point(134, 8);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(224, 35);
            this.txtID.TabIndex = 27;
            this.txtID.Click += new System.EventHandler(this.txtID_Click);
            // 
            // tbAgeEnd
            // 
            this.tbAgeEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbAgeEnd.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAgeEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbAgeEnd.Location = new System.Drawing.Point(666, 7);
            this.tbAgeEnd.MaxLength = 3;
            this.tbAgeEnd.Name = "tbAgeEnd";
            this.tbAgeEnd.Size = new System.Drawing.Size(153, 35);
            this.tbAgeEnd.TabIndex = 5;
            this.tbAgeEnd.Click += new System.EventHandler(this.txtID_Click);
            this.tbAgeEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeEnd_KeyPress);
            // 
            // lbSex
            // 
            this.lbSex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSex.AutoSize = true;
            this.lbSex.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbSex.Location = new System.Drawing.Point(22, 106);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(99, 28);
            this.lbSex.TabIndex = 4;
            this.lbSex.Text = "性    别：";
            // 
            // tbAgeStart
            // 
            this.tbAgeStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbAgeStart.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAgeStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbAgeStart.Location = new System.Drawing.Point(474, 9);
            this.tbAgeStart.MaxLength = 3;
            this.tbAgeStart.Name = "tbAgeStart";
            this.tbAgeStart.Size = new System.Drawing.Size(153, 35);
            this.tbAgeStart.TabIndex = 4;
            this.tbAgeStart.Click += new System.EventHandler(this.txtID_Click);
            this.tbAgeStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgeStart_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.comboBox1.Location = new System.Drawing.Point(134, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 36);
            this.comboBox1.TabIndex = 3;
            // 
            // lbAge
            // 
            this.lbAge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbAge.Location = new System.Drawing.Point(370, 13);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(99, 28);
            this.lbAge.TabIndex = 6;
            this.lbAge.Text = "年    龄：";
            // 
            // lbAgeTitle
            // 
            this.lbAgeTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbAgeTitle.AutoSize = true;
            this.lbAgeTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAgeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbAgeTitle.Location = new System.Drawing.Point(629, 14);
            this.lbAgeTitle.Name = "lbAgeTitle";
            this.lbAgeTitle.Size = new System.Drawing.Size(33, 28);
            this.lbAgeTitle.TabIndex = 6;
            this.lbAgeTitle.Text = "至";
            // 
            // panelBottomo
            // 
            this.panelBottomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBottomo.Controls.Add(this.wp);
            this.panelBottomo.Controls.Add(this.panelOk);
            this.panelBottomo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelBottomo.Location = new System.Drawing.Point(42, 427);
            this.panelBottomo.Name = "panelBottomo";
            this.panelBottomo.Size = new System.Drawing.Size(1020, 57);
            this.panelBottomo.TabIndex = 1;
            // 
            // panelOk
            // 
            this.panelOk.Controls.Add(this.btnSavePageSize);
            this.panelOk.Controls.Add(this.label6);
            this.panelOk.Controls.Add(this.txtPageSize);
            this.panelOk.Controls.Add(this.label5);
            this.panelOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOk.Location = new System.Drawing.Point(670, 0);
            this.panelOk.Margin = new System.Windows.Forms.Padding(0);
            this.panelOk.Name = "panelOk";
            this.panelOk.Size = new System.Drawing.Size(350, 57);
            this.panelOk.TabIndex = 1;
            // 
            // btnSavePageSize
            // 
            this.btnSavePageSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSavePageSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePageSize.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btnSavePageSize.ForeColor = System.Drawing.Color.White;
            this.btnSavePageSize.Location = new System.Drawing.Point(192, 0);
            this.btnSavePageSize.Name = "btnSavePageSize";
            this.btnSavePageSize.Size = new System.Drawing.Size(155, 55);
            this.btnSavePageSize.TabIndex = 23;
            this.btnSavePageSize.Text = "确定";
            this.btnSavePageSize.UseVisualStyleBackColor = false;
            this.btnSavePageSize.Click += new System.EventHandler(this.btnSavePageSize_Click);
            this.btnSavePageSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSavePageSize_MouseDown);
            this.btnSavePageSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSavePageSize_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(148, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "条";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtPageSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtPageSize.Location = new System.Drawing.Point(76, 11);
            this.txtPageSize.Multiline = true;
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(69, 39);
            this.txtPageSize.TabIndex = 22;
            this.txtPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageSize_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "每页";
            // 
            // gc_PatientManage
            // 
            this.gc_PatientManage.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.gc_PatientManage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gc_PatientManage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_PatientManage.BackgroundColor = System.Drawing.Color.White;
            this.gc_PatientManage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gc_PatientManage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gc_PatientManage.ColumnHeadersHeight = 48;
            this.gc_PatientManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_No,
            this.PatientName,
            this.Gender,
            this.Birthday2,
            this.CreateDate,
            this.EcgGather,
            this.EditPatient,
            this.DeletePatient,
            this.PatientID});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gc_PatientManage.DefaultCellStyle = dataGridViewCellStyle11;
            this.gc_PatientManage.EnableHeadersVisualStyles = false;
            this.gc_PatientManage.Location = new System.Drawing.Point(42, 174);
            this.gc_PatientManage.Margin = new System.Windows.Forms.Padding(0);
            this.gc_PatientManage.Name = "gc_PatientManage";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gc_PatientManage.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gc_PatientManage.RowTemplate.Height = 48;
            this.gc_PatientManage.Size = new System.Drawing.Size(1020, 247);
            this.gc_PatientManage.TabIndex = 2;
            this.gc_PatientManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gc_PatientManage_CellClick);
            this.gc_PatientManage.DoubleClick += new System.EventHandler(this.gc_PatientManage_DoubleClick);
            // 
            // id_No
            // 
            this.id_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id_No.DataPropertyName = "P_Id";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.id_No.DefaultCellStyle = dataGridViewCellStyle3;
            this.id_No.HeaderText = "身份证";
            this.id_No.Name = "id_No";
            this.id_No.ReadOnly = true;
            this.id_No.Width = 109;
            // 
            // PatientName
            // 
            this.PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientName.DataPropertyName = "PatientName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.PatientName.DefaultCellStyle = dataGridViewCellStyle4;
            this.PatientName.HeaderText = "姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gender.DataPropertyName = "Gender";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Gender.DefaultCellStyle = dataGridViewCellStyle5;
            this.Gender.HeaderText = "性别";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Birthday2
            // 
            this.Birthday2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Birthday2.DataPropertyName = "Birthday2";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Birthday2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Birthday2.HeaderText = "年龄";
            this.Birthday2.Name = "Birthday2";
            this.Birthday2.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreateDate.DataPropertyName = "CreateDate";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.CreateDate.HeaderText = "创建日期";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // EcgGather
            // 
            this.EcgGather.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EcgGather.DataPropertyName = "EcgGather";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EcgGather.DefaultCellStyle = dataGridViewCellStyle8;
            this.EcgGather.HeaderText = "数据采集";
            this.EcgGather.Name = "EcgGather";
            this.EcgGather.ReadOnly = true;
            this.EcgGather.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EcgGather.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EcgGather.Visible = false;
            this.EcgGather.Width = 133;
            // 
            // EditPatient
            // 
            this.EditPatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EditPatient.DataPropertyName = "EditPatient";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.EditPatient.DefaultCellStyle = dataGridViewCellStyle9;
            this.EditPatient.HeaderText = "个人信息";
            this.EditPatient.Name = "EditPatient";
            this.EditPatient.ReadOnly = true;
            this.EditPatient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditPatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditPatient.Width = 133;
            // 
            // DeletePatient
            // 
            this.DeletePatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DeletePatient.DataPropertyName = "DeletePatient";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.DeletePatient.DefaultCellStyle = dataGridViewCellStyle10;
            this.DeletePatient.HeaderText = "操作";
            this.DeletePatient.Name = "DeletePatient";
            this.DeletePatient.ReadOnly = true;
            this.DeletePatient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeletePatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeletePatient.Width = 85;
            // 
            // PatientID
            // 
            this.PatientID.DataPropertyName = "PatientID";
            this.PatientID.HeaderText = "患者ID";
            this.PatientID.Name = "PatientID";
            this.PatientID.ReadOnly = true;
            this.PatientID.Visible = false;
            // 
            // gc_EcgList
            // 
            this.gc_EcgList.AllowUserToAddRows = false;
            this.gc_EcgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.gc_EcgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gc_EcgList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_EcgList.BackgroundColor = System.Drawing.Color.White;
            this.gc_EcgList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gc_EcgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gc_EcgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gc_EcgList.ColumnHeadersHeight = 48;
            this.gc_EcgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wardshipId,
            this.EcgAnalisis,
            this.InterpretationStatus,
            this.LongConnect,
            this.ApplicationId});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gc_EcgList.DefaultCellStyle = dataGridViewCellStyle19;
            this.gc_EcgList.EnableHeadersVisualStyles = false;
            this.gc_EcgList.Location = new System.Drawing.Point(42, 491);
            this.gc_EcgList.Margin = new System.Windows.Forms.Padding(0);
            this.gc_EcgList.Name = "gc_EcgList";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gc_EcgList.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.gc_EcgList.RowTemplate.Height = 48;
            this.gc_EcgList.Size = new System.Drawing.Size(1020, 191);
            this.gc_EcgList.TabIndex = 3;
            this.gc_EcgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gc_EcgList_CellClick);
            // 
            // wardshipId
            // 
            this.wardshipId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.wardshipId.DataPropertyName = "wardshipId";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.wardshipId.DefaultCellStyle = dataGridViewCellStyle15;
            this.wardshipId.HeaderText = "采集时间";
            this.wardshipId.MinimumWidth = 200;
            this.wardshipId.Name = "wardshipId";
            this.wardshipId.ReadOnly = true;
            this.wardshipId.Width = 240;
            // 
            // EcgAnalisis
            // 
            this.EcgAnalisis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EcgAnalisis.DataPropertyName = "EcgAnalisis";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.EcgAnalisis.DefaultCellStyle = dataGridViewCellStyle16;
            this.EcgAnalisis.HeaderText = "查阅与诊断";
            this.EcgAnalisis.Name = "EcgAnalisis";
            this.EcgAnalisis.ReadOnly = true;
            this.EcgAnalisis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EcgAnalisis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InterpretationStatus
            // 
            this.InterpretationStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InterpretationStatus.DataPropertyName = "InterpretationStatus";
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.InterpretationStatus.DefaultCellStyle = dataGridViewCellStyle17;
            this.InterpretationStatus.HeaderText = "状态";
            this.InterpretationStatus.Name = "InterpretationStatus";
            this.InterpretationStatus.ReadOnly = true;
            // 
            // LongConnect
            // 
            this.LongConnect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LongConnect.DataPropertyName = "LongConnect";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.LongConnect.DefaultCellStyle = dataGridViewCellStyle18;
            this.LongConnect.HeaderText = "远程申请";
            this.LongConnect.Name = "LongConnect";
            this.LongConnect.ReadOnly = true;
            // 
            // ApplicationId
            // 
            this.ApplicationId.DataPropertyName = "ApplicationId";
            this.ApplicationId.HeaderText = "申请ID";
            this.ApplicationId.Name = "ApplicationId";
            this.ApplicationId.ReadOnly = true;
            this.ApplicationId.Visible = false;
            // 
            // wp
            // 
            this.wp.AllowDrop = true;
            this.wp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wp.Location = new System.Drawing.Point(0, 0);
            this.wp.Margin = new System.Windows.Forms.Padding(0);
            this.wp.Name = "wp";
            this.wp.PageCount = 0;
            this.wp.PageIndex = 1;
            this.wp.PageSize = 1;
            this.wp.Size = new System.Drawing.Size(670, 57);
            this.wp.TabIndex = 0;
            this.wp.TotalRows = 0;
            this.wp.EventPaging += new EcgViewPro.EventPagingHandler(this.wp_EventPaging);
            // 
            // PatientManageFrm
            // 
            this.AcceptButton = this.btnSel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.plButtom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientManageFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PatientManage_Frm_Load);
            this.plButtom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottomo.ResumeLayout(false);
            this.panelOk.ResumeLayout(false);
            this.panelOk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_PatientManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_EcgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plButtom;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbSex;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbIP;
        private Pager wp;
        private System.Windows.Forms.Panel panelOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSavePageSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.TextBox tbAgeEnd;
        private System.Windows.Forms.TextBox tbAgeStart;
        private System.Windows.Forms.Label lbAgeTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbDateTtitle;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lb_DateTime;
        private System.Windows.Forms.DataGridView gc_PatientManage;
        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl qrCodePatientId;
        private System.Windows.Forms.Panel panelBottomo;
        private System.Windows.Forms.DataGridView gc_EcgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewLinkColumn EcgGather;
        private System.Windows.Forms.DataGridViewLinkColumn EditPatient;
        private System.Windows.Forms.DataGridViewLinkColumn DeletePatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn wardshipId;
        private System.Windows.Forms.DataGridViewLinkColumn EcgAnalisis;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterpretationStatus;
        private System.Windows.Forms.DataGridViewLinkColumn LongConnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationId;
        private System.Windows.Forms.Panel panelTop;
    }
}