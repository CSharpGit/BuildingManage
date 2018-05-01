<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style15
        {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <div style="margin-left:30%;float:left"><h1>主石头楼报表</h1></div>
        <div style="margin-left:50px;float:left">
            <h1><a href="javascript:void(0)" onclick="window.open('ReadCad.aspx?id=<%=Server.UrlEncode("dwgFile/主石头楼/主石头楼.dwg") %>')">查看楼层CAD</a></h1>
            <%--<h1><asp:Button ID="bt_cad" runat="server" Text="查看楼层CAD" OnClick="bt_cad_Click" Font-Size="16"/></h1>--%>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="910px" Height="800px">
            <LocalReport ReportPath="主石头楼.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DataSet1TableAdapters.主石头楼TableAdapter"></asp:ObjectDataSource>
    </form>
</asp:Content>
