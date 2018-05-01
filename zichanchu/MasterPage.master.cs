using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Object.Equals(Session["LoginName"], null))
        {//判断在Session["LoginName"]是否存在值
            //Response.Redirect("login.aspx", true);
            Response.Write("<script>alert('请重新登录！');location='login.aspx';</script>");
            return;
        }
        else
        {
            if (Session["LoginName"].ToString() != "房产管理平台")
            {
                Response.Write("<script>alert('请重新登录！');location='login.aspx';</script>");
                return;
            }
        }
    }
}
