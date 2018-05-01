<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manages1.aspx.cs" Inherits="Default2" %>

<%@ Register src="message1.ascx" tagname="message1" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    

<br />
        
   <table align="center"> 
   <tr> 

   <td valign="top">  <div style="height: auto; width: 700px; margin-left:0px;margin-top:0px;">

     <div style="margin-left:30px; height:auto">



             <uc2:message1 ID="message1" runat="server" Visible="True" />


     </div>

     </div>
</td>
</tr>
</table>

 

</asp:Content>

