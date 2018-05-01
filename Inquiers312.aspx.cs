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

public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int root = 0;
        if (Session["root"] != null)
        {
            root = Convert.ToInt32(Session["root"].ToString());
        }
        if (root == 12 || root == 20)
        {
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"您没有登录，或者权限不够！\");</Script>"); Server.Transfer("Inquiers51.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string a1;
        string a2;
        string a3;
        string a4;
        string a5;
        string a6;
        string a7;
        string a8;
        string a9;
        string a10;
        string a11;
        string a12;

        if (a.Checked == true)
        {
            a1 = "Fangjian.T_area as 教学用房面积,";
        }
        else
        {
            a1 = null;
        }

        if (b.Checked == true)
        {
            a2 = "Fangjian.E_area as 实验用房面积,";
        }
        else
        {
            a2 = null;
        }

        if (c.Checked == true)
        {
            a3 = "Fangjian.A_area as 行政用房面积,";
        }
        else
        {
            a3 = null;
        }

        if (d.Checked == true)
        {
            a4 = "Fangjian.S_area as 教研室面积,";
        }
        else
        {
            a4 = null;
        }

        if (f.Checked == true)
        {
            a5 = "Fangjian.R_area as 研究室面积,";
        }
        else
        {
            a5 = null;
        }

        if (g.Checked == true)
        {
            a6 = "Fangjian.W_area as 卫生间,";
        }
        else
        {
            a6 = null;
        }

        if (h.Checked == true)
        {
            a7 = "Fangjian.St_area as 库房,";
        }
        else
        {
            a7 = null;
        }

        if (i.Checked == true)
        {
            a8 = "Fangjian.W_area as 配电室,";
        }
        else
        {
            a8 = null;
        }

        if (j.Checked == true)
        {
            a9 = "Fangjian.W_area as 其他房间,";
        }
        else
        {
            a9 = null;
        }

        if (k.Checked == true)
        {
            a10 = "Fangjian.W_area as 房间负责人,";
        }
        else
        {
            a10 = null;
        }

        if (l.Checked == true)
        {
            a11 = "Fangjian.W_area as 是否分配,";
        }
        else
        {
            a11 = null;
        }

        if (m.Checked == true)
        {
            a12 = "Fangjian.W_area as 房间用途,";
        }
        else
        {
            a12 = null;
        }
        
        string s1 = DropDownList1.SelectedItem.Text;
        if (s1 == "社会科学学院" || Convert.ToInt32(Session["root"].ToString()) == 20)
        {
            string connectionStr = WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString2"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select building as 所属楼宇,Fangjian.num as 房间号,Fangjian.department as 所属部门,Fangjian.Cname as 中文名称,Fangjian.Ename as 英文名称," + a1 + "" + a2 + "" + a3 + "" + a4 + "" + a5 + "" + a6 + "" + a7 + "" + a8 + "" + a9 + "" + a10 + "" + a11 + "" + a12 + "Fangjian.note as 备注 from Fangjian,Louyu where Fangjian.B_id = Louyu.B_id and department = '" + s1 + "'";
                cmd.CommandType = CommandType.Text;
                object obj = cmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                {
                    Response.Write("<Script Language=JavaScript>if(confirm('数据为空,请重新查询！')){window.navigate('Inquiers312.aspx');} </Script>");
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
        else
        {
            Response.Write("<script>alert('对不起，您没有权限查看这一类信息');window.location='Inquiers51.aspx'</script>");
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