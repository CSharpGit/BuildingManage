using WebCAD;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReadCad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DrawingManager.Engine = DrawingEngine.CADNET;
        if (Request.QueryString["id"] != null)
        {
            string dwgFile = Server.UrlDecode(Request.QueryString["id"].ToString());
            LoadCad(dwgFile);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string file = Path.GetTempPath() + Guid.NewGuid().ToString() + "_" + FileUpload1.FileName;
        FileUpload1.SaveAs(file);
        CADControl1.File = file;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        CADControl1.File = Server.MapPath("") + "\\" + "dwgTile/Gasket.dwg";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string file = Path.GetTempPath() + Guid.NewGuid().ToString() + "_floorplan.dwg";
        string url = "http://www.cadsofttools.com/dwgviewer/floorplan.dwg";
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, file);
            CADControl1.File = file;
        }
    }

    protected void CADControl1_EntityClickEvent(object sender, EntityClickArgs e)
    {
        if (e.EntityInfo.Count == 0)
            e.EntityInfo.Add(new KeyValuePair<string, object>("No entity selected", "No data"));
    }

    public void LoadCad(string dwgFile)
    {
        CADControl1.File = Server.MapPath("") + "\\" + dwgFile;
    }
}