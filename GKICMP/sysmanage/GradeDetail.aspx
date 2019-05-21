<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeDetail.aspx.cs" Inherits="GKICMP.sysmanage.GradeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hflogo = $id("hf_GraduatePhoto");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">年级信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">年级名称：</td>
                        <td align="left">
                            <asp:Label ID="lbl_GradeName" runat="server" Text=""></asp:Label></td>
                        <td align="right" width="120">入学年份：</td>
                        <td align="left">
                            <asp:Label ID="lbl_GradeYear" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否毕业：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IsGraduate" runat="server" Text=""></asp:Label></td>
                        <td align="right" width="120">创建日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_CreateDate" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">当前简称：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_ShortName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">年级负责人：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_GradeDuty" runat="server" Text=""></asp:Label></td>

                    </tr>

                    <tr>
                        <td align="right" width="120">毕业照：</td>
                        <td align="left" colspan="3">
                            <asp:Image ID="img_GraduatePhoto" runat="server" Width="120" Height="100" />
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_Notes" runat="server" Text=""></asp:Label></td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

