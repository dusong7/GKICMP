<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineCourseManage.aspx.cs" Inherits="GKICMP.app.OnlineCourseManage" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">在线选课</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="OnlineCourseManage.aspx" class="mui-control-item mui-active">在线选课</a>
                    <a href="OnlineCourseManage.aspx" class="mui-control-item">我的选课</a>
                    
                </div>
            </div>
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
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=OnlineCourse&pageindex=1&pagesize=10",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        for (var j in data.data) {
                            var intem = "";
                            intem += "<li class='mui-table-view-cell'>";
                            intem += "<a href='MyOnlineCourse.aspx?id=" + data.data[j].EleID + "'> ";
                            intem += "<div class='mui-table'>";
                            intem += "<div class='mui-col-xs-12'>";
                            intem += "<h4 class='mui-ellipsis'>";
                            intem += "<span style='margin-left: -6px;'>" + " &nbsp;&nbsp;任务名称：" + data.data[j].ElectiverName + "</span>";
                            intem += "</h4>";
                            intem += "</div>";
                            intem += "<div class='mui-col-xs-12'>";
                            intem += "<h5 class='mui-ellipsis'>";
                            //intem += "选课时间：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "&nbsp;&nbsp;&nbsp;&nbsp;状态：";
                            //    //+ data.data[j].EState;
                            //intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:blue'>预选阶段") ;
                            //   //"<span style='color:red'>未处理</span>" : data.data[j].State == "1" ? "<span style='color:blue'>批转中</span>" : data.data[j].State == "2" ? "已处理" : data.data[j].State == "5" ? "<span style='color:#48bd81'>已阅</span>" : "")
                            //intem += "</h5>";

                            intem += "选课时间：" + data.data[j].EBegin + "--" + data.data[j].EEnd;
                            intem += "</h5>";
                            intem += "<h5 class='mui-ellipsis'>";
                            intem += "状态：";
                            intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:blue'>预选阶段");
                            intem += "</h5>";

                            intem += "</div>";
                            intem += "</div>";
                            intem += "</a>";
                            if (data.data[j].EState == 2 || data.data[j].EState == 3) {
                                intem += " <div class='list-btn' ><a href='MyOnlineCourse.aspx?id=" + data.data[j].EleID + "'  class='btn-pz'>选课</a> </div>";
                            }
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
                    //alert(i);
                    var jsondata = "";
                    $.ajax({
                        url: "../ashx/GetMainDate.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=OnlineCourse&pagesize=10&pageindex=" + i,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.result == 'true') {
                                for (var j in data.data) {
                                    var intem = "";
                                    intem += "<li class='mui-table-view-cell'>";
                                    intem += "<a href='MyOnlineCourse.aspx?id=" + data.data[j].EleID + "'> ";
                                    intem += "<div class='mui-table'>";
                                    intem += "<div class='mui-col-xs-12'>";
                                    intem += "<h4 class='mui-ellipsis'>";
                                    intem += "<span style='margin-left: -6px;'>" + " &nbsp;&nbsp;任务名称" + data.data[j].ElectiverName + "</span>";
                                    intem += "</h4>";
                                    intem += "</div>";
                                    intem += "<div class='mui-col-xs-12'>";
                                    intem += "<h5 class='mui-ellipsis'>";
                                    //intem += "选课时间：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "&nbsp;&nbsp;&nbsp;&nbsp;状态：";
                                    //    //+ data.data[j].EState;
                                    //intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:blue'>预选阶段") ;
                                    //   //"<span style='color:red'>未处理</span>" : data.data[j].State == "1" ? "<span style='color:blue'>批转中</span>" : data.data[j].State == "2" ? "已处理" : data.data[j].State == "5" ? "<span style='color:#48bd81'>已阅</span>" : "")
                                    //intem += "</h5>";

                                    intem += "选课时间：" + data.data[j].EBegin + "--" + data.data[j].EEnd;
                                    intem += "</h5>";
                                    intem += "<h5 class='mui-ellipsis'>";
                                    intem += "状态：";
                                    intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:blue'>预选阶段");
                                    intem += "</h5>";
                                    intem += "</div>";
                                    intem += "</div>";
                                    intem += "</a>";
                                    if (data.data[j].EState == 2 || data.data[j].EState == 3) {
                                        intem += " <div class='list-btn' ><a href='MyOnlineCourse.aspx?id=" + data.data[j].EleID + "'  class='btn-pz'>选课</a> </div>";
                                    }
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
                    //mui('#offCanvasContentScroll').pullRefresh().endPullupToRefresh((++count > 100)); //参数为true代表没有更多数据了。
                }, 1500);
            }

        </script>
    </form>
</body>
</html>

