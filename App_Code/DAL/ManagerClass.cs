using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace English.dal
{
    /// <summary>
    ///ManagerClass 的摘要说明
    /// </summary>
    public class ManagerClass
    {
        DBSql dbObj = new DBSql();
        public ManagerClass()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="P_Str_Name">sql语句</param>
        /// <returns></returns>
        /// 
        public int AdminExists(string sql)
        {
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                i = (int)myCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return i;
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="P_Str_srcTable">信息表名</param>
        /// <returns></returns>
        public DataSet ReturnIfo(string sql, string P_Str_srcTable)
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
                throw (ex);
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

        public int AddExecSql(string sql, string name, string content, DateTime time)
        {
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                myCmd.Parameters.Add("@content", SqlDbType.VarChar).Value = content;
                myCmd.Parameters.Add("@time", SqlDbType.DateTime).Value = time;
                i = myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return i;
        }
        /// <summary>
        /// 执行一条sql语句，删除留言
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <returns>返回受影响的行数</returns>
        public int DelExecSql(string sql, int id)
        {
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        /// 执行一条sql语句，回复留言
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <param name="huifu">回复内容</param>
        /// <returns>返回受影响的行数</returns>
        public int PlyExecSql(string sql, int id, string huifu)
        {
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                myCmd.Parameters.Add("@huifu", SqlDbType.VarChar).Value = huifu;
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
        /// 添加系统管理员信息
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int AddInfos(string sql)
        {
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            int i = 0;
            try
            {
               
                i = myCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return i;
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        public void ExecSql(string sql)
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
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
        }

    }



}
