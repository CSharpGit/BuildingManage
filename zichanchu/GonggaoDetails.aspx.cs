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

public partial class admin_GonggaoDetails : System.Web.UI.Page
{
    SqlConnection con;
    string datatime;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"].ToString() != null)
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;//连接字符串在web.config中
                con = new SqlConnection(ConString);
                con.Open();
                SqlCommand com = new SqlCommand();
                SqlDataReader sdr;
                string sqlstr = "select * from Gonggao where ID=" + Request.QueryString["ID"].ToString() + ";";
                com.CommandText = sqlstr;
                com.Connection = con;
                sdr = com.ExecuteReader();
                sdr.Read();
                if (!Page.IsPostBack)
                {
                    txtTitle.Text = sdr["title"].ToString().Trim();
                    FreeTextBox1.Text = sdr["G_content"].ToString().Trim();
                }
                sdr.Close();//记得关闭连接
                sdr = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            Response.Write("<script>alert('请选择要编辑的公告！')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
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
                string sqlstr = "update Gonggao set title='" + txtTitle.Text.ToString().Trim() + "',time='" + datatime + "',G_content='" + FreeTextBox1.Text.Trim() + "' where ID='" + Request.QueryString["ID"].ToString() + "';";
                com.CommandText = sqlstr;
                com.Connection = con;
                com.ExecuteNonQuery();
                string url = "GonggaoManagement.aspx";
                Response.Redirect(url);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string url = "GonggaoManagement.aspx";
        Response.Redirect(url);
    }
}