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

using System.Data.SqlClient;

public partial class admin_AddNews : System.Web.UI.Page
{
    SqlConnection con;
    string table,datatime;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        table = DropDownList1.SelectedValue.ToString();
        datatime = DateTime.Now.ToLocalTime().ToString();
        if ((txtTitle.Text.Trim() == "") || (FreeTextBox1.Text.Trim() == ""))
        {
            Response.Write("<script>alert('标题、内容等不能为空！')</script>");
        }
        else
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;//连接字符串在web.config中
                con = new SqlConnection(ConString);
                con.Open();
                SqlCommand com = new SqlCommand();
                string sqlstr = "INSERT INTO " + table + " (title ,time ,G_content) VALUES ('" + txtTitle.Text.ToString().Trim() + "','" + datatime + "','" + FreeTextBox1.Text.Trim() + "');";
                com.CommandText = sqlstr;
                com.Connection = con;
                com.ExecuteNonQuery();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}