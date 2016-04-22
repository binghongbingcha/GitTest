using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using CommonProj;
using Newtonsoft.Json;

namespace EcgViewPro
{
    public partial class MainForm : Form
    {
        private Task _openBlood;
        private Task _getTask;
        readonly System.Timers.Timer _nowTimer = new System.Timers.Timer(1000);
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _nowTimer.Elapsed += NowTimer_Elapsed;
            _nowTimer.Enabled = true;
            _nowTimer.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            _nowTimer.Start();
            lbDoctorName.Text = ConfigHelper.LoginName.Trim();
            if (ConfigHelper.IsAdmin)
            {
                btnDoctorInfos.Visible = true;
            }
            _openBlood = new Task(OpenBloodSport);
            _openBlood.Start();

            _getTask = new Task(GetToken);
            _getTask.Start();

            panelFill.Controls.Clear();
            var pif = new PatientInfoForm(null) { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(pif);
            pif.Dock = DockStyle.Fill;
            pif.Show();

            PaintImage();

        }
        private void NowTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
          lbTime.Invoke(new MethodInvoker(() => lbTime.Text =DateTime.Now.ToString("HH:mm:ss"))) ;   
        }

        /// <summary>
        /// 打开小窝牛
        /// </summary>
        private void OpenBloodSport()
        {
            bool isOpen = true;
            while (isOpen)
            {
                try
                {
                    if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComBluetooth))
                    {
                        isOpen = SerialPortClass.CreateInstance().ReadComPort_Bluetooth(SerialPortClass.CreateInstance().ComBluetooth);
                    }
                    if (isOpen)
                    {
                        SerialPortClass.CreateInstance().StartThread();
                        isOpen = false;
                    }
                }
                catch (Exception ex)
                {
                    WatchDog.Write(@"打开小蜗牛：", ex);
                }

                Thread.Sleep(3000);
            }
        }
        /// <summary>
        /// 获取远程申请验证token
        /// </summary>
        private void GetToken()
        {
            while (null == ConfigHelper.Cvur)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(ConfigHelper.UrlDistanceString + "/token");
                    request.Method = "post";
                    request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                    var stream = request.GetRequestStream();
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("grant_type=password&username=" + ConfigHelper.UrlUserName + "&password=" +
                                     ConfigHelper.UrlPassWord);
                        writer.Flush();
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    string strjson = CommonRemoteApplication.GetResponseString(response);
                    ConfigHelper.Cvur = JsonConvert.DeserializeObject<CommonVerifyUrlResult>(strjson);

                }
                catch (Exception ex)
                {
                    WatchDog.Write(@" 获取远程申请验证token：", ex);
                }
            }
        }

        /// <summary>
        /// 基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxiAfter;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var pif = new PatientInfoForm(null) { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(pif);
            pif.Dock = DockStyle.Fill;
            pif.Show();
        }
        /// <summary>
        /// 健康信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatientInfos_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankangAfter;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var pmf = new PatientManageFrm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(pmf);
            pmf.Dock = DockStyle.Fill;
            pmf.Show();
        }
        /// <summary>
        /// 心电信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEcg_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindianAfter;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var ef = new EcgForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(ef);
            ef.Dock = DockStyle.Fill;
            ef.Show();
        }
        /// <summary>
        /// 血压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMmhg_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueyaAfter;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var bpf = new BloodPressureForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(bpf);
            bpf.Dock = DockStyle.Fill;
            bpf.Show();
        }
        /// <summary>
        /// 血氧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpo2_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyangAfter;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;


            panelFill.Controls.Clear();
            var sf = new BloodOxygenForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(sf);
            sf.Dock = DockStyle.Fill;
            sf.Show();
        }
        /// <summary>
        /// 体温
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnC_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwenAfter;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var tf = new TemperatureForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(tf);
            tf.Dock = DockStyle.Fill;
            tf.Show();
        }
        /// <summary>
        /// 血糖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMmol_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetangAfter;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            if (!string.IsNullOrEmpty(SerialPortClass.CreateInstance().ComBloodString))
            {
                SerialPortClass.CreateInstance().ReadComPort_Blood(SerialPortClass.CreateInstance().ComBloodString);
            }
            var bf = new BloodSugarForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(bf);
            bf.Dock = DockStyle.Fill;
            bf.Show();
        }
        /// <summary>
        /// 尿常规
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrine_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochangguiAfter;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var uf = new UrineForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(uf);
            uf.Dock = DockStyle.Fill;
            uf.Show();
        }
        /// <summary>
        /// 医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctorInfos_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yishengAfter;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitong;

            panelFill.Controls.Clear();
            var dmf = new DoctorManageForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(dmf);
            dmf.Dock = DockStyle.Fill;
            dmf.Show();
        }
        /// <summary>
        /// 系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemInfo_Click(object sender, EventArgs e)
        {
            btnInfo.BackgroundImage = Properties.Resources.xinxi;
            btnPatientInfos.BackgroundImage = Properties.Resources.jiankuang;
            btnEcg.BackgroundImage = Properties.Resources.xindian;
            btnMmhg.BackgroundImage = Properties.Resources.xueya;
            btnSpo2.BackgroundImage = Properties.Resources.xueyang;
            btnC.BackgroundImage = Properties.Resources.tiwen;
            btnMmol.BackgroundImage = Properties.Resources.xuetang;
            btnUrine.BackgroundImage = Properties.Resources.niaochanggui;
            btnDoctorInfos.BackgroundImage = Properties.Resources.yisheng;
            btnSystemInfo.BackgroundImage = Properties.Resources.xitongAfter;

            panelFill.Controls.Clear();
            var sform = new SystemSetForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panelFill.Controls.Add(sform);
            sform.Dock = DockStyle.Fill;
            sform.Show();
        }

        /// <summary>
        /// 圆角图片
        /// </summary>
        private void PaintImage()
        {
            //string filename =Properties.Resources.photo+ ".png";//如果不是png类型，须转换 

            var bitmap = new Bitmap(Properties.Resources.photo);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if ((x - 50) * (x - 50) + (y - 50) * (y - 50) > 50 * 50)
                    {

                        bitmap.SetPixel(x, y, Color.FromArgb(0, 255, 255, 255));
                    }
                }
            }
            Graphics g = CreateGraphics();

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawImage(bitmap, new Point(50, 50));

            g.DrawEllipse(new Pen(Color.FromArgb(46, 46, 46)), 50, 50, 100, 100);

            g.Dispose();

            //bitmap.Save(Application.StartupPath + "he.png");
            pBoxRightLogo.Image = bitmap;
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDoctorName_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);//临时用
        }

    }
}
