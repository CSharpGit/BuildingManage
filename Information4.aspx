<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Information4.aspx.cs" Inherits="Default5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style16
        {
            width: 11px;
        }
        .style17
        {
            height: 423px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p style="height: 10px"></p>
   <table>
   <tr>
   <td>
    <div style="height: auto; width: 910px; margin-left: 232">
    <table border="2"; width="100%" cellpadding="0" cellspacing="0" style="height: 400px;border-color:#CCFFFF">
<tr><td height="40" align="center" valign="middle" style="color:black; font-size:26px;boder-color:#333333"; >公告栏</td></tr>
<tr>
<td width="100%" class="style17">
<div id="Div1" style="width:100%;height:400px;overflow-y:scroll;valign:center;float:right" runat="server">
        <form id="Form1" runat="server">
        <asp:DataList ID="tExperience1" runat="server" DataKeyField="ID" RepeatColumns="1"
                     RepeatDirection="Horizontal" 
            onitemcommand="tExperience_ItemCommand1" Width="100%" CellPadding="4" 
            Font-Size="Large" Height="29px" Font-Overline="False" 
            Font-Strikeout="False" BackColor="White" BorderColor="White" 
            BorderStyle="Double" BorderWidth="3px" GridLines="Horizontal">
                     <FooterStyle BackColor="White" ForeColor="#333333" 
                         BorderColor="#CCFFFF" />
                     <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                     <ItemStyle BackColor="White" ForeColor="#333333" />
                     <ItemTemplate runat="server">
                       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="37" class="style16"><img src="images/xinwen.png"/></td>
                            <td width="900" height="37" style="font-size:15px;float:left">
                            <asp:LinkButton runat="server" CommandName="Experience1" ID="lbnExperience1">
                            <%#DataBinder.Eval(Container.DataItem, "Title").ToString()%>
                            </asp:LinkButton>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                     </table>
                  </ItemTemplate>
                     <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" runat="server"/>
              </asp:DataList>
		</div>
        </form>
		<br />
		</td></tr></table>

    </div><p style="height:13px"></p>
    </td>
    </tr>
    </table>
    </asp:Content>

