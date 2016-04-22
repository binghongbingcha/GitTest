using System.Drawing;
using CommonProj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class UrineForm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        public UrineForm()
        {
            InitializeComponent();
        }
       

        private void UrineForm_Load(object sender, EventArgs e)
        {
            txtBoxUrineId.Text = ConfigHelper.IP;
            
        }

        /// <summary>
        /// 读取检测数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrineRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComUrineAnalyzer))
            {
                SerialPortClass.CreateInstance().GetUrineAnalyzerComs();
                if (string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComUrineAnalyzer))
                {
                    XtraMessageBox.Show(@"未检测到设备，请插入！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            SerialPortClass.CreateInstance().ReadComPort(SerialPortClass.CreateInstance().ComUrineAnalyzer);
            SerialPortClass.CreateInstance().Analyzer_UrineData();

            lb_LEU.Text = SerialPortClass.CreateInstance().LEU;
            lb_BIL.Text = SerialPortClass.CreateInstance().BIL;
            lb_BLD.Text = SerialPortClass.CreateInstance().BLD;
            lb_GLU.Text = SerialPortClass.CreateInstance().GLU;
            lb_KET.Text = SerialPortClass.CreateInstance().KET;
            lb_NIT.Text = SerialPortClass.CreateInstance().NIT;
            lb_PH.Text = SerialPortClass.CreateInstance().PH;
            lb_PRO.Text = SerialPortClass.CreateInstance().PRO;
            lb_SG.Text = SerialPortClass.CreateInstance().SG;
            lb_UBG.Text = SerialPortClass.CreateInstance().UBG;
            lb_VC.Text = SerialPortClass.CreateInstance().VC;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrineSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxUrineId.Text.Trim()))
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
                    sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,LEU,NIT,UBG,PRO,PH,BLD,KET,BIL,GLU,VC,SG) Values(@ApplicationID,@PatientID,@wardshipId,@LEU,@NIT,@UBG,@PRO,@PH,@BLD,@KET,@BIL,@GLU,@VC,@SG)";
                    lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                    lsp.Add(new SQLiteParameter("@PatientID", ConfigHelper.PatientId));
                    lsp.Add(new SQLiteParameter("@wardshipId", DateTime.Now.ToString("s")));
                    lsp.Add(new SQLiteParameter("@LEU", lb_LEU.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@NIT", lb_NIT.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@UBG", lb_UBG.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@PRO", lb_PRO.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@PH", lb_PH.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@BLD", lb_BLD.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@KET", lb_KET.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@BIL", lb_BIL.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@GLU", lb_GLU.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@VC", lb_VC.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@SG", lb_SG.Text.Trim()));
                    ok = _sqlite.ExecuteSql(sqlApp, lsp.ToArray()) > 0;
                }
                else
                {
                    sqlApp = "update Tb_Application set LEU=@LEU,NIT=@NIT,UBG=@UBG,PRO=@PRO,PH=@PH,BLD=@BLD,KET=@KET,BIL=@BIL,GLU=@GLU,VC=@VC,SG=@SG where ApplicationID=@ApplicationID";
                    lsp.Add(new SQLiteParameter("@LEU", lb_LEU.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@NIT", lb_NIT.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@UBG", lb_UBG.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@PRO", lb_PRO.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@PH", lb_PH.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@BLD", lb_BLD.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@KET", lb_KET.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@BIL", lb_BIL.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@GLU", lb_GLU.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@VC", lb_VC.Text.Trim()));
                    lsp.Add(new SQLiteParameter("@SG", lb_SG.Text.Trim()));
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
        private void btnUrineRead_MouseDown(object sender, MouseEventArgs e)
        {
            btnUrineRead.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrineRead_MouseUp(object sender, MouseEventArgs e)
        {
            btnUrineRead.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrineSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnUrineSave.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrineSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnUrineSave.BackColor = Color.FromArgb(35, 144, 240);
           
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
