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


/// <summary>
///dataOperate 的摘要说明
/// </summary>
public class dataOperate
{
	public dataOperate()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static int seleSQL(string sql) 
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        try
        {
            int i = Convert.ToInt32(com.ExecuteScalar());
            return i;
            con.Close();
        }
        catch (Exception e)
        {
            con.Close();
            return 0;
        }
    }

    public static int selePer(string sql1) 
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql1, con);
        try
        {
            int i = Convert.ToInt32(com.ExecuteScalar());
            return i;
            con.Close();
        }
        catch 
        {
            con.Close();
            return 0;
        }
    
    }

    public static SqlConnection createCon()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BuildingManageConnectionString2"].ToString());
        return con;
    }
}