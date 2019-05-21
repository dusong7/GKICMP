<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAllocationDetail.aspx.cs" Inherits="GKICMP.assetmanage.AssetAllocationDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal ID="ltl_bt" runat="server"></asp:Literal></th>
                    </tr>
                    <div id="div1" runat="server">
                        <tr>
                            <td align="right">移交人：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_OutUser"></asp:Literal>
                            </td>
                            <td align="right" width="90">接收人：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_AcceptUser"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">调出单位：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_OutDep"></asp:Literal>
                            </td>
                            <td align="right" width="90">调入单位：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_InDep"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">调拨日期：</td>
                            <td align="left" colspan="3">
                                <asp:Literal runat="server" ID="ltl_AllocationDate"></asp:Literal>
                            </td>

                        </tr>
                    </div>
                    <div id="div2" runat="server">
                        <tr>
                            <td align="right" width="160">接收单位：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_AcceptDep"></asp:Literal>
                            </td>
                            <td align="right">退回日期：</td>
                            <td align="left">
                                <asp:Literal runat="server" ID="ltl_Data"></asp:Literal>
                            </td>
                        </tr>
                    </div>
                    <tr>
                        <td align="right" width="160">创建人：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CreaterUser"></asp:Literal>
                        </td>
                        <td align="right">创建日期：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">资产信息：<br />
                        </td>
                        <td colspan="3">
                            <table width="99%" style="border: 1px">
                                <tr style="text-align: center; color: #2b8e48; font-weight: bold; width: 20%">
                                    <td>资产名称</td>
                                    <td>数量
                                    </td>
                                    <td>计量单位
                                    </td>
                                    <td>评估净值(元)
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("AccName") %></td>
                                            <td align="center"><%#Eval("AccNum") %></td>
                                            <td align="center"><%#Eval("AccUnitName") %></td>
                                            <td align="center"><%#Eval("AccountCash") %></td>

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
                        <td align="right">说明：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_AllDesc"></asp:Literal>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="4">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




