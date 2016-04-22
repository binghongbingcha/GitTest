using System;
using System.Collections.Generic;
using System.Linq;


namespace CommonProj
{
   public class EcgConvert
    {
        public const int SourceLeadCount = 27;//原始数据中的实际字节数  III avr avf avl 这四个导联都是算出来的 
       readonly List<float> _ecgInt32List = new List<float>();
        public float RefVoltage = 2400;//mv毫伏
        public float HardWareGain = 3;//硬件放大倍数

        /// <summary>
        /// 判断导联状态
        /// </summary>
        /// <param name="secondByte"></param> <param name="threeByte"></param>
        /// <param name="leadStateList"></param>
        string jugeLeadState(byte secondByte, byte threeByte, Dictionary<int, bool> leadStateList)
        {
            leadStateList.Clear();//清除数据
            //LA
            if (((threeByte >> 4) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(0))
                {
                    leadStateList[0] = true;
                }
                else
                {
                    leadStateList.Add(0, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(0))
                {
                    leadStateList[0] = false;
                }
                else
                {
                    leadStateList.Add(0, false);
                }
            }

            //LL
            if (((threeByte >> 5) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(1))
                {
                    leadStateList[1] = true;
                }
                else
                {
                    leadStateList.Add(1, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(1))
                {
                    leadStateList[1] = false;
                }
                else
                {
                    leadStateList.Add(1, false);
                }
            }

            //RA

            if (((secondByte >> 4) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(2))
                {
                    leadStateList[2] = true;
                }
                else
                {
                    leadStateList.Add(2, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(2))
                {
                    leadStateList[2] = false;
                }
                else
                {
                    leadStateList.Add(2, false);
                }
            }
            //V1
            if (((threeByte >> 6) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(3))
                {
                    leadStateList[3] = true;
                }
                else
                {
                    leadStateList.Add(3, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(3))
                {
                    leadStateList[3] = false;
                }
                else
                {
                    leadStateList.Add(3, false);
                }
            }
            //V2
            if (((threeByte >> 7) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(4))
                {
                    leadStateList[4] = true;
                }
                else
                {
                    leadStateList.Add(4, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(4))
                {
                    leadStateList[4] = false;
                }
                else
                {
                    leadStateList.Add(4, false);
                }
            }
            //V3
            if (((secondByte >> 0) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(5))
                {
                    leadStateList[5] = true;
                }
                else
                {
                    leadStateList.Add(5, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(5))
                {
                    leadStateList[5] = false;
                }
                else
                {
                    leadStateList.Add(5, false);
                }
            }

            //V4
            if (((secondByte >> 1) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(6))
                {
                    leadStateList[6] = true;
                }
                else
                {
                    leadStateList.Add(6, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(6))
                {
                    leadStateList[6] = false;
                }
                else
                {
                    leadStateList.Add(6, false);
                }
            }
            //V5
            if (((secondByte >> 2) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(7))
                {
                    leadStateList[7] = true;
                }
                else
                {
                    leadStateList.Add(7, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(7))
                {
                    leadStateList[7] = false;
                }
                else
                {
                    leadStateList.Add(7, false);
                }
            }
            //V6
            if (((secondByte >> 3) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(8))
                {
                    leadStateList[8] = true;
                }
                else
                {
                    leadStateList.Add(8, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(8))
                {
                    leadStateList[8] = false;
                }
                else
                {
                    leadStateList.Add(8, false);
                }
            }
            //V3R
            if (((secondByte >> 7) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(9))
                {
                    leadStateList[9] = true;
                }
                else
                {
                    leadStateList.Add(9, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(9))
                {
                    leadStateList[9] = false;
                }
                else
                {
                    leadStateList.Add(9, false);
                }
            }
            //V4R
            if (((secondByte >> 6) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(10))
                {
                    leadStateList[10] = true;
                }
                else
                {
                    leadStateList.Add(10, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(10))
                {
                    leadStateList[10] = false;
                }
                else
                {
                    leadStateList.Add(10, false);
                }
            }

            //V5R
            if (((secondByte >> 5) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(11))
                {
                    leadStateList[11] = true;
                }
                else
                {
                    leadStateList.Add(11, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(11))
                {
                    leadStateList[11] = false;
                }
                else
                {
                    leadStateList.Add(11, false);
                }
            }
            //V7
            if (((threeByte >> 3) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(12))
                {
                    leadStateList[12] = true;
                }
                else
                {
                    leadStateList.Add(12, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(12))
                {
                    leadStateList[12] = false;
                }
                else
                {
                    leadStateList.Add(12, false);
                }
            }
            //V8
            if (((threeByte >> 2) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(13))
                {
                    leadStateList[13] = true;
                }
                else
                {
                    leadStateList.Add(13, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(13))
                {
                    leadStateList[13] = false;
                }
                else
                {
                    leadStateList.Add(13, false);
                }
            }
            //V9
            if (((threeByte >> 1) & 0x01) == 1)
            {
                if (leadStateList.ContainsKey(14))
                {
                    leadStateList[14] = true;
                }
                else
                {
                    leadStateList.Add(14, true);
                }
            }
            else
            {
                if (leadStateList.ContainsKey(14))
                {
                    leadStateList[14] = false;
                }
                else
                {
                    leadStateList.Add(14, false);
                }
            }

            var leadNameArray = new[] { "LA", "LL", "RA", "V1", "V2", "V3", "V4", "V5", "V6", "V3R", "V4R", "V5R", "V7", "V8", "V9" };
            var leadStateStr = string.Empty;
            for (var i = 0; i < 15; i++)
            {
                if (leadStateList[i])
                {
                    leadStateStr += (leadNameArray[i] + ",");
                }
            }
            if (leadStateStr.Length > 0)
            {
                leadStateStr = leadStateStr.Trim(',');
            }
            return leadStateStr;
        }
        /// <summary>
        /// 数据队列
        /// </summary>
        string _lstate = string.Empty;
        bool _jugels;
        int _jls;
        public string EcgBytesToInt32(Dictionary<int, List<float>> ecgDic, byte[] ecgBytes2, Dictionary<int, bool> leadStateList, int excuteFlag)
        {
            //EcgViewPro.WatchDog.WriteMsg(DateTime.Now.ToString() + "==EcgBytes_2：" + EcgBytes_2.Length.ToString());
            string leadstate = string.Empty;
            if (ecgBytes2.Length < SourceLeadCount)
            {
                return leadstate;
            }

            //校验数据包是否合法
            List<byte> ecgBytes1 = ecgBytes2.ToList();// new List<byte>();

            if (ecgBytes1.Count > 2)
            {

                //判断导联状态
                leadstate = jugeLeadState(ecgBytes1[1], ecgBytes1[2], leadStateList);

                if (!string.IsNullOrEmpty(leadstate.Trim()))
                {
                    if (leadstate.Contains("V1"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                    if (leadstate.Contains("V2"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                    if (leadstate.Contains("V3"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                    if (leadstate.Contains("V4"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                    if (leadstate.Contains("V5"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                    if (leadstate.Contains("V6"))
                    {
                        if (!_lstate.Contains("脱落"))
                        {
                            _lstate += "脱落";
                        }
                    }
                }
                if (_lstate == "脱落")
                {
                    _jugels = LeadState(ecgBytes1);
                    _lstate = string.Empty;
                    _jls = 1;
                }
                else
                {
                    if (_jls == 1)
                    {
                        _jugels = true;
                        _jls = 0;
                    }
                }

                var data1 = new List<byte>();
                for (int r = 0; r < ecgBytes1.Count; r++)
                {
                    if (r > 2)//r > 0 && r != 1 && r != 2 && r != 3
                    {
                        if ((r - 2) % SourceLeadCount != 0 && (r - 1) % SourceLeadCount != 0 && (r - 0) % SourceLeadCount != 0)
                        {
                            data1.Add(ecgBytes1[r]);
                        }
                    }

                }

                //检测起搏信号
                for (int k = 2; k < ecgBytes1.Count; k++)
                {
                    //起搏信号检测

                    if (ecgBytes1[k - 2].ToString() == "192")//&& EcgBytes_1[k - 2 + SourceLeadCount].ToString() == "192"
                    {
                        byte b = ecgBytes1[k];
                        if (((b >> 0) & 0x01) == 1)//  && ((b >> 1) & 0x01) == 0&& ((b >> 2) & 0x01) == 0 && ((b >> 3) & 0x01) == 0
                        {
                            //pace_makingOptions.Pacing_signal_list.Add(1);
                            int a = ecgDic.Count > 0 ? ecgDic[0].Count : 0;
                            int paceLoc = a + k / 27;
                            for (int i = pace_makingOptions.Pacing_signal_list.Count; i <= paceLoc; i++)
                            {
                                if (i == paceLoc && !_jugels)
                                    pace_makingOptions.Pacing_signal_list.Add(1);
                                else
                                    pace_makingOptions.Pacing_signal_list.Add(0);
                            }
                        }
                    }
                    k += SourceLeadCount - 1;
                }
                _jugels = false;
                _ecgInt32List.Clear();
                for (int i = 0; i < data1.Count; i += 3)
                {
                    byte a = data1[i];
                    byte b = data1[i + 1];
                    byte c = data1[i + 2];
                    Int32 values = (((a << 24) + (b << 16) + (c << 8)) >> 8); //转换完32位的数\
                    const float amp = (float)8 * 1024 * 1024 * 3 / 1000 / (float)2.4;

                    //Int32 values =(a << 16) + (b << 8) +c; //转换完32位的数
                    //int hr=(int)hardWareGain<<23;
                    //float amp = hr/refVoltage;

                    var vol = values / amp;
                    _ecgInt32List.Add(vol);
                }

                if (_ecgInt32List.Count > 0)
                {
                    RecoverEcgData(ecgDic, _ecgInt32List, excuteFlag);
                }
            }
            return leadstate;
        }

        string _by1 = string.Empty;
        string _by2 = string.Empty;

        private bool LeadState(List<byte> lb)
        {
            bool ok = false;
            if (lb.Count > 2)
            {
                _by1 = Convert.ToString(lb[1], 16);
                _by2 = Convert.ToString(lb[2], 16);
            }
            for (int i = 1; i < lb.Count; i += SourceLeadCount)
            {
                if (_by1 != Convert.ToString(lb[i], 16) || (_by2 != Convert.ToString(lb[i + 1], 16) && Convert.ToString(lb[i + 1], 16) != "1"))
                {
                    ok = true;
                    break;
                }
            }
            return ok;
        }

       /// <summary>
       /// 把数据恢复成十二导联  并且添加到12导联数据队列中
       /// </summary>
       /// <param name="ecgDic">数据队列</param>
       /// <param name="ecgInt32List"></param>
       /// <param name="excuteFlag"></param>
       private void RecoverEcgData(Dictionary<int, List<float>> ecgDic, List<float> ecgInt32List, int excuteFlag)
        {
            var ecgArray = new float[12];
            switch (excuteFlag)
            {
                case 1:
                    for (int ecgIndex = 0; ecgIndex < (ecgInt32List.Count / 8); ecgIndex++)
                    {
                        //I
                        ecgArray[0] = ecgInt32List[0 + ecgIndex * 8];
                        //II
                        ecgArray[1] = ecgInt32List[1 + ecgIndex * 8];
                        //III=II - I
                        ecgArray[2] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8];
                        //aVR = -(II + I) / 2;
                        ecgArray[3] = -(ecgInt32List[1 + ecgIndex * 8] + ecgInt32List[0 + ecgIndex * 8]) / 2;
                        //aVL= I - II / 2;
                        ecgArray[4] = ecgInt32List[0 + ecgIndex * 8] - ecgInt32List[1 + ecgIndex * 8] / 2;
                        //aVF= II - I / 2;
                        ecgArray[5] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8] / 2;
                        //V1,V2,V3,V4,V5,V6
                        AddRecoverEcgData(ecgArray, ecgDic, ecgIndex);
                    }
                    break;
                case 2:
                    for (int ecgIndex = 0; ecgIndex < (ecgInt32List.Count / 8); ecgIndex++)
                    {
                        //I
                        ecgArray[0] = -ecgInt32List[0 + ecgIndex * 8];
                        //II= II - I;
                        ecgArray[1] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8];
                        //III=II;
                        ecgArray[2] = ecgInt32List[1 + ecgIndex * 8];
                        //aVR =  I - II / 2;
                        ecgArray[3] = ecgInt32List[0 + ecgIndex * 8] - ecgInt32List[1 + ecgIndex * 8] / 2;
                        //aVL=-(II + I) / 2;
                        ecgArray[4] = -(ecgInt32List[1 + ecgIndex * 8] + ecgInt32List[0 + ecgIndex * 8]) / 2;
                        //aVF= II - I / 2;
                        ecgArray[5] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8] / 2;
                        //V1,V2,V3,V4,V5,V6
                        AddRecoverEcgData(ecgArray, ecgDic, ecgIndex);
                    }
                    break;
                case 3:
                    for (int ecgIndex = 0; ecgIndex < (ecgInt32List.Count / 8); ecgIndex++)
                    {
                        //I
                        ecgArray[0] = ecgInt32List[1 + ecgIndex * 8];
                        //II
                        ecgArray[1] = ecgInt32List[0 + ecgIndex * 8];
                        //III=II - I
                        ecgArray[2] = -(ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8]);
                        //aVR = -(II + I) / 2;
                        ecgArray[3] = -(ecgInt32List[1 + ecgIndex * 8] + ecgInt32List[0 + ecgIndex * 8]) / 2;
                        //aVL= I - II / 2;
                        ecgArray[4] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8] / 2;
                        //aVF= II - I / 2;
                        ecgArray[5] = ecgInt32List[0 + ecgIndex * 8] - ecgInt32List[1 + ecgIndex * 8] / 2;
                        //V1,V2,V3,V4,V5,V6
                        AddRecoverEcgData(ecgArray, ecgDic, ecgIndex);
                    }
                    break;
                case 4:
                    for (int ecgIndex = 0; ecgIndex < (ecgInt32List.Count / 8); ecgIndex++)
                    {
                        //I
                        ecgArray[0] = -(ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8]);
                        //II
                        ecgArray[1] = -ecgInt32List[1 + ecgIndex * 8];
                        //III=II - I
                        ecgArray[2] = -ecgInt32List[0 + ecgIndex * 8];
                        //avr = -(II + I) / 2;
                        ecgArray[3] = ecgInt32List[1 + ecgIndex * 8] - ecgInt32List[0 + ecgIndex * 8] / 2;
                        //avl= I - II / 2;
                        ecgArray[4] = ecgInt32List[0 + ecgIndex * 8] - ecgInt32List[1 + ecgIndex * 8] / 2;
                        //avf= II - I / 2;
                        ecgArray[5] = -(ecgInt32List[1 + ecgIndex * 8] + ecgInt32List[0 + ecgIndex * 8]) / 2;
                        //V1,V2,V3,V4,V5,V6
                        AddRecoverEcgData(ecgArray, ecgDic, ecgIndex);
                    }
                    break;
            }
        }

       /// <summary>
       /// 添加V1~V6导联数据
       /// </summary>
       /// <param name="ecgArray"></param>
       /// <param name="ecgDic"></param>
       /// <param name="ecgIndex"></param>
       private void AddRecoverEcgData(float[] ecgArray, Dictionary<int, List<float>> ecgDic, int ecgIndex)
        {
            //V1,V2,V3,V4,V5,V6
            for (int i = 6; i < 12; i++)
            {
                ecgArray[i] = _ecgInt32List[i + ecgIndex * 8 - 4];
            }
            for (int i = 0; i < 12; i++)
            {
                if (ecgDic.ContainsKey(i))
                {
                    ecgDic[i].Add(ecgArray[i]);
                }
                else
                {
                    var dataList = new List<float> {ecgArray[i]};
                    ecgDic.Add(i, dataList);
                }
            }
        }
    }
}
