using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using English.dal;
using System.Threading;




namespace English.bll
{
    /// <summary>
    ///User 的摘要说明
    /// </summary>
    public class User
    {
        UserClass uclass = new UserClass();
        public static string iid;
        public User()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int AddMember(int MemberID, string Name, string Num, string Pwd, string Class, string Question, string Answer)
        {
            string sql = "update tb_Member set Number='" + Num + "',Name='" + Name + "',Class='" + Class + "',Password='" + Pwd + "',Question='" + Question + "',Answer='" + Answer + "'where MemberID=" + MemberID;
            return uclass.ReturnNum(sql);
        }

        public int SearchMember(int MemberID, string DataTableName)
        {
            string sql = "select * from tb_Member where MemberID=" + MemberID;
            DataSet da = uclass.FindInfo(sql, DataTableName);
            string pwd = da.Tables[0].Rows[0][4].ToString();
            int i = 0;
            if (pwd.Length == 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }

        public int FindMember(string Num, string Psw, string DataTableName)
        {
            string sql = "select * from tb_Member where Number='" + Num + "'AND Password='" + Psw + "'";
            DataSet da = uclass.FindInfo(sql, DataTableName);
            int i = da.Tables[0].Rows.Count;
            return i;
        }

        public int UpdateMember(int MemberID, string Pwd)
        {
            string sql = "update tb_Member set Password='" + Pwd + "'where MemberID=" + MemberID;
            return uclass.ReturnNum(sql);
        }

        public int FindNumber(string Num, string DataTableName)
        {
            int MemberID = 0;
            string sql = "select * from tb_Member where Number='" + Num + "'";
            DataSet da = uclass.FindInfo(sql, DataTableName);
            int i = da.Tables[0].Rows.Count;
            if (i == 0)
            {
                MemberID = 0;
            }
            else
            {
                MemberID = Convert.ToInt32(da.Tables[0].Rows[0][0].ToString());
            }
            return MemberID;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public DataSet FindPsw(string Num, string DataTableName)
        {
            string sql = "select * from tb_Member where Number='" + Num + "'";
            return uclass.FindInfo(sql, DataTableName);
        }


        /// <summary>
        /// 验证用户的登录功能
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public DataSet UserLogin(string UserName, string PassWord, string DataTableName)
        {
            string sql = "select * from tb_Member where Number='" + UserName + "' AND Password='" + PassWord + "'";
            return uclass.FindInfo(sql, DataTableName);
        }

        /// <summary>
        /// 绑定最新动态
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public void NewsBind(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select top 5 * from tb_News order by NewsDate desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定友情链接
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public void HelpBind(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select top 5 * from tb_Help order by Date desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 返回友情链接地址
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="P_Str_srcTable"></param>
        /// <returns></returns>
        public DataSet GetHelpAddress(int ID, string P_Str_srcTable)
        {
            string sql = "select Address from tb_Help where ID=" + ID;
            return uclass.FindInfo(sql, P_Str_srcTable);
        }

        /// <summary>
        /// 返回最新动态信息
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="P_Str_srcTable"></param>
        /// <returns></returns>
        public DataSet GetNewsByID(int NewsID, string P_Str_srcTable)
        {
            string sql = "select * from tb_News where NewsID=" + NewsID;
            return uclass.FindInfo(sql, P_Str_srcTable);
        }

        /// <summary>
        /// 绑定下载内容
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public void DownloadBind(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select top 6 * from tb_Download order by Datetime desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定下载内容
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public void DownloadAll(DataList dlName)
        {
            string sql = "select * from tb_Download order by Datetime desc";
            DataSet ds = uclass.FindInfo(sql, "Down");
            dlName.DataSource = ds.Tables["Down"].DefaultView;
            dlName.DataBind();
        }

        public void ExperienceBind(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select top 6 * from Gonggao order by time desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        public void ExperienceBind1(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select top 6 * from Xinxi order by time desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定学习经验
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public void ExperienceAll(DataList dlName, string P_Str_srcTable)
        {
            string sql = "select * from Xinxi order by time desc";
            DataSet ds = uclass.FindInfo(sql, P_Str_srcTable);
            dlName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 返回学习经验信息
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="P_Str_srcTable"></param>
        /// <returns></returns>
        public DataSet GetExperienceByID(int ID, string P_Str_srcTable)
        {
            string sql = "select * from Gonggao where ID = " + ID + "";
            return uclass.FindInfo(sql, P_Str_srcTable);
        }

        public DataSet GetExperienceByID1(int ID, string P_Str_srcTable)
        {
            string sql = "select * from Xinxi where ID = " + ID + "";
            return uclass.FindInfo(sql, P_Str_srcTable);
        }

        /// <summary>
        /// 返回下载信息
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="P_Str_srcTable"></param>
        /// <returns></returns>
        public DataSet GetDownloadByID(int ID, string P_Str_srcTable)
        {
            string sql = "select * from tb_Download where DownloadID=" + ID;
            return uclass.FindInfo(sql, P_Str_srcTable);
        }

        /// <summary>
        /// 添加生词
        /// </summary>
        /// <param name="name">English</param>
        /// <param name="content">Chinese</param>
        /// <returns>为真，表示成功</returns>
        public bool AddNword(string English, string Chinese, string UserName)
        {
            string sql = "insert into [tb_Newword](UserName,English,Chinese)values(@UserName,@English,@Chinese)";
            if (1 == uclass.AddExecSql(sql, UserName, English, Chinese))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 添加难词
        /// </summary>
        /// <param name="name">English</param>
        /// <param name="content">Chinese</param>
        /// <returns>为真，表示成功</returns>
        public bool AddHardword(string English, string Chinese, string UserName)
        {
            string sql = "insert into [tb_Hardword](UserName,English,Chinese)values(@UserName,@English,@Chinese)";
            if (1 == uclass.AddExecSql(sql, UserName, English, Chinese))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 返回能力测试试题样式
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet Yangshi()
        {
            string sql = "select top 1 * from tb_Yangshi order by Datetime desc";
            DataSet ds = uclass.FindInfo(sql, "Yangshi");
            return ds;
        }

        /// <summary>
        /// 绑定词汇量试题
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet ShitiBind(DataList dlName)
        {
            string sql = "select top 50 * from tb_Shiti order by newid()";
            DataSet ds = uclass.FindInfo(sql, "Shiti");
            return ds;
        }

        /// <summary>
        /// 绑定能力测试教室试题-- 词汇
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet NengliShitiBind(DataList dlName, int chno)
        {
            string sql = "select top " + chno + "  * from tb_Shiti order by newid()";
            DataSet ds = uclass.FindInfo(sql, "Shiti");
            return ds;
        }

        /// <summary>
        /// 绑定能力测试教室试题--完型
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet WanxingShitiBind(DataList dlName)
        {
            string sql = "select top 1 * from tb_Wanxing order by newid()";
            DataSet da = uclass.FindInfo(sql, "Wanx");
            iid = da.Tables[0].Rows[0][0].ToString();
            return da;
        }

        /// <summary>
        /// 绑定能力测试教室试题--完型
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet WxxxShitiBind(DataList dlName)
        {
            string sql1 = "select * from tb_Wxxx where fid=" + iid;
            DataSet ds = uclass.FindInfo(sql1, "Shiti");
            return ds;
        }

        /// <summary>
        /// 能力测试教室试题--阅读
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet ReadingShitiBind(int rno)
        {
            string sql = "select top " + rno + " * from tb_Reading order by newid()";
            DataSet da = uclass.FindInfo(sql, "Reading");
            return da;
        }

        /// <summary>
        /// 能力测试教室试题--阅读选项
        /// </summary>
        /// <param name="dlName">控件名称</param>
        /// <param name="P_Str_srcTable">表名</param>
        public DataSet ReadingxxBind(DataList dlName, string id)
        {
            string sql = "select * from tb_Readxx where fid=" + id;
            DataSet ds = uclass.FindInfo(sql, "Readxx");
            return ds;
        }

        /// <summary>
        /// 记录个人测试成绩
        /// </summary>
        /// <returns>为真，表示成功</returns>
        public void AddScore(string Number, int Score, DateTime date)
        {
            string sql = "insert into tb_mygrade (Number,mygrade,Date)values('" + Number + "','" + Score + "','" + date + "')";
            System.Diagnostics.Debug.WriteLine(sql);
            uclass.DoExecSql(sql);
        }

        /// <summary>
        /// 记录能力教室成绩
        /// </summary>
        /// <returns>为真，表示成功</returns>
        public void AddTestScore(string Number, int Testgrade, int Score, DateTime date)
        {
            string sql = "insert into tb_testgrade (Number,Testgrade,Score,Datetime)values('" + Number + "','" + Testgrade + "','" + Score + "','" + date + "')";
            System.Diagnostics.Debug.WriteLine(sql);
            uclass.DoExecSql(sql);
        }

        /// <summary>
        /// 绑定生词
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void NewwordBind(DataList dlName, string Number)
        {
            string sql = "select top 7 * from tb_Newword where UserName= " + Number + "order by WordID desc ";
            DataSet ds = uclass.FindInfo(sql, "NNew");
            dlName.DataSource = ds.Tables["NNew"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定全部生词
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void tNewwordBind(DataList dlName, string Number)
        {
            string sql = "select * from tb_Newword where UserName= " + Number + "order by WordID desc ";
            DataSet ds = uclass.FindInfo(sql, "NNew");
            dlName.DataSource = ds.Tables["NNew"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定难词
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void HardwordBind(DataList dlName, string Number)
        {
            string sql = "select top 7 * from tb_Hardword where UserName=" + Number + "order by WordID desc ";
            DataSet ds = uclass.FindInfo(sql, "HNew");
            dlName.DataSource = ds.Tables["HNew"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定难词
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void tHardwordBind(DataList dlName, string Number)
        {
            string sql = "select * from tb_Hardword where UserName=" + Number + "order by WordID desc ";
            DataSet ds = uclass.FindInfo(sql, "HNew");
            dlName.DataSource = ds.Tables["HNew"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定自我检测成绩
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void MygradeBind(DataList dlName, string Number)
        {
            string sql = "select top 10 * from tb_mygrade where Number=" + Number + "order by Date desc ";
            DataSet ds = uclass.FindInfo(sql, "myscore");
            dlName.DataSource = ds.Tables["myscore"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定全部自我检测成绩
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void tMygradeBind(DataList dlName, string Number)
        {
            string sql = "select * from tb_mygrade where Number=" + Number + "order by Date desc ";
            DataSet ds = uclass.FindInfo(sql, "myscore");
            dlName.DataSource = ds.Tables["myscore"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定能力教室测试成绩
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void TestgradeBind(DataList dlName, string Number)
        {
            string sql = "select top 10 * from tb_testgrade where Number=" + Number + "order by Datetime desc ";
            DataSet ds = uclass.FindInfo(sql, "test");
            dlName.DataSource = ds.Tables["test"].DefaultView;
            dlName.DataBind();
        }

        /// <summary>
        /// 绑定全部能力教室测试成绩
        /// </summary>
        /// <param name="dlName">控件名称</param>
        public void tTestgradeBind(DataList dlName, string Number)
        {
            string sql = "select * from tb_testgrade where Number=" + Number + "order by Datetime desc ";
            DataSet ds = uclass.FindInfo(sql, "test");
            dlName.DataSource = ds.Tables["test"].DefaultView;
            dlName.DataBind();
        }


        }
    }

    

