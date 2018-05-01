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


public partial class Default2 : System.Web.UI.Page
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
        myObj.ExperienceAll(tExperience, "ExperienceTable");
    }

    public void tExperience_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Experience")
        {
            Response.Redirect("Information3.aspx?ID=" + Convert.ToInt32(tExperience.DataKeys[e.Item.ItemIndex].ToString()));
        }
    }
}