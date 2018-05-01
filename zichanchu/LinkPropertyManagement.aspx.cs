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

public partial class admin_LinkPropertyManagement : System.Web.UI.Page
{
    string louyu;
    int num;
    protected void Page_Load(object sender, EventArgs e)
    {
        louyu = Request.QueryString["louyu"].ToString();
        num = Convert.ToInt32(Request.QueryString["num"]);
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
        //注释了后，序号为数据库里面的ID序号。不注释，序号从1开始排列。
        //if (e.Row.RowIndex != -1)
        //{
        //    int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
        //    e.Row.Cells[0].Text = id.ToString();
        //}
    }
    /// <summary>
    /// 此方法必重写，否则会出错
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int parent_index = e.NewEditIndex;
        GridView1.EditIndex = parent_index;
        bind();
        Session["ID"] = Convert.ToInt32(GridView1.DataKeys[parent_index].Value);
        string sqlStr = "select * from Fangjian where ID=" + Convert.ToInt32(Session["ID"].ToString());
        DataSet myds = Common.dataSet(sqlStr);
    }
    protected void ParentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Update 按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int num1;
        float T_area1, E_area1, A_area1, S_area1, R_area1, W_area1, St_area1, El_area1, O_area1;
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string num = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString();
        string department = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string Cname = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string Ename = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string T_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
        string E_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
        string A_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
        string S_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
        string R_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
        string W_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim();
        string St_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();
        string El_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[12].Controls[0])).Text.ToString().Trim();
        string O_area = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[13].Controls[0])).Text.ToString().Trim();
        string principal = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[14].Controls[0])).Text.ToString().Trim();
        string used = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[15].Controls[0])).Text.ToString().Trim();
        string function = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[16].Controls[0])).Text.ToString().Trim();
        string note = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[17].Controls[0])).Text.ToString().Trim();
        try
        {
            num1 = Convert.ToInt32(num);
            T_area1 = float.Parse(T_area);
            E_area1 = float.Parse(E_area);
            A_area1 = float.Parse(A_area);
            S_area1 = float.Parse(S_area);
            R_area1 = float.Parse(R_area);
            W_area1 = float.Parse(W_area);
            St_area1 = float.Parse(St_area);
            El_area1 = float.Parse(El_area);
            O_area1 = float.Parse(O_area);

            string sqlStr = "update Fangjian set num='" + num1 + "',department='" + department + "',Cname='" + Cname + "',Ename='" + Ename + "',T_area='" + T_area1 + "',E_area='" + E_area1 + "',A_area='" + A_area1 + "',S_area='" + S_area1 + "',R_area='" + R_area1 + "',W_area='" + W_area1 + "',St_area='" + St_area1 + "',El_area='" + El_area1 + "',O_area='" + O_area1 + "',principal='" + principal + "',used='" + used + "',[function]='" + function + "',note='" + note + "' where ID='" + ID + "';";
            Common.ExecuteSql(sqlStr);
            GridView1.EditIndex = -1;
            bind();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('房间号和面积不能为空，且必须为数字！请重新确认输入！');</script>");
        }
    }
    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(GridView1.Rows[i].FindControl("CheckBox1"));
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
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                Common.ExecuteSql("delete from Fangjian where ID=" + Convert.ToUInt32(GridView1.DataKeys[i].Value) + "");
            }
        }
        bind();
    }
    /// <summary>
    /// 恢复选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }
}