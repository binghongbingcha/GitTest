using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class WaitingList : Form
    {
        public WaitingList()
        {
            InitializeComponent();
        }

        private void MST_QueueUp_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.gridView1.IndicatorWidth = 40;
            this.labelControl2.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh时mm分ss秒").Trim();
            this.BindGv();
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetQueueUp()
        {
            DataTable dt = new DataTable();
            string sql = "select *,DATEDIFF('yyyy',Birthday,now) as Age from Tb_PatientInfo as p left join WaitingQueue w on p.PatientID=w.PatientID where w.CreateDate>=#" + DateTime.Now.ToShortDateString() + "# and w.CreateDate<#" + DateTime.Now.AddDays(1).ToShortDateString() + "# order by w.CreateDate asc";
            if (ConfigHelper.DB_SIGN == 0)
            {
                dt = new SqliteOptions().ExcuteSqlite(sql);
            }
            else
            {
                sql = "select *,DATEDIFF(YEAR,cast(Birthday as datetime),GETDATE()) as Age from Tb_PatientInfo  as p left join WaitingQueue w on p.PatientID=w.PatientID where w.CreateDate>='" + DateTime.Now.ToShortDateString() + "' and w.CreateDate<'" + DateTime.Now.AddDays(1).ToShortDateString() + "' order by w.CreateDate asc";
                dt = new SqliteOptions_sql().ExcuteSqlite(sql);
            }
            return dt;
        }

        /// <summary>
        /// 绑定Gv
        /// </summary>
        private void BindGv()
        {
            this.gridControl1.DataSource = this.GetQueueUp();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = Convert.ToString(Convert.ToUInt32(e.RowHandle.ToString()) + 1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BindGv();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.labelControl2.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh时mm分ss秒").Trim();
        }

    }
}
