using System.Drawing;
using CommonProj;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class EcgForm : Form
    {
        List<string> _listPort = new List<string>();//端口列表
        public EcgForm()
        {
            InitializeComponent();
            txtBoxEcgId.Text = ConfigHelper.IP;
        }

        private void btnEcgStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfigHelper.PatientId))
            {
                CaiJi();
            }
            else
            {
                XtraMessageBox.Show(@"请先添加基本信息，再开始心电检测！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void CaiJi()
        {
            _listPort = Program.GetHljwComs();//获取端口Port
            bool isOk=false;
            if (_listPort.Count == 2)
            {
                try
                {
                    WatchDog.WriteMsg(DateTime.Now + "==开始初始化滤波：" + (ConfigHelper.BASE_HZ | ConfigHelper.MC_HZ | ConfigHelper.AC_HZ | ConfigHelper.LP_HZ));
                    serialPortOption.CreateInstance().filterPara_Init(ConfigHelper.BASE_HZ | ConfigHelper.MC_HZ | ConfigHelper.AC_HZ | ConfigHelper.LP_HZ);//初始化滤波
                    WatchDog.WriteMsg(DateTime.Now + "==结束初始化滤波：");
                    serialPortOption.CreateInstance().IsClear = true;// 一个患者结束心电数据采集后，清理临时数据
                    serialPortOption.CreateInstance().IniserialPortOption();
                    serialPortOption.CreateInstance().StartEcgDataReadThread();//启动数据读取线程
                    isOk = serialPortOption.CreateInstance().writeStartAD_Command();//下发AD采集命令
                    WatchDog.WriteMsg(DateTime.Now + "==点击采集按钮结束：");
                }
                catch (Exception ex)
                {
                    WatchDog.WriteMsg("设备异常3" + ex.StackTrace);
                    XtraMessageBox.Show("设备异常，请您按以下提示进行操作:\r\n\r\n①请退出系统，先插入设备，再打开系统\r\n\r\n②如果第①条操作不成功，请您退出系统以后，重新插拔一下设备，然后再打开系统\r\n\r\n③如果第②条操作不成功，请重新启动您的电脑，即可恢复\r\n\r\n④如果以上措施均不成功，请更换USB的插入口，再进行以上操作\r\n\r\n⑤如果以上4条还不能解决，请联系懿加乐通信科技（北京）有限公司技术支持：400-010-2568", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (isOk)
            {
                string ptientId = ConfigHelper.PatientId;
                string patientName = ConfigHelper.PatientName;
                string patientGender = ConfigHelper.PatientGender;
                string patientAge = ConfigHelper.PatientAge;
                var egf = new EcgGatherFrm(ptientId, patientName, patientGender, patientAge) {TopMost = true,FormBorderStyle=FormBorderStyle.None};
                egf.Show();
                WatchDog.WriteMsg(DateTime.Now + "==采集患者心电数据：" + patientName + "&&PtientId" + ptientId);
            }
            else
            {
                WatchDog.WriteMsg(DateTime.Now + "==下发停止命令失败返回值为false：");
            }

        }
        /// <summary>
        /// 心电采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEcgStart_MouseDown(object sender, MouseEventArgs e)
        {
            btnEcgStart.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 心电采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEcgStart_MouseUp(object sender, MouseEventArgs e)
        {
            btnEcgStart.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
