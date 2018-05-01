using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using English.bll;



public partial class _Default : System.Web.UI.Page
{
    User myObj = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tExperienceBind();
        }
    }

    public void tExperienceBind()
    {
        myObj.ExperienceBind(tExperience, "ExperienceTable");
        myObj.ExperienceBind1(tExperience1, "ExperienceTable");
    }


    public void tExperience_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Experience")
        {
           Response.Redirect("Information2.aspx?ID=" + Convert.ToInt32(tExperience.DataKeys[e.Item.ItemIndex].ToString()));//公告
        }
    }

    public void tExperience_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Experience1")
        {
            Response.Redirect("Information3.aspx?ID=" + Convert.ToInt32(tExperience1.DataKeys[e.Item.ItemIndex].ToString()));//信息
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = TextBox1.Text;
        string password = TextBox2.Text;
        string sql = "Select * from Zhuce where [user] = '" + user + "'and password = '" + password + "'";
        string sql1 = "Select permission from Zhuce where [user] = '" + user + "'and password = '" + password + "'";
        string str = dataOperate.seleSQL(sql).ToString();
        int per1 = Convert.ToInt32(dataOperate.selePer(sql1).ToString());
        if (dataOperate.seleSQL(sql) > 0)
        {
            Session["user"] = TextBox1.Text;
            Session["root"] = per1;
            Response.Write("<script>alert('登录成功！')</script>");
            Label1.Text = Session["user"].ToString();

        }       
        else
        {
            Response.Write("<script>alert('登录失败！')</script>");
        }


    }
    protected void tExperience_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void tExperience1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = 0;
        Session["root"] = i;
        Response.Write("<script>alert('注销成功！');window.location='Default.aspx'</script>");

    }
    
}