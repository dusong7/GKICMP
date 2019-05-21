<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceDetail.aspx.cs" Inherits="GKICMP.invoice.InvoiceDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_IID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">报销详细信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">报销单位：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_AccountUnit" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100">报销日期：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100">报销类别：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_InvType"></asp:Literal>
                        </td>
                        <td align="right" width="100">报销方式：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_InvModel"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">合计金额：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_TotelCash"></asp:Literal>
                        </td>
                        <td align="right">是否签字：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_IsSign"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">审批人：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_AduitUser"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_InvoiceDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">报销项目：
                        </td>
                        <td colspan="3">
                            <table width="99%" class="border-r">
                                <tr style="text-align: center; color: #2b8e48; font-weight: bold;">
                                    <td style="width: 20%">序号</td>
                                    <td style="width: 20%">摘要
                                    </td>
                                    <td style="width: 20%">张数
                                    </td>
                                    <td style="width: 20%">金额
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List1">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("INum") %></td>
                                            <td align="center"><%#Eval("InvDesc").ToString().Length>20?Eval("InvDesc").ToString().Substring(0,20)+"...":Eval("InvDesc") %></td>
                                            <td align="center"><%#Eval("InvoiceCount") %></td>
                                            <td align="center"><%#Eval("InvoiceCash") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null1">
                                    <td colspan="4" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">附件：</td>
                        <td colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbtn_load" CommandArgument='<%#Eval("AccessID") %>' CommandName="load"
                                                    runat="server"><%# Eval("AccessName")%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">报销审核信息</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="99%" class="border-r">
                                <tr style="text-align: center; color: #2b8e48; font-weight: bold;">
                                    <td style="width: 20%">审核结果</td>
                                    <td style="width: 20%">审核意见</td>
                                    <td style="width: 20%">审核人</td>
                                    <td style="width: 20%">审核时间</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult")) %></td>
                                            <td align="center"><%#Eval("AuditMark") %></td>
                                            <td align="center"><%#Eval("RealName") %></td>
                                            <td align="center"><%#Eval("AuditDate") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4" align="center">暂无信息</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

