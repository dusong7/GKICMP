<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXJS-SDK.aspx.cs" Inherits="GKICMP.test.WXJS_SDK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link rel="stylesheet" href="../appcss/iconfont.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no, width=device-width" />
    <link rel="stylesheet" href="http://cache.amap.com/lbs/static/main1119.css" />
    <script src="http://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script src="http://webapi.amap.com/maps?v=1.3&key=e08c94652c7c52de8aac2664482dbfae&plugin=AMap.PolyEditor"></script>
    <script type="text/javascript" src="http://cache.amap.com/lbs/static/addToolbar.js"></script>
    <script src="http://lib.sinaapp.com/js/jquery/2.2.4/jquery-2.2.4.min.js" type="text/javascript" charset="utf-8"></script>
    <title></title>
    <style>
        .sign {
            width: 100px;
            cursor: pointer;
            border-radius: 60px;
            box-sizing: border-box;
            height: 100px;
            position: absolute;
            top: 65%;
            left: 50%;
            margin-left: -50px;
            margin-top: 20px;
            padding-top: 30px;
            text-align: center;
            font-size: 12px;
            background: #18b1ff;
        }

        .notsign {
            background: #BFBBBB;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <%--onclick="Sign()"--%>
        <div style="height:100%; background-image:url(../images/xy1.png);background-repeat:repeat">
            <div id="container" style="height: 60%"></div>
            <div id="sign" class="sign">
                <div style="font-size: 20px; color: white">立即打卡</div>
                <div id="date" style="font-size: 16px; color: #d7dee3"></div>
            </div>
        </div>
        <nav class="mui-bar mui-bar-tab">
            <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>
            <%--    <a class="mui-tab-item">
                    <span class="mui-icon iconfont icon-bj"></span>
                    <span class="mui-tab-label">班级</span>
                </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
    </form>
    <script>
        function Sign() {
            alert("签到成功");
        }
        // setInterval("Get()", 1000);
        //var map = new AMap.Map("container", {
        //    resizeEnable: true,
        //    center: [116.473188, 39.993253],//地图中心点
        //    zoom: 17 //地图显示的缩放级别
        //});
        //marker = new AMap.Marker({
        //    map: map,
        //    position: [116.473188, 39.993253]
        //})
        //marker.setLabel({
        //    offset: new AMap.Pixel(20, 20),//修改label相对于maker的位置
        //    content: "点击Marker打开高德地图"
        //});
        var map; var marker
        //map = new AMap.Map("container", {
        //    resizeEnable: true,
        //    //center:[res.longitude, res.latitude],//地图中心点
        //    zoom: 17 //地图显示的缩放级别
        //});
        var _config = {
            agentId: 'wxe0b787e4eaa1102c',
            timeStamp: '<%=timestamp%>',
            nonce: 'GKDZ',
            signature: '<%=signature%>',
            jsApiTicket: '<%=jsApiTicket%>'
            //jsApiTicket: 'kgt8ON7yVITDhtdwci0qeQyva_KrUiphj1XF4Pg9IFhthD4quHTIeBAISZ4vYA1eC4q-j-9XqaOrxF_Bu7iUwQ'
        };
        wx.config({
            beta: true,// 必须这么写，否则在微信插件有些jsapi会有问题
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: _config.agentId, // 必填，企业微信的corpID
            timestamp: _config.timeStamp, // 必填，生成签名的时间戳
            nonceStr: _config.nonce, // 必填，生成签名的随机串
            signature: _config.signature,// 必填，签名，见[附录1](#11974)
            jsApiList: ['checkJsApi', 'openLocation', 'getLocation'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function () {
            wx.getLocation({
                type: 'gcj02', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
                success: function (res) {
                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    //var speed = res.speed; // 速度，以米/每秒计
                    //var accuracy = res.accuracy; // 位置精度
                    //alert(res.latitude + ',' + res.longitude)
                    //唤起地图
                    map = new AMap.Map("container", {
                        resizeEnable: true,
                        center: [res.longitude, res.latitude],//地图中心点
                        zoom: 17 //地图显示的缩放级别
                    });

                    //显示多边形区域
                    var polygonArr = new Array();//多边形覆盖物节点坐标数组
                    $.ajax({
                        url: "../ashx/MapService.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=Geofence",
                        dataType: "json",
                        //timeout: 1000,
                        async: false,
                        success: function (data) {
                            for (var d in data.lactions) {
                                polygonArr.push([data.lactions[d].lon, data.lactions[d].lat]);
                            }
                        }
                    })
                    var polygon = new AMap.Polygon({
                        path: polygonArr,//设置多边形边界路径
                        strokeColor: "#0000ff",
                        strokeOpacity: 1,
                        strokeWeight: 3,
                        fillColor: "#f5deb3",
                        fillOpacity: 0.35
                    });
                    polygon.setMap(map);

                    //当前位置
                    marker = new AMap.Marker({
                        map: map,
                        position: [res.longitude, res.latitude],

                    })
                    $.ajax({
                        url: "../ashx/MapService.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=Range&locations=" + (res.longitude + "," + res.latitude),
                        dataType: "json",
                        //timeout: 1000,
                        async: false,
                        success: function (data) {
                            if (data.data.fencing_event_list.length == 0) {
                                $("#sign").addClass("notsign");
                                marker.setLabel({
                                    offset: new AMap.Pixel(20, 20),//修改label相对于maker的位置
                                    content: "还有" + data.data.nearest_fence_distance + "米"
                                });
                            }
                            else {
                                $("#sign").bind('click', Sign);//为div绑定RecommandProduct 函数
                            }
                        }
                    }); Get();
                    //var a= setTimeout("Get()",1000);
                }
            });

            // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
        });
        wx.error(function (res) {
            alert("456");
            // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
        });

        function Get() {
            //setTimeout("Get()", 1000);
            wx.getLocation({
                type: 'gcj02', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
                success: function (res) {
                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    //var speed = res.speed; // 速度，以米/每秒计
                    //var accuracy = res.accuracy; // 位置精度
                    //alert(res.latitude + ',' + res.longitude)
                    map.remove(marker);
                    marker = new AMap.Marker({
                        map: map,
                        position: [res.longitude, res.latitude],

                    })

                    $.ajax({
                        url: "../ashx/MapService.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=Range&locations=" + (res.longitude + "," + res.latitude),
                        dataType: "json",
                        //timeout: 1000,
                        async: false,
                        success: function (data) {
                            if (data.data.fencing_event_list.length == 0) {
                                $("#check").attr("disabled", true);
                                marker.setLabel({
                                    offset: new AMap.Pixel(20, 20),//修改label相对于maker的位置
                                    content: "还有" + data.data.nearest_fence_distance + "米"
                                });
                            }
                            else {
                                $("#check").attr("disabled", false);
                            }
                        }
                    })
                }
            });
        }
        $(function () {
            setInterval("GetTime()", 1000);
        });
        //获取时间并设置格式
        function GetTime() {

            now = new Date();
            hour = now.getHours();
            min = now.getMinutes();
            sec = now.getSeconds();
            if (hour < 10) {
                hour = "0" + hour;
            }
            if (min < 10) {
                min = "0" + min;
            }
            if (sec < 10) {
                sec = "0" + sec;
            }
            $("#date").html(
               hour + ":" + min + ":" + sec
                );
        }

    </script>
</body>
</html>
