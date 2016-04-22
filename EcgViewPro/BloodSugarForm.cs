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
    public partial class BloodSugarForm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        public BloodSugarForm()
        {
            InitializeComponent();
        }

        private void BloodForm_Load(object sender, EventArgs e)
        {

            txtBoxBloodSugarId.Text = ConfigHelper.IP;

            var image = new Bitmap(pBoxBloodTitle.Width, pBoxBloodTitle.Width);
            Graphics g = Graphics.FromImage(image);
            var myBrush = new LinearGradientBrush(new Rectangle(0, 0, pBoxBloodTitle.Width, pBoxBloodTitle.Width), pBoxBloodTitle.BackColor, pBoxBloodTitle.BackColor, LinearGradientMode.Horizontal);
            g.FillRectangle(myBrush, 0, 0, pBoxBloodTitle.Width, pBoxBloodTitle.Width);

            var f = new Font("微软雅黑", 24, FontStyle.Regular);
            g.DrawString("血糖检测值 （", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(233, 155, 1)), 220, 17, 20, 20);
            g.DrawString("偏低", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 240, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(2, 234, 17)), 340, 17, 20, 20);
            g.DrawString("正常", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 360, 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(234, 85, 3)), 460, 17, 20, 20);
            g.DrawString("偏高", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 480, 3);
            g.DrawString("）", f, new SolidBrush(Color.FromArgb(102, 102, 102)), 550, 3);
            pBoxBloodTitle.Image = image;
        }
        /// <summary>
        /// 血糖检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSugarRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComBloodString))
            {
                SerialPortClass.CreateInstance().GetUrineAnalyzerComs();
                if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComBloodString))
                {
                    XtraMessageBox.Show(@"未检测到设备，请插入！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            SerialPortClass.CreateInstance().Analyzer_Blood();
            lbMmol.ForeColor = Color.FromArgb(233, 155, 1);
            if (ConfigHelper.BloodSugarNum == 0)//餐前--空腹
            {
                radiobtnBloodBefore.Checked = true;
                radiobtnBloodAfter.Checked = false;

                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().M))
                {
                    if (Convert.ToDouble(SerialPortClass.CreateInstance().M) >= 4.4 && Convert.ToDouble(SerialPortClass.CreateInstance().M)<=7.0)
                    {
                        lbMmol.ForeColor = Color.FromArgb(2, 234, 17);
                    }
                    if (Convert.ToDouble(SerialPortClass.CreateInstance().M) > 7.0)
                    {
                        lbMmol.ForeColor =Color.FromArgb(234, 85, 3);
                    }
                }


            }
            if (ConfigHelper.BloodSugarNum == 1)//餐后--非空腹
            {
                radiobtnBloodBefore.Checked = false;
                radiobtnBloodAfter.Checked = false;

                if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().M))
                {
                    if (Convert.ToDouble(SerialPortClass.CreateInstance().M) >= 4.4 && Convert.ToDouble(SerialPortClass.CreateInstance().M)<=10.0)
                    {
                        lbMmol.ForeColor = Color.FromArgb(2, 234, 17);
                    }
                    if (Convert.ToDouble(SerialPortClass.CreateInstance().M) > 10.0)
                    {
                        lbMmol.ForeColor =Color.FromArgb(234, 85, 3);
                    }
                }
            }

            lbMmol.Text = SerialPortClass.CreateInstance().M;
            ConfigHelper.BloodSugarNum=-1;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxBloodSugarId.Text.Trim()))
            {
                XtraMessageBox.Show("请先输入检测人的信息！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (AddApplicationInfo())
            {
                XtraMessageBox.Show(@"保存成功",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Information );
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
                    sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,Mmol) Values(@ApplicationID,@PatientID,@wardshipId,@Mmol)";
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    lsp.Add(new SQLiteParameter("@PatientID", ConfigHelper.PatientId));
                    lsp.Add(new SQLiteParameter("@wardshipId", DateTime.Now.ToString("s")));
                    lsp.Add(new SQLiteParameter("@Mmol", lbMmol.Text.Trim()));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                else
                {
                    sqlApp = "update Tb_Application set Mmol=@Mmol where ApplicationID=@ApplicationID";
                    lsp.Add(new SQLiteParameter("@Mmol", lbMmol.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                lsp.Clear();
            }
            return ok;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSugarRead_MouseDown(object sender, MouseEventArgs e)
        {
            btnBloodSugarRead.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSugarRead_MouseUp(object sender, MouseEventArgs e)
        {
            btnBloodSugarRead.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnBloodSave.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBloodSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnBloodSave.BackColor = Color.FromArgb(35, 144, 240);
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
