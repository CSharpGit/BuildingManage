<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="LinkPropertyManagement.aspx.cs" Inherits="admin_LinkPropertyManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" BorderColor="Black" Font-Size="12px" 
        OnRowDataBound="GridView1_RowDataBound" Width="100%" OnRowUpdating="GridView1_RowUpdating"
         OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="ParentGridView_RowCancelingEdit">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="num" HeaderText="房间号" />
            <asp:BoundField DataField="department" HeaderText="所属部门" />
            <asp:BoundField DataField="Cname" HeaderText="中文名称" />
            <asp:BoundField DataField="Ename" HeaderText="英文名称" />
            <asp:BoundField DataField="T_area" HeaderText="教学用房面积" />
            <asp:BoundField DataField="E_area" HeaderText="实验用房面积" />
            <asp:BoundField DataField="A_area" HeaderText="行政用房面积" />
            <asp:BoundField DataField="S_area" HeaderText="教研室面积" />
            <asp:BoundField DataField="R_area" HeaderText="研究室面积" />
            <asp:BoundField DataField="W_area" HeaderText="卫生间" />
            <asp:BoundField DataField="St_area" HeaderText="库房" />
            <asp:BoundField DataField="El_area" HeaderText="配电室" />
            <asp:BoundField DataField="O_area" HeaderText="其他房间" />
            <asp:BoundField DataField="principal" HeaderText="房间负责人" />
            <asp:BoundField DataField="used" HeaderText="是否分配" />
            <asp:BoundField DataField="function" HeaderText="房间用途" />
            <asp:BoundField DataField="note" HeaderText="备注" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
        </Columns>
        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Center" />
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>
    <br />
    <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged"
        Text="全选" AutoPostBack="True" />
    <asp:Button ID="Button1" runat="server" Height="20px" Text="删　除" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Height="20px" Text="取　消" OnClick="Button2_Click" />
    </asp:Content>

