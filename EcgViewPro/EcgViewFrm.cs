using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using CommonProj;
using System.Linq;
using DevExpress.XtraEditors;

namespace EcgViewPro
{

 
    public partial class EcgViewFrm : Form
    {

        public class NativeMethods
        {
            [DllImport("DiagDllProj.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            private static extern int DiagnoseAn(float[] pSrc, int dataCountPerLead, int leadCount, short sampleRate, int annoIndex, string leadName, int[] pacArr, int pacCount, int age, byte[] pOut, int outSize);

            public static int IntDiagnoseAn(float[] pSrc, int dataCountPerLead, int leadCount, short sampleRate, int annoIndex, string leadName, int[] pacArr, int pacCount, int age, byte[] pOut, int outSize)
            {
                return DiagnoseAn(pSrc,dataCountPerLead, leadCount,  sampleRate,  annoIndex,  leadName,  pacArr,  pacCount,  age, pOut,  outSize);
            }
        }

        public EventHandler FormStateEvent;
        string _reportTitleContent = string.Empty;
        readonly string _patientId = string.Empty;
        readonly string _patientName = string.Empty;
        readonly string _gender = string.Empty;
        string _age = string.Empty;
        readonly string _idStr = string.Empty;
        readonly string _applicationId = string.Empty;
        DateTime _currentTime;
        DateTime _beginTime;
        Bitmap _sourceCegBmp;
        Bitmap _bp;//滚轴专用图片
        string _ps = "25mm/s";//打印时的走速
        string _amp = "10mm/mV";//打印时的振幅
        Image _electronicSignature;//电子签名
        readonly Image _electronicSignatureRemote = null;//电子签名
        readonly string _isQiBo = "0";
        string _localAddress = string.Empty;//本地医院地址
        string _remoteAddress = string.Empty;//网络地址
        //存放心电数据的字典 按照 每导联顺序进行存储
        //存放心电数据的原始数据
        int _filterIndex;//滤波时 此标志  指示从数组中 哪一个位置开始滤波
        Dictionary<int, List<float>> _ecgDataDicAfterFilter = new Dictionary<int, List<float>>();//滤波后的数据都存在这个字典中

        readonly DataTable _dt1;
        private const bool IsLeader = false; //判读是否为十八或十五导模式
        public string LeaderType = string.Empty;//导联类别
        private const string StrIsLead = "0";
        readonly string _applicationInterpretationStatus = string.Empty;
        public string ErrorLead = string.Empty;//导联纠错状态 -1表示正常，其他表示纠错
        public List<int> PLocsView = new List<int>();

        /// <summary>
        /// 分析诊断的XML结果
        /// </summary>
        string[] _diagParas = new string[9];

        readonly string _pdStatus = string.Empty;
        readonly bool _isFastPrint;
        readonly SqliteOptions _sqHelper = new SqliteOptions();
        string _diagnosisText = string.Empty;//存改变后的诊断文本，用于提示
        readonly bool _isApped = true;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pmd">
        /// </param>
        /// <param name="isPrint">是否为快速打印</param>
        /// <param name="strQiBo"></param>
        /// <param name="isApped"></param>
        /// <param name="errorLead"></param>
        public EcgViewFrm(PatientMd pmd, bool isPrint, string strQiBo, bool isApped, string errorLead)
        {
            InitializeComponent();

            lb_Time.Parent = pictureEdit3;

            _patientId = pmd.PatientID;
            _patientName = pmd.PatientName;
            _gender = pmd.Gender;
            _age = pmd.AgeStart;
            _idStr = pmd.P_Id;
            _pdStatus = pmd.Pdstatus;
            label2.Text = _patientName;
            label13.Text = _gender;
            _isQiBo = strQiBo;

            #region  尿常规、血糖、血氧、血压、体温

            lb_LEU.Text = pmd.LEU;
            lb_BIL.Text = pmd.BIL;
            lb_BLD.Text = pmd.BLD;
            lb_DIA.Text = pmd.DIA + @" mmHg";
            lb_GLU.Text = pmd.GLU;
            lb_KET.Text = pmd.KET;
            lb_Mmol.Text = pmd.Mmol + @" mmol/L";
            lb_NIT.Text = pmd.NIT;
            lb_PH.Text = pmd.PH;
            lb_PRO.Text = pmd.PRO;
            lb_SG.Text = pmd.SG;
            lb_Spo2.Text = pmd.Spo2 + @" %";
            lb_SYS.Text = pmd.SYS + @" mmHg";
            lb_TEMP.Text = pmd.Temperature + @" ℃";
            lb_UBG.Text = pmd.UBG;
            lb_VC.Text = pmd.VC;

            #endregion

            label19.Text = ((_age == @"0") ? " " : (_age + @" 岁"));

            _isApped = isApped;
            _applicationId = pmd.AppId;
            ErrorLead = errorLead;
            _dt1 = new DataTable();

            string sqlite =
                "SELECT  beginTime,LeadEndTime,LeadType,InterpretationStatus FROM data_packs inner join tb_Application on data_packs.ApplicationID=tb_Application.ApplicationID  WHERE  data_packs.applicationID='" +
                _applicationId + "' and isLead='" + StrIsLead + "' order by beginTime asc limit 1 offset 0";
            DataTable dtBeginTime = _sqHelper.ExcuteSqlite(sqlite);
            if (dtBeginTime.Rows.Count == 1)
            {
                _applicationInterpretationStatus = dtBeginTime.Rows[0]["InterpretationStatus"].ToString();

                _currentTime = Convert.ToDateTime(dtBeginTime.Rows[0]["beginTime"].ToString().Trim());

                _beginTime = _currentTime;

            }
            sqlite = "select * from data_packs WHERE applicationID='" + _applicationId + "' and isLead='" + StrIsLead +
                     "' order by beginTime asc";
            _dt1 = _sqHelper.ExcuteSqlite(sqlite);
            if (_dt1.Rows.Count > 0)
            {

                if (_dt1.Rows[0]["pureData"] == DBNull.Value)
                {
                    string ednPathDir = Application.StartupPath + "\\ECG_DATA_NEW" + "\\" + _applicationId + "_" +
                                        StrIsLead;
                    if (File.Exists(ednPathDir))
                    {
                        var fs = new FileStream(ednPathDir,
                            FileMode.Open,
                            FileAccess.Read);
                        var br = new BinaryReader(fs, Encoding.UTF8);
                        _dt1.Rows[0]["pureData"] = br.ReadBytes((int) fs.Length);
                        br.Close();
                        //fs.Close();
                    }
                }


                if (!string.IsNullOrEmpty(_dt1.Rows[0]["paceLocs"].ToString()))
                {
                    string[] pL = _dt1.Rows[0]["paceLocs"].ToString().Split(',');
                    foreach (string t in pL)
                    {
                        PLocsView.Add(Convert.ToInt32(t));
                    }
                }
            }
            _ecgDataDicAfterFilter.Clear();

            GetEcgData(_dt1); //获取原始心电数据

            if (_ecgDataDicAfterFilter.Count > 0)
            {
                hScrollBar_Lead.Maximum = _ecgDataDicAfterFilter[0].Count/1000;

                //hScrollBar_Lead.Maximum = GetMaximun(EcgData_Dic_AfterFilter[0].Count) / 1000;
                //if (hScrollBar_Lead.Maximum <= 0)
                //{
                //    hScrollBar_Lead.Maximum = 1;
                //}
                //shortLeadRemove = GetMaximun(EcgData_Dic_AfterFilter[0].Count) % 1000;
            }

            if (_applicationInterpretationStatus != "未判读" && _applicationInterpretationStatus != "已作废")
            {
                _isFastPrint = isPrint;
                BindSnapInfo(); // 加载患者心电图快照的时间
                if (isPrint)
                {
                    if (listBox1.Items.Count > 0)
                    {
                        EcgView_Frm_Load(null, null);
                    }
                    else
                    {
                        XtraMessageBox.Show(@"请添加参考记录，再做打印！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        // lblMsg.Text = "提示：" + "请添加参考记录，再做打印！";
                    }
                }
            }
            else
            {
                if (isPrint)
                {
                    XtraMessageBox.Show(@"请添加参考记录，再做打印！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //lblMsg.Text = "提示：" + "请添加参考记录，再做打印！！";
                }
            }
        }

        //重新加载数据

        private const double SamplingRate = 1000.0;
        private const int Dpi = 96; //一英寸的像素点个数
        private const double LenthPerInch = 25.4; //一英寸==25.4mm
        private const int LeadNameLenth = 14; //导联表压所占的长度

        /// <summary>
       /// 采样率1000Hz（赫兹）=1s=25mm/s ----> 96/25.4*25mm=94.488像素 相当于1s==94.488像素
       /// 毫米数＝（像素/DPI）*25.4
       ///  double PreSecond = Dpi / LenthPerInch * PaperSpeed;//每秒多少像素
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
       private int GetMaximun(int count)
       {
           double intervalPixCountPerPoint = (double.Parse(_paperSpeed.ToString()) / double.Parse(SamplingRate.ToString())) * (double.Parse(Dpi.ToString()) / LenthPerInch);//画布的每个像素多少个点
           int screenwith = pictureEdit3.Width / 2 - LeadNameLenth;//画布的半屏的宽度-导联表压所占的长度=半屏波形的长度
           int datacount = count;//数据总量
           int maxmun = (datacount - (int)(screenwith / intervalPixCountPerPoint));
           return maxmun;
       }

       private void BindSnapInfo()
        {
            listBox1.Items.Clear();
            string snapSql = "SELECT distinct ApplicationID,SnapshotTime,type FROM Tb_Snapshot WHERE applicationID='" + _applicationId + "' order by type Desc,SnapshotTime Desc";
           DataTable dtSnap = _sqHelper.ExcuteSqlite(snapSql);
           if (null != dtSnap)
           {
               for (int snapIndex = 0; snapIndex < dtSnap.Rows.Count; snapIndex++)
               {
                   listBox1.Items.Add(dtSnap.Rows[snapIndex]["SnapshotTime"].ToString());
               }
               if (listBox1.Items.Count == 0)
               {
                   删除选中记录ToolStripMenuItem.Visible = false;
               }
               else
               {
                   删除选中记录ToolStripMenuItem.Visible = true;
               }
           }
        }

       //[DllImport("DiagDllProj.dll",  CallingConvention = CallingConvention.Cdecl,CharSet=CharSet.Unicode)]
       //public static extern int DiagnoseAn(float[] pSrc, int dataCountPerLead, int leadCount, short sampleRate, int annoIndex, string leadName, int[] pacArr, int pacCount, int age, byte[] pOut, int outSize);
        /// <summary>
        /// 计算波形的参数
        /// </summary>
       private void AnalisisParameters()
       {
           var dictConvert = new Dictionary<int, List<float>>();
           Dictionary<int, List<float>> ecgDataDicType = _ecgDataDicAfterFilter;
           if (ecgDataDicType.Count == 0)
           {
               return;
           }
           dictConvert.Clear();
           int dicCount = ecgDataDicType[0].Count; //每一导联的总长度
           int cbFilterIndex = dicCount % 1000; //每两个时间点之间是数据点数
           if (dicCount / 1000 <= 12) //数据少于等于12秒
           {
               for (int d = 0; d < ecgDataDicType.Count; d++)
               {
                   for (int childIndex = cbFilterIndex; childIndex < dicCount; childIndex++)
                   {
                       if (dictConvert.ContainsKey(d))
                       {
                           dictConvert[d].Add(ecgDataDicType[d][childIndex]);
                       }
                       else
                       {
                           var f1 = new List<float>();

                           if (childIndex >= 0)
                           {
                               f1.Add(ecgDataDicType[d][childIndex]);
                               dictConvert.Add(d, f1);
                           }
                       }
                   }
               }
           }
           else //数据大于12秒
           {
               int datalength = (dicCount - 12000) / 1000; //算出数据大于12秒数据的长度单位s
               int index = 0;
               if (hScrollBar_Lead.Value <= datalength)
               {
                   index = hScrollBar_Lead.Value;
               }
               else
               {
                   index = datalength;

               }
               int startIndex = (index * (int)SamplingRate) + cbFilterIndex; //读取数据的开始位置
               int endIndex = dicCount;

               for (int d = 0; d < ecgDataDicType.Count; d++)
               {
                   for (int childIndex = startIndex; childIndex < endIndex; childIndex++)
                   {
                       if (dictConvert.ContainsKey(d))
                       {
                           dictConvert[d].Add(ecgDataDicType[d][childIndex]);
                       }
                       else
                       {
                           var f1 = new List<float>();

                           if (childIndex >= 0)
                           {
                               f1.Add(ecgDataDicType[d][childIndex]);
                               dictConvert.Add(d, f1);
                           }
                       }
                   }
               }
           }
           Dictionary<int, List<float>> resulteDic = dictConvert;
           int dataCountPerLead = resulteDic[0].Count;

           if (resulteDic.Count > 0)
           {
               var inParas = new float[resulteDic[0].Count * 12];
               int initIndex = 0;
               for (int i = 0; i < resulteDic[0].Count; i++)
               {
                   for (int b = 0; b < 12; b++)
                   {
                       inParas[initIndex] = resulteDic[b][i];
                       initIndex++;
                   }
               }
               const string leadList = "I,II,III,aVR,aVL,aVF,V1,V2,V3,V4,V5,V6";
               short samp = short.Parse("1000");
               var resulteXml = new byte[1024];

               if (string.IsNullOrEmpty(_age))
               {
                   _age = "0";
               }
               if (_isQiBo == "1")
               {
                   NativeMethods.IntDiagnoseAn(inParas, dataCountPerLead, 12, samp, 1, leadList, PLocsView.ToArray(), PLocsView.Count,
                       Convert.ToInt32(_age), resulteXml, 1024);
               }
               else
               {
                   NativeMethods.IntDiagnoseAn(inParas, dataCountPerLead, 12, samp, 1, leadList, null, 0, Convert.ToInt32(_age),
                       resulteXml, 1024);
               }
               string str = System.Text.Encoding.Default.GetString(resulteXml);
               if (str.Length > 0)
               {
                   _diagParas = str.Split('|');
               }


               EditedAnalisisData();
           }
       }


        /// <summary>
        /// 编辑过的参数分析
        /// </summary>
        public void EditedAnalisisData()
        {

            string sql = "select * from AutoDiagnosis where ApplicationID='" + _applicationId + "' and SnapshotTime='" +
                         _currentTime.ToString("s") + "'";

            DataTable dt = _sqHelper.ExcuteSqlite(sql);

            listBox1.SelectedItem = _currentTime.ToString();
            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                _diagParas[0] = dr["BMP"].ToString();
                ;
                _diagParas[1] = dr["P_R"].ToString();
                _diagParas[2] = dr["QRS"].ToString();
                string[] strs = dr["QT_QTC"].ToString().Split('/');
                _diagParas[3] = strs[0];
                _diagParas[4] = strs[1];
                _diagParas[5] = dr["QRSDZ"].ToString();
                string[] rs = dr["RV5_SV1"].ToString().Split('/');
                _diagParas[6] = rs[0];
                _diagParas[7] = rs[1];
            }
            else
            {

                if (_diagParas.Length == 9)
                {
                    label11.Text = _diagParas[1] + @"ms";
                    label17.Text = _diagParas[2] + @"ms";
                    label5.Text = _diagParas[3] + @"/" + _diagParas[4] + @"ms";
                    label9.Text = _diagParas[5] + @"°";
                    label15.Text = _diagParas[6].Trim('.') + @"/" + _diagParas[7].Trim('.') + @"mV";
                    label7.Text = _diagParas[0] + @"bpm";
                }
            }
            label2.Text = _patientName;
            label13.Text = _gender;
            label19.Text = ((_age == @"0") ? " " : (_age + @" 岁"));

            if (_diagParas.Length == 9)
            {
                label11.Text = _diagParas[1] + @"ms";
                label17.Text = _diagParas[2] + @"ms";
                label5.Text = _diagParas[3] + @"/" + _diagParas[4] + @"ms";
                label9.Text = _diagParas[5] + @"°";
                label15.Text = _diagParas[6].Trim('.') + @"/" + _diagParas[7].Trim('.') + @"mV";
                label7.Text = _diagParas[0] + @"bpm";
            }


            _diagParas[8] = _diagParas[8].Replace("\0", "").Trim().Replace("   ", ";").Replace(" ", ";") + ";";
            //自动诊断

            if (_isQiBo == "0")
            {
                _diagnosisText = _diagParas[8];

                richTextBox1.Clear();

                richTextBox1.AppendText(_diagParas[8]);
            }
            else
            {
                _diagnosisText = @"起搏心律;";
                richTextBox1.Clear();

                richTextBox1.AppendText(@"起搏心律;");

            }


            string snapSql = "SELECT * FROM Tb_Snapshot WHERE ApplicationID='" + _applicationId + "' limit 1 offset 0";

            DataTable dtSnap = _sqHelper.ExcuteSqlite(snapSql);

            if (dtSnap != null && dtSnap.Rows.Count > 0)
            {
                string dv =
                    _diagnosisText = dtSnap.Rows[0][0] != DBNull.Value ? dtSnap.Rows[0]["Diagnosis"].ToString() : "";
                richTextBox1.Text = !string.IsNullOrEmpty(dv) ? dv : _diagParas[8].Trim();
                if (!string.IsNullOrEmpty(dv))
                {
                    richTextBox1.Clear();

                    richTextBox1.AppendText(dv);
                }
                else
                {
                    richTextBox1.Clear();

                    richTextBox1.AppendText(_diagParas[8].Trim());
                }
            }

        }

        private void EcgView_Frm_Load(object sender, EventArgs e)
        {
            _localAddress = ConfigHelper.LOCAL_ADDRESS;
          
            LoadReportTitleContent(out _remoteAddress);//加载报告名称信息

            LoadActiveDoctor();//加载活动医生信息

            if (_pdStatus == "未判读" || _pdStatus == "已作废")
            {
                lb_Time.Text = _beginTime.AddSeconds((hScrollBar_Lead.Value)).ToString();
                BindSnapInfo();
            }
            else
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                    _currentTime = Convert.ToDateTime(listBox1.SelectedItem.ToString());
                    listBox1_Click(null, null);
                }
                else
                {
                    lb_Time.Text = _beginTime.AddSeconds((hScrollBar_Lead.Value)).ToString();
                }
            }
            WindowState = FormWindowState.Maximized;
      
            if (_isApped)
            {
                btnSave.Enabled = false;//保存
            }

            if (_isFastPrint)
            {
                //打印
                btn_Print_Click(null,null);
            }
            else
            {
                listBox1.Dock = DockStyle.Fill;
            }

            SaveIsAnalysisOrDiagnosis();


        }

