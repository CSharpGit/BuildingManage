using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using System.Data.SqlClient;

public partial class admin_UserManagement : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void xiugai_Click(object sender, EventArgs e)
    {
        if (txtPwd1.Text != "" && txtPwd2.Text != "")
        {
            if (txtPwd1.Text == txtPwd2.Text)
            {
                try
                {
                    string ConString = ConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;//连接字符串在web.config中
                    con = new SqlConnection(ConString);
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    string sqlstr = "UPDATE Zhuce SET password='" + txtPwd1.Text + "' WHERE [user]='" + DropDownList1.SelectedValue.ToString() + "';";
                    com.CommandText = sqlstr;
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    com.Dispose();
                    con.Close();
                    Response.Write("<script>alert('修改密码成功！');location='index.aspx'</script>");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Response.Write("<script>alert('两次输入的密码不一致，请重新输入！')</script>");
                txtPwd1.Focus();
            }
        }
        else
        {
            Response.Write("<script>alert('请填写完整！')</script>");
            txtPwd1.Focus();
        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        txtPwd1.Text = "";
        txtPwd2.Text = "";
        txtPwd1.Focus();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;//连接字符串在web.config中
            con = new SqlConnection(ConString);
            con.Open();
            SqlCommand com = new SqlCommand();
            string sqlstr = "select password from Zhuce where [user]='" + DropDownList1.SelectedValue.ToString() + "';";
            com.CommandText = sqlstr;
            com.Connection = con;
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                LinkButton1.Text = rd[0].ToString();
            }
            con.Close();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('查看失败！')</script>");
        }
    }
}