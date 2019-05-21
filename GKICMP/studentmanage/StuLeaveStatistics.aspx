<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuLeaveStatistics.aspx.cs" Inherits="GKICMP.studentmanage.StuLeaveStatistics" %>

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
    <script>
        function show(did, months, attendtype, count) {
            if (did != "" && months != "" && attendtype != "" && count > 0) {
                return openbox('A_id', 'StuLeaveDetail.aspx', 'did=' + did + '&months=' + months + '&attendtype=' + attendtype, 960, 550, 1);
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考勤统计"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">班级名称：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_DIDName" runat="server"></asp:TextBox>
                        </td>
                        <td width="60" align="right">月份：</td>
                        <td width="100px">
                            <asp:DropDownList ID="ddl_Month" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">班级名称</th>
                        <th align="center">月份</th>
                        <th align="center">迟到次数</th>
                        <th align="center">事假次数</th>
                        <th align="center">病假次数</th>
                        <th align="center">传染病次数</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("DIDName") %></td>
                                <td><%#Eval("months") %></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("DID")+"\",\""+Eval("months")+"\",1,\""+Eval("LeaveUser")+"\")" %>'><%#Eval("LeaveUser") %></a></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("DID")+"\",\""+Eval("months")+"\",2,\""+Eval("Compassionate")+"\")" %>'><%#Eval("Compassionate") %></a></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("DID")+"\",\""+Eval("months")+"\",3,\""+Eval("Sick")+"\")" %>'><%#Eval("Sick") %></a></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("DID")+"\",\""+Eval("months")+"\",4,\""+Eval("Infectious")+"\")" %>'><%#Eval("Infectious") %></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
