using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class ZhenDuanTemplet_Form : Form
    {
        public ZhenDuanTemplet_Form()
        {
            InitializeComponent();
        }

        private void ZhenDuanTemplet_Form_Load(object sender, EventArgs e)
        {
            DataTable dt1 = null;
            string sql = "select * from t_DiagnosisTemplate order by DiagIndex DESC";

            if (Program.DB_SIGN == 0)
                dt1 = SqliteOptions.CreateInstance().ExcuteSqlite(sql);
            else
                dt1 = SqliteOptions_sql.CreateInstance().ExcuteSqlite(sql);

            gridControl1.DataSource = dt1;
            gridControl1_Click(null, null);
        }


        #region 新操作
        //判断模板名称是否已存在
        bool GetTheSameTemplate(string templateName)
        {
            bool SameFlag = false;
            DataTable dt2 = null;
            if (Program.DB_SIGN == 0)
                dt2 = SqliteOptions.CreateInstance().ExcuteSqlite("select ChildTypeName from t_DiagnosisTemplate where ChildTypeName='" + templateName + "'");
            else
                dt2 = SqliteOptions_sql.CreateInstance().ExcuteSqlite("select ChildTypeName from t_DiagnosisTemplate where ChildTypeName='" + templateName + "'");

            if (dt2.Rows.Count > 0)
            {
                SameFlag = true;
                return SameFlag;
            }
            return SameFlag;
        }
        //添加
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("模板名称或模板内容不能为空！");
                return;
            }
            if (GetTheSameTemplate(textBox1.Text.Trim()))
            {
                MessageBox.Show("已存在相同的模板名称，请修改");
                return;
            }
            DataTable dt_2 = null;
            if (Program.DB_SIGN == 0)
                dt_2 = SqliteOptions.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate where ChildTypeName='" + textBox1.Text.Trim() + "'");
            else
                dt_2 = SqliteOptions_sql.CreateInstance().ExcuteSqlite("select * from t_DiagnosisTemplate where ChildTypeName='" + textBox1.Text.Trim() + "'");

            if (dt_2.Rows.Count > 0)
            {
                MessageBox.Show("已存在相同模板名称的数据行，请重新命名模板名称！");
                return;
            }
            if (MessageBox.Show("确定要添加此条数据吗?", "添加提示：",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool AddFlag = true;
                if (Program.DB_SIGN == 0)
                    AddFlag = SqliteOptions.CreateInstance().SqliteAdd("INSERT INTO t_DiagnosisTemplate (ID,ChildTypeName,DiagnosisContent,JP,DiagIndex) VALUES ('" + Guid.NewGuid().ToString() + "','" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','0')");
                else
                    AddFlag = SqliteOptions_sql.CreateInstance().SqliteAdd("INSERT INTO t_DiagnosisTemplate (ID,ChildTypeName,DiagnosisContent,JP,DiagIndex) VALUES ('" + Guid.NewGuid().ToString() + "','" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','0')");

                if (AddFlag)
                {
                    MessageBox.Show("添加成功！");
                    ZhenDuanTemplet_Form_Load(null, null);
                }
            }
        }
        //修改
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    MessageBox.Show("模板名称或模板内容不能为空！");
                    return;
                }
                //if (GetTheSameTemplate(textBox1.Text.Trim()))
                //{
                //    MessageBox.Show("已存在相同的模板名称，请修改");
                //    return;
                //}
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                bool UpdateFlag = true;
                if (Program.DB_SIGN == 0)
                    UpdateFlag = SqliteOptions.CreateInstance().SqliteUpdate("update t_DiagnosisTemplate  set ChildTypeName='" + textBox1.Text.Trim() + "',DiagnosisContent='" + textBox2.Text.Trim() + "',JP='" + textBox3.Text.Trim() + "' where ID='" + id + "'");
                else
                    UpdateFlag = SqliteOptions_sql.CreateInstance().SqliteUpdate("update t_DiagnosisTemplate  set ChildTypeName='" + textBox1.Text.Trim() + "',DiagnosisContent='" + textBox2.Text.Trim() + "',JP='" + textBox3.Text.Trim() + "' where ID='" + id + "'");

                if (UpdateFlag)
                {
                    MessageBox.Show("修改成功！");
                    ZhenDuanTemplet_Form_Load(null, null);
                }
            }
        }
        //删除
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                if (MessageBox.Show("确定要删除此条数据吗?", "删除提示：",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    bool DeleteFlag = true;
                    if (Program.DB_SIGN == 0)
                        DeleteFlag = SqliteOptions.CreateInstance().SqliteDelete("delete from t_DiagnosisTemplate where ID='" + id + "'");
                    else
                        DeleteFlag = SqliteOptions_sql.CreateInstance().SqliteDelete("delete from t_DiagnosisTemplate where ID='" + id + "'");
                    if (DeleteFlag)
                    {
                        MessageBox.Show("删除成功！");
                        ZhenDuanTemplet_Form_Load(null, null);
                    }
                }
            }
        }
        //重置
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        //点击事件
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                textBox1.Text = gridView1.GetFocusedRowCellValue("ChildTypeName").ToString();//模板名称
                textBox2.Text = gridView1.GetFocusedRowCellValue("DiagnosisContent").ToString();//模板内容  
                textBox3.Text = gridView1.GetFocusedRowCellValue("JP").ToString();//模板内容
            }
        }
        //模板名称输入，简称生成
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ChineseJP CJP = new ChineseJP();
            textBox3.Text = CJP.ChineseCap(textBox1.Text.Trim().Replace("窦","d"));
        }
        #endregion

        #region 验证
        //模板名称
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[^%&',;=?$\x22]+$")) //正则表达式匹配
                {
                    MessageBox.Show("您输入了非法字符！（如 ^%&',;=?$）");
                    textBox1.Focus();
                    return;
                }
            }

            if (textBox1.Text.Trim().Length > 255)
            {
                MessageBox.Show("您输入的模板名称过长！请更改！(255个字)");
                textBox1.Focus();
                return;
            }

        }
        //模板简拼
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Trim().Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^[^%&',;=?$\x22]+$")) //正则表达式匹配
                {
                    MessageBox.Show("您输入了非法字符！（如 ^%&',;=?$）");
                    textBox3.Focus();
                    return;
                }
            }

            if (textBox3.Text.Trim().Length > 255)
            {
                MessageBox.Show("您输入的模板简拼过长！请更改！(255个字)");
                textBox3.Focus();
                return;
            }
        }
        //模板内容
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[^%&',;=?$\x22]+$")) //正则表达式匹配
                {
                    MessageBox.Show("您输入了非法字符！（如 ^%&',;=?$）");
                    textBox2.Focus();
                    return;
                }
            }

            if (textBox2.Text.Trim().Length > 1000)
            {
                MessageBox.Show("您输入的模板内容过长！请更改！(1000个字)");
                textBox2.Focus();
                return;
            }
        }
        #endregion

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
