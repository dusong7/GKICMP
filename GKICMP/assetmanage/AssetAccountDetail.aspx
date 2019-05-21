<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAccountDetail.aspx.cs" Inherits="GKICMP.assetmanage.AssetAccountDetail" %>

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
        <asp:HiddenField runat="server" ID="hf_AAID" />
        <div class="listcent pad0" id="mainContent">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">资产盘点详细信息</th>
                    </tr>
                    <tr>
                        <td align="right">负责人：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_AccDuty"></asp:Literal>
                        </td>
                        <td align="right" width="90">盘点日期：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_AccBegin"></asp:Literal>--   
                            <asp:Literal runat="server" ID="ltl_AccEnd"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">主要成员：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_AccGroup"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            盘点类型：
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_AAFlag"></asp:Literal>
                        </td>
                        <td align="right">
                            盘点部门：
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_DepID"></asp:Literal>
                        </td>
                    </tr>
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
                        <td align="right">有账无物：</td>
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
                                <asp:Repeater runat="server" ID="rp_List1">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("AccName") %></td>
                                            <td align="center"><%#Eval("AccNum") %></td>
                                            <td align="center"><%#Eval("AccUnitName") %></td>
                                            <td align="center"><%#Eval("AccountCash") %></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null1">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">有物无账：</td>
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
                                <asp:Repeater runat="server" ID="rp_List2">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("AccName") %></td>
                                            <td align="center"><%#Eval("AccNum") %></td>
                                            <td align="center"><%#Eval("AccUnitName") %></td>
                                            <td align="center"><%#Eval("AccountCash") %></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null2">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">固定资产清查情况说明：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_AccDesc"></asp:Literal>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="4">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                            <asp:Button ID="btn_Download" runat="server" Text="下载" CssClass="submit" OnClick="btn_Download_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



