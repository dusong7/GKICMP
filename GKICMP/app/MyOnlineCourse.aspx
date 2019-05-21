<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOnlineCourse.aspx.cs" Inherits="GKICMP.app.MyOnlineCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>在线选课</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 0px;
        }
         .sl {
            margin-right: 10px;
            padding: 5px 10px;
            border-radius: 15px;
            display: inline-block;
            border: 1px solid #29a5e8;
            color: #222222;
            font-size: 12px;
            cursor:pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">在线选课</h1>
        </header>
        <div class="mui-content">
           <%-- <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="OnlineCourseManage.aspx" class="mui-control-item ">在线选课</a>
                    <a href="OnlineCourseManage.aspx" class="mui-control-item mui-active">我的选课</a>
                </div>
            </div>--%>
            <div class=" mui-scroll-wrapper" id="offCanvasContentScroll" style="margin-top: 100px; margin-bottom: 50px">
                <div class="mui-scroll">
                    <ul class="mui-table-view mui-table-view-striped mui-table-view-condensed" id="pullrefresh">
                    </ul>
                </div>
            </div>
        </div>
        <nav class="mui-bar mui-bar-tab">
            <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a href="UserInfo.aspx" class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>

            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        
        <script src="/js/mui.min.js"></script>
        <script type="text/javascript" charset="utf-8">
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });

            mui("body").on("tap", ".list-btn span", function () {
                show(this);
            });
        </script>
        <script>
            function getUrlParam(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
                var r = window.location.search.substr(1).match(reg);  //匹配目标参数
                if (r != null) return unescape(r[2]); return null; //返回参数值
            }
            mui.init({
                pullRefresh: {
                    container: '#offCanvasContentScroll',
                    down: {
                        contentrefresh: '正在加载...',
                        callback: pulldownRefresh
                    },
                    up: {
                        contentrefresh: '正在加载...',
                        callback: pullupRefresh
                    }
                }
            });

            var eleid = getUrlParam("id");
            //alert(eleid);

            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=CourseOnline&pageindex=1&pagesize=10&EleID=" + eleid,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        for (var j in data.data) {
                            var intem = "";
                            intem += "<li class='mui-table-view-cell'>";
                            intem += "<a href='MyOnlineCourseDetail.aspx?id=" + data.data[j].ECID + "'> ";
                            intem += "<div class='mui-table'>";
                            intem += "<div class='mui-col-xs-12'>";
                            intem += "<h4 class='mui-ellipsis'>";
                            intem += "<span style='margin-left: -6px;'>" + " &nbsp;&nbsp;课程名称：" + data.data[j].CourseName + "</span>";
                            intem += "</h4>";
                            intem += "</div>";
                            intem += "<div class='mui-col-xs-12'>";
                            intem += "<h5 class='mui-ellipsis'>";
                            intem += "人数：" + data.data[j].DY + "/" + data.data[j].MaxCount ;
                            intem += "</h5>";
                            intem += "</div>";
                            intem += "</div>";
                            intem += "</a>";
                            intem += "<div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius:15px;' id='" + data.data[j].ECID + "'class='sl'>选课</span></div>";
                            //intem += "<div class='list-btn' ><a href='MyOnlineCourse.aspx?id=" + data.data[j].ECID + "'  class='btn-pz'>选课</a> </div>";
                            intem += "</li>";
                            $("#pullrefresh").append(intem);
                        }
                    } else {
                        $("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
                    }
                },
                error: function () {
                    alert("暂无查询到数据！");
                }
            });


            var i = 2;
            function pulldownRefresh() {
                setTimeout(function () {
                    window.location.reload();
                }, 1500);
            };
            /**
             * 上拉加载具体业务实现
             */
            function pullupRefresh() {
                setTimeout(function () {
                    var jsondata = "";
                    $.ajax({
                        url: "../ashx/GetMainDate.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=CourseOnline&pagesize=10&pageindex=" + i + "&EleID=" + eleid,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.result == 'true') {
                                for (var j in data.data) {
                                    var intem = "";
                                    intem += "<li class='mui-table-view-cell'>";
                                    intem += "<a href='MyOnlineCourseDetail.aspx?id=" + data.data[j].ECID + "'> ";
                                    intem += "<div class='mui-table'>";
                                    intem += "<div class='mui-col-xs-12'>";
                                    intem += "<h4 class='mui-ellipsis'>";
                                    intem += "<span style='margin-left: -6px;'>" + " &nbsp;&nbsp;课程名称：" + data.data[j].CourseName + "</span>";
                                    intem += "</h4>";
                                    intem += "</div>";
                                    intem += "<div class='mui-col-xs-12'>";
                                    intem += "<h5 class='mui-ellipsis'>";
                                    intem += "人数：" + data.data[j].DY + "/" + data.data[j].MaxCount;
                                    intem += "</h5>";
                                    intem += "</div>";
                                    intem += "</div>";
                                    intem += "</a>";
                                    intem += "<div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius:15px;' id='" + data.data[j].ECID + "'class='sl'>选课</span></div>";
                                    //intem += "<div class='list-btn' ><a href='MyOnlineCourse.aspx?id=" + data.data[j].ECID + "'  class='btn-pz'>选课</a> </div>";
                                    intem += "</li>";
                                    $("#pullrefresh").append(intem);
                                }
                            }
                        },
                        error: function () {
                            alert("暂无查询到数据");
                        }
                    });

                    if (jsondata.length == 0) {
                        mui('#offCanvasContentScroll').pullRefresh().endPullupToRefresh(true);
                    }
                    else {
                        mui('#offCanvasContentScroll').pullRefresh().endPullupToRefresh(false);
                    }
                }, 1500);
            }

        </script>
    </form>
</body>
</html>

<script>
    function show(e) {
        var arid = $(e).attr("id")
        var state = $(e).attr("state");
        if (arid != "") {
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=LJWC&arid=" + arid + "&state=" + state,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result = 'true') {
                        alert("报修完成成功");
                        window.location.reload();
                    }
                    else {
                        alert("报修完成失败");
                    }
                }
            });
        }
    }
</script>
