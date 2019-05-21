<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreatedEgovernmentManage.aspx.cs" Inherits="GKICMP.app.TreatedEgovernmentManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>待处理政务</title>
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
        <input type="hidden" runat="server" id="hf_didname" />
        <asp:HiddenField ID="hf_User" runat="server" />

        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">电子政务</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="TreatedEgovernmentManage.aspx" class="mui-control-item mui-active">待处理政务</a>
                    <a href="AlreadyEgovernmentManage.aspx" class="mui-control-item">已发政务</a>
                    <a href="EgovernmentList.aspx" class="mui-control-item">已收政务</a>
                </div>
            </div>
            <div class="mui-input-row mui-search" style="margin-top: 0px">
                <input type="search" class="mui-input-clear" placeholder="请输入政务标题" id="keyword" />
            </div>
            <div class=" mui-scroll-wrapper" id="offCanvasContentScroll" style="margin-top: 150px; margin-bottom: 50px">
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
            mui('body').on('tap', '.list-btn span', function () {
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
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=EgovernmentByFlag&flag=1&pageindex=1&pagesize=10&didname=" + $("#hf_didname").val(),
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == "success") {
                        for (var j in data.data) {
                            var intem = "";
                            intem += " <li class='mui-table-view-cell'><a href='EgovernmentDetails.aspx?id=" + data.data[j].FID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> "
                                + (data.data[j].IsApproved == "1" ? "<span style='font-weight:lighter;color:#47AE6F'>[公文]</span>" : "")
                                + data.data[j].Etitle + "</h4><div class='mui-col-xs-12'><span class='mui-h5'> "
                                + data.data[j].CreateDate + "</span></div>"
                                + "<h5>发件人：" + data.data[j].CreateUserName + "&nbsp&nbsp&nbsp&nbsp<span>状态: "
                                + (data.data[j].Completed == "1" ? "<span style='color:#FF83FA'>已归档</span>" : data.data[j].State == "0" ? "<span style='color:red'>未处理</span>" : data.data[j].State == "1" ? "<span style='color:blue'>批转中</span>" : data.data[j].State == "2" ? "已处理" : data.data[j].State == "5" ? "<span style='color:#48bd81'>已阅</span>" : "")
                                + "</span></h5></div></div></a>";
                            if (data.data[j].State == 0) {
                                intem += " <div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius: 15px;' id='" + data.data[j].FID + "'class='btn-pz'>已阅</span></div>";
                            }
                            intem += "</li>";
                            $("#pullrefresh").append(intem);
                        }
                    }
                    else {
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
                        data: "method=EgovernmentByFlag&flag=1&pagesize=10&pageindex=" + i + "&didname=" + $("#hf_didname").val(),
                        //data: "method=EgovernmentNum&pageindex=" + i + "&pagesize=10",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.result == "success") {
                                for (var j in data.data) {
                                    var intem = "";
                                    //var a = data.data[j].FID;
                                    intem += " <li class='mui-table-view-cell'><a href='EgovernmentDetails.aspx?id=" + data.data[j].FID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> "
                                    + (data.data[j].IsApproved == "1" ? "<span style='font-weight:lighter;color:#47AE6F'>[公文]</span>" : "")
                                    + data.data[j].Etitle + "</h4><div class='mui-col-xs-12'><span class='mui-h5'> "
                                    + data.data[j].CreateDate + "</span></div>"
                                    //<p class='mui-h6 mui-ellipsis'>" +data.data[j].EContent + "</p>"
                                    + "<h5>发件人：" + data.data[j].CreateUserName + "&nbsp&nbsp&nbsp<span>状态: "
                                    + (data.data[j].Completed == "1" ? "<span style='color:#FF83FA'>已归档</span>" : data.data[j].State == "0" ? "<span style='color:red'>未处理</span>" : data.data[j].State == "1" ? "<span style='color:blue'>批转中</span>" : data.data[j].State == "2" ? "已处理" : data.data[j].State == "5" ? "<span style='color:#48bd81'>已阅</span>" : "")
                                    + "</span></h5></div></div></a> ";
                                    if (data.data[j].State == 0) {
                                        intem += " <div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius: 15px;' id='" + data.data[j].FID + "'class='btn-pz'>已阅</span></div>";
                                    }
                                    intem += "</li>";
                                    $("#pullrefresh").append(intem);
                                }

                                i = i + 1;
                                jsondata = data.data;
                                // alert(data.data.length );
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
            $("#keyword").on('keypress', function (e) {
                var keycode = e.keyCode;
                $("#hf_didname").val($(this).val());
                if (keycode == '13') {
                    //e.preventDefault();
                    //请求搜索接口  

                    getdata($("#hf_didname").val());
                    //$("#form1").attr({ "action": 'StuAttendManage.aspx?did=' + didname, "method": "post" });
                    //form.submit();
                }
                //else if (keycode == '13') {
                //    e.preventDefault();
                //    $('#keyword').blur();
                //    return false;
                //}

            });
            $("#keyword").on('blur', function (e) {
                if ($.trim($(this).val()).length > 0) { }
            });
        </script>

    </form>
</body>
</html>
<script>
    function getdata(name) {
        $.ajax({
            url: "../ashx/GetMainDate.ashx",
            cache: false,
            type: "GET",
            data: "method=EgovernmentByFlag&flag=1&pageindex=1&pagesize=10&didname=" + name,
            dataType: "json",
            async: false,
            success: function (data) {
                if (data.result == "success") {
                    for (var j in data.data) {
                        var intem = "";
                        intem += " <li class='mui-table-view-cell'><a href='EgovernmentDetails.aspx?id=" + data.data[j].FID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> "
                                 + (data.data[j].IsApproved == "1" ? "<span style='font-weight:lighter;color:#47AE6F'>[公文]</span>" : "")
                                 + data.data[j].Etitle + "</h4><div class='mui-col-xs-12'><span class='mui-h5'> "
                                 + data.data[j].CreateDate + "</span></div>"
                                 + "<h5>发件人：" + data.data[j].CreateUserName + "&nbsp&nbsp&nbsp&nbsp<span>状态: "
                                 + (data.data[j].Completed == "1" ? "<span style='color:#FF83FA'>已归档</span>" : data.data[j].State == "0" ? "<span style='color:red'>未处理</span>" : data.data[j].State == "1" ? "<span style='color:blue'>批转中</span>" : data.data[j].State == "2" ? "已处理" : data.data[j].State == "5" ? "<span style='color:#48bd81'>已阅</span>" : "")
                                 + "</span></h5></div></div></a>";
                        if (data.data[j].State == 0) {
                            intem += " <div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius: 15px;' id='" + data.data[j].FID + "'class='btn-sh'>已阅</span></div>";
                        }
                        intem += "</li>";
                        $("#pullrefresh").append(intem);
                    }
                }
            },
            error: function () {
                alert("暂无查询到数据！");
            }
        });
    }
</script>
<script>
    function show(e) {
        var fid = $(e).attr("id")
        if (fid != "") {
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=YY&fid=" + fid,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result = 'true') {
                        alert("已阅成功");
                        window.location.reload();
                    }
                    else {
                        alert("已阅失败");
                    }
                }
            });
        }
    }
</script>
