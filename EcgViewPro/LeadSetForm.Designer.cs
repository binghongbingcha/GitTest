namespace EcgViewPro
{
    partial class LeadSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeadSetForm));
            this.lbSingleLead = new System.Windows.Forms.Label();
            this.cBoxSingleLead = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbSingleLead
            // 
            this.lbSingleLead.AutoSize = true;
            this.lbSingleLead.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lbSingleLead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbSingleLead.Location = new System.Drawing.Point(47, 67);
            this.lbSingleLead.Name = "lbSingleLead";
            this.lbSingleLead.Size = new System.Drawing.Size(132, 27);
            this.lbSingleLead.TabIndex = 0;
            this.lbSingleLead.Text = "单节律导联：";
            // 
            // cBoxSingleLead
            // 
            this.cBoxSingleLead.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cBoxSingleLead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cBoxSingleLead.FormattingEnabled = true;
            this.cBoxSingleLead.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "aVR",
            "aVL",
            "aVF",
            "V1",
            "V2",
            "V3",
            "V4",
            "V5",
            "V6"});
            this.cBoxSingleLead.Location = new System.Drawing.Point(186, 63);
            this.cBoxSingleLead.Name = "cBoxSingleLead";
            this.cBoxSingleLead.Size = new System.Drawing.Size(121, 35);
            this.cBoxSingleLead.TabIndex = 1;
            this.cBoxSingleLead.SelectedIndexChanged += new System.EventHandler(this.cBoxSingleLead_SelectedIndexChanged);
            // 
            // LeadSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 207);
            this.Controls.Add(this.cBoxSingleLead);
            this.Controls.Add(this.lbSingleLead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LeadSetForm";
            this.Text = "节律导联";
            this.Load += new System.EventHandler(this.LeadSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSingleLead;
        private System.Windows.Forms.ComboBox cBoxSingleLead;
    }
}