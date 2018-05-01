using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// 常用函数  
/// </summary>
public class Functions
{
	public Functions()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 弹出JavaScript小窗口,其实就是定义的一个DIV
    /// </summary>
    /// <param name="js">窗口信息</param>
    public static void Alert(string message)
    {
        message = "<div style='border:darkturquoise 1px solid; width:200px;color: blue; font-style: normal; font-family: 楷体_GB2312;height:auto; background-color: #f4f8ff;padding:15px 0px; text-align:center; font-size: 23px;left: 360px; position: absolute; top: 200px;'>" + message + "</div>";
	    HttpContext.Current.Response.Write(message);
    }
    
}