        /// <summary>
        /// 加载报告名称信息
        /// </summary>
        private void LoadReportTitleContent(out string rptAddr)
        {
            var dtReportTitle = new DataTable();
            string title = rptAddr = string.Empty;
            if (ConfigHelper.DB_SIGN == 0)
            {
               
                    DataTable data = _sqHelper.ExcuteSqlite("SELECT ReportTitleName,FirstUser FROM Tb_ReportTitle where ApplicationID='" + _applicationId + "'");
                    if (data != null && data.Rows.Count > 0)
                    {
                        title = data.Rows[0][0].ToString();
                        rptAddr = data.Rows[0][1].ToString();//FirstUser已被用于远程的报告地址
                    }
            
                if (string.IsNullOrEmpty(title))
                {
                    dtReportTitle = _sqHelper.ExcuteSqlite("SELECT * FROM Tb_ReportTitle where ApplicationID is null");
                }
            }
          
            if (!string.IsNullOrEmpty(title))
            {
                _reportTitleContent = title;
            }
            else
            {
                if (dtReportTitle.Rows.Count > 0)
                {
                    _reportTitleContent = dtReportTitle.Rows[0]["ReportTitleName"].ToString().Trim();
                    rptAddr = dtReportTitle.Rows[0]["FirstUser"].ToString();//FirstUser已被用于远程的报告地址
                }
            }

            if (string.IsNullOrEmpty(_reportTitleContent))
            {
                _reportTitleContent = "个人健康信息综合报告";//HW-E100心电判读系统心电图报告
            }
        }
      
