namespace EcgViewPro
{
    partial class EcgDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EcgDoctor));
            this.lbDoctorName = new System.Windows.Forms.Label();
            this.txtEditDoctorName = new DevExpress.XtraEditors.TextEdit();
            this.lbDoctorSex = new System.Windows.Forms.Label();
            this.lbDoctorDept = new System.Windows.Forms.Label();
            this.txtEditDoctorCode = new DevExpress.XtraEditors.TextEdit();
            this.lbDoctorCode = new System.Windows.Forms.Label();
            this.cBoxDoctorSex = new System.Windows.Forms.ComboBox();
            this.pictureEditSignature = new DevExpress.XtraEditors.PictureEdit();
            this.txtEditDoctorDept = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddSignature = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditSignature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorDept.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.AutoSize = true;
            this.lbDoctorName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorName.Location = new System.Drawing.Point(20, 88);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(86, 31);
            this.lbDoctorName.TabIndex = 0;
            this.lbDoctorName.Text = "姓名：";
            // 
            // txtEditDoctorName
            // 
            this.txtEditDoctorName.Location = new System.Drawing.Point(112, 80);
            this.txtEditDoctorName.Name = "txtEditDoctorName";
            this.txtEditDoctorName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEditDoctorName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtEditDoctorName.Properties.Appearance.Options.UseFont = true;
            this.txtEditDoctorName.Properties.Appearance.Options.UseForeColor = true;
            this.txtEditDoctorName.Properties.AutoHeight = false;
            this.txtEditDoctorName.Size = new System.Drawing.Size(232, 46);
            this.txtEditDoctorName.TabIndex = 1;
            this.txtEditDoctorName.Click += new System.EventHandler(this.txtEditDoctorCode_Click);
            this.txtEditDoctorName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditDoctorName_KeyPress);
            // 
            // lbDoctorSex
            // 
            this.lbDoctorSex.AutoSize = true;
            this.lbDoctorSex.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDoctorSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorSex.Location = new System.Drawing.Point(20, 145);
            this.lbDoctorSex.Name = "lbDoctorSex";
            this.lbDoctorSex.Size = new System.Drawing.Size(86, 31);
            this.lbDoctorSex.TabIndex = 2;
            this.lbDoctorSex.Text = "性别：";
            // 
            // lbDoctorDept
            // 
            this.lbDoctorDept.AutoSize = true;
            this.lbDoctorDept.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDoctorDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorDept.Location = new System.Drawing.Point(20, 201);
            this.lbDoctorDept.Name = "lbDoctorDept";
            this.lbDoctorDept.Size = new System.Drawing.Size(86, 31);
            this.lbDoctorDept.TabIndex = 4;
            this.lbDoctorDept.Text = "科室：";
            // 
            // txtEditDoctorCode
            // 
            this.txtEditDoctorCode.Location = new System.Drawing.Point(112, 19);
            this.txtEditDoctorCode.Name = "txtEditDoctorCode";
            this.txtEditDoctorCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEditDoctorCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtEditDoctorCode.Properties.Appearance.Options.UseFont = true;
            this.txtEditDoctorCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtEditDoctorCode.Properties.AutoHeight = false;
            this.txtEditDoctorCode.Size = new System.Drawing.Size(232, 46);
            this.txtEditDoctorCode.TabIndex = 7;
            this.txtEditDoctorCode.Click += new System.EventHandler(this.txtEditDoctorCode_Click);
            this.txtEditDoctorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditDoctorCode_KeyPress);
            // 
            // lbDoctorCode
            // 
            this.lbDoctorCode.AutoSize = true;
            this.lbDoctorCode.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDoctorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbDoctorCode.Location = new System.Drawing.Point(20, 27);
            this.lbDoctorCode.Name = "lbDoctorCode";
            this.lbDoctorCode.Size = new System.Drawing.Size(86, 31);
            this.lbDoctorCode.TabIndex = 6;
            this.lbDoctorCode.Text = "工号：";
            // 
            // cBoxDoctorSex
            // 
            this.cBoxDoctorSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDoctorSex.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxDoctorSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cBoxDoctorSex.FormattingEnabled = true;
            this.cBoxDoctorSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cBoxDoctorSex.Location = new System.Drawing.Point(112, 141);
            this.cBoxDoctorSex.Name = "cBoxDoctorSex";
            this.cBoxDoctorSex.Size = new System.Drawing.Size(232, 39);
            this.cBoxDoctorSex.TabIndex = 8;
            // 
            // pictureEditSignature
            // 
            this.pictureEditSignature.Location = new System.Drawing.Point(33, 320);
            this.pictureEditSignature.Name = "pictureEditSignature";
            this.pictureEditSignature.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureEditSignature.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.pictureEditSignature.Properties.Appearance.Options.UseFont = true;
            this.pictureEditSignature.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEditSignature.Properties.NullText = "无签名";
            this.pictureEditSignature.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEditSignature.Size = new System.Drawing.Size(295, 87);
            this.pictureEditSignature.TabIndex = 13;
            this.pictureEditSignature.Tag = "请选JPG图片";
            // 
            // txtEditDoctorDept
            // 
            this.txtEditDoctorDept.Location = new System.Drawing.Point(112, 193);
            this.txtEditDoctorDept.Name = "txtEditDoctorDept";
            this.txtEditDoctorDept.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEditDoctorDept.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtEditDoctorDept.Properties.Appearance.Options.UseFont = true;
            this.txtEditDoctorDept.Properties.Appearance.Options.UseForeColor = true;
            this.txtEditDoctorDept.Properties.AutoHeight = false;
            this.txtEditDoctorDept.Size = new System.Drawing.Size(232, 46);
            this.txtEditDoctorDept.TabIndex = 1;
            this.txtEditDoctorDept.Click += new System.EventHandler(this.txtEditDoctorCode_Click);
            this.txtEditDoctorDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditDoctorName_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(33, 443);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 48);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseDown);
            this.btnAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseUp);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(181, 443);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 48);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "取消";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            this.btnReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseUp);
            // 
            // btnAddSignature
            // 
            this.btnAddSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnAddSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSignature.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddSignature.ForeColor = System.Drawing.Color.White;
            this.btnAddSignature.Location = new System.Drawing.Point(33, 259);
            this.btnAddSignature.Name = "btnAddSignature";
            this.btnAddSignature.Size = new System.Drawing.Size(180, 48);
            this.btnAddSignature.TabIndex = 15;
            this.btnAddSignature.Text = "添加电子签名";
            this.btnAddSignature.UseVisualStyleBackColor = false;
            this.btnAddSignature.Click += new System.EventHandler(this.btnAddSignature_Click);
            this.btnAddSignature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAddSignature_MouseDown);
            this.btnAddSignature.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAddSignature_MouseUp);
            // 
            // EcgDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 510);
            this.Controls.Add(this.btnAddSignature);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureEditSignature);
            this.Controls.Add(this.cBoxDoctorSex);
            this.Controls.Add(this.txtEditDoctorCode);
            this.Controls.Add(this.lbDoctorCode);
            this.Controls.Add(this.lbDoctorDept);
            this.Controls.Add(this.lbDoctorSex);
            this.Controls.Add(this.txtEditDoctorDept);
            this.Controls.Add(this.txtEditDoctorName);
            this.Controls.Add(this.lbDoctorName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcgDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "     ";
            this.Load += new System.EventHandler(this.EcgDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditSignature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditDoctorDept.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDoctorName;
        private DevExpress.XtraEditors.TextEdit txtEditDoctorName;
        private System.Windows.Forms.Label lbDoctorSex;
        private System.Windows.Forms.Label lbDoctorDept;
        private DevExpress.XtraEditors.TextEdit txtEditDoctorCode;
        private System.Windows.Forms.Label lbDoctorCode;
        private System.Windows.Forms.ComboBox cBoxDoctorSex;
        private DevExpress.XtraEditors.PictureEdit pictureEditSignature;
        private DevExpress.XtraEditors.TextEdit txtEditDoctorDept;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddSignature;
    }
}