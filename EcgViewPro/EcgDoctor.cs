using System.Diagnostics;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class EcgDoctor : Form
    {
        readonly CommonProj.SqliteOptions _sqlite=new CommonProj.SqliteOptions();

        string _imagePath = string.Empty;
        string _id = string.Empty;
        string _doctorCode = string.Empty;
        string _doctorName = string.Empty;
      
        string _doctorSex = string.Empty;string _doctorDept = string.Empty;
        byte[] _electronicSignature;
        public EcgDoctor()
        {
            InitializeComponent();
        }
        public EcgDoctor(string id, string doctorCode, string doctorName, string doctorSex, string doctorDept, byte[] electronicSignature)
        {
            InitializeComponent();
            _id =id;
            _doctorCode = doctorCode;
            _doctorName = doctorName;
            _doctorDept = doctorDept;
            _doctorSex = doctorSex;
            _electronicSignature = electronicSignature;
            btnAdd.Text = @"修改";
            btnAddSignature.Text = @"修改电子签名";
        }
        private void EcgDoctor_Load(object sender, EventArgs e)
        {
            txtEditDoctorCode.Text = _doctorCode;
            txtEditDoctorName.Text = _doctorName;
            cBoxDoctorSex.Text = _doctorSex;
            txtEditDoctorDept.Text = _doctorDept;
            if (_electronicSignature != null)
            {
                var bs = new byte[_electronicSignature.Length];
                _electronicSignature.CopyTo(bs, 0);
                var mymemorystream = new MemoryStream(bs, 0, bs.Length);
                pictureEditSignature.Image = Image.FromStream(mymemorystream);
            }
            else
            {
                pictureEditSignature.Image = null;
            }
        }


        /// <summary>
        /// 添加电子签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSignature_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog
            {
                Filter = @"图片文件 (*.jpg)|*.jpg",
                RestoreDirectory = true,
                Multiselect = false
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _imagePath = openFile.FileName;
                var pic =SaveAsPng(_imagePath);
                pictureEditSignature.Image = pic;
            }
        }


        /// <summary>
        /// 转换为png 格式透明图片
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public Image SaveAsPng(string filePath)
        {
            filePath.Remove(filePath.Length - Path.GetExtension(filePath).Length);
            try
            {
                Image i = Image.FromFile(filePath);
                var bitmap = new Bitmap(i);
                bitmap.MakeTransparent(Color.White);
                Image st = bitmap.GetThumbnailImage(240, 120, () => false, IntPtr.Zero);
                return st;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEditDoctorCode.Text.Trim()))
            {
                XtraMessageBox.Show(@"工号不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEditDoctorCode.Text, @"^[^%&',;=?$\x22]+$")) //正则表达式匹配
            {
                XtraMessageBox.Show(@"您输入了非法字符！（如 ^%&',;=?$）", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEditDoctorCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtEditDoctorName.Text.Trim()))
            {
                XtraMessageBox.Show(@"医生名称不能为空！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (txtEditDoctorName.Text.Trim().ToLower() == "admin")
            {
                XtraMessageBox.Show(@"此用户名是管理员，不能添加！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEditDoctorName.Text, @"^[^%&',;=?$\x22]+$")) //正则表达式匹配
            {
                XtraMessageBox.Show(@"您输入了非法字符！（如 ^%&',;=?$）", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEditDoctorName.Focus();
                return;
            }

            if (btnAdd.Text == @"添加")
            {
                _id = Guid.NewGuid().ToString();
            }
           _doctorCode  = txtEditDoctorCode.Text.Trim();
            _doctorName = txtEditDoctorName.Text.Trim();
            _doctorDept= txtEditDoctorDept.Text;
           _doctorSex = cBoxDoctorSex.Text;
            if (pictureEditSignature.Image != null)
            {
                var ms = new MemoryStream();
                pictureEditSignature.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
              _electronicSignature = ms.ToArray();
                ms.Close();
            }
            bool exitOk = ExitEcgDoctor(_id, _doctorCode);
            if (exitOk)
            {
                XtraMessageBox.Show(@"此工号已存在，请重新填写！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            bool addOk;
            if (btnAdd.Text == @"添加")
            {
                addOk = AddEcgDoctor(_id,_doctorCode,_doctorName,_doctorSex,_doctorDept,_electronicSignature);
            }
            else
            {
                addOk = UpdateEcgDoctor(_id, _doctorCode, _doctorName, _doctorSex, _doctorDept, _electronicSignature);
            }
            if (!addOk)
            {
                XtraMessageBox.Show(string.Format(@"{0}失败！", btnAdd.Text), @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        /// <summary>
        /// 判断工号是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExitEcgDoctor(string id, string code)
        {
            string sql = string.Format("select * from Tb_Doctor where ID!='{0}' and  DoctorCode='{1}'", id, code);
            DataTable dt;
             dt = _sqlite.ExcuteSqlite(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctorCode"></param>
        /// <param name="doctorName"></param>
        /// <param name="doctorSex"></param>
        /// <param name="doctorDept"></param>
        /// <param name="electronicSignature"></param>
        /// <returns></returns>
        public bool AddEcgDoctor(string id, string doctorCode, string doctorName, string doctorSex, string doctorDept, byte[] electronicSignature)
        {
            string sql = string.Format("Insert into Tb_Doctor(ID,DoctorCode,DoctorName,DoctorPassword,DoctorSex,DoctorDept,CreateDateTime,ElectronicSignature) Values('{0}','{1}','{2}',123456,'{3}','{4}',datetime('now', 'localtime'),@ElectronicSignature)", id, doctorCode, doctorName, doctorSex, doctorDept);
            var slp = new SQLiteParameter("@ElectronicSignature", DbType.Binary) { Value = electronicSignature };
            return _sqlite.ExecuteSql(sql, new[] { slp }) != 0;
        }
        /// <summary>
        /// 更新医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctorCode"></param>
        /// <param name="doctorName"></param>
        /// <param name="doctorSex"></param>
        /// <param name="doctorDept"></param>
        /// <param name="electronicSignature"></param>
        /// <returns></returns>
        public bool UpdateEcgDoctor(string id, string doctorCode, string doctorName, string doctorSex, string doctorDept, byte[] electronicSignature)
        {
            string sql = string.Format("update Tb_Doctor set DoctorCode='{0}',doctorName='{1}',doctorSex='{2}',doctorDept='{3}',ElectronicSignature=@ElectronicSignature where ID='{4}'", doctorCode, doctorName, doctorSex, doctorDept, id);
           
                var slp = new SQLiteParameter("@ElectronicSignature", DbType.Binary) { Value =electronicSignature };

                return _sqlite.ExecuteSql(sql, new[] { slp }) != 0;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtEditDoctorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 此代码为了使Backspace按键在输入2字之后还能有效
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (txtEditDoctorCode.Text.Length >= 16) e.Handled = true;
        }

        private void txtEditDoctorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 此代码为了使Backspace按键在输入2字之后还能有效
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (txtEditDoctorName.Text.Length >= 6) e.Handled = true;
        }

        private void txtEditDoctorCode_Click(object sender, EventArgs e)
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
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseDown(object sender, MouseEventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseUp(object sender, MouseEventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            btnReset.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 添加电子签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSignature_MouseDown(object sender, MouseEventArgs e)
        {
            btnAddSignature.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 添加电子签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSignature_MouseUp(object sender, MouseEventArgs e)
        {
            btnAddSignature.BackColor = Color.FromArgb(35, 144, 240);
        }
      
    }
}