        //加载活动医生信息
       private void LoadActiveDoctor()
       {
           DataTable dtDoctorActive = _sqHelper.ExcuteSqlite("select DoctorName,DoctorDept,ElectronicSignature from tb_patientInfo inner join tb_doctor on DoctorID=tb_doctor.ID where PatientID='" + _patientId + "'");

           if (null != dtDoctorActive&&dtDoctorActive.Rows.Count > 0)
            {
                lbDoctorName.Text = dtDoctorActive.Rows[0]["DoctorName"].ToString();
                lbDoctorDept.Text = dtDoctorActive.Rows[0]["DoctorDept"].ToString();
                if (DBNull.Value != dtDoctorActive.Rows[0]["ElectronicSignature"])
                {
                    _electronicSignature = _sqHelper.GetImg((byte[])dtDoctorActive.Rows[0]["ElectronicSignature"]);
                }
                else
                {
                    _electronicSignature = null;
                }
            }
       }

        double _amplitude = 10.0;//振幅
        double _paperSpeed = 25.0; //走速
        double _calibrationVoltage = 2.0;
        private const double Coefficient = 1.02; //系数
        int _leadindexdata;


        //滚动条
        private void Paint_ALL_ECG_scroll(Graphics ecgGraphics)
        {
            _bp = new Bitmap(pictureEdit3.Width, pictureEdit3.Height);
            var arrylead = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            var eddNew = new EcgDataDrawNew();
            if (_ecgDataDicAfterFilter.Count == 0)
            {
                return;
            }
            eddNew.InitEcgParameter_Scroll(_bp, ecgGraphics, 12, _ecgDataDicAfterFilter, _ecgDataDicAfterFilter, 96,
                arrylead, _isQiBo); //96
            eddNew.Draw_EcgBackGroundGrid(); //背景小格
            SetAandP();

            _filterIndex = _ecgDataDicAfterFilter[0].Count - 7000 > 0? (_ecgDataDicAfterFilter[0].Count - 7000)/hScrollBar_Lead.Maximum: 0;

            _leadindexdata = (hScrollBar_Lead.Value)*_filterIndex;
            //4*3+1任意单长导模式
            eddNew.Draw_EcgWave_One_Scroll(_paperSpeed, _amplitude, 940, _leadindexdata);
            eddNew.Draw_CalibrationVoltage_And_LeadName_1(_calibrationVoltage*Coefficient, IsLeader, LeaderType); //绘制定标电压和导联名称
        }

