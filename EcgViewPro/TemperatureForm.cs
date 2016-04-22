using CommonProj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class TemperatureForm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        public TemperatureForm()
        {
            InitializeComponent();
        }

        private void Temperature_Load(object sender, EventArgs e)
        {
            txtBoxTemId.Text = ConfigHelper.IP;

            var image = new Bitmap(pictureBox2.Width, pictureBox2.Width);
            Graphics g = Graphics.FromImage(image);
            var myBrush = new LinearGradientBrush(new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Width), pictureBox2.BackColor, pictureBox2.BackColor, LinearGradientMode.Horizontal);
            g.FillRectangle(myBrush, 0, 0, pictureBox2.Width, pictureBox2.Width);

            var f = new Font("微软雅黑", 24, FontStyle.Regular);
            g.DrawString("体温检测值 （", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(233, 155, 1)), 220, 17, 20, 20);
            g.DrawString("偏低", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 240, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(2, 234, 17)), 340, 17, 20, 20);
            g.DrawString("正常", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 360, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(234, 85, 3)), 460, 17, 20, 20);
            g.DrawString("偏高", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 480, 3);
            g.DrawString("）", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 550, 3);
            pictureBox2.Image = image;
        }

        private void timer_Tem_Tick(object sender, EventArgs e)
        {
            try
            {
                lb_C.ForeColor = Color.FromArgb(233, 155, 1);
                lb_CF.ForeColor = Color.FromArgb(233, 155, 1);
                string T = SerialPortClass.CreateInstance().T;
                if (T != "L" && T != "——" && !string.IsNullOrEmpty(T))
                {
                    if (Convert.ToDecimal(T) >= 36 && Convert.ToDecimal(T)<=37)
                    {
                        lb_C.ForeColor = Color.FromArgb(2, 234, 17);
                        lb_CF.ForeColor = Color.FromArgb(2, 234, 17);
                    }
                    if (Convert.ToDecimal(T) > 37)
                    {
                        lb_C.ForeColor = Color.FromArgb(234, 85, 3);
                        lb_CF.ForeColor = Color.FromArgb(234, 85, 3);
                    }
                }
                lb_C.Text = SerialPortClass.CreateInstance().T;
                lb_CF.Text = SerialPortClass.CreateInstance().F;
            }
            catch (Exception ex)
            {

                WatchDog.Write(@"获取温度：", ex);
            }
          
        }
      
        private bool AddApplicationInfo()
        {
            bool ok = false;
            string sqlApp = "select * from Tb_Application where ApplicationID='" + ConfigHelper.AppId + "'";
            DataTable dt = _sqlite.ExcuteSqlite(sqlApp);
            if (null != dt)
            {
                var lsp = new List<SQLiteParameter>();
                if (dt.Rows.Count == 0)
                {
                    sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,Temperature) Values(@ApplicationID,@PatientID,@wardshipId,@Temperature)";
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    lsp.Add(new SQLiteParameter("@PatientID", ConfigHelper.PatientId));
                    lsp.Add(new SQLiteParameter("@wardshipId", DateTime.Now.ToString("s")));
                    lsp.Add(new SQLiteParameter("@Temperature", lb_C.Text.Trim()));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                else
                {
                    sqlApp = "update Tb_Application set Temperature=@Temperature where ApplicationID=@ApplicationID";
                    lsp.Add(new SQLiteParameter("@Temperature", lb_C.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                lsp.Clear();
            }
            return ok;
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                             panelTop.ClientRectangle,
                             Color.FromArgb(35, 144, 240),//7f9db9
                             1,
                             ButtonBorderStyle.Solid,
                            Color.FromArgb(35, 144, 240),
                             1,
                             ButtonBorderStyle.Solid,
                            Color.FromArgb(35, 144, 240),
                             1,
                             ButtonBorderStyle.Solid,
                            Color.FromArgb(35, 144, 240),
                             1,
                             ButtonBorderStyle.Solid);
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxTemId.Text.Trim()))
            {
                XtraMessageBox.Show("请先输入检测人的信息！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (AddApplicationInfo())
            {
                XtraMessageBox.Show(@"保存成功！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTemp_MouseDown(object sender, MouseEventArgs e)
        {
            btnTemp.BackColor = Color.FromArgb(15, 96, 168);
        }

        private void btnTemp_MouseUp(object sender, MouseEventArgs e)
        {
            btnTemp.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
