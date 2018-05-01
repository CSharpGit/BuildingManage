using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Build.bll;



public partial class message : System.Web.UI.UserControl
{
   
         protected void Page_Load(object sender, EventArgs e)
    {
        int root = 0;
        if (Session["root"] != null)
        {
            root = Convert.ToInt32(Session["root"].ToString());
        }
        if (1 <= root)
        {
        }
        else
        {
            this.Page.Response.Write("<script>alert('您没有登录，或者权限不够！');window.location='Default.aspx'</script>");

        }
        if (!IsPostBack)
        {
            ViewState["Page"] = 0;
            MsgBind();
        }
    }

    protected void MsgBind()
    {
        PagedDataSource pg = new PagedDataSource();
        pg.DataSource = DbFilter.GetMsgList().Tables[0].DefaultView;
        pg.AllowPaging = true;
        pg.PageSize = 3;
        pg.CurrentPageIndex = int.Parse(ViewState["Page"].ToString());
        ViewState["count"] = pg.PageCount;
        MsgList.DataSource = pg;
        MsgList.DataBind();
    }

    protected void AlertMsg(string msg)
    {
        this.Page.RegisterStartupScript("alert", "<script language=\"javascript\">alert('" + msg + "');</script>");
    }
    protected void home_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = 0;
        MsgBind();
    }
    protected void pre_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["Page"].ToString()) - 1;
        if (Convert.ToInt32(ViewState["Page"]) < 0)
        {
            Response.Write("<Script Language=JavaScript>alert('已到首页');</Script>");
            ViewState["Page"] = 0;
        }
        MsgBind();

    }
    protected void next_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["Page"].ToString()) + 1;
        if (Convert.ToInt32(ViewState["Page"]) >= int.Parse(ViewState["count"].ToString()))
        {
            Response.Write("<Script Language=JavaScript>alert('已到尾页');</Script>");
            last_Click(sender,e);
        }
        MsgBind();
    }
    protected void last_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["count"].ToString()) - 1;      
        MsgBind();
    }

}