<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonSubstituteManage.aspx.cs" Inherits="GKICMP.app.PersonSubstituteManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <title>我的代课</title>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 80px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
           <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">我的代课</h1>
        </header>
        <div class="mui-content  mui-scroll-wrapper" id="offCanvasContentScroll">
            <div class="mui-scroll">
                <ul class="mui-table-view" id="pullrefresh">
                </ul>
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
            <%--      <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item  mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>

        <script type="text/javascript" charset="utf-8">
            mui('body').on('tap', 'a', function () {
                document.location.href = this.href;
            });
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
            /**
             * 下拉刷新具体业务实现
             */
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=PersonSubstitute&pageindex=1&pagesize=10",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        for (var j in data.data) {
                            var intem = "";
                            intem += "<li class='mui-table-view-cell mui-media'>";
                            intem += "<a href='PersonSubstituteDetail.aspx?id=" + data.data[j].AbID + "'> ";
                            intem += "<div class='mui-media-body'>"
                            intem += "<h4>";
                            intem += "<span style='margin-left: -8px;'>" + "【" + data.data[j].SubCoruseName + "】</span>";
                            intem += "</h4>";
                            intem += "<h5>";
                            intem += "代课班级：" + data.data[j].OtherName + "&nbsp;&nbsp;&nbsp;&nbsp节次：" + data.data[j].SubNum;
                            intem += "</h5>";
                            intem += "<h5>";
                            intem += "<span style='margin-left:0px;'>" + "代课日期：" + data.data[j].SubDate + "</span>" + "&nbsp;&nbsp;&nbsp;&nbsp<span style='font-weight:lighter;font-size:12px;color:" + (data.data[j].SubState == "0" ? "#febe17" : data.data[j].SubState == "1" ? "#47ae6f" : data.data[j].SubState == "2" ? "red" : "gray") + "'>" + data.data[j].SubStateName + "</span>";
                            intem += "</h5>";
                            intem += "</div>";
                            intem += "</a>";
                            if (data.data[j].SubState == 0) {
                                intem += " <div class='list-btn' ><a href='PersonSubstituteEdit.aspx?id=" + data.data[j].AbID + "'  class='btn-pz'>是否同意</a></div>";
                            }
                            intem += "</li>";
                            $("#pullrefresh").append(intem);
                        }
                    }
                    else {
                        $("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
                    }
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
                        data: "method=PersonSubstitute&pagesize=10&pageindex=" + i,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.result == 'true') {
                                for (var j in data.data) {
                                    var intem = "";
                                    intem += "<li class='mui-table-view-cell mui-media'>";
                                    intem += "<a href='PersonSubstituteDetail.aspx?id=" + data.data[j].AbID + "'> ";
                                    intem += "<div class='mui-media-body'>"
                                    intem += "<h4>";
                                    intem += "<span style='margin-left: -8px;'>" + "【" + data.data[j].SubCoruseName + "】</span>";
                                    intem += "</h4>";
                                    intem += "<h5>";
                                    intem += "代课班级：" + data.data[j].OtherName + "&nbsp;&nbsp;&nbsp;&nbsp节次：" + data.data[j].SubNum;
                                    intem += "</h5>";
                                    intem += "<h5>";
                                    intem += "<span style='margin-left:0px;'>" + "代课日期：" + data.data[j].SubDate + "</span>" + "&nbsp;&nbsp;&nbsp;&nbsp<span style='font-weight:lighter;font-size:12px;color:" + (data.data[j].SubState == "0" ? "#febe17" : data.data[j].SubState == "1" ? "#47ae6f" : data.data[j].SubState == "2" ? "red" : "gray") + "'>" + data.data[j].SubStateName + "</span>";
                                    intem += "</h5>";
                                    intem += "</div>";
                                    intem += "</a>";
                                    if (data.data[j].SubState == 0) {
                                        intem += " <div class='list-btn' ><a href='PersonSubstituteEdit.aspx?id=" + data.data[j].AbID + "'  class='btn-pz'>是否同意</a></div>";
                                    }
                                    intem += "</li>";
                                    $("#pullrefresh").append(intem);
                                }
                                i = i + 1;
                                jsondata = data.data;
                            }
                            //else {
                            //    $("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
                            //}

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
