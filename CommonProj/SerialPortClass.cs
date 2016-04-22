using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO.Ports;
using System.Threading;

namespace CommonProj
{
    public class SerialPortClass:IDisposable
    {
        public string LEU = string.Empty;//白细胞   正常：阴性（-）为   异常：阳性说明尿路感染
        public string NIT = string.Empty;//亚硝酸盐 正常： 阴性（-）为  异常： 阳性说明尿路感染
        public string UBG = string.Empty;//尿胆原   正常：<1(mg/dl)<16(μmol/l)     异常：超过此数值，说明有黄疸
        public string PRO = string.Empty;//蛋白质  正常：阴性或仅有微量   异常：阳性提示可能有急性肾小球肾炎,糖尿病肾性疾病
        public string PH = string.Empty;//酸碱度  正常：5-8.5    异常：增高常见于频繁呕吐，呼吸性碱中毒   降低常见于酸中毒，慢性肾小球肾炎,糖尿病等
        public string BLD = string.Empty;//红细泡 正常：阴性（-）    异常：阳性（+）同时又蛋白者要考虑肾脏病和出血
        public string KET = string.Empty;//酮体  正常：阴性（-）    异常：阳性提示可能酸中毒，糖尿病，呕吐，腹泻
        public string BIL = string.Empty;//胆红素     正常：阴性（-）    异常：   阳性提示可能肝细胞性或阻塞性黄疸
        public string GLU = string.Empty;//葡萄糖    正常：阴性（-）    异常：阳性提示可能有糖尿病，甲亢，肢端肥大症等
        public string VC = string.Empty;//维生素C    正常：阴性 ( - )    异常：阳性提示 尿液红细胞,胆红素,亚硝酸盐,葡萄糖可能出现假阳性
        public string SG = string.Empty;//比重 正常：1.000-1.030 异常：增高多见于高热，心功能不全，糖尿病   降低多见于慢性肾小球肾炎和肾盂肾炎等
        public string SYS = "0";//收缩压
        public string DIA = "0";//舒张压 
        public string MAP = string.Empty;//平均脉动压 
        public string MsbCatch = string.Empty;//血压测量中错误信息
        public string Spo2 ="0";//血氧饱和度
        public string Bpm ="0";
        public StringBuilder SpoCatch = new StringBuilder();//血氧测量中错误

