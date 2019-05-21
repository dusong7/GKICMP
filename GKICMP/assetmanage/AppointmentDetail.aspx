<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentDetail.aspx.cs" Inherits="GKICMP.assetmanage.AppointmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%-- <link href="../css/lrtk.css" rel="stylesheet" />--%>
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
                        <th colspan="4" align="left">场地预约信息</th>
                    </tr>
                    <tr>
                        <td align="right">预约场地</td>
                        <td align="left" colspan="2">
                            <asp:Literal ID="ltl_MRID" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">预约人</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">预约日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_BeginDate"></asp:Literal></td>
                        <td align="right">时段</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_begin"></asp:Literal>--<asp:Literal runat="server" ID="ltl_End"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">预约说明</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_AppointmentDesc" runat="server" Text=""></asp:Label>
                        </td>
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

