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
using System.Drawing;
using System.IO;
using System.Text;

public partial class admin_LinkExportingData : System.Web.UI.Page
{
    string louyu;
    int num;
    protected void Page_Load(object sender, EventArgs e)
    {
        louyu = Request.QueryString["louyu"].ToString();
        num = Convert.ToInt32(Request.QueryString["num"]);
        Button1.Text = louyu + Button1.Text;
        if (!IsPostBack)
        {
            bind();
        }
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void bind()
    {
        string sqlStr;
        if (num == 1)
        {
            sqlStr = "select * from Fangjian where Fangjian.B_id=(select Louyu.B_id from Louyu where Louyu.building='" + louyu + "');";
        }
        else
        {
            sqlStr = "select * from Fangjian where department='" + louyu + "';";
        }
        DataSet myds = Common.dataSet(sqlStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        if (e.Row.RowIndex != -1)
        {
            int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Export("application/ms-excel", louyu +".xls");
    }
    /// <summary>
    /// 定义导出Excel的函数
    /// </summary>
    /// <param name="FileType"></param>
    /// <param name="FileName"></param>
    private void Export(string FileType, string FileName)
    {
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
        Response.ContentType = FileType;
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        GridView1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    /// <summary>
    /// 此方法必重写，否则会出错
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string url = "ExportingData.aspx";
        Response.Redirect(url);
    }
}