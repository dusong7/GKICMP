<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetWXAttendRecord.aspx.cs" Inherits="GKICMP.test.GetWXAttendRecord" %>

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
    <script type="text/javascript">
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="评语库管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                       
                       <%-- <td align="right" width="60">评语内容：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_RemarkContent" runat="server"></asp:TextBox>
                        </td>--%>
                        <td width="70" align="right">打卡时间：</td>
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
                        <th align="center">用户id</th>
                        <th align="center">打卡规则名称</th>
                        <th align="center">打卡类型</th>
                          <th align="center">异常类型</th>
                         <th align="center">打卡时间</th>
                        <th align="center">打卡时间</th>
                        <th align="center">打卡地点title</th>
                          <th align="center">打卡地点详情</th>
                        <th align="center">打卡wifi名称</th>
                        <th align="center">打卡备注</th>
                         <th align="center">打卡的MAC地址/bssid</th>
                        <th align="center">打卡附件</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                               
                                <td><%#Eval("userid")%></td>
                                <td><%# Eval("groupname")%></td>
                                <td><%#Eval("checkin_type") %></td>
                                <td><%#Eval("exception_type")%></td>
                                 <td><%#Eval("checkin_time")%></td>
                                <td><%#GetTime(Eval("checkin_time"))%></td>
                                <td><%#Eval("location_title")%></td>
                                 <td title='<%#Eval("location_detail")%>'><%#Eval("location_detail").ToString().Length>40?Eval("location_detail").ToString().Substring(0,39)+"…":Eval("location_detail").ToString()%></td>
                                <td><%# Eval("wifiname")%></td>
                                <td><%#Eval("notes") %></td>
                                 <td><%#Eval("wifimac").ToString().Length>40?Eval("wifimac").ToString().Substring(0,39)+"…":Eval("wifimac").ToString()%></td>
                                <td title='<%#GetM(Eval("mediaids"))%>'><%#GetM(Eval("mediaids")).Length>40?GetM(Eval("mediaids")).Substring(0,40):GetM(Eval("mediaids"))%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="12">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
       <%-- <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />--%>
    </form>
</body>
</html>

