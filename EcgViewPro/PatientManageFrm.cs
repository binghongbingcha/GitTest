using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CommonProj;
using System.IO;
using System.Threading;
using DevExpress.XtraEditors;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EcgViewPro
{
    public partial class PatientManageFrm : Form
    {
     
        /// <summary>
        /// 总记录数
        /// </summary>
        private int _recordCount;

        private const string AppName = "申请判读";
        readonly SqliteOptions _sqlite;
        int _rowIndex;

        private Task _getAppDataTask;

        private readonly List<string> _appIds = new List<string>(); 

        public PatientManageFrm() 
        {
            InitializeComponent();
            _sqlite = new SqliteOptions();
            wp.PageSize = ConfigHelper.PAGE_SIZE;
            txtPageSize.Text = wp.PageSize.ToString();
        }


        private void PatientManage_Frm_Load(object sender, EventArgs e)
        {

            _getAppDataTask = new Task(WaitGetAppData);
            _getAppDataTask.Start();

            txtID.Text = ConfigHelper.IP;
            gc_PatientManage.AutoGenerateColumns = false;
            gc_EcgList.AutoGenerateColumns = false;
          
            gc_PatientManage.RowHeadersVisible = false;//行头隐藏
            gc_EcgList.RowHeadersVisible = false;//行头隐藏
          

            //禁止用户改变 DataGridView1的所有行的行高
            gc_PatientManage.AllowUserToResizeRows = false;
            gc_EcgList.AllowUserToResizeRows = false;
     
            //让 dataGridView_Message的所有列宽自动调整一下。
           // dataGridView_Message.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //让 DataGridView1的第一列的列宽自动调整一下。
      
            gc_EcgList.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);

            WindowState = FormWindowState.Maximized;comboBox1.SelectedIndex = 0;
            txtID.Focus();
        }

        public async void BingData()
        {
            await Task.Run(new Action(RefleshListEcgData));
        }
  
        #region 分页
        //分页事件
        private int wp_EventPaging(EventPagingArg e)
        {
            BindPagedData(wp.PageIndex, GetFilterContidition());
            return _recordCount;
        }

        private PatientMd GetFilterContidition()
        {
            var pm = new PatientMd {P_Id = txtID.Text.Trim().Replace("'", "''")};
            if (comboBox1.SelectedIndex != 0)
            {
                pm.Gender = comboBox1.Text.Trim();
            }
            pm.PatientName = textBox1.Text.Trim().Replace("'", "''");
          
            pm.AgeStart = tbAgeStart.Text;
            pm.AgeEnd = tbAgeEnd.Text;
            if (string.IsNullOrEmpty(pm.PatientName))
            {
                pm.CollectionStartDate = dateTimePicker1.Value.ToShortDateString();
                pm.ConllectionEndDate = dateTimePicker2.Value.ToShortDateString();
            }
            else
            {
                pm.CollectionStartDate = new DateTime(1900, 1, 1).ToShortDateString();
                pm.ConllectionEndDate = DateTime.Now.ToShortDateString();
            }
            return pm;
        }

        private void BindPagedData(int index, PatientMd p)
        {
           
            int account = 0;
            wp.PageIndex = index;
            DataTable dt = QueryPatients(p, wp.PageSize, wp.PageIndex, ref account);
            wp.TotalRows = _recordCount;
            gc_PatientManage.DataSource = dt;
            _recordCount = account;
            if (gc_PatientManage.RowCount > 0)
            {
                gc_PatientManage.CurrentCell = gc_PatientManage.Rows[_rowIndex].Cells[0];
            }
        }

        /// <summary>
        /// 根据条件分页查询患者
        /// </summary>
        /// <param name="pm">患者对象（检索条件）</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">第几页（从第一页开始）</param>
        /// <param name="rowsCount">返回总记录数</param>
        /// <returns></returns>
        private DataTable QueryPatients(PatientMd pm, int pageSize, int pageIndex, ref int rowsCount)
        {
            DateTime startDate = Convert.ToDateTime(pm.CollectionStartDate);
            DateTime endDate = Convert.ToDateTime(pm.ConllectionEndDate);
            if (startDate > endDate)
            {
                string dtTmp = pm.CollectionStartDate;
                pm.CollectionStartDate = pm.ConllectionEndDate;
                pm.ConllectionEndDate = dtTmp;
            }
            int start = (pageIndex - 1) * pageSize;//从第N条开始取数据
            var dt = new DataTable();//存储分页数据
            var tbl = new DataTable();//存储行数
            const string of = " CreateDate desc";


            #region  SQLITE 分页语句

            const string strPdzt = " InterpretationStatus as PDZT,";

            string sql = @"select ifnull(b.[wardshipId],a.CreateDate)- Birthday as Birthday2,IsQiBo,Folk,[Gender],Birthday,[P_Id],[PatientName],(case when( select count(1) as SumEcg from Tb_Application d where d.PatientID=a.PatientID)>0 then '有' else '无' end) as EcgDataState,(case when( select count(1) as SumStatus from Tb_Application dp where dp.PatientID=a.PatientID and Status='3') >0 then '有' else '无' end) as OpeartionState," + strPdzt + "ifnull(b.[wardshipId],a.CreateDate) as CreateDate2,a.CreateDate,a.PatientID,ID,b.CompressType from tb_patientinfo a left join tb_application b on a.[PatientID]=b.[PatientID] WHERE 1=1 ";
            var sbQuery = new StringBuilder(sql);
            var sbCount = new StringBuilder("SELECT COUNT(*) FROM(select a.[PatientID]," + strPdzt + "ifnull(b.[wardshipId],a.CreateDate) as CreateDate2,a.PatientID,ID from tb_patientinfo a left join tb_application b on a.[PatientID]=b.[PatientID] WHERE 1=1 ");
            var sbFilter = new StringBuilder();

            if (ConfigHelper.LoginName != "admin")
            {
                sbFilter.Append(" and DoctorId = '").Append(ConfigHelper.LoginId).Append("' ");
            }

            if (!string.IsNullOrEmpty(pm.P_Id))
            {
                sbFilter.Append(" and P_ID like '%").Append(pm.P_Id).Append("%' ");
            }

            if (!string.IsNullOrEmpty(pm.PatientName))
            {
                sbFilter.Append(" and PatientName like '%").Append(pm.PatientName).Append("%' ");
            }


            if (!string.IsNullOrEmpty(pm.Gender) && pm.Gender != "0")
            {
                sbFilter.Append(" and Gender= '").Append(pm.Gender).Append("' ");
            }

            if (!string.IsNullOrEmpty(pm.AgeStart))
            {
                var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                sbFilter.Append(" and Birthday <='").Append(startTime.AddYears(-Convert.ToInt32(tbAgeStart.Text) + 1).ToString("yyyy-MM-dd")).Append("' ");
            }

            if (!string.IsNullOrEmpty(pm.AgeEnd))
            {
                var date = new DateTime(DateTime.Now.Year, 1, 1);
                sbFilter.Append(" and Birthday >='").Append(date.AddYears(-Convert.ToInt32(tbAgeEnd.Text)).ToString("yyyy-MM-dd")).Append("' ");
            }
            var sbCjsj = new StringBuilder();

            bool canCancel = !string.IsNullOrEmpty(pm.P_Id);

            if (!canCancel)
            {
                sbCjsj.Append(" and createdate2 >='").Append(Convert.ToDateTime(pm.CollectionStartDate).ToString("yyyy-MM-dd")).Append("'").Append(" and createdate2 <'").Append(Convert.ToDateTime(pm.ConllectionEndDate).AddDays(1).ToString("yyyy-MM-dd")).Append("'");
            }


            if (sbFilter.Length > 0)
            {
                sbQuery.Append(sbFilter);
                sbCount.Append(sbFilter);
            }
            sbQuery.Append(sbCjsj);
            sbQuery.Append(") as t ");

            sbCount.Append(sbCjsj);

            string s = "select Birthday2,IsQiBo,Folk,[Gender],Birthday,[P_Id],strftime('%Y-%m-%d'," + of.Replace(" desc", "") + ") as CreateDate,[PatientName],[PatientID],[ID],CompressType,EcgDataState,OpeartionState,PDZT,'查阅与诊断' as EcgAnalisis,'采集' as EcgGather ,'修改' as EditPatient,'删除' as DeletePatient from (";
            var sbUnion = new StringBuilder(s);
            sbUnion.Append(sbQuery).Append(" group by [PatientID] order by ").Append(" strftime('%Y-%m-%d %H:%M:%S', CreateDate2) desc ").Append(" limit ").Append(pageSize.ToString()).Append(" offset ").Append(start.ToString());

            try
            {
                sql = sbUnion.ToString();
                dt = _sqlite.ExcuteSqlite(sql);
                sbCount.Append(" group by a.[PatientID])");
                sql = sbCount.ToString();
                tbl = _sqlite.ExcuteSqlite(sql);
            }
            catch
            {
            }


            #endregion



            if (tbl != null && tbl.Rows.Count > 0)
            {
                rowsCount = Convert.ToInt32(tbl.Rows[0][0]);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                var dcFlag = new DataColumn("flag", typeof(bool));
                dt.Columns.Add(dcFlag);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["flag"] = false;
                }
            }
            return dt;
        }
        #endregion


        public void RefleshListEcgData()
        {
            wp.Bind();
        }

        DataTable _dtEcgDataList = new DataTable();
      
        /// <summary>
        /// 根据患者ID验证是否存在申请数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        private bool Check_App_status(string patientId)
        {
            string sql = "select count(*) as ct from tb_Application where PatientID='" + patientId + "'";
            int num = 0;

            DataTable dt = _sqlite.ExcuteSqlite(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                num = Convert.ToInt32(dt.Rows[0]["ct"]);
            }
            if (num > 0)
            {
                return true;

            }
            return false;
        }


        //分页行数只允许输入数字
        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '\b')))
            {
                e.Handled = true;
            }
        }

        //保存分页行数
        private void btnSavePageSize_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigHelper.PAGE_SIZE = Convert.ToInt32(txtPageSize.Text);
                if (ConfigHelper.PAGE_SIZE <= 100)
                {
                }
                else
                {
                    ConfigHelper.PAGE_SIZE = 100;
                    txtPageSize.Text = (100).ToString();
                    XtraMessageBox.Show(@"每页显示条数为1到100！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                wp.PageSize = ConfigHelper.PAGE_SIZE;

                ConfigHelper.SaveConfig("PAGE_SIZE", ConfigHelper.PAGE_SIZE.ToString());

                wp.PageIndex = 1;
                wp.Bind();
            }
            catch
            {
                XtraMessageBox.Show(@"每页显示条数为1到100！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #region 年龄只能输入数字验证
        private void tbAgeStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '\b')))
            {
                e.Handled = true;
            }
        }

        private void tbAgeEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '\b')))
            {
                e.Handled = true;
            }
        }
        #endregion

     
        private void gc_EcgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dtEcgDataList.Rows.Count <= 0|| gc_PatientManage.Rows.Count<=0)
            {
                return;
            }

            if (gc_EcgList.CurrentRow != null)
            {
                int index=gc_EcgList.CurrentRow.Index;
                if (gc_PatientManage.CurrentRow != null)
                {
                    DataRow dr = ((DataRowView)gc_PatientManage.CurrentRow.DataBoundItem).Row;

                    string appId = gc_EcgList.Rows[index].Cells["ApplicationID"].Value.ToString();
                    var pmd = new PatientMd();
                    #region 心电图分析
                    //心电图分析
                    if (gc_EcgList.Columns[e.ColumnIndex]==EcgAnalisis)
                    {
                        string isQiBo = dr["IsQiBo"].ToString();
                        string errorLead = _dtEcgDataList.Rows[index]["errorLead"].ToString();
                        pmd.WardshipId = _dtEcgDataList.Rows[index]["wardshipId"].ToString();
                        pmd.PatientID = dr["PatientID"].ToString();
                        pmd.PatientName =dr["PatientName"].ToString();
                        pmd.Gender = dr["Gender"].ToString();
                        pmd.AgeStart = string.Empty;
                        if (string.IsNullOrEmpty(dr["Birthday"].ToString().Trim()))
                        {
                            pmd.AgeStart = "0";
                        }
                        else
                        {
                            pmd.AgeStart = (Convert.ToDateTime(pmd.WardshipId).Year - Convert.ToDateTime(dr["Birthday"].ToString().Trim()).Year).ToString();
                        }
                        pmd.P_Id =dr["P_Id"].ToString();

                        pmd.AppId = appId;


                        pmd.Pdstatus = _dtEcgDataList.Rows[index]["InterpretationStatus"].ToString();

                        string status = _dtEcgDataList.Rows[index]["status"].ToString();
                        bool isApped = true;

                        pmd.LEU = _dtEcgDataList.Rows[index]["LEU"].ToString();
                        pmd.NIT = _dtEcgDataList.Rows[index]["NIT"].ToString();
                        pmd.UBG = _dtEcgDataList.Rows[index]["UBG"].ToString();
                        pmd.PRO = _dtEcgDataList.Rows[index]["PRO"].ToString();
                        pmd.PH = _dtEcgDataList.Rows[index]["PH"].ToString();
                        pmd.BLD = _dtEcgDataList.Rows[index]["BLD"].ToString();
                        pmd.KET = _dtEcgDataList.Rows[index]["KET"].ToString();
                        pmd.BIL = _dtEcgDataList.Rows[index]["BIL"].ToString();
                        pmd.GLU = _dtEcgDataList.Rows[index]["GLU"].ToString();
                        pmd.VC =  _dtEcgDataList.Rows[index]["VC"].ToString();
                        pmd.SG = _dtEcgDataList.Rows[index]["SG"].ToString();
                        pmd.Mmol = _dtEcgDataList.Rows[index]["Mmol"].ToString();
                        pmd.Spo2 = _dtEcgDataList.Rows[index]["Spo2"].ToString();
                        pmd.DIA =  _dtEcgDataList.Rows[index]["DIA"].ToString();
                        pmd.SYS =  _dtEcgDataList.Rows[index]["SYS"].ToString();
                        pmd.Temperature = _dtEcgDataList.Rows[index]["Temperature"].ToString();

                        if (status == "1")
                        {
                            isApped = false;
                        }
                        var evf = new EcgViewFrm(pmd, false, isQiBo, isApped, errorLead)
                        {
                            FormBorderStyle = FormBorderStyle.None,
                            WindowState = FormWindowState.Maximized
                        };
                        evf.ShowDialog();
                    }
                    #endregion

                    #region 远程申请

                    if (gc_EcgList.Columns[e.ColumnIndex] == LongConnect)
                    {
                        var extContract = new ExtContract {Data = new EcgData[1]};
                        var combination = new Combination
                        {LEU = _dtEcgDataList.Rows[index]["LEU"].ToString(),
                            NIT = _dtEcgDataList.Rows[index]["NIT"].ToString(),
                            UBG = _dtEcgDataList.Rows[index]["UBG"].ToString(),
                            PRO = _dtEcgDataList.Rows[index]["PRO"].ToString(),
                            PH = _dtEcgDataList.Rows[index]["PH"].ToString(),
                            BLD = _dtEcgDataList.Rows[index]["BLD"].ToString(),
                            KET = _dtEcgDataList.Rows[index]["KET"].ToString(),
                            BIL = _dtEcgDataList.Rows[index]["BIL"].ToString(),
                            GLU = _dtEcgDataList.Rows[index]["GLU"].ToString(),
                            VC = _dtEcgDataList.Rows[index]["VC"].ToString(),
                            SG = _dtEcgDataList.Rows[index]["SG"].ToString(),
                            Mmol = _dtEcgDataList.Rows[index]["Mmol"].ToString(),
                            Spo2 = _dtEcgDataList.Rows[index]["Spo2"].ToString(),
                            DIA = _dtEcgDataList.Rows[index]["DIA"].ToString(),
                            SYS = _dtEcgDataList.Rows[index]["SYS"].ToString(),
                            Temperature = _dtEcgDataList.Rows[index]["Temperature"].ToString()
                        };
                        extContract.Others = combination;
                        var patient = new Patient
                        {
                            PatientID = dr["PatientID"].ToString(),PatientName = dr["PatientName"].ToString(),
                            NewId = dr["P_Id"].ToString(),
                            IsQiBo = dr["IsQiBo"].ToString(),
                            Status ="1"
                        };
                        extContract.God = patient;

                        var ecgData = new EcgData();
                        string sqli =
                            "SELECT data_packs.beginTime,pureData,LeadEndTime,data_packs.EcgFilter,data_packs.IsLead,data_packs.PaceLocs FROM data_packs inner join tb_Application on data_packs.ApplicationID=tb_Application.ApplicationID  WHERE  data_packs.applicationID='" +
                            appId + "' and isLead='0' order by beginTime asc limit 1 offset 0";
                        DataTable dtBeginTime = _sqlite.ExcuteSqlite(sqli);
                        if (null != dtBeginTime && dtBeginTime.Rows.Count == 1)
                        {
                            ecgData.BeginTime = dtBeginTime.Rows[0]["beginTime"].ToString();
                            ecgData.EcgFilter = dtBeginTime.Rows[0]["EcgFilter"].ToString();
                            ecgData.IsLead = "0";
                            ecgData.PaceLocs ="";

                            if (dtBeginTime.Rows[0]["pureData"] == DBNull.Value)
                            {
                                string ednPathDir = Application.StartupPath + "\\ECG_DATA_NEW" + "\\" + appId + "_" +
                                                    ecgData.IsLead;
                                if (File.Exists(ednPathDir))
                                {
                                    var fs = new FileStream(ednPathDir,
                                        FileMode.Open,
                                        FileAccess.Read);
                                    var br = new BinaryReader(fs, Encoding.UTF8);
                                    ecgData.PureData = Convert.ToBase64String(br.ReadBytes((int) fs.Length));
                                    br.Close();
                                    //fs.Close();
                                }
                            }
                        }
                        else
                        {
                            ecgData.BeginTime = DateTime.Now.ToString();
                            ecgData.EcgFilter = "低通：75Hz";
                            ecgData.IsLead = "0";
                            ecgData.PaceLocs ="";
                            ecgData.PureData = null;
                        }
                        extContract.Data[0] = ecgData;

                        var transition = new Transition
                        {
                            ApplicationID = appId,
                            InptLevel = ConfigHelper.InterpretationLevel,
                            CommunityOrgID = ConfigHelper.ORGID
                        };

                        if (null != dtBeginTime && dtBeginTime.Rows.Count == 1)
                        {
                            transition.CheckDate = dtBeginTime.Rows[0]["beginTime"].ToString();
                            transition.GatherCompletionTime = dtBeginTime.Rows[0]["LeadEndTime"].ToString();
                        }
                        else
                        {
                            transition.CheckDate = DateTime.Now.ToString();
                            transition.GatherCompletionTime = DateTime.Now.ToString();
                        }
                        extContract.Trans = transition;

                        var contract = new Contract
                        {
                            ApplicationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            ApplicationUserID = ConfigHelper.LoginId
                        };
                        switch (ConfigHelper.InterpretationLevel)
                        {
                            case "2":
                                contract.Status = "4";
                                break;
                            case "3":
                                contract.Status = "5";
                                break;
                            default:
                                contract.Status = "3";
                                break;

                        }
                        extContract.Contr = contract;
                        ThreadPool.QueueUserWorkItem(WaitAppData, extContract);
                        UpdateApplicationStatus(appId, "4");
                        SelEcgList(extContract.God.PatientID);
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 在线程池中等待申请的数据
        /// </summary>
        private void WaitAppData(object extContract)
        {
            try
            {
                if (null == ConfigHelper.Cvur)
                {
                    var request = (HttpWebRequest)WebRequest.Create(ConfigHelper.UrlDistanceString+@"/token");
                    request.Method = "post"; request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                    var stream = request.GetRequestStream();
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("grant_type=password&username="+ConfigHelper.UrlUserName+"&password="+ConfigHelper.UrlPassWord);
                        writer.Flush();
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    string strjson = CommonRemoteApplication.GetResponseString(response);
                    ConfigHelper.Cvur = JsonConvert.DeserializeObject<CommonVerifyUrlResult>(strjson);
                }
                if (ConfigHelper.Cvur != null)
                {
                    var ext = (ExtContract)extContract;
                    var json = JsonConvert.SerializeObject(ext);
                    var msg = CommonRemoteApplication.DoPostMethodToObj<Msg>(ConfigHelper.UrlDistanceString + @"/api/AllInOne/Create", json);
                    if (msg != null)
                    {
                        bool msgOk = msg.IsOk;
                        if (msgOk)
                        {
                            UpdateApplicationStatus(ext.Trans.ApplicationID, "2");
                            SelEcgList(ext.God.PatientID);
                            _isGetAppData = true;
                        }
                        else
                        {
                            WatchDog.WriteMsg(@"申请失败：" + msg.Content);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WatchDog.Write(@" 待申请的数据：", ex);
            }
          
        }
        /// <summary>  
        /// 更新申请状态
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="status"></param>
        private void UpdateApplicationStatus(string applicationId,string status)
        {
            var so = new SqliteOptions();
            string sql = string.Format("Update tb_Application set status='{1}' where ApplicationId='{0}'", applicationId,status);
            so.SqliteUpdate(sql);
        }
        /// <summary>
        /// 更新判读结果
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="beginTime"></param>
        /// <param name="diagnosis"></param>
        private void UpdateApplicationDiagnosis(string applicationId,DateTime beginTime,string diagnosis)
        {
            var so = new SqliteOptions();
            string sql = string.Format("update tb_Application set InterpretationStatus='已判读' where ApplicationId='{0}'", applicationId);
            so.SqliteUpdate(sql);
            
            sql = string.Format("select * from Tb_Snapshot where ApplicationID='{0}'",applicationId);
            DataTable dso=so.ExcuteSqlite(sql);
            if (null != dso && dso.Rows.Count > 0)
            {
                sql = string.Format("update Tb_Snapshot set Diagnosis='{1}' where ApplicationID='{0}'",applicationId,diagnosis);
                so.SqliteUpdate(sql);
            }
            else
            {
                sql = string.Format(" insert into Tb_Snapshot(ID,ApplicationID,SnapshotTime,Diagnosis) Values('{0}','{1}','{2}','{3}')", Guid.NewGuid(), applicationId, beginTime.ToString("s"), diagnosis);
                so.SqliteAdd(sql);
            }
        }

        private bool _isGetAppData = true;//是否开始获取判读结果
        /// <summary>
        /// 获取判读结果
        /// </summary>
        private void WaitGetAppData()
        {
            while (true)
            {
                try
                {
                    if (null == ConfigHelper.Cvur)
                    {
                        var request = (HttpWebRequest) WebRequest.Create(ConfigHelper.UrlDistanceString + @"/token");
                        request.Method = "post";
                        request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                        var stream = request.GetRequestStream();
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write("grant_type=password&username=" + ConfigHelper.UrlUserName + "&password=" +
                                         ConfigHelper.UrlPassWord);
                            writer.Flush();
                        }
                        var response = (HttpWebResponse) request.GetResponse();
                        string strjson = CommonRemoteApplication.GetResponseString(response);
                        ConfigHelper.Cvur = JsonConvert.DeserializeObject<CommonVerifyUrlResult>(strjson);
                    }
                    if (null != ConfigHelper.Cvur)
                    {
                        if (_isGetAppData)
                        {
                            SelAppDataNums();
                            if (_appIds.Count > 0)
                            {
                                var qp = new QueryParams { CommunityId = ConfigHelper.ORGID, ContractIds = _appIds.ToArray() };
                                var strReturn = JsonConvert.SerializeObject(qp);
                                var rresult =
                                    CommonRemoteApplication.DoPostMethodToObj<ExtRestResult>(
                                        ConfigHelper.UrlDistanceString + @"/api/AllInOne/Result", strReturn);
                                if (null != rresult)
                                {
                                    Msg mg = rresult.State;
                                    if (mg.IsOk)
                                    {
                                        foreach (var result in rresult.Result)
                                        {
                                            UpdateApplicationStatus(result.ContractId, "3");
                                            UpdateApplicationDiagnosis(result.ContractId, result.BeginTime, result.Diagnosis);
                                            DataRow dr = ((DataRowView)gc_PatientManage.CurrentRow.DataBoundItem).Row;
                                            if (null != dr)
                                            {
                                                SelEcgList(dr["PatientId"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                _isGetAppData = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WatchDog.Write(@"获取判读结果：", ex);
                }
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        ///获取正在判读中的数据ID
        /// </summary>
        private void SelAppDataNums()
        {
            _appIds.Clear();
            const string sql = @"select ApplicationId from Tb_Application where status=2";
            DataTable dt = _sqlite.ExcuteSqlite(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!_appIds.Contains(dr["ApplicationId"].ToString()))
                    {
                        _appIds.Add(dr["ApplicationId"].ToString());
                    }
                }
            }
        }


        private void gc_PatientManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (gc_PatientManage.RowCount > 0)
            {
                _rowIndex = e.RowIndex;
                DataRow dr = ((DataRowView)gc_PatientManage.Rows[e.RowIndex].DataBoundItem).Row;
                string patientId = string.Empty;
                if (null != dr)
                {
                    patientId = dr["PatientID"].ToString();
                    qrCodePatientId.Text =@"YJL-"+patientId;
                    qrCodePatientId.Visible = true;
                }
                #region 删除
                if (gc_PatientManage.Columns[e.ColumnIndex] == DeletePatient)
                {
                    if (gc_EcgList.RowCount > 0)
                    {
                        bool status = Check_App_status(patientId);
                        if (status)
                        {
                            XtraMessageBox.Show(@"此患者已有关联信息，不允许删除！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (XtraMessageBox.Show(@"是否确定删除选中的患者？", @"患者删除提示：", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        var sqls = new string[6];
                        sqls[0] = "DELETE FROM data_packs WHERE ApplicationID in(select ApplicationID from tb_Application where patientID='" + patientId + "')";
                        sqls[1] = "DELETE FROM Tb_Snapshot WHERE ApplicationID in(select ApplicationID from tb_Application where patientID='" + patientId + "')";
                        sqls[2] = "DELETE FROM AutoDiagnosis WHERE ApplicationID in(select ApplicationID from tb_Application where patientID='" + patientId + "')";
                        sqls[3] = "delete from Tb_ReportTitle where ApplicationID in(select ApplicationID from tb_Application where patientID='" + patientId + "')";
                        sqls[4] = "DELETE FROM tb_Application WHERE PatientID='" + patientId + "'";
                        sqls[5] = "DELETE FROM Tb_PatientInfo WHERE PatientID='" + patientId + "'";
                        WatchDog.WriteMsg(DateTime.Now + "==删除数据：" + dr["PatientName"] + "，患者ID：" + patientId);

                        DataTable tbl = _sqlite.ExcuteSqlite("SELECT * FROM data_packs WHERE ApplicationID in(select ApplicationID from tb_Application where patientID='" + patientId + "')");
                        bool isSuccess = _sqlite.SqliteExecuteNonQuery(sqls);
                        if (isSuccess)
                        {
                            if (tbl != null && tbl.Rows.Count > 0)
                            {
                                string ednPathDir = Application.StartupPath + "\\ECG_DATA_NEW";
                                for (int j = 0; j < tbl.Rows.Count; j++)
                                {
                                    if (tbl.Rows[j]["pureData"] == DBNull.Value)
                                    {
                                        try
                                        {
                                            File.Delete(ednPathDir + "\\" + tbl.Rows[j]["ApplicationID"].ToString() + "_" + tbl.Rows[j]["isLead"].ToString());
                                        }
                                        catch
                                        { }
                                    }
                                }
                            }
                        }
                        var pIndex = (int)Math.Ceiling(Convert.ToDouble(_recordCount)/ConfigHelper.PAGE_SIZE);
                        if (_recordCount % ConfigHelper.PAGE_SIZE == 0 && wp.PageIndex == pIndex)
                        {
                            if (wp.PageIndex > 1)
                                wp.PageIndex = wp.PageIndex - 1;
                        }
                        gc_EcgList.DataSource = null;
                        wp.Bind();


                        txtID.Text = string.Empty;
                        //XtraMessageBox.Show("患者信息删除成功！");
                        qrCodePatientId.Visible = false;
                    }
                    if (gc_PatientManage.RowCount > 0)
                    {
                        gc_PatientManage.CurrentCell = gc_PatientManage.Rows[e.RowIndex].Cells[0];
                    }
                }
                #endregion

                #region 绑定右侧历史数据

                if (gc_PatientManage.Columns[e.ColumnIndex] != EcgGather &&
                    gc_PatientManage.Columns[e.ColumnIndex] != EditPatient &&
                    gc_PatientManage.Columns[e.ColumnIndex] != DeletePatient)
                {
                    SelEcgList(patientId);
                }

                #endregion      

                #region 公共卫生信息
                if (gc_PatientManage.Columns[e.ColumnIndex] == EditPatient)
                {
                    if (dr != null)
                    {
                        string pId = dr["PatientID"].ToString();
                        var pif = new PatientInfoForm(pId) {WindowState = FormWindowState.Maximized};
                        pif.ShowDialog();
                    }
                    gc_PatientManage.CurrentCell = gc_PatientManage.Rows[e.RowIndex].Cells[0];
                }
                #endregion
            }
            else
            {
                gc_EcgList.DataSource = null;
            }
        }

        private delegate void SelEcgData();

        private void SelEcgList(string patientId)
        {
            SelEcgData selEcgData = delegate()
            {
                var so = new CommonProj.SqliteOptions();
                string sqsel =
                    "select distinct(dp.wardshipId) as wardshipId,errorLead,CompressType,'查阅与诊断' as EcgAnalisis,'删除' as DeleteEcgData,'申请' as LongConnect,'打印' as FastPrint,dp.ApplicationID,Status,InterpretationStatus,replace(ReportTitleName,'心电图报告','')as OrgName,LEU,NIT,UBG,PRO,PH,BLD,KET,BIL,GLU,VC,SG,Mmol,Spo2,DIA,SYS,Temperature from Tb_Application dp left join Tb_ReportTitle rt on dp.ApplicationID=rt.ApplicationID where dp.PatientID='" +
                    patientId + "' ";
                _dtEcgDataList = so.ExcuteSqlite(sqsel);
                if (null != _dtEcgDataList)
                {
                    for (int i = 0; i < _dtEcgDataList.Rows.Count; i++)
                    {
                        string status = _dtEcgDataList.Rows[i]["Status"].ToString();
                        if (status == "1") //未申请
                        {
                            _dtEcgDataList.Rows[i]["LongConnect"] = AppName;
                        }
                        else if (status == "2") //已申请，但未判读完成
                        {
                            _dtEcgDataList.Rows[i]["LongConnect"] = "正在判读中";
                        }
                        else if (status == "3") //已申请，远程判读完成
                        {
                            _dtEcgDataList.Rows[i]["LongConnect"] = "判读完成";
                            _dtEcgDataList.Rows[i]["InterpretationStatus"] = "已判读";
                        }
                        else if (status == "4") //已申请，但是数据发送失败
                        {
                            _dtEcgDataList.Rows[i]["LongConnect"] = "正在申请中";
                        }
                    }
                }

                gc_EcgList.DataSource = _dtEcgDataList;
            };
            gc_EcgList.Invoke(selEcgData);
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gc_PatientManage_DoubleClick(object sender, EventArgs e)
        {
            if (gc_PatientManage.RowCount > 0)
            {
               
                if (gc_PatientManage.CurrentRow != null)
                {
                    ConfigHelper.AppId = Guid.NewGuid().ToString();
                    ConfigHelper.PatientId = gc_PatientManage.Rows[gc_PatientManage.CurrentRow.Index].Cells["PatientID"].Value.ToString();
                    ConfigHelper.IP = gc_PatientManage.Rows[gc_PatientManage.CurrentRow.Index].Cells["id_No"].Value.ToString();
                    ConfigHelper.PatientName = gc_PatientManage.Rows[gc_PatientManage.CurrentRow.Index].Cells["PatientName"].Value.ToString();
                    ConfigHelper.PatientGender = gc_PatientManage.Rows[gc_PatientManage.CurrentRow.Index].Cells["Gender"].Value.ToString();
                    ConfigHelper.PatientAge = gc_PatientManage.Rows[gc_PatientManage.CurrentRow.Index].Cells["Birthday2"].Value.ToString();
                }
                XtraMessageBox.Show(@"成功设置为当前信息。", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            int startAge = 0;
            int endAge = 0;
            if (!string.IsNullOrEmpty(tbAgeStart.Text))
            {
                startAge = Convert.ToInt32(tbAgeStart.Text);
            }
            if (!string.IsNullOrEmpty(tbAgeEnd.Text))
            {
                endAge = Convert.ToInt32(tbAgeEnd.Text);
            }
            if (tbAgeStart.Text.Trim() != "" && tbAgeEnd.Text.Trim() != "")
            {
                if (startAge > endAge)
                {
                    XtraMessageBox.Show(@"起始年龄必须小于或等于结束年龄", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            wp.PageIndex = 1;
            wp.Bind();
            if (gc_PatientManage.RowCount > 0)
            {
                gc_PatientManage.CurrentCell = gc_PatientManage.Rows[0].Cells[0];
            }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtID_Click(object sender, EventArgs e)
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
        private void btnSel_MouseDown(object sender, MouseEventArgs e)
        {
            btnSel.BackColor = Color.FromArgb(15, 96, 168);

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_MouseUp(object sender, MouseEventArgs e)
        {
            btnSel.BackColor = Color.FromArgb(35, 144, 240);

        }
        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePageSize_MouseDown(object sender, MouseEventArgs e)
        {
            btnSavePageSize.BackColor = Color.FromArgb(35, 144, 240);
        }

        private void btnSavePageSize_MouseUp(object sender, MouseEventArgs e)
        {
            btnSavePageSize.BackColor = Color.FromArgb(35, 144, 240);
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
