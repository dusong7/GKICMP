<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingDetail.aspx.cs" Inherits="GKICMP.meeting.MeetingDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">会议详细信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">会议主题</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_MTitle"></asp:Literal>
                        </td>
                        <td align="right" width="80">会议室</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_MeetingRoom"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">联系人</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_LinkUser"></asp:Literal>
                        </td>
                        <td align="right">联系电话</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_LinkNum"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">会议时间</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_MBegin"></asp:Literal>至
                            <asp:Literal runat="server" ID="ltl_MEnd"></asp:Literal>
                        </td>
                        <td align="right">会议主持人</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_MeetingHost"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">参会人员情况</td>
                        <td colspan="3"><span style="font-weight: bold; font-size: 14px;">应参会人员：</span><asp:Literal ID="ltl_MeetUser" runat="server"></asp:Literal><br />
                            <span style="font-weight: bold; font-size: 14px;">实到人员：</span><asp:Literal runat="server" ID="ltl_AMeetUser"></asp:Literal><br />
                            <span style="font-weight: bold; font-size: 14px;">迟到人员：</span><asp:Literal runat="server" ID="ltl_LateUser"></asp:Literal><br />
                            <span style="font-weight: bold; font-size: 14px;">缺席人员：</span><asp:Literal runat="server" ID="ltl_AbsendUser"></asp:Literal><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">外来人员</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_UserList"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">会议内容</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_MContent"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">会议纪要</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_Minutes"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
