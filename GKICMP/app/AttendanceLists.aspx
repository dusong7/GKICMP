<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceLists.aspx.cs" Inherits="GKICMP.app.AttendanceLists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>签到统计</title>

    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/icons-extra.css" rel="stylesheet" type="text/css" />
    <link href="../appcss/calendar.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/sign.css" rel="stylesheet" />
    <%-- <script src="../js/jquery-3.3.1.min.js"></script>--%>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/mui.min.js"></script>

    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>

   
    <style>
        .mui-table-view-cell{padding: 11px 15px;margin-bottom: 0px}
        html,body,#form1,.mui-content{height: 100%}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mui-content">
            <header class="mui-bar mui-bar-nav">
                <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
                <h1 class="mui-title">考勤统计</h1>
            </header>
            <div class="sign">

                <ul class="mui-table-view">
                    <li class="mui-table-view-cell signtop"> 
                        <div class="st-date ">
                            <input type="date" runat="server" id="datePicker" class="mui-navigate-right" onchange="function()" />
                            <asp:HiddenField ID="hf_date" runat="server" />
                            <asp:Button ID="btn_Search" runat="server" Text="Button"  OnClick="btn_Search_Click" style="display:none;" />
                        </div>                       
                    </li>

                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_DY" runat="server" Text="打卡/应到"></asp:Label>
                            </b>
                            <span>
                                <asp:Label ID="lbl_YD" runat="server"></asp:Label>
                            </span>
                        </a>
                        <div class="mui-collapse-content">
                            <%--<ul class="st-inli" id="pullreydts" >--%>
                            <ul class="st_li2 fn-clear" id="pullreydts" >
                                <asp:Literal ID="ltl_WeiDaKa" runat="server"></asp:Literal>
                            </ul>

                        </div>
                    </li>
  




                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_DS" runat="server" Text="迟到"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_CD" runat="server" Text="0"></asp:Label>人
                            </span>
                        </a>
                        <div class="mui-collapse-content">
                            <ul class="st-inli" id="pullredkts">
                               <asp:Literal ID="ltl_ChiDao" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </li>

                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_DC" runat="server" Text="缺卡"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_QK" runat="server" Text="0"></asp:Label>人
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrecd">
                            <asp:Literal ID="ltl_QueKa" runat="server"></asp:Literal>
                         
                        </div>
                    </li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_TZ" runat="server" Text="早退"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_ZT" runat="server" Text="0"></asp:Label>人
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrezt">
                            <ul class="st-inli" >
                               <asp:Literal ID="ltl_ZaoTui" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </li>                  
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_JQ" runat="server" Text="请假"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_QJ" runat="server" Text="0"></asp:Label>人
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrefresh">
                             <ul class="st-inli" >
                                 <asp:Literal ID="ltl_QingJia" runat="server"></asp:Literal>
                             </ul>
                        </div>
                    </li>
                    <li class="mui-table-view-cell mui-collapse">
                        <a class="mui-navigate-right" href="#">
                            <b>
                                <asp:Label ID="lbl_CW" runat="server" Text="外出"></asp:Label></b>
                            <span>
                                <asp:Label ID="lbl_WC" runat="server" Text="0"></asp:Label>人
                            </span>
                        </a>
                        <div class="mui-collapse-content" id="pullrefre">
                            <ul class="st-inli" >
                                <asp:Literal ID="ltl_WaiChu" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </li>


                </ul>

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

       
        <script type="text/javascript" charset="utf-8">
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        </script>

        <script>
            $(document).ready(function () {
                ////设置当前时间
                //var now = new Date();
                ////格式化日，如果小于9，前面补0
                //var day = ("0" + now.getDate()).slice(-2);
                ////格式化月，如果小于9，前面补0
                //var month = ("0" + (now.getMonth() + 1)).slice(-2);
                ////拼装完整日期格式
                //var today = now.getFullYear() + "-" + (month) + "-" + (day);
                ////完成赋值
                //$('#datePicker').val(today);
                //GetYearsOrMonth(a);//页面初始化
                $("#datePicker").change(function () {
                    var a = $("#datePicker").val();
                    document.getElementById("btn_Search").click();
                })
            })
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
    </form>
</body>
</html>
