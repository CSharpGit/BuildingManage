using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using English.bll;

public partial class Default3 : System.Web.UI.Page
{

    User myObj = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            Response.Write("<Script language='javascript'>alert('信息内容已被删除');</script>");
            return;
        }
        else
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            DataSet ds = myObj.GetExperienceByID1(id, "ExperienceTable");
            this.litTitle.Text = ds.Tables["ExperienceTable"].Rows[0][1].ToString();
            this.litAuthor.Text = ds.Tables["ExperienceTable"].Rows[0][2].ToString();
            this.litContent.Text = ds.Tables["ExperienceTable"].Rows[0][3].ToString();
        }

    }
}