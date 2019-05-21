<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="GKICMP.Main" %>

<!DOCTYPE html>
<html>
<head>
    <title>智慧校园</title>
    <link href="css/homecss.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <%--<script type="text/javascript">
        $(function () 
        {
            var user = $("#hffth").val(); //获取UserID
            if (user !== "")
            {
                    $.ajax({
                        url: "ashx/GetMainDate.ashx",
                        cache: false,
                        type: "GET",
                        data: "method=MainDate&user=" + user,
                        dataType: "json",
                       
                        success: function (data)
                        {
                           // alert(data.dzzw); 
                            $("#lbl_wdzw").html(data.dzzw);
                            $("#lbl_jsqj").html(data.jsqj);
                            $("#lbl_xsqj").html(data.xsqj);
                            $("#lbl_dkjl").html( data.dkjl);
                            $("#lbl_bxjl").html( data.bxjl);
                           
                        }
                    })
            }
            else
               {
                  alert("查询出错，请重新操作");
                }
        });
            
    </script>--%>

    <script type="text/javascript">
        $(function () {
            showTime();
            Play();
        });

        function showTime() {
            var user = $("#hffth").val(); //获取UserID
            if (user !== "") {
                $.ajax({
                    url: "ashx/GetMainDate.ashx",
                    cache: false,
                    type: "GET",
                    data: "method=MainDate&user=" + user,
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $("#lbl_wdzw").html(data.dzzw);
                        $("#lbl_jsqj").html(data.jsqj);
                        $("#lbl_wzsh").html(data.wzsh);
                        $("#lbl_dkjl").html(data.dkjl);
                        $("#lbl_bxjl").html(data.bxjl);
                    }
                })
            }
            else {
                alert("查询出错，请重新操作");
            }
        }

        function Play() {
            var a = document.getElementById("tryListen").src
            var b = $("#lbl_wdzw").val();
            document.getElementById("tryListen").src = "ashx/Handler1.ashx?text=" + encodeURI('<%=text%>');
            var b = document.getElementById("tryListen").src
            $("#tryListen")[0].play();
        }

        //页面无刷新操作 
        setInterval("showTime()", 60000);//设置每隔1豪秒调用一下上面的函数或方法或对象   

       

    </script>

   

</head>

