<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActDetail.aspx.cs" Inherits="GKICMP.schoolwork.StudentActDetail" %>

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
                        <th colspan="4" align="left">学生活动信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">活动名称：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ActName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100px">活动类型：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ActType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ABegin" runat="server"></asp:Literal>至
                            <asp:Literal ID="ltl_AEnd" runat="server"></asp:Literal>
                        </td>
                        <td align="right">是否发布：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_IsPublish"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否可报名：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsSign" runat="server"></asp:Literal>
                        </td>
                        <td align="right">报名截止日期：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ClosingDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">指导老师：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Counselor" runat="server"></asp:Literal>
                        </td>
                        <td align="right">活动地点：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ActAddress" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参与人：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_ActUsers" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动内容：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ActContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动LOGO：</td>
                        <td colspan="3">
                            <asp:Image runat="server" ID="img_LogoUrl" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ActDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动模板：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ActivityTemp" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>









