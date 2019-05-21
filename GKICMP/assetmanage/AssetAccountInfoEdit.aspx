<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAccountInfoEdit.aspx.cs" Inherits="GKICMP.assetmanage.AssetAccountInfoEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function showokwin() {
            var accname = document.getElementById("txt_AccName").value;
            var accnum = document.getElementById("txt_AccNum").value;
            var accunit = document.getElementById("ddl_AccUnit").value;
            var accountcash = document.getElementById("txt_AccountCash").value;
            if (accname == "" || accnum == "" || accunit == -2 || accountcash=="") {
                alert("请将带“*”的必填项填写完整！");
                return;
            }
            var aresult = true;
            $.ajax({
                url: "../ashx/AssetAccountInfo.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=Add&aaid=" + document.getElementById("hf_AAID").value + "&aitype=" + document.getElementById("hf_AiType").value + "&accname=" + encodeURI(accname) + "&accnum=" + encodeURI(accnum) + "&accunit=" + encodeURI(accunit) + "&accountcash=" + encodeURI(accountcash),
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = false;
                    }
                }
            });
            if (!aresult) {
                alert("系统提示：提交失败");
                return;
            }
            else {
                alert('提交成功！');
                $.opener("A_id").document.getElementById('btnsear').click();
                $.close("Add_id");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_AAID" />
         <asp:HiddenField runat="server" ID="hf_AiType" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">资产信息</th>
                    </tr>
                    <tr>
                        <td align="right">资产名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AccName" runat="server" datatype="*" nullmsg="请填写资产名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">资产数量：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AccNum" runat="server" datatype="sum" nullmsg="请填写资产数量"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>

                        <td align="right">计量单位：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_AccUnit" runat="server" datatype="ddl" errormsg="请选择计量单位"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">评估价值（元）：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AccountCash" runat="server" datatype="sum" nullmsg="请填写评估价值（元）"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="showokwin()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("Add_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

