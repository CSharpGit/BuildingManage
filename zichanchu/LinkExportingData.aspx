<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="LinkExportingData.aspx.cs" Inherits="admin_LinkExportingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" BorderColor="Black" Font-Size="12px" 
        OnRowDataBound="GridView1_RowDataBound" Width="100%">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="序号" />
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
        </Columns>
        <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Center" />
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="——EXCEL导出" Height="34px" OnClick="Button1_Click" Width="263px" />
    <asp:Button ID="btnReturn" runat="server" Text="退后" Width="263px" Height="34px" onclick="btnReturn_Click" />
</asp:Content>

