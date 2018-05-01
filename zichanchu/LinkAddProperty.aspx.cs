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
public partial class admin_LinkAddProperty : System.Web.UI.Page
{
    string louyu;
    int num,Bid;
    protected void Page_Load(object sender, EventArgs e)
    {
        louyu = Request.QueryString["louyu"].ToString();
        num = Convert.ToInt32(Request.QueryString["num"]);
        if (!IsPostBack)
        {
            bind();
            
        }
        try
        {
            string Str;
            if (num == 1)
            {
                Str = "select B_id from Louyu where building='" + louyu + "';";
            }
            else
            {
                Str = "select B_id from Fangjian where department='" + louyu + "';";
            }
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(Str, cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Bid = Convert.ToInt32(ds.Tables[0].Rows[0]["B_id"].ToString());
            cn.Close();

        }
        catch (Exception)
        {
            throw;
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

    }
    //添加记录
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int num1;
        float T_area1, E_area1, A_area1, S_area1, R_area1, W_area1, St_area1, El_area1, O_area1;
        TextBox num = GridView1.FooterRow.FindControl("num") as TextBox;
        TextBox Cname = GridView1.FooterRow.FindControl("Cname") as TextBox;
        TextBox Ename = GridView1.FooterRow.FindControl("Ename") as TextBox;
        TextBox T_area = GridView1.FooterRow.FindControl("T_area") as TextBox;
        TextBox E_area = GridView1.FooterRow.FindControl("E_area") as TextBox;
        TextBox A_area = GridView1.FooterRow.FindControl("A_area") as TextBox;
        TextBox S_area = GridView1.FooterRow.FindControl("S_area") as TextBox;
        TextBox R_area = GridView1.FooterRow.FindControl("R_area") as TextBox;
        TextBox W_area = GridView1.FooterRow.FindControl("W_area") as TextBox;
        TextBox St_area = GridView1.FooterRow.FindControl("St_area") as TextBox;
        TextBox El_area = GridView1.FooterRow.FindControl("El_area") as TextBox;
        TextBox O_area = GridView1.FooterRow.FindControl("O_area") as TextBox;
        TextBox principal = GridView1.FooterRow.FindControl("principal") as TextBox;
        TextBox used = GridView1.FooterRow.FindControl("used") as TextBox;
        TextBox function = GridView1.FooterRow.FindControl("function") as TextBox;
        TextBox note = GridView1.FooterRow.FindControl("note") as TextBox;
        try
        {
            num1 = Convert.ToInt32(num.Text);
            T_area1 = float.Parse(T_area.Text);
            E_area1 = float.Parse(E_area.Text);
            A_area1 = float.Parse(A_area.Text);
            S_area1 = float.Parse(S_area.Text);
            R_area1 = float.Parse(R_area.Text);
            W_area1 = float.Parse(W_area.Text);
            St_area1 = float.Parse(St_area.Text);
            El_area1 = float.Parse(El_area.Text);
            O_area1 = float.Parse(O_area.Text);
            string sql = "insert into Fangjian(B_id,num,department,Cname,Ename,T_area,E_area,A_area,S_area,R_area,W_area,St_area,El_area,O_area,principal,used,[function],note) values('" + Bid + "','" + num1 + "','" + louyu + "','" + Cname.Text.ToString() + "','" + Ename.Text.ToString() + "','" + T_area1 + "','" + E_area1 + "','" + A_area1 + "','" + S_area1 + "','" + R_area1 + "','" + W_area1 + "','" + St_area1 + "','" + El_area1 + "','" + O_area1 + "','" + principal.Text.ToString() + "','" + used.Text.ToString() + "','" + function.Text.ToString() + "','" + note.Text.ToString() + "');";
            Common.ExecuteSql(sql);
            bind();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('房间号和面积不能为空，且必须为数字！请重新确认输入！');</script>");
        }
    }
    //取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GridView1.ShowFooter = false;
        bind();
        Functions.Alert("Cancel");
    }
}