<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceInfoEdit.aspx.cs" Inherits="GKICMP.invoice.InvoiceInfoEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function showokwin() {
            var inum = document.getElementById("txt_INum").value;
            var invoicecount = document.getElementById("txt_InvoiceCount").value;
            var invoicecash = document.getElementById("txt_InvoiceCash").value;
            var invdesc = document.getElementById("txt_InvDesc").value;
            if (inum == "" || invoicecount == "" || invoicecash == "" || invdesc == "") {
                alert("请将带“*”的必填项填写完整！");
                return;
            }
            var aresult = true;
            $.ajax({
                url: "../ashx/InvoiceInfo.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=Add&iid=" + document.getElementById("hf_IID").value + "&inum=" + inum + "&invdesc=" + encodeURI(invdesc) + "&invoicecount=" + invoicecount + "&invoicecash=" + invoicecash,
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
        <asp:HiddenField runat="server" ID="hf_IID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">报销详情信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">序号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_INum" runat="server" datatype="*" nullmsg="请填写序号" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="100">张数：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_InvoiceCount" datatype="zheng" nullmsg="请填写张数"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100">金额：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_InvoiceCash" datatype="zeronum" nullmsg="请填写金额"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">摘要：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_InvDesc" runat="server" TextMode="MultiLine" Height="50px" Width="70%"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
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
