<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadCad.aspx.cs" Inherits="ReadCad" %>

<%@ Register Assembly="CADControl" Namespace="WebCAD" TagPrefix="sg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>

    <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/smoothness/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" href="./Content/buttons.css"/>
    <link rel="stylesheet" type="text/css" href="./Content/site.css"/>

    <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
    <%--<script src="http://code.jquery.com/jquery-1.10.2.js"></script>--%>
    <%--<script src="http://code.jquery.com/jquery-2.0.3.js"></script>--%>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#buttonSet0").buttonset();
            $("#buttonSet1").buttonset();
            $("#buttonSet2").buttonset();
            $("#buttonSet3").buttonset();

            var iconSet = [{ icon: "icon_save", text: false }, { icon: "icon_print", text: false }, { icon: "icon_zoomin", text: false }, { icon: "icon_zoomout", text: false }, { icon: "icon_orbit", text: false }, { icon: "icon_bw", text: false }, { icon: "icon_extents", text: false }, { icon: "icon_layers", text: false }, { icon: "icon_select", text: false }, { icon: "icon_line", text: false }, { icon: "icon_poly", text: false }, { icon: "icon_area", text: false }];
            $("button.nav").each(function (i) {
                if ((i < iconSet.length)) {
                    $(this).button({
                        text: iconSet[i].text,
                        icons: { primary: iconSet[i].icon }
                    });
                } else {
                    $(this).button();
                }
            });
            $("#dialogLayers").dialog({ autoOpen: false });
            $("#dialogMeasuring").dialog({ autoOpen: false, close: function (ev, ui) { if (!noClosedMeas) measStart(this, false); } });
            $("#dialogPrint").dialog({ autoOpen: false, width: 600 });
            $("#dialogEntInfo").dialog({ autoOpen: false, width: 450 });

            changeDialogVisibility = function (dlg) {
                if ($(dlg).dialog("isOpen")) {
                    $(dlg).dialog("close");
                } else {
                    $(dlg).dialog("open");
                }
            }
        });
    </script>

    <style type="text/css">
        @media screen {
            .nonPrintableArea {
                display: block;
            }

            .printableArea {
                display: none;
            }
        }

        @media print {
            body {
                margin: 0;
                padding: 0;
            }

            .nonPrintableArea {
                display: none;
            }

            .printableArea {
                display: block;
            }
        }
    </style>

