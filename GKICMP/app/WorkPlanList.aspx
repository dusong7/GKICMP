<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanList.aspx.cs" Inherits="GKICMP.app.WorkPlanList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>读计划</title>
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
            <h1 class="mui-title">周计划</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="WorkPlanList.aspx"class="mui-control-item mui-active" >读计划</a>
                    <a href="WorkPlan.aspx"    class="mui-control-item ">写计划</a>
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
                data: "method=Work&pageindex=1&pagesize=10",
                dataType: "json",
                async: false,
                success: function (data) {
                    for (var j in data.data) {
                        var intem = "";
                        var m = data.data[j].ExamName;
                        var n = m.split('&');
                     
                      if(m.indexOf('&') >=0)//便于区分以前写过的计划不包含&
                       {
                        intem += " <li class='mui-table-view-cell  mui-media'><div class=''mui-media-body'><h4> "
                            + data.data[j].EYear + "学年度" + (data.data[j].Term == "1" ? "上学期" : "下学期") + "第" + data.data[j].WeekNum + "周" + "</h4>";
                            for (var i = 0; i < n.length-1; i++) 
                            {
                                var name = "";
                                var t = i;
                                name = t == 0 ? "一" : t == 1 ? "二" : t == 2 ? "三" : t == 3 ? "四" : t == 4 ? "五" : t == 5 ? "六" : "日";
                                if (i >= 7)
                                {
                                    t = i - 7;
                                    name = t == 0 ? "一" : t == 1 ? "二" : t == 2 ? "三" : t == 3 ? "四" : t == 4 ? "五" : t == 5 ? "六" : "日";
                                }                                
                                intem += " <p style='font-size:12px;'>" + '【周' + name + '】' + n[i] + "</p>"
                                //intem += " <p style='font-size:12px;'>" + '【周' + a + '】' + n[i] + "</p>"

                            }
                        intem += "<span class='mui-h5'>" + "日期：" + data.data[j].BeginDate + "至" + data.data[j].EndDate;
                        intem += " <p  style='font-size:12px;'>" + "参与人：" + data.data[j].AllUsers + "</p>";
                        intem += " <h5>部门：" + data.data[j].DepName + "&nbsp;&nbsp;&nbsp;&nbsp;责任人：" + data.data[j].DutyUserName + "</h5>";
                        intem += " <h5>发起人：" + data.data[j].CreateUserName;
                        intem += " &nbsp&nbsp&nbsp&nbsp状态: " + (data.data[j].IsComplete == "1" ? "<span style='color:gray'>已完成</span>" : "<span style='color:#febe17'>未完成</span>");
                        intem += " </h5></div>";

                       }
                      else
                        {
                                   intem += " <li class='mui-table-view-cell  mui-media'><div class=''mui-media-body'><h4> "
                                   + data.data[j].EYear + "学年度" + (data.data[j].Term == "1" ? "上学期" : "下学期") + "第" + data.data[j].WeekNum + "周" + "</h4>"
                                   + "<p  style='font-size:12px;'> " + data.data[j].ExamName + "</p>"
                                   + "<span class='mui-h5'>" + "日期：" + data.data[j].BeginDate + "至" + data.data[j].EndDate
                                   + "<p  style='font-size:12px;'>" + "参与人：" + data.data[j].AllUsers + "</p>"
                                   + "<h5>部门：" + data.data[j].DepName + "&nbsp;&nbsp;&nbsp;&nbsp;责任人：" + data.data[j].DutyUserName + "</h5>"
                                   + "<h5>发起人：" + data.data[j].CreateUserName
                                   + "&nbsp&nbsp&nbsp&nbsp状态: " + (data.data[j].IsComplete == "1" ? "<span style='color:gray'>已完成</span>" : "<span style='color:#febe17'>未完成</span>")
                                   + "</h5></div>";
                        }

                        if (data.data[j].IsComplete == 0) 
                        {
                            intem += " <div class='list-btn' ><span  style='margin-right: 10px;padding: 5px 10px;border-radius: 15px;' id='" + data.data[j].PlanID + "' class='btn-pz'>完成</span></div>";
                        }
                        intem += "</li>";

                        $("#pullrefresh").append(intem);
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
                        data: "method=Work&pagesize=10&pageindex=" + i,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            for (var j in data.data) {
                                //var intem = "";
                                  // intem += " <li class='mui-table-view-cell  mui-media'><div class=''mui-media-body'><h4> "
                                  // + data.data[j].EYear + "学年度" + (data.data[j].Term == "1" ? "上学期" : "下学期") + "第" + data.data[j].WeekNum + "周" + "</h4>"
                                  // + "<p  style='font-size:12px;'> " + data.data[j].ExamName + "</p>"
                                  // + "<span class='mui-h5'>" + "日期：" + data.data[j].BeginDate + "至" + data.data[j].EndDate
                                  // + "<p  style='font-size:12px;'>" + "参与人：" + data.data[j].AllUsers + "</p>"
                                  // + "<h5>部门：" + data.data[j].DepName + "&nbsp;&nbsp;&nbsp;&nbsp;责任人：" + data.data[j].DutyUserName + "</h5>"
                                  // + "<h5>发起人：" + data.data[j].CreateUserName
                                  // + "&nbsp&nbsp&nbsp&nbsp状态: " + (data.data[j].IsComplete == "1" ? "<span style='color:gray'>已完成</span>" : "<span style='color:#febe17'>未完成</span>")
                                  // + "</h5></div>";
                        var intem = "";
                        var m = data.data[j].ExamName;
                        var n = m.split('&');
                     
                       if(m.indexOf('&') >=0)
                       {
                        intem += " <li class='mui-table-view-cell  mui-media'><div class=''mui-media-body'><h4> "
                            + data.data[j].EYear + "学年度" + (data.data[j].Term == "1" ? "上学期" : "下学期") + "第" + data.data[j].WeekNum + "周" + "</h4>";
                            for (var i = 0; i < n.length-1; i++) 
                            {
                                var name = "";
                                var t = i;
                                name = t == 0 ? "一" : t == 1 ? "二" : t == 2 ? "三" : t == 3 ? "四" : t == 4 ? "五" : t == 5 ? "六" : "日";
                                if (i >= 7)
                                {
                                    t = i - 7;
                                    name = t == 0 ? "一" : t == 1 ? "二" : t == 2 ? "三" : t == 3 ? "四" : t == 4 ? "五" : t == 5 ? "六" : "日";
                                }
                                intem += " <p style='font-size:12px;'>" + '【周' + name + '】' + n[i] + "</p>"
                                //intem += " <p style='font-size:12px;'>" + '【周' + [i + 1] + '】' + n[i] + "</p>"
                            }
                        intem += "<span class='mui-h5'>" + "日期：" + data.data[j].BeginDate + "至" + data.data[j].EndDate;
                        intem += " <p  style='font-size:12px;'>" + "参与人：" + data.data[j].AllUsers + "</p>";
                        intem += " <h5>部门：" + data.data[j].DepName + "&nbsp;&nbsp;&nbsp;&nbsp;责任人：" + data.data[j].DutyUserName + "</h5>";
                        intem += " <h5>发起人：" + data.data[j].CreateUserName;
                        intem += " &nbsp&nbsp&nbsp&nbsp状态: " + (data.data[j].IsComplete == "1" ? "<span style='color:gray'>已完成</span>" : "<span style='color:#febe17'>未完成</span>");
                        intem += " </h5></div>";

                       }
                      else
                        {
                              intem += " <li class='mui-table-view-cell  mui-media'><div class=''mui-media-body'><h4> "
                              + data.data[j].EYear + "学年度" + (data.data[j].Term == "1" ? "上学期" : "下学期") + "第" + data.data[j].WeekNum + "周" + "</h4>"
                              + "<p  style='font-size:12px;'> " + data.data[j].ExamName + "</p>"
                              + "<span class='mui-h5'>" + "日期：" + data.data[j].BeginDate + "至" + data.data[j].EndDate
                              + "<p  style='font-size:12px;'>" + "参与人：" + data.data[j].AllUsers + "</p>"
                              + "<h5>部门：" + data.data[j].DepName + "&nbsp;&nbsp;&nbsp;&nbsp;责任人：" + data.data[j].DutyUserName + "</h5>"
                              + "<h5>发起人：" + data.data[j].CreateUserName
                              + "&nbsp&nbsp&nbsp&nbsp状态: " + (data.data[j].IsComplete == "1" ? "<span style='color:gray'>已完成</span>" : "<span style='color:#febe17'>未完成</span>")
                              + "</h5></div>";
                        }

                        if (data.data[j].IsComplete == 0) {
                              intem += " <div class='list-btn' ><span style='margin-right: 10px;padding: 5px 10px;border-radius: 15px;' id='" + data.data[j].PlanID + "' class='btn-pz'>完成</span></div>";
                         }
                                intem += "</li>";
                                $("#pullrefresh").append(intem);
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
<script>
    function show(e) {
        var planid = $(e).attr("id")
        if (planid != "") {
            $.ajax({
                url: "../ashx/GetMainDate.ashx",
                cache: false,
                type: "GET",
                data: "method=WorkWC&planid=" + planid,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result = 'true') {
                        alert("完成成功");
                        window.location.reload();
                    }
                    else {
                        alert("完成失败");
                    }
                }
            });
        }
    }
</script>



<script>
    <%--function aa()
    {
        alert(1);
            var numStr = "0123456789";
            var chineseStr = "零一二三四五六七八九";
            var c = numberStr.ToCharArray();
            for (var i = 0; i < c.Length; i++)
            {
               var index = numStr.IndexOf(c[i]);
               if (index != -1)
               c[i] = chineseStr.ToCharArray()[index];
            }
        numStr = null;
        chineseStr = null;
        return new string(c);
    } --%>
 </script>