<body class="hold-transition skin-blue sidebar-mini">
    <form runat="server">
        <asp:HiddenField ID="hffth" runat="server" />
         <audio id="tryListen" style="display:none;">
             <source src="ashx/Handler1.ashx?text=111" type="audio/mp3" />
         </audio>
        <div id="areascontent">
            <div class="rows" style="margin-bottom: 0.8%; overflow: hidden;">
                <div>
                    <div style="height: 100%; overflow: hidden;">
                        <a href="oamanage/EgovernmentTR.aspx">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #47ae6f;">
                                    <div class="stat-icon"><i class="fa f1"></i></div>
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_wdzw" runat="server" Text="" Style="font-size: 28px;"></asp:Label><span>条</span></h2>
                                    <h5>未读政务</h5>
                                </div>
                            </div>
                        </a>

                        <a href="office/LeaveList.aspx">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #98cd01;">
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_jsqj" runat="server" Text="Label" Style="font-size: 28px;"></asp:Label>
                                        <span>条</span></h2>
                                    <h5>教师请假</h5>
                                    <div class="stat-icon"><i class="fa f2"></i></div>
                                </div>
                            </div>
                        </a>
                        <a href="cms/NewsAuditList.aspx">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #febe17;">
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_wzsh" runat="server" Text="" Style="font-size: 28px;"></asp:Label>
                                        <span>条</span></h2>
                                    <h5>新闻审核</h5>
                                    <div class="stat-icon"><i class="fa f3"></i></div>
                                </div>
                            </div>
                        </a>
                        <%--<a href="#">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #febe17;">
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_xsqj" runat="server" Text="" Style="font-size: 28px;"></asp:Label>
                                        <span>条</span></h2>
                                    <h5>学生请假</h5>
                                    <div class="stat-icon"><i class="fa f3"></i></div>
                                </div>
                            </div>
                        </a>--%>

                        <a href="#">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #03acef;">
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_dkjl" runat="server" Text="" Style="font-size: 28px;"></asp:Label>
                                        <span>条</span></h2>
                                    <h5>代课记录</h5>
                                    <div class="stat-icon"><i class="fa f4"></i></div>
                                </div>
                            </div>
                        </a>

                        <a href="assetmanage/RepairPeopleList.aspx?flag=1">
                            <div class="dashboard-stats">
                                <div class="dashboard-stats-item" style="background-color: #2f63d0; margin-right: 0px">
                                    <h2 class="m-top-none">
                                        <asp:Label ID="lbl_bxjl" runat="server" Text="" Style="font-size: 28px;"></asp:Label>
                                        <span>条</span></h2>
                                    <h5>报修记录</h5>
                                    <div class="stat-icon"><i class="fa f5"></i></div>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>

            <div class="rows" style="margin-bottom: 0.8%; overflow: hidden;">
                <div style="float: right; width: 33%;">
                    <div style="height: 230px; border: 1px solid #e6e6e6; background-color: #fff;">
                        <div class="listdiv">
                            <div class="topdiv tzgg">
                                <i></i><span>校内通知</span>
                                <div class="csbtn">
                                    <ul>
                                        <li><a href="oamanage/AfficheAcceptManage.aspx" class="menuItem" data-id="90003">更多>></a></li>
                                        <li><a href="oamanage/AfficheEdit.aspx" class="menuItem" data-id="90003">
                                            <img src="images/fhc_75.png" title="添加"></a></li>
                                    </ul>
                                </div>
                            </div>

                            <ul class="sms-list">
                                <asp:Repeater runat="server" ID="rp_Affice">
                                    <ItemTemplate>
                                        <li>
                                            <a href="oamanage/AfficheDetail.aspx?id=<%# Eval("AID")%>" style="color: black; text-decoration: none">
                                                <span>【<%# Eval("AcceptUserName")%>】</span>
                                                <%#Eval("AfficheTitle").ToString().Length > 18 ? Eval("AfficheTitle").ToString().Substring(0,18)+ "…" :Eval("AfficheTitle")  %>
                                            </a>
                                        </li>


                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <ul class="sms-list" runat="server" id="ul_affice">
                                <li>暂无记录</li>
                            </ul>

                        </div>
                    </div>
                </div>
                <div style="float: left; width: 66%;">
                    <div style="height: 230px; border: 1px solid #e6e6e6; background-color: #fff; padding-bottom: 15px; overflow: hidden; width: 100%">
                        <div class="listdiv">
                            <div class="topdiv gzjh">
                                <i></i><span>工作计划 第<asp:Literal ID="ltl_Weeks" runat="server"></asp:Literal>周</span>
                                <div class="csbtn">
                                    <ul>
                                        <li><a href="office/WorkPlanManage.aspx" data-id="90001" class="menuItem">更多>></a></li>
                                        <li><a href="office/WorkPlanEdit.aspx" data-id="90002" class="menuItem"><span style="display: none;">本周计划</span><img src="images/fhc_75.png" title="添加"></a></li>
                                    </ul>
                                </div>
                            </div>
                            <table width="100%" class="Mtable" id="weekplan" border="0" cellspacing="0" cellpadding="0">
                                <tr class="title">
                                    <th style="width: 4em;">负责部门</th>
                                    <th style="width: 4em;">负责人</th>
                                    <th style="width: 13em;">内容</th>
                                    <th style="width: 10em;">参与人员</th>
                                    <th style="width: 8em;">结束日期</th>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("DepName")%></td>
                                            <td><%# Eval("DutyUserName")%></td>
                                            <td title="<%# Eval("ExamName")%>"><%#Eval("ExamName").ToString().Length>15?Eval("ExamName").ToString().Substring(0,14):Eval("ExamName").ToString()%></td>
                                            <td title="<%# Eval("AllUsers")%>"><%#Eval("AllUsers").ToString().Split(',').Length>2?Eval("AllUsers").ToString().Split(',')[0]+","+Eval("AllUsers").ToString().Split(',')[1]+"…":Eval("AllUsers").ToString()%></td>
                                            <td><%#Eval("EndDate","{0:yyyy-MM-dd}")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="rows" style="overflow: hidden;">
                <div style="float: left; width: 100%;">
                    <div style="border: 1px solid #e6e6e6; background-color: #fff;">
                        <div class="listdiv" style="margin-bottom: 15px;">
                            <div class="topdiv xlbw">
                                <i></i><span>我的课表</span>
                            </div>

                            <asp:Table ID="tab" runat="server" Width="100%" border="0" CellPadding="0" CellSpacing="0" class="xltab"></asp:Table>

                        </div>
                        <div style="clear: both"></div>
                    </div>
                </div>
            </div>
        </div>
        <style></style>
    </form>
</body>

    



</html>
