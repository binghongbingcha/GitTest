namespace EcgViewPro
{
    partial class DisplayColorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayColorForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnWaveSize = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGrid = new System.Windows.Forms.Button();
            this.btnWave = new System.Windows.Forms.Button();
            this.colorPickEditBack = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEditGrid = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEditWave = new DevExpress.XtraEditors.ColorPickEdit();
            this.spinEditWaveSize = new DevExpress.XtraEditors.SpinEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.colorSet = new System.Windows.Forms.ColorDialog();
            this.pBoxFill = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditGrid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditWave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWaveSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFill)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnWaveSize);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.btnGrid);
            this.panelTop.Controls.Add(this.btnWave);
            this.panelTop.Controls.Add(this.colorPickEditBack);
            this.panelTop.Controls.Add(this.colorPickEditGrid);
            this.panelTop.Controls.Add(this.colorPickEditWave);
            this.panelTop.Controls.Add(this.spinEditWaveSize);
            this.panelTop.Controls.Add(this.label8);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(729, 336);
            this.panelTop.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(559, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 55);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseDown);
            this.btnSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseUp);
            // 
            // btnWaveSize
            // 
            this.btnWaveSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnWaveSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaveSize.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWaveSize.ForeColor = System.Drawing.Color.White;
            this.btnWaveSize.Location = new System.Drawing.Point(352, 224);
            this.btnWaveSize.Name = "btnWaveSize";
            this.btnWaveSize.Size = new System.Drawing.Size(155, 55);
            this.btnWaveSize.TabIndex = 31;
            this.btnWaveSize.Text = "默认";
            this.btnWaveSize.UseVisualStyleBackColor = false;
            this.btnWaveSize.Click += new System.EventHandler(this.btnWaveSize_Click);
            this.btnWaveSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWaveSize_MouseDown);
            this.btnWaveSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnWaveSize_MouseUp);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(354, 152);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 55);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "默认";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseDown);
            this.btnBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseUp);
            // 
            // btnGrid
            // 
            this.btnGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrid.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGrid.ForeColor = System.Drawing.Color.White;
            this.btnGrid.Location = new System.Drawing.Point(354, 80);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(155, 55);
            this.btnGrid.TabIndex = 31;
            this.btnGrid.Text = "默认";
            this.btnGrid.UseVisualStyleBackColor = false;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            this.btnGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGrid_MouseDown);
            this.btnGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnGrid_MouseUp);
            // 
            // btnWave
            // 
            this.btnWave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnWave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWave.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWave.ForeColor = System.Drawing.Color.White;
            this.btnWave.Location = new System.Drawing.Point(354, 8);
            this.btnWave.Name = "btnWave";
            this.btnWave.Size = new System.Drawing.Size(155, 55);
            this.btnWave.TabIndex = 31;
            this.btnWave.Text = "默认";
            this.btnWave.UseVisualStyleBackColor = false;
            this.btnWave.Click += new System.EventHandler(this.btnWave_Click);
            this.btnWave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWave_MouseDown);
            this.btnWave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnWave_MouseUp);
            // 
            // colorPickEditBack
            // 
            this.colorPickEditBack.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditBack.Location = new System.Drawing.Point(263, 152);
            this.colorPickEditBack.Name = "colorPickEditBack";
            this.colorPickEditBack.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorPickEditBack.Properties.Appearance.Options.UseFont = true;
            this.colorPickEditBack.Properties.AutoHeight = false;
            this.colorPickEditBack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditBack.Size = new System.Drawing.Size(74, 55);
            this.colorPickEditBack.TabIndex = 30;
            this.colorPickEditBack.EditValueChanged += new System.EventHandler(this.colorPickEditBack_EditValueChanged);
            // 
            // colorPickEditGrid
            // 
            this.colorPickEditGrid.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditGrid.Location = new System.Drawing.Point(263, 80);
            this.colorPickEditGrid.Name = "colorPickEditGrid";
            this.colorPickEditGrid.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorPickEditGrid.Properties.Appearance.Options.UseFont = true;
            this.colorPickEditGrid.Properties.AutoHeight = false;
            this.colorPickEditGrid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditGrid.Size = new System.Drawing.Size(74, 55);
            this.colorPickEditGrid.TabIndex = 30;
            this.colorPickEditGrid.EditValueChanged += new System.EventHandler(this.colorPickEditGrid_EditValueChanged);
            // 
            // colorPickEditWave
            // 
            this.colorPickEditWave.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditWave.Location = new System.Drawing.Point(263, 8);
            this.colorPickEditWave.Name = "colorPickEditWave";
            this.colorPickEditWave.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorPickEditWave.Properties.Appearance.Options.UseFont = true;
            this.colorPickEditWave.Properties.AutoHeight = false;
            this.colorPickEditWave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditWave.Size = new System.Drawing.Size(74, 55);
            this.colorPickEditWave.TabIndex = 30;
            this.colorPickEditWave.EditValueChanged += new System.EventHandler(this.colorPickEditWave_EditValueChanged);
            // 
            // spinEditWaveSize
            // 
            this.spinEditWaveSize.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinEditWaveSize.Location = new System.Drawing.Point(263, 224);
            this.spinEditWaveSize.Name = "spinEditWaveSize";
            this.spinEditWaveSize.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spinEditWaveSize.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.spinEditWaveSize.Properties.Appearance.Options.UseFont = true;
            this.spinEditWaveSize.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditWaveSize.Properties.AutoHeight = false;
            this.spinEditWaveSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditWaveSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditWaveSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditWaveSize.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.spinEditWaveSize.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditWaveSize.Size = new System.Drawing.Size(74, 55);
            this.spinEditWaveSize.TabIndex = 25;
            this.spinEditWaveSize.EditValueChanged += new System.EventHandler(this.spinEditWaveSize_EditValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label8.Location = new System.Drawing.Point(138, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 27);
            this.label8.TabIndex = 24;
            this.label8.Text = "波形粗细：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(118, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 27);
            this.label5.TabIndex = 23;
            this.label5.Text = "波形背景色：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(58, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 27);
            this.label6.TabIndex = 22;
            this.label6.Text = "波形背景网格颜色：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(18, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 27);
            this.label7.TabIndex = 21;
            this.label7.Text = "分析的心电图波形颜色：";
            // 
            // pBoxFill
            // 
            this.pBoxFill.BackColor = System.Drawing.Color.White;
            this.pBoxFill.Location = new System.Drawing.Point(0, 342);
            this.pBoxFill.Name = "pBoxFill";
            this.pBoxFill.Size = new System.Drawing.Size(729, 128);
            this.pBoxFill.TabIndex = 1;
            this.pBoxFill.TabStop = false;
            // 
            // DisplayColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 468);
            this.Controls.Add(this.pBoxFill);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayColorForm";
            this.Text = "显示颜色";
            this.Load += new System.EventHandler(this.DisplayColorForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditGrid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditWave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditWaveSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pBoxFill;
        private System.Windows.Forms.ColorDialog colorSet;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditBack;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditGrid;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditWave;
        private DevExpress.XtraEditors.SpinEdit spinEditWaveSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnWaveSize;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGrid;
        private System.Windows.Forms.Button btnWave;
    }
}