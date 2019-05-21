<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverList.aspx.cs" Inherits="GKICMP.appstu.ElectiverList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>任务列表</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../appjs/mui.min.js"></script>

</head>

<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_User" runat="server" />

        <header class="mui-bar mui-bar-nav">
             <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">任务列表</h1>
        </header>
        <div class="mui-content  mui-scroll-wrapper" id="offCanvasContentScroll">
            <div class="mui-scroll">
            <ul class="mui-table-view mui-table-view-striped mui-table-view-condensed" id="pullrefresh">
                
            </ul>
            </div>
        </div>

          <nav class="mui-bar mui-bar-tab">
             <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a href="../app/UserInfo.aspx" class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>

            <a href="Stu_AppMain.aspx" class="mui-tab-item mui-active">
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
            //function getUrlParam(name) {
            //    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            //    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            //    if (r != null) return unescape(r[2]); return null; //返回参数值
            //}
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
                url: "../ashx/ElectiverCourse.ashx",
                cache: false,
                type: "GET",
                data: "method=EList&pageindex=1&pagesize=10",
                dataType: "json",
                async: false,
                success: function (data) {
                    //alert(321);
                    for (var j in data.data) {
                        var intem = "";
                        //var a = data.data[j].CourseDesc.length;
                        //var a = data.data[j].FID;
                        //intem += " <li class='mui-table-view-cell'><a href='ElectiverStu.aspx?id=" + data.data[j].EleID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> 选课名称："
                        //    + data.data[j].ElectiverName +  "</h4><div class='mui-col-xs-12'></div>"
                        //    //+ "<p class='mui-h6 mui-ellipsis'>限制门数：" + data.data[j].Ecount + "</p>"
                        //    //+ "<h5>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd
                        //     + "<p class='mui-h6 mui-ellipsis'>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "</p>"
                        //     + "<h5>限制门数：" + data.data[j].Ecount +
                        //     + "</h5></div></div></a></li> ";

                        //var edate = new Date().toLocaleDateString();
                        //if (data.data[j].EStopDate < edate)
                        //{
                            intem += " <li class='mui-table-view-cell'><a href='ElectiverStu.aspx?id=" + data.data[j].EleID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> 选课名称："
                            intem += data.data[j].ElectiverName + "</h4><div class='mui-col-xs-12'></div>"
                            intem += "<p class='mui-h6 mui-ellipsis'>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "</p>"
                            intem += "<h5>限制门数：" + data.data[j].Ecount
                            intem += "</h5>"
                            intem += "<h5>状态："
                        //intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:green'>预选阶段");                            
                            intem += (new Date(data.data[j].EstimateEDate) <= new Date() ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:green'>预选阶段");
                            intem += "</h5>"

                            intem += "</div></div></a></li> ";
                        //}
                        

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
                        url: "../ashx/ElectiverCourse.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=EList&pagesize=10&pageindex=" + i,
                        //data: "method=EgovernmentNum&pageindex=" + i + "&pagesize=10",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            for (var j in data.data) {
                                var intem = "";
                                //var a = data.data[j].FID;
                                //intem += " <li class='mui-table-view-cell'><a href='ElectiverStu.aspx?id=" + data.data[j].EleID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> 选课名称："
                                //      + data.data[j].ElectiverName + "</h4><div class='mui-col-xs-12'></div>"
                                //    //+ "<p class='mui-h6 mui-ellipsis'>限制门数：" + data.data[j].Ecount + "</p>"
                                //    //+ "<h5>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd
                                //      + "<p class='mui-h6 mui-ellipsis'>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "</p>"
                                //      + "<h5>限制门数：" + data.data[j].Ecount
                                //      + "</h5></div></div></a></li> ";

                                intem += " <li class='mui-table-view-cell'><a href='ElectiverStu.aspx?id=" + data.data[j].EleID + "'> <div class='mui-table'><div class='mui-col-xs-12'><h4 class='mui-ellipsis'> 选课名称："
                                intem += data.data[j].ElectiverName + "</h4><div class='mui-col-xs-12'></div>"
                                intem += "<p class='mui-h6 mui-ellipsis'>选课日期：" + data.data[j].EBegin + "--" + data.data[j].EEnd + "</p>"
                                intem += "<h5>限制门数：" + data.data[j].Ecount
                                intem += "</h5>"
                                intem += "<h5>状态："
                                intem += (data.data[j].EState == "3" ? "<span style='color:#FF83FA'>选课阶段</span>" : "<span style='color:green'>预选阶段");
                                intem += "</h5>"
                                intem += "</div></div></a></li> ";

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


