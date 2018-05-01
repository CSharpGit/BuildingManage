using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Build.bll;
using System.Data;
using System.Data.SqlClient;

public partial class Default6 : System.Web.UI.Page
{
 protected void Page_Load(object sender, EventArgs e)
    {
        
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

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (0 == txtname.Text.Length&&txtname.Text.Trim()==null)
        {
            AlertMsg("请输入名字");
            txtname.Focus();
            return;
        }
        if (0 == txtcontent.Text.Length)
        {
            AlertMsg("请输入内容");
            txtcontent.Focus();
            return;
        }
        Button1.Enabled = false;
        if (txtname.Text.Length == 0 && txtcontent.Text.Length==0)
        {
            AlertMsg("留言失败");
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            DbFilter.AddMsg(txtname.Text, txtcontent.Text);
            AlertMsg("留言成功");
        }
        MsgBind();
    }

    protected void AlertMsg(string msg)
    {
        Response.Write("<script language=\"javascript\">alert('" + msg + "');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtname.Text = "";
        txtcontent.Text = "";
    }
    protected void home_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = 0;
        MsgBind();
    }
    protected void pre_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["Page"].ToString()) - 1;      
        MsgBind();

    }
    protected void next_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["Page"].ToString()) + 1;
        MsgBind();
    }
    protected void last_Click(object sender, EventArgs e)
    {
        ViewState["Page"] = int.Parse(ViewState["count"].ToString()) - 1;        
        MsgBind();
    }





}