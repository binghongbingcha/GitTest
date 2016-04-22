using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

//断线 ok
//V1-V6 ok
//重绘 ok
//定标电压
//*缩放

namespace EcgViewPro
{
    class RtWave
    {
        int[] _cache = null;

        public void Reset()
        {
            _bParamChange = true;
        }
        public void PaintOffset(Graphics g, Rectangle r, int[] oriData)
        {
            //return;
            if (_lastRect == r)
            {//绘图矩形未发生改变

            }
            else
            {
                _lastRect = r;
                _bParamChange = true;
            }

            if (_bParamChange)
            {//参数变化时，重新绘制背景，重绘屏幕的波形
                CalcParam(r);
                PaintBackGround(g, r);
            }

            //绘制波形增量
            AlphaMask(g, r, oriData);
            _bParamChange = false;
        }

        private void PaintBackGround(Graphics g, Rectangle r)
        {
            Pen p = new Pen(Color.DarkRed, 2);
            
            int WAVE_WIDTH = (r.Width - VIEW_GAP) / 2 - RULER_WIDTH;
            int rightViewX = RULER_WIDTH + WAVE_WIDTH + VIEW_GAP;



            string[] dict = { "I", "II", "III", "aVR", "aVL", "avF", "V1", "V2", "V3", "V4", "V5", "V6" };
            Font font = new Font("宋体", FONT_SIZE);
            Brush brush = Brushes.Lime;

            ////标尺
            short k = 0, l = 0;
            if (_magCo < 3)
            {
                //画标压
                for (k = 0; k < 12; k++)
                {
                    if (k < 6)
                    {
                        g.DrawLine(p, new Point(r.Left, (int)(_baselineOffset + ((float)l * _heightPerLead))),
                            new Point(r.Left + 0 + (int)(_pixelPerMv / 8), (int)(_baselineOffset + ((float)l * _heightPerLead))));//-
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 8), (int)(_baselineOffset + ((float)l * _heightPerLead))),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 8), (int)(_baselineOffset + ((float)l * _heightPerLead) - _pixelPerMv))); //|
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 8), (int)(_baselineOffset + ((float)l * _heightPerLead) - _pixelPerMv)),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 3), (int)(_baselineOffset + ((float)l * _heightPerLead) - _pixelPerMv))); //-
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 3), (int)(_baselineOffset + ((float)l * _heightPerLead) - _pixelPerMv)),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 3), (int)(_baselineOffset + ((float)l * _heightPerLead)))); //|
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 3), (int)(_baselineOffset + ((float)l * _heightPerLead))),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv * 4 / 8), (int)(_baselineOffset + ((float)l * _heightPerLead))));

                        g.DrawString(dict[k], font, brush,
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 8), (int)(_baselineOffset + ((float)l * _heightPerLead)) + FONT_SIZE /2));
                    }
                    else
                    {
                        g.DrawLine(p, new Point(r.Left+ 0 + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead))),
                           new Point(r.Left+ 0 + (int)(_pixelPerMv / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead))));//-
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead))),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead) - _pixelPerMv))); //|
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead) - _pixelPerMv)),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 3) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead) - _pixelPerMv))); //-
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 3) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead) - _pixelPerMv)),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 3) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead)))); //|
                        g.DrawLine(p, new Point(r.Left+ 0 + (int)(_pixelPerMv / 3) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead))),
                            new Point(r.Left+ 0 + (int)(_pixelPerMv * 4 / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead))));
              
                        g.DrawString(dict[k], font, brush,
                            new Point(r.Left+ 0 + (int)(_pixelPerMv / 8) + rightViewX, (int)(_baselineOffset + ((float)(l - 6) * _heightPerLead)) + FONT_SIZE/2));
                    }
                    l++;
                }
            }
            p.Dispose();
            font.Dispose();
        }

        private void AlphaMask(Graphics g, Rectangle r, int[] oriData)
        {
            int[] data = null;

            if (_cache != null && _cache.Length > 0)
            {
                data = new int[_cache.Length + oriData.Length];
                _cache.CopyTo(data, 0);
                oriData.CopyTo(data, _cache.Length);
            }
            else
            {
                data = oriData;
            }

            int dataCount = data.Length / 12;
            int toPaintCount = data.Length / 12;
            if (toPaintCount <= _dspStep + 1)
            {
                return;
            }

            //_dspStep = 4.0; //跳点画
            const short RESERVE_POINT_COUNT = 2; //cache缓存上一栅最后两个点
            int DSP_COUNT = (int)(((float)toPaintCount) / _dspStep);

            if (DSP_COUNT > r.Width)
            {
                //throw new Exception("DSP_COUNT > r.Width");
            }
            if (DSP_COUNT <= RESERVE_POINT_COUNT)
            {
                return;
            }

            //计算采样点
            int i = 0;
            float j = 0;
            int index = 0;
            int lastX = -1;//当横坐标相等时，y取相同值

            int startPos = 0;
            int k = 0;
            int fastKY = (int)(_kY);
            int aLeadIndex = 0;

            int RIGHTVIEW = r.Left + r.Width / 2 + VIEW_GAP / 2;
            int rightViewX = 0;

            for (i = 0; i < _leadCount; i++)
            {
                index = 0;
                startPos = _baselineOffset + _heightPerLead * (k > 5 ? k - 6 : k);

                for (j = 0; j < toPaintCount; j += _dspStep)
                {
                    _ppScreenPoints[i][index].X = (int)(j * _kX) + rightViewX;//float a = (j) * _kX;
                    //_ppScreenPoints[i][index].Y = _cache.GetPaintOffsetBuf(i,j) * fastKY / 1000 + startPos;
                    _ppScreenPoints[i][index].Y = (int)-data[i + (int)j * 12] * fastKY / 10000 + startPos;
                    index++;
                    if (index > _screenPointsCount)
                    {
                        System.Console.Write("图形增量宽度大于_ppScreenPoints的体积");
                        break;
                    }
                }
                aLeadIndex = i;
                k++;
            }

            if (k < 1)
            {//无显示导联
                //SetEvent(_cache.GetEvent());
                return;
            }
            index--;
            //ASSERT(index + 1 > 2);

            int avoidMissSpCount = toPaintCount - ((int)((float)(index + 1 - RESERVE_POINT_COUNT) * _dspStep));//cache (step1... step2... step3..) FinishPaintOffset-> (step1...) 被偏移掉
            _cache = new int[avoidMissSpCount * 12];
            Array.Copy(data, data.Length - avoidMissSpCount * 12, _cache, 0, avoidMissSpCount * 12);

            //_cache.FinishPaintOffset(avoidMissSpCount);//_cache尽早脱离互斥保护,  为去掉单屏累积误差不使用_cache.FinishPaintOffset(); 
            //SetEvent(_cache.GetEvent());
            int WAVE_WIDTH = (r.Width - VIEW_GAP) / 2 - RULER_WIDTH;
            Rectangle r0 = new Rectangle(r.Left + RULER_WIDTH, r.Top, WAVE_WIDTH, r.Height);
            GdiPaint(0, index, RESERVE_POINT_COUNT, r0, g);

            //DrawCursor(pDc, _ppScreenPoints, _leadCount, index+1, pRect->left + _lastPaintScreenPoss[0], &_gridPen);
            Rectangle r1 = new Rectangle(r.Left + RULER_WIDTH + WAVE_WIDTH + VIEW_GAP + RULER_WIDTH, r.Top, WAVE_WIDTH, r.Height);
            GdiPaint(6, index, RESERVE_POINT_COUNT, r1, g);
            //g.DrawLine(Pens.Red, 0, 0, r.Right, r.Bottom);
        }
        /// <summary>
        /// 绘
        /// </summary>
        /// <param name="r"></param>
        private void CalcParam(Rectangle r)
        {
            _pixelPerMm = DEVICE_DISPLAY_DPI / MM_PER_INCH;
            _pixelPerMv = _scaleY * _pixelPerMm * _magCo;
            _pixelPerSecond = _pixelPerMm * _scaleX * _magCo;
            _pixelPerAdjacentOffset = _pixelPerSecond / _sr;
            _dspStep = 1 / _pixelPerAdjacentOffset; //一个像素表示dspStep个点

            if (_dspStep < 1)
            {// _dspStep < 1 ? _dspStep = 1 : true;//_dspStep小于1时，逐点画
                _dspStep = 1;
            }
            _lineInterval = (float)_mmPerGrid * _pixelPerMm * _magCo;

            _kX = _pixelPerAdjacentOffset;
            _kY = _pixelPerMv / _adMagCo;

            _displayLeadCount = 12;
            if (_displayLeadCount < 1)
                _heightPerLead = r.Height;
            else
                _heightPerLead = r.Height / _displayLeadCount * 2; //分左右屏幕显示
            _baselineOffset = _heightPerLead / 2;

            _lastPaintScreenPoss[0] = 0;
            _lastPaintScreenPoss[1] = 0;
        }

        void GdiPaint(short aLeadIndex, int index, short RESERVE_POINT_COUNT, Rectangle pRect, Graphics pDc)
        {
            if (pRect.Height < 1 || pRect.Width < 1)
                return;

            float offset = _ppScreenPoints[aLeadIndex][index].X - _ppScreenPoints[aLeadIndex][RESERVE_POINT_COUNT - 1].X; //offset = _pScreenPoints[index].x - _pScreenPoints[RESERVE_POINT_COUNT-1].x; //offset = _pScreenPoints[index].x+1;//加一个像素
            int beginPos = _ppScreenPoints[aLeadIndex][RESERVE_POINT_COUNT - 1].X;			//_pScreenPoints[RESERVE_POINT_COUNT-1].x
            int endPos = _ppScreenPoints[aLeadIndex][index].X;			//_pScreenPoints[index].x;

          //  int rulerWidth = RULER_WIDTH;
            double _lastPaintScreenPos = 0;
            if (aLeadIndex < 6)
                _lastPaintScreenPos = _lastPaintScreenPoss[0];
            else
            {
                _lastPaintScreenPos = _lastPaintScreenPoss[1];// +pRect.Left;
          //      rulerWidth = rulerWidth * 2;
            }

            Bitmap bmp = new Bitmap(endPos - beginPos + 1 + 5, pRect.Height);
            Graphics bufferG = Graphics.FromImage(bmp);
            bufferG.Clear(Color.Black);

            //对目标dc的绘制
            if (offset > pRect.Width || offset == 0)
            {
                //todo
                //TRACE(L"!!! exception occur!\n");
                return;
            }
            else if (_lastPaintScreenPos + offset <= pRect.Width)
            {
                DrawPloy(aLeadIndex, bufferG, _ppScreenPoints, _leadCount, index + 1);//pAlphaDc->Polyline(_pScreenPoints, index+1);
             
                pDc.DrawImage(bmp, (float)(pRect.Left + _lastPaintScreenPos), (float)pRect.Top);

                if (aLeadIndex < 6)
                    _lastPaintScreenPoss[0] += offset;
                else
                    _lastPaintScreenPoss[1] = _lastPaintScreenPoss[0];
            }
            else
            {
                int offsetA = pRect.Width - (int)_lastPaintScreenPos;
                int offsetB = (int)offset - offsetA;

              
                    DrawPloy(aLeadIndex, bufferG, _ppScreenPoints, _leadCount, index + 1);//pAlphaDc->Polyline(_pScreenPoints, index+1);
              
                    RectangleF sA = new RectangleF(0, 0, offsetA, bmp.Height);
                    RectangleF sB = new RectangleF(offsetA, 0, offsetB, bmp.Height);

                    RectangleF dA = new RectangleF((int)(pRect.Left + _lastPaintScreenPos), pRect.Top, offsetA, pRect.Height);
                    RectangleF dB = new RectangleF(pRect.Left, pRect.Top, offsetB, pRect.Height);
                try
                {
                    pDc.DrawImage(bmp, dA, sA, GraphicsUnit.Pixel);
                    pDc.DrawImage(bmp, dB, sB, GraphicsUnit.Pixel);
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
                if (aLeadIndex < 6)
                    _lastPaintScreenPoss[0] = offsetB;
                else
                    _lastPaintScreenPoss[1] = _lastPaintScreenPoss[0];
            }

            bmp.Dispose();
            bufferG.Dispose();
        }

        void DrawPloy2(short aLeadIndex, Graphics g, Point[][] ppScreenPoints, int leadCount, int pointCount)
        {
            Pen p = new Pen(Color.White, 1);
            Point[] points = new Point[pointCount];
            for (int i = aLeadIndex; i < aLeadIndex + 6; i++)
            {
                for (int j = 0; j < pointCount; j++)
                {
                    points[j] = ppScreenPoints[i][j];
                    //points[i][j].Y = j;
                }
                g.DrawLines(p, points);
            }
            p.Dispose();
        }

        void DrawPloy(short aLeadIndex, Graphics g, Point[][] ppScreenPoints, int leadCount, int pointCount)
        {
            Pen p = new Pen(Color.GreenYellow, 1);
            Point[] points = new Point[pointCount];
            for (int i = aLeadIndex; i < aLeadIndex + 6; i++)
            {
                for (int j = 0; j < pointCount; j++)
                {
                    points[j] = ppScreenPoints[i][j];
                    //points[i][j].Y = j;
                }
                g.DrawLines(p, points);
            }
            p.Dispose();
        }

        //Ecg 绘图参数
        float _pixelPerMm;//由显示屏决定	
        float _pixelPerMv;
        float _pixelPerSecond;
        float _pixelPerAdjacentOffset;//double
        float _dspStep;
        float _kX;
        float _kY;

        int _heightPerLead;//每导联高度
        int _baselineOffset;//基线高度

        int _mmPerGrid;
        float _lineInterval;

        float _adMagCo;
        float _magCo;
        float _sr;
        float _scaleX;
        float _scaleY;
        int _leadCount;

        int _displayLeadCount = 12;
        Point[][] _ppScreenPoints = new Point[12][];
        int _screenPointsCount = 1024; //初始化时赋值
        float[] _lastPaintScreenPoss = new float[2]; //屏幕坐标的绘制开始位置

        bool _bParamChange = true;
        Rectangle _lastRect;

        public RtWave()
        {
            _sr = DEFAULT_SAMPLE_RATE;
            _leadCount = DEFAULT_LEAD_COUNT;
            _scaleY = 10; //10mm/mv
            _scaleX = 25; //25mm/s
            _magCo = (float)1.3;
            _adMagCo = (float)1;
            _dspStep = 1;
            _mmPerGrid = 5;//每大格5小格

            _heightPerLead = 0;
            _baselineOffset = 0;

            for (int i = 0; i < 12; i++)
            {
                _ppScreenPoints[i] = new Point[512];
            }
        }


        //
        float DEVICE_DISPLAY_DPI = ((float)(76.8));
        float MM_PER_INCH = ((float)(25.4));
        int VIEW_GAP = 50;
        int RULER_WIDTH = 40;
        int DEFAULT_SAMPLE_RATE = 1000;
        int DEFAULT_LEAD_COUNT = 12;
        int FONT_SIZE = 11;
    }
}
