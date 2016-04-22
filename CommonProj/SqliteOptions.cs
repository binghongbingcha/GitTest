using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace CommonProj
{
    public class SqliteOptions
    {
        public SQLiteConnection SqliteConn = null;
        /// <summary>
        /// 让此类创建一个单例类
        /// </summary>
        public static SqliteOptions Instance = null;//申明一个EcgDrawing对象，复制Null
        private static readonly object LockHelper = new object();

        public static SqliteOptions CreateInstance()
        {
            if (Instance == null)
            {
                lock (LockHelper)
                {
                    if (Instance == null)
                        Instance = new SqliteOptions();
                }
            }
            return Instance;
        }

        public SqliteOptions()
        {
            GetSqliteConnection();
        }

        /// <summary>
        /// 获得sqlite数据库连接
        /// </summary>
        /// <returns></returns>
        public bool GetSqliteConnection()
        {
            try
            {
                string connectionStr = string.Format(@"Data Source=" + Application.StartupPath + @"\EcgView2.dll" + ";Version=3;Password=hljwa ");
                var conn = new SQLiteConnection(connectionStr);
                SqliteConn = conn;
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
            try
            {
                if (SqliteConn.State == ConnectionState.Closed)
                {
                    SqliteConn.Open();  
                }
                var sqliteDp = new SQLiteDataAdapter(sqliteStr, SqliteConn) {SelectCommand = {CommandTimeout = 600000}};
                var sqliteds = new DataSet();
                sqliteDp.Fill(sqliteds);
                return sqliteds.Tables[0];
            }
            catch { return null; }
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
                if (SqliteConn.State == ConnectionState.Closed)
                    SqliteConn.Open();
                var sqliteCmd = new SQLiteCommand(sqliteSQL, SqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                SqliteConn.Close();
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
                if (SqliteConn.State == ConnectionState.Closed)
                    SqliteConn.Open();
                var sqliteCmd = new SQLiteCommand(sqliteSQL, SqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                SqliteConn.Close();
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
                if (SqliteConn.State == ConnectionState.Closed)
                    SqliteConn.Open();
                var sqliteCmd = new SQLiteCommand(sqliteSQL, SqliteConn);
                sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
                SqliteConn.Close();
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
        public int ExecuteSql(string sqlcmd, params SQLiteParameter[] paras)
        {

            var cmd = new SQLiteCommand(sqlcmd, SqliteConn);
            if (SqliteConn.State == ConnectionState.Closed)
            {
                SqliteConn.Open();
            }

            foreach (SQLiteParameter p in paras)
            {
                cmd.Parameters.Add(p);
            }

            int cnt = cmd.ExecuteNonQuery();
            SqliteConn.Close();
            return cnt;
        }




        /// <summary>
        /// Sqlite 执行数据库的多条语句,
        /// </summary>
        /// <param name="sqliteSQL"></param>
        /// <returns></returns>
        public bool SqliteExecuteNonQuery(string[] sqliteSQL)
        {

            if (SqliteConn.State == ConnectionState.Closed)
            {
                SqliteConn.Open();
            }

            SQLiteTransaction sqlTran = SqliteConn.BeginTransaction();
            try
            {
                foreach (string sql in sqliteSQL)
                {
                    var sqliteCmd = new SQLiteCommand(sql, SqliteConn, sqlTran);
                    int i = sqliteCmd.ExecuteNonQuery();
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

                SqliteConn.Close();
            }
            return true;
        }

        public Image GetImg(byte[] imgBytes)
        {
            var ms = new MemoryStream(imgBytes);
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
