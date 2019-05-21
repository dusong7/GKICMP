<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeriesWageDetail.aspx.cs" Inherits="GKICMP.payment.SeriesWageDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="工资信息"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <div id="t3" runat="server">
                        <tr>
                            <td align="right" width="120px;">姓名</td>
                            <td align="left" colspan="3">
                                <asp:Literal ID="ltl_TIDName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td align="right">年份</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_WYear"></asp:Literal></td>
                            <td align="right">月份</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_WMonth"></asp:Literal>
                            </td>
                        </tr>
                    </div>
                    <div id="t1" runat="server">
                        <tr>
                            <td align="right">岗位工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_PostWage"></asp:Literal></td>
                            <td align="right">薪级工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_SalaryScale"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">教龄津贴</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Allowance"></asp:Literal></td>
                            <td align="right">教护</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_TeachNursing"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">基础性绩效工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_BasicPay"></asp:Literal></td>
                            <td align="right">奖励性绩效工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Rewarding"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">提租补贴</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_RentalFee"></asp:Literal></td>
                            <td align="right">20%工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Serious"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">应发小计</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_ShouldWage"></asp:Literal></td>
                            <td align="right">公积金</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Accumulation"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">失业保险</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Unemployment"></asp:Literal></td>
                            <td align="right">医保费</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_MedicalFee"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">养老保险</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Insurance"></asp:Literal></td>
                            <td align="right">工会费</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Union"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">考核工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_AssessWage"></asp:Literal></td>
                            <td align="right">个人所得税</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Income"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">代扣小计</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Withhold"></asp:Literal></td>
                            <td align="right">实发工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_ActualWages"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">备注</td>
                            <td align="left" colspan="3">
                                <asp:Literal runat="server" ID="ltl_WDesc"></asp:Literal></td>
                        </tr>
                    </div>
                    <div id="t2" runat="server">
                        <tr>
                            <td align="right">基本工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_jbgz"></asp:Literal></td>
                            <td align="right">岗位工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_gwgz"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">学历工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_xlgz"></asp:Literal></td>
                            <td align="right">上月绩效工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_syjxgz"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">应发工资</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_yfgz"></asp:Literal></td>
                            <td align="right">养老保险</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_ylbx"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">住房公积金</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_zfgjj"></asp:Literal></td>
                            <td align="right">失业保险</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_sybx"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">大病救助</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_dbjz"></asp:Literal></td>
                            <td align="right">医保</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_yb"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">代扣小计</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_dkxj"></asp:Literal></td>
                            <td align="right">工会扣除</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_ghkc"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">实发工资</td>
                            <td align="left" colspan="3">
                                <asp:Literal runat="server" ID="ltl_sfgz"></asp:Literal></td>
                        </tr>
                    </div>
                    <tr id="tr3" runat="server">
                        <td colspan="4" style='color: red; font-size: 14px; text-align: center;'>暂无数据</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
