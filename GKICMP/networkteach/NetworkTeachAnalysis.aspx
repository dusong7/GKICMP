<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetworkTeachAnalysis.aspx.cs" Inherits="GKICMP.networkteach.NetworkTeachAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>资源管理平台</title>
    <link rel="icon" href="../gzimages/yghd_favicon.ico" type="image/x-icon" />
    <link href="../css/rourcecss.css" rel="stylesheet" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <script src="../js/echarts.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
</head>
<body>
    <form runat="server" id="form1">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="网络课程管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="100" align="right">创建日期：</td>
                        <td width="60%">
                            <asp:TextBox runat="server" ID="txt_BeginDate" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                        <asp:TextBox runat="server" ID="txt_EndDate" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td id="xz">
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <div class="zy-chart listcss zy-mt-10">
                <%--<div class="titlecss">网络课程总量</div>
                <div style="width: 480px; height: 400px; float: left; margin-top: 10px">
                    <div id="main1" style="width: 480px; height: 400px;"></div>
                </div>--%>
                <div style="width: 90%; height: 400px; padding-left: 20px; margin-top: 10px; box-sizing: border-box; border-left: 1px dashed #ABABAB; float: left">
                    <div id="main2" style="width: 90%; height: 400px; text-align: center;"></div>
                </div>
            </div>
            <div class="zy-ranking listcss">
                <div class="zy-ranking-title titlecss">
                    <span style="float: left; margin-left: 10px">教师排行榜</span><span style="float: right; margin-right: 10px">
                        <%--<asp:Literal runat="server" ID="ltl_Year"></asp:Literal>学年本学期--%></span>
                </div>
                <div class="zy-ranking-list">
                    <asp:Literal runat="server" ID="ltl_Content"></asp:Literal>
                    <%--<table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tbody>
                            <tr>
                                <th>教师</th>
                                <th colspan="10">上传情况</th>
                            </tr>
                            <tr>
                                <td rowspan="2" style="border-top:1px solid #f6fafd;"><a href="#"><span>1</span>【校长室】王小明</a></td>
                                <td align="center">语文</td>
                                <td align="center">数学</td>
                                <td align="center">英语</td>
                                <td align="center">化学</td>
                            </tr>
                            <tr>
                                <td align="center">1</td>
                                <td align="center">2</td>
                                <td align="center">3</td>
                                <td align="center">4</td>
                            </tr>
                            <tr>
                                <td rowspan="2" style="border-top:1px solid #f6fafd;"><a href="#"><span>1</span>【校长室】王小明</a></td>
                                <td align="center" style="border-top:1px solid #f6fafd;border-left:1px solid #f6fafd;">语文</td>
                                <td align="center" style="border-top:1px solid #f6fafd;border-left:1px solid #f6fafd;">数学</td>
                                <td align="center" style="border-top:1px solid #f6fafd;border-left:1px solid #f6fafd;">英语</td>
                                <td align="center" style="border-top:1px solid #f6fafd;border-left:1px solid #f6fafd;">化学</td>
                            </tr>
                            <tr>
                                <td align="center">1</td>
                                <td align="center">2</td>
                                <td align="center">3</td>
                                <td align="center">4</td>
                            </tr>
                        </tbody>
                    </table>--%>
                </div>
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

