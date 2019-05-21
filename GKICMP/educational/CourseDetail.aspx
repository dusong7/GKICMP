<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="GKICMP.educational.CourseDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
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
                        <th colspan="4" align="left">课程信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">课程名称：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CourseName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程别名：</td>
                        <td>
                            <asp:Literal ID="ltl_CourseOther" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">教材数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_MaterialNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">版本数：</td>
                        <td>
                            <asp:Literal ID="ltl_EditionNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">是否开设：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsOpen" runat="server"></asp:Literal>
                        </td>
                        <%--<td align="right">是否国标：</td>
                        <td>
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right" width="90">课程等级：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CourseGrade" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否主课：</td>
                        <td>
                            <asp:Literal ID="ltl_IsMain" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否选修课程：</td>
                        <td>
                            <asp:Literal ID="ltl_IsElective" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td align="right" width="90">邮箱：</td>
                        <td align="left">
                            <asp:Label ID="txt_MailNum" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">QQ：</td>
                        <td>
                            <asp:Label ID="txt_QQNum" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">微信号：</td>
                        <td align="left">
                            <asp:Label ID="txt_WeiNum" runat="server"></asp:Label>
                        </td>
                        <td align="right">用户类别：</td>
                        <td>
                            <asp:Label ID="ddl_UserType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">民族：</td>
                        <td align="left">
                            <asp:Label ID="ddl_UserNation" runat="server"></asp:Label>
                        </td>
                        <td align="right">一卡通：</td>
                        <td>
                            <asp:Label ID="txt_CardNum" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">状态：</td>
                        <td align="left" colspan="3" >
                            <asp:Label ID="txt_UState" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="txt_UserDesc" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

