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
    public partial class BloodOxygenForm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        public BloodOxygenForm()
        {
            InitializeComponent();
        }
        private void Spo2_Load(object sender, EventArgs e)
        {
            txtBoxBloodOxygenId.Text = ConfigHelper.IP;

            var image = new Bitmap(pictureBox2.Width, pictureBox2.Width);
            Graphics g = Graphics.FromImage(image);
            var myBrush = new LinearGradientBrush(new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Width), pictureBox2.BackColor, pictureBox2.BackColor, LinearGradientMode.Horizontal);
            g.FillRectangle(myBrush, 0, 0, pictureBox2.Width, pictureBox2.Width);

            var f = new Font("微软雅黑", 24, FontStyle.Regular);
            g.DrawString("血氧饱和度检测值 （", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(233, 155, 1)), 300, 17, 20, 20);
            g.DrawString("偏低", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 320, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(2, 234, 17)), 420, 17, 20, 20);
            g.DrawString("正常", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 440, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(234, 85, 3)), 540, 17, 20, 20);
            g.DrawString("偏高", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 560, 3);
            g.DrawString("）", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 630, 3);
            pictureBox2.Image = image;
        }

        private void timer_Spo2_Tick(object sender, EventArgs e)
        {
            try
            {
                lb_Spo2.ForeColor = Color.FromArgb(233, 155, 1);
                lbBloodOxygenBpm.ForeColor = Color.FromArgb(233, 155, 1);
                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().Spo2))
                {
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().Spo2) >= 94)
                    {
                        lb_Spo2.ForeColor = Color.FromArgb(2, 234, 17);
                    }
                  
                }
                lb_Spo2.Text = SerialPortClass.CreateInstance().Spo2;


                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().Bpm))
                {
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().Bpm) >= 60 && Convert.ToInt32(SerialPortClass.CreateInstance().Bpm) <=100)
                    {
                        lbBloodOxygenBpm.ForeColor = Color.FromArgb(2, 234, 17);

                    }
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().Bpm) > 100)
                    {
                        lbBloodOxygenBpm.ForeColor = Color.FromArgb(234, 85, 3);
                    }
                }
                lbBloodOxygenBpm.Text = SerialPortClass.CreateInstance().Bpm;
                if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().SpoCatch.ToString()) || SerialPortClass.CreateInstance().SpoCatch.ToString() == "——")
                {
                    lb_SpoCatch.Visible = false;
                }
                else
                {
                    lb_SpoCatch.Visible = true;
                }
                lb_SpoCatch.Text = SerialPortClass.CreateInstance().SpoCatch.ToString();

            }
            catch (Exception ex)
            {

                WatchDog.Write(@"获取血氧：", ex);
            }
           
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpo2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxBloodOxygenId.Text.Trim()))
            {
                XtraMessageBox.Show("请先输入检测人的信息！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (AddApplicationInfo())
            {
                XtraMessageBox.Show(@"保存成功",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                    sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,Spo2) Values(@ApplicationID,@PatientID,@wardshipId,@Spo2)";
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    lsp.Add(new SQLiteParameter("@PatientID", ConfigHelper.PatientId));
                    lsp.Add(new SQLiteParameter("@wardshipId", DateTime.Now.ToString("s")));
                    lsp.Add(new SQLiteParameter("@Spo2", lb_Spo2.Text.Trim()));
                    ok= _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0 ;
                }
                else
                {
                    sqlApp = "update Tb_Application set Spo2=@Spo2 where ApplicationID=@ApplicationID";
                    lsp.Add(new SQLiteParameter("@Spo2", lb_Spo2.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    ok= _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0 ;
                }
                lsp.Clear();
            }
            return ok;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpo2_MouseDown(object sender, MouseEventArgs e)
        {
            btnSpo2.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpo2_MouseUp(object sender, MouseEventArgs e)
        {
            btnSpo2.BackColor = Color.FromArgb(35, 144, 240);
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
    }
}
