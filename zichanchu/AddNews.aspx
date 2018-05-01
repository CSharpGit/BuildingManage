<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="admin_AddNews" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="500" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50" align="right">类别：</td>
    <td width="450" align="left">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="Xinxi">信息</asp:ListItem>
            <asp:ListItem Value="Gonggao">公告</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
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
        <asp:Button type="submit" value="提交" id="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="提交" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <input name="btnReset" type="reset" value="重置" id="btnReset" /></td>
  </tr>
</table>
</asp:Content>

