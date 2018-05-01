<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Information2.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style15
    {
        height: 25px;
            width: 900px;
        }
        .style16
        {
            width: 900px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width:910px; height: auto;">
    <div style="height:100%;">
        <table style="height:500px; width: 100%; margin-left: 0;">
            <tr>
                <td align="center" style="font-size:20px; font-weight:bold";} class="style15">&nbsp;<asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </td>
            </tr>
            
            <tr>
                <td height="25" align="center" class="style16">&nbsp;<asp:Literal ID="litAuthor" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="litDate" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td height="auto" valign="top" style="line-height:25px" class="style16"><asp:Literal ID="litContent" runat="server"></asp:Literal></td>
            </tr>
        </table>
     </div>
</div>

</asp:Content>

