using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Collections;
using System.Data.SqlClient;
using System.Xml.Linq;
using English.bll;
using System.Web.UI.HtmlControls;



public partial class Default3 : System.Web.UI.Page
{
    User myObj = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            Response.Write("<Script language='javascript'>alert('公告内容已被删除！');</script>");//信息
            return;
        }
        else
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            DataSet ds = myObj.GetExperienceByID(id, "ExperienceTable");
            if (ds.Tables.Count > 0)
            {
                this.litTitle.Text = ds.Tables["ExperienceTable"].Rows[0][1].ToString();
                this.litAuthor.Text = ds.Tables["ExperienceTable"].Rows[0][2].ToString();
                this.litContent.Text = ds.Tables["ExperienceTable"].Rows[0][3].ToString();
            }
        }

    }

}