<%@ Control Language="C#" AutoEventWireup="true" CodeFile="message1.ascx.cs" Inherits="message" %>

<asp:Repeater ID="MsgList" runat="server">

<HeaderTemplate>

    <table border="1px" cellspacing="0" cellpadding="0" style="border:#999999;width:620px;border-style:inherit;">

    <tr>
    <td align="center" style="width:620px; line-height:40px;font-size:25px;">留言信息</td>
    </tr>

    </table>

</HeaderTemplate>
<ItemTemplate>

<table width="620" border="1" cellspacing="0" cellpadding="0" style="font-size: 14px;border-color:#999999; ">
<tr>
<td height="30"><div style="padding-top:2px;padding-left:2em; padding-right:5px; ">
    <div style="float:right; padding-left:5px; padding-right:5px; "><span style="color:#993a4e;font-size:14px;">日期:</span><%#Eval("time") %></div>
     <span style="color:#993a4e;font-size:14px;">用户名：</span><%#Eval("Name") %></div>
</td> 
</tr>
<tr>
<td height="2" style="background-image: url(images/index_07_06.gif);width: 620px; line-height:2px" >
</td>
</tr>
<tr height="80" valign="top" style="background-image: url(images/index_07_06.gif);
        width: 620px;  font-size:14px">
 <td style=" padding:5px 0 0 2em;">
       <span style="color:#993a4e;font-size:14px;">留言内容：</span><%#Server.HtmlEncode(Eval("L_content").ToString()) %>
 </td>
</tr>
<tr>
    <td height="20" align="left" valign="top" style="background-image: url(images/index_07_06.gif);width: 620px; line-height: 15px;font-size:14px; padding-left:2em; vertical-align:top;">
       <span style="color:#993a4e;font-size:14px;">回复:</span> <%#Eval("reply") %></td>
</tr>
</table>

        

</ItemTemplate>



</asp:Repeater>
    <table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td align="center" height="30">
    <form id="form1"  runat="server">
    <asp:LinkButton ID="home" runat="server" Text="首页" Font-Size=13px onclick="home_Click"/>&nbsp;
    <asp:LinkButton ID="pre" runat="server" Text="上一页" Font-Size=13px onclick="pre_Click"/>&nbsp;
    <asp:LinkButton ID="next" runat="server" Text="下一页" Font-Size=13px onclick="next_Click"/>&nbsp;
    <asp:LinkButton ID="last" runat="server" Text="末页" Font-Size=13px onclick="last_Click"/>
    </td></tr>
    </form></table>
</div>
