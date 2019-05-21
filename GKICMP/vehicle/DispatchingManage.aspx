<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchingManage.aspx.cs" Inherits="GKICMP.vehicle.DispatchingManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'DispatchingEdit.aspx', 'id=' + id, 650, 240, 47);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'VehicleApplyDetail.aspx', 'id=' + id, 950, 600, 4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="出车安排"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">申请人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_ApplyUserName" runat="server"></asp:TextBox>
                        </td>
                        <td width="80" align="right">申请日期：</td>
                        <td width="230px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">申请人</th>
                        <th align="center">出车地点</th>
                        <th align="center">目的地</th>
                        <th align="center">用车开始时间</th>
                        <th align="center">用车结束时间</th>
                        <th align="center">同行人数</th>
                        <th align="center">申请日期</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("ApplyUserName")%></td>
                                <td align="center"><%#Eval("BeginAddress")%></td>
                                <td align="center"><%#Eval("EndAddress")%></td>
                                <td align="center"><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td align="center"><%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td align="center"><%#Eval("PeerCount")%></td>
                                <td align="center"><%#Eval("ApplyDate","{0:yyyy-MM-dd}")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Plan" runat="server" CssClass="listbtn btneditcolor" ToolTip="安排" OnClientClick='return editinfo(this);'>安排</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_TPID" Value='<%#Eval("ApplyID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>



