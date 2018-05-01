<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="XinxiDetails.aspx.cs" Inherits="admin_XinxiDetails" validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="500" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">标题：</td>
    <td align="left">
        <asp:TextBox runat="server" ID="txtTitle" Width="300px" MaxLength="50" />      
    </td>
  </tr>
  <tr>
    <td align="right">内容：</td>
    <td align="left">
        <FTB:FreeTextBox ID="FreeTextBox1" runat="server" ToolbarStyleConfiguration="Office2003" Width="450px" />
    </td>
  </tr>
  <tr>
  	<td align="right">&nbsp;</td>
    <td align="left">
        <asp:Button id="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="保存" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button id="btnReset" runat="server" onclick="btnReset_Click" Text="返回" />
    </td>
  </tr>
</table>
</asp:Content>

