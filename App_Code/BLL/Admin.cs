using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using English.dal;

/// <summary>
///Admin 的摘要说明
/// </summary>
public class Admin
{
    ManagerClass mclass = new ManagerClass();
	public Admin()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 判断用户名与密码是否存在
    /// </summary>
    /// <param name="P_Str_Name"></param>
    /// <param name="P_Str_Password"></param>
    /// <returns></returns>
    public int AExists(string P_Str_Name, string P_Str_Password)
    {
        string sql = string.Format("select count(*) from [tb_Admin] where [Admin]='{0}' and [Password]='{1}'", P_Str_Name, P_Str_Password);
        return mclass.AdminExists(sql);
    }

    /// <summary>
    /// 返回管理员信息
    /// </summary>
    /// <param name="P_Str_Name">管理员用户名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <param name="P_Str_srcTable">返回的表名</param>
    /// <returns></returns>
    public DataSet ReturnAIDs(string P_Str_Name, string P_Str_Password, string P_Str_srcTable)
    {
        string sql = string.Format("select * from [tb_Admin] where [Admin]='{0}' and [Password]='{1}'", P_Str_Name, P_Str_Password);
        return mclass.ReturnIfo(sql, P_Str_srcTable);
    }

    /// <summary>
    /// 添加系统管理员
    /// </summary>
    /// <param name="P_Str_AdminName">用户名</param>
    /// <param name="P_Str_AdminPwd">密码</param>
    /// <returns></returns>
    public bool AddAdminInfo(string AdminName, string AdminPwd)
    {
        string sql = string.Format("insert into tb_Admin([Admin],[Password]) values('{0}','{1}')", AdminName, AdminPwd);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataSet ReturnMember(string Number)
    {
        string sql = string.Format("select * from [tb_Member] where [Number]='{0}'", Number);
        return mclass.ReturnIfo(sql, "Mem");
    }

    public DataSet ReturnState()
    {
        string sql = "select * from tb_Control";
        return mclass.ReturnIfo(sql, "Con");
    }

    /// <summary>
    /// 更新测试状态
    /// </summary>
    public void UpdateState(string State)
    {
        string sql = string.Format("update tb_Control set [State]='{0}' where ID=1", State);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 添加会员
    /// </summary>
    /// <param name="P_Str_AdminName">用户名</param>
    /// <param name="P_Str_AdminPwd">密码</param>
    /// <returns></returns>
    public bool AddMemberInfo(string Number)
    {
        string sql = string.Format("insert into tb_Member([Number]) values('{0}')", Number);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 返回所有管理员的信息
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnAdmin()
    {
        string sql = "select * from tb_Admin";
        return mclass.ReturnIfo(sql, "Admin");
    }
    /// <summary>
    /// 返回所有会员的信息
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnMember()
    {
        string sql = "select * from tb_Member";
        return mclass.ReturnIfo(sql, "Member");
    }

    /// <summary>
    /// 删除指定管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">要删除的编号</param>
    public void DeleteAdminInfo(int P_Int_AdminID)
    {
        int i = 0;
        string sql = string.Format("delete from tb_Admin where AdminID={0}", P_Int_AdminID);
        i = mclass.DelExecSql(sql, P_Int_AdminID);
    }

    /// <summary>
    /// 删除指定会员信息
    /// </summary>
    /// <param name="MemberID">要删除的编号</param>
    public void DeleteMemberInfo(int MemberID)
    {
        int i = 0;
        string sql = string.Format("delete from tb_Member where MemberID={0}", MemberID);
        i = mclass.DelExecSql(sql, MemberID);
    }

    /// <summary>
    /// 更新管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员标号</param>
    /// <param name="P_Str_Admin">管理员用户名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    public void UpdateAdminInfo(int P_Int_AdminID, string P_Str_Admin, string P_Str_Password)
    {
        string sql = string.Format("update tb_Admin set [Admin]='{0}',[Password]='{1}' where AdminID='{2}'", P_Str_Admin, P_Str_Password, P_Int_AdminID);
        mclass.ExecSql(sql);
    }
    /// <summary>
    /// 更新会员信息
    /// </summary>
    public void UpdateMemberInfo(int MemberID, string Number, string Name, string Class, string Password)
    {
        string sql = string.Format("update tb_Member set [Number]='{0}',[Name]='{1}',[Class]='{2}',[Password]='{3}' where MemberID='{4}'", Number, Name, Class, Password, MemberID);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 添加完形填空试题
    /// </summary>
    /// <returns></returns>
    public DataSet AddWanxing(string Wanxing)
    {
        string sql = string.Format("insert into tb_Wanxing([Wanxing]) values('{0}')", Wanxing);
        mclass.ExecSql(sql);
        string sql2 = "select top 1 * from tb_Wanxing order by ID desc";
        DataSet ds = mclass.ReturnIfo(sql2,"Wx");
        return ds;
    }

    /// <summary>
    /// 添加完形填空试题选项
    /// </summary>
    /// <returns></returns>
    public void AddWxxx(string Num,string fid)
    {
        string sql = string.Format("insert into tb_Wxxx([Num],[fid]) values('{0}','{1}')", Num,fid);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 返回所有完形填空试题选项信息
    /// </summary>
    /// <param name="P_Str_srcTable"></param>
    /// <returns></returns>
    public DataSet ReturnWanxing(string fid)
    {
        string sql = "select * from tb_Wxxx where fid=" + fid;
        return mclass.ReturnIfo(sql, "Read");
    }

    /// <summary>
    /// 添加阅读理解试题
    /// </summary>
    /// <returns></returns>
    public DataSet AddReading(string Reading)
    {
        string sql = string.Format("insert into tb_Reading([Reading]) values('{0}')", Reading);
        mclass.ExecSql(sql);
        string sql2 = "select top 1 * from tb_Reading order by ID desc";
        DataSet ds = mclass.ReturnIfo(sql2, "Rx");
        return ds;
    }

    /// <summary>
    /// 添加阅读理解试题选项
    /// </summary>
    /// <returns></returns>
    public void AddReadxx(string Num, string fid)
    {
        string sql = string.Format("insert into tb_Readxx([Num],[fid]) values('{0}','{1}')", Num, fid);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 返回所有阅读理解试题选项信息
    /// </summary>
    /// <param name="P_Str_srcTable"></param>
    /// <returns></returns>
    public DataSet ReturnReading(string fid)
    {
        string sql = "select * from tb_Readxx where fid=" + fid;
        return mclass.ReturnIfo(sql, "Read");
    }

    /// <summary>
    /// 更新完型填空信息
    /// </summary>
    public void UpdateWanxingInfo(string A, string B, string C, string D, string Answer,int ID)
    {
        string sql = string.Format("update tb_Wxxx set [A]='{0}',[B]='{1}',[C]='{2}',[D]='{3}',[Answer]='{4}' where ID='{5}'", A, B, C, D, Answer,ID);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 更新阅读理解信息
    /// </summary>
    public void UpdateReadingInfo(string Question, string A, string B, string C, string D, string Answer, int ID)
    {
        string sql = string.Format("update tb_Readxx set [Question]='{0}',[A]='{1}',[B]='{2}',[C]='{3}',[D]='{4}',[Answer]='{5}' where ID='{6}'", Question, A, B, C, D, Answer, ID);
        mclass.ExecSql(sql);
    }

    /// <summary>
    /// 返回词汇检测题信息
    /// </summary>
    /// <param name="P_Str_srcTable"></param>
    /// <returns></returns>
    public DataSet ReturnWord()
    {
        string sql = "select * from tb_Shiti";
        return mclass.ReturnIfo(sql, "Word");
    }

    /// <summary>
    /// 删除指定词汇检测题信息
    /// </summary>
    /// <param name="P_Int_AdminID">要删除的编号</param>
    public void DeleteWordInfo(int ID)
    {
        int i = 0;
        string sql = string.Format("delete from tb_Shiti where ShitiID={0}", ID);
        i = mclass.DelExecSql(sql, ID);
    }

    /// <summary>
    /// 添加词汇测试题
    /// </summary>
    /// <returns></returns>
    public bool AddWordInfo(string Word, string A, string B, string C, string D, string Answer)
    {
        string sql = string.Format("insert into tb_Shiti([Shiti],[A],[B],[C],[D],[Answer]) values('{0}','{1}','{2}','{3}','{4}','{5}')", Word, A, B, C, D, Answer);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 添加能力检测试题模式
    /// </summary>
    /// <returns></returns>
    public bool AddYangshiInfo(int Word, int Reading)
    {
        DateTime Date = DateTime.Now;
        string sql = string.Format("insert into tb_Yangshi([Cihui],[Reading],[Datetime]) values('{0}','{1}','{2}')", Word, Reading, Date);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 返回所有会员的词汇检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnScore()
    {
        string sql = "select tb_mygrade.Number,mygrade,Date,Name,Class from tb_mygrade,tb_Member where tb_mygrade.Number=tb_Member.Number order by Date desc";
        return mclass.ReturnIfo(sql, "Score");
    }

    /// <summary>
    /// 返回某学号的词汇检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnNumberScore(string Number)
    {
        string sql = "select tb_mygrade.Number,mygrade,Date,Name,Class from tb_mygrade,tb_Member where tb_mygrade.Number=tb_Member.Number AND tb_mygrade.Number='" + Number + "' order by Date desc";
        return mclass.ReturnIfo(sql, "NScore");
    }
    /// <summary>
    /// 返回某同学的词汇检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnNameScore(string Name)
    {
        string sql = "select tb_mygrade.Number,mygrade,Date,Name,Class from tb_mygrade,tb_Member where tb_mygrade.Number=tb_Member.Number AND tb_Member.Name='" + Name + "' order by Date desc";
        return mclass.ReturnIfo(sql, "NScore");
    }

    /// <summary>
    /// 返回所有会员的能力检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnTestScore()
    {
        string sql = "select tb_testgrade.Number,Testgrade,Score,Datetime,Name,Class from tb_testgrade,tb_Member where tb_testgrade.Number=tb_Member.Number order by Datetime desc";
        return mclass.ReturnIfo(sql, "TScore");
    }

    /// <summary>
    /// 返回某学号的能力检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnNTestScore(string Number)
    {
        string sql = "select tb_testgrade.Number,Testgrade,Score,Datetime,Name,Class from tb_testgrade,tb_Member where tb_testgrade.Number=tb_Member.Number AND tb_testgrade.Number='" + Number + "' order by Datetime desc";
        return mclass.ReturnIfo(sql, "NScore");
    }
    /// <summary>
    /// 返回某同学的能力检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnNameTestScore(string Name)
    {
        string sql = "select tb_testgrade.Number,Testgrade,Score,Datetime,Name,Class from tb_testgrade,tb_Member where tb_testgrade.Number=tb_Member.Number AND tb_Member.Name='" + Name + "' order by Datetime desc";
        return mclass.ReturnIfo(sql, "NScore");
    }

    /// <summary>
    /// 返回某班级的能力检测成绩
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnClassTestScore(string Class)
    {
        string sql = "select tb_testgrade.Number,Testgrade,Score,Datetime,Name,Class from tb_testgrade,tb_Member where tb_testgrade.Number=tb_Member.Number AND tb_Member.Class='" + Class + "' order by Datetime desc";
        return mclass.ReturnIfo(sql, "NScore");
    }

    /// <summary>
    /// 添加友情链接
    /// </summary>
    /// <returns></returns>
    public bool AddHelpInfo(string Name, string Address)
    {
        DateTime date = DateTime.Now;
        string sql = string.Format("insert into tb_Help([Name],[Address],[Date]) values('{0}','{1}','{2}')", Name, Address,date);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 返回友情链接的信息
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnHelp()
    {
        string sql = "select * from tb_Help";
        return mclass.ReturnIfo(sql, "Help");
    }
    /// <summary>
    /// 返回下载信息
    /// </summary>
    /// <returns></returns>
    public DataSet ReturnDownload()
    {
        string sql = "select * from tb_Download";
        return mclass.ReturnIfo(sql, "Download");
    }

    /// <summary>
    /// 添加英语学习经验
    /// </summary>
    /// <returns></returns>
    public bool AddExperienceInfo(string title,string author,string content)
    {
        DateTime date = DateTime.Now;
        string sql = string.Format("insert into tb_Experience([Title],[Author],[Content],[Datetime]) values('{0}','{1}','{2}','{3}')", title,author,content,date);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 添加最新动态
    /// </summary>
    /// <returns></returns>
    public bool AddNewsInfo(string title, string author, string content)
    {
        DateTime date = DateTime.Now;
        string sql = string.Format("insert into tb_News([Title],[Author],[Content],[NewsDate]) values('{0}','{1}','{2}','{3}')", title, author, content, date);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 添加下载资料
    /// </summary>
    /// <returns></returns>
    public bool AddDownloadInfo(string filename, string filepath)
    {
        DateTime date = DateTime.Now;
        string sql = string.Format("insert into tb_Download([Filename],[Filepath],[Datetime]) values('{0}','{1}','{2}')", filename, filepath, date);
        int p = mclass.AddInfos(sql);
        if (p == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