        /// <summary>
        /// 设置增益和走速和定标电压
        /// </summary>
        private void SetAandP()
        {
            _paperSpeed = 25.0;
            _ps = "25mm/s";
            _amplitude = 10.0;
            _amp = "10mm/mV";
            _calibrationVoltage = 2.0;
        }


        readonly List<Bitmap> _bitArray = new List<Bitmap>();
        private const int PrintDpi = 300;
        Bitmap _ecgBitMap;
        string _printFilter = "低通：0Hz";

        /// <summary>
        ///心电报告
        /// </summary>
        public void GetEcgViewDataImage(Image img, string addr)
        {
            var eddNew = new EcgDataDrawNew();
            _bitArray.Clear();
            var leadinfo = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

            Dictionary<int, List<float>> ecgDataDicAfterFilterType = _ecgDataDicAfterFilter;
            string filter = _printFilter; // label23.Text;

            _ecgBitMap = new Bitmap((1090*PrintDpi)/96, (760*PrintDpi)/96);
            _ecgBitMap.SetResolution(PrintDpi, PrintDpi);

            eddNew.InitEcgParameter(_ecgBitMap, 12, _ecgDataDicAfterFilter, ecgDataDicAfterFilterType, PrintDpi,
                leadinfo, _isQiBo);



            //************************************************************************  
            var ecgInfoList = new string[28];
            ecgInfoList[0] = label1.Text + label2.Text;
            ecgInfoList[1] = label14.Text + label13.Text;
            ecgInfoList[2] = label20.Text + label19.Text;
            //EcgInfo_List[3] = label4.Text + label3.Text;
            ecgInfoList[4] = label12.Text + label11.Text;
            ecgInfoList[5] = label18.Text + label17.Text;
            ecgInfoList[6] = label6.Text + label5.Text;
            ecgInfoList[7] = label10.Text + label9.Text;
            ecgInfoList[8] = label16.Text + label15.Text;
            ecgInfoList[9] = label8.Text + label7.Text;
            ecgInfoList[10] = ""; // label27.Text + label26.Text;
            ecgInfoList[11] = ""; // label30.Text + lblBedNum.Text;
            ecgInfoList[12] = ""; // label31.Text + lblCaseID.Text.Trim();
            ecgInfoList[13] = "血压：" + lb_DIA.Text.Trim() + "/" + lb_SYS.Text.Trim();
            ecgInfoList[14] = "血氧：" + lb_Spo2.Text.Trim();
            ecgInfoList[15] = "血糖：" + lb_Mmol.Text.Trim();
            ecgInfoList[16] = "体温：" + lb_TEMP.Text.Trim();
            ecgInfoList[17] = "LEU：" + lb_LEU.Text.Trim();
            ecgInfoList[18] = "NIT：" + lb_NIT.Text.Trim();
            ecgInfoList[19] = "UBG：" + lb_UBG.Text.Trim();
            ecgInfoList[20] = "PRO：" + lb_PRO.Text.Trim();
            ecgInfoList[21] = "BLD：" + lb_BLD.Text.Trim();
            ecgInfoList[22] = "KET：" + lb_KET.Text.Trim();
            ecgInfoList[23] = "BIL：" + lb_BIL.Text.Trim();
            ecgInfoList[24] = "GLU：" + lb_GLU.Text.Trim();
            ecgInfoList[25] = "PH：" + lb_PH.Text.Trim();
            ecgInfoList[26] = "VC：" + lb_VC.Text.Trim();
            ecgInfoList[27] = "SG：" + lb_SG.Text.Trim();

            SetAandP(); //设置增益和走速

            string diagContent = richTextBox1.Text.Trim();
            string[] diagArray = diagContent.Split('\n');
            diagContent = string.Empty;
            for (int i = 0; i < diagArray.Length; i++)
            {
                diagContent += diagArray[i].Trim();
            }

            //if (EcgData_Dic_AfterFilter.Count > 0)
            //{
            //    FilterIndex =(int)SamplingRate;
            //}
            //else
            //{//    FilterIndex = 0;
            //}
            if (_ecgDataDicAfterFilter.Count > 0)
            {
                _filterIndex = _ecgDataDicAfterFilter[0].Count - 7000 > 0
                    ? (_ecgDataDicAfterFilter[0].Count - 7000)/hScrollBar_Lead.Maximum
                    : 0;
            }
            else
            {
                _filterIndex = 0;
            }
            _leadindexdata = (hScrollBar_Lead.Value)*_filterIndex;
            //4*3 II长导模式

            eddNew.Draw_ReportHeadInfo(_reportTitleContent, lbDoctorDept.Text.Trim(), _idStr);
            eddNew.Draw_EcgInfo(ecgInfoList, true); //Draw_EcgInfo_Diag
            eddNew.Draw_DiagInfo(diagContent, lbDoctorName.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd"), filter,
                _currentTime.ToString(), lbDoctorDept.Text.Trim(), _amp, _ps, img, addr, true);

            eddNew.Draw_EcgBackGroundGrid(30, 171, 0); //196

            eddNew.Draw_EcgWave_longOneLeadPrint(6, 1, _paperSpeed, _amplitude, SamplingRate, _leadindexdata,
                _leadindexdata); //绘制波形

            eddNew.Draw_CalibrationVoltage_And_LeadName_1(_calibrationVoltage*Coefficient, IsLeader, LeaderType);
                //绘制定标电压和导联名称



            _sourceCegBmp = _ecgBitMap;
        }

    
       private void pd1_PrintPage(object sender, PrintPageEventArgs e)
        {
            for (int i = 0; i < _bitArray.Count; i++)
            {
                e.Graphics.DrawImage(_bitArray[i], new Point(0, 0));
            }
            _bitArray.Clear();
        }

