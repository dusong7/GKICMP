<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayBackDetail.aspx.cs" Inherits="GKICMP.payment.PayBackDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生缴费登记</th>
                    </tr>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left">
                            <asp:Literal ID="ltl_StuName" runat="server"></asp:Literal></td>
                        <td align="right">缴费日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RegDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">缴费项目</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_PIID"></asp:Literal></td>
                        <td align="right">缴费金额</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RegCount"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">退费记录</td>
                        <td colspan="3">
                            <table width="99%" id="tb_Right" style="border: 1px; margin-top: 10px;">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold; width: 10%">退费金额
                                    </td>
                                    <td style="font-weight: bold; width: 10%">退费日期
                                    </td>
                                    <td style="font-weight: bold; width: 10%">状态
                                    </td>
                                    <td style="font-weight: bold; width: 10%">审核人
                                    </td>
                                    <td style="font-weight: bold; width: 10%">审核日期
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("BackCount") %></td>
                                            <td align="center"><%#Eval("BackDate","{0:yyyy-MM-dd}") %></td>
                                            <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.PraState>( Eval("IsAudit") )%></td>
                                            <td align="center"><%#Eval("AduitUserName") %></td>
                                            <td align="center"><%#Eval("AuditDate","{0:yyyy-MM-dd}") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="4">
                            <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
