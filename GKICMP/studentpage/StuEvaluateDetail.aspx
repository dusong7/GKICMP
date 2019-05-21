<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuEvaluateDetail.aspx.cs" Inherits="GKICMP.studentpage.StuEvaluateDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">评语信息</th>
                    </tr>
                    <tr>
                        <td align="right">学生姓名：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_StudentName"></asp:Literal>
                        </td>
                    
                        <td align="right" width="120">学年度/学期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EYear" runat="server"></asp:Literal>
                            <asp:Literal runat="server" ID="ltl_Term"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">评语：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Evaluate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


