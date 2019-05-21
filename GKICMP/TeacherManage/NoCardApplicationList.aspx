<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoCardApplicationList.aspx.cs" Inherits="GKICMP.teachermanage.NoCardApplicationList" %>

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
        $(function () {
            $('#btn_Audit').click(function () {
                var ids = document.getElementById("hf_CheckIDS").value;
                if (checkselectones(ids) == false) {
                    alert("系统提示：请至少选择一条信息！");
                    return false;
                }
                else {
                    return openbox('A_id', 'LeaveAuditEdit.aspx', 'id=' + ids, 860, 350, 29);
                }

            });
        });

        function auditainfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'NoCardApplicationAudit.aspx', 'id=' + id , 860, 350, 29);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'NoCardApplicationDetail.aspx', 'id=' + id, 950, 550, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="补卡审核"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">补卡申请人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_NoCardApplyUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">补卡时间点：</td>
                        <td width="190">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                        <th align="center">申请人</th>
                        <th align="center">补卡时间点</th>
                        <th align="center">审核人</th>
                        <th align="center">审核状态</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("NoCardApplyUserName")%></td>
                                <td><%#Eval("NoCardApplyDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("NoCardAuditUserName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.PraState>( Eval("NoCardState"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" OnClientClick='return auditainfo(this);'>审核</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("ID") %>' runat="server" />
                                        <%--<asp:HiddenField ID="hf_LAID" Value='<%#Eval("ID") %>' runat="server" />--%>
                                    </div>
                                </td>
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
