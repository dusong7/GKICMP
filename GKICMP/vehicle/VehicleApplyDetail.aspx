<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleApplyDetail.aspx.cs" Inherits="GKICMP.vehicle.VehicleApplyDetail" %>

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
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">车辆申请信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">申请人：</td>
                        <td align="left">
                            <asp:Label ID="lbl_ApplyUser" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="100px">申请日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_ApplyDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">出发地点：</td>
                        <td align="left">
                            <asp:Label ID="lbl_BeginAddress" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">目的地：</td>
                        <td align="left">
                            <asp:Label ID="lbl_EndAddress" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">用车开始时间：</td>
                        <td align="left">
                            <asp:Label ID="lbl_BeginDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">&nbsp;用车结束时间：</td>
                        <td align="left">
                            <asp:Label ID="lbl_EndDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">同行人数：</td>
                        <td align="left">
                            <asp:Label ID="lbl_PeerCount" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">状态：</td>
                        <td align="left">
                            <asp:Label ID="lbl_VAState" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_ApplyDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
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
                            <asp:Label ID="lbl_Vstate" runat="server" Text=""></asp:Label>
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
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">审核信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">审核人：</td>
                        <td align="left">
                            <asp:Label ID="lbl_AduitUser" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">审核日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_AduitDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">审核意见：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_AduitMess" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>





