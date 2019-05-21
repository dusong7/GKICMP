﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuPhysicalDetail.aspx.cs" Inherits="GKICMP.studentmanage.StuPhysicalDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%--<link href="../css/lrtk.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生体质健康信息</th>
                    </tr>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_StuName" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">学年度</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_EYear"></asp:Literal></td>
                        <td align="right">学期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Term"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">体重</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_StuWeight"></asp:Literal></td>
                        <td align="right">身高</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_StuHeight"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">胸围</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Bust"></asp:Literal></td>
                        <td align="right">肺活量</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Vitalcapacity"></asp:Literal></td>
                    </tr>
                    
                     <tr>
                        <td align="right">左视力</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_LVision"></asp:Literal></td>
                        <td align="right">右视力</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RVision"></asp:Literal></td>
                    </tr>

                     <tr>
                        <td align="right">左听力</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Lhearing"></asp:Literal></td>
                        <td align="right">右听力</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Rhearing"></asp:Literal></td>
                    </tr>
                     <tr>
                        <td align="right">是否有龋齿</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_DentalCaries"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="4">
                            <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>