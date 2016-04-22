using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Text;
using System.IO;
using DevExpress.XtraEditors;
using log4net;
using System.IO.Ports;
using System.Management;
using CommonProj;

namespace EcgViewPro
{

    public class MessageFilter : IMessageFilter
    {
        const int WmNclbuttondown = 0x00A1;
        const int Htcaption = 2;


        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WmNclbuttondown && m.WParam.ToInt32() == Htcaption)
                return true;
            return false;
        }
    }
    public static class Program
    {
        private static readonly MessageFilter Filter = new MessageFilter();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            try
            {
                bool createNew;
                var m = new Mutex(true, Application.ProductName, out createNew);

                

                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");

                DirectoryInfo[] directories = new DirectoryInfo(Environment.SystemDirectory + @"\..\Microsoft.NET\Framework").GetDirectories("v?.?.*");
                bool flag = directories.Any(info2 => Convert.ToDouble(info2.Name.Substring(1, 3)) >= 3.5);
                if (!flag)
                {
                    XtraMessageBox.Show(@"请先安装Framework3.5或其更高版本！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else
                {

                    if (createNew)
                    {
                        try
                        {
                            Application.AddMessageFilter(Filter);
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new FormLogin());
                            //Application.Run(new Main_Frm());
                        }
                        catch
                        {
                            //WatchDog.Fatal("系统异常2：" + ex.StackTrace + "\r\n" + ex.InnerException, ex);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(@"您已经在运行<<YJL_ECG心电图系统>>", @"YJL_ECG心电图系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch
            {
                //WatchDog.Fatal("系统异常：" + ex.StackTrace + "\r\n" + ex.InnerException, ex);
            }
        }

        /// <summary>
        /// 获取E100----COM串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetHljwComs()
        {
            var sesarcher = new ManagementObjectSearcher("select * from Win32_SerialPort");

            var coms = (from ManagementObject mo in sesarcher.Get() let p = mo.Properties["DeviceID"].Value.ToString() let name = mo.Properties["Caption"].Value.ToString() where name.Contains("YJL USB Driver") select p).ToList();
            WatchDog.WriteMsg("Com数量：" + coms.Count);
            int com1 = 3;
            int com2 = 4;
            if (coms.Count >= 2)
            {
                try
                {
                    com1 = Convert.ToInt32(coms[0].Substring(coms[0].LastIndexOf('M') + 1).TrimEnd(')'));
                    com2 = Convert.ToInt32(coms[1].Substring(coms[1].LastIndexOf('M') + 1).TrimEnd(')'));
                }
                catch(Exception ex)
                {
                     WatchDog.Fatal("系统异常1：" + ex.StackTrace + "\r\n" + ex.InnerException, ex);
                }
                WatchDog.WriteMsg("Com1数量：" + com1);
                CommandComPortOrEcgDataComPort(com1, com2);
            }
            return coms;
        }


        /// <summary>
        /// 获取蓝牙----COM串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBlueToothComs()
        {
            var sesarcher = new ManagementObjectSearcher("select * from Win32_SerialPort");
            var coms = (from ManagementObject mo in sesarcher.Get() let p = mo.Properties["DeviceID"].Value.ToString() let name = mo.Properties["Caption"].Value.ToString() where name.Contains("Bluetooth") select p).ToList();
            return coms;
        }


        /// <summary>
        /// 获取尿液分析仪----COM串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUrineAnalyzerComs()
        {
            var sesarcher = new ManagementObjectSearcher("select * from Win32_SerialPort");

            var coms = (from ManagementObject mo in sesarcher.Get() let p = mo.Properties["DeviceID"].Value.ToString() let name = mo.Properties["Caption"].Value.ToString() where name.Contains("YJL Urine Analyzer") select p).ToList();
            if (coms.Count == 1)
            {
                try
                {
                    ConfigHelper.EcgDataOrCommandPort_Urine =coms[0];
                }
                catch
                {
                    // WatchDog.Fatal("系统异常1：" + ex.StackTrace + "\r\n" + ex.InnerException, ex);
                }
            }
            return coms;
        }

        /// <summary>
        /// 判断那端口是命令串口
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public static void CommandComPortOrEcgDataComPort(int c1, int c2)
        {
            //byte[] crc_table = {0x00,0x5e,0xbc,0xe2,0x61,0x3f,0xdd,0x83,0xc2,0x9c,0x7e,0x20,0xa3,0xfd,0x1f,0x41,
            //                    0x9d,0xc3,0x21,0x7f,0xfc,0xa2,0x40,0x1e,0x5f,0x01,0xe3,0xbd,0x3e,0x60,0x82,0xdc,
            //                    0x23,0x7d,0x9f,0xc1,0x42,0x1c,0xfe,0xa0,0xe1,0xbf,0x5d,0x03,0x80,0xde,0x3c,0x62,
            //                    0xbe,0xe0,0x02,0x5c,0xdf,0x81,0x63,0x3d,0x7c,0x22,0xc0,0x9e,0x1d,0x43,0xa1,0xff,
            //                    0x46,0x18,0xfa,0xa4,0x27,0x79,0x9b,0xc5,0x84,0xda,0x38,0x66,0xe5,0xbb,0x59,0x07,
            //                    0xdb,0x85,0x67,0x39,0xba,0xe4,0x06,0x58,0x19,0x47,0xa5,0xfb,0x78,0x26,0xc4,0x9a,
            //                    0x65,0x3b,0xd9,0x87,0x04,0x5a,0xb8,0xe6,0xa7,0xf9,0x1b,0x45,0xc6,0x98,0x7a,0x24,
            //                    0xf8,0xa6,0x44,0x1a,0x99,0xc7,0x25,0x7b,0x3a,0x64,0x86,0xd8,0x5b,0x05,0xe7,0xb9,
            //                    0x8c,0xd2,0x30,0x6e,0xed,0xb3,0x51,0x0f,0x4e,0x10,0xf2,0xac,0x2f,0x71,0x93,0xcd,
            //                    0x11,0x4f,0xad,0xf3,0x70,0x2e,0xcc,0x92,0xd3,0x8d,0x6f,0x31,0xb2,0xec,0x0e,0x50,
            //                    0xaf,0xf1,0x13,0x4d,0xce,0x90,0x72,0x2c,0x6d,0x33,0xd1,0x8f,0x0c,0x52,0xb0,0xee,
            //                    0x32,0x6c,0x8e,0xd0,0x53,0x0d,0xef,0xb1,0xf0,0xae,0x4c,0x12,0x91,0xcf,0x2d,0x73,
            //                    0xca,0x94,0x76,0x28,0xab,0xf5,0x17,0x49,0x08,0x56,0xb4,0xea,0x69,0x37,0xd5,0x8b,
            //                    0x57,0x09,0xeb,0xb5,0x36,0x68,0x8a,0xd4,0x95,0xcb,0x29,0x77,0xf4,0xaa,0x48,0x16,
            //                    0xe9,0xb7,0x55,0x0b,0x88,0xd6,0x34,0x6a,0x2b,0x75,0x97,0xc9,0x4a,0x14,0xf6,0xa8,
            //                    0x74,0x2a,0xc8,0x96,0x15,0x4b,0xa9,0xf7,0xb6,0xe8,0x0a,0x54,0xd7,0x89,0x6b,0x35 };


            //命令下发端口初始化
            var com = new SerialPort("COM" + c1, 115200, Parity.None, 8, StopBits.One)
            {
                ReadBufferSize = 4096,
                WriteBufferSize = 2048
            };
            byte[] data = new byte[6];
            //启动AD指令  AA 00 02 A1 09 FF    停止AD：AA 00 02 A2 0A FF
            data[0] = Convert.ToByte("CC", 16);
            data[1] = Convert.ToByte("A1", 16);
            data[2] = Convert.ToByte("00", 16);
            data[3] = Convert.ToByte("00", 16);
            data[4] = Convert.ToByte("00", 16);
            data[5] = Convert.ToByte("DD", 16);

            //打开端口
            try
            {
                if (!com.IsOpen)
                {
                    com.Open();
                }
            }
            catch
            {
                return;
            }
            com.Write(data, 0, data.Length);
            Thread.Sleep(10);
            int comByte = com.BytesToRead;
          
            if (comByte > 1)//c1端口是命令串口
            {
                ConfigHelper.CommandComPort = "COM" + c1;
                ConfigHelper .EcgDataComPort= "COM" + c2;
            }
            else//c2端口是命令串口
            {
                ConfigHelper.CommandComPort = "COM" + c2;
                ConfigHelper.EcgDataComPort = "COM" + c1;
            }
            com.DiscardInBuffer();
            com.Close();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WatchDog.WriteMsg("系统异常3StackTrace：" + e.Exception.StackTrace);
            WatchDog.WriteMsg("系统异常3Source：" + e.Exception.Source);
            WatchDog.WriteMsg("系统异常3TargetSite：" + e.Exception.TargetSite);
            WatchDog.WriteMsg("系统异常3ToString：" + e.Exception.ToString());
            WatchDog.WriteMsg("系统异常3Message：" + e.Exception.Message);
            WatchDog.WriteMsg("系统异常3InnerException：" + e.Exception.InnerException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WatchDog.WriteMsg("系统异常4："+ (e.ExceptionObject as Exception).StackTrace);
        }

    }
}
