using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProj;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public class NativeMethods
    {
        [DllImport("Sdtapi.dll")]
        private static extern int CardOn();
        [DllImport("Sdtapi.dll")]
        private static extern int InitComm(int iPort);
        [DllImport("Sdtapi.dll")]
        private static extern int Authenticate();
        [DllImport("Sdtapi.dll", CharSet = CharSet.Unicode)]
        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);
        [DllImport("Sdtapi.dll")]
        private static extern int CloseComm();


        public static int IntCardOn()
        {
            return CardOn();
        }

        public static int IntInitComm(int iPort)
        {
            return InitComm(iPort);
        }

        public static int IntAuthenticate()
        {
            return Authenticate();
        }

        public static int IntCloseComm()
        {
            return CloseComm();
        }

        public static int IntReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd)
        {
            return ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
        }

    }



    public partial class PatientInfoForm : Form
    {
        //[DllImport("Sdtapi.dll")]
        //private static extern int CardOn();
        //[DllImport("Sdtapi.dll")]
        //private static extern int InitComm(int iPort);
        //[DllImport("Sdtapi.dll")]
        //private static extern int Authenticate();
        //[DllImport("Sdtapi.dll",CharSet=CharSet.Unicode)]
        //private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
        //                                            StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
        //                                                StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);
        //[DllImport("Sdtapi.dll")]
        //private static extern int CloseComm();

        readonly StringBuilder _patientName = new StringBuilder(31);//姓名
        readonly StringBuilder _gender = new StringBuilder(3);//性别
        readonly StringBuilder _folk = new StringBuilder(10);//民族
        readonly StringBuilder _birthDay = new StringBuilder(9);//出生日期
        readonly StringBuilder _code = new StringBuilder(19);//身份证号
        readonly StringBuilder _address = new StringBuilder(71);//家庭住址
        readonly StringBuilder _agency = new StringBuilder(31);//签发机关
        readonly StringBuilder _expireStart = new StringBuilder(9);//开始有效期
        readonly StringBuilder _expireEnd = new StringBuilder(9);//结束有效期
        string _birDay = string.Empty;
        string _exStart = string.Empty;
        string _exEnd = string.Empty;
        private readonly string _patientId = string.Empty;

        readonly SqliteOptions _sqlite;

       

        public PatientInfoForm(string patientId)
        {
            InitializeComponent();
            _sqlite = new SqliteOptions();
            _patientId = patientId;
            if (string.IsNullOrEmpty(patientId))
            {
                btnMod.Visible = false;
                btnExit.Visible = false;
            }
            else
            {
                btnRead.Visible = false;
                btnSave.Visible = false;
                DisableControls(false);
            }
        }
        /// <summary>
        /// 读取身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            _patientName.Clear();
            _gender.Clear();
            _folk.Clear();
            _birthDay.Clear();
            _code.Clear();
            _address.Clear();
            _agency.Clear();
            _expireStart.Clear();
            _expireEnd.Clear();
            _birDay = string.Empty;
            _exStart = string.Empty;
            _exEnd = string.Empty;

            int cardOn = NativeMethods.IntCardOn();
            //打开端口
            int intOpenRet = NativeMethods.IntInitComm(1001);
            if (intOpenRet != 1)
            {
                XtraMessageBox.Show(@"阅读机具未连接", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //卡认证
            int intReadRet = NativeMethods.IntAuthenticate();
            if (intReadRet != 1)
            {
                XtraMessageBox.Show(@"卡认证失败", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NativeMethods.IntCloseComm();
                return;
            }

            //三种方式读取基本信息
            //ReadBaseInfos（推荐使用）

            int intReadBaseInfosRet =NativeMethods.IntReadBaseInfos(_patientName, _gender, _folk, _birthDay, _code, _address, _agency, _expireStart, _expireEnd);
            if (intReadBaseInfosRet != 1)
            {
                // XtraMessageBox.Show("读卡失败");
                NativeMethods.IntCloseComm();
                return;
            }
            _birDay = _birthDay.ToString().Substring(0, 4) + "-" + _birthDay.ToString().Substring(4, 2) + "-" + _birthDay.ToString().Substring(6, 2);
            _exStart = _expireStart.ToString().Substring(0, 4) + "-" + _expireStart.ToString().Substring(4, 2) + "-" + _expireStart.ToString().Substring(6, 2);
            _exEnd = _expireEnd.ToString().Substring(0, 4) + "-" + _expireEnd.ToString().Substring(4, 2) + "-" + _expireEnd.ToString().Substring(6, 2);
            //关闭端口
            int intCloseRet = NativeMethods.IntCloseComm();
            ConfigHelper.IP = _code.ToString();
            txtBoxID.Text = _code.ToString();//身份证
            txtBoxName.Text = _patientName.ToString();//姓名

            if (_gender.ToString() != "男")
            {
                rbtnSexF.Checked = true;
            }
            else
            {
                rbtnSexM.Checked = true;
            }
            dateTPBirthday.Value = DateTime.Parse(_birDay);//出生日期
            cBoxNational.Text = _folk.ToString();//民族
            txtBoxRegistrationAddress.Text = _address.ToString();//户籍地址
            DisableControls(false);
        }
        /// <summary>
        /// 禁用某一些控件
        /// </summary>
        private void DisableControls(bool isable)
        {
            txtBoxName.Enabled = isable;
            rbtnSexM.Enabled = isable;
            rbtnSexF.Enabled = isable;
            dateTPBirthday.Enabled = isable;
            cBoxNational.Enabled = isable;
            txtBoxID.Enabled = isable;
            txtBoxRegistrationAddress.Enabled = isable;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxID.Text.Trim()))
            {
                XtraMessageBox.Show(@"请先读取身份信息，再保存信息！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PatientInfo_IsExsist(_code.ToString().Trim()))
            {
                XtraMessageBox.Show(@"此身份证已存在，请重新填写！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var pmMd = new PatientMd
            {
                PatientName = txtBoxName.Text.Trim(),
                PatientID = Guid.NewGuid().ToString(),
                Gender = (rbtnSexM.Checked?"男":"女"),
                Birthday = _birDay,
                Folk = cBoxNational.Text,
                P_Id = txtBoxID.Text ,
                ExpireStart = _exStart,
                ExpireEnd =_exEnd,
                WorkUnits = txtBoxWorkUnits.Text .Trim(),
                Phone = txtBoxPhone.Text.Trim(),
                Address = txtBoxRegistrationAddress.Text.Trim(),
                Levelofeducation = cBoxLevelofeducation.Text,
                Marriage = cBoxMarriage.Text,
                PermanentType = cBoxPermanentType.Text,
                BloodType = cBoxBloodType.Text,
                SleepStatus = cBoxSleepStatus.Text,
                PhysicalExercise = cBoxPhysicalExercise.Text,
                Drinking = cBoxDrinking.Text,
                Professional = cBoxProfessional.Text,
                Height = txtBoxHeight.Text.Trim(),
                Waistline = txtBoxWaistline.Text.Trim(),
                Hipline = txtBoxHipline.Text.Trim(),
                Weight = txtBoxWeight.Text.Trim(),
                DisabilityStatus = (rbtnDisabilityStatusNo.Checked ? "无&" : "有&"+txtBoxDisabilityStatus.Text.Trim()),
                Allergy = (rbtnAllergyNo.Checked ? "无&" : "有&" + txtBoxAllergy.Text.Trim()),
                ExposureHistory = (rbtnExposureHistoryNo.Checked ? "无&" : "有&" + txtBoxrExposureHistory.Text.Trim()),
                DiseasesHistory = (rbtnDiseasesHistoryNo.Checked ? "无&" : "有&" + txtBoxDiseasesHistory.Text.Trim()),
                OperationHistory = (rbtnOperationHistoryNo.Checked ? "无&" : "有&" + txtBoxOperationHistory.Text.Trim()),
                RtaumaHistory = (rbtnRtaumaHistoryNo.Checked ? "无&" : "有&" + txtBoxRtaumaHistory.Text.Trim()),
                TransfusionHistory = (rbtnTransfusionHistoryNo.Checked ? "无&" : "有&" + txtBoxTransfusionHistory.Text.Trim())
            };
            bool ok = PatientInfo_Add(pmMd);
            if (ok)
            {
                ConfigHelper.PatientId = pmMd.PatientID;
                ConfigHelper.PatientName = pmMd.PatientName;
                ConfigHelper.IP = pmMd.P_Id;
                ConfigHelper.PatientGender = pmMd.Gender;
                ConfigHelper.PatientAge = (DateTime.Now.Year - DateTime.Parse(_birDay).Year).ToString();
                ConfigHelper.AppId = Guid.NewGuid().ToString();
                ResetPatientInfo();
                DisableControls(true);
                XtraMessageBox.Show(@"添加成功！",@"提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 判读数据库中是否存在此身份证ID
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        private bool PatientInfo_IsExsist(string pId)
        {
            string sql = string.Format("select count(*) as Num from Tb_PatientInfo where P_Id='{0}'", pId);
            DataTable dt = _sqlite.ExcuteSqlite(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Num"]) == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="patientMd"></param>
        /// <returns></returns>
        public bool PatientInfo_Add(PatientMd patientMd)
        {
            try
            {
                const string sql = "insert into Tb_PatientInfo (ID,PatientID,PatientName,Gender,Birthday,P_Id,CreateDate,Folk,Address,Agency,ExpireStart,ExpireEnd,DoctorId,WorkUnits,Phone,Levelofeducation,Marriage,PermanentType,BloodType,SleepStatus,Drinking,Professional,PhysicalExercise,Height,Waistline,Hipline,Weight,DisabilityStatus,Allergy,ExposureHistory,DiseasesHistory,OperationHistory,RtaumaHistory,TransfusionHistory)" +
                                   "Values(@ID,@PatientID,@PatientName,@Gender,@Birthday,@P_Id,datetime('now', 'localtime'),@Folk,@Address,@Agency,@ExpireStart,@ExpireEnd,@DoctorId,@WorkUnits,@Phone,@Levelofeducation,@Marriage,@PermanentType,@BloodType,@SleepStatus,@Drinking,@Professional,@PhysicalExercise,@Height,@Waistline,@Hipline,@Weight,@DisabilityStatus,@Allergy,@ExposureHistory,@DiseasesHistory,@OperationHistory,@RtaumaHistory,@TransfusionHistory)";
                var ls = new List<SQLiteParameter>
                {
                    new SQLiteParameter("@ID", Guid.NewGuid().ToString()),
                    new SQLiteParameter("@PatientID", patientMd.PatientID),
                    new SQLiteParameter("@PatientName",patientMd.PatientName),
                    new SQLiteParameter("@Gender",patientMd.Gender),
                    new SQLiteParameter("@Birthday",patientMd.Birthday),
                    new SQLiteParameter("@P_Id",patientMd.P_Id),
                    new SQLiteParameter("@Folk",patientMd.Folk),
                    new SQLiteParameter("@Address",patientMd.Address),
                    new SQLiteParameter("@Agency", patientMd.Agency),
                    new SQLiteParameter("@ExpireStart", patientMd.ExpireStart),
                    new SQLiteParameter("@ExpireEnd",patientMd.ExpireEnd),
                    new SQLiteParameter("@DoctorId",ConfigHelper.LoginId),
                    new SQLiteParameter("@WorkUnits", patientMd.WorkUnits),
                    new SQLiteParameter("@Phone",patientMd.Phone),
                    new SQLiteParameter("@Levelofeducation",patientMd.Levelofeducation),
                    new SQLiteParameter("@Marriage",patientMd.Marriage),
                    new SQLiteParameter("@PermanentType",patientMd.PermanentType),
                    new SQLiteParameter("@BloodType",patientMd.BloodType),
                    new SQLiteParameter("@SleepStatus", patientMd.SleepStatus),
                    new SQLiteParameter("@Drinking", patientMd.Drinking),
                    new SQLiteParameter("@Professional", patientMd.Professional),
                    new SQLiteParameter("@PhysicalExercise",patientMd.PhysicalExercise),
                    new SQLiteParameter("@Height",patientMd.Height),
                    new SQLiteParameter("@Waistline",patientMd.Waistline),
                    new SQLiteParameter("@Hipline",patientMd.Hipline),
                    new SQLiteParameter("@Weight",patientMd.Weight),
                    new SQLiteParameter("@DisabilityStatus",patientMd.DisabilityStatus),
                    new SQLiteParameter("@Allergy",patientMd.Allergy),
                    new SQLiteParameter("@ExposureHistory",patientMd.ExposureHistory),
                    new SQLiteParameter("@DiseasesHistory",patientMd.DiseasesHistory),
                    new SQLiteParameter("@OperationHistory", patientMd.OperationHistory),
                    new SQLiteParameter("@RtaumaHistory",patientMd.RtaumaHistory),
                    new SQLiteParameter("@TransfusionHistory",patientMd.TransfusionHistory)
                };
                WatchDog.WriteMsg(DateTime.Now + "==添加患者：" + patientMd.PatientName);
                _sqlite.ExecuteSql(sql, ls.ToArray());
                ls.Clear();
                return true;
            }
            catch (Exception ex)
            {
                WatchDog.WriteMsg(DateTime.Now + "==添加患者失败：" +patientMd.PatientName + ex.StackTrace);
                return false;
            }

        }
        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <returns></returns>
        public DataTable PatientInfo_Select()
        {
            string sql = "select * from Tb_PatientInfo where PatientID='"+_patientId+"'";
            return _sqlite.ExcuteSqlite(sql);
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="patientMd"></param>
        /// <returns></returns>
        public bool PatientInfo_Mod(PatientMd patientMd)
        {
            try
            {
                const string sql ="update Tb_PatientInfo set  WorkUnits=@WorkUnits,Phone=@Phone,Levelofeducation=@Levelofeducation,Marriage=@Marriage,PermanentType=@PermanentType,BloodType=@BloodType,SleepStatus=@SleepStatus,Drinking=@Drinking,Professional=@Professional,PhysicalExercise=@PhysicalExercise,Height=@Height,Waistline=@Waistline,Hipline=@Hipline,Weight=@Weight,DisabilityStatus=@DisabilityStatus,Allergy=@Allergy,ExposureHistory=@ExposureHistory,DiseasesHistory=@DiseasesHistory,OperationHistory=@OperationHistory,RtaumaHistory=@RtaumaHistory,TransfusionHistory=@TransfusionHistory where PatientID=@PatientID";

                var ls = new List<SQLiteParameter>
                {
                    new SQLiteParameter("@PatientID", patientMd.PatientID),
                    new SQLiteParameter("@WorkUnits", patientMd.WorkUnits),
                    new SQLiteParameter("@Phone",patientMd.Phone),
                    new SQLiteParameter("@Levelofeducation",patientMd.Levelofeducation),
                    new SQLiteParameter("@Marriage",patientMd.Marriage),
                    new SQLiteParameter("@PermanentType",patientMd.PermanentType),
                    new SQLiteParameter("@BloodType",patientMd.BloodType),
                    new SQLiteParameter("@SleepStatus", patientMd.SleepStatus),
                    new SQLiteParameter("@Drinking", patientMd.Drinking),
                    new SQLiteParameter("@Professional", patientMd.Professional),
                    new SQLiteParameter("@PhysicalExercise",patientMd.PhysicalExercise),
                    new SQLiteParameter("@Height",patientMd.Height),
                    new SQLiteParameter("@Waistline",patientMd.Waistline),
                    new SQLiteParameter("@Hipline",patientMd.Hipline),
                    new SQLiteParameter("@Weight",patientMd.Weight),
                    new SQLiteParameter("@DisabilityStatus",patientMd.DisabilityStatus),
                    new SQLiteParameter("@Allergy",patientMd.Allergy),
                    new SQLiteParameter("@ExposureHistory",patientMd.ExposureHistory),
                    new SQLiteParameter("@DiseasesHistory",patientMd.DiseasesHistory),
                    new SQLiteParameter("@OperationHistory", patientMd.OperationHistory),
                    new SQLiteParameter("@RtaumaHistory",patientMd.RtaumaHistory),
                    new SQLiteParameter("@TransfusionHistory",patientMd.TransfusionHistory)
                };
                WatchDog.WriteMsg(DateTime.Now + "==修改患者：" + patientMd.PatientName);
                _sqlite.ExecuteSql(sql, ls.ToArray());
                ls.Clear();
                return true;
            }
            catch (Exception ex)
            {
                WatchDog.WriteMsg(DateTime.Now + "==修改患者失败：" + patientMd.PatientName + ex.StackTrace);
                return false;
            }

        }
        /// <summary>
        /// 重置信息
        /// </summary>
        public void ResetPatientInfo()
        {
            const int resetInt = -1;
            txtBoxName.Text = string.Empty;
            rbtnSexM.Checked = true;
            dateTPBirthday.Value = DateTime.Now;
            cBoxNational.SelectedIndex = resetInt;
            txtBoxID.Text = string.Empty;
            txtBoxWorkUnits.Text = string.Empty;
            txtBoxPhone.Text = string.Empty;
            txtBoxRegistrationAddress.Text = string.Empty;
            cBoxLevelofeducation.SelectedIndex = resetInt;
            cBoxMarriage.SelectedIndex = resetInt;
            cBoxPermanentType.SelectedIndex = resetInt;
            cBoxBloodType.SelectedIndex = resetInt;
            cBoxSleepStatus.SelectedIndex = resetInt;
            cBoxPhysicalExercise.SelectedIndex = resetInt;
            cBoxDrinking.SelectedIndex = resetInt;
            cBoxProfessional.SelectedIndex = resetInt;
            txtBoxHeight.Text = string.Empty;
            txtBoxWaistline.Text = string.Empty;
            txtBoxHipline.Text = string.Empty;
            txtBoxWeight.Text = string.Empty;
            txtBoxDisabilityStatus.Text = string.Empty;
            rbtnDisabilityStatusNo.Checked = true;
            txtBoxAllergy.Text = string.Empty;
            rbtnAllergyNo.Checked = true;
            txtBoxrExposureHistory.Text = string.Empty;
            rbtnExposureHistoryNo.Checked = true;
            txtBoxDiseasesHistory.Text = string.Empty;
            rbtnDiseasesHistoryNo.Checked = true;
            txtBoxOperationHistory.Text = string.Empty;
            rbtnOperationHistoryNo.Checked = true;
            txtBoxRtaumaHistory.Text = string.Empty;
            rbtnRtaumaHistoryNo.Checked = true;
            txtBoxTransfusionHistory.Text = string.Empty;
            rbtnTransfusionHistoryNo.Checked = true;
        }
        /// <summary>
        /// 残疾情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDisabilityStatusYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDisabilityStatusYes.Checked)
            {
                txtBoxDisabilityStatus.Enabled = true;
            }
            if (rbtnDisabilityStatusNo.Checked)
            {
                txtBoxDisabilityStatus.Enabled = false;
                txtBoxDisabilityStatus.Text = string.Empty;
            }
        }
        /// <summary>
        /// 药物过敏史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAllergyYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAllergyYes.Checked)
            {
                txtBoxAllergy.Enabled = true;
            }
            if (rbtnAllergyNo.Checked)
            {
                txtBoxAllergy.Enabled = false;
                txtBoxAllergy.Text = string.Empty;
            }
        }
        /// <summary>
        /// 暴露史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnExposureHistoryYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnExposureHistoryYes.Checked)
            {
                txtBoxrExposureHistory.Enabled = true;
            }
            if (rbtnExposureHistoryNo.Checked)
            {
                txtBoxrExposureHistory.Enabled = false;
                txtBoxrExposureHistory.Text = string.Empty;
            }
        }
        /// <summary>
        /// 疾病史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDiseasesHistoryYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDiseasesHistoryYes.Checked)
            {
                txtBoxDiseasesHistory.Enabled = true;
            }
            if (rbtnDiseasesHistoryNo.Checked)
            {
                txtBoxDiseasesHistory.Enabled = false;
                txtBoxDiseasesHistory.Text = string.Empty;
            }
        }
        /// <summary>
        /// 手术史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnOperationHistoryYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOperationHistoryYes.Checked)
            {
                txtBoxOperationHistory.Enabled = true;
            }
            if (rbtnOperationHistoryNo.Checked)
            {
                txtBoxOperationHistory.Enabled = false;
                txtBoxOperationHistory.Text = string.Empty;
            }
        }
        /// <summary>
        /// 外伤史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnRtaumaHistoryYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRtaumaHistoryYes.Checked)
            {
                txtBoxRtaumaHistory.Enabled = true;
            }
            if (rbtnRtaumaHistoryNo.Checked)
            {
                txtBoxRtaumaHistory.Enabled = false;
                txtBoxRtaumaHistory.Text = string.Empty;
            }
        }
        /// <summary>
        /// 输血史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnTransfusionHistoryYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTransfusionHistoryYes.Checked)
            {
                txtBoxTransfusionHistory.Enabled = true;
            }
            if (rbtnTransfusionHistoryNo.Checked)
            {
                txtBoxTransfusionHistory.Enabled = false;
                txtBoxTransfusionHistory.Text = string.Empty;
            }
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

        private void PatientInfoForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_patientId))
            {
              DataTable dt= PatientInfo_Select();
                if (null != dt && dt.Rows.Count > 0)
                {
                    txtBoxName.Text = dt.Rows[0]["PatientName"].ToString();

                    if (dt.Rows[0]["Gender"].ToString() != "男")
                    {
                        rbtnSexF.Checked = true;
                    }
                    else
                    {
                        rbtnSexM.Checked = true;
                    }
                    dateTPBirthday.Value = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                    cBoxNational.Text = dt.Rows[0]["Folk"].ToString();
                    txtBoxID.Text = dt.Rows[0]["P_Id"].ToString();
                    txtBoxWorkUnits.Text = dt.Rows[0]["WorkUnits"].ToString();
                    txtBoxPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtBoxRegistrationAddress.Text = dt.Rows[0]["Address"].ToString();
                    cBoxLevelofeducation.Text = dt.Rows[0]["Levelofeducation"].ToString();
                    cBoxMarriage.Text = dt.Rows[0]["Marriage"].ToString();
                    cBoxPermanentType.Text = dt.Rows[0]["PermanentType"].ToString();
                    cBoxBloodType.Text = dt.Rows[0]["BloodType"].ToString();
                    cBoxSleepStatus.Text = dt.Rows[0]["SleepStatus"].ToString();
                    cBoxPhysicalExercise.Text = dt.Rows[0]["PhysicalExercise"].ToString();
                    cBoxDrinking.Text = dt.Rows[0]["Drinking"].ToString();
                    cBoxProfessional.Text = dt.Rows[0]["Professional"].ToString();
                    txtBoxHeight.Text = dt.Rows[0]["Height"].ToString();
                    txtBoxWaistline.Text = dt.Rows[0]["Waistline"].ToString();
                    txtBoxHipline.Text = dt.Rows[0]["Hipline"].ToString();
                    txtBoxWeight.Text = dt.Rows[0]["Weight"].ToString();

                    string[] splitString = dt.Rows[0]["DisabilityStatus"].ToString().Split('&');
                    if (splitString.Length>0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnDisabilityStatusNo.Checked = true;
                        }
                        else
                        {
                            rbtnDisabilityStatusYes.Checked = true;
                            txtBoxDisabilityStatus.Text = splitString[1];
                        }
                    }
                    splitString = dt.Rows[0]["Allergy"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnAllergyNo.Checked = true;
                        }
                        else
                        {
                            rbtnAllergyYes.Checked = true;
                            txtBoxAllergy.Text = splitString[1];
                        }
                    }

                    splitString = dt.Rows[0]["ExposureHistory"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnExposureHistoryNo.Checked = true;
                        }
                        else
                        {
                            rbtnExposureHistoryYes.Checked = true;
                            txtBoxrExposureHistory.Text = splitString[1];
                        }
                    }
                    splitString = dt.Rows[0]["DiseasesHistory"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnDiseasesHistoryNo.Checked = true;
                        }
                        else
                        {
                            rbtnDiseasesHistoryYes.Checked = true;
                            txtBoxDiseasesHistory.Text = splitString[1];
                        }
                    }

                    splitString = dt.Rows[0]["OperationHistory"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnOperationHistoryNo.Checked = true;
                        }
                        else
                        {
                            rbtnOperationHistoryYes.Checked = true;
                            txtBoxOperationHistory.Text = splitString[1];
                        }
                    }
                    splitString = dt.Rows[0]["RtaumaHistory"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnRtaumaHistoryNo.Checked = true;
                        }
                        else
                        {
                            rbtnRtaumaHistoryYes.Checked = true;
                            txtBoxRtaumaHistory.Text = splitString[1];
                        }
                    }

                    splitString = dt.Rows[0]["TransfusionHistory"].ToString().Split('&');
                    if (splitString.Length > 0)
                    {
                        if (splitString[0] == "无")
                        {
                            rbtnTransfusionHistoryNo.Checked = true;
                        }
                        else
                        {
                            rbtnTransfusionHistoryYes.Checked = true;
                            txtBoxTransfusionHistory.Text = splitString[1];
                        }
                    }
                  
                }
            }
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMod_Click(object sender, EventArgs e)
        {
            var pmMd = new PatientMd
            {
                PatientID =_patientId,
                WorkUnits = txtBoxWorkUnits.Text.Trim(),
                Phone = txtBoxPhone.Text.Trim(),
                Address = txtBoxRegistrationAddress.Text.Trim(),
                Levelofeducation = cBoxLevelofeducation.Text,
                Marriage = cBoxMarriage.Text,
                PermanentType = cBoxPermanentType.Text,
                BloodType = cBoxBloodType.Text,
                SleepStatus = cBoxSleepStatus.Text,
                PhysicalExercise = cBoxPhysicalExercise.Text,
                Drinking = cBoxDrinking.Text,
                Professional = cBoxProfessional.Text,
                Height = txtBoxHeight.Text.Trim(),
                Waistline = txtBoxWaistline.Text.Trim(),
                Hipline = txtBoxHipline.Text.Trim(),
                Weight = txtBoxWeight.Text.Trim(),
                DisabilityStatus = (rbtnDisabilityStatusNo.Checked ? "无&" : "有&" + txtBoxDisabilityStatus.Text.Trim()),
                Allergy = (rbtnAllergyNo.Checked ? "无&" : "有&" + txtBoxAllergy.Text.Trim()),
                ExposureHistory = (rbtnExposureHistoryNo.Checked ? "无&" : "有&" + txtBoxrExposureHistory.Text.Trim()),
                DiseasesHistory = (rbtnDiseasesHistoryNo.Checked ? "无&" : "有&" + txtBoxDiseasesHistory.Text.Trim()),
                OperationHistory = (rbtnOperationHistoryNo.Checked ? "无&" : "有&" + txtBoxOperationHistory.Text.Trim()),
                RtaumaHistory = (rbtnRtaumaHistoryNo.Checked ? "无&" : "有&" + txtBoxRtaumaHistory.Text.Trim()),
                TransfusionHistory = (rbtnTransfusionHistoryNo.Checked ? "无&" : "有&" + txtBoxTransfusionHistory.Text.Trim())
            };
            bool ok = PatientInfo_Mod(pmMd);
            if (ok)
            {
                XtraMessageBox.Show(@"修改成功！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_MouseDown(object sender, MouseEventArgs e)
        {
            btnRead.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_MouseUp(object sender, MouseEventArgs e)
        {
            btnRead.BackColor = Color.FromArgb(35, 144, 240);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMod_MouseDown(object sender, MouseEventArgs e)
        {
            btnMod.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMod_MouseUp(object sender, MouseEventArgs e)
        {
            btnMod.BackColor = Color.FromArgb(35, 144, 240);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_MouseDown(object sender, MouseEventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(15, 96, 168);
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_MouseUp(object sender, MouseEventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(35, 144, 240);
        }


    }
}
