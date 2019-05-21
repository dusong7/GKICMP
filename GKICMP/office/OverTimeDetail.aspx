<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeDetail.aspx.cs" Inherits="GKICMP.office.OverTimeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <%-- <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">加班信息
                        </th>
                    </tr>
                    <tr>
                        <td width="90px" align="right">申请人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ApplyUser" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">加班类型：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">开始日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BeginDate" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">结束日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EndDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">天数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ODays" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">状态：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr >
                        <td width="110px" align="right">参与人员：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_UsersName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">加班事由： </td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_OMark" runat="server" Text=""></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">审核信息
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rp_List" runat="server">
                                    <ItemTemplate>
                                        <%
                                            if (count > 1)
                                            {   %>
                                        <tr>
                                            <td colspan="4"><%# Container.ItemIndex.ToString()=="0"?"第一":Container.ItemIndex.ToString()=="1"?"第二":Container.ItemIndex.ToString()=="2"?"第三":Container.ItemIndex.ToString()=="3"?"第四":"第五" %>审核人</td>
                                        </tr>
                                        <%} %>
                                        <tr>
                                            <td width="100px" align="center">审核人
                                            </td>
                                            <td>
                                                <%#Eval("RealName")%>
                                            </td>
                                            <td width="100px" align="center">审核日期
                                            </td>
                                            <td>
                                                <%#Eval("AuditDate", "{0:yyyy-MM-dd HH:mm}")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">审核结果
                                            </td>
                                            <td>
                                                  <%#Eval("RealName").ToString().Split(',').Length>1?Eval("AuditResult").ToString()!="1"? (Eval("AuditName")+"&nbsp审核"):"":""%>
                                                <%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>
                                               <%-- <%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>--%>
                                            </td>
                                            <td align="center">审核意见
                                            </td>
                                            <td>
                                                <%#Eval("AuditMark")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr id="trnull" runat="server">
                                    <td colspan="4" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



