<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverDetail.aspx.cs" Inherits="GKICMP.electiver.ElectiverDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script>
        function viewinfo(e, a) {
            var id = getUrlParam("id");
            var cid = $(e).next().val();
            if (a == 1)
                return openbox('A_id', 'CourseSelectList.aspx', 'flag=1&id=' + id + '&cid=' + cid, 900, 700, 58);
            else
                return openbox('A_id', 'CourseSelectList.aspx', 'flag=2&id=' + id + '&cid=' + cid, 900, 700, 59);
        }

        function back() {
            var id = document.getElementById("hf_SysMUID").value;
            window.location.href = "ElectiverManage.aspx?SysMUID=" + id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <asp:HiddenField ID="hf_SysMUID" runat="server" />
         <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="选课任务"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">任务详情信息
                        </th>
                    </tr>
                    <tr>
                        <td width="90px" align="right">任务名称：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_ElectiverName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">学年度：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EYear" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">学期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TermID" runat="server"></asp:Literal>
                        </td>


                    </tr>
                    <tr>
                        <td width="90px" align="right">报名开始日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EBegin" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">报名结束日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EEnd" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td width="90px" align="right">预选开始日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EstimateBDate" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">预选结束日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EstimateEDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>

                        <td width="90px" align="right">任务结束日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EStopDate" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">任务状态：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_EState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">创建人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CreateUser" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">创建时间：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" colspan="4">课程信息：</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="99%" id="tb_Right" style="border: 1px">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold;">课程</td>
                                    <td style="font-weight: bold;">等级</td>
                                    <td style="font-weight: bold;">人数</td>
                                    <td style="font-weight: bold;">已选</td>
                                    <td style="font-weight: bold;">操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("CourseName")%></td>
                                            <td align="center"><%#Eval("ClevelName") %></td>
                                            <td align="center"><%#Eval("MaxCount") %></td>
                                            <td align="center"><%#Eval("DY") %></td>
                                            <td align="center">
                                                <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="选课名单" OnClientClick='return viewinfo(this,1);'>选课名单</asp:LinkButton>
                                                <asp:HiddenField ID="HiddenField1" Value='<%#Eval("CourseID") %>' runat="server" />
                                                <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="退课名单" OnClientClick='return viewinfo(this,2);'>退课名单</asp:LinkButton>
                                                <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("CourseID") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="return back();" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




