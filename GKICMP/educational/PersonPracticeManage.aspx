<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonPracticeManage.aspx.cs" Inherits="GKICMP.educational.PersonPracticeManage" %>

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
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function addinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SelectStu.aspx', 'id=' + id, 860, 620, 1)
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="我的学习"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的练习"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">试卷名称：</td>
                        <td width="180px">
                            <asp:TextBox ID="txt_PaperName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="70">要求完成时间：
                        </td>
                        <td width="250px">
                            <asp:TextBox runat="server" ID="txt_BeginDate" Width="105px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_EndDate" Width="105px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox></td>

                        <td width="40" align="right">发布人：</td>
                        <td width="180px">
                            <asp:TextBox ID="txt_createuser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="70">发布日期：
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_createbegin" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_createend" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox></td>
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
                        <th align="center">试卷名称</th>
                        <th align="center">课程</th>
                        <th align="center">要求完成时间</th>
                        <th align="center">发布人</th>
                        <th align="center">发布日期</th>
                        <th align="center">练习要求</th>
                        <th align="center">是否完成</th>
                        <th width="105px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("PaperName") %></td>
                                <td><%#Eval("CIDName") %></td>
                                <td><%#Eval("CompleteDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                <td><%#Eval("CreateUserName") %></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></td>
                                <td title='<%#Eval("ExcDesc") %>'><%#Eval("ExcDesc").ToString().Length>30?Eval("ExcDesc").ToString().Substring(0,30)+"...":Eval("ExcDesc").ToString() %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>( Eval("IsComplete")) %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_AddScore" runat="server" CssClass="listbtn btnreportncolor" ToolTip="开始答题" Visible='<%#Eval("IsComplete").ToString()=="0"?true:false %>' CommandArgument='<%#Eval("PPSID") %>' OnClick="lbtn_AddScore_Click">开始答题</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PPSID") %>' runat="server" />
                                </td>
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
