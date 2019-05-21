<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbsentWorkStatisticsDetail.aspx.cs" Inherits="GKICMP.educationals.AbsentWorkStatisticsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <style>
        .listcent {
            min-width: 0px;
        }

        .pad0 {
            width: 98%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">请假人</th>
                        <th align="center">代课人</th>
                        <th align="center">代课日期</th>
                        <th align="center">代课课程</th>
                        <th align="center">课时系数</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("AbsentUserName")%></td>
                                <td><%#Eval("SubUserName")%></td>
                                <td><%#Eval("SubDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("SubCoruseName")%></td>
                                <td><%#Eval("Hourse")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="5">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

