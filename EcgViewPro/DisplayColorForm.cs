using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CommonProj;
using DevExpress.XtraEditors;


namespace EcgViewPro
{
    public partial class DisplayColorForm : Form
    {
        public DisplayColorForm()
        {
            InitializeComponent();
        }
        private void PaintWave()
        {
            //它在定义数组的长度和for循环中都要用到。 
            const int size = 1000;
            var x = new double[size];
            Bitmap bt = new Bitmap(pBoxFill.Width,pBoxFill.Height);
            Graphics graphics = Graphics.FromImage(bt);
            graphics.Clear(ConfigHelper.WaveBackColor);
             Draw_EcgBackGroundGrid(graphics);
            var pen = new Pen(ConfigHelper.WaveColor,ConfigHelper.WaveSize);
            //画正弦曲线的横轴间距参数。建议所用的值应该是正数且是2的倍数。 
            //在这里采用2。 
            const int val = 2;
            float temp = 0.0f;
            //把画布下移100。为什么要这样做，只要你把这一句给注释掉，运行一下代码， 

            //你就会明白是为什么？ 
            graphics.TranslateTransform(0, 60);
            for (int i = 0; i < size; i++)
            {
                //改变32，实现正弦曲线宽度的变化。 

                //改100，实现正弦曲线高度的变化。 

                x[i] = Math.Sin(2 * Math.PI * i / 32) * 50;
                graphics.DrawLine(pen, i * val, temp, i * val + val / 2, (float)x[i]);
                temp = (float)x[i]; 
            }
            pBoxFill.Image = bt;
        }

        private void DisplayColorForm_Load(object sender, EventArgs e)
        {
            colorPickEditWave.Color = ConfigHelper.WaveColor;//波形颜色
            colorPickEditGrid.Color = ConfigHelper.WaveGridColor;//背景网格颜色
            colorPickEditBack.Color = ConfigHelper.WaveBackColor;//背景颜色
            spinEditWaveSize.Value = (decimal)ConfigHelper.WaveSize;//波形粗细
            spinEditWaveSize.Properties.MinValue = 1;
            spinEditWaveSize.Properties.MaxValue = 6;
            PaintWave();
        }

        /// <summary>
        ///背景网格---显示
        /// </summary>
        public void Draw_EcgBackGroundGrid(Graphics ecgGraphics)
        {
            var ecgP = new Pen(ConfigHelper.WaveGridColor, float.Parse("1"));
            bool shuxianFlag = false;
            const float pointCountPerMM = 4f; //
            float x = 0; int xNum = 0;
            float y = 0; int yNum = 0;
            float divY, divX;
            divY = pBoxFill.Height / pointCountPerMM + 1;
            divX = pBoxFill.Width / pointCountPerMM + 1;
            ecgGraphics.SmoothingMode = SmoothingMode.None;//保证网格线的清晰
            for (int p = 0; p < (int)divY; p++)
            {
                for (int r = 0; r < (int)divX; r++)
                {
                    if (xNum % 5 == 0 && !shuxianFlag)
                    {
                        ecgGraphics.DrawLine(ecgP, x + 0.3f, 0, x + 0.3f, pBoxFill.Height);
                    }
                    x += pointCountPerMM;
                    xNum++;
                    if (x < pBoxFill.Width && y < pBoxFill.Height)
                    {
                        if (xNum % 5 != 0 && yNum % 5 != 0)
                        {
                            //Ecg_Graphics.SmoothingMode = SmoothingMode.AntiAlias;//保证网格线的清晰
                            var sbrush = new SolidBrush(ConfigHelper.WaveGridColor);
                            ecgGraphics.FillEllipse(sbrush, x, y, 1.45f, 1.45f);
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
                    ecgGraphics.DrawLine(ecgP, 0, y + 0.3f, pBoxFill.Width, y + 0.3f);
                }
                yNum++;
                y += pointCountPerMM;

                xNum = 0;


                if (y > pBoxFill.Height)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 分析的心电图波形颜色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWave_Click(object sender, EventArgs e)
        {
            colorPickEditWave.Color = ConfigHelper.WaveColor = Color.Black;
            PaintWave();
        }
        /// <summary>
        /// 波形背景网格颜色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrid_Click(object sender, EventArgs e)
        {
            colorPickEditGrid.Color = ConfigHelper.WaveGridColor = Color.LightCoral;
            PaintWave();
        }
        /// <summary>
        /// 波形背景色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            colorPickEditBack.Color = ConfigHelper.WaveBackColor = Color.White;
            PaintWave();
        }
        /// <summary> 
        /// 波形粗细：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaveSize_Click(object sender, EventArgs e)
        {
            ConfigHelper.WaveSize = 5.0f;
            spinEditWaveSize.Value = (decimal)5.0f;
            PaintWave();

        }
        /// <summary>
        /// 分析的心电图波形颜色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPickEditWave_EditValueChanged(object sender, EventArgs e)
        {
            ConfigHelper.WaveColor = colorPickEditWave.Color;
            PaintWave();
        }
        /// <summary>
        /// 波形背景网格颜色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPickEditGrid_EditValueChanged(object sender, EventArgs e)
        {
            ConfigHelper.WaveGridColor = colorPickEditGrid.Color;
            PaintWave();
        }
        /// <summary>
        /// 波形背景色：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPickEditBack_EditValueChanged(object sender, EventArgs e)
        {
            ConfigHelper.WaveBackColor = colorPickEditBack.Color;
            PaintWave();
        }
        /// <summary>
        /// 波形粗细：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spinEditWaveSize_EditValueChanged(object sender, EventArgs e)
        {
            ConfigHelper.WaveSize = (float)spinEditWaveSize.Value;
            PaintWave();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, string>
                {
                    {"WaveBackColor", ConfigHelper.WaveBackColor.ToArgb().ToString()},
                    {"WaveGridColor", ConfigHelper.WaveGridColor.ToArgb().ToString()},
                    {"WaveColor", ConfigHelper.WaveColor.ToArgb().ToString()},
                    {"WaveSize", ConfigHelper.WaveSize.ToString()}
                };
            bool ok= ConfigHelper.SaveConfig(dic);
            if (ok)
            {
                XtraMessageBox.Show(@"保存成功！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 波形颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWave_MouseDown(object sender, MouseEventArgs e)
        {
            btnWave.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 波形颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWave_MouseUp(object sender, MouseEventArgs e)
        {
            btnWave.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 网格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrid_MouseDown(object sender, MouseEventArgs e)
        {
            btnGrid.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 网格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrid_MouseUp(object sender, MouseEventArgs e)
        {
            btnGrid.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 波形背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 波形背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 波形粗细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaveSize_MouseDown(object sender, MouseEventArgs e)
        {
            btnWaveSize.BackColor = Color.FromArgb(15, 96, 168);

        }
        /// <summary>
        /// 波形粗细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaveSize_MouseUp(object sender, MouseEventArgs e)
        {
            btnWaveSize.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_MouseDown(object sender, MouseEventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_MouseUp(object sender, MouseEventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(35, 144, 240);
        }
    }
}