</head>
<body>
    <div class="printableArea">
        <img id="printImage" onload="window.print()"/>
    </div>
    <div class="nonPrintableArea">
        <div class="nav left makesmaller">
            <span id="buttonSet0">
                <button class="nav" onclick="saveAsDXF();">另存为DXF</button>
                <button class="nav" onclick="popupPrint();">打印</button>
            </span>
            <span id="buttonSet1">
                <button class="nav" onclick="CADControl1.cad.face.zoomIn();">放大</button>
                <button class="nav" onclick="CADControl1.cad.face.zoomOut();">缩小</button>
                <button class="nav" onclick="CADControl1.cad.orbit.enabled = !CADControl1.cad.orbit.enabled;">3D 轨道</button>
            </span>
            <span id="buttonSet2">
                <button class="nav" onclick="CADControl1.cad.face.changeBackgroundColor(this);">切换背景</button>
                <button class="nav" onclick="CADControl1.cad.face.resetView();">全屏</button>
                <button class="nav" onclick="CADControl1.cad.face.updateCBL('checkBoxlist'); changeDialogVisibility('#dialogLayers');">图层</button>
                <button class="nav" onclick="CADControl1.cad.setInfoEnabled();">详细信息</button>
            </span>
            <span id="buttonSet3">
                <button class="nav" onclick="measStart(this, 1)">直线距离</button>
                <button class="nav" onclick="measStart(this, 2)">折线距离</button>
                <button class="nav" onclick="measStart(this, 3)">面积</button>
            </span>
            <select class="nav" id="dropDownlist">
            </select>
            <select class="nav" id="viewsDownlist">
            </select>
            <select class="nav" id="displayDownlist">
            </select>
        </div>
        <form id="Form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:FileUpload ID="FileUpload1" runat="server" Width="300" onchange="Button1.click()"/>
            <asp:Button ID="Button1" runat="server" Text="查看本机图片" OnClick="Button1_Click" style="display: none"/>
            <asp:Button ID="Button2" runat="server" Text="查看历史图片" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="加载测试图片" OnClick="Button3_Click" />
           <%-- <asp:Label runat="server" id="MergeLabel" text="Select merge file" />--%>
            <%--<input type="file" id="MergeFile" onchange="CADControl1.cad.merge($('#MergeFile')[0].files[0], 'name_' + Math.random(), {x:5, y:5}, {x:1,y:1}, 0)" />--%>
            <br />
            <br />
            <sg:CADControl runat="server" ID="CADControl1" Service="./draw" Height="100%" Width="100%" DefaultSHXFont="simplex.shx" SHXSearchPaths="SHX\" UseSHXFonts="True" SHXDefaultPath="SHX\" OnEntityClickEvent="CADControl1_EntityClickEvent"></sg:CADControl>
        </form>
        <div id="dialogLayers" class="makesmaller" title="图层">
            <form id="checkBoxlist" style="max-height: 500px">
            </form>
        </div>
        <div id="dialogMeasuring" class="makesmaller" title="详细信息">
            <form id="measuringList" style="max-height: 500px">
                <label id="lbDistanse" for="edDistance">距离</label><input id="edDistance" type="text" />
                <br />
                <label id="lbDeltaX" for="edDeltaX">X 坐标</label><input id="edDeltaX" type="text" />
                <br />
                <label id="lbDeltaY" for="edDeltaY">Y 坐标</label><input id="edDeltaY" type="text" />
                <br />
                <label id="lbPerimeter" for="edPerimeter">周长</label><input id="edPerimeter" type="text" />
                <br />
                <label id="lbArea" for="edArea">面积</label><input id="edArea" type="text" />
                <br />
                <label id="lbAngle" for="edAngle">角度</label><input id="edAngle" type="text" />
            </form>
        </div>
        <div id="dialogEntInfo" class="makesmaller" title="详细信息">
        </div>
    </div>
    <script type="text/javascript">
        CADControl1.cad.face.updateCBL("checkBoxlist");
        CADControl1.cad.face.updateDDL("dropDownlist");
        //CADControl1.cad.isShowSnap = true;

        var viewsNames = ["初始视图", "-", "俯视图", "仰视图", "左视图", "右视图", "前视图", "后视图", "-", "西南视角", "东南视角", "东北视角", "西北视角"];
        CADControl1.cad.face.updateVDL("viewsDownlist", viewsNames);
        var displayModes = ["2D 线框", "-", "3D 线框", "3D 隐藏线", "3D平滑阴影", "3D平面阴影"];
        CADControl1.cad.face.updateVDL("displayDownlist", displayModes, 100);

        cad.get(CADControl1.cad, "mode?" + cad.makeParams({ id: CADControl1.cad.guid }), undefined, function (msg) {
            if (msg > 0)
                displayDownlist.selectedIndex = msg;
        }, null, true);

        var saveAsDXF = function () {
            location.href = cad.service + "/saveasdxf?id=" + CADControl1.cad.guid;
        }

        var measStart = function (e, t) {
            var m = CADControl1.cad.measuring;
            m.start(m.mode != t ? t : 0);
        }

        CADControl1.cad.onselect = function (msg) {
            dialogEntInfo.innerHTML = "";
            var innerHTML = "<table style=\"width:100%\">";
            var isOpen = false;

            if (msg) {
                //var xml = msg.xml;
                //delete  msg.xml;
                var isOpen = false;

                for (var i = 0; i < msg.length; i++) {
                    innerHTML += "<tr><td><b>" + msg[i].Key + "</b></td><td>" + msg[i].Value + "</td></tr>";
                    isOpen = true;
                }
                dialogEntInfo.innerHTML = innerHTML + "</table>";

                if (isOpen)
                    $(dialogEntInfo).dialog("open");
            }

            if (!isOpen)
                $(dialogEntInfo).dialog("close");
        }

        CADControl1.cad.measuring.onmeasuring = function (e) {
            if (confirm('确定执行此操作?')) {
                return true;
            }
            return false;
        }

        var makePopupWindowParams = function (w, h) {
            var params = [];
            var top = document.documentElement.clientTop + (document.documentElement.clientHeight - h) / 2;
            var left = document.documentElement.clientLeft + (document.documentElement.clientWidth - w) / 2;

            params.push("top=" + top);
            params.push("left=" + left);
            params.push("height=" + h);
            params.push("width=" + w);
            return params.join(",");
        }

        var showMeasuring = function (dist, area, perimeter, angle, deltaX, deltaY, isShow) {
            var dlg = '#dialogMeasuring';
            var isOpen = false;
            noClosedMeas = isShow;

            if (cad.utils.browser.msie) {
                edDistance = document.getElementById("edDistance");
                edArea = document.getElementById("edArea");
                edPerimeter = document.getElementById("edPerimeter");
                edAngle = document.getElementById("edAngle");
                edDeltaX = document.getElementById("edDeltaX");
                edDeltaY = document.getElementById("edDeltaY");
            }

            if (dist) {
                edDistance.value = dist.toFixed(2);
                edDistance.style.display = "inline";
                isOpen = true;
            } else {
                edDistance.style.display = "none";

            }

            if (deltaX) {
                edDeltaX.value = deltaX.toFixed(2);
                edDeltaX.style.display = "inline";
                isOpen = true;
            } else {
                edDeltaX.style.display = "none";
            }

            if (deltaY) {
                edDeltaY.value = deltaY.toFixed(2);
                edDeltaY.style.display = "inline";
                isOpen = true;
            } else {
                edDeltaY.style.display = "none";
            }

            if (area) {
                edArea.value = area.toFixed(2);
                edArea.style.display = "inline";
                isOpen = true;
            } else {
                edArea.style.display = "none";
            }

            if (perimeter) {
                edPerimeter.value = perimeter.toFixed(2);
                edPerimeter.style.display = "inline";
                isOpen = true;
            } else {
                edPerimeter.style.display = "none";
            }

            if (angle) {
                edAngle.value = angle.toFixed(2);
                edAngle.style.display = "inline";
                isOpen = true;
            } else {
                edAngle.style.display = "none";
            }

            if (!isShow)
                isOpen = false;
            else if (isShow && CADControl1.cad.measuring.mode == 1)
                isOpen = true;

            if (isOpen) {
                if (!($(dlg).dialog("isOpen"))) {
                    $(dlg).dialog("open");
                    //$(dlg).dialog('option', 'position', [x,y]);
                }
            } else {
                $(dlg).dialog("close");
            }

            noClosedMeas = false;
        }

        CADControl1.cad.measuring.onShowMeasuring = showMeasuring;

        var makePopupWindowParams = function (w, h) {
            var params = [];
            var x = 0, y = 0;

            if (cad.utils.browser.msie) {
                x = window.screenLeft;
                y = window.screenTop;
            } else {
                x = window.screenX;
                y = window.screenY;
            }

            var top = y + (document.documentElement.clientHeight - h) / 2;
            var left = x + (document.documentElement.clientWidth - w) / 2;

            params.push("top=" + top);
            params.push("left=" + left);
            params.push("height=" + h);
            params.push("width=" + w);
            return params.join(",");
        }

        var getCadRefernce = function () {
            return CADControl1.cad;
        }

        var popupPrint = function () {
            if (CADControl1.cad.isPrint()) {
                CADControl1.cad.cancel();
            }
            else {
                var params = makePopupWindowParams(500, 300);
                var win = window.open('<%=CADControl1.GetForm(CADControl.DialogForm.Print, "eng")%>', '_blank', params);

                $(win.document).ready(function () {
                    win.cad = CADControl1.cad;
                });
            }
        }

    </script>
</body>
</html>

