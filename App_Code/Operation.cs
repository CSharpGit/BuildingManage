using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

using System.Web.UI;

/// <summary>
/// Operation 网站业务流程类（封装所有业务方法）
/// </summary>
public class Operation
{
    public Operation()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    #region  添加供求信息
    /// <summary>
    /// 添加供求信息
    /// </summary>
    /// <param name="type">信息类别</param>
    /// <param name="title">标题</param>
    /// <param name="info">内容</param>
    /// <param name="linkMan">联系人</param>
    /// <param name="tel">联系电话</param>
    public void InsertInfo(string type, string title, string info, string linkMan, string tel)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@type",SqlDbType.VarChar,50,type),
            data.MakeInParam("@title",SqlDbType.VarChar,50,title),
            data.MakeInParam("@info",SqlDbType.VarChar,500,info),
            data.MakeInParam("@linkMan",SqlDbType.VarChar,50,linkMan),
            data.MakeInParam("@tel",SqlDbType.VarChar,50,tel),
        };
        int i = data.RunProc("INSERT INTO tb_info (type, title, info, linkman, tel,checkState) VALUES (@type, @title,@info,@linkMan, @tel, 0)", parms);
    }
    #endregion

    #region  修改供求信息
    /// <summary>
    /// 修改供求信息的审核状态
    /// </summary>
    /// <param name="id">信息ＩＤ</param>
    /// <param name="type">信息类型</param>
    public void UpdateInfo(string id, string type)
    {

        DataSet ds = this.SelectInfo(type, Convert.ToInt32(id));
        bool checkState = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
        int i;
        if (checkState)
        {
            i = data.RunProc("UPDATE tb_info SET checkState = 0 WHERE (ID = " + id + ")");
        }
        else
        {
            i = data.RunProc("UPDATE tb_info SET checkState = 1 WHERE (ID = " + id + ")");
        }
    }
    #endregion

    #region  删除供求信息

    /// <summary>
    /// 删除指定的供求信息
    /// </summary>
    /// <param name="id">供求信息ＩＤ</param>
    public void DeleteInfo(string id)
    {
        int d = data.RunProc("Delete from tb_info where id='" + id + "'");
    }

    #endregion

    #region  查询供求信息
    /// <summary>
    /// 按类型查询供求信息
    /// </summary>
    /// <param name="type">供求信息类型</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectInfo(string type)
    {
        SqlParameter[] parms ={ data.MakeInParam("@type", SqlDbType.VarChar, 50, type) };
        return data.RunProcReturn("SELECT ID, type, title, info, linkman, tel, checkState, date FROM tb_info where type=@type ORDER BY date DESC", parms, "tb_info");
    }
    /// <summary>
    /// 按类型和ＩＤ查询供求信息
    /// </summary>
    /// <param name="type">供求信息类型</param>
    /// <param name="id">供求信息ＩＤ</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectInfo(string type, int id)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@type", SqlDbType.VarChar, 50, type) ,
        };
        return data.RunProcReturn("SELECT ID, type, title, info, linkman, tel, checkState, date FROM tb_info where (type=@type) AND (ID=" + id + ") ORDER BY date DESC", parms, "tb_info1");
    }
    /// <summary>
    /// 按信息类型查询，审核和未审核信息。
    /// </summary>
    /// <param name="type">信息类型</param>
    /// <param name="checkState">True 显示审核信息 False显示未审核信息</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectInfo(string type, bool checkState)
    {
        return data.RunProcReturn("select * from tb_info where type='" + type + "' and checkState='" + checkState + "'", "tb_info");
    }

    /// <summary>
    /// 供求信息快速检索
    /// </summary>
    /// <param name="type">信息类型</param>
    /// <param name="infoSearch">查询信息的关键字</param>
    /// <returns>返回查询结果DataSet数据集</returns>
    public DataSet SelectInfo(string type, string infoSearch)
    {
        SqlParameter[] pars ={
            data.MakeInParam("@type", SqlDbType.VarChar, 50, type) ,
            data.MakeInParam("@info",SqlDbType.VarChar,50,"%"+infoSearch+"%")
        };
        return data.RunProcReturn("select * from tb_info where (type=@type) and (info like @info) and (checkstate=1)", pars, "tb_info");
    }

    #endregion

    #region 添加收费供求信息

    /// <summary>
    /// 添加收费供求信息
    /// </summary>
    /// <param name="type">信息类型</param>
    /// <param name="title">信息标题</param>
    /// <param name="info">信息内容</param>
    /// <param name="linkMan">联系人</param>
    /// <param name="tel">联系电话</param>
    /// <param name="sumDay">有时天数</param>
    public void InsertLeaguerInfo(string type, string title, string info, string linkMan, string tel, DateTime sumDay,bool checkState)
    {
        SqlParameter[] parms ={ 
            data.MakeInParam("@type",SqlDbType.VarChar,50,type),
            data.MakeInParam("@title",SqlDbType.VarChar,50,title),
            data.MakeInParam("@info",SqlDbType.VarChar,500,info),
            data.MakeInParam("@linkMan",SqlDbType.VarChar,50,linkMan),
            data.MakeInParam("@tel",SqlDbType.VarChar,50,tel),
            data.MakeInParam("@showday",SqlDbType.DateTime,8,sumDay),
            data.MakeInParam("@CheckState",SqlDbType.Bit,8,checkState)
        };
        int i = data.RunProc("INSERT INTO tb_LeaguerInfo (type, title, info, linkman, tel,showday,checkState) VALUES (@type, @title,@info,@linkMan, @tel,@showday,@CheckState)", parms);
    }
    #endregion

    #region  删除收费供求信息
    /// <summary>
    /// 删除收费供求信息
    /// </summary>
    /// <param name="id">要删除信息的ＩＤ</param>
    public void DeleteLeaguerInfo(string id)
    {
        int d = data.RunProc("Delete from tb_LeaguerInfo where id='" + id + "'");
    }
    #endregion

    #region  查询收费供求信息
    /// <summary>
    /// 显示所有的收费信息
    /// </summary>
    /// <returns>返回DataSet结果集</returns>
    public DataSet SelectLeaguerInfo()
    {
        return data.RunProcReturn("Select * from tb_LeaguerInfo order by date desc", "tb_LeaguerInfo");
    }
    /// <summary>
    /// 查询收费到期和未到期供求信息
    /// </summary>
    /// <param name="All">True显示未到期信息,False显示到期信息</param>
    /// <returns>返回DataSet结果集</returns>
    public DataSet SelectLeaguerInfo(bool All)
    {
        if (All) 　　　　 //显示有效收费信息
            return data.RunProcReturn("Select * from tb_LeaguerInfo where showday >= getdate() order by date desc", "tb_LeaguerInfo");
        else　　　　　　　//显示过期收费信息
            return data.RunProcReturn("select * from tb_LeaguerInfo where showday<getdate() order by date desc", "tb_LeaguerInfo");
    }
    /// <summary>
    /// 查询同类型收费到期和未到期供求信息
    /// </summary>
    /// <param name="all">True显示未到期信息,False显示到期信息</param>
    /// <param name="infoType">信息类型</param>
    /// <returns>返回DataSet结果集</returns>
    public DataSet SelectLeaguerInfo(bool All, string infoType)
    {
        if (All) 　　　　 //显示有效收费信息
            return data.RunProcReturn("Select * from tb_LeaguerInfo where type='" + infoType + "' and showday >= getdate() order by date desc", "tb_LeaguerInfo");
        else　　　　　　　//显示过期收费信息
            return data.RunProcReturn("select * from tb_LeaguerInfo where type='" + infoType + "' and showday<getdate() order by date desc", "tb_LeaguerInfo");
    }
    /// <summary>
    /// 查询显示‘按类型未过期推荐信息’或‘所有的未过期推荐信息’
    /// </summary>
    /// <param name="infoType">信息类型</param>
    /// <param name="checkState">True按类型显示未过期推荐信息  False显示所有未过期推荐信息</param>
    /// <returns></returns>
    public DataSet SelectLeaguerInfo(string infoType,bool checkState)
    {
        if (checkState) 　 //按类型未过期推荐信息
            return data.RunProcReturn("SELECT top 20 * FROM tb_LeaguerInfo WHERE (type = '" + infoType + "') AND (showday >= GETDATE()) AND (CheckState = '" + checkState + "') ORDER BY date DESC", "tb_LeaguerInfo");
        else　　　　　　　//显示未过期推荐信息
            return data.RunProcReturn("SELECT top 10 * FROM tb_LeaguerInfo WHERE (showday >=GETDATE()) AND (CheckState = '" + !checkState + "') ORDER BY date DESC", "tb_LeaguerInfo");
    }
    /// <summary>
    /// 查询同类型收费到期和未到期供求信息(前Ｎ条信息)
    /// </summary>
    /// <param name="all">True显示有效收费信息,False显示过期收费信息</param>
    /// <param name="infoType">信息类型</param>
    /// <param name="top">获取前Ｎ条信息</param>
    /// <returns></returns>
    public DataSet SelectLeaguerInfo(bool All, string infoType, int top)
    {
        if (All) 　　　　 //显示有效收费信息
            return data.RunProcReturn("Select top(" + top + ") * from dbo.公示信息 where type='" + infoType + "' and showday >= getdate() order by date desc", "tb_LeaguerInfo");
        else　　　　　　　//显示过期收费信息
            return data.RunProcReturn("select top(" + top + ") * from dbo.公示信息 where type='" + infoType + "' and showday<getdate() order by date desc", "tb_LeaguerInfo");
    }
    /// <summary>
    /// 根据ＩＤ查询收费供求信息
    /// </summary>
    /// <param name="id">供求信息ＩＤ</param>
    /// <returns></returns>
    public DataSet SelectLeaguerInfo(string id)
    {
        return data.RunProcReturn("Select * from tb_LeaguerInfo where id='" + id + "' order by date desc", "tb_LeaguerInfo");
    }

    #endregion

    #region  分页设置绑定
    /// <summary>
    /// 绑定DataList控件，并且设置分页
    /// </summary>
    /// <param name="infoType">信息类型</param>
    /// <param name="infoKey">查询的关键字（如果为空，则查询所有）</param>
    /// <param name="currentPage">当前页</param>
    /// <param name="PageSize">每页显示数量</param>
    /// <returns>返回PagedDataSource对象</returns>
    public PagedDataSource PageDataListBind(string infoType, string infoKey, int currentPage,int PageSize)
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = SelectInfo(infoType, infoKey).Tables[0].DefaultView; //将查询结果绑定到分页数据源上。
        pds.AllowPaging = true;　　　　　　　　　　//允许分页
        pds.PageSize = PageSize;　　　　　　　　 　//设置每页显示的页数
        pds.CurrentPageIndex = currentPage - 1;　  //设置当前页
        return pds;
    }
    #endregion

    #region 后台登录

    public DataSet Logon(string user, string pwd)
    {
        SqlParameter[] parms ={
            data.MakeInParam("@sysName",SqlDbType.VarChar,20,user),
            data.MakeInParam("@sysPwd",SqlDbType.VarChar,20,pwd)
        };
        return data.RunProcReturn("Select * from tb_Power where sysName=@sysName and sysPwd=@sysPwd",parms, "tb_Power");
    }
    #endregion
}
