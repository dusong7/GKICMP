<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExerciseDetail.aspx.cs" Inherits="GKICMP.educational.ExerciseDetail" %>

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
    <script src="../js/common.js"></script>
    <style type="text/css">
        .tb_aa td {
            border: 0;
            line-height: auto;
            padding: 0;
        }

        .tb_aa tr:last-child td {
            background: #f5f5f5;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">题目信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">题型：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EType" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="90">难易程度：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Difficulty" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">年级：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GradeID" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="90">学期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Term" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">课程：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CourseName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="90">分数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Score" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">题目内容：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_Title" runat="server"></asp:Literal>
                            <asp:Literal ID="ltl_Option" runat="server"></asp:Literal>
                            <table class="tb_aa">
                                <tr style="vertical-align: top;">
                                    <td width="40">
                                        <p>答案：</p>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltl_Answer" runat="server"></asp:Literal></td>
                                </tr>
                            </table>


                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <input type="button" class="editor" onclick="Javascript: window.history.go(-1);" value="返回" />

                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



