using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

public partial class admin_xiugai : System.Web.UI.Page
{
    SqlConnection con;
    private string username;

    protected void Page_Load(object sender, EventArgs e)
    {
        username = Convert.ToString(Session["LoginName"]);
    }
    protected void xiugai_Click(object sender, EventArgs e)
    {
        if (password.Text != "" && xpassword.Text.Trim()!="" && cpassword.Text.Trim()!="")
        {
            if (cpassword.Text == xpassword.Text)
            {
                try
                {
                    string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    con = new SqlConnection(ConString);
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    SqlDataReader sdr;
                    string sqlstr = "select * from Zhuce where [user]='" + username + "' and password='" + password.Text.ToString().Trim() + "' and permission=47;";
                    com.CommandText = sqlstr;
                    com.Connection = con;
                    sdr = com.ExecuteReader();
                    if (sdr.Read())
                    {
                        string sqlStr = "update Zhuce set password='" + xpassword.Text.ToString().Trim() + "' where [user]='" + username + "'";
                        Common.ExecuteSql(sqlStr);
                        Response.Write("<script>alert('修改成功！');location='login.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('原密码错误，请重新输入！')</script>");
                        password.Text = ""; xpassword.Text = ""; cpassword.Text = ""; password.Focus();
                    }
                    sdr = null;
                    com.Dispose(); con.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                Response.Write("<script>alert('两次输入的密码不一致，请重新输入！')</script>");
                xpassword.Text = ""; cpassword.Text = ""; password.Focus();
            }
        }
        else
        {
            xpassword.Text = ""; cpassword.Text = ""; password.Focus();
            Response.Write("<script>alert('请填写完整！')</script>");
        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        password.Text = ""; xpassword.Text = ""; cpassword.Text = ""; password.Focus();
    }
}