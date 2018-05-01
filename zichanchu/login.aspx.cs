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

public partial class login : System.Web.UI.Page
{
    private string name;
    private string pwd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear(); //清除session 会话状态
        }
        txtName.Focus();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        name = txtName.Text.Trim();
        pwd = txtPwd.Text.Trim();
        if (name == "" || pwd == "")
        {
            Response.Write("<script>alert('请输入用户名或密码！')</script>");
            txtName.Focus();
        }
        else
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;
                //SqlCommand comm=new SqlCommand("update tb1 set vName=@vName,iAge=@iAge where ID=@id",conn);
                //SqlParameter parm1=new SqlParameter("@vName",SqlDbType.NVarChar,50);
                //parm1.Value=((TextBox)e.Item.FindControl("name")). Text;
                //SqlParameter parm2=new SqlParameter("@iAge",SqlDbType.Int);
               // parm2.Value=((TextBox)e.Item.FindControl("age")).T ext;
                //SqlParameter parm3=new SqlParameter("@id",SqlDbType.Int);
                //parm3.Value=this.DataGrid1.DataKeys[e.Item.ItemInd ex];
                conn.Open();
                //string sqlcheck = "select * from Zhuce where [user]='" + name + "' and password='" + pwd + "' and permission=47;";  //检查用户是否存在
                string sqlcheck = "select permission from Zhuce where [user]=@uName and [password]=@uPwd";  //检查用户是否存在
                //SqlCommand sqlcmd = new SqlCommand(sqlcheck, conn);

                //SqlParameter parm1=new SqlParameter("@uName",name);
                ////parm1.Value=name;
                //SqlParameter parm2=new SqlParameter("@uPwd",pwd);
                ////parm2.Value=pwd;
                //SqlParameter parm3 = new SqlParameter("@Pow",47);
                //sqlcmd.Parameters.Add(parm1);
                //sqlcmd.Parameters.Add(parm2);
                //sqlcmd.Parameters.Add(parm3);
                SqlParameter[] paramss = new SqlParameter[] {new SqlParameter("@uName",name), new SqlParameter("@uPwd",pwd)};
                int count = Convert.ToInt32(ExecuteScalar(conn, sqlcheck, paramss));
                if (count !=47)
                {
                    Response.Write("<script>alert('用户名或密码错误！')</script>");
                    txtName.Text = "";
                    txtName.Focus();
                    return;
                }
                else
                {
                    Session["LoginName"] = name;
                    string url = "index.aspx";
                    Response.Redirect(url);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public static object ExecuteScalar(SqlConnection conn, string cmdText,
        params SqlParameter[] parameters)
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }
}
