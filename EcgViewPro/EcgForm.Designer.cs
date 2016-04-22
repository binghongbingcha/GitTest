namespace EcgViewPro
{
    partial class EcgForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EcgForm));
            this.panelEcgBottom = new System.Windows.Forms.Panel();
            this.btnEcgStart = new System.Windows.Forms.Button();
            this.pBoxFill = new System.Windows.Forms.PictureBox();
            this.txtBoxEcgId = new System.Windows.Forms.TextBox();
            this.lbEcgId = new System.Windows.Forms.Label();
            this.panelEcgBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFill)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEcgBottom
            // 
            this.panelEcgBottom.Controls.Add(this.txtBoxEcgId);
            this.panelEcgBottom.Controls.Add(this.lbEcgId);
            this.panelEcgBottom.Controls.Add(this.btnEcgStart);
            this.panelEcgBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEcgBottom.Location = new System.Drawing.Point(0, 625);
            this.panelEcgBottom.Name = "panelEcgBottom";
            this.panelEcgBottom.Size = new System.Drawing.Size(1098, 63);
            this.panelEcgBottom.TabIndex = 1;
            // 
            // btnEcgStart
            // 
            this.btnEcgStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEcgStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnEcgStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEcgStart.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btnEcgStart.ForeColor = System.Drawing.Color.White;
            this.btnEcgStart.Location = new System.Drawing.Point(471, 4);
            this.btnEcgStart.Name = "btnEcgStart";
            this.btnEcgStart.Size = new System.Drawing.Size(155, 55);
            this.btnEcgStart.TabIndex = 0;
            this.btnEcgStart.Text = "心电检测";
            this.btnEcgStart.UseVisualStyleBackColor = false;
            this.btnEcgStart.Click += new System.EventHandler(this.btnEcgStart_Click);
            this.btnEcgStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEcgStart_MouseDown);
            this.btnEcgStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEcgStart_MouseUp);
            // 
            // pBoxFill
            // 
            this.pBoxFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxFill.Image = global::EcgViewPro.Properties.Resources.EcgLogo;
            this.pBoxFill.Location = new System.Drawing.Point(0, 0);
            this.pBoxFill.Name = "pBoxFill";
            this.pBoxFill.Size = new System.Drawing.Size(1098, 625);
            this.pBoxFill.TabIndex = 2;
            this.pBoxFill.TabStop = false;
            // 
            // txtBoxEcgId
            // 
            this.txtBoxEcgId.Enabled = false;
            this.txtBoxEcgId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.txtBoxEcgId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtBoxEcgId.Location = new System.Drawing.Point(120, 9);
            this.txtBoxEcgId.Multiline = true;
            this.txtBoxEcgId.Name = "txtBoxEcgId";
            this.txtBoxEcgId.Size = new System.Drawing.Size(285, 45);
            this.txtBoxEcgId.TabIndex = 10;
            this.txtBoxEcgId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbEcgId
            // 
            this.lbEcgId.AutoSize = true;
            this.lbEcgId.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lbEcgId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbEcgId.Location = new System.Drawing.Point(19, 16);
            this.lbEcgId.Name = "lbEcgId";
            this.lbEcgId.Size = new System.Drawing.Size(92, 31);
            this.lbEcgId.TabIndex = 9;
            this.lbEcgId.Text = "身份证:";
            // 
            // EcgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1098, 688);
            this.Controls.Add(this.pBoxFill);
            this.Controls.Add(this.panelEcgBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EcgForm";
            this.Text = "心电检测";
            this.panelEcgBottom.ResumeLayout(false);
            this.panelEcgBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEcgBottom;
        private System.Windows.Forms.Button btnEcgStart;
        private System.Windows.Forms.PictureBox pBoxFill;
        private System.Windows.Forms.TextBox txtBoxEcgId;
        private System.Windows.Forms.Label lbEcgId;
    }
}