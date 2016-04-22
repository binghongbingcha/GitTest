using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using CommonProj;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EcgViewPro
{
    public partial class FormLogin : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        Dictionary<string, UserInfo> _users = new Dictionary<string, UserInfo>();
        readonly UserInfo _user = new UserInfo();

        public FormLogin()
        {
            InitializeComponent();

            SerialPortClass.CreateInstance().GetUrineAnalyzerComs();
        }

        protected override void WndProc(ref   Message m)
        {
            if (m.Msg != 0x007B && m.Msg != 0x0301 && m.Msg != 0x0302)
            {
                base.WndProc(ref m);
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = cBoxUsername.Text.Trim();
            string userPassword = txtBox_Password.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                XtraMessageBox.Show(@"用户名不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(userPassword))
            {
                XtraMessageBox.Show(@"密码不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var fs = new FileStream(Application.StartupPath +@"\data.bin", FileMode.Create);
             var bf = new BinaryFormatter();
            _user.UserName = userName;
            _user.Pwd = cbRember.Checked ? userPassword : "";
            if (_users.ContainsKey(_user.UserName))
            {
                _users.Remove(_user.UserName);
            }
            _users.Add(_user.UserName, _user);
            bf.Serialize(fs, _users);
            fs.Close();
            if (ValidationPassword(userName, userPassword))
            {
                if (userName == "admin")
                {
                    ConfigHelper.IsAdmin = true;
                }
                var mf = new MainForm {FormBorderStyle = FormBorderStyle.None};
                mf.Show();
                Hide();
            }
            else
            {
                XtraMessageBox.Show(@"用户名或者密码错误！");
            }
        }
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <returns></returns>
        private bool ValidationPassword(string userName, string userPassword)
        {
            string sql = string.Format("select * from tb_Doctor where DoctorName='{0}' and DoctorPassword='{1}'", userName, userPassword);
            DataTable dt = _sqlite.ExcuteSqlite(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                ConfigHelper.LoginId = dt.Rows[0]["ID"].ToString();
                ConfigHelper.LoginName = dt.Rows[0]["DoctorName"].ToString();
                ConfigHelper.LoginPassword = userPassword;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Login_Load(object sender, EventArgs e)
        {
            var fs = new FileStream(Application.StartupPath + @"\data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                var bf = new BinaryFormatter();
                _users = bf.Deserialize(fs) as Dictionary<string, UserInfo>;
                if (_users != null)
                {
                    foreach (UserInfo ui in _users.Values)
                    {
                        cBoxUsername.Items.Add(ui.UserName);
                    }
                    for (int i = 0; i < _users.Count; i++)
                    {
                        if (cBoxUsername.Text != "")
                        {
                            if (_users.ContainsKey(cBoxUsername.Text))
                            {
                                txtBox_Password.Text = _users[cBoxUsername.Text].Pwd;
                                cbRember.Checked = true;
                            }
                        }
                    }
                }
            }
            cBoxUsername.Focus();
            fs.Close();
        }
        private void cBoxUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            var fs = new FileStream(Application.StartupPath + @"\data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                var bf = new BinaryFormatter();
                _users = bf.Deserialize(fs) as Dictionary<string, UserInfo>;
                if (null != _users)
                {
                    for (int i = 0; i < _users.Count; i++)
                    {
                        if (cBoxUsername.Text.Trim() != "")
                        {
                            if (_users.ContainsKey(cBoxUsername.Text.Trim()) && _users[cBoxUsername.Text].Pwd != "")
                            {
                                txtBox_Password.Text = _users[cBoxUsername.Text].Pwd;
                                cbRember.Checked = true;
                            }
                            else
                            {
                                txtBox_Password.Text = "";
                                cbRember.Checked = false;
                            }
                        }
                    }
                }
            }

            fs.Close();

        }

        private void cBoxUsername_Click(object sender, EventArgs e)
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

        private void btn_Login_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Login.BackColor = Color.FromArgb(15, 96, 168);
        }

        private void btn_Login_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Login.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
