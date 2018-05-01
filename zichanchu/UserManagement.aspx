<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="admin_UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="500px" height="61" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="150" align="right">用户名：</td>
        <td width="350" class="style1">
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="user" 
                DataValueField="user">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BuildingManageConnectionString%>" 
                SelectCommand="SELECT [user] FROM [Zhuce] WHERE ([permission] &lt;&gt; @permission) ORDER BY [ID]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="47" Name="permission" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
          </td>
      </tr>
      <tr>
        <td align="right">点击获取当前密码：</td>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" 
                onclick="LinkButton1_Click">点击获取</asp:LinkButton>
        </td>
      </tr>
      <tr>
        <td align="right">新密码：</td>
        <td>
        <asp:TextBox ID="txtPwd1" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">确认密码：</td>
        <td>
        <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td></td>
        <td>
        <asp:Button ID="xiugai" Text="修改" runat="server" onclick="xiugai_Click" />
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancle" Text="取消" runat="server" 
                onclick="btnCancle_Click" />
        </td>
      </tr>
    </table>
</asp:Content>