using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System;
using System.Drawing;
using System.Collections.Generic;


namespace CommonProj
{
    public class ConfigHelper
    {
        /// <summary>
        /// 远程连接字符串
        /// </summary>
        private static string remoteConStr = string.Empty;

        /// <summary>
        /// 缓存远程电子签章的容器
        /// </summary>
        public static Dictionary<string, Image> remoteDocImages = new Dictionary<string, Image>();

       
        /// <summary>
        /// 社区机构编号
        /// </summary>
        private static string orgID = string.Empty;

        /// <summary>
        /// 提交到几级判读设置
        /// </summary>
        private static string inptLevel = "1";

        /// <summary>
        /// 0:Access 1:SqlServer
        /// </summary>
        public readonly static int DB_SIGN = 0;


        /// <summary>
        /// 设置分页的
        /// </summary>
        public static int PAGE_SIZE = 20;
        /// <summary>
        /// 默认采集时间设置
        /// </summary>
        public static int CaiSJ = 12;

        /// <summary>
        /// 打印采样点设置
        /// </summary>
        public static int PrintSampleRate = 1000;


        /// <summary>
        /// 远程结果是否需要闪烁
        /// </summary>
        public static bool IsNeedBland = false;


        /// <summary>
        /// 是否有服务端修正的结果
        /// </summary>
        public static bool HasCorrectResult = false;

        /// <summary>
        /// E100命令端口
        /// </summary>
        public static string CommandComPort = "COM4";

        /// <summary>
        /// E100数据端口
        /// </summary>
        public static string EcgDataComPort = "COM3";


        /// <summary>
        /// BlueTooth命令端口
        /// </summary>
        public static string CommandComPort_BlueTooth = "COM6";

        /// <summary>
        /// BlueTooth数据端口
        /// </summary>
        public static string EcgDataComPort_BlueTooth = "COM5";
        /// <summary>
        /// 尿液分析仪数据和命令端口
        /// </summary>
        public static string EcgDataOrCommandPort_Urine = "COM7";
        /// <summary>
        /// 0表示餐前血糖，1表示餐后血糖,-1表示还没确定
        /// </summary>
        public static int BloodSugarNum = -1;

        /// <summary>
        /// 波形颜色
        /// </summary>
        public static Color WaveColor = Color.Black;

        /// <summary>
        /// 波形网格颜色
        /// </summary>
        public static Color WaveGridColor = Color.LightCoral;

        /// <summary>
        /// 波形背景色
        /// </summary>
        public static Color WaveBackColor = Color.White;

        /// <summary>
        /// 4*3+1导联默认显示
        /// </summary>
        public static int SingleLead = 1;

        /// <summary>
        /// 打印波形线条粗细
        /// </summary>
        public static float WaveSize = 2.0f;

        /// <summary>
        /// 是否自动采集
        /// </summary>
        public static bool IsAutoCollect = true;

   

        /// <summary>
        /// 是否进行采集
        /// </summary>
        public static bool IsRecordEcg = false;

        /// <summary>
        /// 缓存的病室信息
        /// </summary>
        public static DataTable PATIENT_ROOMS = null;

        /// <summary>
        /// 缓存的病床信息
        /// </summary>
        public static DataTable PATIENT_BEDS = null;

        /// <summary>
        /// 本地报告地址
        /// </summary>
        public static string LOCAL_ADDRESS = string.Empty;

        /// <summary>
        /// 判读是否有返回结果
        /// </summary>
        public static bool IsNeedBland_Ok = false;
   


        public static bool IsDashOrSolid = false;


        /// <summary>
        /// 基线
        /// </summary>
        public static int BASE_OFF = 0x00000001;
        public static int BASE_005HZ = 0x00000002;
        public static int BASE_05HZ = 0x00000004;
        public static int BASE_075HZ = 0x00000008;

        /// <summary>
        /// 肌电
        /// </summary>
        public static int MC_OFF = 0x00000100;
        public static int MC_25HZ = 0x00000200;
        public static int MC_35HZ = 0x00000400;
        public static int MC_45HZ = 0x00000800;

        /// <summary>
        /// 工频
        /// </summary>
        public static int AC_OFF = 0x00010000;
        public static int AC_50HZ = 0x00020000;
        public static int AC_60HZ = 0x00040000;

