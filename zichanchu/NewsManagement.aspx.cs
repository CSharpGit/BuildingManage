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

public partial class admin_NewsManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void bind()
    {
        string sqlStr = "select * from Xinxi order by ID desc";
        DataSet myds = Common.dataSet(sqlStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.GridView1.PageCount; i++)
        {
            this.ddlCurrentPage.Items.Add(i.ToString());
        }
        this.ddlCurrentPage.SelectedIndex = this.GridView1.PageIndex;
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.GridView1.PageIndex + 1, this.GridView1.PageCount);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标移动到每项时颜色交替效果
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';this.style.color='#003399'");
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#6699FF';this.style.color='#8C4510'");

            e.Row.Attributes["style"] = "Cursor:hand";
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
            }
        }
        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }

    }
    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.ddlCurrentPage.SelectedIndex;
        bind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        bind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex > 0)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex - 1;
            bind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex < this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
            bind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.GridView1.PageCount;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Delete 按钮（其 CommandName 属性设置为“Delete”的按钮）时发生，但在 GridView 控件从数据源删除记录之前。此事件通常用于取消删除操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlStr = "delete from Xinxi where ID=" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value) + "";
        Common.ExecuteSql(sqlStr);
        bind();
    }
}