<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitDetail.aspx.cs" Inherits="GKICMP.office.VisitDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
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
                        <th colspan="4" align="left">来访登记详细信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">来访人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_VisitUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right">来访时间：</td>
                        <td>
                            <asp:Literal ID="ltl_VDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">对接人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SchoolUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right">联系电话：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_LinkNum"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">离开时间：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_LeaveDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">登记人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CreateUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right">登记时间：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">来访事由：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_VisitReason"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_VMark" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="2" align="center">
                        <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
