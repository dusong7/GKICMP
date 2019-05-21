<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeWorkDetail.aspx.cs" Inherits="GKICMP.office.HomeWorkDetail" %>

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
                        <th colspan="4" align="left">作业详情</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">课程：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CID" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120px">完成时间（分钟）：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CompleteTime" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">是否发送：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsSend" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120px">布置日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">班级名称：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_ClaName" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" width="100px">作业内容：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_HomeWork" runat="server"></asp:Literal>
                        </td>

                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

