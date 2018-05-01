<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center;">
        <asp:GridView ID="ParentGridView" BorderColor="Black" OnRowDataBound="ParentGridView_RowDataBound" 
            runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="100%" AllowSorting="True" 
            OnRowEditing="ParentGridView_RowEditing" OnRowCancelingEdit="ParentGridView_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="用户名" ReadOnly="true" />
                <asp:BoundField DataField="time" HeaderText="日期" ReadOnly="true" />
                <asp:TemplateField HeaderText="留言内容">
                    <ItemTemplate>
                        <asp:Button ID="ViewChild_Button" runat="server" Text="查看详情" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="CancelChild_Button" runat="server" Text="取消" CommandName="Cancel" />
                        <asp:GridView ID="ChildGridView" runat="server" AutoGenerateColumns="False"  BorderColor="Black" OnRowDataBound="ChildGridView_RowDataBound" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="L_content" HeaderText="内容" ReadOnly="True">
                                    <HeaderStyle Width="200px" />
                                </asp:BoundField>
                            </Columns>  
                            <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <PagerStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </EditItemTemplate>
                </asp:TemplateField>
<%--                <asp:BoundField DataField="reply" HeaderText="回复" />--%>
                <asp:BoundField DataField="reply" HeaderText="回复">   
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            </Columns>
            <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" />
          <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged"
            Text="全选" AutoPostBack="True" />
        <asp:Button ID="Button1" runat="server" Height="20px" Text="删　除" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Height="20px" Text="取　消" OnClick="Button2_Click" />
    </div>
</asp:Content>

