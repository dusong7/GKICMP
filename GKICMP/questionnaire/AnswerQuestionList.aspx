    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnswerQuestionList.aspx.cs" Inherits="GKICMP.questionnaire.AnswerQuestionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function addinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AnswerQuestionEdit.aspx', 'id=' + id, 960, 720, 51);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的问卷"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">问卷名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_QuestName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">创建日期：</td>
                        <td width="250">
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
                        <th align="center" width="300">问卷名称</th>
                        <th align="center">截至日期</th>
                        <th align="center">是否实名投票</th>
                        <%--<th align="center">是否发布</th>--%>
                        <th align="center">创建人</th>
                        <th align="center">创建日期</th>
                        <th width="55px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("QuestName")%></td>
                                <td><%#Eval("LastDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsRealName"))%></td>
                                <%--<td><%#GK.ICMP.Common.CommonFunction.CheckEnum<GK.ICMP.Common.CommonEnum.IsorNot>(Eval("IsPublish"))%></td>--%>
                                <td><%#Eval("CreateName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_AddAnswer" runat="server" CssClass="listbtn btneditcolor" ToolTip="开始答题" OnClientClick='return addinfo(this);'>开始答题</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("QID") %>' runat="server" />

                                    </div>
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





