using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CommonProj;

namespace EcgViewPro
{
    public partial class EcgGatherFrm : Form
    {
        readonly SqliteOptions _sqlite = new SqliteOptions();
        readonly string _patientId = string.Empty;
        readonly string _wardshipId = string.Empty;
        int _t;//采集波形的秒数
        bool _canClose = true;
        string _beginCollectTime = string.Empty;//开始采集心电时的起始时间
        string _endCollectTime = string.Empty;//开始采集心电时的结束时间
        int _caiJsj = 12;
        string _isQiBo = "0";//0表示正常，1表起搏
        Dictionary<int, List<float>> _ecgDataDicAfterFilter = new Dictionary<int, List<float>>();//滤波后的数据都存在这个字典中
        public Color EcgColor = Color.Lime;//绿色
    
        int _mouseMoveCount;
        bool _isExpection = true;
        public USB EzUsb = new USB();//usb设备监测类
        readonly EcgAnalisisParameters _eap = new EcgAnalisisParameters();
        readonly System.Timers.Timer _tecg = new System.Timers.Timer(600000);//10分钟执行一次
        string _filter = string.Empty;
        private const int LeadDateTime = 0;
        private const int LeadCaiSj = 0;
        private const int RecordSecond = 8;
        byte[] _commandbyte = new byte[6];
        int _paceCount = 0;//起搏信号个数
        int _totPaceCount = 0;
        private const string Dataperlead = "3000,3000,3000,";

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public EcgGatherFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="patientIdStr"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="age"></param>
        public EcgGatherFrm(string patientIdStr,string name,string gender,string age )
        {
            InitializeComponent();
            _wardshipId = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _patientId = patientIdStr;
            lb_Name.Text=name;
            lb_Sex.Text= gender;
            lb_Age.Text=age;
            //*********************************************************************************************************
            serialPortOption.CreateInstance().isRecord = true;//设置数据为可以接收到内存并显示
            //*********************************************************************************************************

        }
        //yangwei add code 4 begin
        //Graphics _memG;
        Bitmap _bmp;
        public void OnData(int[] data)
        {
            if (pictureEdit1.Width < 1 || pictureEdit1.Height < 1)
            {
                _rtPlayer.Reset();
                return;
            }
            var r = new Rectangle(4, 2, pictureEdit1.Width - 6, pictureEdit1.Height - 4);

            if (_bmp == null)
            {
                _bmp = new Bitmap(r.Width, r.Height);
            }
            Graphics memG = Graphics.FromImage(_bmp);
            _rtPlayer.PaintOffset(memG, r, data);
            if (pictureEdit1 == null)
            {
                return;
            }
            Graphics g = pictureEdit1.CreateGraphics();
            g.DrawImage(_bmp, 0, 0);
            g.Dispose();
            memG.Dispose();
        }

        RtWave _rtPlayer;
        //yangwei add code 4 end
        /// <summary>
        /// /拦截双击标题栏、移动窗体的系统消息
        /// </summary>
        /// <param name="m"></param>
        //protected override void WndProc(ref Message m)
        //{
        //    //拦截双击标题栏、移动窗体的系统消息
        //    if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
        //    {
        //        base.WndProc(ref m);
        //    }
        //}
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EcgGather_Frm_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.AllPaintingInWmPaint, true);
       
