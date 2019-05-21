<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchingEdit.aspx.cs" Inherits="GKICMP.vehicle.DispatchingEdit" %>

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
        <%--<asp:HiddenField ID="hf_sysuid" runat="server"></asp:HiddenField>--%>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">出车安排管理</th>
                    </tr>
                    <tr>
                        <td align="right" width="60px">司机：</td>
                        <td align="left">
                            <%--<input id="sysuid" style="width: 80%;" runat="server" class="easyui-combotree" name="sysuid" />--%>
                            <asp:DropDownList runat="server" ID="ddl_SysUID" datatype="ddl" errormsg="请选择司机"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetDriver";
            $.getJSON(url, function (data) { $('#sysuid').combotree({ data: data.data, multiple: false, /*multiline: true,*/ }); });
            $('#sysuid').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_sysuid").value = val;
                }
            });
            jQuery("#form1").Validform();
        });
    </script>
    <script>
        $(function () {
            $('#sysuid').combotree('setValues', [$("#hf_sysuid").val()]);
        });
    </script>
</body>
</html>
<script>
    function check() {
        if ($val("hf_sysuid") == "") {
            alert("司机不能为空");
        }
    };
</script>





