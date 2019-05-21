<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriverDetail.aspx.cs" Inherits="GKICMP.vehicle.DriverDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">司机信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">司机名称：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_RealName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">性别：</td>
                        <td align="left">
                            <asp:Label ID="lbl_UserSex" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">出生日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Birthday" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">手机号码：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Cellphone" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">&nbsp;驾驶证号：</td>
                        <td align="left">
                            <asp:Label ID="lbl_DriverCode" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">初次领证日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_FristGetDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">准驾车型：</td>
                        <td align="left">
                            <asp:Label ID="lbl_SType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_DDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




