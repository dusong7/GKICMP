<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierDetail.aspx.cs" Inherits="ICMP.assetmanage.SupplierDetail" %>

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
                        <th colspan="4" align="left">供应商管理</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">供应商名称：</td>
                        <td align="left">
                            <asp:Label ID="lbl_SupplierName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">企业性质</td>
                        <td align="left">
                            <asp:Label ID="lbl_Enterprise" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">业务联系人：</td>
                        <td align="left">
                            <asp:Label ID="lbl_LinkUser" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">联系人职务</td>
                        <td align="left">
                            <asp:Label ID="lbl_LinkPost" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">联系人电话：</td>
                        <td align="left">
                            <asp:Label ID="lbl_LinkPhone" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">主要经营范围</td>
                        <td align="left">
                            <asp:Label ID="lbl_MainAssest" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">开户行：</td>
                        <td align="left">
                            <asp:Label ID="lbl_BankName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">开户账号</td>
                        <td align="left">
                            <asp:Label ID="lbl_BankNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">资信等级：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Qualifications" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">企业法人</td>
                        <td align="left">
                            <asp:Label ID="lbl_Legal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

