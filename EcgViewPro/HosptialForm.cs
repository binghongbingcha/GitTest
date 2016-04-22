using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class HosptialForm : Form
    {
        public HosptialForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 医院信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxHosptial_Click(object sender, EventArgs e)
        {
            Process[] mProcs = Process.GetProcessesByName(@"osk");
            if (mProcs.Length == 0)
            {
                Process.Start(@"C:\WINDOWS\system32\osk.exe");
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHosptialSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnHosptialSave.BackColor = Color.FromArgb(15, 96, 168);

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHosptialSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnHosptialSave.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
