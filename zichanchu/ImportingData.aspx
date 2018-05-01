<%@ Page Title="" Language="C#" MasterPageFile="~/zichanchu/MasterPage.master" AutoEventWireup="true" CodeFile="ImportingData.aspx.cs" Inherits="admin_ImportingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TreeView ID="tree1" runat="server" NodeIndent="15" ShowLines="true" Width="200px">
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <Nodes>
            <asp:TreeNode Value="gengjiedian" Text="数据导入">
                <asp:TreeNode Value="ParentA" Expanded="True" Text="独立部门数据导入">
                    <asp:TreeNode Value="ChildA1" Text="校医院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=校医院&nums=1&bid=11" />
                    <asp:TreeNode Value="ChildA2" Text="新图书馆" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=新图书馆&nums=1&bid=32" />
                    <asp:TreeNode Value="ChildA3" Text="老图书馆" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=老图书馆&nums=1&bid=9" />
                    <asp:TreeNode Value="ChildA4" Text="离退处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=离退处&nums=1&bid=8" />
                    <asp:TreeNode Value="ChildA5" Text="公寓" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=公寓&nums=1" />
                </asp:TreeNode>
                <asp:TreeNode Value="ParentB" Expanded="False" Text="各院系数据导入">
                    <asp:TreeNode Value="ChildB1" Text="电气工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=电气工程学院" />
                    <asp:TreeNode Value="ChildB2" Text="自动化工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=自动化工程学院" />
                    <asp:TreeNode Value="ChildB3" Text="经济管理学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=经济管理学院" />
                    <asp:TreeNode Value="ChildB4" Text="建筑工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=建筑工程学院" />
                    <asp:TreeNode Value="ChildB5" Text="理学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=理学院" />
                    <asp:TreeNode Value="ChildB6" Text="体育学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=体育学院" />
                    <asp:TreeNode Value="ChildB7" Text="艺术学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=艺术学院" />
                    <asp:TreeNode Value="ChildB8" Text="能源与动力工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=能源与动力工程学院" />
                    <asp:TreeNode Value="ChildB9" Text="信息工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=信息工程学院" />
                    <asp:TreeNode Value="ChildB10" Text="化学工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=化学工程学院" />
                    <asp:TreeNode Value="ChildB11" Text="外国语学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=外国语学院" />
                    <asp:TreeNode Value="ChildB12" Text="社会科学学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=社会科学学院" />
                    <asp:TreeNode Value="ChildB13" Text="媒体技术与传媒系" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=媒体技术与传媒系" />
                    <asp:TreeNode Value="ChildB14" Text="输配电工程学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=输配电工程学院" />
                    <asp:TreeNode Value="ChildB15" Text="国际交流学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=国际交流学院" />
                    <asp:TreeNode Value="ChildB16" Text="自控学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=自控学院" />
                    <asp:TreeNode Value="ChildB17" Text="输变电技术学院" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=输变电技术学院" />
                </asp:TreeNode>
                <asp:TreeNode Value="ParentC" Expanded="False" Text="其他部门数据导入">
                    <asp:TreeNode Value="ChildC1" Text="资产处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=资产处" />
                    <asp:TreeNode Value="ChildC2" Text="人事处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=人事处" />
                    <asp:TreeNode Value="ChildC3" Text="信息化教学中心" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=信息化教学中心" />
                    <asp:TreeNode Value="ChildC4" Text="纪检委" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=纪检委" />
                    <asp:TreeNode Value="ChildC5" Text="校友总会" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=校友总会" />
                    <asp:TreeNode Value="ChildC6" Text="校友会" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=校友会" />
                    <asp:TreeNode Value="ChildC7" Text="工程训练教学中心" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=工程训练教学中心" />
                    <asp:TreeNode Value="ChildC8" Text="民族党派办公室" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=民族党派办公室" />
                    <asp:TreeNode Value="ChildC9" Text="教育发展研究所" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=教育发展研究所" />
                    <asp:TreeNode Value="ChildC10" Text="工会" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=工会" />
                    <asp:TreeNode Value="ChildC11" Text="媒体" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=媒体" />
                    <asp:TreeNode Value="ChildC12" Text="保卫处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=保卫处" />
                    <asp:TreeNode Value="ChildC13" Text="组织部、统战部" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=组织部、统战部" />
                    <asp:TreeNode Value="ChildC14" Text="教务处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=教务处" />
                    <asp:TreeNode Value="ChildC15" Text="教育发展研究室" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=教育发展研究室" />
                    <asp:TreeNode Value="ChildC16" Text="科产处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=科产处" />
                    <asp:TreeNode Value="ChildC17" Text="科技产业处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=科技产业处" />
                    <asp:TreeNode Value="ChildC18" Text="监审处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=监审处" />
                    <asp:TreeNode Value="ChildC19" Text="宣传部" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=宣传部" />
                    <asp:TreeNode Expanded="False" NavigateUrl="" Text="后勤保障部" Value="ParentD">
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
                    <asp:TreeNode Value="ChildC22" Text="产业办" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=产业办" />
                    <asp:TreeNode Value="ChildC23" Text="国际合作处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=国际合作处" />
                    <asp:TreeNode Value="ChildC24" Text="训练中心" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=训练中心" />
                    <asp:TreeNode Value="ChildC25" Text="团委" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=团委" />
                    <asp:TreeNode Value="ChildC26" Text="计划财务处" NavigateUrl="~/zichanchu/LinkImportingData.aspx?louyu=计划财务处" />
                </asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
</asp:Content>

