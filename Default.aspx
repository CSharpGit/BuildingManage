<%@ Page Title="东北电力大学房产管理平台" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Map.ascx" TagName="Map" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%--  ajax加载图像--%>
    <script type="text/javascript">
        function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
        var OverH, OverW, ChangeDesc, ChangeH = 50, ChangeW = 50;
        function OpenDiv(_Dw, _Dh, _Desc) {
            $("www_zzjs_net").innerHTML = "loading";
            OverH = _Dh; OverW = _Dw; ChangeDesc = _Desc;
            $("www_zzjs_net").style.display = '';
            if (_Dw > _Dh) { ChangeH = Math.ceil((_Dh - 10) / ((_Dw - 10) / 50)) } else if (_Dw < _Dh) { ChangeW = Math.ceil((_Dw - 10) / ((_Dh - 10) / 50)) }
            $("www_zzjs_net").style.top = (document.documentElement.clientHeight - 10) / 2 + "px";
            $("www_zzjs_net").style.left = (document.documentElement.clientWidth - 10) / 2 + "px";
            OpenNow()
        }
        var Nw = 10, Nh = 10;
        function OpenNow() {
            if (Nw > OverW - ChangeW) ChangeW = 2;
            if (Nh > OverH - ChangeH) ChangeH = 2;
            Nw = Nw + ChangeW; Nh = Nh + ChangeH;
            if (OverW > Nw || OverH > Nh) {
                if (OverW > Nw) {
                    $("www_zzjs_net").style.width = Nw + "px";
                    $("www_zzjs_net").style.left = (document.documentElement.clientWidth - Nw) / 2 + "px";
                }
                if (OverH > Nh) {
                    $("www_zzjs_net").style.height = Nh + "px";
                    $("www_zzjs_net").style.top = (document.documentElement.clientHeight - Nh) / 2 + "px"
                }
                window.setTimeout("OpenNow()", 10)
            } else {
                Nw = 10; Nh = 10; ChangeH = 50; ChangeW = 50;
                AjaxGet(ChangeDesc)
            }
        }
        //创建XML对象
        function createXMLHttps() {
            var ret = null;
            try { ret = new ActiveXObject('Msxml2.XMLHTTP') }
            catch (e) {
                try { ret = new ActiveXObject('Microsoft.XMLHTTP') }
                catch (ee) { ret = null }
            }
            if (!ret && typeof XMLHttpRequest != 'undefined') ret = new XMLHttpRequest();
            return ret;
        }
        function AjaxGet(URL) {
            var xmlhttp = createXMLHttps();
            xmlhttp.open("Get", URL, true);
            xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 404) { $("www_zzjs_net").innerHTML = '读取页面失败，文件' + URL + '不存在！'; return }
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    $("www_zzjs_net").innerHTML = "<div class='LoadContent'>" + xmlhttp.responseText + "</div>";
                }
            }
            xmlhttp.send(null);
        }
    </script>
    <%--图片自动切换的javascript--%>
    <script type="text/javascript">
        function $(id) { return document.getElementById(id) }
        function moveElement(elementID, final_x, final_y, interval) {//这个方法在DOM艺术那个书上讲的很清楚 
            if (!document.getElementById) return false;
            if (!document.getElementById(elementID)) return false;
            var elem = document.getElementById(elementID);
            if (elem.movement) {
                clearTimeout(elem.movement);
            }
            if (!elem.style.left) {
                elem.style.left = "0px";
            }
            if (!elem.style.top) {
                elem.style.top = "0px";
            }
            var xpos = parseInt(elem.style.left);
            var ypos = parseInt(elem.style.top);
            if (xpos == final_x && ypos == final_y) {
                return true;
            }
            if (xpos < final_x) {
                var dist = Math.ceil((final_x - xpos) / 10);
                xpos = xpos + dist;
            }
            if (xpos > final_x) {
                var dist = Math.ceil((xpos - final_x) / 10);
                xpos = xpos - dist;
            }
            if (ypos < final_y) {
                var dist = Math.ceil((final_y - ypos) / 10);
                ypos = ypos + dist;
            }
            if (ypos > final_y) {
                var dist = Math.ceil((ypos - final_y) / 10);
                ypos = ypos - dist;
            }
            elem.style.left = xpos + "px";
            elem.style.top = ypos + "px";
            var repeat = "moveElement('" + elementID + "'," + final_x + "," + final_y + "," + interval + ")";
            elem.movement = setTimeout(repeat, interval);
        }
        function imgChange(num) {//切换图片焦点 
            if (!$('play')) return false;
            var piclist = $('playimg').getElementsByTagName('img');
            var imgheight = piclist[0].offsetHeight;
            var moveY = -(imgheight * num);
            moveElement('playimg', 0, moveY, 5);
        }
        function classToggle(arr, n) {//切换按钮样式 
            for (var i = 0; i < arr.length; i++) {
                arr[i].className = '';
            }
            arr[n].className = 'current';
        }
        function btnChange(btns) {//鼠标移动播放 
            if (!$(btns)) return false;
            $('play').onmouseover = function () { autokey = false };
            $('play').onmouseout = function () { autokey = true };
            var arr = $(btns).getElementsByTagName('li');
            for (var i = 0; i < arr.length; i++) {
                arr[i].index = i; //设置索引号 
                arr[i].onmouseover = function () {
                    //var num=index(this,arr); 
                    classToggle(arr, this.index);
                    imgChange(this.index);
                }
            }
        }
        function autoChange(btns) {
            if (!$(btns)) return false;
            if (!autokey) return false;
            var arr = $(btns).getElementsByTagName('li');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].className == 'current') {
                    var n = i + 1;
                }
            }
            if (n >= arr.length) n = 0;
            classToggle(arr, n);
            imgChange(n);
        }
        var autokey = true;
        setInterval("autoChange('playbtn')", 6000);
        window.onload = function () {
            btnChange('playbtn');
        } 
    </script>
    <%--ajax加载图片的样式设计--%>
    <style type="text/css">
        #www_zzjs_net
        {
            position: fixed;
            z-index: 10;
            left: 50%;
            top: 50%;
            border: 1px #666666;
            background: #eeeeee;
            width: 10px;
            height: 10px;
        }
        .LoadContent
        {
            width: 100%;
            height: 100%;
        }
    </style>
    <%--整个页面的样式设计--%>
    <style type="text/css">
        a:link, a:visited
        {
            color: #034af3;
            text-decoration: none;
        }
        
        a:hover
        {
            color: #1d60ff;
            text-decoration: underline;
        }
        
        a:active
        {
            color: #034af3;
        }
        .style17
        {
            margin-bottom: 0;
            width: 95%;
            font-size: 15px;
            height: 220px;
            font-family: @楷体;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: 0;
        }
        .style19
        {
            width: 20px;
            height: 200px;
        }
        #Select1
        {
            width: 98px;
            margin-left: 0px;
        }
        #Text1
        {
            height: 15px;
            width: 96px;
            margin-left: 50px;
        }
        #Password1
        {
            width: 97px;
        }
        #Submitt
        {
            padding-bottom: 5px;
        }
        .style27
        {
            width: 213px;
            height: 372px;
        }
        .style36
        {
            height: 230px;
            width: 226px;
            background-color:white;
            vertical-align:top;
        }
        #marquee
        {
            height: 218px;
            width: 428px;
        }
        .wenbenkuang
        {
            height: 20px;
            margin-top: 5px;
            padding-bottom: 5px;
            padding-left: 20px;
            padding-top: 5px;
            color: #4f88f2;
            font-size: 18px;
        }
        .style38
        {
            height: 20px;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
        }
        #obj
        {
            width: 219px;
        }
        .style41
        {
            width: 723px;
            height: 220px;
        }
        .style42
        {
            height: 29px;
            background-image:url(images/path.jpg);
        }
        .style43
        {
            height: 160px;
        }
        .style44
        {
            height: 20px;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
            width: 310px;
        }
        .style45
        {
            height: 200px;
            width: 200px;
        }
        .path
        {
            height: 24px;
            padding-top: 10px;
            padding-left: 60px;
            font-size: 13px;
        }
        
        .style46
        {
            width: 10px;
        }
    </style>
    <%--以下为自动切换图片的样式设计--%>
    <style type="text/css">
        #play
        {
            width: 210px;
            height: 210px;
            position: relative;
            top: 0px;
            left: 0px;
            overflow: hidden;
        }
        #playimg
        {
            width: 210px;
            height: 210px;
            position: relative;
        }
        #playimg li
        {
            height: 210px;
            overflow: hidden;
        }
        #playimg img
        {
            width: 210px;
            height: 210px;
        }
        #playbtn
        {
            position: absolute;
            left: 0;
            bottom: 5px;
        }
        #playbtn li
        {
            display: inline;
            background: #eee;
            padding: 2px 2px;
            margin: 0 3px;
            cursor: pointer;
        }
        #playbtn .current
        {
            background: #bbffff;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="all" style="border: dotted 2px #00DDDD; padding-top: 8px; padding-bottom: 10px;padding-left: 6px; margin: 8px 0;">
        <form id="form1" runat="server">
        <table width="1200" style="border:0;text-align:center;" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" align="left" colspan="0" class="style27">
                    <table cellspacing="0" cellpadding="0" style="border-color: #00DDDD;border:0;text-align:center;">
                        <tr>
                            <td class="style36">
                                <div id="Div1" style="width: 221px; height: 215px; text-align:center; margin-top:0; background-color: #dcdcdc; padding-top: 5px;">
                                    <%--以下为图片定时切换的div设计--%>
                                    <div id="play">
                                        <ul id="playimg">
                                            <li>
                                                <img alt="" src="images/图片选取/第一教学楼.JPG" /></li>
                                            <li>
                                                <img alt="" src="images/图片选取/第二教学楼.JPG" /></li>
                                            <li>
                                                <img alt="" src="images/图片选取/第三教学楼.JPG" /></li>
                                            <li>
                                                <img alt="" src="images/图片选取/学术活动中心.JPG" /></li>
                                        </ul>
                                        <ul id="playbtn">
                                            <li class="current">1</li>
                                            <li>2</li>
                                            <li>3</li>
                                            <li>4</li>
                                        </ul>
                                    </div>
                                    </div>
                            </td>
                        </tr>
                        <tr style="height:18px;">
                            <td class="style42"></td>
                        </tr>
                        <tr style="height:160px;">
                            <td style="background-repeat: no-repeat; border: 0px; padding: 0 0 0 0; margin: 0 0 0 0;"
                                align="left" class="style43">
                                <div style="overflow: auto; height: 367px;">
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条10.jpg)">
                                        <a href="javascript:OpenDiv(750,350,'shitoulou.aspx')">主石头楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条10.jpg)">
                                        <a href="javascript:OpenDiv(750,350,'dongshitoulou.aspx')">东石头楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条10.jpg)">
                                        <a href="javascript:OpenDiv(750,350,'xishitoulou.aspx')">西石头楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条1.jpg)">
                                        <a href="javascript:OpenDiv(551,270,'xintushuguan.aspx')">新图书馆</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条1.jpg)">
                                        <a href="javascript:OpenDiv(551,270,'laotushuguan.aspx')">老图书馆</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条10.jpg)">
                                        <a href="javascript:OpenDiv(577,270,'xueshu.aspx')">学术中心</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条1.jpg)">
                                        <a href="Default14.aspx">大学生活动中心</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条1.jpg)">
                                        <a href="javascript:OpenDiv(780,350,'zhujiao.aspx')">第一教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条2.jpg)">
                                        <a href="javascript:OpenDiv(600,274,'dierjiaoxuelou.aspx')">第二教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条3.jpg)">
                                        <a href="javascript:OpenDiv(710,310,'disanjiaoxuelou.aspx')">第三教学楼 </a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条3.jpg)">
                                        <a href="javascript:OpenDiv(710,310,'disijiaoxuelou.aspx')">第四教学楼 </a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条5.jpg)">
                                        <a href="javascript:OpenDiv(600,270,'kejilou.aspx')">科技楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条8.jpg)">
                                        <a href="javascript:OpenDiv(582,270,'meiti.aspx')">媒体楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条9.jpg)">
                                        <a href="javascript:OpenDiv(543,270,'jichushiyan.aspx')">基础实验楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条4.jpg)">
                                        <a href="javascript:OpenDiv(600,270,'dongjie.aspx')">东阶教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条6.jpg)">
                                        <a href="javascript:OpenDiv(600,270,'xinxixueyuan.aspx')">信息学院教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条7.jpg)">
                                        <a href="javascript:OpenDiv(600,300,'zonghe.aspx')">化学工程学院教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条4.jpg)">
                                        <a href="javascript:OpenDiv(579,270,'gaoyadongli.aspx')">动电实验教学楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条5.jpg)">
                                        <a href="javascript:OpenDiv(600,270,'shubiandian.aspx')">输变电实训中心</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条6.jpg)">
                                        <a href="Default20.aspx">新校区正门保卫处</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条7.jpg)">
                                        <a href="Default21.aspx">新校区门卫办公楼</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条2.jpg)">
                                        <a href="javascript:OpenDiv(568,270,'xiaoyiyuan.aspx')">校医院</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条8.jpg)">
                                        <a href="Default22.aspx">离退处</a>
                                    </div>
                                    <div class="path" style="cursor: pointer; background-image: url(images/下拉条3.jpg)">
                                        <a href="javascript:OpenDiv(600,270,'tiyuguan.aspx')">新校区体育馆</a>
                                    </div>
                                </div>
                                <div>
                                    <img alt="" src="images/path_bottom.jpg" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style46"></td>
                <td style="background-color:white;vertical-align:top;">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <table style="border:0;text-align:center;border-color: #00DDDD; width: 669px;"cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top" class="style41" align="left">
                                                        <table class="style17" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="width:340px;vertical-align:top;background-image:url(images/标题1.jpg)" class="style44"></td>
                                                                <td style="vertical-align:top;width:20px;" class="style38"></td>
                                                                <td style="width:340px;vertical-align:top;background-image:url(images/标题2.jpg)" class="style38"></td>
                                                            </tr>
                                                            <tr style="height:200px;">
                                                                <td style="width:330px;vertical-align:top;background-image:url(images/lianjie2.jpg)" class="style45">
                                                                    <asp:DataList ID="tExperience1" runat="server" DataKeyField="ID" RepeatColumns="1"
                                                                        RepeatDirection="Horizontal" OnItemCommand="tExperience_ItemCommand1" HIDeight="192px"
                                                                        Width="310px" Height="200px" Font-Names="宋体">
                                                                        <ItemTemplate>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td style="width:20px;height:30px;">
                                                                                        <img alt="" src="images/xinwen.png" />
                                                                                    </td>
                                                                                    <td style="width:310px;height:30px;font-size: 14px; float: left">&nbsp;&nbsp;
                                                                                        <asp:LinkButton runat="server" CommandName="Experience1" ID="lbnExperience1">
                                                                        <%#DataBinder.Eval(Container.DataItem, "title").ToString().Substring(0, 10)+"..."%>
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </td>
                                                                <td style="width:20px;vertical-align:top;" class="style29">
                                                                    <img alt="" class="style19" src="images/书.jpg" />
                                                                </td>
                                                                <td style="width:330px;vertical-align:top;background-image:url(images/lianjie.jpg)" class="style45">
                                                                    <asp:DataList ID="tExperience" runat="server" DataKeyField="ID" RepeatColumns="1"
                                                                        RepeatDirection="Horizontal" OnItemCommand="tExperience_ItemCommand" HIDeight="192px"
                                                                        Width="310px" Height="200px" Font-Names="宋体">
                                                                        <ItemTemplate>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td style="width:30px;height:30px;">
                                                                                        <img alt="" src="images/xinwen.png" />
                                                                                    </td>
                                                                                    <td style="width:310px;height:30px;font-size: 14px; float: left">&nbsp;&nbsp;
                                                                                        <asp:LinkButton runat="server" CommandName="Experience" ID="lbnExperience">
                                                                        <%#DataBinder.Eval(Container.DataItem, "title").ToString().Substring(0, 15)+"..."%>
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:10px"></td>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" style="border:0;text-align:center;border-color: #00DDDD"
                                                width="290">
                                                <tr>
                                                    <td style="width:280px;height:220px;vertical-align:top;background-color:white;">
                                                        <div style="background-image: url(images/login_bg.jpg); width: 280px; height: 220px;">
                                                            <div class="style21">
                                                                <img alt="" src="images/用户登录2.jpg" style="width: 280px;" />
                                                            </div>
                                                            <div class="wenbenkuang">
                                                                身份：
                                                                <asp:Label ID="Label1" runat="server" Text="未登录"></asp:Label>
                                                            </div>
                                                            <div class="wenbenkuang">
                                                                账号：<asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                                                            </div>
                                                            <div class="wenbenkuang">
                                                                密码：<asp:TextBox ID="TextBox2" TextMode="Password" runat="server" Width="130px"></asp:TextBox>
                                                            </div>
                                                            <div class="wenbenkuang" id="Submitt" style="padding-left: 60px;">
                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" />
                                                                <span style="margin-left:50px"></span>
                                                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注销" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div style="margin-top: 10px;">
                                    <img alt="" src="images/map_title.jpg" />
                                </div>
                                <div style="border-right: 1px solid #CCCCCC; width: 969px; text-align: left;">
                                    <uc1:Map ID="Map1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <div style="margin-top: 10px;">
                                    <img src="images/link3.jpg" />
                                </div>
                                <div style="height: 30px">
                                    <img src="images/link_content.jpg" width="650" height="30" border="0" usemap="#Map" />
                                    <map name="Map" id="Map">
                                        <area shape="rect" coords="23,5,143,25" href="http://www.neepu.edu.cn/" target="_blank" />
                                        <area shape="rect" coords="171,5,303,25" href="http://zcc.neepu.edu.cn/" target="_blank" />
                                        <area shape="rect" coords="333,5,458,25" href="http://jwc.neepu.edu.cn/" target="_blank" />
                                        <area shape="rect" coords="485,5,635,25" href="http://hqjt.neepu.edu.cn/" target="_blank" />
                                    </map>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </form>
    </div>
    <%--以下为ajax刷新显示的Div设计--%>
    <div id="www_zzjs_net" style="display: none" onmouseleave="this.style.display='none'">
    </div>
</asp:Content>
