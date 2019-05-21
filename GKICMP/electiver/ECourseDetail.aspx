<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECourseDetail.aspx.cs" Inherits="GKICMP.electiver.ECourseDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>

                    <tr>
                        <th colspan="2" align="left">选修课课程信息</th>
                    </tr>
                    <tr>
                        <td align="right">课程编码：</td>
                        <td>
                            <asp:Literal ID="ltl_CourseOther" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">课程名称：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CourseName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">课程等级：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CourseGrade" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程类别：</td>
                        <td>
                            <asp:Literal ID="ltl_CourseType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程简介：</td>
                        <td>
                            <asp:Literal ID="ltl_CourseDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


