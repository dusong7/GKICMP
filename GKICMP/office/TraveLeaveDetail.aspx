<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraveLeaveDetail.aspx.cs" Inherits="GKICMP.office.TraveLeaveDetail" %>

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
                        <th colspan="4" align="left">外出登记信息
                        </th>
                    </tr>
                    <tr>
                        <td width="110px" align="right">登记人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LeaveUser" runat="server"></asp:Literal>
                        </td>

                        <td width="110px" align="right">外出日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BeginDate" runat="server"></asp:Literal>   至    
                            <asp:Literal ID="ltl_EndDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="110px" align="right">天数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LeaveDays" runat="server"></asp:Literal>
                        </td>
                         <td width="110px" align="right">课程是否已安排：</td>
                        <td align="left" >
                            <asp:Literal ID="ltl_IsOK" runat="server"></asp:Literal>
                        </td>

                       
                    </tr>
                    <tr runat="server" id="trIsOK">
                        <td width="110px" align="right">状态：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LeaveState" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">申请时间：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LeaveDate" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">申请材料： </td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("LeaveFile") %>' CommandName="load"
                                                    runat="server"><%# getFileName(Eval("LeaveFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">事由： </td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_LeaveMark" runat="server" Text=""></asp:Literal>
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
                                                <%--<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>--%>
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


