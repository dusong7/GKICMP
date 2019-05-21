<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheAcceptManage.aspx.cs" Inherits="GKICMP.oamanage.AfficheAcceptManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'AfficheEdit.aspx', '', 940, 560, -1);
            });

        });
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="通知公告"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="通知公告"></asp:Label>
                </tr>
            </table>
        </div>

            <div class="dvTab">
<ul class="menuall">
<li class="tab "><a href="AfficheManage.aspx">已发通知公告</a></li>

<li class="tab activeTab"><a href="AfficheAcceptManage.aspx">已收通知公告</a></li>

</ul>
<div class="dv"></div>
</div>


        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">公告标题：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_AfficheTitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">公告类型：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_AType" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="70">发送日期：</td>
                        <td width="210">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right " width="60">是否已读：</td>
                        <td width="120">
                            <asp:DropDownList ID="ddl_IsRead" runat="server"></asp:DropDownList>
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
                        <th align="center">公告类型</th>
                        <th align="center">公告标题</th>
                        <th align="center">发送人</th>
                        <th align="center">发送日期</th>
                        <th align="center">是否公示</th>
                        <th align="center">是否已读</th>
                        <th width="70px" align="center">操作</th>

                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ATypeName")%></td>
                                <td><%#Eval("AfficheTitle")%></td>
                                <td><%#Eval("SenduserName")%></td>
                                <td><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot> (Eval("IsDisplay"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot> (Eval("IsRead"))%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass=" listbtn btndetialcolor" CommandArgument='<%#Eval("AID") %>' CommandName='<%#Eval("AcceptUser") %>' ToolTip="详细" OnClick="lbtn_View_Click">详细</asp:LinkButton>
                                </td>
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


