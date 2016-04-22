using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace EcgViewPro
{
    class TransOldData
    {
        //转换数据
        public void TranslateData()
        {
            if (File.Exists(Application.StartupPath + "\\EcgView.dll") && File.Exists(Application.StartupPath + "\\EcgView2.dll"))
            {
                try
                {
                    AccessOptions aoc = new AccessOptions();
                    DataTable patients = aoc.ExcuteSqlite("select * from Tb_PatientInfo");
                    SqliteOptions sq = new SqliteOptions();
                    DateTime defaultDate = new DateTime(2012, 2, 15);
                    if (patients != null && patients.Rows.Count > 0)
                    {
                        foreach (DataRow dr in patients.Rows)
                        {
                            #region 插入患者
                            string CaseID = dr["CaseID"] != DBNull.Value ? dr["CaseID"].ToString() : "";
                            string RoomNum = dr["RoomNum"] != DBNull.Value ? dr["RoomNum"].ToString() : "";
                            string PBedNum = dr["PBedNum"] != DBNull.Value ? dr["PBedNum"].ToString() : "";
                            string cd = dr["CreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["CreateDate"]).ToString("s") : defaultDate.ToString("s");
                            sq.SqliteAdd("INSERT INTO [Tb_PatientInfo]([ID],[PatientName],[Gender],[Birthday],[PatientID],[PatientIdType],[Remark],[CreateDate],[P_Id],[Area],CaseID,RoomNum,PBedNum)VALUES('"
                               + dr["ID"].ToString() + "','" + dr["PatientName"].ToString() + "','" + dr["Gender"].ToString() + "','"
                               + dr["Birthday"].ToString() + "','" + dr["PatientID"].ToString() + "','" + dr["PatientIdType"].ToString() + "','"
                               + dr["Remark"].ToString() + "','" + cd + "','" + dr["P_Id"].ToString() + "','"
                               + dr["Area"].ToString() + "','" + CaseID + "','" + RoomNum + "','" + PBedNum + "')");
                            #endregion
                            #region 插入合同与数据、快照、自动分析、远程报告名称
                            DataTable apps = aoc.ExcuteSqlite("Select distinct WardshipId,PatientID,ApplicationID,Status,CreateDate,InterpretationStatus from data_packs where PatientID='" + dr["PatientID"].ToString() + "'");
                            if (apps != null && apps.Rows.Count > 0)
                            {
                                foreach (DataRow app in apps.Rows)
                                {
                                    string cdate = app["CreateDate"] != DBNull.Value ? Convert.ToDateTime(app["CreateDate"]).ToString("s") : defaultDate.ToString("s");
                                    sq.SqliteAdd("insert into tb_application(ApplicationID,PatientID,Status,InterpretationStatus,CreateDate,wardshipId) values('" + app["ApplicationID"].ToString() + "','"
                                        + app["PatientID"].ToString() + "','" + app["Status"].ToString() + "','" + app["InterpretationStatus"].ToString() + "','"
                                        + cdate + "','" + app["wardshipId"].ToString() + "')");
                                    //以上是申请，一下是心电数据
                                    DataTable dps = aoc.ExcuteSqlite("Select ApplicationID,beginTime,pureData,dataSizePerLead,EcgFilter from data_packs where PatientID='" + app["PatientID"].ToString() + "' and ApplicationID='" + app["ApplicationID"].ToString() + "'");
                                    if (dps != null && dps.Rows.Count > 0)
                                    {
                                        foreach (DataRow dp in dps.Rows)
                                        {
                                            SQLiteParameter sqp = new SQLiteParameter("@Hospita", DbType.Binary);
                                            sqp.Value = (byte[])dp["pureData"];
                                            sq.ExecuteSql("insert into data_packs(ApplicationID,beginTime,pureData,dataSizePerLead,EcgFilter) values('" + dp["ApplicationID"].ToString() + "','"
                                                + Convert.ToDateTime(dp["beginTime"]).ToString("s") + "',@Hospita,'" + dp["dataSizePerLead"].ToString() + "','" + dp["EcgFilter"].ToString() + "')", new SQLiteParameter[] { sqp });
                                        }
                                    }
                                    #region 插入快照
                                    DataTable snapshots = aoc.ExcuteSqlite("Select * from Tb_Snapshot where PatientID='" + app["PatientID"].ToString() + "' and wardshipId='" + app["wardshipId"].ToString() + "'");
                                    if (snapshots != null && snapshots.Rows.Count > 0)
                                    {
                                        foreach (DataRow s in snapshots.Rows)
                                        {
                                            string strType = string.Empty;
                                            try
                                            {
                                                strType = s["Type"].ToString();
                                            }
                                            catch { }
                                            sq.SqliteAdd("insert into tb_snapshot(ID,ApplicationID,SnapshotTime,Diagnosis,Type) values('" + s["ID"].ToString() + "','"
                                                + app["ApplicationID"].ToString() + "','" + Convert.ToDateTime(s["SnapshotTime"]).ToString("s") + "','" + s["Diagnosis"].ToString() + "','" + strType + "')");
                                        }
                                    }
                                    #endregion
                                    #region 插入自动分析
                                    DataTable autoDiagnosis = aoc.ExcuteSqlite("Select ID,wardshipId,PatientID,SnapshotTime,P,P_R,QRS,QT_QTC,QRSDZ,RV5_SV1,BMP from AutoDiagnosis where PatientID='" + app["PatientID"].ToString() + "' and wardshipId='" + app["wardshipId"].ToString() + "'");
                                    if (autoDiagnosis != null && autoDiagnosis.Rows.Count > 0)
                                    {
                                        foreach (DataRow ad in autoDiagnosis.Rows)
                                        {
                                            sq.SqliteAdd("INSERT INTO [AutoDiagnosis]([ID],[ApplicationID],[SnapshotTime],[P],[P_R],[QRS],[QT_QTC],[QRSDZ],[RV5_SV1],[BMP]) VALUES('"
                                                + ad["ID"].ToString() + "','" + app["ApplicationID"].ToString() + "','" + Convert.ToDateTime(ad["SnapshotTime"]).ToString("s") + "','" + ad["P"].ToString() + "','" + ad["P_R"].ToString() + "','"
                                                + ad["QRS"].ToString() + "','" + ad["QT_QTC"].ToString() + "','" + ad["QRSDZ"].ToString() + "','" + ad["RV5_SV1"].ToString() + "','" + ad["BMP"].ToString() + "')");
                                        }
                                    }
                                    #endregion
                                    #region 插入报告名称
                                    DataTable rts = aoc.ExcuteSqlite("Select * from Tb_ReportTitle where PatientID='" + app["PatientID"].ToString() + "' and wardshipId='" + app["wardshipId"].ToString() + "'");
                                    if (rts != null && rts.Rows.Count > 0)
                                    {
                                        foreach (DataRow rt in rts.Rows)
                                        {
                                            string ldept = string.Empty;
                                            string sdept = string.Empty;
                                            try
                                            {
                                                ldept = rt["LastDept"].ToString();
                                                sdept = rt["SecondDept"].ToString();
                                            }
                                            catch { }
                                            sq.SqliteAdd("insert into Tb_ReportTitle (ID,ReportTitleName,CreateTime,[ApplicationID],[FirstUser],[SecondUser],[LastUser],[LastDept],[SecondDept]) values ('"
                                                + rt["ID"].ToString() + "','" + rt["ReportTitleName"].ToString() + "','" + Convert.ToDateTime(rt["CreateTime"]).ToString("s") + "','"
                                                + app["ApplicationID"].ToString() + "','" + rt["FirstUser"].ToString() + "','" + rt["SecondUser"].ToString() + "','"
                                                + rt["LastUser"].ToString() + "','" + ldept + "','" + sdept + "')");
                                        }
                                    }
                                    #endregion
                                }
                            }

                            #endregion
                        }
                        #region 插入病房和病室
                        DataTable rooms = aoc.ExcuteSqlite("select ID,PatientRoomName from PatientRooms");
                        if (rooms != null && rooms.Rows.Count > 0)
                        {
                            foreach (DataRow r in rooms.Rows)
                            {
                                if (!IsDataExists("PatientRooms", "PatientRoomName='" + r["PatientRoomName"].ToString() + "'"))
                                {
                                    sq.SqliteAdd("insert into PatientRooms(ID,PatientRoomName) values('" + r["ID"].ToString() + "','" + r["PatientRoomName"].ToString() + "')");
                                }
                            }
                        }

                        DataTable beds = aoc.ExcuteSqlite("select ID,PatientBedName from PatientBeds");
                        if (beds != null && beds.Rows.Count > 0)
                        {
                            foreach (DataRow b in beds.Rows)
                            {
                                if (!IsDataExists("PatientBeds", "PatientBedName='" + b["PatientBedName"].ToString() + "'"))
                                {
                                    sq.SqliteAdd("insert into PatientBeds(ID,PatientBedName) values('" + b["ID"].ToString() + "','" + b["PatientBedName"].ToString() + "')");
                                }
                            }
                        }
                        #endregion
                        #region 插入科室和默认报告名称、医生
                        DataTable depts = aoc.ExcuteSqlite("Select ID,SectionName,ActiveSection,CreateDateTime from Tb_Section");
                        if (depts != null && depts.Rows.Count > 0)
                        {
                            foreach (DataRow d in depts.Rows)
                            {
                                if (!IsDataExists("Tb_Section", "SectionName='" + d["SectionName"].ToString() + "'"))
                                {
                                    sq.SqliteAdd("insert into Tb_Section(ID,SectionName,ActiveSection,CreateDateTime) values('" + d["ID"].ToString() + "','" + d["SectionName"].ToString() + "','" + d["ActiveSection"].ToString() + "','" + Convert.ToDateTime(d["CreateDateTime"]).ToString("s") + "')");
                                }
                            }
                        }

                        DataTable doctors = aoc.ExcuteSqlite("Select ID,DoctorName,ActiveDoctor,CreateDateTime from Tb_Doctor");
                        if (doctors != null && doctors.Rows.Count > 0)
                        {
                            foreach (DataRow d in doctors.Rows)
                            {
                                if (!IsDataExists("Tb_Doctor", "DoctorName='" + d["DoctorName"].ToString() + "'"))
                                {
                                    sq.SqliteAdd("insert into Tb_Doctor(ID,DoctorName,ActiveDoctor,CreateDateTime) values('" + d["ID"].ToString() + "','" + d["DoctorName"].ToString() + "','" + d["ActiveDoctor"].ToString() + "','" + Convert.ToDateTime(d["CreateDateTime"]).ToString("s") + "')");
                                }
                            }
                        }


                        string sql = "select count(1) from Tb_ReportTitle where ApplicationID is null";
                        DataTable dt = sq.ExcuteSqlite(sql);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            DataTable titles = aoc.ExcuteSqlite("Select * from Tb_ReportTitle where PatientID is null");
                            if (titles != null && titles.Rows.Count > 0)
                            {
                                int count = Convert.ToInt32(dt.Rows[0][0]);
                                if (count == 0)
                                {
                                    foreach (DataRow rt in titles.Rows)
                                    {
                                        sq.SqliteAdd("insert into Tb_ReportTitle (ID,ReportTitleName,CreateTime) values ('"
                                            + rt["ID"].ToString() + "','" + rt["ReportTitleName"].ToString() + "','" + Convert.ToDateTime(rt["CreateTime"]).ToString("s") + "')");
                                    }
                                }
                            }
                        }


                        #endregion
                        try
                        {
                            File.Delete(Application.StartupPath + "\\EcgView.dll");
                        }
                        catch
                        { }
                    }
                }
                catch (Exception ex)
                {
                    FileInfo info = new FileInfo(Application.StartupPath + "\\EcgView.dll");
                    try
                    {
                        info.MoveTo(Application.StartupPath + "\\EcgView20130722.dll");
                    }
                    catch { }
                }
            }
        }

        //验证SQLITE中是否存在该记录
        private bool IsDataExists(string tableName, string contidition)
        {
            bool sign = false;
            string sql = "select count(1) from " + tableName + " where " + contidition;
            SqliteOptions sqlite = new SqliteOptions();
            DataTable dt = sqlite.ExcuteSqlite(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                if (count > 0)
                {
                    sign = true;
                }
            }
            return sign;
        }
    }
}
