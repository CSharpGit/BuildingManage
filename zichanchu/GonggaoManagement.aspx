<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="GonggaoManagement.aspx.cs" Inherits="admin_GonggaoManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="container">
        <asp:GridView ID="GridView1" ShowFooter="false" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"  runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="100%"  AllowPaging="True" OnRowDeleting="GridView1_RowDeleting">
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" />
            <asp:BoundField DataField="title" HeaderText="标题" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="time" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" />
            <asp:TemplateField HeaderText="公告内容">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "GonggaoDetails.aspx?ID="+Eval("ID")%>'
                            Text='<%# "公告详情" %>'></asp:HyperLink>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" BorderStyle="None" BorderWidth="0px" ForeColor="#330099" />
            <PagerSettings Visible="False" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton> 
        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 
        <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton> 
跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> 
        </asp:DropDownList>页
    </div>
</asp:Content>

