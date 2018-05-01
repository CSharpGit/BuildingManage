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

        if (root == 0)
        {
            Response.Write("<script>alert('您没有登录，请登录后再查询！');window.location='Default.aspx'</script>");
            //Response.Write("<Script Language=JavaScript>if(confirm('您没有登录，请登录后再查询！')){window.navigate('Default.aspx');} </Script>");            
        }
        else
        {
            if (root == 1)
            {
                Response.Write("<script>window.location='Inquiers301.aspx'</script>");
            }
            if (root == 2)
            {
                Response.Write("<script>window.location='Inquiers302.aspx'</script>");
            }
            if (root == 3)
            {
                Response.Write("<script>window.location='Inquiers303.aspx'</script>");
            }
            if (root == 4)
            {
                Response.Write("<script>window.location='Inquiers304.aspx'</script>");
            }
            if (root == 5)
            {
                Response.Write("<script>window.location='Inquiers305.aspx'</script>");
            }
            if (root == 6)
            {
                Response.Write("<script>window.location='Inquiers306.aspx'</script>");
            }
            if (root == 7)
            {
                Response.Write("<script>window.location='Inquiers307.aspx'</script>");
            }
            if (root == 8)
            {
                Response.Write("<script>window.location='Inquiers308.aspx'</script>");
            }
            if (root == 9)
            {
                Response.Write("<script>window.location='Inquiers309.aspx'</script>");
            }
            if (root == 10)
            {
                Response.Write("<script>window.location='Inquiers310.aspx'</script>");
            }
            if (root == 11)
            {
                Response.Write("<script>window.location='Inquiers311.aspx'</script>");
            }
            if (root == 12)
            {
                Response.Write("<script>window.location='Inquiers312.aspx'</script>");
            }
            if (root == 13)
            {
                Response.Write("<script>window.location='Inquiers313.aspx'</script>");
            }
            if (root == 14)
            {
                Response.Write("<script>window.location='Inquiers314.aspx'</script>");
            }
            if (root == 15)
            {
                Response.Write("<script>window.location='Inquiers315.aspx'</script>");
            }
            if (root == 16)
            {
                Response.Write("<script>window.location='Inquiers316.aspx'</script>");
            }
            if (root == 17)
            {
                Response.Write("<script>window.location='Inquiers317.aspx'</script>");
            }
            if (root == 21)
            {
                Response.Write("<script>window.location='Inquiers321.aspx'</script>");
            }
            if (root == 22)
            {
                Response.Write("<script>window.location='Inquiers322.aspx'</script>");
            }
            if (root == 23)
            {
                Response.Write("<script>window.location='Inquiers323.aspx'</script>");
            }
            if (root == 24)
            {
                Response.Write("<script>window.location='Inquiers324.aspx'</script>");
            }
            if (root == 25)
            {
                Response.Write("<script>window.location='Inquiers325.aspx'</script>");
            }
            if (root == 26)
            {
                Response.Write("<script>window.location='Inquiers326.aspx'</script>");
            }
            if (root == 27)
            {
                Response.Write("<script>window.location='Inquiers327.aspx'</script>");
            }
            if (root == 28)
            {
                Response.Write("<script>window.location='Inquiers328.aspx'</script>");
            }
            if (root == 29)
            {
                Response.Write("<script>window.location='Inquiers329.aspx'</script>");
            }
            if (root == 30)
            {
                Response.Write("<script>window.location='Inquiers330.aspx'</script>");
            }
            if (root == 31)
            {
                Response.Write("<script>window.location='Inquiers331.aspx'</script>");
            }
            if (root == 32)
            {
                Response.Write("<script>window.location='Inquiers332.aspx'</script>");
            }
            if (root == 33)
            {
                Response.Write("<script>window.location='Inquiers333.aspx'</script>");
            }
            if (root == 34)
            {
                Response.Write("<script>window.location='Inquiers334.aspx'</script>");
            }
            if (root == 35)
            {
                Response.Write("<script>window.location='Inquiers335.aspx'</script>");
            }
            if (root == 36)
            {
                Response.Write("<script>window.location='Inquiers336.aspx'</script>");
            }
            if (root == 37)
            {
                Response.Write("<script>window.location='Inquiers337.aspx'</script>");
            }
            if (root == 38)
            {
                Response.Write("<script>window.location='Inquiers338.aspx'</script>");
            }
            if (root == 39)
            {
                Response.Write("<script>window.location='Inquiers339.aspx'</script>");
            }
            if (root == 40)
            {
                Response.Write("<script>window.location='Inquiers340.aspx'</script>");
            }
            if (root == 41)
            {
                Response.Write("<script>window.location='Inquiers341.aspx'</script>");
            }
            if (root == 42)
            {
                Response.Write("<script>window.location='Inquiers342.aspx'</script>");
            }
            if (root == 43)
            {
                Response.Write("<script>window.location='Inquiers343.aspx'</script>");
            }
            if (root == 44)
            {
                Response.Write("<script>window.location='Inquiers344.aspx'</script>");
            }
            if (root == 45)
            {
                Response.Write("<script>window.location='Inquiers345.aspx'</script>");
            }
            if (root == 46)
            {
                Response.Write("<script>window.location='Inquiers346.aspx'</script>");
            }
        }                     
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s1 = DropDownList1.SelectedItem.Text;
        string s2 = DropDownList2.SelectedItem.Text;
        string s3 = DropDownList3.SelectedItem.Text;
        string connectionStr = WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString2"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select num as 房间号,department as 所属部门,Cname as 中文名称,Ename as 英文名称,T_area as 教学用房面积,E_area as 实验用房面积,A_area as 行政用房面积,S_area as 教研室面积,R_area as 研究室面积,W_area as 卫生间,St_area as 库房,El_area as 配电室,O_area as 其它房间,principal as 房间负责人,used as 是否分配,[function] as 房间用途,note as 备注 from Fangjian where Cname = '" + s3 + "'and B_id in(select B_id from Louyu where campus = '" + s1 + "'and building = '" + s2 + "') ";
            cmd.CommandType = CommandType.Text;
            object obj = cmd.ExecuteScalar();
            if (obj == null || obj == DBNull.Value)
            {
                Response.Write("<Script Language=JavaScript>if(confirm('数据为空,请重新查询！')){window.navigate('Inquiers51.aspx');} </Script>");
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
    protected void Button2_Click(object sender, EventArgs e)
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
}