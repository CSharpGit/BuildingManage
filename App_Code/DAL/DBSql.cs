using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace English.dal
{
    /// <summary>
    ///DBSql 的摘要说明
    /// </summary>
    public class DBSql
    {
        public DBSql()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>Sqlconnection对象</returns>
        public SqlConnection GetConnection()
        {
            string myStr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConn = new SqlConnection(myStr);
            return myConn;
        }
    }
}
