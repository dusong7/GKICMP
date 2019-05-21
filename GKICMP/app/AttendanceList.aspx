<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceList.aspx.cs" Inherits="GKICMP.app.AttendanceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>签到统计</title>

    <link href="../appcss/mui.min.css" rel="stylesheet"/>
    <link href="../appcss/icons-extra.css" rel="stylesheet" type="text/css"  />
    <link href="../appcss/sign.css" rel="stylesheet"/>
    <link href="../appcss/calendar.css" rel="stylesheet"/>
   
    <link href="../appcss/new_file.css" rel="stylesheet" />
   
   <%-- <script src="../js/jquery-3.3.1.min.js"></script>--%>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/mui.min.js"></script>

    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div class="mui-content">
			<header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">考勤统计</h1>
        </header>
			<div class="sign" >
				
				<ul class="mui-table-view" >
					<li class="mui-table-view-cell signtop">
						<div class="st-date ">
                           <input type="month" runat="server" id="datePicker"  class="mui-navigate-right" onchange="function()" />
                           <asp:HiddenField ID="hf_date" runat="server" />
                        </div>
						<div class="st-img">
                            <asp:Image runat="server" ID="image1" />
							<div class="st-name">
                                <span> <asp:Literal ID="ltl_UserName" runat="server"></asp:Literal></span>
                            </div>
							<a href="AttendanceDetail.aspx" >
                                <span class="mui-icon-extra mui-icon-extra-calendar"></span>打卡月历
							</a>
						</div>
					</li>
					<li class="mui-table-view-cell mui-collapse">
						<a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_DY" runat="server" Text="应到天数"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_YD" runat="server" Text="0"></asp:Label>天
                            </span>
						</a>
						<div class="mui-collapse-content">
							<ul class="st-inli" id="pullreydts">
								<li>2018-07-02(星期一)</li>
								<li>2018-07-02(星期一)</li>
								<li>2018-07-02(星期一)</li>
							</ul>
						</div>
					</li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_DS" runat="server" Text="打卡天数"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_SD" runat="server" Text="0"></asp:Label>天
                            </span>
                        </a>
                        <div class="mui-collapse-content">
                            <ul class="st-inli" id="pullredkts">
                                <li>2018-07-02(星期一)</li>
                                <li>2018-07-02(星期一)</li>
                                <li>2018-07-02(星期一)</li>
                            </ul>
                        </div>
                    </li>

                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_DC" runat="server" Text="迟到"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_CD" runat="server" Text="0"></asp:Label>次
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrecd">
                            <p>2018-07-11 (星期一) 8:00</p>
                            <span>3.00分钟</span>
                        </div>
                    </li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_TZ" runat="server" Text="早退"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_ZT" runat="server" Text="0"></asp:Label>次
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrezt">
                            <p>2018-07-19 (星期四) 8:00</p>
                            <span>3.00分钟</span>
                        </div>
                    </li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_GK" runat="server" Text="缺卡"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_KG" runat="server" Text="0"></asp:Label>次
                            </span>
                        </a>
                        <div class="mui-collapse-content" >
                            <ul class="st-inli" id="pullrekg">
                                <li>2018-07-02(星期一)</li>
                                <li>2018-07-02(星期一)</li>
                            </ul>
                        </div>
                    </li>


                   <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_JQ" runat="server" Text="事假"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_QJ" runat="server" Text="0"></asp:Label>天
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrefresh">
                            <%--<p>2018年7月19日-2018年7月19日 0.5天 零星假</p>--%>
                        </div>
                      </li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b><asp:Label ID="lbl_CW" runat="server" Text="外出"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_WC" runat="server" Text="0"></asp:Label>天
                             </span>
                       </a>
                        <div class="mui-collapse-content" id="pullrefre">
                            <%--<p>2018年7月24日-2018年7月24日 1.0天</p>--%>
                        </div>
                    </li>

				</ul>

				<p class="sign-bot">本月平均工时8小时40分</p>
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
            <a href="AppMain.aspx" class="mui-tab-item  mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>

		</div>

