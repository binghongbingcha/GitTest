using System.Diagnostics;
using CommonProj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class SystemForm : Form
    {
        SqliteOptions _sqlite = new SqliteOptions();

        public SystemForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref   Message m)
        {
            if (m.Msg != 0x007B && m.Msg != 0x0301 && m.Msg != 0x0302)
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemMod_Click(object sender, EventArgs e)
        {
            if (!txtBoxOldPassword.Text.Trim().Equals(ConfigHelper.LoginPassword))
            {
                XtraMessageBox.Show(@"请输入正确的当前密码", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!txtBoxNewPassword.Text.Trim().Equals(txtBoxNewOkPassword.Text.Trim()))
            {
                XtraMessageBox.Show(@"输入的新密码和确定密码不一致，请重新输入！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (txtBoxNewPassword.Text.Trim().Equals(txtBoxOldPassword.Text.Trim()))
            {
                XtraMessageBox.Show(@"输入的当前密码和新密码一致，请重新输入！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            bool ok = UpdateUserPassword(txtBoxNewPassword.Text.Trim());
            if (ok)
            {
                XtraMessageBox.Show(@"修改成功", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxOldPassword.Text = string.Empty;
                txtBoxNewPassword.Text = string.Empty;
                txtBoxNewOkPassword.Text = string.Empty;
            }
        }
        /// <summary>
        /// 当前密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)(e.KeyChar) == Keys.Back)) 
            { 
                e.Handled = false; 
            }
            else
            {
                e.Handled = true; XtraMessageBox.Show(@"只能输入数字或英文", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //if (txtBoxOldPassword.Text.Length > 8)
            //{
            //    XtraMessageBox.Show("请输入8位长度以内的字符串");
            //}
        }
        /// <summary>
        /// 新密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)(e.KeyChar) == Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; XtraMessageBox.Show(@"只能输入数字或英文", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// 确定密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxNewOkPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)(e.KeyChar) == Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; XtraMessageBox.Show(@"只能输入数字或英文", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        public bool UpdateUserPassword(string newPassword)
        {
            string _sql = string.Format("update tb_doctor set DoctorPassword='{0}' where ID='{1}'",newPassword,ConfigHelper.LoginId);
            return _sqlite.SqliteUpdate(_sql);
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxOldPassword_Click(object sender, EventArgs e)
        {
            GetOsk();
        }
        /// <summary>
        /// 调用虚拟键盘
        /// </summary>
        private void GetOsk()
        {
            Process[] mProcs = Process.GetProcessesByName(@"osk");
            if (mProcs.Length == 0)
            {
                Process.Start(@"C:\WINDOWS\system32\osk.exe");
            }
        }

        private void btnSystemMod_MouseDown(object sender, MouseEventArgs e)
        {
            btnSystemMod.BackColor = Color.FromArgb(15, 96, 168);
        }

        private void btnSystemMod_MouseUp(object sender, MouseEventArgs e)
        {
            btnSystemMod.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
