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



public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int root = 0;
        if (Session["root"] != null)
        {
            root = Convert.ToInt32(Session["root"].ToString());
        }
        if (root == 20)
        {
        }
        else
        {
            Response.Write("<script>alert('您没有登录，或者权限不够！');window.location='Default.aspx'</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string connectionStr = WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString2"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            string chabiaoshi = loubiaoshi.Text;
            string chamingcheng = loumingcheng.Text;
            string chabiaohao = loubiaohao.Text;

            if (loubiaoshi.Text.Length == 0 && loumingcheng.Text.Length == 0 && loubiaohao.Text.Length == 0)
            {
                AlertMsg("请输入数据");
                loumingcheng.Focus();
                loubiaohao.Focus();
                loubiaoshi.Focus();
            }
            else
            {
                AlertMsg("查询成功");
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select B_id as 楼宇标号,campus as 校区标识,building as 楼宇名称,B_area as 占地面积,R_num as 房间总数 from Louyu where campus like '%" + chabiaoshi + "%' and B_id like '%" + chabiaohao + "%' and building like '%" + chamingcheng + "%'";
            cmd.CommandType = CommandType.Text;
            object obj = cmd.ExecuteScalar();
            if (obj == null || obj == DBNull.Value)
            {
                Response.Write("<Script Language=JavaScript>if(confirm('数据为空,请重新查询！')){window.navigate('Inquiers/Inquiers1.aspx');} </Script>");
            }
            using (SqlDataReader sqlreader = cmd.ExecuteReader())
            {
                if (sqlreader.HasRows)
                {
                    GridView1.DataSource = sqlreader;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void AlertMsg(string msg)
    {
        this.Page.RegisterStartupScript("alert", "<script language=\"javascript\">alert('" + msg + "');</script>");
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
 

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}