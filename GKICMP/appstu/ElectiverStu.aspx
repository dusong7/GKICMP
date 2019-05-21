<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverStu.aspx.cs" Inherits="GKICMP.appstu.ElectiverStu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>选课管理</title>
    <link href="../appcss/w_new_file.css" rel="stylesheet" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
   <%-- <link href="../appcss/w_new_file.css" rel="stylesheet" />--%>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/mui.min.js"></script>
    <script src="../js/choice.js"></script>
    <style>
       
    </style>

</head>

<body class="xuanke">

    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_User" runat="server" />

        <header class="mui-bar mui-bar-nav" >
             <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">选课管理</h1>
        </header>

         <div class="mui-content">
         
             <div class="xk-top mg10">
		        <div class="xktop-1"> 选课时间
                    <asp:Label ID="lbl_ks" runat="server" Text=""></asp:Label>
                    至 
                     <asp:Label ID="lbl_js" runat="server" Text=""></asp:Label>
		        </div>
		        <div class="xktop-2">课程限制：
                    <asp:Label ID="lbl_Ecount" runat="server" Text=""></asp:Label> 门
		        </div>
	         </div>

             <div class="mui-card" style="margin-bottom: 35px;" id="offCanvasContentScroll">
			    <ul class="mui-table-view" id="pullrefresh">
			    </ul>
		    </div>

             <%-- <div class="mui-content  mui-scroll-wrapper" id="offCanvasContentScroll">

                <div class="mui-scroll">
                    <ul class="mui-table-view mui-table-view-striped mui-table-view-condensed" id="pullrefresh">
                    </ul>
                </div>
            </div>--%>

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
            mui("body").on("tap", ".mui-btn-primary span", function () {
                show(this);
            });
        </script>

        <script>
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
            $.ajax({
                url: "../ashx/ElectiverCourse.ashx",
                cache: false,
                type: "GET",
                data: "method=CList&pageindex=1&pagesize=10&eleid=" + eleid,
                dataType: "json",
                async: false,
                success: function (data) {
                    for (var j in data.data) {
                        var intem = "";
                        intem += "<li class='mui-table-view-cell'>";
                        intem += "<a href='CourseDetail.aspx?id=" + data.data[j].CourseID + "&eleid=" + eleid + "'> ";
                        intem += "<span class='xklist1'>" + data.data[j].CourseName + "</span> &nbsp;&nbsp;";
                        intem += "<span class='xklist2'>(" + data.data[j].ClevelName + ")</span> &nbsp;&nbsp;";
                        intem += "<span class='xklist3'><i>" + data.data[j].DY + "&nbsp;</i>/&nbsp;";
                        intem += data.data[j].MaxCount + "</span>";
                        intem += "</a>";
                        var isin = data.data[j].IsIn;
                        if (parseInt(data.data[j].SignCount) < parseInt(data.data[j].ECount)) {
                            if (data.data[j].IsIn == "0") {
                                if (parseInt(data.data[j].DY) < parseInt(data.data[j].MaxCount)) {
                                    intem += "<div class='mui-btn mui-btn-primary' id='fh' ><span  id='" + data.data[j].CourseID + "'  eleid='" + data.data[j].EleID + "'>选课</span></div>";
                                }
                            }
                            else {
                                intem += "<div class='mui-btn mui-btn-primary' id='fh' ><span  id='Back_" + data.data[j].CourseID + "'  eleid='" + data.data[j].EleID + "'>退课</span></div>";
                            }
                        }
                        else {
                            if (data.data[j].IsIn != "0")
                                intem += "<div class='mui-btn mui-btn-primary' id='fh' ><span  id='Back_" + data.data[j].CourseID + "'  eleid='" + data.data[j].EleID + "'>退课</span></div>";
                        }
                        intem += "</li>";
                       
                        $("#pullrefresh").append(intem);
                    }
                },
                error: function () {
                    $("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
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
                        url: "../ashx/ElectiverCourse.ashx",
                        cache: false,
                        type: "GET",
                          data: "method=CList&pagesize=10&pageindex=" + i + "&eleid=" + eleid,
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            for (var j in data.data) {
                                var intem = "";
                                intem += "<li class='mui-table-view-cell'>";
                                intem += "<a href='CourseDetail.aspx?id=" + data.data[j].CourseID + "&eleid=" + eleid + "'> ";
                                intem += "<span class='xklist1'>" + data.data[j].CourseName + "</span> &nbsp;&nbsp;";
                                intem += "<span class='xklist2'>(" + data.data[j].ClevelName + ")</span> &nbsp;&nbsp;";
                                intem += "<span class='xklist3'><i>" + data.data[j].DY + "&nbsp;/</i>&nbsp;";
                                intem += data.data[j].MaxCount + "</span>";
                                intem += "</a>";
                                if (data.data[j].IsIN == false) {
                                    if (data.data[j].DY < data.data[j].MaxCount) {
                                        intem += "<div class='mui-btn mui-btn-primary' ><span id='" + data.data[j].CourseID + "'  eleid='" + data.data[j].EleID + "'>选课</span></div>";
                                    }
                                }
                                else {
                                    intem += "<div class='mui-btn mui-btn-primary' id='fh' ><span  id='Back_" + data.data[j].CourseID + "'  eleid='" + data.data[j].EleID + "'>退课</span></div>";
                                }
                                intem += "</li>";
                        $("#pullrefresh").append(intem);
                            }

                            i = i + 1;
                            jsondata = data.data;
                        },
                        error: function () {
                            $("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
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
        var id = $(e).attr("id");
        var cid = "";
        var IsBack = false;
        if (id.indexOf("Back_") >= 0)
        {
            id = id.replace("Back_", "");
            IsBack = true;
        }
        eleid = $(e).attr("eleid");
        if (id != "") {
            $.ajax({
                url: "../ashx/ElectiverCourse.ashx",
                cache: false,
                type: "GET",
                data: "method=OnLine&id=" + id + "&eleid=" + eleid + "&isback=" + IsBack,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result = 'true') {
                        if (IsBack)
                            alert("退课成功");
                        else
                            alert("选课成功");
                        window.location.reload();
                        //$("#fh").css("display", "none");//隐藏按钮
                    }
                    else {
                        if (IsBack)
                            alert("退课失败");
                        else
                            alert("选课失败");
                    }
                }
            });
        }
    }
</script>