        /// <summary>
        /// 低通
        /// </summary>
        public static int LP_OFF = 0x01000000;
        public static int LP_75HZ = 0x02000000;
        public static int LP_100HZ = 0x04000000;
        public static int LP_150HZ = 0x08000000;

        /// <summary>
        /// 基线变量参数
        /// </summary>
        public static int BASE_HZ = BASE_05HZ;
        /// <summary>
        /// 肌电变量参数
        /// </summary>
        public static int MC_HZ = MC_35HZ;
        /// <summary>
        /// 工频变量参数
        /// </summary>
        public static int AC_HZ = AC_50HZ;
        /// <summary>
        /// 低通变量参数
        /// </summary>
        public static int LP_HZ = LP_100HZ;


        public static string EcgReportTitle = "本报告仅供临床参考，不作证明之用。";

        /// <summary>
        /// 身份证IP
        /// </summary>
        public static string IP = string.Empty;

        /// <summary>
        /// 申请表ID
        /// </summary>
        public static string AppId = string.Empty;
        /// <summary>
        /// 患者ID
        /// </summary>
        public static string PatientId = string.Empty;
        /// <summary>
        /// 患者名称
        /// </summary>
        public static string PatientName = string.Empty;
        /// <summary>
        /// 患者性别
        /// </summary>
        public static string PatientGender = string.Empty;
        /// <summary>
        /// 患者年龄
        /// </summary>
        public static string PatientAge = string.Empty;
        /// <summary>
        /// 判断登录人是否管理员
        /// </summary>
        public static bool IsAdmin = false;
        /// <summary>
        /// 登录人的ID
        /// </summary>
        public static string LoginId = string.Empty;
        /// <summary>
        /// 登录人名称
        /// </summary>
        public static string LoginName = string.Empty;
        /// <summary>
        /// 登录人的密码
        /// </summary>
        public static string LoginPassword = string.Empty;

        /// <summary>
        /// 申请令牌
        /// </summary>
        public static CommonVerifyUrlResult Cvur;
        /// <summary>
        /// 远程判读URL
        /// </summary>
        private static string UrlDistance = string.Empty;

        /// <summary>
        /// 远程验证用户名
        /// </summary>
        public static string UrlUserName = string.Empty;
        /// <summary>
        /// 远程验证密码
        /// </summary>
        public static string UrlPassWord = string.Empty;

        static ConfigHelper()
        {

            var ds = new DataSet();
            var sr = new StreamReader(Application.StartupPath + @"\Test.dll", System.Text.Encoding.UTF8);
            string str = DESEncrypt.Decrypt(sr.ReadToEnd());
            var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str));
            ds.ReadXml(ms);
            ms.Close();
            sr.Close();

            remoteConStr = ds.Tables[0].Rows[0]["RemoteConnectionString"].ToString().Trim();


            PAGE_SIZE = Convert.ToInt32(ds.Tables[0].Rows[0]["PAGE_SIZE"].ToString().Trim());

