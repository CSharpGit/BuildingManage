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

public partial class Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindParent();
        }
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void bindParent()
    {
        string sqlStr = "select * from Liuyan";
        DataSet myds = Common.dataSet(sqlStr);
        ParentGridView.DataSource = myds;
        ParentGridView.DataKeyNames = new string[] { "ID" };
        ParentGridView.DataBind();
    }

    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ParentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //if (e.Row.RowIndex != -1)
        //{
        //    int id = ParentGridView.PageIndex * ParentGridView.PageSize + e.Row.RowIndex + 1;
        //    e.Row.Cells[0].Text = id.ToString();
        //}
    }
    protected void ParentGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int parent_index = e.NewEditIndex;
        ParentGridView.EditIndex = parent_index;
        bindParent();
        Session["ID"] = Convert.ToInt32(ParentGridView.DataKeys[parent_index].Value);
        Session["sParentGridViewIndex"] = parent_index;
        GridView childGridView = (GridView)(ParentGridView.Rows[parent_index].FindControl("ChildGridView"));
        string sqlStr = "select * from Liuyan where ID=" + Convert.ToInt32(Session["ID"].ToString());
        DataSet myds = Common.dataSet(sqlStr);
        childGridView.DataSource = myds;
        childGridView.DataKeyNames = new string[] { "ID" };
        childGridView.DataBind();
    }
    //protected void ChildGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    int parent_index = (int)Session["sParentGridViewIndex"];
    //    GridViewRow parent_row = ParentGridView.Rows[parent_index];
    //    GridView ChildGridView = (GridView)parent_row.FindControl("ChildGridView");
    //    int child_index = e.NewEditIndex;
    //    ChildGridView.EditIndex = child_index;
    //    Session["sProductID"] = Convert.ToInt32(ChildGridView.DataKeys[child_index].Value);
    //}
    protected void ChildGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }

    }
    protected void GrandChildGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
    }
    protected void ParentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ParentGridView.EditIndex = -1;
        bindParent();
    }
    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= ParentGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(ParentGridView.Rows[i].FindControl("CheckBox1"));
            if (CheckBox2.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }
    /// <summary>
    /// 删除所选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= ParentGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)ParentGridView.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                Common.ExecuteSql("delete from Liuyan where ID=" + Convert.ToUInt32(ParentGridView.DataKeys[i].Value) + "");
            }
        }
        bindParent();
    }
    /// <summary>
    /// 恢复选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= ParentGridView.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)ParentGridView.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Update 按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ParentGridView.DataKeys[e.RowIndex].Value.ToString();
        string reply = ((TextBox)(ParentGridView.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string sqlStr = "update Liuyan set reply='" + reply + "' where ID='" + ID + "'";
        Common.ExecuteSql(sqlStr);
        ParentGridView.EditIndex = -1;
        bindParent();
    }
}