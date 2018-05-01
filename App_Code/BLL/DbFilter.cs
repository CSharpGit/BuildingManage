using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using English.dal;
using System.Data.SqlClient;

//namespace Build.bll
//{

//    /// <summary>
//    ///Dbfilter 的摘要说明
//    /// </summary>
//    public class Dbfilter
//    {
//        public Dbfilter()
//        {
//            //
//            //TODO: 在此处添加构造函数逻辑
//            //
//        }

//        public static DataSet GetMsgList()
//        {
//            ManagerClass da = new ManagerClass();
//            string sql = "select * from [Liuyan] order by time desc";
//            return da.ReturnIfo(sql, "Liuyan");
//        }

//        /// <summary>
//        /// 添加留言
//        /// </summary>
//        /// <param name="name">名字</param>
//        /// <param name="content">内容</param>
//        /// <returns>为真，表示成功</returns>
//        public static bool AddMsg(string name, string Lcontent)
//        {
//            string datetime = System.DateTime.Now.ToString();
//            string sql = "insert into [Liuyan](name,time,Lcontent)values(@name,@datetime,@Lcontent)";
//            if (1 == AddExecSql(sql, name, datetime, Lcontent))
//                return true;
//            else
//                return false;
//        }

//        public static int AddExecSql(string sql, string name, string datetime, string Lcontent)
//        {
//            DBSql dbObj = new DBSql();
//            int i = 0;
//            SqlConnection myConn = dbObj.GetConnection();
//            SqlCommand myCmd = new SqlCommand(sql, myConn);
//            myConn.Open();
//            try
//            {
//                myCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
//                myCmd.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
//                myCmd.Parameters.Add("@Lcontent", SqlDbType.VarChar).Value = Lcontent;
//                i = myCmd.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                myCmd.Dispose();
//                myConn.Close();
//            }
//            return i;
//        }
//    }
//}

namespace Build.bll
{
    /// <summary>
    ///DbFilter 的摘要说明
    /// </summary>
    public class DbFilter
    {

