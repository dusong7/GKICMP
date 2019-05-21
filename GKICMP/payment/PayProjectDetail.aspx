<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayProjectDetail.aspx.cs" Inherits="GKICMP.payment.PayProjectDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
  
    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
     <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">缴费项目信息</th>
                    </tr>
                    <%--<tr>
                        <td align="right">缴费项目名称</td>
                        <td align="left" colspan="2">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal></td>
                    </tr>--%>
                    <tr>
                        <td align="right">缴费项目名称</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ProjectName"></asp:Literal></td>
                        <td align="right">缴费总金额</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_PayCount"></asp:Literal>
                        </td>
                    </tr>
                    

                    <tr>
                        <th colspan="4" align="left" class="auto-style1">缴费项</th>
                    </tr>
                    <tr>
                        <th align="center" colspan="2">缴费项</th>
                        <th align="center" colspan="2">缴费金额</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" align="center"><%#Eval("PayName")%></td>
                                <td colspan="2" align="center"><%#Eval("PayCount")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr_null" runat="server">
                        <td colspan="4" align="center">暂无记录</td>
                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="7">
                            <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
