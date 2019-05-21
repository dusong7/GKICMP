<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetDetailOffice.aspx.cs" Inherits="GKICMP.assetmanage.AssetDetailOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">
                            办公用品信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">名称</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">数量</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">分类</td>
                        <td align="left">
                            <asp:Label ID="lbl_DataType" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">单价</td>
                        <td align="left">
                            <asp:Label ID="lbl_APrice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">购置时间</td>
                        <td align="left">
                            <asp:Label ID="lbl_BuyDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">所属校区</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_CID" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">规格型号</td>
                        <td align="left">
                            <asp:Label ID="lbl_SpecificationModel" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">品牌</td>
                        <td align="left">
                            <asp:Label ID="lbl_Brand" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">供应商</td>
                        <td align="left">
                            <asp:Label ID="lbl_Suppliers" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">计量单位</td>
                        <td align="left">
                            <asp:Label ID="lbl_AUnit" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">计划使用年限</td>
                        <td align="left">
                            <asp:Label ID="lbl_PlanYear" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">采购人</td>
                        <td align="left">
                            <asp:Label ID="lbl_BuyUser" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">物品描述</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_AssetMark" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
