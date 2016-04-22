using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.IO;
using CommonProj;
using log4net;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace EcgViewPro
{
   

    public class EcgDataDrawNew : IDisposable
    {
        double _amplitude = 10.0;//振幅
        double _paperSpeed = 25.0;

        double _samplingRate = 1000.0;

        int _dpi = 96;//一英寸的像素点个数
        private const double LenthPerInch = 25.4; //一英寸==25.4mm
        int _baseLine = 0;
        int _leadHeight = 0;
        Pen Ecg_Pen;
        Pen EcgPen;
        Graphics Ecg_Graphics;
        Bitmap Ecg_Canvas;
        public List<int> LeadInfo = new List<int>();
        Dictionary<int, List<double>> _ecgDataList;
        int FreePixs = 0;
        Point _firstPosition = new Point(0, 0);
        Point _secondPosition = new Point(0, 0);
        readonly Dictionary<string, Point> _firstPointArray = new Dictionary<string, Point>();

        //存放心电数据的字典 按照 每导联顺序进行存储
        Dictionary<int, List<float>> _ecgDataDic = new Dictionary<int, List<float>>();

        public double PerInch = 1;//振幅高度百分比（y值）
        string _isQb = "0";//0表示非起搏，1表示起搏
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //[DllImport("DiagDllProj.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool calcQrsPos(float[] pSrc, int dataCountPerLead, short sampleRate, int[] qrsPos);

        public EcgDataDrawNew()
        {
            var configFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"AppConfig.config");
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 初始化参数十二导
        /// </summary>
        /// <param name="btmp"></param>
        /// <param name="leadCount"></param>
        /// <param name="ecgTable"></param>
        /// <param name="ecgTableType"></param>
        /// <param name="newDpi"></param>
        /// <param name="leadinfo"></param>
        /// <param name="isQiBo"></param>
        public void InitEcgParameter(Bitmap btmp, int leadCount, Dictionary<int, List<float>> ecgTable, Dictionary<int, List<float>> ecgTableType, int newDpi, List<int> leadinfo, string isQiBo)
        {
            string[] wavePara = File.ReadAllText(Application.StartupPath + @"\WavePara.txt").Trim().Split(',');
            _samplingRate = int.Parse(wavePara[0].Trim());

            Ecg_Canvas = btmp;
            Ecg_Graphics = Graphics.FromImage(Ecg_Canvas);
            Ecg_Graphics.Clear(Color.White);//填充指定颜色

            Ecg_Graphics.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿
            //Ecg_Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic; //质量最高
            //Ecg_Graphics.CompositingQuality = CompositingQuality.HighQuality;//消除锯齿,最高品质


            LeadInfo = leadinfo;
            _baseLine = (btmp.Height / LeadInfo.Count) / 2;

            _leadHeight = (btmp.Height / (LeadInfo.Count / 2));
            _dpi = newDpi;

            _ecgDataDic = ecgTable;


            Ecg_Pen = new Pen(Color.Black, float.Parse(ConfigHelper.WaveSize.ToString()));
            //Ecg_Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            EcgPen = new Pen(Color.Black, float.Parse((ConfigHelper.WaveSize / 2.5).ToString()));//ConfigHelper.WaveColor
            FreePixs = int.Parse(Math.Round((double.Parse(_dpi.ToString()) / LenthPerInch) * 5).ToString());
            _isQb = isQiBo;


        }


        int _clearCount = 0;//滤掉的点数

        private void PointContrast(Pen ep, List<Point> xp, int leadindex)
        {
            var lp = new List<Point>();
            var nullP = new Point(-1, -1);
            var preP = nullP;
            for (int k = 1; k < xp.Count; k++)
            {
                if (k + 1 < xp.Count)
                {
                    if (_isQb == "1")
                    {
                        if (xp[k + 1].X - xp[k].X < 10 && xp[k + 1].X - xp[k].X >= 0)// 
                        {
                            lp.Add(xp[k]);
                        }
                    }
                    else
                    {
                        if ((xp[k + 1].X - xp[k].X < 10 && xp[k + 1].X - xp[k].X > 0) || ((xp[k].Y >= xp[k + 1].Y && xp[k].Y > xp[k - 1].Y) || (xp[k].Y <= xp[k + 1].Y && xp[k].Y < xp[k - 1].Y)))// 
                        {
                            if (!lp.Contains(xp[k]))
                            {
                                lp.Add(xp[k]);
                            }
                        }
                        else
                        {
                            if (xp[k].X == xp[k + 1].X && xp[k].Y != xp[k + 1].Y && leadindex == 0)//leadindex==0 以I导为标准
                            {
                                _clearCount++;
                            }
                        }
                    }
                }
            }
            if (_clearCount > xp.Count * 0.6)//0.7 代表滤掉的点数大于总点数的百分之七十
            {
                lp.Clear();
                lp = xp;
            }


            Ecg_Graphics.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿
            foreach (Point p in lp)
            {
                if (preP != nullP && p.X - preP.X < 10)
                {
                    Ecg_Graphics.DrawLine(ep, preP, p);
                }
                preP = p;
            }
        }

        /// <summary>
        /// 绘制打印的心电波形4X3+1---打印
        /// </summary>
        public void Draw_EcgWave_longOneLeadPrint(int drawInitHeight, int bottomHeight, double paperSpeed1, double amplitude1, double samplingRate1, int dataIndex, int dataLengthIndex)
        {
            _paperSpeed = paperSpeed1;
            _amplitude = amplitude1;
            _samplingRate = samplingRate1;

            _firstPointArray.Clear();
            drawInitHeight = drawInitHeight * FreePixs;
            bottomHeight = bottomHeight * FreePixs;

            double intervalPixCountPerPoint = (double.Parse(_paperSpeed.ToString()) / double.Parse(_samplingRate.ToString())) * (double.Parse(_dpi.ToString()) / LenthPerInch);

            var xpoint = new Dictionary<int, List<Point>>();//下坡线点集合
            var spointL = new Dictionary<int, List<Point>>();//上坡线点集合
            var xpointL = new Dictionary<int, List<Point>>();//下坡线点集合
            for (int i = 0; i < LeadInfo.Count; i++)
            {
                int leadIndex = LeadInfo[i];//取导联下标  0  1   2  3 ...11
                if (i < 6)
                {
                    if (i < 3)
                    {
                        _baseLine = ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1)) / 2 + (i * ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1))) + drawInitHeight;
                        _baseLine = _baseLine - drawInitHeight / 4 * i;
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs;
                        var fp = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), fp);
                    }
                    else
                    {
                        _baseLine = ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 3) * ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1))) + drawInitHeight;
                        _baseLine = _baseLine - drawInitHeight / 4 * (i - 3);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + Ecg_Canvas.Width / 4;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + Ecg_Canvas.Width / 4;
                        var fp = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), fp);
                    }

                }
                else
                {
                    if (i < 9)
                    {
                        _baseLine = ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 6) * ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1))) + drawInitHeight;
                        _baseLine = _baseLine - drawInitHeight / 4 * (i - 6);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + Ecg_Canvas.Width / 2;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + Ecg_Canvas.Width / 2;
                        var fp = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), fp);
                    }
                    else
                    {
                        _baseLine = ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 9) * ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1))) + drawInitHeight;
                        _baseLine = _baseLine - drawInitHeight / 4 * (i - 9);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + 3 * Ecg_Canvas.Width / 4;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + 3 * Ecg_Canvas.Width / 4;
                        var fp2 = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), fp2);
                    }


                }
                for (int b = dataIndex; b < _ecgDataDic[leadIndex].Count; b += (1000 / ConfigHelper.PrintSampleRate))
                {
                    if (i < 6)
                    {
                        if (i < 3)
                        {
                            if (_firstPosition.X > Ecg_Canvas.Width / 4 - 5)
                                break;
                        }
                        else
                        {
                            if (_firstPosition.X > Ecg_Canvas.Width / 2 - 5)
                                break;
                        }
                    }
                    else
                    {
                        if (i < 9)
                        {
                            if (_firstPosition.X > 3 * Ecg_Canvas.Width / 4)
                                break;
                        }
                        else
                        {
                            if (_firstPosition.X > Ecg_Canvas.Width)
                                break;
                        }
                    }
                    float yValues = 0;
                    try
                    {
                        yValues = _ecgDataDic[leadIndex][b] * (float)(300 / 25.4) * (float)_amplitude * (float)PerInch;
                    }
                    catch
                    {
                    }
                    _secondPosition.Y = _baseLine - (Int32)yValues;//后一点Y轴位置

                    double x = double.Parse((b - dataIndex).ToString()) * intervalPixCountPerPoint;
                    int nextX = (int.Parse(Math.Round(x).ToString()));
                    if (Math.Abs(_firstPosition.X - _secondPosition.X) < 5)
                    {
                        if (i < 6)
                        {
                            if (i < 3)
                            {
                                _secondPosition.X = nextX + FreePixs;


                            }
                            else
                            {
                                _secondPosition.X = Ecg_Canvas.Width / 4 + FreePixs + nextX;

                            }
                        }
                        else
                        {
                            if (i < 9)
                            {
                                _secondPosition.X = Ecg_Canvas.Width / 2 + FreePixs + nextX;

                            }
                            else
                            {
                                _secondPosition.X = 3 * Ecg_Canvas.Width / 4 + FreePixs + nextX;

                            }
                        }
                        if (_firstPosition.X != _secondPosition.X && _firstPosition.Y == _secondPosition.Y)// 
                        {

                            Ecg_Graphics.DrawLine(Ecg_Pen, _firstPosition, _secondPosition);

                        }
                        else
                        {
                            if (!xpoint.ContainsKey(i))
                            {
                                var xp = new List<Point> { _firstPosition };
                                xpoint.Add(i, xp);
                            }
                            else
                            {
                                xpoint[i].Add(_firstPosition);
                            }
                        }
                    }

                    _firstPosition = _secondPosition;
                }
                PointContrast(EcgPen, xpoint[i], leadIndex);//绘制所有导联的QRS波群

            }

            for (int i = 0; i < 1; i++)
            {
                int leadIndex = LeadInfo[ConfigHelper.SingleLead];//取导联下标  0  1   2  3 ...11
                _baseLine = ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1)) / 2 + ((i + 3) * ((Ecg_Canvas.Height - drawInitHeight - bottomHeight) / ((LeadInfo.Count / 4) + 1))) + drawInitHeight;
                _baseLine = _baseLine - drawInitHeight / 4 * (i + 3);
                _firstPosition.Y = _baseLine;
                _firstPosition.X = FreePixs;
                _secondPosition.Y = _baseLine;
                _secondPosition.X = FreePixs;
                var fp = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                _firstPointArray.Add((i + 12).ToString(), fp);
                if (_ecgDataDic.Count > 0)
                    for (int b = dataLengthIndex; b < _ecgDataDic[leadIndex].Count; b += (1000 / ConfigHelper.PrintSampleRate))
                    {
                        if (_firstPosition.X > Ecg_Canvas.Width)
                            break;
                        double yValues = 0;
                        try
                        {
                            yValues = _ecgDataDic[leadIndex][b] * (float)(300 / 25.4) * (float)_amplitude * (float)PerInch;
                        }
                        catch
                        {
                        }
                        _secondPosition.Y = _baseLine - (Int32)yValues;//后一点Y轴位置
                        double x = double.Parse((b - dataLengthIndex).ToString()) * intervalPixCountPerPoint;
                        int nextX = (int.Parse(Math.Round(x).ToString()));
                        if (Math.Abs(_firstPosition.X - _secondPosition.X) < 5)
                        {
                            _secondPosition.X = nextX + FreePixs;

                            if (_firstPosition.X != _secondPosition.X && _firstPosition.Y == _secondPosition.Y)// 
                            {
                                if (!spointL.ContainsKey(leadIndex))
                                {
                                    var sp = new List<Point> { _firstPosition };
                                    spointL.Add(leadIndex, sp);
                                }
                                else
                                {
                                    spointL[leadIndex].Add(_firstPosition);
                                }
                                Ecg_Graphics.DrawLine(Ecg_Pen, _firstPosition, _secondPosition);

                            }
                            else
                            {
                                if (!xpointL.ContainsKey(leadIndex))
                                {
                                    var xp = new List<Point> { _firstPosition };
                                    xpointL.Add(leadIndex, xp);
                                }
                                else
                                {
                                    xpointL[leadIndex].Add(_firstPosition);
                                }
                            }
                        }
                        _firstPosition = _secondPosition;

                    }

                PointContrast(EcgPen, xpointL[leadIndex], leadIndex);//绘制所有导联的QRS波群
            }
        }




        /// <summary>
        /// 绘制心电报告的报告头---打印
        /// </summary>
        public void Draw_ReportHeadInfo(string reportHeadTile, string sectionName, string idStr)
        {
            var pen1 = new Pen(ConfigHelper.WaveColor, float.Parse("4"));
            var font1 = new Font("隶书", 20);
            Brush brush = Brushes.Black;
            float aa = ((20 * 300) / 96) * reportHeadTile.Length;
            var point2 = new PointF((Ecg_Canvas.Width - aa) / 2 - ((20 * 300) / 96) * 3, FreePixs / 2);
            Ecg_Graphics.DrawString(reportHeadTile, font1, brush, point2);
            var font = new Font("宋体", 9, FontStyle.Bold);
            var pointId = new PointF(Ecg_Canvas.Width - 3400, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString("ID：" + idStr, font, brush, pointId);

            Ecg_Graphics.DrawLine(pen1, 0, FreePixs * 4 - 100, Ecg_Canvas.Width, FreePixs * 4 - 100);//第一条横线
        }


        /// <summary>
        /// 绘制患者的心电识别的参数--打印
        /// </summary>
        public void Draw_EcgInfo(string[] diagInfoList, bool isbool)
        {
            var pen1 = new Pen(ConfigHelper.WaveColor, float.Parse("4"));
            var font1 = new Font("宋体", 9, FontStyle.Bold);
            Brush brush = Brushes.Black;

            var point = new PointF(500, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[0], font1, brush, point);//姓名

            point = new PointF(800, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[1], font1, brush, point);//性别

            point = new PointF(1150, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[2], font1, brush, point);//年龄

            point = new PointF(1450, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[12], font1, brush, point);//住院号

            point = new PointF(1750, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[10], font1, brush, point);//病室

            point = new PointF(2050, FreePixs * 4 - 80);
            Ecg_Graphics.DrawString(diagInfoList[11], font1, brush, point);//床号

            point = new PointF(10, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[4], font1, brush, point);//P-R

            point = new PointF(500, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[5], font1, brush, point);//QRS

            point = new PointF(800, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[9], font1, brush, point);//心率

            point = new PointF(1150, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[6], font1, brush, point);//QT/QTC

            point = new PointF(1550, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[7], font1, brush, point);//QRS电轴

            point = new PointF(1850, FreePixs * 4 - 30);
            Ecg_Graphics.DrawString(diagInfoList[8], font1, brush, point);//RV5/SV1

            point = new PointF(10, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[17], font1, brush, point);//LEU

            point = new PointF(500, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[18], font1, brush, point);//NIT

            point = new PointF(800, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[19], font1, brush, point);//UBG

            point = new PointF(1150, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[20], font1, brush, point);//PRO

            point = new PointF(1550, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[21], font1, brush, point);//BLD

            point = new PointF(1850, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[22], font1, brush, point);//KET

            point = new PointF(2150, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[23], font1, brush, point);//BIL

            point = new PointF(2450, FreePixs * 4 + 20);
            Ecg_Graphics.DrawString(diagInfoList[24], font1, brush, point);//GLU


            point = new PointF(10, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[13], font1, brush, point);//血压

            point = new PointF(500, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[14], font1, brush, point);//血氧

            point = new PointF(800, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[15], font1, brush, point);//血糖

            point = new PointF(1150, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[16], font1, brush, point);//体温

            point = new PointF(1550, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[25], font1, brush, point);//PH

            point = new PointF(1850, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[26], font1, brush, point);//VC

            point = new PointF(2150, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(diagInfoList[27], font1, brush, point);//SG


            if (isbool)
            {
                Ecg_Graphics.DrawLine(pen1, 0, FreePixs * 8 - 110, Ecg_Canvas.Width, FreePixs * 8 - 110);//第二条横线
            }
        }


        /// <summary>
        /// 绘制医生的诊断结果-----打印
        /// </summary>
        public void Draw_DiagInfo(string diagInfoContent, string reportDoctorName, string reportDate, string filter, string collectTime, string dept, string amp, string ps, Image img, string addr, bool isbool)
        {
            var diagresultecontent = new string[diagInfoContent.Length / 48 + 1];
            for (int a = 0; a < diagInfoContent.Length / 48 + 1; a++)
            {
                if (a < diagInfoContent.Length / 48)
                    diagresultecontent[a] = diagInfoContent.Substring(a * 48, 48);
                else
                    diagresultecontent[a] = diagInfoContent.Substring(a * 48, diagInfoContent.Length - a * 48);
            }
            var pen1 = new Pen(ConfigHelper.WaveColor, float.Parse("4"));
            var font1 = new Font("宋体", 9, FontStyle.Bold);
            Brush brush = Brushes.Black;
            if (isbool)
            {
                Ecg_Graphics.DrawLine(pen1, 0, Ecg_Canvas.Height - FreePixs * 6, Ecg_Canvas.Width, Ecg_Canvas.Height - FreePixs * 6);//第三条横线
            }
            var point1 = new PointF(9, Ecg_Canvas.Height - FreePixs * 6 + 50);
            Ecg_Graphics.DrawString("诊断提示：", font1, brush, point1);//诊断结果
            for (int i = 0; i < diagresultecontent.Length; i++)
            {
                var point5 = new PointF(230, Ecg_Canvas.Height - FreePixs * (6 - i) + 50);
                Ecg_Graphics.DrawString(diagresultecontent[i].Trim(), font1, brush, point5);//诊断结果
            }

            var pAddr = new PointF(Ecg_Canvas.Width - 3400, Ecg_Canvas.Height - FreePixs * 2);
            Ecg_Graphics.DrawString("地址：" + addr, font1, brush, pAddr);//地址

            var pointb = new PointF(Ecg_Canvas.Width - 1800, Ecg_Canvas.Height - FreePixs * 2);
            Ecg_Graphics.DrawString("科室：" + dept, font1, brush, pointb);//科室

            var point2 = new PointF(Ecg_Canvas.Width - 1200, Ecg_Canvas.Height - FreePixs * 2);
            if (img == null)
                Ecg_Graphics.DrawString("报告医生：" + reportDoctorName, font1, brush, point2);//报告医生
            else
            {
                using (var bmpSource = new Bitmap(((Bitmap)img), 160, 80))
                {
                    bmpSource.SetResolution(200, 200);
                    var pointImg = new PointF(Ecg_Canvas.Width - 1000, Ecg_Canvas.Height - FreePixs * 3.0f);
                    Ecg_Graphics.DrawString("报告医生：", font1, brush, point2);//报告医生
                    Ecg_Graphics.DrawImage(bmpSource, pointImg);
                    // bmpSource.Dispose();
                }
            }

            var point9 = new PointF(Ecg_Canvas.Width - 600, Ecg_Canvas.Height - FreePixs * 2);
            Ecg_Graphics.DrawString("报告日期：" + reportDate, font1, brush, point9);//报告日期

            var point10 = new PointF(2450, FreePixs * 4 + 70);
            Ecg_Graphics.DrawString(ps + "    " + amp + "    " + filter, font1, brush, point10);//振幅 走纸速度  滤波
            var point11 = new PointF(Ecg_Canvas.Width - 420, Ecg_Canvas.Height - FreePixs * 7 + 10);
            Ecg_Graphics.DrawString(collectTime, font1, brush, point11);//波形的起始时间点

            Ecg_Graphics.DrawLine(pen1, 0, Ecg_Canvas.Height - FreePixs, Ecg_Canvas.Width, Ecg_Canvas.Height - FreePixs);//第四条横线

            var font99 = new Font("宋体", 9, FontStyle.Bold);
            var point99 = new PointF(Ecg_Canvas.Width - 3400, Ecg_Canvas.Height - (float)(FreePixs * 0.7));
            Ecg_Graphics.DrawString("【" + ConfigHelper.EcgReportTitle + "】", font99, brush, point99);//报告日期

        }

        /// <summary>
        ///背景网格---显示
        /// </summary>
        public void Draw_EcgBackGroundGrid()
        {
            var ecgP = new Pen(ConfigHelper.WaveGridColor, float.Parse("1"));
            bool shuxianFlag = false;
            const float pointCountPerMM = 4f; //
            float x = 0; int xNum = 0;
            float y = 0; int yNum = 0;
            float divY, divX;
            divY = Ecg_Canvas.Height / pointCountPerMM + 1;
            divX = Ecg_Canvas.Width / pointCountPerMM + 1;
            Ecg_Graphics.SmoothingMode = SmoothingMode.None;//保证网格线的清晰
            for (int p = 0; p < (int)divY; p++)
            {
                for (int R = 0; R < (int)divX; R++)
                {
                    if (xNum % 5 == 0 && !shuxianFlag)
                    {
                        Ecg_Graphics.DrawLine(ecgP, x + 0.3f, 0, x + 0.3f, Ecg_Canvas.Height);
                    }
                    x += pointCountPerMM;

                    xNum++;
                    //x += float.Parse(Math.Round(double.Parse(PointCountPerMM.ToString("0.0"))).ToString());
                    if (x < Ecg_Canvas.Width && y < Ecg_Canvas.Height)
                    {
                        if (xNum % 5 != 0 && yNum % 5 != 0)
                        {
                            //Ecg_Graphics.SmoothingMode = SmoothingMode.AntiAlias;//保证网格线的清晰
                            var sbrush = new SolidBrush(ConfigHelper.WaveGridColor);
                            Ecg_Graphics.FillEllipse(sbrush, x, y, 1.45f, 1.45f);
                        }
                    }
                    else
                    {
                        x = 0;
                        break;
                    }
                }
                shuxianFlag = true;
                if (yNum % 5 == 0)
                {
                    Ecg_Graphics.DrawLine(ecgP, 0, y + 0.3f, Ecg_Canvas.Width, y + 0.3f);
                }
                yNum++;
                y += pointCountPerMM;

                xNum = 0;


                if (y > Ecg_Canvas.Height)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 绘制心电图的背景网格-----打印
        /// </summary>
        public void Draw_EcgBackGroundGrid(int height1, int height2, int penWidth)
        {
            var ep = new Pen(Color.Black, float.Parse("1.5"));

            if (ConfigHelper.IsDashOrSolid)
            {
                ep.DashStyle = DashStyle.Solid;
            }
            else
            {
                ep.DashStyle = DashStyle.Dash;
            }

            const float PointCountPerMM = 12; //每个小网格间距 12mm;// Math.Abs(float.Parse(Dpi.ToString()) / (float)LenthPerInch);
            float heightTop = height1 * (PointCountPerMM);//+ 0.2f
            float heightBottm = height2 * (PointCountPerMM - 0.2f);
            float x = 0;
            float y = 0;
            int cHeight = (int)(heightBottm);//网格高度


            Ecg_Graphics.SmoothingMode = SmoothingMode.None;//保证网格线的清晰
            for (int i = Ecg_Canvas.Width, j = 0; i >= -72; i -= (int)PointCountPerMM, j++)//72 代表宽度相差6个小格间距
            {
                if (j % 5 == 0)
                {
                    x = (float)Math.Round((i + j / 5 * 1.2), 2);//每个大格相差1.2mm
                    Ecg_Graphics.DrawLine(ep, x, heightTop, x, cHeight);
                }

            }
            //绘制横线
            for (int i = cHeight, j = 0; i >= heightTop - 36; i -= (int)PointCountPerMM, j++)//36 代表高度相差3个小格的间距
            {
                if (j % 5 == 0)
                {

                    y = (float)Math.Round((i + j / 5 * 1.2), 2);//每个大格相差1.2mm
                    Ecg_Graphics.DrawLine(ep, 0, y, Ecg_Canvas.Width, y);
                }
                else
                {
                    y = (float)Math.Round((i + j * 0.24), 2);
                    for (int k = Ecg_Canvas.Width, t = 0; k >= -72; k -= (int)PointCountPerMM, t++)
                    {
                        x = (float)Math.Round((k + t * 0.24), 2);//每个小格相差0.24
                        if ((int)y < cHeight && (int)x < Ecg_Canvas.Width)
                        {
                            if (t % 5 != 0)
                            {
                                Ecg_Canvas.SetPixel((int)x, (int)y, Color.Black);//ConfigHelper.WaveColor
                            }
                        }
                    }
                }
            }


        }


        /// <summary>
        /// 4X3+1---显示和打印 标压名称
        /// </summary>
        /// <param name="cVoltagescale">定标电压高度比例</param>
        /// <param name="isLeader"></param>
        /// <param name="leaderType"></param>
        public void Draw_CalibrationVoltage_And_LeadName_1(double cVoltagescale, bool isLeader, string leaderType)
        {
            Ecg_Pen = new Pen(Color.Black, float.Parse("1"));
            var leadNameArray = new string[12] { "I", "II", "III", "aVR", "aVL", "aVF", "V1", "V2", "V3", "V4", "V5", "V6" };
            for (int d = 0; d < LeadInfo.Count; d++)
            {
                if (d < 6)
                {
                    if (d < 3)
                    {
                        Ecg_Graphics.DrawLine(Ecg_Pen, 0, _firstPointArray[LeadInfo[d].ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);

                        Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                        Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                        Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);

                        Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 3).ToString()) * 3, _firstPointArray[LeadInfo[d].ToString()].Y);

                        string str = leadNameArray[LeadInfo[d]];
                        Font font = new Font("宋体", 11);
                        Brush brush = Brushes.Black;
                        if (d < _firstPointArray.Count)
                        {
                            PointF point = new PointF(0, _firstPointArray[LeadInfo[d].ToString()].Y);
                            Ecg_Graphics.DrawString(str, font, brush, point);
                        }
                    }
                    else
                    {
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 4, _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);

                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);

                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 3).ToString()) * 3, _firstPointArray[LeadInfo[d].ToString()].Y);
                        string str = leadNameArray[LeadInfo[d]];
                        Font font = new Font("宋体", 11);
                        Brush brush = Brushes.Black;
                        if (d < _firstPointArray.Count)
                        {
                            PointF point = new PointF(Ecg_Canvas.Width / 4, _firstPointArray[LeadInfo[d].ToString()].Y);
                            Ecg_Graphics.DrawString(str, font, brush, point);
                        }
                    }
                }
                else
                {
                    if (d < 9)
                    {
                        //1
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 2, _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);
                        //2
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()));
                        //3
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()), Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()));
                        //4
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()), Ecg_Canvas.Width / 2 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);
                        //5
                        Ecg_Graphics.DrawLine(Ecg_Pen, Ecg_Canvas.Width / 2 + (FreePixs / 6) * 5, _firstPointArray[LeadInfo[d].ToString()].Y, Ecg_Canvas.Width / 2 + FreePixs, _firstPointArray[LeadInfo[d].ToString()].Y);
                        string str = leadNameArray[LeadInfo[d]];
                        Font font = new Font("宋体", 11);
                        Brush brush = Brushes.Black;
                        if (d < _firstPointArray.Count)
                        {
                            PointF point = new PointF(Ecg_Canvas.Width / 2, _firstPointArray[LeadInfo[d].ToString()].Y);

                            Ecg_Graphics.DrawString(str, font, brush, point);

                        }
                    }
                    else
                    {
                        //1
                        Ecg_Graphics.DrawLine(Ecg_Pen, 3 * Ecg_Canvas.Width / 4, _firstPointArray[LeadInfo[d].ToString()].Y, 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);
                        //2
                        Ecg_Graphics.DrawLine(Ecg_Pen, 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y, 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()));
                        //3
                        Ecg_Graphics.DrawLine(Ecg_Pen, 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()), 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()));
                        //4
                        Ecg_Graphics.DrawLine(Ecg_Pen, 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y - Int16.Parse(Math.Round((cVoltagescale * double.Parse(FreePixs.ToString()))).ToString()), 3 * Ecg_Canvas.Width / 4 + Int16.Parse(Math.Round((double.Parse(FreePixs.ToString()) / 6) * 5).ToString()), _firstPointArray[LeadInfo[d].ToString()].Y);
                        //5
                        Ecg_Graphics.DrawLine(Ecg_Pen, 3 * Ecg_Canvas.Width / 4 + (FreePixs / 6) * 5, _firstPointArray[LeadInfo[d].ToString()].Y, 3 * Ecg_Canvas.Width / 4 + FreePixs, _firstPointArray[LeadInfo[d].ToString()].Y);
                        string str = leadNameArray[LeadInfo[d]];
                        Font font = new Font("宋体", 11);
                        Brush brush = Brushes.Black;
                        if (d < _firstPointArray.Count)
                        {
                            PointF point = new PointF(3 * Ecg_Canvas.Width / 4, _firstPointArray[LeadInfo[d].ToString()].Y);

                            Ecg_Graphics.DrawString(str, font, brush, point);
                        }

                    }

                }
            }




            for (int d = 0; d < 1; d++)
            {
                Ecg_Graphics.DrawLine(Ecg_Pen, 0, _firstPointArray[(d + 12).ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[(d + 12).ToString()].Y);

                Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[(d + 12).ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[(d + 12).ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 5).ToString()), _firstPointArray[(d + 12).ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[(d + 12).ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()));

                Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[(d + 12).ToString()].Y - Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * cVoltagescale).ToString()), Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[(d + 12).ToString()].Y);

                Ecg_Graphics.DrawLine(Ecg_Pen, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) * 5 / 6).ToString()), _firstPointArray[(d + 12).ToString()].Y, Int16.Parse(Math.Round(double.Parse(FreePixs.ToString()) / 3).ToString()) * 3, _firstPointArray[(d + 12).ToString()].Y);
                string str = leadNameArray[ConfigHelper.SingleLead];
                Font font = new Font("宋体", 11);
                Brush brush = Brushes.Black;
                if (d < _firstPointArray.Count)
                {
                    PointF point = new PointF(0, _firstPointArray[(d + 12).ToString()].Y);

                    Ecg_Graphics.DrawString(str, font, brush, point);

                }
            }


        }

        public int EcgPacksIndex = 1;
        /// <summary>
        /// 滚动条绘制心电波形
        /// </summary>
        const int LeadWaveLenth = 4;//波形和表压的间距



        /// <summary>
        /// 4X3+1---显示
        /// </summary>
        public void Draw_EcgWave_One_Scroll(double paperSpeed1, double amplitude1, double samplingRate1, int dataIndex)
        {
            _leadHeight = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1));
            _paperSpeed = paperSpeed1;
            _amplitude = amplitude1;
            _samplingRate = samplingRate1;

            Ecg_Pen = new Pen(ConfigHelper.WaveColor, float.Parse("1"));

            Pen EcgPen = new Pen(ConfigHelper.WaveColor, float.Parse("0.1"));//ConfigHelper.WaveColor
            double intervalPixCountPerPoint = (double.Parse(_paperSpeed.ToString()) / double.Parse(_samplingRate.ToString())) * (double.Parse(_dpi.ToString()) / LenthPerInch);
            var spoint = new Dictionary<int, List<Point>>();//上坡线点集合
            var xpoint = new Dictionary<int, List<Point>>();//下坡线点集合


            var xpointL = new Dictionary<int, List<Point>>();//下坡线点集合
            for (int i = 0; i < LeadInfo.Count; i++)
            {
                int leadIndex = LeadInfo[i];//取导联下标  0  1   2  3 ...11
                if (i < 6)
                {
                    if (i < 3)
                    {
                        _baseLine = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1)) / 2 + (i * _leadHeight);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs;
                        Point FP = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), FP);
                    }
                    else
                    {
                        _baseLine = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 3) * _leadHeight);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + Ecg_Canvas.Width / 4;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + Ecg_Canvas.Width / 4;
                        Point FP = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), FP);
                    }
                }
                else
                {
                    if (i < 9)
                    {
                        _baseLine = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 6) * _leadHeight);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + Ecg_Canvas.Width / 2;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + Ecg_Canvas.Width / 2;
                        Point FP = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), FP);
                    }
                    else
                    {
                        _baseLine = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1)) / 2 + ((i - 9) * _leadHeight);
                        _firstPosition.Y = _baseLine;
                        _firstPosition.X = FreePixs + 3 * Ecg_Canvas.Width / 4;
                        _secondPosition.Y = _baseLine;
                        _secondPosition.X = FreePixs + 3 * Ecg_Canvas.Width / 4;
                        Point FP = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                        _firstPointArray.Add(leadIndex.ToString(), FP);

                    }
                }
                if (_ecgDataDic.Count > 0)
                    for (int b = dataIndex; b < _ecgDataDic[leadIndex].Count; b += (1000 / ConfigHelper.PrintSampleRate))
                    {
                        if (i < 6)
                        {
                            if (i < 3)
                            {
                                if (_firstPosition.X >= Ecg_Canvas.Width / 4 - LeadWaveLenth)
                                    break;
                            }
                            else
                            {
                                if (_firstPosition.X >= Ecg_Canvas.Width / 2 - LeadWaveLenth)
                                    break;
                            }
                        }
                        else
                        {
                            if (i < 9)
                            {
                                if (_firstPosition.X >= 3 * Ecg_Canvas.Width / 4)
                                    break;
                            }
                            else
                            {
                                if (_firstPosition.X > Ecg_Canvas.Width)
                                    break;
                            }
                        }

                        double yValues = 0;
                        try
                        {
                            yValues = _ecgDataDic[leadIndex][b] * (float)(_dpi / LenthPerInch) * _amplitude * PerInch;
                        }
                        catch
                        {
                        }
                        _secondPosition.Y = _baseLine - (Int32)yValues;//后一点Y轴位置

                        double x = double.Parse((b - dataIndex).ToString()) * intervalPixCountPerPoint;
                        int nextX = (int.Parse(Math.Round(x).ToString()));
                        if (Math.Abs(_firstPosition.X - _secondPosition.X) < LeadWaveLenth)
                        {
                            if (i < 6)
                            {
                                if (i < 3)
                                {
                                    _secondPosition.X = nextX + FreePixs;
                                    //Ecg_Graphics.DrawLine(Ecg_Pen, FirstPosition, SecondPosition);

                                }
                                else
                                {
                                    _secondPosition.X = Ecg_Canvas.Width / 4 + FreePixs + nextX;
                                    //Ecg_Graphics.DrawLine(Ecg_Pen, FirstPosition, SecondPosition);

                                }
                            }
                            else
                            {
                                if (i < 9)
                                {
                                    _secondPosition.X = Ecg_Canvas.Width / 2 + FreePixs + nextX;
                                    //Ecg_Graphics.DrawLine(Ecg_Pen, FirstPosition, SecondPosition);

                                }
                                else
                                {
                                    _secondPosition.X = 3 * Ecg_Canvas.Width / 4 + FreePixs + nextX;
                                    //Ecg_Graphics.DrawLine(Ecg_Pen, FirstPosition, SecondPosition);

                                }
                            }

                            if (_firstPosition.X != _secondPosition.X && _firstPosition.Y == _secondPosition.Y)// 
                            {
                                if (!spoint.ContainsKey(i))
                                {
                                    var sp = new List<Point> { _firstPosition };
                                    spoint.Add(i, sp);
                                }
                                else
                                {
                                    spoint[i].Add(_firstPosition);
                                }
                                Ecg_Graphics.DrawLine(Ecg_Pen, _firstPosition, _secondPosition);

                            }
                            else
                            {
                                if (!xpoint.ContainsKey(i))
                                {
                                    var xp = new List<Point> { _firstPosition };
                                    xpoint.Add(i, xp);
                                }
                                else
                                {
                                    xpoint[i].Add(_firstPosition);
                                }
                            }


                        }
                        _firstPosition = _secondPosition;
                    }
                PointContrast(EcgPen, xpoint[leadIndex], leadIndex);//绘制所有导联的QRS波群
            }

            for (int i = 0; i < 1; i++)
            {
                int leadIndex = LeadInfo[ConfigHelper.SingleLead];//取导联下标  0  1   2  3 ...11

                _baseLine = (Ecg_Canvas.Height / ((LeadInfo.Count / 4) + 1)) / 2 + ((i + 3) * _leadHeight);
                _firstPosition.Y = _baseLine;
                _firstPosition.X = FreePixs;
                _secondPosition.Y = _baseLine;
                _secondPosition.X = FreePixs;
                var fp = new Point(_firstPosition.X + FreePixs, _firstPosition.Y);
                _firstPointArray.Add((i + 12).ToString(), fp);
                if (_ecgDataDic.Count > 0)
                    for (int b = dataIndex; b < _ecgDataDic[leadIndex].Count - LongLeadRemove; b += (1000 / ConfigHelper.PrintSampleRate))
                    {

                        if (_firstPosition.X > Ecg_Canvas.Width)
                            break;
                        double yValues = 0;
                        try
                        {
                            yValues = _ecgDataDic[leadIndex][b] * (float)(_dpi / LenthPerInch) * _amplitude * PerInch;
                        }
                        catch
                        {
                        }
                        _secondPosition.Y = _baseLine - (Int32)yValues;//后一点Y轴位置
                        double x = double.Parse((b - dataIndex).ToString()) * intervalPixCountPerPoint;
                        int nextX = (int.Parse(Math.Round(x).ToString()));
                        if (Math.Abs(_firstPosition.X - _secondPosition.X) < LeadWaveLenth)
                        {

                            _secondPosition.X = nextX + FreePixs;
                            if (_firstPosition.X != _secondPosition.X && _firstPosition.Y == _secondPosition.Y)// 
                            {
                                Ecg_Graphics.DrawLine(Ecg_Pen, _firstPosition, _secondPosition);

                            }
                            else
                            {
                                if (!xpointL.ContainsKey(leadIndex))
                                {
                                    var xp = new List<Point> { _firstPosition };
                                    xpointL.Add(leadIndex, xp);
                                }
                                else
                                {
                                    xpointL[leadIndex].Add(_firstPosition);
                                }
                            }

                            //Ecg_Graphics.DrawLine(Ecg_Pen, FirstPosition, SecondPosition);

                        }

                        _firstPosition = _secondPosition;

                    }
                PointContrast(EcgPen, xpointL[leadIndex], leadIndex);//绘制所有导联的QRS波群
            }

        }

        private const int LongLeadRemove = 0; //画长导是显示多了0个小格 5个小格1000



        //**************************************************************************************************************************************************
        /// <summary>
        /// 初始化绘制---显示
        /// </summary>
        /// <param name="btmp"></param>
        /// <param name="graphics"></param>
        /// <param name="leadCount"></param>
        /// <param name="ecgTable"></param>
        /// <param name="ecgTableType"></param>
        /// <param name="newDpi"></param>
        /// <param name="leadinfo"></param>
        /// <param name="isQiBo"></param>
        public void InitEcgParameter_Scroll(Bitmap btmp, Graphics graphics, int leadCount, Dictionary<int, List<float>> ecgTable, Dictionary<int, List<float>> ecgTableType, int newDpi, List<int> leadinfo, string isQiBo)
        {
            string[] wavePara = File.ReadAllText(Application.StartupPath + @"\WavePara.txt").Trim().Split(',');
            _samplingRate = int.Parse(wavePara[0].Trim());
            Ecg_Canvas = btmp;
            Ecg_Graphics = graphics;
            Ecg_Graphics.Clear(ConfigHelper.WaveBackColor);//填充指定颜色

            Ecg_Graphics.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿
            //Ecg_Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic; //质量最高
            // Ecg_Graphics.CompositingQuality = CompositingQuality.HighQuality;//消除锯齿,最高品质


            LeadInfo = leadinfo;
            _baseLine = (btmp.Height / LeadInfo.Count) / 2;
            _leadHeight = (btmp.Height / (LeadInfo.Count / 2));
            _dpi = newDpi;
            _ecgDataDic = ecgTable;

            Ecg_Pen = new Pen(ConfigHelper.WaveColor, float.Parse("1"));
            Ecg_Pen.DashStyle = DashStyle.Solid;
            Ecg_Pen.DashCap = DashCap.Round;
            Ecg_Pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };

            EcgPen = new Pen(ConfigHelper.WaveColor, float.Parse("0.1"));//ConfigHelper.WaveColor
            EcgPen.DashCap = DashCap.Round;

            FreePixs = int.Parse(Math.Round((double.Parse(_dpi.ToString()) / LenthPerInch) * 5).ToString());
            _isQb = isQiBo;
        }


        /// <summary>
        /// 判读是那个导联名称
        /// </summary>
        /// <param name="leaderType"></param>
        /// <returns></returns>
        public string[] GetLeaderType(string leaderType)
        {
            var strLeadNameArray = new string[12] { "I", "II", "III", "aVR", "aVL", "aVF", "V1", "V2", "V3", "V4", "V5", "V6" };

            return strLeadNameArray;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~EcgDataDrawNew()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (EcgPen != null)
                {
                    EcgPen.Dispose();
                    EcgPen = null;
                }
                if (Ecg_Pen != null)
                {
                    Ecg_Pen.Dispose();
                    Ecg_Pen = null;
                }
            }
        }


    }
}
