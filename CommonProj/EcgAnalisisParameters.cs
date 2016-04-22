using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CommonProj
{

    public class NativeMethods
    {
        [DllImport("DiagDllProj.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CalcRr(float[] pSrc, int dataCountPerLead, short sampleRate);

        public static int IntCalcRr(float[] pSrc, int dataCountPerLead, short sampleRate)
        {
            return CalcRr( pSrc,  dataCountPerLead,  sampleRate);
        }
    }


    public class EcgAnalisisParameters
    {
        readonly short _samp = short.Parse("994");//956

        /// <summary>
        /// 根据二导联的数据 进行实时的心率计算
        /// </summary>
        /// <param name="resulteDic"></param>
        /// <returns></returns>
        public int AnalisisHeartRate(Dictionary<int, List<float>> resulteDic)
        {
            if (resulteDic.Count == 0)
                return -1;
            if (resulteDic.Count > 1)
            {
                int dataCountPerLead = resulteDic[0].Count;
                var inParas = new float[dataCountPerLead];
                for (int i = 0; i < dataCountPerLead; i++)
                {
                   inParas[i] = resulteDic[1][i];
                }
                try
                {
                    int heartRate = NativeMethods.IntCalcRr(inParas, dataCountPerLead, _samp);
                    return heartRate;
                }
                catch
                {

                }
            }
            return -1;
        }
    }
}
