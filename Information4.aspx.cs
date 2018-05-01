using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using English.bll;

public partial class Default5 : System.Web.UI.Page
{
    User myObj = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tExperienceBind();
        }
    }

    /// <summary>
    /// 绑定学习经验
    /// </summary>
    public void tExperienceBind()
    {
        myObj.ExperienceBind(tExperience1, "ExperienceTable");
    }

    public void tExperience_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Experience1")
        {
            Response.Redirect("Information2.aspx?ID=" + Convert.ToInt32(tExperience1.DataKeys[e.Item.ItemIndex].ToString()));
        }
    }
}