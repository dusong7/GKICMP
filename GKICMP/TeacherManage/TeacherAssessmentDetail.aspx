<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherAssessmentDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherAssessmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
</head>
<body>
    <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">考核信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right" >教师</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TID" runat="server"></asp:Literal>
                        </td> </tr>
                    <tr>
                        <td align="right" >年份</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TSYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >考核结果</td>
                        <td align="left">
                            <asp:Literal ID="ltl_AssResult" runat="server"></asp:Literal>
                        </td>
                      <%--  <td align="right">审核状态</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_AduitState"></asp:Literal>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right" >备注</td>
                        <td align="left"colspan="3">
                            <asp:Literal ID="ltl_TSDesc" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                   

                </tbody>
            </table>
        </div>
</body>
</html>