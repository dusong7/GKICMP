<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleApplyEdit.aspx.cs" Inherits="GKICMP.vehicle.VehicleApplyEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>

    <script src="../js/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_vhid" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hf_sysuid" runat="server"></asp:HiddenField>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">出车申请管理</th>
                    </tr>
                    <tr>
                        <td align="right">车辆：</td>
                        <td align="left" colspan="3">
                            <%--<input id="vhid" style="width: 80%;" runat="server" class="easyui-combotree" name="vhid" />--%>
                            <asp:DropDownList runat="server" ID="ddl_VHID" datatype="ddl" errormsg="请选择车辆"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">出车地点：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginAddress" runat="server" datatype="*" nullmsg="请填写出车地点"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">目的地：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EndAddress" runat="server" datatype="*" nullmsg="请填写目的地"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">用车开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginDate" runat="server" datatype="*" nullmsg="请选择用车开始时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">用车结束时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EndDate" runat="server" datatype="*" nullmsg="请选择用车结束时间" ckdate="txt_BeginDate" errormsg="用车开始时间不能小于用车结束时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">同行人数：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_PeerCount" runat="server" datatype="zheng" nullmsg="请填写同行人数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">用车事由：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_ApplyDesc" runat="server" Rows="6" TextMode="MultiLine" datatype="*" nullmsg="请填写用车事由" Width="80%" Height="100px" CssClass="MultiLinebg" Style="resize: none;"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetVehicle",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#vhid').combotree({ data: d.data, multiple: false, });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $('#vhid').combotree({
                onSelect: function (node) {
                    document.getElementById("hf_vhid").value = node.id;
                }
            });
            jQuery("#form1").Validform();
        });
    </script>
    <script>
        $(function () {
            $('#vhid').combotree('setValues', [$("#hf_vhid").val()]);
        });
    </script>
</body>
</html>
<script>
    function check() {
        if ($val("hf_vhid") == "") {
            alert("车辆不能为空");
        }
    };
</script>




