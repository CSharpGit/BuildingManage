<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="AddProperty.aspx.cs" Inherits="admin_AddProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TreeView ID="tree1" runat="server" NodeIndent="15" ShowLines="true" 
        Width="300px">
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <Nodes>
            <asp:TreeNode Text="房产添加" Value="gengjiedian">
                <asp:TreeNode Expanded="True" Text="独立部门房产添加" Value="ParentA">
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=校医院&num=1" 
                        Text="校医院" Value="ChildA1" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=新图书馆&num=1" 
                        Text="新图书馆" Value="ChildA2" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=老图书馆&num=1" 
                        Text="老图书馆" Value="ChildA3" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=离退处&num=1" 
                        Text="离退处" Value="ChildA4" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=公寓&num=1" 
                        Text="公寓" Value="ChildA5" />
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" Text="各院系房产添加" Value="ParentB">
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=电气工程学院" 
                        Text="电气工程学院" Value="ChildB1" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=自动化工程学院" 
                        Text="自动化工程学院" Value="ChildB2" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=经济管理学院" 
                        Text="经济管理学院" Value="ChildB3" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=建筑工程学院" 
                        Text="建筑工程学院" Value="ChildB4" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=理学院" 
                        Text="理学院" Value="ChildB5" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=体育学院" 
                        Text="体育学院" Value="ChildB6" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=艺术学院" 
                        Text="艺术学院" Value="ChildB7" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=能源与动力工程学院" 
                        Text="能源与动力工程学院" Value="ChildB8" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=信息工程学院" 
                        Text="信息工程学院" Value="ChildB9" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=化学工程学院" 
                        Text="化学工程学院" Value="ChildB10" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=外国语学院" 
                        Text="外国语学院" Value="ChildB11" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=社会科学学院" 
                        Text="社会科学学院" Value="ChildB12" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=媒体技术与传媒系" 
                        Text="媒体技术与传媒系" Value="ChildB13" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=输配电工程学院" 
                        Text="输配电工程学院" Value="ChildB14" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=国际交流学院" 
                        Text="国际交流学院" Value="ChildB15" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=自控学院" 
                        Text="自控学院" Value="ChildB16" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=输变电技术学院" 
                        Text="输变电技术学院" Value="ChildB17" />
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" Text="其他部门房产添加" Value="ParentC">
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=资产处" 
                        Text="资产处" Value="ChildC1" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=人事处" 
                        Text="人事处" Value="ChildC2" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=信息化教学中心" 
                        Text="信息化教学中心" Value="ChildC3" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=纪检委" 
                        Text="纪检委" Value="ChildC4" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=校友总会" 
                        Text="校友总会" Value="ChildC5" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=校友会" 
                        Text="校友会" Value="ChildC6" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=工程训练教学中心" 
                        Text="工程训练教学中心" Value="ChildC7" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=民族党派办公室" 
                        Text="民族党派办公室" Value="ChildC8" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=教育发展研究所" 
                        Text="教育发展研究所" Value="ChildC9" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=工会" 
                        Text="工会" Value="ChildC10" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=媒体" 
                        Text="媒体" Value="ChildC11" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=保卫处" 
                        Text="保卫处" Value="ChildC12" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=组织部、统战部" 
                        Text="组织部、统战部" Value="ChildC13" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=教务处" 
                        Text="教务处" Value="ChildC14" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=教育发展研究室" 
                        Text="教育发展研究室" Value="ChildC15" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=科产处" 
                        Text="科产处" Value="ChildC16" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=科技产业处" 
                        Text="科技产业处" Value="ChildC17" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=监审处" 
                        Text="监审处" Value="ChildC18" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=宣传部" 
                        Text="宣传部" Value="ChildC19" />
                    <asp:TreeNode Expanded="False" Text="后勤保障部" Value="ParentD">
                        <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="办公室" Value="ChildD1" />
                        <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="内控科" Value="ChildD2" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="工程科" Value="ChildD3" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="修缮科" Value="ChildD4" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="物资科" Value="ChildD5" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="校园管理科" Value="ChildD6" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="公寓管理科" Value="ChildD7" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="水电管理科" Value="ChildD8" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="饮食管理科" Value="ChildD9" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="住宅小区管理科" Value="ChildD10" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="专家招待所" Value="ChildD11" />
                            <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=后勤保障部" 
                            Text="就业服务处" Value="ChildD12" />
                    </asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=产业办" 
                        Text="产业办" Value="ChildC22" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=国际合作处" 
                        Text="国际合作处" Value="ChildC23" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=训练中心" 
                        Text="训练中心" Value="ChildC24" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=团委" 
                        Text="团委" Value="ChildC25" />
                    <asp:TreeNode NavigateUrl="~/zichanchu/LinkAddProperty.aspx?louyu=计划财务处" 
                        Text="计划财务处" Value="ChildC26" />
                </asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
</asp:Content>

