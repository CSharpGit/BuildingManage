﻿using System;
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
        if (root == 20)
        {
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"您没有登录，或者权限不够！\");</Script>"); Server.Transfer("Inquiers51.aspx");
        }

        string connectionStr = WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString2"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select building as 所属楼宇,Fangjian.num as 房间号,Fangjian.department as 所属部门,Fangjian.Cname as 中文名称,Fangjian.Ename as 英文名称,Fangjian.S_area as 教研室面积,Fangjian.principal as 房间负责人,Fangjian.used as 是否分配,Fangjian.[function] as 房间用途,Fangjian.note as 备注 from Louyu,Fangjian where Louyu.B_id = Fangjian.B_id and Fangjian.S_area != 0";
            cmd.CommandType = CommandType.Text;
            object obj = cmd.ExecuteScalar();
            if (obj == null || obj == DBNull.Value)
            {
                Response.Write("<Script Language=JavaScript>if(confirm('数据为空,请重新查询！')){window.navigate('Inquiers358.aspx');} </Script>");
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