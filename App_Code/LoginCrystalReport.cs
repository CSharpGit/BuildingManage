using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

///// <summary>
/////Class1 的摘要说明
///// </summary>
//public class Class1
//{
//    public Class1()
//    {
//        //
//        //TODO: 在此处添加构造函数逻辑
//        //
//    }
//}


namespace BLL
{
    public class LoginCrystalReport
    {
        public void Login(CrystalDecisions.CrystalReports.Engine.ReportDocument report)
        {
            string serverName = ConfigurationManager.AppSettings["ServerName"];
            string databasename = ConfigurationManager.AppSettings["DbName"];
            string userId = ConfigurationManager.AppSettings["UserID"];

            string passWord = ConfigurationManager.AppSettings["Password"];

            //Set Database Logon to main report
            foreach (CrystalDecisions.Shared.IConnectionInfo connection in report.DataSourceConnections)
            {
                if (connection.ServerName == serverName)
                {
                    connection.SetLogon(userId, passWord);
                }
            }

            //Set Database Logon to subreport
            foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument subreport in report.Subreports)
            {
                foreach (CrystalDecisions.Shared.IConnectionInfo connection in subreport.DataSourceConnections)
                {
                    if (connection.ServerName == serverName)
                    {
                        connection.SetLogon(userId, passWord);
                    }
                }
            }
        }


    }
}