<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyExamManage.aspx.cs" Inherits="GKICMP.educational.MyExamManage" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'ExamEdit.aspx', 'id=' + id, 1000, 450, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考试管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">学年度：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_EYear" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">学期：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_Term" runat="server" Width="80"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">考试名称：</td>
                        <td width="100px">
                            <asp:TextBox ID="txt_ExamName" runat="server" Width="90px"></asp:TextBox>
                        </td>
                        <td width="70" align="right">考试时间：</td>
                        <td width="200px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                        <th align="center">年级</th>
                        <th align="center">学年度/学期</th>
                        <th align="center">考试名称</th>
                        <th align="center">考场</th>
                        <th align="center">考试科目</th>
                        <th align="center">监考时间</th>
                        <%--<th width="70px" align="center">操作</th>--%>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("GIDName")%>（<%#Eval("GShortName") %>）</td>
                                <td><%#Eval("EYear")%>学年度<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ >(Eval("Term"))%></td>
                                <td><%#Eval("ExamName")%></td>
                                <td>第<%#Eval("RoomNum") %>考场（<%#Eval("ClassName") %>）</td>
                                <td><%#Eval("CourseName") %></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%>--<%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <%--<td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return editinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("EID") %>' runat="server" />
                                    </div>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="6">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
