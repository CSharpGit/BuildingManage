using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace English.dal
{
    /// <summary>
    ///UserClass 的摘要说明
    /// </summary>
    public class UserClass
    {
        DBSql dbObj = new DBSql();
        private DataSet Sqlset = new DataSet();
        private SqlDataAdapter SqlDA = null;
        public UserClass()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="P_Str_srcTable">表名</param>
        /// <returns></returns>
        public DataSet FindInfo(string sql, string P_Str_srcTable)
        {
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, P_Str_srcTable);
            return ds;
        }

        /// <summary>
        /// 添加成员操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ReturnNum(string sql)
        {
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                i = myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return i;
        }

        /// <summary>
        /// 获取留言本的信息
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataSet ExecSql(string sql)
        {
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            Sqlset.Clear();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            SqlDA = new SqlDataAdapter(sql, myConn);
            SqlDA.Fill(Sqlset);
            return Sqlset;

        }
        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <param name="sql">保存sql命令</param>
        /// <returns>返回第一个单元格的值</returns>
        public string ExecReturnFirstCell(string sql)
        {
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            string returnstring = "";
            try
            {
                returnstring = Convert.ToString(myCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return returnstring;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="sql">添加sql命令</param>
        /// <returns></returns>
        public  int AddExecSql(string sql,string UserName,string English, string Chinese)
        {
            DBSql dbObj = new DBSql();
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                myCmd.Parameters.Add("@English", SqlDbType.VarChar).Value = English;
                myCmd.Parameters.Add("@Chinese", SqlDbType.VarChar).Value = Chinese;
                i = myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return i;
        }

        /// <summary>
        /// 执行一条Sql语句
        /// </summary>
        /// <param name="sql">添加sql命令</param>
        /// <returns></returns>
        public void DoExecSql(string sql)
        {
            DBSql dbObj = new DBSql();
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
        }

    }
}
