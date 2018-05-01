<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Information3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style15
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
        <div style="width:900px; height: auto;">
    <div style="height:auto;overflow:auto;">
    <table width="100%" style="height:500px">
            <tr>
                <td height="25" align="center" style="font-size:20px; font-weight:bold";}><asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </td>
            </tr>
            
            <tr>
                <td align="center" class="style15"><asp:Literal ID="litAuthor" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="litDate" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td height="auto" valign="top" style="line-height:25px"><asp:Literal ID="litContent" runat="server"></asp:Literal></td>
            </tr>
        </table>
        </div>
    </div>


    </asp:Content>

