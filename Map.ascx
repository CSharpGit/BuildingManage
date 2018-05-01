<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Map.ascx.cs" Inherits="Map" %>
<div id="container" style="height: 343px; width: 968px"></div>  
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>  
  <script type="text/javascript">
      var map = new BMap.Map("container");          // 创建地图实例  
     // var map = new BMap.Map("container", { mapType: BMAP_HYBRID_MAP });
      //通过经纬度坐标来初始化地图
      var point = new BMap.Point(126.51194, 43.830263);  // 创建点坐标  
      map.centerAndZoom(point, 16);                 // 初始化地图，设置中心点坐标和地图级别  
      //通过城市名称来初始化地图
      var marker = new BMap.Marker(point);        // 创建标注  
      map.addOverlay(marker);
      //map.enableScrollWheelZoom();  // 开启鼠标滚轮缩放  
      map.enableKeyboard();         // 开启键盘控制  
      map.enableContinuousZoom();   // 开启连续缩放效果  
      map.enableInertialDragging(); // 开启惯性拖拽效果 

      map.addControl(new BMap.NavigationControl()); //添加标准地图控件(左上角的放大缩小左右拖拽控件)
      map.addControl(new BMap.ScaleControl());      //添加比例尺控件(左下角显示的比例尺控件)
      map.addControl(new BMap.OverviewMapControl()); // 缩略图控件
      map.addControl(new BMap.MapTypeControl());     //// 仅当设置城市信息时，MapTypeControl的切换功能才能可用map.setCurrentCity("北京");  
      map.setCurrentCity("吉林省");

      //添加自定义控件

      // 定义一个控件类，即function  
      function ZoomControl() {
          // 设置默认停靠位置和偏移量  
          this.defaultAnchor = BMAP_ANCHOR_TOP_LEFT;
          this.defaultOffset = new BMap.Size(50, 10);
      }

      // 通过JavaScript的prototype属性继承于BMap.Control  
      ZoomControl.prototype = new BMap.Control();

      // 自定义控件必须实现initialize方法，并且将控件的DOM元素返回  
      // 在本方法中创建个div元素作为控件的容器，并将其添加到地图容器中  
      ZoomControl.prototype.initialize = function (map) {
          // 创建一个DOM元素  
          var div = document.createElement("div");
          // 添加文字说明  
          div.appendChild(document.createTextNode("东北电力大学"));
          // 设置样式  
          div.style.cursor = "pointer";
          div.style.border = "1px solid gray";
          div.style.backgroundColor = "white";
          // 绑定事件，点击一次放大两级  
          div.onclick = function (e) {
              alert("东北电力大学");
          }
          // 添加DOM元素到地图中  
          map.getContainer().appendChild(div);
          // 将DOM元素返回  
          return div;
      }
      // 创建控件实例  
      var myZoomCtrl = new ZoomControl();
      // 添加到地图当中  
      map.addControl(myZoomCtrl);
      //添加信息窗口
      var opts = {
          width: 200,     // 信息窗口宽度  
          height: 70,     // 信息窗口高度  
          title: "东北电力大学"  // 信息窗口标题  
      }
      var infoWindow = new BMap.InfoWindow("您好，欢迎来到东北电力大学", opts);  // 创建信息窗口对象  
      map.openInfoWindow(infoWindow, map.getCenter());      // 打开信息窗口 
</script>  