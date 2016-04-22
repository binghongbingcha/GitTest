namespace EcgViewPro
{
    partial class HosptialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HosptialForm));
            this.lbHosptial = new System.Windows.Forms.Label();
            this.txtBoxHosptial = new System.Windows.Forms.TextBox();
            this.btnHosptialSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHosptial
            // 
            this.lbHosptial.AutoSize = true;
            this.lbHosptial.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lbHosptial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbHosptial.Location = new System.Drawing.Point(11, 36);
            this.lbHosptial.Name = "lbHosptial";
            this.lbHosptial.Size = new System.Drawing.Size(92, 27);
            this.lbHosptial.TabIndex = 0;
            this.lbHosptial.Text = "医院信息";
            // 
            // txtBoxHosptial
            // 
            this.txtBoxHosptial.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxHosptial.Location = new System.Drawing.Point(11, 71);
            this.txtBoxHosptial.Name = "txtBoxHosptial";
            this.txtBoxHosptial.Size = new System.Drawing.Size(356, 34);
            this.txtBoxHosptial.TabIndex = 1;
            this.txtBoxHosptial.Click += new System.EventHandler(this.txtBoxHosptial_Click);
            // 
            // btnHosptialSave
            // 
            this.btnHosptialSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(240)))));
            this.btnHosptialSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHosptialSave.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHosptialSave.ForeColor = System.Drawing.Color.White;
            this.btnHosptialSave.Location = new System.Drawing.Point(11, 135);
            this.btnHosptialSave.Name = "btnHosptialSave";
            this.btnHosptialSave.Size = new System.Drawing.Size(155, 55);
            this.btnHosptialSave.TabIndex = 2;
            this.btnHosptialSave.Text = "保存";
            this.btnHosptialSave.UseVisualStyleBackColor = false;
            this.btnHosptialSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHosptialSave_MouseDown);
            this.btnHosptialSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHosptialSave_MouseUp);
            // 
            // HosptialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.btnHosptialSave);
            this.Controls.Add(this.txtBoxHosptial);
            this.Controls.Add(this.lbHosptial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HosptialForm";
            this.Text = "医院信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHosptial;
        private System.Windows.Forms.TextBox txtBoxHosptial;
        private System.Windows.Forms.Button btnHosptialSave;
    }
}