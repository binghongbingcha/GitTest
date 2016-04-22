using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;


namespace CommonProj
{
    public class SafeNativeMethods
    {
        [DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern short Filter_E100(int[] pIn, int[] pOut, int dataCountPerLead, short leadCount, bool flagLead, int[] paceLocBuff, int paceLocNum, int paceLocBuffSize);
        [DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool SetFilterPar(int FilterType);
        [DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetFilterDelay();//获取滤波后 起搏信号位置的整理偏移量

        public static short FilterE100(int[] pIn, int[] pOut, int dataCountPerLead, short leadCount, bool flagLead, int[] paceLocBuff, int paceLocNum, int paceLocBuffSize)
        {
            return Filter_E100(pIn, pOut, dataCountPerLead, leadCount, flagLead, paceLocBuff, paceLocNum, paceLocNum);
        }

        public static bool BoolSetFilterPar(int FilterType)
        {
            return SetFilterPar(FilterType);//滤波器参数设置
        }

        public static int IntGetFilterDelay()
        {
            return GetFilterDelay();
        }
    }

    public class serialPortOption:IDisposable
    {
        public SerialPort ccgData_Read_SerialPort;
        public SerialPort command_Write_SerialPort;
        public string leadDrop = ",-1,";//该状态指示某一导联是否脱落  值为-1时 指示为 没有导联脱落
        public string LeadState = string.Empty;//导联状态指示  脱落指示
        EcgConvert EC = new EcgConvert();
        public Dictionary<int, List<float>> EcgData_Dic = new Dictionary<int, List<float>>();//存放心电数据的字典 按照 每导联顺序进行存储
        public Dictionary<int, bool> LeadState_List = new Dictionary<int, bool>();
        public int FilterIndex = 0;//滤波时 此标志  指示从数组中 哪一个位置开始滤波
        public int excuteIndex = 1;//==1 表示导联没有接错
        public List<int> leadInfo = new List<int>();//导联信息 
        public bool isFilter = false;//指示是否需要启动滤波器设置

        int readEcgDataIndex = 0;//该变量指示 几次清除一下 实时计算心率的数据
        int AnalisisEcgDataMinlength = 5000;//分析的单导联最小数据长度
        public Dictionary<int, List<float>> EcgData_Dic_AfterFilter = new Dictionary<int, List<float>>();//滤波后的数据都存在这个字典中
        public Dictionary<int, List<float>> ecgData_realTimeAfterFilter = new Dictionary<int, List<float>>();//每次从串口缓冲区读取的心电数据，滤波后的数据都存在这个字典中
        public bool firstFlag = true;//firstFlag = true  表示 第一次加载数据  那么就需要移除滤波后的直线 数据
        public bool isRecord = true;//只是是否开始记录波形到内存中 2014-05-15 
        public int bufferBytesLength = 0;//每次读取串口数据时的数据长度
        private Thread th_ecgDataRead;//串口数据读取线程
        private Thread th_dealecgDataQueue;//保存接收到的心电数据的队列
        public int drawIndex = 0;//心电采集的初始开始位置为0

        public double PaperSpeed = 25.0;//心电波形走速
        public double Amplitude = 10.0;//振幅
        public double SamplingRate = 1000;
        //[DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern short Filter_E100(int[] pIn, int[] pOut, int dataCountPerLead, short leadCount, bool flagLead, int[] paceLocBuff, int paceLocNum, int paceLocBuffSize);
        //[DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern bool SetFilterPar(int FilterType);
        //[DllImport("YjlFilterArithmetic.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern int GetFilterDelay();//获取滤波后 起搏信号位置的整理偏移量
        public const int SourceLeadCount = 27;
        /// <summary>
        /// 让此类创建一个单例类
        /// </summary>
        public static serialPortOption _instance = null;//申明一个EcgDrawing对象，复制Null
        private static readonly object LockHelper = new object();
        private static readonly object LockHelperEcgData = new object();
        public bool IsExitExpection = false;
        public int PoutLength = 0;
        public short FilterResulte = 0;
        public List<long> PaceLocs = new List<long>();

        public static serialPortOption CreateInstance()
        {
            if (_instance == null)
            {
                lock (LockHelper)
                {
                    if (_instance == null)
                        _instance = new serialPortOption();
                }
            }
            return _instance;
        }

        public void IniserialPortOption()
        {
            //数据读取串口 初始化
            ccgData_Read_SerialPort = new SerialPort(ConfigHelper.EcgDataComPort, 115200, Parity.None, 8, StopBits.One);
            ccgData_Read_SerialPort.RtsEnable = false;
            ccgData_Read_SerialPort.ReadBufferSize = 4096 * 16;//4096000;
            ccgData_Read_SerialPort.ReadTimeout = 3000;
            ccgData_Read_SerialPort.ReceivedBytesThreshold = 256;

            //命令下发端口初始化
            command_Write_SerialPort = new SerialPort(ConfigHelper.CommandComPort, 115200, Parity.None, 8, StopBits.One);
            command_Write_SerialPort.ReadBufferSize = 4096;
            command_Write_SerialPort.WriteBufferSize = 2048;
            serialTime = DateTime.Now;
            leadInfo = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        }
        /// <summary>
        /// 开始将串口数据接收到内存数组中
        /// </summary>
        public void BeginRecord()
        {
            isRecord = true;
        }

        /// <summary>
        /// 停止将串口数据接收到内存数组中
        /// </summary>
        public void StopRecord()
        {
            //isRecord = false;//2014-05-15
            isRecord = true;
        }

        /// <summary>
        /// 下发AD启动指令
        /// </summary>
        public bool writeStartAD_Command()
        {
            try
            {
                byte[] command = new byte[7];
                byte[] data = new byte[7];
                data[0] = Convert.ToByte("CC", 16);
                data[1] = Convert.ToByte("A0", 16);
                data[2] = Convert.ToByte("00", 16);
                data[3] = Convert.ToByte("01", 16);
                data[4] = Convert.ToByte("0C", 16);
                data[5] = Convert.ToByte("0D", 16);
                data[6] = Convert.ToByte("DD", 16);
                if (!command_Write_SerialPort.IsOpen)
                {
                    command_Write_SerialPort.Open();
                }

                command_Write_SerialPort.Write(data, 0, data.Length);
                Thread.Sleep(100);
                if (command_Write_SerialPort.BytesToRead > 1)
                {

                    WatchLog.WriteMsg(DateTime.Now + "：????" + command_Write_SerialPort.BytesToRead);
                    command_Write_SerialPort.Read(command, 0, command.Length);

                }
                else
                {
                    WatchLog.WriteMsg(DateTime.Now + "：" + command_Write_SerialPort.BytesToRead);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                WatchLog.WriteMsg(DateTime.Now + "：" + command_Write_SerialPort.BytesToRead + "ex:" + ex.StackTrace);
                return false;
            }

        }

        /// <summary>
        /// 下发AD停止命令
        /// </summary>
        public void writeStopAD_Command()
        {
            var command = new byte[6];
            var data = new byte[6];
            data[0] = Convert.ToByte("CC", 16);
            data[1] = Convert.ToByte("A1", 16);
            data[2] = Convert.ToByte("00", 16);
            data[3] = Convert.ToByte("00", 16);
            data[4] = Convert.ToByte("00", 16);
            data[5] = Convert.ToByte("DD", 16);
            try
            {
                if (!command_Write_SerialPort.IsOpen)
                {
                    command_Write_SerialPort.Open();
                }
                command_Write_SerialPort.Write(data, 0, data.Length);
                Thread.Sleep(100);
                int comByte = command_Write_SerialPort.Read(command, 0, command.Length);
                command_Write_SerialPort.DiscardInBuffer();

                if (comByte != 6)
                {
                    command = new byte[6];
                    command_Write_SerialPort.Write(data, 0, data.Length);
                    command_Write_SerialPort.Read(command, 0, command.Length);
                    command_Write_SerialPort.DiscardInBuffer();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 关闭串口对象
        /// </summary>
        public void CloseSerialPort()
        {
            try
            {
                ccgData_Read_SerialPort.Close();
            }
            catch { }
            try
            {
                command_Write_SerialPort.Close();
            }
            catch { }
        }

        /// <summary>
        /// 终止心电数据读取的线程
        /// </summary>
        public void StopEcgDataReadThread()
        {
            th_ecgDataRead.Abort();
            th_dealecgDataQueue.Abort();

        }
        /// <summary>
        /// 开启心电数据读取的线程
        /// </summary>
        public void StartEcgDataReadThread()
        {
            th_ecgDataRead = new Thread(new ThreadStart(ecgDataRead));
            th_ecgDataRead.IsBackground = true;
            th_ecgDataRead.Priority = ThreadPriority.Highest;
            th_ecgDataRead.Start();

            th_dealecgDataQueue = new Thread(new ThreadStart(DealEcgData));
            th_dealecgDataQueue.IsBackground = true;
            th_dealecgDataQueue.Start();//开始心电数据队列中数据的处理线程
        }

        //[DllImport("movFilter.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int movFilter(int[] pSrc, int dataCountPerLead, int leadCount, short sampleRate, string leadName);

        public Queue<byte[]> EcgDataQueue = new Queue<byte[]>();


        public bool IsClear = false;
        public int PaceOffset = 0;
        private void DealEcgData()
        {
            //return;//yangwei return 处理

            while (true)
            {

                // Thread.Sleep(dealEcgDataSleepInterval);
                // lock (lockHelper_ecgDataQueue)
                //{
                if (isRecord)
                {
                    if (IsClear)
                    {
                        firstFlag = true;
                        IsClear = false;
                        ClearEcgData();
                    }
                    else
                    {
                        Console.Write("ecgDataQueue" + EcgDataQueue.Count + "\n");
                        if (EcgDataQueue.Count > 0)
                        {
                            #region  从队列中读取心电数据

                            Read_DataQueue();

                            #endregion

                            if (EcgData_Dic.Count == 12)
                            {
                                int filterCount = EcgData_Dic[0].Count - FilterIndex;
                                if (filterCount >= 100)  //yangwei add 7
                                {
                                    Console.Write(filterCount + "\n");
                                    int[] pIn = new int[filterCount * 12];
                                    int[] pOut = new int[filterCount * 12];
                                    List<int> paceLoc = new List<int>();
                                    int dataCountPerLead = filterCount;
                                    int pIn_Index = 0;

                                    //#region 准备滤波数据

                                    Pre_FilterEcgData(pIn, pIn_Index, paceLoc, filterCount);

                                    //#endregion

                                    //#region 滤波
                                    //// EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "开始滤波");
                                    Filter_EcgData(pIn, pOut, dataCountPerLead, paceLoc);
                                    //// EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "结束滤波");

                                    //pOut = pIn;
                                    //#endregion

                                    #region 心率

                                    HeartRate();

                                    #endregion

                                    #region 心电数据

                                    EcgData(pOut);

                                    #endregion


                                    #region //移除滤波后心电数组的 前 2100个 直线数据

                                    DeleteEcgData();
                                    //firstFlag = false;
                                    #endregion

                                    #region 导联状态

                                    Ecg_LeadState();

                                    #endregion

                                    Thread.Sleep(1);
                                    continue;
                                }
                                Thread.Sleep(8);
                                continue;
                            }
                        }
                        else
                        {
                            Thread.Sleep(20);
                        }
                    }
                }

                // }
                //throw new Exception("haha");
            }



        }
        /// <summary>
        /// 从队列中读取数据
        /// </summary>
        private void Read_DataQueue()
        {
            try
            {
                if (EcgDataQueue.Count > 0)
                {
                    byte[] buffer = EcgDataQueue.Dequeue();//将队列中的心电数据
                    LeadState = EC.EcgBytesToInt32(EcgData_Dic, buffer, LeadState_List, excuteIndex);
                }
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// 准备滤波数据
        /// </summary>
        /// <param name="pIn"></param>
        /// <param name="pIn_Index"></param>
        /// <param name="paceLoc"></param>
        /// <param name="FilterCount"></param>
        private void Pre_FilterEcgData(int[] pIn, int pIn_Index, List<int> paceLoc, int FilterCount)
        {
            try
            {
                for (int i = FilterIndex; i < FilterIndex + FilterCount; i++)
                {
                    for (int lead_1 = 0; lead_1 < 12; lead_1++)
                    {
                        if (EcgData_Dic.Count == 12)
                        {
                            try
                            {
                                if (EcgData_Dic[lead_1].Count > i)
                                {
                                    string dataConvert = double.Parse((EcgData_Dic[lead_1][(int)i] * 10000).ToString()).ToString("0");
                                    pIn[pIn_Index] = Int32.Parse(dataConvert);
                                    pIn_Index++;
                                }
                            }
                            catch { break; }
                        }
                    }
                    if (i < pace_makingOptions.Pacing_signal_list.Count && pace_makingOptions.Pacing_signal_list[(int)i] == 1)
                    {
                        paceLoc.Add(i - FilterIndex);
                        PaceLocs.Add(i);
                    }
                }
                FilterIndex += (int)FilterCount;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 滤波
        /// </summary>
        /// <param name="pIn"></param>
        /// <param name="pOut"></param>
        /// <param name="dataCountPerLead"></param>
        /// <param name="paceLoc"></param>
        private void Filter_EcgData(int[] pIn, int[] pOut, int dataCountPerLead, List<int> paceLoc)
        {
            short m = 12;
            try
            {
                int[] pacePos = paceLoc.ToArray();
                if (LeadState.Trim() == "LA,LL,RA,V1,V2,V3,V4,V5,V6" || LeadState.Trim() == "LA,LL,V1,V2,V3,V4,V5,V6")
                {
                    FilterResulte = SafeNativeMethods.FilterE100(pIn, pOut, dataCountPerLead, 12, true, pacePos, pacePos.Length, pacePos.Length);

                    PaceOffset = SafeNativeMethods.IntGetFilterDelay();
                }
                else
                {
                    FilterResulte = SafeNativeMethods.FilterE100(pIn, pOut, dataCountPerLead, m, false, pacePos, pacePos.Length, pacePos.Length);

                    PaceOffset = SafeNativeMethods.IntGetFilterDelay();
                }
                //EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "滤波正常：");
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 实时计算心率
        /// </summary>
        private void HeartRate()
        {
            readEcgDataIndex++;
            if (readEcgDataIndex % 10 == 0 && readEcgDataIndex != 0)
            {
                if (EcgData_Dic_AfterFilter.Count == 12)
                {
                    Dictionary<int, List<float>> RealEcg = EcgData_Dic_AfterFilter;
                    try
                    {
                        if (RealEcg[0].Count > AnalisisEcgDataMinlength)
                        {
                            ecgData_realTimeAfterFilter.Clear();
                            int beginIndex = RealEcg[0].Count - AnalisisEcgDataMinlength;

                            for (int rt_leadIndex = 0; rt_leadIndex < 12; rt_leadIndex++)
                            {
                                for (int i = beginIndex; i < beginIndex + AnalisisEcgDataMinlength; i++)
                                {
                                    if (ecgData_realTimeAfterFilter.ContainsKey(rt_leadIndex))
                                    {
                                        if (RealEcg.Count == 12)
                                        {
                                            if (RealEcg[rt_leadIndex].Count > i)
                                            {
                                                ecgData_realTimeAfterFilter[rt_leadIndex].Add(RealEcg[rt_leadIndex][i]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        List<float> pout_list = new List<float>();
                                        if (RealEcg.Count == 12)
                                        {
                                            if (RealEcg[rt_leadIndex].Count > i)
                                            {
                                                float pOut_data = RealEcg[rt_leadIndex][i];
                                                pout_list.Add(pOut_data);
                                                ecgData_realTimeAfterFilter.Add(rt_leadIndex, pout_list);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                readEcgDataIndex = 0;
            }
        }

        //yangwei add code 1 begin
        public delegate void OnData(int[] data);
        public event OnData _eventCallOnData;
        //yangwei add code 1 end

        /// <summary>
        /// 心电数据整理
        /// </summary>
        /// <param name="pOut"></param>
        private void EcgData(int[] pOut)
        {
            if (_eventCallOnData != null)
            {
                _eventCallOnData(pOut);//yangwei add code 2
            }

            //return;

            try
            {
                int p_count = 0;
                for (int AF = 0; AF < pOut.Length; AF++)
                {
                    if (EcgData_Dic_AfterFilter.ContainsKey(AF % 12))
                    {
                        float pOut_data = ((float)pOut[AF]) / 10000;
                        if (EcgData_Dic_AfterFilter.Count > 0)
                        {
                            EcgData_Dic_AfterFilter[AF % 12].Add(pOut_data);
                            p_count++;
                        }
                    }
                    else
                    {
                        List<float> pout_list = new List<float>();
                        float pOut_data = ((float)pOut[AF]) / 10000;
                        pout_list.Add(pOut_data);
                        EcgData_Dic_AfterFilter.Add(AF % 12, pout_list);
                        p_count++;
                    }
                }
                PoutLength += p_count / 12;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 移除滤波后心电数组的 前 2100个 直线数据
        /// </summary>
        private void DeleteEcgData()
        {
            try
            {
                if (firstFlag && EcgData_Dic_AfterFilter.Count == 12)
                {
                    if (EcgData_Dic_AfterFilter[0].Count >= 3000)//2500
                    {
                        for (int d = 0; d < 12; d++)
                        {
                            EcgData_Dic_AfterFilter[d].RemoveRange(0, 3000);
                        }
                        firstFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 导联状态判断
        /// </summary>
        private void Ecg_LeadState()
        {
            try
            {
                if (string.IsNullOrEmpty(LeadState.Trim()))
                {
                    leadDrop = ",-1,";
                    LeadState = "导联正常";
                }

            }
            catch (Exception ex)
            {

            }
        }


        int sleepInterval = 300; //yangwei add 9
        public DateTime serialTime;
        List<byte> bf = new List<byte>();
        //临时
        //StringBuilder sb = new StringBuilder();
        //static string path = Application.StartupPath + "\\ecgdata\\";
        //static FileStream fs = new FileStream(path + "ed", FileMode.OpenOrCreate, FileAccess.Write);
        //BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
        //int pwCount = 0;
        /// <summary>
        /// 串口数据读取
        /// </summary>
        private void ecgDataRead()
        {
            //return;//yangwei return 读

            while (true)
            {
                lock (LockHelperEcgData)
                {
                    try
                    {
                        if (!ccgData_Read_SerialPort.IsOpen)
                        {
                            ccgData_Read_SerialPort.Open();
                        }
                        bufferBytesLength = ccgData_Read_SerialPort.BytesToRead;
                        Console.Write("read len" + bufferBytesLength + "\n");
                        //bufferBytesLength = 1024 * 128;
                        //EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "==读取缓存区数据量：" + bufferBytesLength.ToString()+"==串口字节数："+bufferBytesLength.ToString());
                        if (bufferBytesLength > 0)
                        {
                            byte[] buffer = new byte[bufferBytesLength];
                            ccgData_Read_SerialPort.Read(buffer, 0, bufferBytesLength);
                            //ccgData_Read_SerialPort.DiscardInBuffer();
                            //ccgData_Read_SerialPort.DiscardOutBuffer();
                            bf.Clear();
                            bool Ok = false;

                            //for (int j = 0; j < buffer.Length; j++)
                            //{
                            //    //写临时数据
                            //    sb.Append(buffer[j]).Append(",");
                            //}
                            //if (pwCount < 5)
                            //{
                            //    bw.Write(sb.ToString().Replace(",","\t"));
                            //}
                            //else
                            //{
                            //    pwCount = 6;
                            //}
                            //pwCount++;
                            //bw.Close();
                            //fs.Close();
                            //if (buffer.Length % SourceLeadCount != 0)
                            //{
                            //    EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString()+"=====踢C0异常");




                            for (int k = 0; k < buffer.Length; k++)
                            {

                                if (buffer[k].ToString() == "192" && !Ok)
                                {
                                    Ok = true;

                                }
                                if (Ok && k + SourceLeadCount <= buffer.Length)
                                {
                                    if (k + SourceLeadCount + 2 < buffer.Length)
                                    {
                                        if (buffer[k + SourceLeadCount].ToString() == "192" && (buffer[k + 1] == buffer[k + 1 + SourceLeadCount] && buffer[k + 2] == buffer[k + 2 + SourceLeadCount] || buffer[k + 2 + SourceLeadCount] == 1 || buffer[k + 2] == 1))//
                                        {
                                            for (int t = k; t < k + SourceLeadCount; t++)
                                            {
                                                bf.Add(buffer[t]);
                                            }
                                            Ok = false;
                                            k += SourceLeadCount - 1;
                                        }
                                        else
                                        {
                                            Ok = false;
                                        }
                                    }
                                    else
                                    {
                                        for (int t = k; t < k + SourceLeadCount; t++)
                                        {
                                            bf.Add(buffer[t]);
                                        }
                                        Ok = false;
                                    }
                                }
                            }



                            //}
                            //else
                            //{
                            //    bf = buffer.ToList<byte>();
                            //}
                            // EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "读取缓存区数据量" + bufferBytesLength.ToString() + "==处理后的数据量：" + bf.Count.ToString());
                            if (isRecord)//&&bf.Count>0
                            {
                                EcgDataQueue.Enqueue(bf.ToArray());//将接收到的心电数据添加到队列中
                                //ecgDataQueue.Enqueue(buffer);
                            }

                            Thread.Sleep(sleepInterval);
                        }
                        else
                        {
                            Thread.Sleep(sleepInterval);
                        }

                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                }
                //  Thread.Sleep(sleepInterval);
            }
        }


        /// <summary>
        /// 清除数据
        /// </summary>
        public void ClearEcgData()
        {
            pace_makingOptions.Pacing_signal_list.Clear();
            FilterIndex = 0;
            EcgDataQueue.Clear();
            EcgData_Dic_AfterFilter.Clear();
            ecgData_realTimeAfterFilter.Clear();
            EcgData_Dic.Clear();
            PaceLocs.Clear();
            firstFlag = true;
            IsClear = false;

            // EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "清除全部数据");
        }


        /// <summary>
        /// 滤波器参数初始化
        /// </summary>
        /// <param name="param"></param>
        public void filterPara_Init(int param)
        {
            SafeNativeMethods.BoolSetFilterPar(param);//滤波器参数设置
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                ccgData_Read_SerialPort.Close();
                command_Write_SerialPort.Close();
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