        string[] LEUs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "/", "/", "/" };
        string[] NITs = new string[8] { "-", "+", "/", "/", "/", "/", "/", "/" };
        string[] UBGs = new string[8] { "-", "+ 1", "+ 2", "+ 3", "/", "/", "/", "/" };
        string[] PROs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "+ 4", "/", "/" };
        string[] PHs = new string[8] { "5.0", "6.0", "6.5", "7.0", "7.5", "8.0", "8.5", "/" };
        string[] BLDs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "/", "/", "/" };
        string[] KETs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "+ 4", "/", "/" };
        string[] BILs = new string[8] { "-", "+ 1", "+ 2", "+ 3", "/", "/", "/", "/" };
        string[] GLUs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "+ 4", "/", "/" };
        string[] VCs = new string[8] { "-", "+ -", "+ 1", "+ 2", "+ 3", "/", "/", "/" };
        string[] SGs = new string[8] { "1.000", "1.005", "1.010", "1.015", "1.020", "1.025", "1.030", "/" };
        string[] data_Bir = new string[16] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        public string ComUrineAnalyzer = string.Empty;
        public string ComBluetooth = string.Empty;
        public string ComBloodString = string.Empty;
        public byte[] DataRead = new byte[19];
        public byte[] DataBlood = new byte[45];
        SerialPort _com;
        public SerialPort ComBlue;
        public SerialPort ComBlood;
        public string T = "——";//体温
        public string F = "——";//体温
        public string M = string.Empty;//血糖
        Thread _blueToothRead;
        Thread _blueToothDeal;
        static readonly object LockBluetooth = new object();
        public Queue<byte[]> BlueToothQueue = new Queue<byte[]>();
        public static SerialPortClass Instance = null;
        public List<byte> BlueToothMmhg = new List<byte>();
        public bool IsblueToothMmhg = true;

        public static SerialPortClass CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new SerialPortClass();
            }
            return Instance;
        }

        /// <summary>
        /// 获取尿液分析仪----COM串口
        /// </summary>
        /// <returns></returns>
        public void GetUrineAnalyzerComs()
        {
            var sesarcher = new ManagementObjectSearcher("select * from Win32_SerialPort");

            ManagementObjectCollection mos=sesarcher.Get();

            var coms = new List<string>();

            foreach (ManagementObject mo in mos)
            {
                string p = mo.Properties["DeviceID"].Value.ToString();
                string name = mo.Properties["Caption"].Value.ToString();
                if (name.Contains("YJL Urine Analyzer"))////EMP-Ui
                {
                    ComUrineAnalyzer = p;
                }
                if (name.Contains("YJL Blood Glucose Meter"))
                {
                    
                    ComBloodString = p;

                }
                if (name.Contains("Bluetooth"))
                {
                    coms.Add(p);
                }
            }

            if (coms.Count == 2)
            {
                int c1 = Convert.ToInt32(coms[0].Substring(coms[0].LastIndexOf('M') + 1).TrimEnd(')'));
                int c2 = Convert.ToInt32(coms[1].Substring(coms[1].LastIndexOf('M') + 1).TrimEnd(')'));

                if (c1 > c2)
                {
                    ComBluetooth = coms[1];
                }
                else
                {
                    ComBluetooth = coms[0];
                }
            }
        }

        /// <summary>
        /// 打开尿液端口
        /// </summary>
        public bool ReadComPort(string comname)
        {
            //命令下发端口初始化
            _com = new SerialPort(comname, 9600, Parity.None, 8, StopBits.One);
            _com.ReadBufferSize = 4096;
            _com.WriteBufferSize = 2048;
            //打开端口
            try
            {
                if (!_com.IsOpen)
                {
                    _com.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 打开血糖端口
        /// </summary>
        public bool ReadComPort_Blood(string comname)
        {
            //命令下发端口初始化
            ComBlood = new SerialPort(comname, 9600, Parity.None, 8, StopBits.One);
            ComBlood.ReadBufferSize = 4096;
            ComBlood.WriteBufferSize = 2048;
            //打开端口
            try
            {
                if (!ComBlood.IsOpen)
                {
                    ComBlood.Open();

                }
                string dt = "26 44 5A 20 06 33 36 38 0D";
                ComBlood.Write(dt);
                ComBlood.DiscardInBuffer();
                Thread.Sleep(100);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 打开温度端口
        /// </summary>
        public bool ReadComPort_Bluetooth(string comname)
        {
            //命令下发端口初始化
            ComBlue = new SerialPort(comname, 9600, Parity.None, 8, StopBits.One);
            ComBlue.ReadBufferSize = 4096;
            ComBlue.WriteBufferSize = 2048;

            //打开端口
            try
            {
                if (!ComBlue.IsOpen)
                {
                    ComBlue.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        ///解析尿液数据 data_read数组从下标6至18为数据
        /// </summary>
        public void Analyzer_UrineData()
        {
            //读取单条数据
            byte[] data = new byte[7];
            data[0] = Convert.ToByte("93", 16);
            data[1] = Convert.ToByte("8E", 16);
            data[2] = Convert.ToByte("04", 16);
            data[3] = Convert.ToByte("00", 16);
            data[4] = Convert.ToByte("08", 16);
            data[5] = Convert.ToByte("04", 16);
            data[6] = Convert.ToByte("10", 16);
            if (_com.IsOpen)
            {
                _com.Write(data, 0, data.Length);Thread.Sleep(10);
                if (_com.BytesToRead > 0)
                {
                    _com.Read(DataRead, 0, DataRead.Length);


                    ////删除数据
                    //byte[] data_del = new byte[9];
                    //data_del[0] = Convert.ToByte("93", 16);
                    //data_del[1] = Convert.ToByte("8E", 16);
                    //data_del[2] = Convert.ToByte("06", 16);
                    //data_del[3] = Convert.ToByte("00", 16);
                    //data_del[4] = Convert.ToByte("08", 16);
                    //data_del[5] = Convert.ToByte("06", 16);
                    //data_del[6] = Convert.ToByte("00", 16);
                    //data_del[7] = Convert.ToByte("00", 16);
                    //data_del[8] = Convert.ToByte("14", 16);
                    //com.Write(data_del, 0, data_del.Length);

                    for (int i = 6, j = 1; i < DataRead.Length - 1; i += 2, j++)
                    {
                        Analyzer_HexadecimalToBinary(DataRead[i], DataRead[i + 1], j);
                    }
                    _com.Close();
                }

            }
        }

        /// <summary>
        /// 解析血糖数据
        /// </summary>
        public void Analyzer_Blood()
        {
            //读取单条数据
            byte[] data = new byte[9];
            data[0] = Convert.ToByte("26", 16);
            data[1] = Convert.ToByte("44", 16);
            data[2] = Convert.ToByte("5A", 16);
            data[3] = Convert.ToByte("20", 16);
            data[4] = Convert.ToByte("06", 16);
            data[5] = Convert.ToByte("33", 16);
            data[6] = Convert.ToByte("36", 16);
            data[7] = Convert.ToByte("38", 16);
            data[8] = Convert.ToByte("0D", 16);
            //Thread.Sleep(100);
            if (ComBlood.IsOpen)
            {
                ComBlood.Write(data, 0, data.Length);
           
                Thread.Sleep(100);
                if (ComBlood.BytesToRead > 0)
                {
                    ComBlood.Read(DataBlood, 0, DataBlood.Length);
                }
                //////删除数据
                //byte[] data_del = new byte[11];
                //data_del[0] = Convert.ToByte("26", 16);
                //data_del[1] = Convert.ToByte("44", 16);
                //data_del[2] = Convert.ToByte("4A", 16);
                //data_del[3] = Convert.ToByte("20", 16);
                //data_del[4] = Convert.ToByte("06", 16);
                //data_del[5] = Convert.ToByte("34", 16);
                //data_del[6] = Convert.ToByte("39", 16);
                //data_del[7] = Convert.ToByte("35", 16);
                //data_del[8] = Convert.ToByte("33", 16);
                //data_del[9] = Convert.ToByte("33", 16);
                //data_del[10] = Convert.ToByte("0D", 16);
                //com_Blood.DiscardInBuffer();
                //com_Blood.Write(data_del, 0, data_del.Length);

                if (DataBlood[0] == 38 && DataBlood[1] == 68 && DataBlood[2] == 90 && DataBlood[3] == 32 && DataBlood[4] == 49 && DataBlood[5] == 32 && DataBlood[6] == 30 && DataBlood[18] != 0)
                {
                    AllowHexSpecifier(DataBlood[18], DataBlood[19], DataBlood[20]);

                    if (DataBlood[22] == 49)
                    {
                        ConfigHelper.BloodSugarNum = 1;
                    }
                    if (DataBlood[22] == 48)
                    {
                        ConfigHelper.BloodSugarNum = 0;
                    }
                }
                ComBlood.Close();
            }
        }
        /// <summary>
        /// 开始命令
        /// </summary>
        public void Instance_BluetoothStart()
        {
            if (!ComBlue.IsOpen)
            {
                ComBlue.Open();
            }
            //读取单条数据
            byte[] data = new byte[6];
            byte[] dataRead = new byte[6];
            data[0] = Convert.ToByte("AA", 16);
            data[1] = Convert.ToByte("55", 16);
            data[2] = Convert.ToByte("40", 16);
            data[3] = Convert.ToByte("02", 16);
            data[4] = Convert.ToByte("01", 16);
            data[5] = Convert.ToByte("29", 16);
            ComBlue.Write(data, 0, data.Length);
            if (ComBlue.BytesToRead > 0)
            {
                ComBlue.Read(dataRead, 0, dataRead.Length);
            }
        }
        /// <summary>
        /// 停止命令
        /// </summary>
        public void Instance_BluetoothStop()
        {
            //读取单条数据
            byte[] data = new byte[6];

            data[0] = Convert.ToByte("AA", 16);
            data[1] = Convert.ToByte("55", 16);
            data[2] = Convert.ToByte("40", 16);
            data[3] = Convert.ToByte("02", 16);
            data[4] = Convert.ToByte("01", 16);
            data[5] = Convert.ToByte("CB", 16);
            ComBlue.Write(data, 0, data.Length);

        }

        /// <summary>
        /// 十六进制转换ASC
        /// </summary>
        private void AllowHexSpecifier(byte b1, byte b2, byte b3)
        {
            string bb1 = ((char)b1).ToString();
            string bb2 = ((char)b2).ToString();
            string bb3 = ((char)b3).ToString();
            if (bb1 == "9")
            {
                M = "LO";
                return;
            }
            if (bb1 == "601")
            {
                M = "Hi";
                return;
            }
            M = ((Math.Round((Convert.ToDecimal((bb1 + bb2 + bb3)) / 18)*10, MidpointRounding.AwayFromZero))/10).ToString();
        }

        /// <summary>
        /// 十六进制转换二进制
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="index"></param>
        public void Analyzer_HexadecimalToBinary(byte data1, byte data2, int index)
        {
            string d1 = string.Empty;
            string d2 = string.Empty;
            string d = string.Empty;

            d1 = data_Bir[data1 / 16] + data_Bir[data1 % 16];

            d2 = data_Bir[data2 / 16] + data_Bir[data2 % 16];

            d = d1 + d2;
            Analyzer_Binary(d, index);
        }

        /// <summary>
        /// 解析二进制数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public void Analyzer_Binary(string data, int index)
        {
            //data 数据长度为16。
            switch (index)
            {
                case 1:// 第一行尿液数据对应SN（下标6-15）

                    break;
                case 2:// 第二行尿液数据对应effective（下标5-15）

                    break;
                case 3://第三行尿液数据对应TmDay（下标0-4）、TmMon（下标5-8）、TmYear（下标9-15）

                    break;
                case 4://第四行尿液数据对应LEU（下标2-4）、TmMinute（下标5-10）、TmHour（下标11-15）
                    LEU = LEUs[Convert.ToInt32(data.Substring(2, 3), 2)];
                    break;
                case 5://第五行尿液数据对应BLD（下标1-3）、PH（下标4-6）、PRO（下标7-9）、UBG（下标10-12）、NIT（下标13-15）
                    BLD = BLDs[Convert.ToInt32(data.Substring(1, 3), 2)];
                    PH = PHs[Convert.ToInt32(data.Substring(4, 3), 2)];
                    PRO = PROs[Convert.ToInt32(data.Substring(7, 3), 2)];
                    UBG = UBGs[Convert.ToInt32(data.Substring(10, 3), 2)];
                    NIT = NITs[Convert.ToInt32(data.Substring(13, 3), 2)];
                    break;
                case 6://第六行尿液数据对应PF（下标0）、VC（下标1-3）、GLU（下标4-6）、BIL（下标7-9）、KET（下标10-12）、SG（下标13-15）
                    VC = VCs[Convert.ToInt32(data.Substring(1, 3), 2)];
                    GLU = GLUs[Convert.ToInt32(data.Substring(4, 3), 2)];
                    BIL = BILs[Convert.ToInt32(data.Substring(7, 3), 2)];
                    KET = KETs[Convert.ToInt32(data.Substring(10, 3), 2)];
                    SG = SGs[Convert.ToInt32(data.Substring(13, 3), 2)];
                    break;
            }
        }

        /// <summary>
        /// 开启线程
        /// </summary>
        public void StartThread()
        {
            _blueToothRead = new Thread(new ThreadStart(ReadBlueToothData));
            _blueToothRead.IsBackground = true;
            _blueToothRead.Start();


            _blueToothDeal = new Thread(new ThreadStart(DealBlueToothData));
            _blueToothDeal.IsBackground = true;
            _blueToothDeal.Start();
        }

        /// <summary>
        /// 读取蜗牛数据
        /// </summary>
        public void ReadBlueToothData()
        {

            while (true)
            {
                try
                {
                    if (!ComBlue.IsOpen)
                    {
                        ComBlue.Open();
                    }
                    lock (LockBluetooth)
                    {
                        byte[] tem = new byte[ComBlue.BytesToRead];
                        ComBlue.Read(tem, 0, tem.Length);
                        if (tem.Length != 0)
                        {
                            BlueToothQueue.Enqueue(tem);
                        }

                    }
                    //Thread.Sleep(100);
                }
                catch (Exception e)
                {

                }
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 处理蜗牛数据
        /// </summary>
        public void DealBlueToothData()
        {

            BlueToothMmhg.Clear();
            while (true)
            {
                if (BlueToothQueue.Count > 0)
                {
                    byte[] tem = BlueToothQueue.Dequeue();
                    if (tem == null)
                    {
                        return;
                    }
                    for (int i = 0; i < tem.Length - 2; i++)
                    {
                        #region  //温度
                        if (tem[i] == 114 && tem[i + 1] == 5 && tem[i + 2] == 1&&(i+5)<tem.Length)
                        {
                            BlueToothMmhg.Add(tem[i + 3]);
                            BlueToothMmhg.Add(tem[i + 4]);
                            BlueToothMmhg.Add(tem[i + 5]);
                            if (BlueToothMmhg.Count == 0)
                            {
                                return;
                            }
                            string t1 = Convert.ToString(BlueToothMmhg[1], 16);
                            string t2 = Convert.ToString(BlueToothMmhg[2], 16);
                            string t = t1 + t2;
                            int dat = Int32.Parse(t, System.Globalization.NumberStyles.HexNumber);
                            if (dat != 0)
                            {
                                T =  (30.00f + dat * 0.01f).ToString().Substring(0, (30.00f + dat * 0.01f).ToString().IndexOf('.') + 2); // "℃"
                                F = (32 + Convert.ToDouble(T)*1.8).ToString();
                            }
                            else
                            {
                                F = "L";
                                T = "L";
                            }
                            BlueToothMmhg.Clear();


                        }
                        #endregion

                        #region //血糖
                        if (tem[i] == 115 && tem[i + 1] == 5 && tem[i + 2] == 1&&(i+5)<tem.Length)
                        {
                            BlueToothMmhg.Add(tem[i + 3]);
                            BlueToothMmhg.Add(tem[i + 4]);
                            BlueToothMmhg.Add(tem[i + 5]);
                            if (BlueToothMmhg.Count == 0)
                            {
                                return;
                            }
                            string t1 = Convert.ToString(BlueToothMmhg[1], 16);
                            string t2 = Convert.ToString(BlueToothMmhg[2], 16);
                            string t = t1 + t2;
                            float dat = Convert.ToInt32(t) * 0.1f;
                            M = dat.ToString();
                            BlueToothMmhg.Clear();


                        }
                        #endregion

                        #region//血氧
                        if (tem[i] == 83 && tem[i + 1] == 7 && tem[i + 2] == 1&&(i+7)<tem.Length)
                        {
                            BlueToothMmhg.Add(tem[i + 3]);//Spo2血氧饱和度
                            BlueToothMmhg.Add(tem[i + 4]);
                            BlueToothMmhg.Add(tem[i + 5]);
                            BlueToothMmhg.Add(tem[i + 6]);//PI（灌注指数）
                            BlueToothMmhg.Add(tem[i + 7]);//状态信息
                            if (BlueToothMmhg.Count == 0)
                            {
                                return;
                            }
                            Spo2 = BlueToothMmhg[0].ToString();
                            Bpm = BlueToothMmhg[1].ToString();
                            string bit = data_Bir[BlueToothMmhg[4] / 16] + data_Bir[BlueToothMmhg[4] % 16];

                            if (bit.Substring(7, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("探针断开连接"))
                                {
                                    SpoCatch.Append("探针断开连接");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("探针断开连接", "");
                            }

                            if (bit.Substring(6, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("调查关闭"))
                                {
                                    SpoCatch.Append("调查关闭");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("调查关闭", "");
                            }
                            if (bit.Substring(5, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("脉冲搜索……"))
                                {
                                    SpoCatch.Append("脉冲搜索……");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("脉冲搜索……", "");
                            }
                            if (bit.Substring(4, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("搜索的时间太长"))
                                {
                                    SpoCatch.Append("搜索的时间太长");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("搜索的时间太长", "");
                            }
                            if (bit.Substring(3, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("运动检测"))
                                {
                                    SpoCatch.Append("运动检测");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("运动检测", "");
                            }
                            if (bit.Substring(2, 1) == "1")
                            {
                                if (!SpoCatch.ToString().Contains("低灌注"))
                                {
                                    SpoCatch.Append("低灌注");
                                }
                            }
                            else
                            {
                                SpoCatch.Replace("低灌注", "");
                            }
                            BlueToothMmhg.Clear();
                        }
                        #endregion

                        #region //血压
                        if (tem[i] == 67 && tem[i + 1] == 7 && tem[i + 2] == 1&&(i+7)<tem.Length)
                        {
                            BlueToothMmhg.Add(tem[i + 3]);
                            BlueToothMmhg.Add(tem[i + 4]);
                            BlueToothMmhg.Add(tem[i + 5]);
                            BlueToothMmhg.Add(tem[i + 6]);
                            BlueToothMmhg.Add(tem[i + 7]);
                            if (BlueToothMmhg.Count == 0)
                            {
                                return;
                            }
                            SYS = (BlueToothMmhg[0] + BlueToothMmhg[1]).ToString();
                            DIA = BlueToothMmhg[3].ToString();
                            MAP = BlueToothMmhg[2].ToString();
                            BlueToothMmhg.Clear();
                            MsbCatch = string.Empty;

                        }

                        if (tem[i] == 67 && tem[i + 1] == 3 && tem[i + 2] == 2&&(i+3)<tem.Length)
                        {
                            BlueToothMmhg.Add(tem[i + 3]);
                            if (BlueToothMmhg.Count == 0)
                            {
                                return;
                            }
                            string bit = data_Bir[BlueToothMmhg[0] / 16] + data_Bir[BlueToothMmhg[0] % 16];
                            string bit7 = bit.Substring(0, 1);
                            string bit6 = bit.Substring(1, 7);
                            int bit0 = Convert.ToInt32(bit6, 2);
                            if (bit7 == "0")
                            {
                                switch (bit0)
                                {
                                    case 0:
                                        MsbCatch = "测量不到有效的脉搏";
                                        break;
                                    case 1:
                                        MsbCatch = "气袋没绑好";
                                        break;
                                    case 2:
                                        MsbCatch = "测量结果数值有误";
                                        break;
                                    case 3:
                                        MsbCatch = "气袋压力超过295mmHg。进入超压保护";
                                        break;
                                    case 4:
                                        MsbCatch = "干预过多（测量中移动、说话等）";
                                        break;
                                }

                            }
                            if (bit7 == "1")
                            {
                                switch (bit0)
                                {
                                    case 1:
                                        MsbCatch = "气袋没绑好";
                                        break;
                                    case 2:
                                        MsbCatch = "气袋压力超过295mmHg。进入超压保护";
                                        break;
                                    case 3:
                                        MsbCatch = "测量不到有效的脉搏";
                                        break;
                                    case 4:
                                        MsbCatch = "干预过多（测量中移动、说话等）";
                                        break;
                                    case 5:
                                        MsbCatch = "测量结果数值有误";
                                        break;
                                    case 6:
                                        MsbCatch = "漏气";
                                        break;
                                }
                            }

                            SYS = "0";
                            DIA = "0";
                            MAP = string.Empty;
                        }

                        #endregion
                    }
                }
                Thread.Sleep(100);
            }


        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                _com.Close();
                ComBlue.Close();
                ComBlood.Close();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
