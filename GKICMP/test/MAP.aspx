<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MAP.aspx.cs" Inherits="GKICMP.test.MAP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://webapi.amap.com/maps?v=1.3&key=e08c94652c7c52de8aac2664482dbfae&plugin=AMap.PolyEditor"></script>
    <script src="http://lib.sinaapp.com/js/jquery/2.2.4/jquery-2.2.4.min.js" type="text/javascript" charset="utf-8"></script>

        <link rel="stylesheet" href="http://cache.amap.com/lbs/static/main1119.css"/>
    <script src="http://webapi.amap.com/maps?v=1.4.3&key=e08c94652c7c52de8aac2664482dbfae&plugin=AMap.PolyEditor,AMap.CircleEditor"></script>
    <script type="text/javascript" src="http://cache.amap.com/lbs/static/addToolbar.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div id="container"></div>
        <div class="button-group">
            <input id="btn_edit" class="button" type="button" value="修改" onclick="edit()"  />
            <input id="btn_sumbit" class="button" type="button" value="完成" onclick="sumbit()" />
            <input id="btn_delete" class="button" type="button" value="删除" onclick="del()" />
        </div>
    </form>
</body>
    <script>
        var editor = {};
       
        var polygonArr = new Array();//多边形覆盖物节点坐标数组
        //polygonArr.push([116.403322, 39.920255]);
        //polygonArr.push([116.410703, 39.897555]);
        //polygonArr.push([116.402292, 39.892353]);
        //polygonArr.push([116.389846, 39.891365]);
        $.ajax({
            url: "../ashx/MapService.ashx",
            cache: false,
            type: "GET",
            data: "method=Geofence",
            dataType: "json",
            //timeout: 1000,
            async: false,
            success: function (data) {
                for (var d in data.data) {
                    polygonArr.push([data.data[d].lon, data.data[d].lat]);
                }
            }
        })
        var editorTool, map = new AMap.Map("container", {
            resizeEnable: true,
            center: polygonArr[0],//地图中心点
            zoom: 17 //地图显示的缩放级别
        });
        var polygon = new AMap.Polygon({
            path: polygonArr,//设置多边形边界路径
            strokeColor: "#0000ff",
            strokeOpacity: 1,
            strokeWeight: 3,
            fillColor: "#f5deb3",
            fillOpacity: 0.35
        });
        polygon.setMap(map);
        editor._polygonEditor = new AMap.PolyEditor(map,polygon);

        function edit() {
            editor._polygonEditor.open();
        }
        function sumbit() {
            editor._polygonEditor.close();
                
        }
        function polygonEnd(res) {
            resPolygon.push(res.target);
            alert(resPolygon[resNum].contains([116.386328, 39.913818]));
            appendHideHtml(resNum, res.target.getPath());

            resNum++;
            init();
            //resPolygon.push(res.target);
            //var strify = JSON.stringify(res.target.getPath());
        }
        function del() {

        }

</script>
</html>
