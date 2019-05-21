<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceDetail.aspx.cs" Inherits="GKICMP.app.AttendanceDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>签到日历</title>

     <link href="../appcss/mui.min.css" rel="stylesheet"/>
   <%-- <link href="../css/mui.min.css" rel="stylesheet" />--%>
    <link href="../appcss/icons-extra.css" rel="stylesheet" type="text/css"  />
    <link href="../appcss/sign.css" rel="stylesheet"/>
    <link href="../appcss/calendar.css" rel="stylesheet"/>
     <link href="../appcss/new_file.css" rel="stylesheet" />
  
    <script src="../appjsjs/jquery-3.3.1.min.js"></script>
    <script src="../appjsjs/jquery-1.11.0.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>

    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="mui-content">
			<header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">考勤详情</h1>
        </header>
			<div class="calenda">
				
				<ul class="mui-table-view">
					<li class="mui-table-view-cell signtop nbb">
						<div class="st-img">
                             <asp:Image runat="server" ID="image1" />
							<div class="st-name">
                                <span> 
                                    <asp:Literal ID="ltl_UserName" runat="server"></asp:Literal>
                                </span>
							</div>
							<a style="color: #666">
                                <asp:Label ID="lbl_Time" runat="server" Text=""></asp:Label>
							</a>
						</div>
					</li>
					<div id="calendain"></div>
                    <asp:HiddenField ID="hf_DepID" runat="server" />
					<p></p>
					<p style="padding:0 15px">班次：软件部 08:00-11:30 13:30-18:00 </p>
					
					<ul class="mui-table-view" >
						 <li class="mui-table-view-cell bl0">
                             <span class="mui-icon-extra mui-icon-extra-regist blue mr5"></span>
                             今日打卡 <asp:Label ID="ltl_dkcs" runat="server" Text=""></asp:Label>次，工时共计3小时38分钟
						 </li>
						 <li class="mui-table-view-cell calendatime" id="pullrefresh">
						 	<%--<div class="calendatime-box">
						 		<h3>打卡时间 07:58
                                     <span class="gre"> (上班时间08:00)</span>
						 		</h3>
						 		<p class="mb5"><span class="mui-icon mui-icon-location"></span>步行街</p>
						 		<span class="mui-badge mui-badge-danger">迟到</span>
						 		<div class="calendatime-up">上</div>
						 		<div class="calendatime-line"></div>
						 	</div>
						 	<div class="calendatime-box">
						 		<h3>打卡时间 11:58
                                     <span class="gre"> (下班时间08:00)</span>
						 		</h3>
						 		<p class="mb5"><span class="mui-icon mui-icon-location"></span>步行街</p>
						 		<span class="mui-badge mui-badge-primary">正常</span>
						 		<div class="calendatime-up">下</div>
						 		<div class="calendatime-line"></div>
						 	</div>
						 	<div class="calendatime-box">
						 		<h3>打卡时间 11:58
                                     <span class="gre"> (下班时间08:00)</span>
						 		</h3>
						 		<p class="mb5"><span class="mui-icon mui-icon-location"></span>步行街</p>
						 		<span class="mui-badge mui-badge-warning">缺卡</span>
						 		<div class="calendatime-up">上</div>
						 		<div class="calendatime-line"></div>
						 	</div>--%>
						 </li>

					</ul>
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


   <script src="../appjs/calendar.js" type="text/javascript" charset="utf-8"></script>
	<script type="text/javascript">
	    var cld = new Calendar({
	        el: '#calendain',
	        value: '', // 默认为new Date();
	        callback: function (obj) {
	            console.log(obj);
	            console.log(JSON.stringify(obj));
	            console.log(obj.year + "-" + obj.month + "-" + obj.day);
	            var a = obj.year + "-" + obj.month + "-" + obj.day;
	           
	            document.getElementById('hf_DepID').value = a;
	            var b = document.getElementById('hf_DepID').value;


	            GetYearsOrMonth(a);//页面初始化
	            $("#calendain").click(function () {
	                var a = obj.year + "-" + obj.month + "-" + obj.day;
	                GetData(a);
	            })

	        }


	    })

	    function GetYearsOrMonth(a)
	    {
	        GetData(a);
	    }

	    function GetData(a) {
	        $.ajax({
	            url: "../ashx/GetMainDate.ashx",
	            cache: false,
	            type: "GET",
	            data: "method=AnalysisDetails&pageindex=1&pagesize=10&begindate=" + a,
	            dataType: "json",
	            async: false,
	            success: function (data) {
	                $('#ltl_dkcs').text(data.data.length);//给页面中的打卡次数赋值
	                for (var j in data.data) {
	                    var intem = "";
	                    intem += "<div class='calendatime-box'>";
	                    intem += "<h3>打卡时间&nbsp;" + data.data[j].RecordDate
	                    //intem += "<span class='gre'> (上班时间&nbsp;" + data.data[j].RecordDate + ")</span></h3>";
	                    intem += "<span class='gre'> </span></h3>";
	                    intem += "<p class='mb5'><span class='mui-icon mui-icon-location'></span>" + data.data[j].MachineCode + "号考勤机</p>";
	                    if (data.data[j].AnayName == "正常") {
	                        intem += "<span class='mui-badge mui-badge-primary'>" + data.data[j].AnayName + "</span>";
	                    }
	                    else if (data.data[j].AnayName == "早退") {
	                        intem += "<span class='mui-badge mui-badge-warning'>" + data.data[j].AnayName + "</span>";
	                    }
	                    else if (data.data[j].AnayName == "迟到") {
	                        intem += "<span class='mui-badge mui-badge-danger'>" + data.data[j].AnayName + "</span>";
	                    }
	                    else {
	                        intem += "<span class='mui-badge mui-badge-danger'>" + data.data[j].AnayName + "</span>";
	                    }
	                    if (data.data[j].RecordDate <= "10:00") {
	                        intem += "<div class='calendatime-up'>" + "上" + "</div>";
	                    }
	                    else if (data.data[j].RecordDate > "10:00" && data.data[j].RecordDate <= "13:00") {
	                        intem += "<div class='calendatime-up'>" + "下" + "</div>";
	                    }
	                    else if (data.data[j].RecordDate > "13:00" && data.data[j].RecordDate <= "15:00") {
	                        intem += "<div class='calendatime-up'>" + "上" + "</div>";
	                    }
	                    else {
	                        intem += "<div class='calendatime-up'>" + "下" + "</div>";
	                    }
	                    intem += "<div class='calendatime-line'></div>";
	                    intem += "</div>";
	                    $("#pullrefresh").append(intem);
	                }
	            },
	            error: function () {
	                alert("暂无查询到数据！");
	            }
	        });
	    }


	</script>

<script>
    $(document).ready(function () {
    })
</script>
 
<script>
    var a = $("#hf_DepID").val();

</script>


    </form>
</body>
</html>
