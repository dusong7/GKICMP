<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleEdit.aspx.cs" Inherits="GKICMP.vehicle.VehicleEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">车辆信息</th>
                    </tr>
                    <tr>
                        <td align="right">车辆名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_VehicleName" runat="server" Width="600" datatype="*" nullmsg="请输入车辆名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">金额：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Vcash" runat="server" datatype="sum" nullmsg="请填写金额"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">座位数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CSeatNum" runat="server" datatype="zheng" nullmsg="请填写座位数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">车辆类型：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Vtype" datatype="ddl" errormsg="请选择车辆类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>

                        <td align="right">状态：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_VState" datatype="ddl" errormsg="请选择状态"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">购置日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BuyDate" runat="server" datatype="*" nullmsg="请选择购置日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                          <td align="right">车牌照：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_VehicleCode" runat="server" datatype="*" nullmsg="请填写车牌照"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">车辆配置：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_VConfig" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg"
                                Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_VDesc" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

