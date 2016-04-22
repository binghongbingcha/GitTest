using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProj;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class RemoteServiceForm : Form
    {
        public RemoteServiceForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUrl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditAppUrl.Text.Trim()))
            {
                XtraMessageBox.Show(lbAppUrl.Text + @"不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEditAppUrl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBoxUrlUserName.Text.Trim()))
            {
                XtraMessageBox.Show(txtBoxUrlUserName.Text + @"不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtBoxUrlUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtBoxUrlPassWord.Text.Trim()))
            {
                XtraMessageBox.Show(txtBoxUrlPassWord.Text + @"不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtBoxUrlPassWord.Focus();
                return;
            }

            ConfigHelper.UrlDistanceString = txtEditAppUrl.Text.Trim();
            ConfigHelper.UrlUserName = txtBoxUrlUserName.Text.Trim();
            ConfigHelper.UrlPassWord = txtBoxUrlPassWord.Text.Trim();
            ConfigHelper.InterpretationLevel = (cBoxLevel.SelectedIndex + 1).ToString();

            var dic = new Dictionary<string, string>
                {
                    {"UrlDistanceString", ConfigHelper.UrlDistanceString},
                    {"UrlUserName", ConfigHelper.UrlUserName},
                    {"UrlPassWord", ConfigHelper.UrlPassWord},
                    {"InterpretationLevel", ConfigHelper.InterpretationLevel}
                };
            bool ok = ConfigHelper.SaveConfig(dic);
            if (ok)
            {
                XtraMessageBox.Show(@"保存成功！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResetUrl_Click(object sender, EventArgs e)
        {
            txtEditAppUrl.Text = string.Empty;
            txtBoxUrlUserName.Text = string.Empty;
            txtBoxUrlPassWord.Text = string.Empty;
        }

        private void RemoteServiceForm_Load(object sender, EventArgs e)
        {
            txtEditAppUrl.Text = ConfigHelper.UrlDistanceString;
            txtBoxUrlUserName.Text = ConfigHelper.UrlUserName;
            txtBoxUrlPassWord.Text = ConfigHelper.UrlPassWord;
            cBoxLevel.SelectedIndex = Convert.ToInt32(ConfigHelper.InterpretationLevel) - 1;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUrl_MouseDown(object sender, MouseEventArgs e)
        {
            btnSaveUrl.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUrl_MouseUp(object sender, MouseEventArgs e)
        {
            btnSaveUrl.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetUrl_MouseDown(object sender, MouseEventArgs e)
        {
            btnResetUrl.BackColor = Color.FromArgb(15, 96, 168);

        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetUrl_MouseUp(object sender, MouseEventArgs e)
        {
            btnResetUrl.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
