<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseImportDetail.aspx.cs" Inherits="GKICMP.purchase.PurchaseImportDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/select.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td colspan="6">
                            <h1 style="text-align: center;">
                                <asp:Literal ID="ltl_Year" runat="server"></asp:Literal>年<asp:Literal ID="ltl_Project" runat="server"></asp:Literal>项目供货清单一览表</h1>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="listcent pad0">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                                    <tbody>
                                        <tr>
                                            <%-- <th align="center" >所属学校</th>--%>
                                            <th align="center">资产分类</th>
                                            <th align="center">资产名称</th>
                                            <th align="center">资产编号</th>
                                            <%-- <th align="center">资产数量</th>--%>
                                            <th align="center">品牌</th>
                                            <th align="center">规格型号</th>
                                            <th align="center">计量单位</th>
                                            <th align="center">物品单价</th>
                                            <th align="center">数量</th>
                                            <th align="center">供应商</th>
                                            <th align="center">购置时间</th>
                                            <th align="center">计划使用年限</th>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rp_List">
                                            <ItemTemplate>
                                                <tr>
                                                    <%-- <td align="center"><%#Eval("SchoolName")%></td>--%>
                                                    <td align="center"><%#Eval("TypeName")%></td>
                                                    <td align="center"><%#Eval("AssetName")%></td>
                                                    <td align="center"><%#Eval("DataDesc")%></td>
                                                    <%--<td><%#Eval("AssetNum")%></td>--%>
                                                    <td align="center"><%#Eval("Brand")%></td>
                                                    <td align="center"><%#Eval("SpecificationModel")%></td>
                                                    <td align="center"><%#Eval("AUnitName")%></td>
                                                    <td align="center"><%#Eval("APrice")%></td>
                                                    <td align="center"><%#Eval("AssetNum")%></td>
                                                    <td align="center"><%#Eval("SuppliersName")%></td>
                                                    <td align="center"><%#Eval("BuyDate","{0:yyyy-MM-dd}")%></td>
                                                    <td align="center"><%#Eval("PlanYear")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr runat="server" id="tr_null">
                                            <td colspan="11" align="center">暂无记录</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div style="text-align: right">
                                <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