            _tecg.Elapsed += StartClearEcg;
            _tecg.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            _tecg.Enabled = true;
            _tecg.Start();
            EzUsb.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 3));

            serialPortOption.CreateInstance().PaperSpeed = 25.0;//走速
            serialPortOption.CreateInstance().Amplitude = 10.0;//增益
          
            CheckForIllegalCrossThreadCalls = false;
            //yangwei add code 3 start
            _rtPlayer = new RtWave();
            serialPortOption._instance._eventCallOnData += OnData;
            //yangwei add code 3 end
        }
        /// <summary>
        /// 自动检测E100设备插拔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void USBEventHandler(Object sender, EventArrivedEventArgs e)
        {
            bool isClose = false;
            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                //设备插入
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                //设备拔出
            }
            foreach (USBControllerDevice device in USB.WhoUSBControllerDevice(e))
            {
                string strUsb = device.Dependent.Replace("\\", "").Replace("&", "").ToUpper().Substring(0, 24);
                //WatchDog.WriteMsg(DateTime.Now.ToString()+"==设备ID："+str_usb);
                if (strUsb == "USBVID_03EBPID_6133MI_00")//USBVID_03EBPID_6133MI_007755BC1500000设备ID号
                {
                    _isExpection = false;
                    serialPortOption.CreateInstance().IsExitExpection = true;
                    EzUsb.RemoveUSBEventWatcher();
                    isClose = true;
                }
            }
            if (isClose)
            {
                Close();
            }
        }
        /// <summary>
        /// 10分自动清理数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClearEcg(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke((Action)delegate()
            {
                if (_mouseMoveCount == 0)
                {
                    ClearMinddleEcgData();
                }
                else
                {
                    _mouseMoveCount = 0;
                }
            });
        }
     
        /// <summary>
        /// 下发AD停止命令时，出现的异常处理
        /// </summary>
        public void writeStopAD_Command_Exception()
        {
            byte[] data = new byte[6];
            //启动AD指令  AA 00 02 A1 09 FF    停止AD：AA 00 02 A2 0A FF 返回值：170 00 02 187 19 255==AA 00 02 BB 13 FF
            data[0] = Convert.ToByte("CC", 16);
            data[1] = Convert.ToByte("A1", 16);
            data[2] = Convert.ToByte("00", 16);
            data[3] = Convert.ToByte("00", 16);
            data[4] = Convert.ToByte("00", 16);
            data[5] = Convert.ToByte("DD", 16);

            serialPortOption.CreateInstance().command_Write_SerialPort.Write(data, 0, data.Length);
            _commandbyte = new byte[6];
            Thread.Sleep(600);
            if (serialPortOption.CreateInstance().command_Write_SerialPort.BytesToRead == 6)
            {
                serialPortOption.CreateInstance().command_Write_SerialPort.Read(_commandbyte, 0, _commandbyte.Length);
                serialPortOption.CreateInstance().command_Write_SerialPort.DiscardInBuffer();//丢弃来自串行驱动程序的接收缓冲区的数据。
             
            }
        }
        /// <summary>
        /// 停止心电采集
        /// </summary>
        private void StopRecordEcgData()
        {
            ConfigHelper.IsRecordEcg = false;
            EcgColor = Color.Lime;//绿色

            _endCollectTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            toolSbtn_Repeat.Enabled = false;//重采

            toolSbtn_Ecg.Enabled = true;//心电测量

            lb_RecordTime.Visible = false;//停止倒计时
            lb_RecordTime.Text = "";

            SaveEcgData();
    
            pace_makingOptions.Pacing_signal_list.Clear();
           
        }
        /// <summary>
        /// 一个患者结束心电数据采集后，清理临时数据
        /// </summary>
        public void ClearMinddleEcgData()
        {
            serialPortOption.CreateInstance().IsClear = true;
            serialPortOption.CreateInstance().FilterIndex = 0;
            serialPortOption.CreateInstance().drawIndex = 0;
 
           
            pace_makingOptions.Pacing_signal_list.Clear();//起搏数组
            serialPortOption.CreateInstance().PaceLocs.Clear();//存储的起搏位置
            serialPortOption.CreateInstance().ecgData_realTimeAfterFilter.Clear();

        }
       
        //采集时间计时器
        private void timer_Record_Tick(object sender, EventArgs e)
        {
            _t++;
            int hours = 0;
            int mimuts = 0;
            int seconds = 0;
            seconds = _t % 60;
            mimuts = (_t / 60) % 60;
            hours = _t / 3600;
            if (_t >= 1)//大于2是因为采集10秒的数据会少2秒
            {
                int s = seconds - 2;
                if (s < 0)
                {
                    s = 0;
                }
                if (mimuts > 0 || hours > 0)
                {
                    s = seconds;
                }
            }
            if (_t > RecordSecond)
            {
                _canClose = true;//允许关闭

                lb_Title.Text = "";
            }
            else
            {
                _canClose = false;
            }

            if (_caiJsj > 0 && _t > 1)
            {
                lb_RecordTime.ForeColor = Color.LawnGreen;
                lb_RecordTime.Visible = true;
                lb_RecordTime.Text =@"记录倒计时："+ _caiJsj.ToString()+@"秒";
            }
            else
            {
                lb_RecordTime.Visible = false;
                lb_RecordTime.Text = "";
            }

            //采集时间达到默认采集时间时停止采集
            if (_t == ConfigHelper.CaiSJ + 1)
            {
                AddApplationInfo();//添加患者和心电数据中间表
                StopRecordEcgData();//添加心电数据表
                Close();
            }
            if (_t > 1)
            {
                _caiJsj--;
            }
        }

        /// <summary>
        /// 添加患者和数据的中间表
        /// </summary>
        private void AddApplationInfo()
        {
            string sqlApp = "select * from Tb_Application where ApplicationID='"+ConfigHelper.AppId+"'";
            DataTable dt= _sqlite.ExcuteSqlite(sqlApp);
            if (null != dt && dt.Rows.Count == 0)
            {
                var lsp = new List<SQLiteParameter>();
                sqlApp = "Insert into [Tb_Application](ApplicationID,PatientID,wardshipId,InterpretationStatus) Values(@ApplicationID,@PatientID,@wardshipId,@InterpretationStatus)";
                lsp.Add(new SQLiteParameter("@ApplicationID", ConfigHelper.AppId));
                lsp.Add(new SQLiteParameter("@PatientID", _patientId));
                lsp.Add(new SQLiteParameter("@wardshipId", _wardshipId));
                lsp.Add(new SQLiteParameter("@InterpretationStatus", "未判读"));
                _sqlite.ExecuteSql(sqlApp, lsp.ToArray());
                lsp.Clear();
            }
        }
        /// <summary>
        /// 保存心电数据
        /// </summary>
        private void SaveEcgData()
        {
            _dCount++;
            var pm = new PermissionModel();
            for (int i = 1; i < pace_makingOptions.Pacing_signal_list.Count - 2; i++)
            {
                if (pace_makingOptions.Pacing_signal_list[i] == 1 && pace_makingOptions.Pacing_signal_list[i - 1] != 1)
                {
                    _paceCount++;
                }

                if (pace_makingOptions.Pacing_signal_list[i] == 1)
                {
                    _totPaceCount++;
                }
            }
            if (_paceCount > 0 && _totPaceCount > 0)
            {
                _isQiBo = "1";
            }
            _paceCount = 0;
            _totPaceCount = 0;
            try
            {
                _ecgDataDicAfterFilter = serialPortOption.CreateInstance().EcgData_Dic_AfterFilter;

            }
            catch
            {
                _ecgDataDicAfterFilter = serialPortOption.CreateInstance().EcgData_Dic;
            }
            int ecgCount = (_ecgDataDicAfterFilter.Count > 0 ? _ecgDataDicAfterFilter[0].Count : 0);
            try
            {
                for (int leadIndex = 0; leadIndex < 12; leadIndex++)
                {
                    var leadEcgData = new List<float>();
                    for (int i = 0; i < ecgCount; i++)
                    {
                        if (serialPortOption.CreateInstance().EcgData_Dic_AfterFilter.Count > 0 && i < _ecgDataDicAfterFilter[leadIndex].Count)
                        {
                            leadEcgData.Add(_ecgDataDicAfterFilter[leadIndex][i]);
                        }
                    }
                    pm.Add(leadIndex, leadEcgData);

                }
            }
            catch (Exception ex)
            {
              
            }
            byte[] hospitalTel = pm.Compress(pm.Dict);string ednPathDir = Application.StartupPath + "\\ECG_DATA_NEW";
            if (!Directory.Exists(ednPathDir))
            {
                Directory.CreateDirectory(ednPathDir);
            }
            try
            {
                var fs = new FileStream(ednPathDir + "\\" + ConfigHelper.AppId + "_0", FileMode.CreateNew, FileAccess.Write);
                var bw = new BinaryWriter(fs, Encoding.UTF8);
                bw.Write(hospitalTel);
                bw.Close();
                //fs.Close();
            }
            catch (Exception ex)
            {
            }
            _filter = "低通：75Hz";

            var pLocs = new StringBuilder();
            for (int k = 0; k < serialPortOption.CreateInstance().PaceLocs.Count; k++)
            {
                serialPortOption.CreateInstance().PaceLocs[k] = serialPortOption.CreateInstance().PaceLocs[k] + serialPortOption.CreateInstance().PaceOffset;
                if (serialPortOption.CreateInstance().PaceLocs[k] < 2500)
                {
                    serialPortOption.CreateInstance().PaceLocs.RemoveAt(k);
                }
                else
                {
                    pLocs.Append(serialPortOption.CreateInstance().PaceLocs[k] - 2500).Append(",");
                }
            }
            string strdel = "delete from data_packs where ApplicationID='" + ConfigHelper.AppId + "'";
            string strsql = "insert into data_packs (ApplicationID,beginTime,dataSizePerLead,EcgFilter,isLead,LeadEndTime,paceLocs) values ('" + ConfigHelper.AppId + "','" + _beginCollectTime + "','" + Dataperlead + "','" + _filter + "','0','" + _endCollectTime + "','" + pLocs.ToString().TrimEnd(',') + "') ";
            string strsqlUpdate = "update tb_patientinfo set IsQiBo='" + _isQiBo + "' where PatientID='" + _patientId + "'";
            //执行SQL语句，将数据插入表中
            try
            {
                if (hospitalTel.Length > 0)
                {
                    _sqlite.SqliteDelete(strdel);
                    _sqlite.SqliteAdd(strsql);
                    _sqlite.SqliteUpdate(strsqlUpdate);
                }
                serialPortOption.CreateInstance().PaceLocs.Clear();
            }
            catch (Exception ex)
            {
               
            }
        }
        /// <summary>
        /// 心电测量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSbtn_Ecg_Click(object sender, EventArgs e)
        {
            toolSbtn_Ecg.BackgroundImage = Properties.Resources.cjStart;
            _mouseMoveCount++;
            try
            {
                _tecg.Enabled = false;
                _tecg.Stop();
                _tecg.Enabled = true;
                _tecg.Start();
                ConfigHelper.IsRecordEcg = true;
                EcgColor = Color.Lime;//浅绿
                ClearMinddleEcgData();// 一个患者结束心电数据采集后，清理临时数据 位置不可以移动
                toolSbtn_Repeat.Enabled = true;//重新采集
                _caiJsj = ConfigHelper.CaiSJ;
                timer_Record.Enabled = true;
                toolSbtn_Ecg.Enabled = false;_beginCollectTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lb_RecordTime.Text = string.Empty;
            }
            catch
            {
                //WatchDog.Fatal("记录波形失败：", ex);
            }
        }
      
        /// <summary>
        /// 重新采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSbtn_Repeat_Click(object sender, EventArgs e)
        {
            _mouseMoveCount++;
            ClearMinddleEcgData();// 一个患者结束心电数据采集后，清理临时数据
            _beginCollectTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _t = LeadDateTime;
            _caiJsj = LeadCaiSj;
        }

        /// <summary>
        /// 实时心率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_BPM_Tick(object sender, EventArgs e)
        {
            //计算实时的心率
            if (serialPortOption.CreateInstance().ecgData_realTimeAfterFilter.Count > 0)
            {
                int resulteArray = _eap.AnalisisHeartRate(serialPortOption.CreateInstance().ecgData_realTimeAfterFilter);
                if (resulteArray > 0)
                {

                    if (resulteArray > 100)
                    {
                        if (resulteArray.ToString() != lb_BPM.Text)
                        {
                            lb_BPM.Text = resulteArray.ToString();
                        }
                    }
                    if (resulteArray < 60)
                    {
                        if (resulteArray.ToString()  != lb_BPM.Text)
                        {
                            lb_BPM.Text = resulteArray.ToString();
                        }
                    }
                 
                    if (resulteArray <= 100 && resulteArray >= 60)
                    {
                        if (resulteArray.ToString() != lb_BPM.Text)
                        {
                            lb_BPM.Text = resulteArray.ToString();
                        }
                    }
                }
                else
                {
                    if (!Equals(@"——", lb_BPM.Text))
                    {
                        lb_BPM.Text = @"——";
                    }
                }
                if (serialPortOption.CreateInstance().LeadState != lbBPMTab.Text && !string.IsNullOrEmpty(serialPortOption.CreateInstance().LeadState))
                {
                    lbBPMTab.Visible = true;
                    if (serialPortOption.CreateInstance().LeadState == "导联正常")
                    {
                        lbBPMTab.ForeColor = Color.LawnGreen;
                        lbBPMTab.Text = serialPortOption.CreateInstance().LeadState;
                    }
                    else
                    {
                        lbBPMTab.ForeColor = Color.FromArgb(242, 78, 66);
                        lbBPMTab.Text = serialPortOption.CreateInstance().LeadState + "导联脱落";
                    }
                }

            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 重新采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSbtn_Repeat_MouseDown(object sender, MouseEventArgs e)
        {
            toolSbtn_Repeat.BackgroundImage = Properties.Resources.chongcaiAfter;
        }
        /// <summary>
        /// 重新采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSbtn_Repeat_MouseUp(object sender, MouseEventArgs e)
        {
            toolSbtn_Repeat.BackgroundImage = Properties.Resources.chongcai;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_MouseDown(object sender, MouseEventArgs e)
        {
            btnExit.BackgroundImage = Properties.Resources.exitAfter;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_MouseUp(object sender, MouseEventArgs e)
        {
            btnExit.BackgroundImage = Properties.Resources.exit;
        }

        private void EcgGatherFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_canClose)
            {
                lb_Title.Visible = true;
                e.Cancel = true;
            }
            else
            {
                serialPortOption._instance._eventCallOnData -= OnData;
                pace_makingOptions.Pacing_signal_list.Clear();
                serialPortOption.CreateInstance().PaceLocs.Clear();
                serialPortOption.CreateInstance().FilterResulte = 0;
                if (_isExpection)
                {
                    serialPortOption.CreateInstance().drawIndex = 0;

                    writeStopAD_Command_Exception();//下发停止命令
                    serialPortOption.CreateInstance().command_Write_SerialPort.Close();
                    serialPortOption.CreateInstance().ccgData_Read_SerialPort.Close();
                    serialPortOption.CreateInstance().StopEcgDataReadThread();


                    serialPortOption.CreateInstance().bufferBytesLength = 0;
                    CommonProj.ConfigHelper.IsRecordEcg = false;
                    EzUsb.RemoveUSBEventWatcher();
                }
                else
                {
                    serialPortOption.CreateInstance().drawIndex = 0;
                    serialPortOption.CreateInstance().StopEcgDataReadThread();
                    serialPortOption.CreateInstance().bufferBytesLength = 0;
                    CommonProj.ConfigHelper.IsRecordEcg = false;

                }
                serialPortOption.CreateInstance().ecgData_realTimeAfterFilter.Clear();

                _tecg.Enabled = false;
                _tecg.Stop();
                _beginCollectTime = string.Empty;
                _endCollectTime = string.Empty;
            }
        }
    }
}
