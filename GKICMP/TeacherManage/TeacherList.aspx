<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="GKICMP.teachermanage.TeacherList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <style>
        .cus-height li {
            border-bottom: 1px solid #ccc;
            line-height: 40px;
        }

            .cus-height li:last-child {
                border-bottom: none;
            }

        .cus-height .progress {
            margin-top: 18px;
            margin-right: 40px;
            border-radius: 4px;
        }
    </style>
    <script>

        //$(function () {

        //    $('#drpAge').combotree({
        //        data: [{
        //            "id": "", "text": "选择全部",
        //            "children": [{ "id": 1, "text": "25岁以下" },
        //                         { "id": 2, "text": "26-30" },
        //                         { "id": 3, "text": "31-35" },
        //                         { "id": 4, "text": "36-40" },
        //                         //{ "id": "SAge41", "text": "36-40" },
        //                         { "id": 5, "text": "41-45" },
        //                         { "id": 6, "text": "46-50" },
        //                         { "id": 7, "text": "51-55" },
        //                         { "id": 8, "text": "56-60" }
        //            ]
        //        }],
        //        multiple: true,
        //        multiline: true,
        //        //editable: true
        //    });
        //});
    </script>
    <link href="../assets/css/style.css" rel='stylesheet' type='text/css' />
    <link href="../assets/css/icons.css" rel="stylesheet" />
    <!-- jQueryUI -->
    <link href="../assets/css/sprflat-theme/jquery.ui.all.css" rel="stylesheet" />
    <!-- Bootstrap stylesheets (included template modifications) -->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <!-- Plugins stylesheets (all plugin custom css) -->
    <link href="../assets/css/plugins.css" rel="stylesheet" />
    <!-- Main stylesheets (template main css file) -->
    <link href="../assets/css/main.css" rel="stylesheet" />
    <!-- Custom stylesheets ( Put your own changes here ) -->
    <!--<link href="../assets/css/custom.css" rel="stylesheet" />-->
    <meta name="msapplication-TileColor" content="#3399cc" />



    <script>
        function XFSetValues() {
            //var val = $('#DepartList').combotree('getValues');
            //document.getElementById("hf_SelectedValue").value = val;
            var valage = $('#drpAge').combotree('getValues');
            document.getElementById("hf_Age").value = valage;
            // alert(valage);
        }

    </script>

    <style>
        .searclass .wxz, .searclass .yxz {
            float: left;
        }

        .searclass span {
            display: block;
            float: left;
            width: auto;
            line-height: 20px;
            margin-left: 3px;
            margin-right: 5px;
        }

        .auto-style1 {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_Age" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教师简明情况统计表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent">

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>

                    <tr>
                        <td align="right" width="60">是否在编：</td>
                        <td>
                            <div class="sel" style="float: left">
                                <asp:DropDownList runat="server" ID="ddl_TState">
                                    <asp:ListItem Value="-2">--请选择--</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </td>
                        <td align="right" width="60">年龄结构：</td>
                        <td>
                            <asp:TextBox ID="txt_Age" runat="server" Style="width: 70%;" multiple="true" multiline="true" url="../ashx/age.ashx" class="easyui-combotree"></asp:TextBox>
                            <%--      <input id="drpAge" name="drpAge" style="width: 90%; height: 48px" multiple="true" ,multiline="true" , url="../ashx/age.ashx"  class="easyui-combotree" />--%>

                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
                            <%--<asp:Button ID="Button2" runat="server" CssClass="btn" Text="查询" OnClientClick="XFSetValues()" OnClick="btn_Query_Click" />--%>
                        </td>
                        <%-- <td align="right">年龄：</td>
                        <td>
                            <asp:TextBox Width="35" ID="txt_SAge" runat="server"></asp:TextBox>--
                            <asp:TextBox Width="35" ID="txt_EAge" runat="server"></asp:TextBox>
                        </td>


                        <td align="right">专业技术职务：</td>
                        <td>
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_CurrentPro" runat="server"></asp:DropDownList>
                            </div>

                        </td>--%>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0" id="excel" runat="server">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="left"></td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border='0' cellspacing='0' cellpadding="0" class='listinfoc'>
                <tbody>
                    <tr>
                        <th style="text-align: center" rowspan="2">序号</th>
                        <th style="text-align: center" rowspan="2">单位</th>
                        <th style="text-align: center" rowspan="2">实有<br />
                            在编<br />
                            教师数</th>
                        <th style="text-align: center" rowspan="2">实<br />
                            有<br />
                            人</th>
                        <th style="text-align: center" rowspan="2">专<br />
                            任<br />
                            教</th>
                        <th style="text-align: center" colspan="4">专科学历构成</th>
                        <th style="text-align: center" colspan="6">专业技术职务</th>
                        <th style="text-align: center" colspan="8" runat="server" id="td_Age">年龄结构</th>
                        <%--<th align="center" colspan="16">教授科目结构</th>--%>
                        <th style="text-align: center" rowspan="2">女教<br />
                            师数</th>
                        <th style="text-align: center" rowspan="2">男教<br />
                            师数</th>
                        <th style="text-align: center" rowspan="2">退休<br />
                            教师<br />
                            数</th>

                    </tr>
                    <tr>
                        <th style="text-align: center">研究生</th>
                        <th style="text-align: center">本科</th>
                        <th style="text-align: center">大专</th>
                        <th style="text-align: center">中师</th>

                        <th style="text-align: center">正高级</th>
                        <th style="text-align: center">高级</th>
                        <th style="text-align: center">一级</th>
                        <th style="text-align: center">二级</th>
                        <th style="text-align: center">三级</th>
                        <th style="text-align: center">未定级</th>
                        <% if (ViewState["SAge25"].ToString().Trim() != "")
                           {
                        %>

                        <th style="text-align: center">25岁及以下</th>
                        <%} %>


                        <% if (ViewState["SAge26"].ToString().Trim() != "")
                           {
                        %>
                        <th style="text-align: center">26-30</th>
                        <%} %>
                        <% if (ViewState["SAge31"].ToString().Trim() != "")
                           {
                        %>
                        <th style="text-align: center">31-35</th>
                        <% } if (ViewState["SAge36"].ToString().Trim() != "")
                           {
                        %>
                        <th style="text-align: center">36-40</th>
                        <% 
                            } if (ViewState["SAge41"].ToString().Trim() != "")
                           {
                        %>
                        <th style="text-align: center">41-45</th>
                        <%} if (ViewState["SAge46"].ToString().Trim() != "")
                           {%>
                        <th style="text-align: center">46-50</th>
                        <%} if (ViewState["SAge51"].ToString().Trim() != "")
                           { %>
                        <th style="text-align: center">51-55</th>
                        <% } %>
                        <% if (ViewState["SAge56"].ToString().Trim() != "")
                           { %>
                        <th style="text-align: center">56-60</th>
                        <%} %>
                        <%-- <th align="center">语文</th>
                        <th align="center">数学</th>
                        <th align="center">英语</th>
                        <th align="center">音乐</th>
                        <th align="center">体育</th>
                        <th align="center">美术</th>
                        <th align="center">思想品德</th>
                        <th align="center">科学</th>
                        <th align="center">心理健康</th>
                        <th align="center">信息技术</th>
                        <th align="center">综合实践</th>
                        <th align="center">物理</th>
                        <th align="center">化学</th>
                        <th align="center">生物</th>
                        <th align="center">历史</th>
                        <th align="center">地理</th>--%>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td><%#Container.ItemIndex + 1%></td>
                                <td><%#Eval("DW")%></td>
                                <td><%#Eval("SYZB")%></td>
                                <td align="center"><%#Eval("SYR") %></td>
                                <td align="center"><%#Eval("ZRJ") %></td>
                                <td align="center"><%#Eval("YJS") %></td>
                                <td align="center"><%#Eval("BK") %></td>
                                <td align="center"><%#Eval("DZ") %></td>
                                <td align="center"><%#Eval("ZS") %></td>
                                <td align="center"><%#Eval("ZGJ") %></td>
                                <td align="center"><%#Eval("GJ") %></td>
                                <td align="center"><%#Eval("YJ") %></td>
                                <td align="center"><%#Eval("EJ") %></td>
                                <td align="center"><%#Eval("SJ") %></td>
                                <td align="center"><%#Eval("WD") %></td>
                                <% if (ViewState["SAge25"].ToString().Trim() != "")
                                   {
                                %>

                                <td align="center"><%#Eval("S25") %></td>
                                <% } if (ViewState["SAge26"].ToString().Trim() != "")
                                   {
                                %>
                                <td align="center"><%#Eval("S26") %></td>
                                <% } if (ViewState["SAge31"].ToString().Trim() != "")
                                   { %>
                                <td align="center"><%#Eval("S31") %></td>
                                <%} if (ViewState["SAge36"].ToString().Trim() != "")
                                   {%>
                                <td align="center"><%#Eval("S36") %></td>
                                <% } if (ViewState["SAge41"].ToString().Trim() != "")
                                   { %>
                                <td align="center"><%#Eval("S41") %></td>
                                <% } if (ViewState["SAge46"].ToString().Trim() != "")
                                   { %>
                                <td align="center"><%#Eval("S46") %></td>
                                <% } if (ViewState["SAge51"].ToString().Trim() != "")
                                   { %>
                                <td align="center"><%#Eval("S51") %></td>
                                <% } if (ViewState["SAge56"].ToString().Trim() != "")
                                   { %>
                                <td align="center"><%#Eval("S56") %></td>
                                <%} %>
                                <%--  <td align="center"><%#Eval("YW") %></td>
                                <td align="center"><%#Eval("SX") %></td>
                                <td align="center"><%#Eval("yy") %></td>
                                <td align="center"><%#Eval("music") %></td>
                                <td align="center"><%#Eval("ty") %></td>
                                <td align="center"><%#Eval("ms") %></td>
                                <td align="center"><%#Eval("sxpd") %></td>
                                <td align="center"><%#Eval("kx") %></td>
                                <td align="center"><%#Eval("xljk") %></td>
                                <td align="center"><%#Eval("xxjs") %></td>
                                <td align="center"><%#Eval("zhsj") %></td>
                                <td align="center"><%#Eval("wl") %></td>
                                <td align="center"><%#Eval("hx") %></td>
                                <td align="center"><%#Eval("sw") %></td>
                                <td align="center"><%#Eval("ls") %></td>
                                <td align="center"><%#Eval("dl") %></td>--%>
                                <td align="center"><%#Eval("NJSS") %></td>
                                <td align="center"><%#Eval("NanJSS") %></td>
                                <td align="center"><%#Eval("TXRS") %></td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr_null" runat="server">
                        <td colspan="26" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltl_NL" runat="server"></asp:Literal>
        <div id="content" style="margin-left: 0;">
            <div class="content-wrapper">
                <div class="outlet">
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <div class="panel panel-default toggle">
                                <div class="panel-heading" style="background: #48bd81">
                                    <h4 class="panel-title"><i class="im-pie"></i>教师年龄结构</h4>
                                </div>
                                <div class="panel-body">
                                    <div id="donut-chart" style="width: 100%; height: 250px;"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12">
                            <div class="panel panel-default toggle">
                                <div class="panel-heading" style="background: #48bd81">
                                    <h4 class="panel-title"><i class="im-bars"></i>学历结构</h4>
                                </div>
                                <div class="panel-body">
                                    <div id="ordered-bars-chart" style="width: 100%; min-height: 250px;"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12">
                            <div class="panel panel-default toggle">
                                <div class="panel-heading" style="background: #48bd81">
                                    <h4 class="panel-title"><i class="im-bars"></i>在编比例</h4>
                                </div>
                                <div class="panel-body">
                                    <div id="ordered-bars-chart1" style="width: 100%; min-height: 250px;">
                                        <ul class="list-unstyled cus-height" id="tstate">
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <%-- <div class="clearfix"></div>--%>
            <%-- <div id="container" style="min-width:400px;height:400px"></div>--%>
        </div>
        <asp:Literal ID="ltl_JQuery" runat="server"></asp:Literal>
        <script src="../assets/js/jquery-1.8.3.min.js"></script>

        <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
        <script src="../assets/js/bootstrap/bootstrap.js"></script>
        <script src="../assets/js/jRespond.min.js"></script>
        <script src="../assets/js/core/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../assets/js/core/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
        <script src="../assets/js/forms/autosize/jquery.autosize.js"></script>
        <script src="../assets/js/core/quicksearch/jquery.quicksearch.js"></script>
        <script src="../assets/js/bootbox.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.pie.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.resize.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.time.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.growraf.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.categories.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.stack.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.orderBars.js"></script>
        <script src="../assets/js/charts/flot/jquery.flot.tooltip.min.js"></script>
        <script src="../assets/js/charts/flot/date.js"></script>
        <script src="../assets/js/charts/sparklines/jquery.sparkline.js"></script>
        <script src="../assets/js/charts/pie-chart/jquery.easy-pie-chart.js"></script>
        <script src="../assets/js/forms/icheck/jquery.icheck.js"></script>
        <script src="../assets/js/forms/tags/jquery.tagsinput.min.js"></script>
        <script src="../assets/js/forms/tinymce/tinymce.min.js"></script>
        <script src="../assets/js/highlight.pack.js"></script>
        <script src="../assets/js/jquery.countTo.js"></script>

        <script src="../assets/js/jquery.sprFlat.js"></script>
        <script src="../assets/js/app.js"></script>
        <script src="../assets/js/pages/charts.js"></script>
    </form>
</body>
</html>
