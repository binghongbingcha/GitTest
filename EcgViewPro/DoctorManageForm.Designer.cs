namespace EcgViewPro
{
    partial class DoctorManageForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorManageForm));
            this.panelDoctorTop = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtBoxDoctorName = new System.Windows.Forms.TextBox();
            this.lbDoctorName = new System.Windows.Forms.Label();
            this.txtBoxDoctorCode = new System.Windows.Forms.TextBox();
            this.lbDoctorCode = new System.Windows.Forms.Label();
            this.btnDoctorSel = new System.Windows.Forms.Button();
            this.panelDoctorFill = new System.Windows.Forms.Panel();
            this.wpDoctor = new EcgViewPro.Pager();
            this.btnDoctorAdd = new System.Windows.Forms.Button();
            this.dGVDocotr = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsElectronicSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorMod = new System.Windows.Forms.DataGridViewLinkColumn();
            this.doctorDel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ResetPassword = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panelDoctorTop.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelDoctorFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDocotr)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDoctorTop
            // 
            this.panelDoctorTop.BackColor = System.Drawing.Color.White;
            this.panelDoctorTop.Controls.Add(this.panelTop);
            this.panelDoctorTop.Controls.Add(this.btnDoctorSel);
            this.panelDoctorTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDoctorTop.Location = new System.Drawing.Point(0, 0);
            this.panelDoctorTop.Name = "panelDoctorTop";
            this.panelDoctorTop.Size = new System.Drawing.Size(1098, 278);
            this.panelDoctorTop.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTop.Controls.Add(this.txtBoxDoctorName);
            this.panelTop.Controls.Add(this.lbDoctorName);
            this.panelTop.Controls.Add(this.txtBoxDoctorCode);
            this.panelTop.Controls.Add(this.lbDoctorCode);
            this.panelTop.Location = new System.Drawing.Point(30, 30);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1041, 131);
            this.panelTop.TabIndex = 3;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // txtBoxDoctorName
            // 
            this.txtBoxDoctorName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxDoctorName.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtBoxDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxDoctorName.Location = new System.Drawing.Point(683, 28);
            this.txtBoxDoctorName.Multiline = true;
            this.txtBoxDoctorName.Name = "txtBoxDoctorName";
            this.txtBoxDoctorName.Size = new System.Drawing.Size(234, 48);
            this.txtBoxDoctorName.TabIndex = 1;
            this.txtBoxDoctorName.Click += new System.EventHandler(this.txtBoxDoctorCode_Click);
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDoctorName.AutoSize = true;
            this.lbDoctorName.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorName.Location = new System.Drawing.Point(606, 37);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(68, 31);
            this.lbDoctorName.TabIndex = 0;
            this.lbDoctorName.Text = "姓名:";
            // 
            // txtBoxDoctorCode
            // 
            this.txtBoxDoctorCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxDoctorCode.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtBoxDoctorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxDoctorCode.Location = new System.Drawing.Point(250, 28);
            this.txtBoxDoctorCode.Multiline = true;
            this.txtBoxDoctorCode.Name = "txtBoxDoctorCode";
            this.txtBoxDoctorCode.Size = new System.Drawing.Size(234, 48);
            this.txtBoxDoctorCode.TabIndex = 1;
            this.txtBoxDoctorCode.Click += new System.EventHandler(this.txtBoxDoctorCode_Click);
            // 
            // lbDoctorCode
            // 
            this.lbDoctorCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDoctorCode.AutoSize = true;
            this.lbDoctorCode.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbDoctorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorCode.Location = new System.Drawing.Point(150, 37);
            this.lbDoctorCode.Name = "lbDoctorCode";
            this.lbDoctorCode.Size = new System.Drawing.Size(68, 31);
            this.lbDoctorCode.TabIndex = 0;
            this.lbDoctorCode.Text = "工号:";
            // 
            // btnDoctorSel
            // 
            this.btnDoctorSel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDoctorSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnDoctorSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctorSel.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.btnDoctorSel.ForeColor = System.Drawing.Color.White;
            this.btnDoctorSel.Location = new System.Drawing.Point(472, 194);
            this.btnDoctorSel.Name = "btnDoctorSel";
            this.btnDoctorSel.Size = new System.Drawing.Size(155, 55);
            this.btnDoctorSel.TabIndex = 2;
            this.btnDoctorSel.Text = "查询";
            this.btnDoctorSel.UseVisualStyleBackColor = false;
            this.btnDoctorSel.Click += new System.EventHandler(this.btnDoctorSel_Click);
            this.btnDoctorSel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDoctorSel_MouseDown);
            this.btnDoctorSel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDoctorSel_MouseUp);
            // 
            // panelDoctorFill
            // 
            this.panelDoctorFill.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelDoctorFill.Controls.Add(this.wpDoctor);
            this.panelDoctorFill.Controls.Add(this.btnDoctorAdd);
            this.panelDoctorFill.Location = new System.Drawing.Point(30, 600);
            this.panelDoctorFill.Name = "panelDoctorFill";
            this.panelDoctorFill.Size = new System.Drawing.Size(1041, 57);
            this.panelDoctorFill.TabIndex = 1;
            // 
            // wpDoctor
            // 
            this.wpDoctor.AllowDrop = true;
            this.wpDoctor.BackColor = System.Drawing.Color.White;
            this.wpDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpDoctor.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.wpDoctor.Location = new System.Drawing.Point(0, 0);
            this.wpDoctor.Margin = new System.Windows.Forms.Padding(0);
            this.wpDoctor.Name = "wpDoctor";
            this.wpDoctor.PageCount = 0;
            this.wpDoctor.PageIndex = 1;
            this.wpDoctor.PageSize = 100;
            this.wpDoctor.Size = new System.Drawing.Size(886, 57);
            this.wpDoctor.TabIndex = 1;
            this.wpDoctor.TotalRows = 0;
            this.wpDoctor.EventPaging += new EcgViewPro.EventPagingHandler(this.wpDoctor_EventPaging);
            // 
            // btnDoctorAdd
            // 
            this.btnDoctorAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnDoctorAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDoctorAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctorAdd.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.btnDoctorAdd.ForeColor = System.Drawing.Color.White;
            this.btnDoctorAdd.Location = new System.Drawing.Point(886, 0);
            this.btnDoctorAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoctorAdd.Name = "btnDoctorAdd";
            this.btnDoctorAdd.Size = new System.Drawing.Size(155, 57);
            this.btnDoctorAdd.TabIndex = 2;
            this.btnDoctorAdd.Text = "添加";
            this.btnDoctorAdd.UseVisualStyleBackColor = false;
            this.btnDoctorAdd.Click += new System.EventHandler(this.btnDoctorAdd_Click);
            this.btnDoctorAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDoctorAdd_MouseDown);
            this.btnDoctorAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDoctorAdd_MouseUp);
            // 
            // dGVDocotr
            // 
            this.dGVDocotr.AllowUserToAddRows = false;
            this.dGVDocotr.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dGVDocotr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDocotr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dGVDocotr.BackgroundColor = System.Drawing.Color.White;
            this.dGVDocotr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDocotr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVDocotr.ColumnHeadersHeight = 48;
            this.dGVDocotr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVDocotr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DoctorCode,
            this.DoctorName,
            this.DoctorSex,
            this.DoctorDept,
            this.IsElectronicSignature,
            this.CreateDateTime,
            this.doctorMod,
            this.doctorDel,
            this.ResetPassword});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVDocotr.DefaultCellStyle = dataGridViewCellStyle13;
            this.dGVDocotr.EnableHeadersVisualStyles = false;
            this.dGVDocotr.Location = new System.Drawing.Point(30, 291);
            this.dGVDocotr.Margin = new System.Windows.Forms.Padding(0);
            this.dGVDocotr.MultiSelect = false;
            this.dGVDocotr.Name = "dGVDocotr";
            this.dGVDocotr.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDocotr.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dGVDocotr.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dGVDocotr.RowTemplate.Height = 48;
            this.dGVDocotr.Size = new System.Drawing.Size(1041, 300);
            this.dGVDocotr.TabIndex = 0;
            this.dGVDocotr.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVDocotr_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ID.HeaderText = "主键";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // DoctorCode
            // 
            this.DoctorCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorCode.DataPropertyName = "DoctorCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DoctorCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.DoctorCode.HeaderText = "工号";
            this.DoctorCode.Name = "DoctorCode";
            this.DoctorCode.ReadOnly = true;
            // 
            // DoctorName
            // 
            this.DoctorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorName.DataPropertyName = "DoctorName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DoctorName.DefaultCellStyle = dataGridViewCellStyle5;
            this.DoctorName.HeaderText = "姓名";
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.ReadOnly = true;
            // 
            // DoctorSex
            // 
            this.DoctorSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorSex.DataPropertyName = "DoctorSex";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DoctorSex.DefaultCellStyle = dataGridViewCellStyle6;
            this.DoctorSex.HeaderText = "性别";
            this.DoctorSex.Name = "DoctorSex";
            this.DoctorSex.ReadOnly = true;
            // 
            // DoctorDept
            // 
            this.DoctorDept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorDept.DataPropertyName = "DoctorDept";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DoctorDept.DefaultCellStyle = dataGridViewCellStyle7;
            this.DoctorDept.HeaderText = "科室";
            this.DoctorDept.Name = "DoctorDept";
            this.DoctorDept.ReadOnly = true;
            // 
            // IsElectronicSignature
            // 
            this.IsElectronicSignature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsElectronicSignature.DataPropertyName = "IsElectronicSignature";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.IsElectronicSignature.DefaultCellStyle = dataGridViewCellStyle8;
            this.IsElectronicSignature.HeaderText = "签名";
            this.IsElectronicSignature.Name = "IsElectronicSignature";
            this.IsElectronicSignature.ReadOnly = true;
            // 
            // CreateDateTime
            // 
            this.CreateDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreateDateTime.DataPropertyName = "CreateDateTime";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle9.Format = "yyyy-MM-dd";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.CreateDateTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.CreateDateTime.HeaderText = "日期";
            this.CreateDateTime.Name = "CreateDateTime";
            this.CreateDateTime.ReadOnly = true;
            // 
            // doctorMod
            // 
            this.doctorMod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doctorMod.DataPropertyName = "doctorMod";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.doctorMod.DefaultCellStyle = dataGridViewCellStyle10;
            this.doctorMod.HeaderText = "修改";
            this.doctorMod.Name = "doctorMod";
            this.doctorMod.ReadOnly = true;
            // 
            // doctorDel
            // 
            this.doctorDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doctorDel.DataPropertyName = "doctorDel";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.doctorDel.DefaultCellStyle = dataGridViewCellStyle11;
            this.doctorDel.HeaderText = "删除";
            this.doctorDel.Name = "doctorDel";
            this.doctorDel.ReadOnly = true;
            // 
            // ResetPassword
            // 
            this.ResetPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResetPassword.DataPropertyName = "ResetPassword";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ResetPassword.DefaultCellStyle = dataGridViewCellStyle12;
            this.ResetPassword.HeaderText = "操作";
            this.ResetPassword.Name = "ResetPassword";
            this.ResetPassword.ReadOnly = true;
            // 
            // DoctorManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.dGVDocotr);
            this.Controls.Add(this.panelDoctorFill);
            this.Controls.Add(this.panelDoctorTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoctorManageForm";
            this.Text = "医生管理";
            this.panelDoctorTop.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelDoctorFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDocotr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDoctorTop;
        private System.Windows.Forms.Panel panelDoctorFill;
        private System.Windows.Forms.DataGridView dGVDocotr;
        private System.Windows.Forms.TextBox txtBoxDoctorCode;
        private System.Windows.Forms.Label lbDoctorCode;
        private System.Windows.Forms.TextBox txtBoxDoctorName;
        private System.Windows.Forms.Label lbDoctorName;
        private Pager wpDoctor;
        private System.Windows.Forms.Button btnDoctorSel;
        private System.Windows.Forms.Button btnDoctorAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsElectronicSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateTime;
        private System.Windows.Forms.DataGridViewLinkColumn doctorMod;
        private System.Windows.Forms.DataGridViewLinkColumn doctorDel;
        private System.Windows.Forms.DataGridViewLinkColumn ResetPassword;
        private System.Windows.Forms.Panel panelTop;
    }
}