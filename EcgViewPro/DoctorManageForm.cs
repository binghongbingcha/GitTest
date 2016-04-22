using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public partial class DoctorManageForm : Form
    {

        CommonProj.SqliteOptions _sqlite=new CommonProj.SqliteOptions();

        public DoctorManageForm()
        {
            InitializeComponent();
            wpDoctor.Bind();
        }
        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctorAdd_Click(object sender, EventArgs e)
        {
            var ed = new EcgDoctor {FormBorderStyle = FormBorderStyle.None};
            ed.ShowDialog();
            wpDoctor.Bind();
        }

        private int wpDoctor_EventPaging(EventPagingArg e)
        {
            BindingDataDoctor(wpDoctor.PageIndex);
            return wpDoctor.TotalRows;
        }
        private void BindingDataDoctor(int index)
        {
            wpDoctor.PageIndex = index;
            dGVDocotr.DataSource = SelAllEcgDoctor(wpDoctor.PageIndex, wpDoctor.PageSize, txtBoxDoctorCode.Text.Trim(), txtBoxDoctorName.Text .Trim ());
            wpDoctor.TotalRows = SelCountEcgDoctor(txtBoxDoctorCode.Text.Trim(), txtBoxDoctorName.Text.Trim());
        }

        public DataTable SelAllEcgDoctor(int index, int pagesize,string doctorCode,string doctorName)
        {
            string sql = "select ID,DoctorCode,DoctorName,DoctorSex,DoctorDept,CreateDateTime,(case when ElectronicSignature is null then '无' else '有' end ) as IsElectronicSignature,'修改' as doctorMod,'删除' as doctorDel,'重置密码' as ResetPassword from Tb_Doctor where DoctorDept!='YJLAdminb578ec8eeffe' ";
            if (!string.IsNullOrEmpty(doctorCode))
            {
                sql += " and DoctorCode like '%"+doctorCode+"%' ";
            }
            if (!string.IsNullOrEmpty(doctorName))
            {
                sql += " and DoctorName like '%"+doctorName+"%' ";
            }
            sql +=string.Format("order by CreateDateTime desc limit {0} offset {1}", pagesize, (index - 1) * pagesize);

            DataTable dt = _sqlite.ExcuteSqlite(sql);
            return dt;
        }

        public int SelCountEcgDoctor(string doctorCode, string doctorName)
        {
            string sql = "select Count(*) as CountVlues from Tb_Doctor where DoctorDept!='YJLAdminb578ec8eeffe'";

            if (!string.IsNullOrEmpty(doctorCode))
            {
                sql += " and DoctorCode like '%" + doctorCode + "%' ";
            }
            if (!string.IsNullOrEmpty(doctorName))
            {
                sql += " and DoctorName like '%" + doctorName + "%' ";
            }

            DataTable dt = _sqlite.ExcuteSqlite(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["CountVlues"]);
            }
            return 0;
        }

        private void btnDoctorSel_Click(object sender, EventArgs e)
        {
            wpDoctor.Bind();
        }

        private void dGVDocotr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVDocotr.SelectedCells.Count != 0 && null != dGVDocotr.CurrentRow)
            {
                string id =dGVDocotr.CurrentRow.Cells["ID"].Value .ToString ();
                if (null != dGVDocotr.CurrentCell.Value && dGVDocotr.CurrentCell.Value.ToString()=="修改")
                {
                    string doctorCode = dGVDocotr.CurrentRow.Cells["DoctorCode"].Value.ToString();
                    string doctorName = dGVDocotr.CurrentRow.Cells["DoctorName"].Value.ToString();
                    string doctorSex = dGVDocotr.CurrentRow.Cells["DoctorSex"].Value.ToString();
                    string doctorDept = dGVDocotr.CurrentRow.Cells["DoctorDept"].Value.ToString();
                    byte[] electronicSignature = null;
                    DataTable dt = SelAllEcgDoctor(id);
                    if (null != dt && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ElectronicSignature"] != DBNull.Value)
                        {
                            electronicSignature = (byte[])dt.Rows[0]["ElectronicSignature"];
                        }
                    }
                    var ed = new EcgDoctor(id,doctorCode,doctorName,doctorSex,doctorDept,electronicSignature);
                    ed.ShowDialog();
                    wpDoctor.Bind();
                }
                if (null != dGVDocotr.CurrentCell.Value && dGVDocotr.CurrentCell.Value.ToString() == "删除")
                {
                    if (XtraMessageBox.Show(@"确定删除此条数据吗？", @"删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool delOk =DeleteEcgDoctor(id);
                        if (!delOk)
                        {
                            XtraMessageBox.Show(@"删除失败！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    wpDoctor.Bind();
                }
                if (null != dGVDocotr.CurrentCell.Value && dGVDocotr.CurrentCell.Value.ToString() == "重置密码")
                {
                    if (XtraMessageBox.Show(@"确定重置此医生的密码吗？", @"重置提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string doctorName = dGVDocotr.CurrentRow.Cells["DoctorName"].Value.ToString();
                        bool ok = UpdateEcgDoctorPassword(id);
                        if (ok)
                        {
                            XtraMessageBox.Show(@"医生：" + doctorName + @"的密码已重置为默认密码123456", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            wpDoctor.Bind();
                        }
                    }
                }
            }
        }
        public DataTable SelAllEcgDoctor(string id)
        {
            string sql = string.Format("select ID,DoctorCode,DoctorName,DoctorSex,DoctorDept,(case when ElectronicSignature is null then '无' else '有' end ) as IsElectronicSignature,ElectronicSignature from Tb_Doctor where ID='{0}'", id);
            DataTable dt = _sqlite.ExcuteSqlite(sql);
            return dt;
        }

        /// <summary>
        /// 删除医生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEcgDoctor(string id)
        {
            string sql = string.Format("delete from Tb_Doctor where ID='{0}'", id);
         
            return _sqlite.SqliteDelete(sql);
         
        }

        public bool UpdateEcgDoctorPassword(string id)
        {
            string sql = string.Format("update tb_doctor set DoctorPassword='123456' where ID='{0}'",id);
            return _sqlite.SqliteUpdate(sql);
        }

        private void txtBoxDoctorCode_Click(object sender, EventArgs e)
        {
            GetOsk();
        }
        /// <summary>
        /// 调用虚拟键盘
        /// </summary>
        private void GetOsk()
        {
            Process[] mProcs = Process.GetProcessesByName(@"osk");
            if (mProcs.Length == 0)
            {
                Process.Start(@"C:\WINDOWS\system32\osk.exe");
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctorSel_MouseDown(object sender, MouseEventArgs e)
        {
            btnDoctorSel.BackColor = Color.FromArgb(15, 96, 168);
        }

        private void btnDoctorSel_MouseUp(object sender, MouseEventArgs e)
        {
            btnDoctorSel.BackColor = Color.FromArgb(35, 144, 240);
        }

        private void btnDoctorAdd_MouseDown(object sender, MouseEventArgs e)
        {
            btnDoctorAdd.BackColor = Color.FromArgb(15, 96, 168);
        }

        private void btnDoctorAdd_MouseUp(object sender, MouseEventArgs e)
        {
            btnDoctorAdd.BackColor = Color.FromArgb(35, 144, 240);
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                panelTop.ClientRectangle,
                                Color.FromArgb(35, 144, 240),//7f9db9
                                1,
                                ButtonBorderStyle.Solid,
                               Color.FromArgb(35, 144, 240),
                                1,
                                ButtonBorderStyle.Solid,
                               Color.FromArgb(35, 144, 240),
                                1,
                                ButtonBorderStyle.Solid,
                               Color.FromArgb(35, 144, 240),
                                1,
                                ButtonBorderStyle.Solid);

        }
    }
}
