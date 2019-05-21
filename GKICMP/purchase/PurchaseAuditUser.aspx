<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseAuditUser.aspx.cs" Inherits="GKICMP.purchase.PurchaseAuditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">

        function getvalue(a) {
            var cid = a.id;
           // var cname = $(a).next().val();
            var pid = getUrlParam("pid");
            var aresult = 0;
            $.ajax({
                url: "../ashx/PurchaseBill.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=AuditUser&uid=" + cid + "&pid=" + pid ,
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = -1;
                    }
                    if (data.result == "repeat") {
                        aresult = -2;
                    }
                }
            });
            if (aresult == -1) {
                alert("系统提示：提交失败");
                return;
            }
            else if (aresult == -2) {
                alert("系统提示：此审核人已存在，请重新选择");
                return;
            }
            else {
                $.opener("A_id").document.getElementById('btn_Search').click();
            }
            $.close("S_id");
        }
    </script>
</head>
<body>
    <form runat="server">
        
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <asp:HiddenField ID="hf_PID" runat="server" />
        <div class="listcent pad0" style="min-width:100px">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo" >
                <tbody>
                    <tr>
                        <th width="70px" align="center"></th>
                        <th align="center">部门</th>
                        <th align="center">姓名</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td width="100px">
                                    <a  id='<%# DataBinder.Eval(Container.DataItem, "UID")%>' href="#" onclick='getvalue(this)'>
                                        <img src="../images/accept1.png" style="border: 0px; padding-top: 4px;" /></a>
                                    <asp:HiddenField ID="hfname" runat="server" Value='<%# Eval("RealName") %>' />
                                </td>
                                <td width="100px"><%#Eval("DepName")%></td>
                                <td width="100px"><%#Eval("RealName")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="3">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


