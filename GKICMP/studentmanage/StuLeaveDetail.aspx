<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuLeaveDetail.aspx.cs" Inherits="GKICMP.studentmanage.StuLeaveDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <style>
        .listcent {
            min-width: 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_attendtype" runat="server" />
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">班级名称：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_DIDName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">姓名：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_LeaveUser" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">晨检日期：</td>
                        <td width="230px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">班级名称</th>
                        <th align="center">姓名</th>
                        <th align="center">晨检日期</th>
                        <th align="center">
                            <asp:Label ID="lbl_attenttype" runat="server"></asp:Label></th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("DIDName") %></td>
                                <td><%#Eval("LeaveUserName") %></td>
                                <td><%#Eval("LeaveDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("LeaveDays") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


