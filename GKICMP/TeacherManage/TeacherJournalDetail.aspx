<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherJournalDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherJournalDetail" %>

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
                        <th colspan="4" align="left">著作信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">教师姓名：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_TidName" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">著作类别：</td>
                        <td>
                            <asp:Literal ID="ltl_JournalType" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="90">学科领域：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubjectArea" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">著作名称：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_RewardName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">出版社名称：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_PubName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">出版日期：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_PubDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">出版号：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_PubNum" runat="server"></asp:Literal>
                        </td>

                        <td align="right">是否上报：</td>
                        <td>
                            <asp:Literal ID="ltl_IsReport" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">本人撰写字数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OnwerNum" runat="server"></asp:Literal>
                        </td>

                        <td align="right">总字数：</td>
                        <td>
                            <asp:Literal ID="ltl_TotelNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


