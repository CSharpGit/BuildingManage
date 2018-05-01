using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

public partial class admin_AddUser : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }
    protected void xiugai_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != "" && txtPwd1.Text != "" && txtPwd2.Text != "")
        {
            if(txtPwd1.Text==txtPwd2.Text)
            {
                try
                {
                    string ConString = ConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;//连接字符串在web.config中
                    con = new SqlConnection(ConString);
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    string sqlstr = "INSERT INTO  Zhuce ([user] ,[password] ,[permission]) VALUES ('" + txtUsername.Text + "','" + txtPwd1.Text + "','" + Convert.ToInt32(DropDownList1.SelectedValue) + "');";
                    com.CommandText = sqlstr;
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    com.Dispose();
                    con.Close();
                    Response.Write("<script>alert('添加用户成功！');location='index.aspx'</script>");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Response.Write("<script>alert('两次输入的密码不一致，请重新输入！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('相关信息请填写完整！')</script>");
        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        txtUsername.Text = "";
        txtPwd1.Text = "";
        txtPwd2.Text = "";
        txtUsername.Focus();
    }
}