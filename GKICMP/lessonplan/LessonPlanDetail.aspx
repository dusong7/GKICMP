<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPlanDetail.aspx.cs" Inherits="GKICMP.lessonplan.LessonPlanDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_Teachers" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">备课计划信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">名称：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_LName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学年：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_LYear"></asp:Literal>
                        </td>
                        <td align="right">学期：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_TID"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">校区：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CID"></asp:Literal>
                        </td>
                        <td align="right">类型：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_LType"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">执教教师：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_Teacher"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">录入人：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateUser"></asp:Literal></td>
                        <td align="right">录入时间：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">备课计划清单信息</th>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <table width="99%" style="border: 1px" id="print">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold;">周次
                                    </td>
                                    <td style="font-weight: bold;">时间
                                    </td>
                                    <td style="font-weight: bold;">活动内容
                                    </td>
                                    <td style="font-weight: bold;">
                                        <asp:Literal runat="server" ID="ltl_TeacherName"></asp:Literal>
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                第<%#Eval("WeekNum") %>周
                                            </td>
                                            <td align="center">
                                                <%#Eval("PDate","{0:yyyy-MM-dd}") %>
                                            </td>
                                            <td align="center">
                                                <%#Eval("AContent") %>
                                            </td>
                                            <td align="center">
                                                <%#Eval("TeacherName") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <input type="button" class="editor" id="return" value="返回" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
