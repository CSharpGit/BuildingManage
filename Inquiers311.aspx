<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inquiers311.aspx.cs" Inherits="Default6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <style type="text/css">
        .style15
        {
           
            width: 210px;
        }
        </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br />

    <form id="form1" runat="server">
<div>
<table height="700">

    <tr>
        <td class="style15" valign="top" style="padding-top:30px;">
                <table style="width: 20px; height: auto;">
                    <tr>
                        <td align="left">
                            <asp:TreeView ID="TreeView2" runat="server" ImageSet="XPFileExplorer" NodeIndent="15"
                                ShowLines="True" Width="200px">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <Nodes>
                                    <asp:TreeNode Value="genjiedian" Expanded="True" Text="综合查询">
                                        <asp:TreeNode Value="Parent1" Expanded="false" Text="管理员查询" Checked="True">
                                            <asp:TreeNode Value="Child1A" Text="具体房间查询" NavigateUrl="~/Inquiers51.aspx" />
                                            <asp:TreeNode Value="Child1B" Text="部门用房查询" NavigateUrl="~/Inquiers52.aspx" />
                                            <asp:TreeNode Value="Child1C" Text="独立部门查询" Checked="True" Expanded="False">
                                                <asp:TreeNode Value="Child1D" Text="校医院" NavigateUrl="~/Inquiers351.aspx" />
                                                <asp:TreeNode Value="Child1E" Text="图书馆" NavigateUrl="~/Inquiers352.aspx" />
                                                <asp:TreeNode Value="Child1F" Text="离退处" NavigateUrl="~/Inquiers353.aspx" />
                                                <asp:TreeNode Value="Child1G" Text="公寓" NavigateUrl="~/Inquiers354.aspx" />
                                            </asp:TreeNode>
                                            <asp:TreeNode Value="Child1H" Text="房间用途查询" Checked="True" Expanded="False">
                                                <asp:TreeNode Value="Child1I" Text="教学用房" NavigateUrl="~/Inquiers355.aspx" />
                                                <asp:TreeNode Value="Child1J" Text="行政用房" NavigateUrl="~/Inquiers356.aspx" />
                                                <asp:TreeNode Value="Child1K" Text="实验用房" NavigateUrl="~/Inquiers357.aspx" />
                                                <asp:TreeNode Value="Child1L" Text="教研用房" NavigateUrl="~/Inquiers358.aspx" />
                                                <asp:TreeNode Value="Child1M" Text="研究用房" NavigateUrl="~/Inquiers359.aspx" />
                                                <asp:TreeNode Value="Child1N" Text="公寓用房" NavigateUrl="~/Inquiers360.aspx" />
                                                <asp:TreeNode Value="Child1O" Text="图书馆" NavigateUrl="~/Inquiers361.aspx" />
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Value="Parent2" Expanded="True" Text="各院系查询">
                                            <asp:TreeNode Value="Child2A" Text="电气工程学院" NavigateUrl="~/Inquiers301.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2B" Text="自动化工程学院" NavigateUrl="~/Inquiers302.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2C" Text="经济管理学院" NavigateUrl="~/Inquiers303.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2D" Text="建筑工程学院" NavigateUrl="~/Inquiers304.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2E" Text="理学院" NavigateUrl="~/Inquiers305.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2G" Text="体育学院" NavigateUrl="~/Inquiers306.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2H" Text="艺术学院" NavigateUrl="~/Inquiers307.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2I" Text="能源与动力工程学院" NavigateUrl="~/Inquiers308.aspx">
                                            </asp:TreeNode>
                                            <asp:TreeNode Value="Child2J" Text="信息工程学院" NavigateUrl="~/Inquiers309.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2K" Text="化学工程学院" NavigateUrl="~/Inquiers310.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2L" Text="外国语学院" NavigateUrl="~/Inquiers311.aspx" 
                                                Selected="True"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2M" Text="社会科学学院" NavigateUrl="~/Inquiers312.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2N" Text="媒体技术与传媒系" NavigateUrl="~/Inquiers313.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2O" Text="输配电工程学院" NavigateUrl="~/Inquiers315.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2P" Text="国际交流学院" NavigateUrl="~/Inquiers317.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2Q" Text="自控学院" NavigateUrl="~/Inquiers316.aspx"></asp:TreeNode>
                                            <asp:TreeNode Value="Child2R" Text="输变电技术学院" NavigateUrl="~/Inquiers314.aspx"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Value="Parent3" Expanded="false" Text="其他部门查询" Checked="True">
                                            <asp:TreeNode Value="Child3A" Text="资产处" NavigateUrl="~/Inquiers330.aspx" />
                                            <asp:TreeNode Value="Child3B" Text="人事处" NavigateUrl="~/Inquiers326.aspx" />
                                            <asp:TreeNode Value="Child3C" Text="信息化教学中心" NavigateUrl="~/Inquiers321.aspx" />
                                            <asp:TreeNode Value="Child3D" Text="纪检委" NavigateUrl="~/Inquiers322.aspx" />
                                            <asp:TreeNode Value="Child3E" Text="校友总会" NavigateUrl="~/Inquiers323.aspx" />
                                            <asp:TreeNode Value="Child3F" Text="校友会" NavigateUrl="~/Inquiers324.aspx" />
                                            <asp:TreeNode Value="Child3G" Text="工程训练教学中心" 
                                                NavigateUrl="~/Inquiers325.aspx" />
                                            <asp:TreeNode Value="Child3H" Text="民族党派办公室" NavigateUrl="~/Inquiers327.aspx" />
                                            <asp:TreeNode Value="Child3I" Text="教育发展研究所" NavigateUrl="~/Inquiers328.aspx" />
                                            <asp:TreeNode Value="Child3J" Text="工会" NavigateUrl="~/Inquiers329.aspx" />
                                            <asp:TreeNode Value="Child3K" Text="媒体" NavigateUrl="~/Inquiers331.aspx" />
                                            <asp:TreeNode Value="Child3L" Text="保卫处" NavigateUrl="~/Inquiers332.aspx" />
                                            <asp:TreeNode Value="Child3M" Text="组织部、统战部" NavigateUrl="~/Inquiers333.aspx" />
                                            <asp:TreeNode Value="Child3N" Text="教务处" NavigateUrl="~/Inquiers334.aspx" />
                                            <asp:TreeNode Value="Child3O" Text="教育发展研究室" NavigateUrl="~/Inquiers335.aspx" />
                                            <asp:TreeNode Value="Child3P" Text="科产处" NavigateUrl="~/Inquiers336.aspx" />
                                            <asp:TreeNode Value="Child3Q" Text="科技产业处" NavigateUrl="~/Inquiers337.aspx" />
                                            <asp:TreeNode Value="Child3R" Text="监审处" NavigateUrl="~/Inquiers338.aspx" />
                                            <asp:TreeNode Value="Child3S" Text="宣传部" NavigateUrl="~/Inquiers339.aspx" />
                                            <asp:TreeNode Value="Child3T" Text="后勤保障部" NavigateUrl="~/Inquiers340.aspx" />
                                            <asp:TreeNode Value="Child3V" Text="产业办" NavigateUrl="~/Inquiers342.aspx" />
                                            <asp:TreeNode Value="Child3W" Text="国际合作处" NavigateUrl="~/Inquiers343.aspx" />
                                            <asp:TreeNode Value="Child3X" Text="训练中心" NavigateUrl="~/Inquiers344.aspx" />
                                            <asp:TreeNode Value="Child3Y" Text="团委" NavigateUrl="~/Inquiers345.aspx" />
                                            <asp:TreeNode Value="Child3Z" Text="计划财务处" NavigateUrl="~/Inquiers346.aspx" />
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="Small" ForeColor="Black" HorizontalPadding="2px"
                                    NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                    VerticalPadding="0px" />
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
        </td>
        <td style="height:auto;width:690px;" valign="top">

            <div style="height:auto;width:690px;">
                <div style="height:100px; width:690px; margin-bottom: 0;text-align:center;vertical-align:center;">
                  请输入所要选择的学院&nbsp
                    <asp:DropDownList ID="DropDownList1" runat="server"  Width="140px" 
                        Height="25px">
                        <asp:ListItem Value="0">外国语学院</asp:ListItem>
                        <asp:ListItem Value="1">自动化工程学院</asp:ListItem>
                        <asp:ListItem Value="2">经济管理学院</asp:ListItem>
                        <asp:ListItem Value="3">建筑工程学院</asp:ListItem>
                        <asp:ListItem Value="4">理学院</asp:ListItem>
                        <asp:ListItem Value="5">体育学院</asp:ListItem>
                        <asp:ListItem Value="6">艺术学院</asp:ListItem>
                        <asp:ListItem Value="7">能源与动力工程学院</asp:ListItem>
                        <asp:ListItem Value="8">信息工程学院</asp:ListItem>
                        <asp:ListItem Value="9">化学工程学院</asp:ListItem>
                        <asp:ListItem Value="10">电气工程学院</asp:ListItem>
                        <asp:ListItem Value="11">社会科学学院</asp:ListItem>
                        <asp:ListItem Value="12">媒体技术与传媒系</asp:ListItem>
                        <asp:ListItem Value="13">输变电技术学院</asp:ListItem>
                        <asp:ListItem Value="14">输配电工程学院</asp:ListItem>
                        <asp:ListItem Value="15">自控学院</asp:ListItem>
                        <asp:ListItem Value="16">国际交流学院</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定"  Width="60" height="25"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="导出" Width="60" height="25" 
                        onclick="Button2_Click"/>
                    <br />
                    <br />
                    <asp:CheckBox ID="a" runat="server" Width="93" height="25" Text="教学用房"/>
                    <asp:CheckBox ID="b" runat="server" Width="93" height="25" Text="实验用房"/>
                    <asp:CheckBox ID="c" runat="server" Width="93" height="25" Text="行政用房"/>
                    <asp:CheckBox ID="d" runat="server" Width="74" height="25" Text="教研室"/>
                    <asp:CheckBox ID="f" runat="server" Width="74" height="25" Text="研究室"/>
                    <asp:CheckBox ID="g" runat="server" Width="74" height="25" Text="卫生间"/>
                    <br />
                    <asp:CheckBox ID="h" runat="server" Width="74" height="25" Text="库房"/>
                    <asp:CheckBox ID="i" runat="server" Width="74" height="25" Text="配电室"/>
                    <asp:CheckBox ID="j" runat="server" Width="93" height="25" Text="其它用房"/>
                    <asp:CheckBox ID="k" runat="server" Width="110" height="25" Text="房间负责人"/>
                    <asp:CheckBox ID="l" runat="server" Width="93" height="25" Text="是否分配"/>
                    <asp:CheckBox ID="m" runat="server" Width="93" height="25" Text="房间用途"/>

                    <br />
                    <br />
                </div>
                <br />
                <br />
                 <div style="height:700px; width:690px; overflow: scroll">
                    <asp:GridView ID="GridView1" runat="server" Width="690px" 
                         CellPadding="4" ForeColor="#333333">               
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataRowStyle Width="10px" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle Wrap="true" BackColor="#507CD1" Font-Bold="True" 
                            ForeColor="White"  />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1"   />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE"   />
                    </asp:GridView>
                </div>
            </div>


        </td>
    </tr>
</table>
</div>
</form>
</asp:Content>



