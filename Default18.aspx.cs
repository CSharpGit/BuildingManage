using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default18 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int root = 0;
        if (Session["root"] != null)
        {
            root = Convert.ToInt32(Session["root"].ToString());
        }
        if (root == 20)
        {
        }
        else
        {
            Response.Write("<script>alert('您没有登录，或者权限不够！');window.location='Default.aspx'</script>");
        }
    }

    protected void bt_cad_Click(object sender, EventArgs e)
    {
        string url = "ReadCad.aspx";
        Session["dwgFile"] = "dwgFile/动电实验教学楼/房间分配图.dwg";
        Response.Write(" <script type='text/JavaScript'>window.open('" + url + "','_blank'); </script>");
    }
}