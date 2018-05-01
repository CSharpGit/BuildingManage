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

using System.Data.OleDb;
using System.Data.SqlClient;

public partial class admin_LinkImportingData : System.Web.UI.Page
{
    string louyu;
    int nums,bid;
    protected void Page_Load(object sender, EventArgs e)
    {
        louyu = Request.QueryString["louyu"].ToString();
        nums = Convert.ToInt32(Request.QueryString["nums"]);
        bid = Convert.ToInt32(Request.QueryString["bid"]);
    }

    public DataSet ExecleDs(string filenameurl, string table)
    {
        string strConn = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = " + filenameurl + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1'";
        //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataSet ds = new DataSet();
        OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
        odda.Fill(ds, table);
        return ds;
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Response.Write("<script>alert('请您选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXls=System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        if (!(IsXls == ".xls"|| IsXls == ".xlsx"))
        {
            Response.Write("<script>alert('请选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回
        }
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;
            cn.Open();
            string filename = DateTime.Now.ToString("yyyymmddhhMMss") + FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
            string savePath = Server.MapPath(("~\\zichanchu\\upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
            DataSet ds = ExecleDs(savePath, filename);           //调用自定义方法
            DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
            int rowsnum = ds.Tables[0].Rows.Count;
            if (rowsnum == 0)
            {
                Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
            }
            else
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    string num = dr[i]["房间号"].ToString();
                    string department = dr[i]["所属部门"].ToString();
                    string Cname = dr[i]["中文名称"].ToString();
                    string Ename = dr[i]["英文名称"].ToString();
                    string T_area = dr[i]["教学用房面积"].ToString();
                    string E_area = dr[i]["实验用房面积"].ToString();
                    string A_area = dr[i]["行政用房面积"].ToString();
                    string S_area = dr[i]["教研室面积"].ToString();
                    string R_area = dr[i]["研究室面积"].ToString();
                    string W_area = dr[i]["卫生间"].ToString();
                    string St_area = dr[i]["库房"].ToString();
                    string El_area = dr[i]["配电室"].ToString();
                    string O_area = dr[i]["其他房间"].ToString();
                    string principal = dr[i]["房间负责人"].ToString();
                    string used = dr[i]["是否分配"].ToString();
                    string function = dr[i]["房间用途"].ToString();
                    string note = dr[i]["备注"].ToString();

                    string sqlcheck;
                    if (nums == 1)//独立部门
                    {
                        sqlcheck = "select * from Fangjian where num='" + num + "' and B_id='" + bid + "';";  //检查独立部门（房间号 所属楼宇），数据库中是否存在
                    }
                    else//学院、其它部门
                    {
                        sqlcheck = "select * from Fangjian where num='" + num + "' and B_id='" + bid + "' and department='" + louyu + "';";  //检查非独立部门（房间号 所属院系 所属楼宇），数据库中是否已经存在
                    }
                    SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                    int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    if (count < 1)//如果数据库表中不存在上传表格中的房间号，将表中的数据插入数据库表中
                    {
                        string insertstr = "INSERT INTO Fangjian(B_id,num,department,Cname,Ename,T_area,E_area,A_area,S_area,R_area,W_area,St_area,El_area,O_area,principal,used,[function],note)" +
                        "VALUES('" + Convert.ToInt32(DropDownList1.SelectedValue) + "'" +
                        ",'" + num + "'" +
                        ",'" + department + "'" +
                        ",'" + Cname + "'" +
                        ",'" + Ename + "'" +
                        ",'" + T_area + "'" +
                        ",'" + E_area + "'" +
                        ",'" + A_area + "'" +
                        ",'" + S_area + "'" +
                        ",'" + R_area + "'" +
                        ",'" + W_area + "'" +
                        ",'" + St_area + "'" +
                        ",'" + El_area + "'" +
                        ",'" + O_area + "'" +
                        ",'" + principal + "'" +
                        ",'" + used + "'" +
                        ",'" + function + "'" +
                        ",'" + note + "')";
                        SqlCommand cmd = new SqlCommand(insertstr, cn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (MembershipCreateUserException ex)//捕捉异常
                        {
                            Response.Write("<script>alert('导入内容:" + ex.Message + "')</script>");
                        }
                    }
                    else//如果数据库表中存在导入表中的房间号
                    {
                        //Response.Write("<script>alert('excel表格里第" + i + "条数据和已有的内容重复！跳过该条数据继续导入！');</script>");
                        //continue;
                        string insertstr;
                        if (nums == 1)//独立部门
                        {   //更新数据
                            insertstr = "UPDATE Fangjian SET B_id='" + Convert.ToInt32(DropDownList1.SelectedValue) + "'" +
                            ",num='" + num + "'" +
                            ",department='" + department + "'" +
                            ",Cname='" + Cname + "'" +
                            ",Ename='" + Ename + "'" +
                            ",T_area='" + T_area + "'" +
                            ",E_area='" + E_area + "'" +
                            ",A_area='" + A_area + "'" +
                            ",S_area='" + S_area + "'" +
                            ",R_area='" + R_area + "'" +
                            ",W_area='" + W_area + "'" +
                            ",St_area='" + St_area + "'" +
                            ",El_area='" + El_area + "'" +
                            ",O_area='" + O_area + "'" +
                            ",principal='" + principal + "'" +
                            ",used='" + used + "'" +
                            ",[function]='" + function + "'" +
                            ",note='" + note + "'" +
                            "WHERE num='" + num + "' AND B_id='" + bid + "';";
                            //Response.Write("<script>alert('111')</script>");
                        }
                        else
                        {
                            insertstr = "UPDATE Fangjian SET B_id='" + Convert.ToInt32(DropDownList1.SelectedValue) + "'" +
                            ",num='" + num + "'" +
                            ",department='" + department + "'" +
                            ",Cname='" + Cname + "'" +
                            ",Ename='" + Ename + "'" +
                            ",T_area='" + T_area + "'" +
                            ",E_area='" + E_area + "'" +
                            ",A_area='" + A_area + "'" +
                            ",S_area='" + S_area + "'" +
                            ",R_area='" + R_area + "'" +
                            ",W_area='" + W_area + "'" +
                            ",St_area='" + St_area + "'" +
                            ",El_area='" + El_area + "'" +
                            ",O_area='" + O_area + "'" +
                            ",principal='" + principal + "'" +
                            ",used='" + used + "'" +
                            ",[function]='" + function + "'" +
                            ",note='" + note + "'" +
                            "WHERE num='" + num + "' AND department='" + louyu + "';";
                            //Response.Write("<script>alert('222')</script>");
                        }
                        SqlCommand cmd = new SqlCommand(insertstr, cn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (MembershipCreateUserException ex)       //捕捉异常
                        {
                            Response.Write("<script>alert('覆盖内容:" + ex.Message + "')</script>");
                        }
                    }
                }
                if (nums == 1)
                {
                    Response.Write("<script>alert('Excle表内数据导入并更新成功!');location='LinkPropertyManagement.aspx?louyu=" + louyu + "&num=1'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Excle表内数据导入并更新成功!');location='LinkPropertyManagement.aspx?louyu=" + louyu + "'</script>");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            changeToNull();
        }
    }

    public void changeToNull()
    {
        string[] upCmd = new string[9];
        upCmd[0] = "update Fangjian set T_area = null where T_area = 0";
        upCmd[1] = "update Fangjian set O_area = null where O_area = 0";
        upCmd[2] = "update Fangjian set E_area = null where E_area = 0";
        upCmd[3] = "update Fangjian set A_area = null where A_area = 0";
        upCmd[4] = "update Fangjian set S_area = null where S_area = 0";
        upCmd[5] = "update Fangjian set R_area = null where R_area = 0";
        upCmd[6] = "update Fangjian set W_area = null where W_area = 0";
        upCmd[7] = "update Fangjian set St_area = null where St_area = 0";
        upCmd[8] = "update Fangjian set El_area = null where El_area = 0";
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BuildingManageConnectionString"].ConnectionString;
            cn.Open();
            for (int k = 0; k < 9; k++)
            {
                SqlCommand cmd = new SqlCommand(upCmd[k], cn);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}