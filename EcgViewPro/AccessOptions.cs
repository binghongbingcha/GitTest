using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EcgViewPro
{
    public class AccessOptions
    {
        public OleDbConnection sqliteConn = null;
        /// <summary>
        /// 让此类创建一个单例类
        /// </summary>
        public static AccessOptions _instance = null;//申明一个EcgDrawing对象，复制Null
        private static readonly object lockHelper = new object();

        public static AccessOptions CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new AccessOptions();
                }
            }
            return _instance;
        }

        public AccessOptions()
        {
            GetSqliteConnection();
        }
        /// <summary>
        /// 获得sqlite数据库连接
        /// </summary>
        /// <param name="dbpath"></param>
        /// <returns></returns>
        public bool GetSqliteConnection()
        {
            try
            {
                string ConnectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\EcgView.dll";
                OleDbConnection Conn = new OleDbConnection(ConnectionStr);
                sqliteConn = Conn;
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// 执行sqlite查询语句，并返回一个 DataTable
        /// </summary>
        /// <param name="sqliteStr"></param>
        /// <returns></returns>
        public DataTable ExcuteSqlite(string sqliteStr)
        {
            //if (sqliteConn.State == ConnectionState.Open)
            //    sqliteConn.Close();
            OleDbDataAdapter sqliteDp = new OleDbDataAdapter(sqliteStr, sqliteConn);
            sqliteDp.SelectCommand.CommandTimeout = 600000;
            DataSet sqliteds = new DataSet();
            sqliteDp.Fill(sqliteds);
            return sqliteds.Tables[0];
        }

        /// <summary>
        /// Sqlite 添加数据的操作函数
        /// </summary>
        /// <param name="sqliteSQL"></param>
        /// <returns></returns>
        public bool SqliteAdd(string sqliteSQL)
        {
            try
            {
                if (sqliteConn.State == ConnectionState.Closed)
                    sqliteConn.Open();
                OleDbCommand sqliteCmd = new OleDbCommand(sqliteSQL, sqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                sqliteConn.Close();
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Sqlite 删除数据的操作函数
        /// </summary>
        /// <param name="sqliteSQL"></param>
        /// <returns></returns>
        public bool SqliteDelete(string sqliteSQL)
        {
            try
            {
                if (sqliteConn.State == ConnectionState.Closed)
                    sqliteConn.Open();
                OleDbCommand sqliteCmd = new OleDbCommand(sqliteSQL, sqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                sqliteConn.Close();
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Sqlite 更新数据的操作函数
        /// </summary>
        /// <param name="sqliteSQL"></param>
        /// <returns></returns>
        public bool SqliteUpdate(string sqliteSQL)
        {
            try
            {
                if (sqliteConn.State == ConnectionState.Closed)
                    sqliteConn.Open();
                OleDbCommand sqliteCmd = new OleDbCommand(sqliteSQL, sqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                sqliteConn.Close();
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// 执行SQL语句函数
        /// </summary>
        /// <param name="sqlcmd">SQL语句</param>
        /// <param name="paras">SQL语句中的参数组</param>
        /// <returns>返回受影响记录条数</returns>
        public int ExecuteSql(string sqlcmd, params OleDbParameter[] paras)
        {

            OleDbCommand cmd = new OleDbCommand(sqlcmd, sqliteConn);
            if (sqliteConn.State == ConnectionState.Closed)
            {
                sqliteConn.Open();
            }

            foreach (OleDbParameter p in paras)
            {
                cmd.Parameters.Add(p);
            }

            int cnt = cmd.ExecuteNonQuery();
            sqliteConn.Close();
            return cnt;
        }




        /// <summary>
        /// Sqlite 执行数据库的多条语句,
        /// </summary>
        /// <param name="sqliteSQL"></param>
        /// <returns></returns>
        public bool SqliteExecuteNonQuery(string[] sqliteSQL)
        {

            if (sqliteConn.State == ConnectionState.Closed)
            {
                sqliteConn.Open();
            }

            OleDbTransaction sqlTran = sqliteConn.BeginTransaction();
            try
            {
                foreach (string sql in sqliteSQL)
                {
                    OleDbCommand sqliteCmd = new OleDbCommand(sql, sqliteConn, sqlTran);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteCmd.Dispose();
                }
                sqlTran.Commit();
            }
            catch 
            {
                sqlTran.Rollback();
                return false; 
            }
            finally
            {

                sqliteConn.Close();
            }
            return true;
        }

    }
}
