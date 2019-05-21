<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLearnDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherLearnDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left" colspan="2">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal>
                        </td>
                        <%--<td align="right">部门</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_DepName"></asp:Literal>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">身份证号</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CardNO"></asp:Literal></td>
                        <td align="right">性别</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TSex"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">培训年份</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Year"></asp:Literal></td>
                        <td align="right">课时</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_THours"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">开始时间</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TStartDate"></asp:Literal></td>
                        <td align="right">结束时间 </td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TEndDate"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td align="right">学习或培训地点</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TrainAddress"></asp:Literal></td>
                        <td align="right">学习或培训类型</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TType"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">学习或培训内容</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_TrainContent"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">备注</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_TDesc"></asp:Literal></td>
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
