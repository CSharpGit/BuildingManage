<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="LinkImportingData.aspx.cs" Inherits="admin_LinkImportingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="DropDownListSqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:BuildingManageConnectionString%>"
        SelectCommand="SELECT [building], [B_id] FROM [Louyu] ORDER BY [B_id]"></asp:SqlDataSource>
    <table align="center" cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td align="right">选择导入数据所属楼宇名称：</td>
            <td align="left">
                <asp:DropDownList ID="DropDownList1" runat="server"
                    DataSourceID="DropDownListSqlDataSource1" DataTextField="building"
                    DataValueField="B_id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">数据源：</td>
            <td align="left">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="left">
                <asp:Button ID="btnImport" runat="server" Text="导入数据" OnClick="btnImport_Click" />
            </td>
        </tr>
    </table>


</asp:Content>