            inptLevel = ds.Tables[0].Rows[0]["InterpretationLevel"].ToString().Trim();
            UrlDistance = ds.Tables[0].Rows[0]["UrlDistanceString"].ToString().Trim();
            UrlUserName = ds.Tables[0].Rows[0]["UrlUserName"].ToString();
            UrlPassWord = ds.Tables[0].Rows[0]["UrlPassWord"].ToString();
            orgID = ds.Tables[0].Rows[0]["ORGID"].ToString();
            bool isEx = ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "DashOrSolid");
            if (isEx)
            {
                IsDashOrSolid = ds.Tables[0].Rows[0]["DashOrSolid"] != null && bool.Parse(ds.Tables[0].Rows[0]["DashOrSolid"].ToString());
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "CaiSJ"))
            {
                isEx = true;
            }
            if (isEx)
            {
                CaiSJ = ds.Tables[0].Rows[0]["CaiSJ"] != null ? int.Parse(ds.Tables[0].Rows[0]["CaiSJ"].ToString()) : 12;
                isEx = false;
            }


            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "PrintSampleRate"))
            {
                isEx = true;
            }
            if (isEx)
            {
                PrintSampleRate = ds.Tables[0].Rows[0]["PrintSampleRate"] != null
                    ? int.Parse(ds.Tables[0].Rows[0]["PrintSampleRate"].ToString())
                    : 250;
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "WaveColor"))
            {
                isEx = true;
            }
            if (isEx)
            {
                WaveColor = ds.Tables[0].Rows[0]["WaveColor"] != null
                    ? Color.FromArgb(int.Parse(ds.Tables[0].Rows[0]["WaveColor"].ToString()))
                    : Color.Black;
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "WaveGridColor"))
            {
                isEx = true;
            }
            if (isEx)
            {
                WaveGridColor = ds.Tables[0].Rows[0]["WaveGridColor"] != null
                    ? Color.FromArgb(int.Parse(ds.Tables[0].Rows[0]["WaveGridColor"].ToString()))
                    : Color.LightCoral;
                isEx = false;
            }


            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "WaveBackColor"))
            {
                isEx = true;
            }
            if (isEx)
            {
                WaveBackColor = ds.Tables[0].Rows[0]["WaveBackColor"] != null
                    ? Color.FromArgb(int.Parse(ds.Tables[0].Rows[0]["WaveBackColor"].ToString()))
                    : Color.White;
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "SingleLead"))
            {
                isEx = true;
            }
            if (isEx)
            {
                SingleLead = ds.Tables[0].Rows[0]["SingleLead"] != null
                    ? int.Parse(ds.Tables[0].Rows[0]["SingleLead"].ToString())
                    : 1;
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "WaveSize"))
            {
                isEx = true;
            }
            if (isEx)
            {
                WaveSize = ds.Tables[0].Rows[0]["WaveSize"] != null
                    ? float.Parse(ds.Tables[0].Rows[0]["WaveSize"].ToString())
                    : 2.0f;
                isEx = false;
            }

            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "IsAutoCollect"))
            {
                isEx = true;
            }
            if (isEx)
            {
                IsAutoCollect = ds.Tables[0].Rows[0]["IsAutoCollect"] == null || bool.Parse(ds.Tables[0].Rows[0]["IsAutoCollect"].ToString());
                isEx = false;
            }





            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "EcgReportTitle"))
            {
                isEx = true;
            }
            if (isEx)
            {
                EcgReportTitle = ds.Tables[0].Rows[0]["EcgReportTitle"] != null
                    ? ds.Tables[0].Rows[0]["EcgReportTitle"].ToString()
                    : "";
                isEx = false;
            }



            if (ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == "BASE_HZ"))
            {
                isEx = true;
            }
            if (isEx)
            {
                switch (ds.Tables[0].Rows[0]["BASE_HZ"].ToString().Trim())
                {
                    case "关":
                        BASE_HZ = BASE_OFF;
                        break;
                    case "0.05":
                        BASE_HZ = BASE_005HZ;
                        break;
                    case "0.5":
                        BASE_HZ = BASE_05HZ;
                        break;
                    case "0.75":
                        BASE_HZ = BASE_075HZ;
                        break;
                }
                isEx = false;
            }

            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                if (dc.ColumnName == "MC_HZ")
                {
                    isEx = true;
                    break;
                }
            }
            if (isEx)
            {
                switch (ds.Tables[0].Rows[0]["MC_HZ"].ToString().Trim())
                {
                    case "关":
                        MC_HZ = MC_OFF;
                        break;
                    case "25":
                        MC_HZ = MC_25HZ;
                        break;
                    case "35":
                        MC_HZ = MC_35HZ;
                        break;
                    case "45":
                        MC_HZ = MC_45HZ;
                        break;
                }
                isEx = false;
            }

            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                if (dc.ColumnName == "AC_HZ")
                {
                    isEx = true;
                    break;
                }
            }
            if (isEx)
            {
                switch (ds.Tables[0].Rows[0]["AC_HZ"].ToString().Trim())
                {
                    case "关":
                        AC_HZ = AC_OFF;
                        break;
                    case "50":
                        AC_HZ = AC_50HZ;
                        break;
                    case "60":
                        AC_HZ = AC_60HZ;
                        break;

                }
                isEx = false;
            }

            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                if (dc.ColumnName == "LP_HZ")
                {
                    isEx = true;
                    break;
                }
            }
            if (isEx)
            {
                switch (ds.Tables[0].Rows[0]["LP_HZ"].ToString().Trim())
                {
                    case "关":
                        LP_HZ = LP_OFF;
                        break;
                    case "75":
                        LP_HZ = LP_75HZ;
                        break;
                    case "100":
                        LP_HZ = LP_100HZ;
                        break;
                    case "150":
                        LP_HZ = LP_150HZ;
                        break;
                }
                isEx = false;
            }
            ds.Dispose();


            try
            {
                string addrPath = Application.StartupPath + "\\LOCAL_INFOMATION.INFO";
                if (File.Exists(addrPath))
                {
                    StreamReader sReader = new StreamReader(addrPath);
                    string cnt = sReader.ReadToEnd();
                    sReader.Close();
                    LOCAL_ADDRESS = cnt;
                }
                else
                {
                    string addr = "北京市大兴区亦庄经济技术开发区宏达北路16号";
                    FileStream fs = new FileStream(addrPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(addr);
                    sw.Close();
                    //fs.Close();
                    LOCAL_ADDRESS = addr;
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 获得远程连接字符串
        /// </summary>
        /// <returns></returns>
        public static string RemoteConnectionStr
        {
            get
            {
                return remoteConStr;
            }
        }
        /// <summary>
        /// 远程判读URL
        /// </summary>
        public static string UrlDistanceString
        {
            get { return UrlDistance; }
            set { UrlDistance = value; }
        }
        /// <summary>
        /// 获得社区机构编号
        /// </summary>
        /// <returns></returns>
        public static string ORGID
        {
            get
            {
                return orgID;
            }
        }

        /// <summary>
        /// 获取提交判读等级
        /// </summary>
        public static string InterpretationLevel
        {
            get { return inptLevel; }
            set { inptLevel = value; }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="value">值</param>
        public static void SaveConfig(string columnName, string value)
        {
            try
            {
                var ds = new DataSet();
                var sr = new StreamReader(Application.StartupPath + @"\Test.dll", System.Text.Encoding.UTF8);
                string str = DESEncrypt.Decrypt(sr.ReadToEnd());
                var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str));
                ds.ReadXml(ms);
                bool isEx = ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == columnName);
                if (!isEx)
                {
                    ds.Tables[0].Columns.Add(new DataColumn(columnName, typeof(string)));
                }
                ds.Tables[0].Rows[0][columnName] = value;
                ms.Close();
                sr.Close();

                var msm = new MemoryStream();
                ds.Tables[0].WriteXml(msm);
                string s = System.Text.Encoding.UTF8.GetString(msm.ToArray()).Insert(0, "<?xml version=\"1.0\" standalone=\"yes\" ?>");
                File.WriteAllText(Application.StartupPath + @"\Test.dll", DESEncrypt.Encrypt(s), System.Text.Encoding.UTF8);

                msm.Close();
                ds.Dispose();
            }
            catch
            { }
        }

        /// <summary>
        /// 保存多个配置文件节点
        /// </summary>
        /// <param name="config">配置字符串</param>
        public static bool SaveConfig(Dictionary<string, string> config)
        {
            try
            {
                var ds = new DataSet();
                var sr = new StreamReader(Application.StartupPath + @"\Test.dll", System.Text.Encoding.UTF8);
                string str = DESEncrypt.Decrypt(sr.ReadToEnd());
                var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str));
                ds.ReadXml(ms);

                if (config != null)
                {
                    foreach (KeyValuePair<string, string> kvp in config)
                    {
                        bool isEx = ds.Tables[0].Columns.Cast<DataColumn>().Any(dc => dc.ColumnName == kvp.Key);
                        if (!isEx)
                        {
                            ds.Tables[0].Columns.Add(new DataColumn(kvp.Key, typeof (string)));
                        }
                        ds.Tables[0].Rows[0][kvp.Key] = kvp.Value;
                    }
                }
                ms.Close();
                sr.Close();
                var msm = new MemoryStream();
                ds.Tables[0].WriteXml(msm);
                string s = System.Text.Encoding.UTF8.GetString(msm.ToArray())
                    .Insert(0, "<?xml version=\"1.0\" standalone=\"yes\" ?>");
                File.WriteAllText(Application.StartupPath + @"\Test.dll", DESEncrypt.Encrypt(s),
                    System.Text.Encoding.UTF8);
                msm.Close();
                ds.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