        private void EcgView_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (richTextBox1.Text.Trim() != _diagnosisText.Replace("\0", ""))
                {
                    if (DialogResult.Cancel == XtraMessageBox.Show(@"系统检测到您的诊断结论有改动或未添加到参考记录，您确定要退出吗？", @"提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (_ecgBitMap != null)
                    _ecgBitMap.Dispose();
                if (_sourceCegBmp != null)
                    _sourceCegBmp.Dispose();
                if (_bp != null)
                    _bp.Dispose();
                
                FormStateEvent(null, null);
            }
            catch
            {
            }

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                _currentTime = Convert.ToDateTime(listBox1.SelectedItem.ToString());
                var ts1 = new TimeSpan(_currentTime.Ticks);
                var ts2 = new TimeSpan(_beginTime.Ticks);
                var ts = ts1.Subtract(ts2).Duration();
                int secondCount = int.Parse(ts.TotalSeconds.ToString("0"));
                hScrollBar_Lead.Value = secondCount;

                _currentTime = _beginTime.AddSeconds((hScrollBar_Lead.Value));
                lb_Time.Text = _currentTime.ToString();
                pictureEdit3.Invalidate();

                string snapSql = "SELECT * FROM Tb_Snapshot WHERE ApplicationID='" + _applicationId + "' and SnapshotTime='" + _currentTime.ToString("s") + "' order by SnapshotTime Desc";

                DataTable dtSnap = _sqHelper.ExcuteSqlite(snapSql);
             
                if (dtSnap != null && dtSnap.Rows.Count > 0)
                {
                    string tmpStr = dtSnap.Rows[0][0] != DBNull.Value ? dtSnap.Rows[0]["Diagnosis"].ToString() : "";
                    for (int i = 1; i < dtSnap.Rows.Count; i++)
                    {
                        tmpStr += dtSnap.Rows[i]["Diagnosis"] + ";";
                    }
                    _diagnosisText = tmpStr;
                    richTextBox1.Clear();
                  
                    richTextBox1.AppendText(tmpStr);
                    lbDoctorName.Text = dtSnap.Rows[0]["Doctor"] != DBNull.Value ? dtSnap.Rows[0]["Doctor"].ToString() : "";
                    lbDoctorDept.Text = dtSnap.Rows[0]["Dept"] != DBNull.Value ? dtSnap.Rows[0]["Dept"].ToString() : "";
                    if (dtSnap.Rows[0]["type"] == DBNull.Value || dtSnap.Rows[0]["type"].ToString() == "")
                        richTextBox1.ReadOnly = false;
                    else
                        richTextBox1.ReadOnly = true;
                }
            }
            catch
            {
                //WatchDog.Error("参考记录错误：", ex);
            }

        }

