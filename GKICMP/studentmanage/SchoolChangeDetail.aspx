<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolChangeDetail.aspx.cs" Inherits="GKICMP.studentmanage.SchoolChangeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <asp:HiddenField ID="hf_face" runat="server" Value="" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">学生变动信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">姓名：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_Realname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">年级：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Gradename" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">班级：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Claidname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">变动类别：</td>
                        <td align="left">
                            <asp:Label ID="lbl_SCType" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">&nbsp;变动日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_SCDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">变动原因：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_SCReason" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">变动说明：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_SCDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


