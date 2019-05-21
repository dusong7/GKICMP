<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayBackAduitManage.aspx.cs" Inherits="GKICMP.payment.PayBackAduitManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
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
        function aduitinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PayBackAduitEdit.aspx', 'id=' + id, 960, 250, 48);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="退费审核"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">学生姓名：</td>
                        <td width="170">
                            <asp:TextBox ID="txt_StuName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">退费日期：</td>
                        <td width="180">
                            <asp:TextBox ID="txt_BeginDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="40">状态：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_IsAudit" runat="server"></asp:DropDownList>
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
                        <th align="center">学生姓名</th>
                        <th align="center">退费金额</th>
                        <th align="center">退费日期</th>
                        <th align="center">状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("BackCount")%></td>
                                <td><%#Eval("BackDate","{0:yyyy-MM-dd}")%></td>
                                <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.PraState>( Eval("IsAudit") )%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Aduit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" Visible='<%#Eval("IsAudit").ToString()=="0"?true:false %>' OnClientClick='return aduitinfo(this);'>审核</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PBID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>



