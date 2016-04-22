using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace EcgViewPro
{
    public class NewConfig
    {
        internal void BuildNewConfigFile()
        {
            string oldFilePath = Application.StartupPath + @"\DBConfig.xml";
            if (File.Exists(oldFilePath))
            {
                string localConStr = string.Empty;
                string remoteConStr = string.Empty;
                string newFilePath = Application.StartupPath + @"\Test.dll";
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                try
                {
                    ds.ReadXml(oldFilePath);
                    DataRow dr = ds.Tables[0].Rows[0];
                    localConStr = "server='" + dr["HostName"].ToString().Trim() + "';database='" + dr["DataBase"].ToString().Trim() + "';uid='" + dr["UID"].ToString().Trim() + "';pwd='" + dr["PWD"].ToString().Trim() + "';";


                    ds2.ReadXml(Application.StartupPath + @"\DBConfig2.xml");
                    DataRow dr2 = ds2.Tables[0].Rows[0];
                    remoteConStr = "server='" + dr2["HostName"].ToString().Trim() + "';database='" + dr2["DataBase"].ToString().Trim() + "';uid='" + dr2["UID"].ToString().Trim() + "';pwd='" + dr2["PWD"].ToString().Trim() + "';";

                    //StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" standalone=\"yes\" ?><DBConfig><LocalConnectionString>");
                    //sb.Append(localConStr).Append("</LocalConnectionString><DB_SIGN>").Append(dr["DB_SIGN"].ToString()).Append("</DB_SIGN><ShowFlag>");
                    //sb.Append(dr2["ShowFlag"].ToString()).Append("</ShowFlag><PAGE_SIZE>").Append(dr["PAGE_SIZE"].ToString());
                    //sb.Append("</PAGE_SIZE><AREA>").Append(dr["AREA"].ToString()).Append("</AREA><RemoteConnectionString>").Append(remoteConStr);
                    //sb.Append("</RemoteConnectionString><ORGID>").Append(dr2["ORGID"].ToString()).Append("</ORGID><LongDistanceType>");
                    //sb.Append(dr2["LongDistanceType"].ToString()).Append("</LongDistanceType><InterpretationLevel>").Append(dr2["InterpretationLevel"].ToString());
                    //sb.Append("</InterpretationLevel><StartWorkTime>").Append(dr2["StartWorkTime"].ToString()).Append("</<StartWorkTime></DBConfig>");

                    DataTable dt = new DataTable("DBConfig");
                    dt.Columns.Add(new DataColumn("LocalConnectionString", typeof(string)));
                    dt.Columns.Add(new DataColumn("DB_SIGN", typeof(string)));
                    dt.Columns.Add(new DataColumn("ShowFlag", typeof(string)));
                    dt.Columns.Add(new DataColumn("PAGE_SIZE", typeof(string)));
                    dt.Columns.Add(new DataColumn("AREA", typeof(string)));
                    dt.Columns.Add(new DataColumn("RemoteConnectionString", typeof(string)));
                    dt.Columns.Add(new DataColumn("ORGID", typeof(string)));
                    dt.Columns.Add(new DataColumn("LongDistanceType", typeof(string)));
                    dt.Columns.Add(new DataColumn("InterpretationLevel", typeof(string)));
                    dt.Columns.Add(new DataColumn("StartWorkTime", typeof(string)));

                    DataRow newRow = dt.NewRow();
                    newRow["LocalConnectionString"] = localConStr;
                    newRow["DB_SIGN"] = dr["DB_SIGN"].ToString();
                    newRow["ShowFlag"] = dr2["ShowFlag"].ToString();
                    newRow["PAGE_SIZE"] = dr["PAGE_SIZE"].ToString();
                    newRow["AREA"] = dr["AREA"].ToString();
                    newRow["RemoteConnectionString"] = remoteConStr;
                    newRow["ORGID"] = dr2["ORGID"].ToString();
                    newRow["LongDistanceType"] = dr2["LongDistanceType"].ToString();
                    newRow["InterpretationLevel"] = dr2["InterpretationLevel"].ToString();
                    newRow["StartWorkTime"] = dr2["StartWorkTime"].ToString();
                    dt.Rows.Add(newRow);


                    ds2.Dispose();
                    ds.Dispose();

                    MemoryStream ms = new MemoryStream();
                    dt.WriteXml(ms);
                    string s = System.Text.Encoding.UTF8.GetString(ms.ToArray()).Insert(0, "<?xml version=\"1.0\" standalone=\"yes\" ?>");
                    string tmp = DESEncrypt.Encrypt(s);
                    FileStream fs = new FileStream(newFilePath, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    ms.Close();
                    sw.Write(tmp);
                    sw.Close();
                    fs.Close();
                    File.Delete(oldFilePath);
                    File.Delete(Application.StartupPath + @"\DBConfig2.xml");
                }
                catch (Exception ex)
                { }
            }
        }
    }
}
