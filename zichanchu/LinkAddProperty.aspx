<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="LinkAddProperty.aspx.cs" Inherits="admin_LinkAddProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" ShowFooter="true" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"   runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="100%" AllowSorting="True">
    <Columns>
        <asp:TemplateField HeaderText="房间号">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="num" runat="server" Text='<%# Bind("num") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="num" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="所属部门">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="department" runat="server" Text='<%# Bind("department") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="中文名称">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="Cname" runat="server" Text='<%# Bind("Cname") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="Cname" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="英文名称">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="Ename" runat="server" Text='<%# Bind("Ename") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="Ename" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="教学用房面积">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="T_area" runat="server" Text='<%# Bind("T_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="T_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="实验用房面积">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="E_area" runat="server" Text='<%# Bind("E_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="E_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="行政用房面积">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="A_area" runat="server" Text='<%# Bind("A_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="A_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="教研室面积">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="S_area" runat="server" Text='<%# Bind("S_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="S_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="研究室面积">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="R_area" runat="server" Text='<%# Bind("R_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="R_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="卫生间">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="W_area" runat="server" Text='<%# Bind("W_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="W_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="库房">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="St_area" runat="server" Text='<%# Bind("St_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="St_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="配电室">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="El_area" runat="server" Text='<%# Bind("El_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="El_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="其他房间">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="O_area" runat="server" Text='<%# Bind("O_area") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="O_area" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="房间负责人">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="principal" runat="server" Text='<%# Bind("principal") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="principal" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="是否分配">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="used" runat="server" Text='<%# Bind("used") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="used" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="房间用途">
            <ControlStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="function" runat="server" Text='<%# Bind("function") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="function" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="备注">
            <ControlStyle Width="200px" />
            <ItemTemplate>
                <asp:Label ID="note" runat="server" Text='<%# Bind("note") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="note" runat="server" Width="80px"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="取 消" OnClick="btnCancel_Click" />
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
    <RowStyle HorizontalAlign="Center" />
    <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>

