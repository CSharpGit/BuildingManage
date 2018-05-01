<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="xiugai.aspx.cs" Inherits="admin_xiugai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="500" height="61" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right">输入原密码：</td>
    <td width="350">
    <asp:TextBox ID="password" runat="server" TextMode="Password" ></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right" class="style1">输入新密码：</td>
    <td class="style1">
    <asp:TextBox ID="xpassword" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">重新输入新密码：</td>
    <td>
    <asp:TextBox ID="cpassword" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td></td>
    <td>
    <asp:Button ID="xiugai" Text="修改" runat="server"  onclick="xiugai_Click" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancle" Text="取消" runat="server" onclick="btnCancle_Click" />
    </td>
  </tr>
</table>
</asp:Content>

