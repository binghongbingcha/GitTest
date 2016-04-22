using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class DiagnosisShow_Form : Form
    {
        public EventHandler TemplateEvent = null;
        public static DiagnosisShow_Form _instance = null;
        private static readonly object lockHelper = new object();

        public static DiagnosisShow_Form CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new DiagnosisShow_Form();
                }
            }
            return _instance;
        }

        public DiagnosisShow_Form()
        {
            InitializeComponent();
        }
        private void DiagnosisShow_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void DiagnosisShow_Form_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            if (Program.DB_SIGN == 0)
                dt1 = SqliteOptions.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate order by DiagIndex DESC");
            else
                dt1 = SqliteOptions_sql.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate order by DiagIndex DESC");
            gridControl1.DataSource = dt1;
        }


        //文本框改变事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            if (Program.DB_SIGN == 0)
                dt1 = SqliteOptions.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate where JP like '%" + textBox1.Text.Trim() + "%' order by DiagIndex DESC");
            else
                dt1 = SqliteOptions_sql.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate where JP like '%" + textBox1.Text.Trim() + "%' order by DiagIndex DESC");

            gridControl1.DataSource = dt1;
        }


        //数据行点击
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                string dcon = gridView1.GetFocusedRowCellValue("DiagnosisContent").ToString();//模板内容
                string ChildTypeName = gridView1.GetFocusedRowCellValue("ChildTypeName").ToString();//模板名称
                string XuHao = gridView1.GetFocusedRowCellValue("DiagIndex").ToString();//模板排序下标
                string ID = gridView1.GetFocusedRowCellValue("ID").ToString();//模板ID
                int ReIndex = int.Parse(XuHao) + 1;
                if (Program.DB_SIGN == 0)
                    SqliteOptions.CreateInstance().SqliteUpdate("update t_DiagnosisTemplate set DiagIndex='" + ReIndex + "' where ID='" + ID + "'");
                else
                    SqliteOptions_sql.CreateInstance().SqliteUpdate("update t_DiagnosisTemplate set DiagIndex='" + ReIndex + "' where ID='" + ID + "'");
                DiagnosisShow_Form_Load(null, null);
                TemplateEvent(dcon, null);
            }
        }


    }
}
