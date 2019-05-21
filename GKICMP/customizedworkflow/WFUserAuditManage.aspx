﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFUserAuditManage.aspx.cs" Inherits="GKICMP.customizedworkflow.WFUserAuditManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智慧校园基础管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {

        });

        function audit(e) {
            var cid = $(e).next().val();
            var wffid = $(e).next().next().val();
            var faid = $(e).next().next().next().val();
            window.location.href = "WFAudit.html?WFFID=" + wffid + "&CID=" + cid + "&FAID=" + faid;
            return false;
            //var hour = document.getElementById("ltl_TotelHour").innerText;
            //return openbox('A_id', 'TeacherPlaneEdit.aspx', 'id=' + id + '&totelhour=' + hour, 960, 650, 0);
        }

    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />

        <asp:HiddenField ID="hf_AvoidSubmit" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a href="/Main.aspx">首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="流程管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">事务名称</th>
                        <th align="center">发起人</th>
                        <th align="center">发起日期</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("FormName")%></td>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd HH:mm")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" OnClientClick='return audit(this);'>审核</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("CID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("WFFID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField2" Value='<%#Eval("FAID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

