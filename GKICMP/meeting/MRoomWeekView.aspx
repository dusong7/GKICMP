<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRoomWeekView.aspx.cs" Inherits="GKICMP.meeting.MRoomWeekView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/My97/WdatePicker.js"></script>
    <style type="text/css">
        .stripe_tb th {
            padding: 0px;
            line-height: 2px;
        }

        .stripe_tb td {
            padding: 0px;
        }

        .btncss {
            width: 69px;
            height: 27px;
            border: none;
            background: url(../images/green_yjqh_19.png);
            padding: 0px;
            margin: 0px;
            color: #fff;
            font-size: 14px;
            text-align: left;
            text-indent: 10px;
            line-height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>会议管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="会议室使用情况"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="7" align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="MRoomDayView.aspx">日视图</a></li>
                                    <li class="selected"><a href="MRoomWeekView.aspx">周视图</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">会议日期：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_MDate" runat="server" CssClass="searchbg" datatype="*" nullmsg="请选择会议日期" Width="85px"
                                onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" CssClass="btncss" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <thead>
                    <tr>
                        <td style="font-weight: bold; border-right: 1px solid #cccccc; text-align: center; border-top: 1px solid #cccccc;">会议室名称
                        </td>
                        <asp:Literal ID="ltl_Days" runat="server"></asp:Literal>
                    </tr>
                </thead>
                <asp:Literal ID="ltl_Rooms" runat="server"></asp:Literal>
            </table>
        </div>
    </form>
</body>
</html>
