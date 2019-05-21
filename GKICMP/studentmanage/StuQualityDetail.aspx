<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuQualityDetail.aspx.cs" Inherits="GKICMP.studentmanage.StuQualityDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>

    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生素质评价信息</th>
                    </tr>
                    <tr>
                        <td align="right">学年度：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EYear" runat="server"></asp:Literal>
                        </td>
                        <td align="right">学期：</td>
                        <td>
                            <asp:Literal ID="ltl_Term" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学生：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_StID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">思想道德：</td>
                        <td>
                            <asp:Literal ID="ltl_SXDD" runat="server"></asp:Literal>
                        <td align="right">勤奋学习：</td>
                        <td>
                            <asp:Literal ID="ltl_QFXX" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >身体素质：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_STSZ" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >审美塑美能力：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SMSMNL" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">生活劳动技能：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SHLDJN" runat="server"></asp:Literal>
                        </td>
                        <td align="right">创造精神创造能力：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CZJSCZNL" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>