<script>
     $(document).ready(function () {
         //设置当前时间
         document.getElementById('datePicker').valueAsDate = new Date();
         var a = $("#datePicker").val() + "-01";
         console.log(a);
         //$.ajax({
         //    url: "../ashx/GetMainDate.ashx",
         //    cache: false,
         //    type: "GET",
         //    data: "method=AnalysisCounts&pageindex=1&pagesize=10&begindate=" + a,
         //    dataType: "json",
         //    async: false,
         //    success: function (data) {
         //        var intem = "";
         //        var ite = "";
         //        var s = 0;
         //        var m = 0;
         //        for (var j in data.data) {
         //            if (data.data[j].LFlag == 1) {
         //                s += Number(data.data[j].LeaveDays);
         //                $('#lbl_JQ').text("事假");//赋值
         //                $('#lbl_QJ').text(s);
         //                intem += "<p>" + data.data[j].BeginDate + '—&nbsp' + data.data[j].EndDate
         //                intem += "&nbsp&nbsp" + data.data[j].LeaveDays + '天' + '&nbsp&nbsp' + data.data[j].LTypeName + "</p>"
         //            }
         //        }
         //        $("#pullrefresh").append(intem);

         //        for (var t in data.data) {
         //            if (data.data[t].LFlag == 2) {
         //                m += Number(data.data[t].LeaveDays);
         //                $('#lbl_CW').text("外出");//给页面中的打卡次数赋值
         //                $('#lbl_WC').text(m);
         //                ite += "<p>" + data.data[t].BeginDate + '—&nbsp' + data.data[t].EndDate
         //                ite += "&nbsp&nbsp" + data.data[t].LeaveDays + '天' + "</p>"
         //            }
         //        }
         //        $("#pullrefre").append(ite);

         //    },
         //    error: function () {
         //        alert("暂无查询到数据！");
         //    }
         //});


         GetYearsOrMonth(a);//页面初始化
         $("#datePicker").change(function () {
             var a = $("#datePicker").val() + "-01";
             GetData(a);
         })


     })



     function GetYearsOrMonth(a)
     {
         GetData(a);
     }

     function GetData(a) {
         $.ajax({
             url: "../ashx/GetMainData.ashx",
             cache: false,
             type: "GET",
             data: "method=GetUserAcount&begin=" + a,
             dataType: "json",
             async: false,
             success: function (data) {
                 var intem = "";
                 var ite = "";
                 var s = 0;
                 var m = 0;
                 for (var j in data.data) {
                     if (data.data[j].LFlag == 1) {
                         s += Number(data.data[j].LeaveDays);
                         $('#lbl_JQ').text("事假");//赋值
                         $('#lbl_QJ').text(s);
                         intem += "<p>" + data.data[j].BeginDate + '—&nbsp' + data.data[j].EndDate
                         intem += "&nbsp&nbsp" + data.data[j].LeaveDays + '天' + '&nbsp&nbsp' + data.data[j].LTypeName + "</p>"
                     }
                 }
                 $("#pullrefresh").append(intem);

                 for (var t in data.data) {
                     if (data.data[t].LFlag == 2) {
                         m += Number(data.data[t].LeaveDays);
                         $('#lbl_CW').text("外出");//给页面中的打卡次数赋值
                         $('#lbl_WC').text(m);
                         ite += "<p>" + data.data[t].BeginDate + '—&nbsp' + data.data[t].EndDate
                         ite += "&nbsp&nbsp" + data.data[t].LeaveDays + '天' + "</p>"
                     }
                 }
                 $("#pullrefre").append(ite);

             },
             error: function () {
                 alert("暂无查询到数据！");
             }
         });
     }

</script>


 <script>
     //$("#datePicker").change(function () {
     //           var a = $("#datePicker").val() + "-01";
     //           $.ajax({
     //               url: "../ashx/GetMainDate.ashx",
     //               cache: false,
     //               type: "GET",
     //               data: "method=AnalysisCounts&pageindex=1&pagesize=10&begindate=" + a,
     //               dataType: "json",
     //               async: false,
     //               success: function (data) {
     //                   var intem = "";
     //                   var ite = "";
     //                   var s = 0;
     //                   var m = 0;
     //                   for (var j in data.data) {
     //                       if (data.data[j].LFlag == 1) {
     //                           s += Number(data.data[j].LeaveDays);
     //                           $('#lbl_JQ').text("事假");//
     //                           $('#lbl_QJ').text(s);     //赋值
     //                           intem += "<p>" + data.data[j].BeginDate + '—&nbsp' + data.data[j].EndDate
     //                           intem += "&nbsp&nbsp" + data.data[j].LeaveDays + '天' + '&nbsp&nbsp' + data.data[j].LTypeName + "</p>"
     //                       }
     //                   }
     //                   $("#pullrefresh").append(intem);

     //                   for (var t in data.data) {
     //                       if (data.data[t].LFlag == 2) {
     //                           m += Number(data.data[t].LeaveDays);
     //                           $('#lbl_CW').text("外出");
     //                           $('#lbl_WC').text(m);
     //                           ite += "<p>" + data.data[t].BeginDate + '—&nbsp' + data.data[t].EndDate
     //                           ite += "&nbsp&nbsp" + data.data[t].LeaveDays + '天' + "</p>"
     //                       }
     //                   }
     //                   $("#pullrefre").append(ite);

     //               },
     //               error: function () {
     //                   alert("暂无查询到数据！");
     //               }
     //           });
     //       });
</script>



    </form>
</body>
</html>
