<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseBillAdd.aspx.cs" Inherits="GKICMP.purchase.PurchaseBillAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/choice.js"></script>
    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="120">名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BName" runat="server" datatype="*" nullmsg="请填写名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">规格型号</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BModel" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">数量</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BCount" runat="server" datatype="zheng" nullmsg="请填写数量" MaxLength="5"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">单价</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BPrice" runat="server" datatype="money" nullmsg="请填写单价"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" width="120">备注</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <asp:TextBox ID="txt_BReason" runat="server" Width="90%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <%-- <span style="color: Red; float: none">*</span>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <input id="btn_Submit" type="button" class="submit" value="提交" onclick="submits()" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script type="text/javascript">

        function submits() {
            var pid = getUrlParam("pid");
            var pestimate = getUrlParam("pestimate");
            if (pid == "" || pid == null) {
                alert("采购标识ID不正确，请联系系统管理员");
                return;
            }
 
            var bname = document.getElementById("txt_BName").value;
            var bmodel = document.getElementById("txt_BModel").value;
            var bcount = document.getElementById("txt_BCount").value;
            var bprice = document.getElementById("txt_BPrice").value;
            var breason = document.getElementById("txt_BReason").value;
            var aresult = 0;
            $.ajax({
                url: "../ashx/PurchaseBill.ashx",
                cache: false,
                type: "POST",
                async: false,
                data: { method: "Add", pid: pid, bname: bname, bmodel: bmodel, bcount: bcount, bprice: bprice, breason: breason, pestimate: pestimate },
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = -1;
                    }
                    if (data.result == "repeat") {
                        aresult = -2;
                    }
                    if(data.result=="moreprice")
                    {
                        aresult = -3;
                    }
                }
            });
            if (aresult == -1) {
                alert("系统提示：提交失败");
                return;
            }
            else if (aresult == -2) {
                alert("系统提示：该项目中此项已存在，请勿重复添加");
                return;
            }
            else if(aresult==-3)
            {
                alert("系统提示：此清单金额添加已超出采购概算价格");
                return;
            }
            else {
                $.opener("A_id").document.getElementById('btn_Search').click();
            }
            $.close("S_id");
        }
    </script>

</body>
</html>


