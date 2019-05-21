<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleDetail.aspx.cs" Inherits="GKICMP.vehicle.VehicleDetail" %>

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
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">车辆信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">车辆名称：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_VehicleName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">金额：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Vcash" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">座位数：</td>
                        <td align="left">
                            <asp:Label ID="lbl_CSeatNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">车辆类型：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Vtype" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">&nbsp;状态：</td>
                        <td align="left">
                            <asp:Label ID="lbl_VState" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">购置日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_BuyDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">车牌照：</td>
                        <td align="left">
                            <asp:Label ID="lbl_VehicleCode" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">车辆配置：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_VConfig" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_VDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