        private DbFilter()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static DataSet GetMsgList()
        {
            ManagerClass da = new ManagerClass();
            string sql = "select * from [Liuyan] order by time desc";
            return da.ReturnIfo(sql, "Liuyan");
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="name">名字</param>
        /// <param name="content">内容</param>
        /// <returns>为真，表示成功</returns>
        public static bool AddMsg(string name, string L_content)
        {
            string datetime = System.DateTime.Now.ToString();
            string sql = "insert into [Liuyan](name,time,L_content)values(@name,@datetime,@L_content)";
            if (1 == AddExecSql(sql, name, datetime, L_content))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>为真，表示成功</returns>
        public static bool DeleteMsg(int ID)
        {
            string sql = "delete from [Liuyan] where ID=@ID";
            if (1 == DelExecSql(sql, ID))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 回复留言
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="huifu">内容</param>
        /// <returns>为真，表示成功</returns>
        public static bool HuifuMsg(int ID, string huifu)
        {
            string sql = "update [Liuyan]set audit=@huifu where ID=@ID";
            if (1 == PlyExecSql(sql, ID, huifu))
                return true;
            else
                return false;
        }

        public static int AddExecSql(string sql, string name, string datetime, string L_content)
        {
            DBSql dbObj = new DBSql();
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                myCmd.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
                myCmd.Parameters.Add("@L_content", SqlDbType.Text).Value = L_content;
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
        /// 执行一条sql语句，删除留言
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DelExecSql(string sql, int ID)
        {
            DBSql dbObj = new DBSql();
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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
        public static int PlyExecSql(string sql, int ID, string huifu)
        {
            DBSql dbObj = new DBSql();
            int i = 0;
            SqlConnection myConn = dbObj.GetConnection();
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            myConn.Open();
            try
            {
                myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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

        //public static DataSet GetMsgList()
        //{
        //    ManagerClass da = new ManagerClass();
        //    string sql = "select * from [Liuyan] order by time desc";
        //    return da.ReturnIfo(sql, "Message");
        //}

        ///// <summary>
        ///// 添加留言
        ///// </summary>
        ///// <param name="name">名字</param>
        ///// <param name="content">内容</param>
        ///// <returns>为真，表示成功</returns>
        //public static bool AddMsg(string name, string content)
        //{
        //    string datetime = System.DateTime.Now.ToString();
        //    string sql = "insert into [Liuyan](name,Lcontent,time)values(@name,@content,@datetime)";
        //    if (1 == AddExecSql(sql, name, content, datetime))
        //        return true;
        //    else
        //        return false;
        //}

        ///// <summary>
        ///// 删除留言
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns>为真，表示成功</returns>
        //public static bool DeleteMsg(int id)
        //{
        //    string sql = "delete from [Liuyan] where id=@id";
        //    if (1 == DelExecSql(sql, id))
        //        return true;
        //    else
        //        return false;
        //}

        ///// <summary>
        ///// 回复留言
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <param name="huifu">内容</param>
        ///// <returns>为真，表示成功</returns>
        //public static bool HuifuMsg(int id, string huifu)
        //{
        //    string sql = "update [Liuyan]set audit=@huifu where id=@id";
        //    if (1 == PlyExecSql(sql, id, huifu))
        //        return true;
        //    else
        //        return false;
        //}

        //public static int AddExecSql(string sql, string name, string content, string datetime)
        //{
        //    DBSql dbObj = new DBSql();
        //    int i = 0;
        //    SqlConnection myConn = dbObj.GetConnection();
        //    SqlCommand myCmd = new SqlCommand(sql, myConn);
        //    myConn.Open();
        //    try
        //    {
        //        myCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        //        myCmd.Parameters.Add("@content", SqlDbType.VarChar).Value = content;
        //        myCmd.Parameters.Add("@dtime", SqlDbType.DateTime).Value = datetime;
        //        i = myCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        myCmd.Dispose();
        //        myConn.Close();
        //    }
        //    return i;
        //}
        ///// <summary>
        ///// 执行一条sql语句，删除留言
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="id"></param>
        ///// <returns>返回受影响的行数</returns>
        //public static int DelExecSql(string sql, int id)
        //{
        //    DBSql dbObj = new DBSql();
        //    int i = 0;
        //    SqlConnection myConn = dbObj.GetConnection();
        //    SqlCommand myCmd = new SqlCommand(sql, myConn);
        //    myConn.Open();
        //    try
        //    {
        //        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        //        i = myCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        myCmd.Dispose();
        //        myConn.Close();
        //    }
        //    return i;
        //}

        ///// <summary>
        ///// 执行一条sql语句，回复留言
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="id"></param>
        ///// <param name="huifu">回复内容</param>
        ///// <returns>返回受影响的行数</returns>
        //public static int PlyExecSql(string sql, int id, string huifu)
        //{
        //    DBSql dbObj = new DBSql();
        //    int i = 0;
        //    SqlConnection myConn = dbObj.GetConnection();
        //    SqlCommand myCmd = new SqlCommand(sql, myConn);
        //    myConn.Open();
        //    try
        //    {
        //        myCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        //        myCmd.Parameters.Add("@huifu", SqlDbType.VarChar).Value = huifu;
        //        i = myCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        myCmd.Dispose();
        //        myConn.Close();
        //    }
        //    return i;
        //}
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="M_Table"></param>
        /// <returns></returns>
        public static DataSet GetMessOne(int ID, string M_Table)
        {
            string sql = string.Format("select * from Liuyan where id={0}", ID);
            return GetMessOnes(sql, M_Table);
        }


        /// <summary>
        /// 获取单个留言的信息
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="M_Table">表名</param>
        /// <returns></returns>
        public static DataSet GetMessOnes(string sql, string M_Table)
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
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds, M_Table);
            return ds;
        }
    }
}