using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CommonProj
{
    public static class pace_makingOptions
    {

        /*************************起搏信号检测******************************************/
        ///// <summary>
        ///// 检测第三字节的第一个位 的值 是否为1  1为起搏 0为不是起搏
        ///// </summary>
        ///// <param name="b"></param>
        ///// <param name="bitIndex"></param>
        ///// <returns></returns>
        //public static String byteToBit(byte b, int bitIndex)
        //{
        //    return ((byte)((b >> 0) & 0x1)).ToString();
        //    //return "" +(byte)((b >> 7) & 0x1) +   
        //    //(byte)((b >> 6) & 0x1) +   
        //    //(byte)((b >> 5) & 0x1) +   
        //    //(byte)((b >> 4) & 0x1) +   
        //    //(byte)((b >> 3) & 0x1) +   
        //    //(byte)((b >> 2) & 0x1) +   
        //    //(byte)((b >> 1) & 0x1) +   
        //    //(byte)((b >> 0) & 0x1);  
        //}


        public static int pace_count = 0;
        public static List<int> Pacing_signal_list = new List<int>();//用于标记起搏信号，有起搏信号的为1，没有起搏信号的 为 0
        /// <summary>
        /// 检测第三字节的第一个位 的值 是否为1  1为起搏 0为不是起搏
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bitIndex"></param>
        /// <returns></returns>
        public static void isPace_making(byte[] EcgBytes_1)
        {
            for (int i = 0; i < EcgBytes_1.Length / 27; i++)
            {
                byte b = EcgBytes_1[2 + i * 27];
                if (((b >> 0) & 0x01) == 1)
                {
                    Pacing_signal_list.Add(1);
                    // File.AppendAllText(Application.StartupPath + @"/time.txt", "1");
                }
                if (((b >> 0) & 0x01) == 0)
                {
                    Pacing_signal_list.Add(0);
                    //File.AppendAllText(Application.StartupPath + @"/time.txt", "0");
                }
            }
        }



    }
}
