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
    public partial class BloodPressureForm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        public BloodPressureForm()
        {
            InitializeComponent();
        }

        private void BloodPressureForm_Load(object sender, EventArgs e)
        {
            txtBoxBloodPressureId.Text = ConfigHelper.IP;

            var image = new Bitmap(pBoxBloodPressure.Width, pBoxBloodPressure.Width);
            Graphics g = Graphics.FromImage(image);
            var myBrush = new LinearGradientBrush(new Rectangle(0, 0, pBoxBloodPressure.Width, pBoxBloodPressure.Width), pBoxBloodPressure.BackColor, pBoxBloodPressure.BackColor, LinearGradientMode.Horizontal);
            g.FillRectangle(myBrush, 0, 0, pBoxBloodPressure.Width, pBoxBloodPressure.Width);

            var f = new Font("微软雅黑", 24, FontStyle.Regular);


            g.DrawString("无创血压检测值 （", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(233, 155, 1)), 280, 17, 20, 20);
            g.DrawString("偏低", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 300, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(2, 234, 17)), 400, 17, 20, 20);
            g.DrawString("正常", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 420, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(234, 85, 3)), 520, 17, 20, 20);
            g.DrawString("偏高", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 540, 3);
            g.DrawString("）", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 610, 3);
            pBoxBloodPressure.Image = image;
        }
        /// <summary>
        /// 开始检测血压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComBluetooth))
            {
                XtraMessageBox.Show(@"未检测到设备，请开启！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            SerialPortClass.CreateInstance().MsbCatch = string.Empty;
            SerialPortClass.CreateInstance().Instance_BluetoothStart();
            SerialPortClass.CreateInstance().IsblueToothMmhg = false;

        }

        private void timerBloodPressure_Tick(object sender, EventArgs e)
        {
            try
            {
                lb_SYS.ForeColor = Color.FromArgb(233, 155, 1);
                lb_DIA.ForeColor = Color.FromArgb(233, 155, 1);
                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().SYS))
                {

                    if (Convert.ToInt32(SerialPortClass.CreateInstance().SYS) > 90&&Convert.ToInt32(SerialPortClass.CreateInstance().SYS) < 140)
                    {
                        lb_SYS.ForeColor = Color.FromArgb(2, 234, 17);

                    }
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().SYS) >= 140)
                    {
                        lb_SYS.ForeColor = Color.FromArgb(234, 85, 3);
                    }

                  
                }
                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().DIA))
                {
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().DIA) > 60 && Convert.ToInt32(SerialPortClass.CreateInstance().DIA) <90)
                    {
                        lb_DIA.ForeColor = Color.FromArgb(2, 234, 17);
                    }
                    if (Convert.ToInt32(SerialPortClass.CreateInstance().DIA) >= 90)
                    {
                        lb_DIA.ForeColor = Color.FromArgb(234, 85, 3);
                    }
                }

                lb_SYS.Text = SerialPortClass.CreateInstance().SYS;//收缩压
                lb_DIA.Text = SerialPortClass.CreateInstance().DIA;//舒张压

                if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().MsbCatch))
                {
                    lb_MBSCatch.Visible = false;
                }
                else
                {
                    lb_MBSCatch.Visible = true;
                }
                lb_MBSCatch.Text = SerialPortClass.CreateInstance().MsbCatch;
            }
            catch (Exception ex)
            {

                WatchDog.Write(@"获取血压：", ex);
            }
           
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxBloodPressureId.Text.Trim()))
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
                    sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,DIA,SYS) Values(@ApplicationID,@PatientID,@wardshipId,@DIA,@SYS)";
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    lsp.Add(new SQLiteParameter("@PatientID", ConfigHelper.PatientId));
                    lsp.Add(new SQLiteParameter("@wardshipId", DateTime.Now.ToString("s")));
                    lsp.Add(new SQLiteParameter("@DIA", lb_DIA.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@SYS", lb_SYS.Text.Trim()));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                else
                {
                    sqlApp = "update Tb_Application set DIA=@DIA,SYS=@SYS where ApplicationID=@ApplicationID";
                    lsp.Add(new SQLiteParameter("@DIA", lb_DIA.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@SYS", lb_SYS.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                lsp.Clear();
            }
            return ok;
        }
        /// <summary>
        /// 开始检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureStart_MouseDown(object sender, MouseEventArgs e)
        {
            btnBloodPressureStart.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 开始检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureStart_MouseUp(object sender, MouseEventArgs e)
        {
            btnBloodPressureStart.BackColor = Color.FromArgb(35, 144, 240);

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnBloodPressureSave.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodPressureSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnBloodPressureSave.BackColor = Color.FromArgb(35, 144, 240);

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