        private void 删除选中记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    if (XtraMessageBox.Show(@"是否确定删除选中的参考记录？", @"删除提示：", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning) == DialogResult.OK)
                    {

                        if (!richTextBox1.ReadOnly)
                        {
                            DateTime shotTime = Convert.ToDateTime(listBox1.SelectedItem.ToString());
                            string delSql = "DELETE FROM Tb_Snapshot WHERE ApplicationID='" + _applicationId + "' AND SnapshotTime='" + shotTime.ToString("s") + "'";
                           
                         
                            _sqHelper.SqliteDelete(delSql);
                          
                            richTextBox1.Text = string.Empty;
                            lblMsg.Text = @"提示：";
                            BindSnapInfo();//绑定参考记录信息
                            if (listBox1.Items.Count > 0)
                            {
                                listBox1.SelectedIndex = 0;
                                listBox1_Click(null, null);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(@"非本地判读不能删除！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(@"未选中任何参考记录！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                XtraMessageBox.Show(@"您还没有添加任何参考记录，删除操作无效！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
      
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            string state = GetWardshipInterpStatus();
            if (state == @"未判读")
            {
                string udSql = "UPDATE Tb_Application set InterpretationStatus='已判读' WHERE applicationID='" + _applicationId + "'";
                if (ConfigHelper.DB_SIGN == 0)
                {
                    _sqHelper.SqliteUpdate(udSql);
                }
             
            }
            lblMsg.Text = @"提示：" + @"保存成功！";
        }


        /// <summary>
        /// 根据患者编号和合同号获取判读状态
        /// </summary>
        /// <returns></returns>
        private string GetWardshipInterpStatus()
        {
            var tbl = new DataTable();
            string sql = "select InterpretationStatus from Tb_Application where applicationID='" + _applicationId + "'";
            if (ConfigHelper.DB_SIGN == 0)
            {
                tbl = _sqHelper.ExcuteSqlite(sql);
            }
      
            if (tbl.Rows.Count > 0)
            {
                try
                {
                    return tbl.Rows[0][0].ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 保存配置到文件并调用参数识别
        /// </summary>
        private void SaveIsAnalysisOrDiagnosis()
        {
            string path = Application.StartupPath + "\\AnalysisShow.txt";
            if (File.Exists(path))
            {
                const string strAnalysis = "1";
                const string strDiagsis = "1";
                var sw = new StreamWriter(path, false);
                sw.Write(strAnalysis + "," + strDiagsis);
                sw.Close();
            }
            AnalisisParameters(); //计算心电波形的参数

        }

        //滚动条值改变事件
        private void hScrollBar_Lead_ValueChanged(object sender, EventArgs e)
        {
            if (_dt1.Rows.Count <= 0)
            {
                return;
            }
            _currentTime = _beginTime.AddSeconds((hScrollBar_Lead.Value));

            lb_Time.Text = _currentTime.ToString();

            pictureEdit3.Invalidate();

            if (listBox1.Items.Count > 1)
            {
                var dic = new Dictionary<string, double>();
                foreach (string it in listBox1.Items)
                {
                    DateTime t1 = Convert.ToDateTime(it);//到期时间
                    TimeSpan ts = _currentTime.Subtract(t1);
                    dic.Add(it, Math.Abs(ts.TotalMilliseconds));
                }

                KeyValuePair<string, double> kvp = dic.OrderByDescending(c => c.Value).LastOrDefault();

                string snapSql = "SELECT * FROM Tb_Snapshot WHERE ApplicationID='" + _applicationId + "' and SnapshotTime='" + Convert.ToDateTime(kvp.Key).ToString("s") + "' order by SnapshotTime Desc";

                DataTable dtSnap = _sqHelper.ExcuteSqlite(snapSql);
              
                if (dtSnap != null && dtSnap.Rows.Count > 0)
                {
                    string tmpStr = dtSnap.Rows[0][0] != DBNull.Value ? dtSnap.Rows[0]["Diagnosis"].ToString() : "";
                    for (int i = 1; i < dtSnap.Rows.Count; i++)
                    {
                        tmpStr += dtSnap.Rows[i]["Diagnosis"] + ";";
                    }
                    _diagnosisText = tmpStr;
                    richTextBox1.Clear();
                    
                    richTextBox1.AppendText(tmpStr);
                    lbDoctorName.Text = dtSnap.Rows[0]["Doctor"] != DBNull.Value ? dtSnap.Rows[0]["Doctor"].ToString() : "";
                    lbDoctorDept.Text = dtSnap.Rows[0]["Dept"] != DBNull.Value ? dtSnap.Rows[0]["Dept"].ToString() : "";
                    if (dtSnap.Rows[0]["type"] == DBNull.Value || dtSnap.Rows[0]["type"].ToString() == "")
                        richTextBox1.ReadOnly = false;
                    else
                        richTextBox1.ReadOnly = true;
                }
            }
        }
        private void hScrollBar_Lead_MouseEnter(object sender, EventArgs e)
        {
            hScrollBar_Lead.Focus();
        }
        /// <summary>
        /// 获取原始心电数据
        /// </summary>
        private void GetEcgData(DataTable dt)
        {
            const int leadCount = 12;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _printFilter = dt.Rows[i]["EcgFilter"].ToString();
                if (dt.Rows[i]["pureData"] == DBNull.Value)
                {
                    return;
                }
                var pm = new PermissionModel();
                _ecgDataDicAfterFilter = pm.Decompress((byte[])dt.Rows[i]["pureData"], leadCount);

            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            string udSql = "UPDATE Tb_Application set InterpretationStatus='已打印' WHERE ApplicationID='" + _applicationId + "'";
            if (ConfigHelper.DB_SIGN == 0)
            {
                _sqHelper.SqliteUpdate(udSql);
            }


            if (_ecgDataDicAfterFilter.Count <= 0)
            {
                XtraMessageBox.Show(@"未发现任何心电数据不能进行打印！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (_isFastPrint)
            {
                WatchDog.WriteMsg(DateTime.Now + @"快速打印患者：" + label2.Text);
            }
            else
            {
                WatchDog.WriteMsg(DateTime.Now + @"普通打印患者：" + label2.Text);

            }

            Image image = richTextBox1.ReadOnly ? _electronicSignatureRemote : _electronicSignature;
            string address;
            if (richTextBox1.ReadOnly)
            {
                address = _remoteAddress;
            }
            else
            {
                address = _localAddress;
            }
            int tempValue = ConfigHelper.PrintSampleRate;
            if (_isQiBo == "1")
            {
                ConfigHelper.PrintSampleRate = 1000;
            }
            GetEcgViewDataImage(image, address);

            ConfigHelper.PrintSampleRate = tempValue;
            _bitArray.Add(_sourceCegBmp);//将画好的高精度心电图保存到列表中
            _sourceCegBmp.Save(Application.StartupPath + "\\ECGImage\\" + _idStr + ".jpg", ImageFormat.Jpeg);
            try
            {
                var pd1 = new PrintDocument
                {
                    DefaultPageSettings = {Landscape = true, Margins = {Top = 0, Left = 0, Right = 0, Bottom = 0}}
                };
                pd1.PrintPage += pd1_PrintPage;
                pd1.Print();
            }
            catch
            {
                XtraMessageBox.Show(@"打印失败，请稍后重试：\r\n\r\n①请确保已经安装了打印机\r\n\r\n②检查打印机是否开机，纸张油墨是否充足\r\n\r\n③如果打印机工作正常而打印失败，您还可以联系我们！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (_ecgBitMap != null)
            {
                _ecgBitMap.Dispose();
            }
            if (!_isApped)
            {

                listBox1_Click(null, null);
            }
        }
       
        private void pictureEdit3_Paint(object sender, PaintEventArgs e)
        {
            Paint_ALL_ECG_scroll(e.Graphics);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            Process[] mProcs = Process.GetProcessesByName(@"osk");
            if (mProcs.Length == 0)
            {
                Process.Start(@"C:\WINDOWS\system32\osk.exe");
            }
        }

       
    }
}
