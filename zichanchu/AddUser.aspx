<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="admin_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="500px" height="61" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="150" align="right">用户名：</td>
        <td width="350">
        <asp:TextBox ID="txtUsername" runat="server" TextMode="Password" ></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">密码：</td>
        <td>
        <asp:TextBox ID="txtPwd1" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">确认密码：</td>
        <td>
        <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">用户权限：</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="ZhuceSqlDataSource1" DataTextField="user" 
                DataValueField="permission">
            </asp:DropDownList>
          </td>
      </tr>
      <tr>
        <td></td>
        <td>
        <asp:Button ID="xiugai" Text="修改" runat="server" onclick="xiugai_Click" />
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancle" Text="取消" runat="server" 
                onclick="btnCancle_Click" />
            <asp:SqlDataSource ID="ZhuceSqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BuildingManageConnectionString%>" 
                
                SelectCommand="SELECT [permission], [user] FROM [Zhuce] WHERE ([ID] &lt; @ID) ORDER BY [ID]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="45" Name="ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
      </tr>
    </table>
</asp:Content>

