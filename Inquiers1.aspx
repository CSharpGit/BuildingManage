<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Inquiers1.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <div style="height:auto; width: 910px; margin-left: 0px;">
                        <form id="Form1" runat="server">
                        <div align="center" style="margin-top: 20px; width: 900px; height: 25;">
                            <asp:Label ID="biaoshi" runat="server" Text="请输入新校区或者老校区："></asp:Label>
                            <asp:TextBox
                                ID="loubiaoshi" runat="server" Width="105px" Height="20px"></asp:TextBox>
                            <asp:Label ID="mingcheng" runat="server" Text="请输入楼宇的名称："></asp:Label>
                            <asp:TextBox ID="loumingcheng"
                                runat="server" Width="105px" Height="20px"></asp:TextBox>
                            <asp:Label ID="biaohao" runat="server" Text="请输入楼宇的编号："></asp:Label>
                            <asp:TextBox ID="loubiaohao"
                                runat="server" Width="105px" Height="20px"></asp:TextBox>
                        </div>
                        <div align="center" style="margin-top: 20px; width: 900px;">
                            <asp:Button ID="chaxun" runat="server" Text="查询" OnClick="Button1_Click" Width="80px"
                                Height="28px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="重新查询" Width="80px"
                                Height="28px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="导出" Width="80px"
                                Height="28px" />
                        </div>
                        <br />
                        <br />
                        <div style="width: 900px; height:auto; overflow: auto;">
                            <div align="center" style="height:auto;">
                                <asp:GridView ID="GridView1" runat="server" Width="900px" Height="247px" HorizontalAlign="Center"
                                    EnableTheming="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>
                        </div>
                        </form>
                    </div>
                </td>
    </div>
    </tr> </table>
</asp:Content>
