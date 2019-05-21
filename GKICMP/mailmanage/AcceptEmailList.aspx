<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptEmailList.aspx.cs" Inherits="GKICMP.mailmanage.AcceptEmailList" %>

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
            $('#btn_Replay').click(function () {
                var ids = document.getElementById("hf_CheckIDS").value;
                if (onlycheck("转发") != false) {
                    return openbox('A_id', 'RepeatEmailEdit.aspx', 'id=' + ids, 980, 670, 41);
                }
            });
        });
        function replyainfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ReplayEmailEdit.aspx', 'id=' + id, 980, 670, 40);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="收件箱"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70px">标题：</td>
                        <td width="160px">
                            <asp:TextBox runat="server" ID="txt_EmailTitle"></asp:TextBox></td>
                        <td align="right" width="70px">类型：</td>
                        <td width="150px">
                            <asp:DropDownList runat="server" ID="ddl_EType"></asp:DropDownList></td>
                        <td width="70px" align="right">发送时间：</td>
                        <td width="350px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Replay" runat="server" Text="转发" CssClass="listbtncss listrelay" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">发件人</th>
                        <th align="center">标题</th>
                        <th align="center">类型</th>
                        <th align="center">发送时间</th>
                        <th align="center">是否已读</th>
                        <th width="120px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("EUID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("EUID") %>' id='ck_<%#Eval("EUID") %>' /></label>
                                </td>
                                <td><%#Eval("SendUserName")%></td>
                                <td><%#Eval("EmailTitle")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RecType>(Eval("EType"))%></td>
                                <td><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsRead"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("EUID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Reply" runat="server" CssClass="listbtn btngdcolor" OnClientClick='return replyainfo(this);' Visible='<%#Eval("IsRead").ToString ()=="1"?true :false %>'>回复</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("EUID") %>' runat="server" />
                                    </div>
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

