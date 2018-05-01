<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manages2.aspx.cs" Inherits="Default6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" runat="server"> 
<p style="height: 10px"></p>
  <table align="center">
  <tr>
 <td valign="top">
 <div style="height: 281px; width: 673px; margin-left: 232">

 <div style="height: 262px">
     <br />
     <br />

     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

     您对我们有什么意见或者建议，欢迎留言！<br />
     <br />
<br>
<table width="600" border="0" cellspacing="0" cellpadding="0">
<tr>
    <td height="30" align="right" valign="middle">
        &nbsp;姓名：</td>
    <td width="480"><asp:TextBox ID="txtname" runat="server"></asp:TextBox><br/>
    </td>
</tr>
<tr>
    <td height="45" align="right" valign="middle">
       &nbsp;内容：</td>
       <td width="480"><asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine" 
               Rows="5" Columns="40" MaxLength="200"></asp:TextBox>    </td>
</tr>
</table>
                                                                                                                                                                                                  
<table width="600" border="0" cellspacing="0" cellpadding="0">

<tr>
    <td height="20" align="center" valign="top" width="600">
        
        <br/>&nbsp;<asp:Button ID="Button1" runat="server" Text="提交" 
            onclick="Button1_Click" />&nbsp;&nbsp;<asp:Button ID="Button2" 
            runat="server" Text="清除" onclick="Button2_Click" />
        
    </td>
</tr>

</table>

</div>
    </div>
</form>
</td>
</tr>  
</table>
    </asp:Content>

