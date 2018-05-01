using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.IO;

public partial class Default999 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        Session["root"] = i;
        Response.Write("<Script Language=JavaScript>if(confirm('注销成功！')){window.location='Default.aspx';} </Script>");
    }
}