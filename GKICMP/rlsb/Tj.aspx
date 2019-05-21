<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tj.aspx.cs" Inherits="GKICMP.rlsb.Tj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
   <%-- <link href="../css/rourcecss.css" rel="stylesheet" />--%>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/echarts.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script>
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AttendSetEdit.aspx', 'id=' + id, 960, 400, 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                         <td align="right" width="60">
                            打卡日期：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_MBegin" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--<asp:TextBox ID="txt_MEnd" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                         <td align="right" width="60">
                            考勤节点：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_Attend" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">
                            类型：</td>
                        <td width="299">
                            <asp:RadioButtonList ID="rbl_OutType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">进</asp:ListItem>
                                <asp:ListItem Value="2" >出</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
       <%-- <div class="zy-chart listcss zy-mt-10">--%>
            <div style="width: 480px; height: 400px; margin:0 auto ;">
                <div id="main1" style="width: 480px; height: 400px;"></div>
            </div>
       <%-- </div>--%>
       
        <div class="listcent pad0">
           
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                      
                        <th align="center">姓名</th>
                        <th align="center">未打卡次数</th>
                        <th align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                               
                                 <td><%#Eval("UserName")%></td>
                                <td><%#Eval("cs")%></td>
                                  <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btneditcolor"  ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("nid") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="3">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
        <asp:Literal ID="ltl_EType" runat="server"></asp:Literal>


    </form>
</body>


<%--<script type='text/javascript'>
         var myChart1 = echarts.init(document.getElementById('main1'));
         option1 = {
             title: {
                 text: '类型分布情况',
                 subtext: '',
                 left: 'left'
             },
             tooltip: {
                 trigger: 'item',
                 formatter: '{a} <br/>{b} : {c} ({d}%)'
             },
             legend: {
                 bottom: 10,
                 left: 'center',
                 data: ['课件', '教案']
             }, color:['#CCCCCC','#666699'],
             series: [
                 {
                     type: 'pie',
                     radius: '65%',
                     center: ['50%', '50%'],
                     selectedMode: 'single',
                     data: [{ value: 100, name: 'ceshi' }, { value: 90, name: 'ceshi2' }
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
         if (option1 && typeof option1 === 'object') {
             myChart1.setOption(option1, true);
         }
           //$(function () { load();})
           //$('#Search').click(function () { alert('click') });
           //function load() {
              
           //    jQuery.get("../ashx/StatisticsHandler.ashx?method=GetAttend&b=" + b + "&e=" + e, function (data) {
           //        ihuman = data.ihuman;
           //        ohuman = data.ohuman;
           //        ihuman1 = data.ihuman1;
           //        ohuman1 = data.ohuman1;
           //    }, "json");
           //    var myChart1 = echarts.init(document.getElementById('main1'));
           //    option1 = {
           //        title: {
           //            text: '学生进入情况',
           //            subtext: '',
           //        },
           //        tooltip: {
           //            trigger: 'item',
           //            formatter: '{a} <br/>{b} : {c} ({d}%)'
           //        },
           //        legend: {
           //            bottom: 10,
           //            left: 'center',
           //            data: ['已到', '未到', ]
           //        }, color: ['#CCCCCC', '#666699'],
           //        series: [
           //            {
           //                name: '考勤统计',
           //                type: 'pie',
           //                radius: '65%',
           //                center: ['50%', '50%'],
           //                selectedMode: 'single',
           //                data: [{ value: ihuman, name: '已进入' }, { value: ohuman, name: '未进入' },

           //                ],
           //                itemStyle: {
           //                    emphasis: {
           //                        shadowBlur: 10,
           //                        shadowOffsetX: 0,
           //                        shadowColor: 'rgba(0, 0, 0, 0.5)'
           //                    }
           //                }
           //            }
           //        ]
           //    };
           //    if (option1 && typeof option1 === 'object') {
           //        myChart1.setOption(option1, true);
           //    }
           //    var myChart2 = echarts.init(document.getElementById('main2'));
           //    option2 = {
           //        title: {
           //            text: '学生出去情况',
           //            subtext: '',
           //        },
           //        tooltip: {
           //            trigger: 'item',
           //            formatter: '{a} <br/>{b} : {c} ({d}%)'
           //        },
           //        legend: {
           //            bottom: 10,
           //            left: 'center',
           //            data: ['已出', '未出']
           //        }, color: ['#CCCCCC', '#666699'],
           //        series: [
           //            {
           //                name: '考勤统计',
           //                type: 'pie',
           //                radius: '65%',
           //                center: ['50%', '50%'],
           //                selectedMode: 'single',
           //                data: [
           //                    { value: ihuman1, name: '已进入' }, { value: ohuman1, name: '未进入' },
           //                ],
           //                itemStyle: {
           //                    emphasis: {
           //                        shadowBlur: 10,
           //                        shadowOffsetX: 0,
           //                        shadowColor: 'rgba(0, 0, 0, 0.5)'
           //                    }
           //                }
           //            }
           //        ]
           //    };
           //    if (option2 && typeof option2 === 'object') {
           //        myChart2.setOption(option2, true);
           //    }
           //}
           </script>--%>
</html>
