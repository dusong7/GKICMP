<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Res_NewMain.aspx.cs" Inherits="GKICMP.resourcesite.Res_NewMain" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>资源管理平台</title>
    <link rel="icon" href="../gzimages/yghd_favicon.ico" type="image/x-icon" />
    <link href="../css/rourcecss.css" rel="stylesheet" />
    <script src="../js/echarts.min.js"></script>
    <style type="text/css">
        body {
            background: url(../images/zy_1.png) center top no-repeat;
        }
    </style>
    <script type="text/javascript">
        //$("#li1").attr("class", "selected");
        function changecss(id) {
            if (id == 1) {
                document.getElementById("li1").className = "selected";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 2) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "selected";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 3) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "selected";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 4) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "selected";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 5) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "selected";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 6) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "selected";
                document.getElementById("li7").className = "";
            }
            else {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "selected";
            }
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
        <div class="headcss">
            <div class="headlogo">
                <img src="../images/zy_2.png">
            </div>
            <div class="headmenu">
                <ul>
                    <%--<li><a href="#">全部</a></li>
                    <li><a href="#">课件</a></li>
                    <li><a href="#">教案</a></li>
                    <li><a href="#">试卷</a></li>
                    <li><a href="#">素材</a></li>
                    <li><a href="#">微课程</a></li>
                    <li><a href="#">其他</a></li>--%>
                    <li class="selected">
                        <a href="Res_NewMain.aspx">首页</a>
                    </li>
                    <li id="li1">
                        <a href="Index.aspx" onclick="changecss(1)">全部</a>
                    </li>
                    <li id="li2">
                        <a href="Index.aspx?RType=1" onclick="changecss(2)">课件</a>
                    </li>
                    <li id="li3">
                        <a href="Index.aspx?RType=2" onclick="changecss(3)">教案</a>
                    </li>
                    <li id="li4">
                        <a href="Index.aspx?RType=3" onclick="changecss(4)">试卷</a>
                    </li>
                    <li id="li5">
                        <a href="Index.aspx?RType=4" onclick="changecss(5)">素材</a>
                    </li>
                    <li id="li6">
                        <a href="Index.aspx?RType=5" onclick="changecss(6)">微课程</a>
                    </li>
                    <li id="li7">
                        <a href="Index.aspx?RType=7" onclick="changecss(7)">其他</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="centcss">
            <div class="zy-block">
                <ul>
                    <li>
                        <img src="../images/rl.png"><span>
                            <h4>
                                <asp:Literal runat="server" ID="ltl_RSize"></asp:Literal></h4>
                            资源总量（MB）</span></li>
                    <li>
                        <img src="../images/sl.png"><span>
                            <h4>
                                <asp:Literal runat="server" ID="ltl_RCount"></asp:Literal></h4>
                            资源数（份）</span></li>
                    <li>
                        <img src="../images/rs.png"><span>
                            <h4>
                                <asp:Literal runat="server" ID="ltl_RUser"></asp:Literal></h4>
                            今日登录人数</span></li>
                </ul>
            </div>
            <div class="zy-chart listcss zy-mt-10">
                <div class="titlecss">资源总量</div>
                <div style="width: 480px; height: 400px; float: left; margin-top: 10px">
                    <div id="main1" style="width: 480px; height: 400px;"></div>
                </div>
                <div style="width: 420px; height: 400px; padding-left: 20px; margin-top: 10px; box-sizing: border-box; border-left: 1px dashed #ABABAB; float: left">
                    <div id="main2" style="width: 520px; height: 400px;"></div>
                </div>
            </div>
            <div class="zy-ranking listcss">
                <div class="zy-ranking-title titlecss">
                    <span style="float: left; margin-left: 10px">教师排行榜</span><span style="float: right; margin-right: 10px">
                        <asp:Literal runat="server" ID="ltl_Year"></asp:Literal>学年本学期</span>
                </div>
                <div class="zy-ranking-list">
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tbody>
                            <tr>
                                <th>教师</th>
                                <th width="65" align="center">总量</th>
                                <th width="65" align="center">课件</th>
                                <th width="65" align="center">教案</th>
                                <th width="65" align="center">试卷</th>
                                <th width="65" align="center">素材</th>
                                <th width="65" align="center">微课程</th>
                                <th width="65" align="center">其他</th>
                            </tr>
                            <asp:Repeater runat="server" ID="rp_TopList">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="#"><span><%#Container.ItemIndex+1 %></span>【<%#Eval("DepName") %>】<%#Eval("UserName") %></a></td>
                                        <td align="center"><%#Eval("RCount") %></td>
                                        <td align="center"><%#Eval("RKJ") %></td>
                                        <td align="center"><%#Eval("RJA") %></td>
                                        <td align="center"><%#Eval("RSJ") %></td>
                                        <td align="center"><%#Eval("RSC") %></td>
                                        <td align="center"><%#Eval("RWKC") %></td>
                                        <td align="center"><%#Eval("RQT") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr runat="server" id="tr_null">
                                <td align="center" colspan="8">暂无记录</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="listcss zy-zxzy" style="width: 490px; float: left">
                <div class="titlecss">最新资源</div>
                <ul>
                    <asp:Repeater runat="server" ID="rp_NewList">
                        <ItemTemplate>
                            <li><a href="Res_Detail.aspx?id=<%#Eval("Erid") %>" target="_blank" title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %>
                                <span>【<%#Eval("CreateUserName") %>】<%#Eval("CreateDate","{0:yyyy-MM-dd}") %></span>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li runat="server" id="li_null" style="text-align: center; line-height: 30px;">暂无记录</li>
                </ul>
            </div>
            <div class="listcss zy-rmzy" style="width: 490px; float: right">
                <div class="titlecss">热门资源</div>
                <ul>
                    <asp:Repeater runat="server" ID="rp_GoodList">
                        <ItemTemplate>
                            <li><a href="Res_Detail.aspx?id=<%#Eval("Erid") %>" target="_blank" title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %>
                                <span>【<%#Eval("CreateUserName") %>】<%#Eval("CreateDate","{0:yyyy-MM-dd}") %></span>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li runat="server" id="li_null1" style="text-align: center; line-height: 30px;">暂无记录</li>
                </ul>
            </div>
        </div>
        <%--<script type="text/javascript">
            // 基于准备好的dom，初始化echarts实例
            var myChart1 = echarts.init(document.getElementById('main1'));
            // 指定图表的配置项和数据
            option1 = {
                title: {
                    text: '类型分布情况',
                    subtext: '',
                    left: 'left'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    // orient: 'vertical',
                    // top: 'middle',
                    bottom: 10,
                    left: 'center',
                    data: ['课件', '教案', '试卷', '素材', '微课程', '在线课堂', '其他']
                },
                series: [
                    {
                        type: 'pie',
                        radius: '65%',
                        center: ['50%', '50%'],
                        selectedMode: 'single',
                        data: [
                            { value: 1548, name: '课件' },
                            { value: 535, name: '教案' },
                            { value: 510, name: '试卷' },
                            { value: 634, name: '素材' },
                            { value: 735, name: '微课程' },
                            { value: 735, name: '在线课堂' },
                            { value: 735, name: '其他' }
                        ],
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        }
                    }
                ]
            };
            if (option1 && typeof option1 === "object") {
                myChart1.setOption(option1, true);
            }


            var myChart2 = echarts.init(document.getElementById('main2'));
            option2 = {
                title: {
                    text: '学科分布情况',
                    subtext: '',
                    left: 'left'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    // orient: 'vertical',
                    // top: 'middle',
                    bottom: 10,
                    left: 'center',
                    data: ['西凉', '益州', '兖州', '荆州', '幽州']
                },
                series: [
                    {
                        type: 'pie',
                        radius: '65%',
                        center: ['50%', '50%'],
                        selectedMode: 'single',
                        data: [
                            {
                                value: 1548,
                                name: '幽州'
                            },
                            { value: 535, name: '荆州' },
                            { value: 510, name: '兖州' },
                            { value: 634, name: '益州' },
                            { value: 735, name: '西凉' }
                        ],
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        }
                    }
                ]
            };
            if (option2 && typeof option2 === "object") {
                myChart2.setOption(option2, true);
            }
            // 使用刚指定的配置项和数据显示图表。
            // myChart.setOption(option);
        </script>--%>
        <asp:Literal runat="server" ID="ltl_EType"></asp:Literal>
        <asp:Literal runat="server" ID="ltl_Subject"></asp:Literal>
    </form>
</body>
</html>
