<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonRewardManage.aspx.cs" Inherits="GKICMP.app.PersonRewardManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>获奖管理</title>
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
            <h1 class="mui-title">获奖管理</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="PersonRewardEdit.aspx" class="mui-control-item">获奖添加</a>
                    <a class="mui-control-item  mui-active" href="PersonRewardManage.aspx">我的获奖</a>
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

        <script type="text/javascript" charset="utf-8">
            mui('body').on('tap', 'a', function () {
                document.location.href = this.href;
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
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=TeaReward&pageindex=1&pagesize=10",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        for (var j in data.data) {
                            var intem = "";
                            intem += " <li class='mui-table-view-cell  mui-media'><a href='PersonRewardDetail.aspx?id=" + data.data[j].TPID + "'><div class='mui-media-body'><h4> "
                                     + data.data[j].RewardName + "</h4>" + "<h5>获奖年月：" + data.data[j].PubDate + "</h5>" + "<h5>获奖类别：" + data.data[j].RewardTypeName + "</h5>"
                                     + "<h5>" + "奖励级别：" + data.data[j].RGradeName + "</h5>"
                                        + "<h5>" + "本人排名：" + data.data[j].RankingName + "&nbsp;&nbsp;&nbsp;&nbsp;是否上报：" + data.data[j].IsReportName + "</h5>"
                                    + "</div>";
                            intem += "</a></li>";
                            $("#pullrefresh").append(intem);
                        }
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
                        data: "method=TeaReward&pagesize=10&pageindex=" + i,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.result == 'true') {
                                for (var j in data.data) {
                                    var intem = "";
                                    intem += " <li class='mui-table-view-cell  mui-media'><a href='PersonRewardDetail.aspx?id=" + data.data[j].TPID + "'><div class='mui-media-body'><h4> "
                                     + data.data[j].RewardName + "</h4>" + "<h5>获奖年月：" + data.data[j].PubDate + "</h5>" + "<h5>获奖类别：" + data.data[j].RewardTypeName + "</h5>"
                                     + "<h5>" + "奖励级别：" + data.data[j].RGradeName + "</h5>"
                                        + "<h5>" + "本人排名：" + data.data[j].RankingName + "&nbsp;&nbsp;&nbsp;&nbsp;是否上报：" + data.data[j].IsReportName + "</h5>"
                                    + "</div>";
                                    intem += "</a></li>";
                                    $("#pullrefresh").append(intem);
                                }
                            }
                            i = i + 1;
                            jsondata = data.data;
                            // alert(data.data.length );
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

