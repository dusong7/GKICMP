<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailDetail.aspx.cs" Inherits="GKICMP.mailmanage.EmailDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <style>        *{
            word-wrap:break-word;
   word-break:break-all;      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">信息详情</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">消息标题：</td>
                        <td align="left" colspan="4">
                            <asp:Literal ID="ltl_EmailTitle" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">
                            <asp:Literal ID="ltl_Date" runat="server"></asp:Literal></td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_SendDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">类型：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_EType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">
                            <asp:Literal ID="ltl_User" runat="server"></asp:Literal>
                        </td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Users" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr id="aa" runat="server" visible="false">
                        <td align="right" width="100px">是否已读：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsRead" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100px">接收时间：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_AcceptDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">消息内容：</td>
                        <td align="left" colspan="3" >
                           <asp:Literal ID="ltl_EmailContent" runat="server" Mode="Transform"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

