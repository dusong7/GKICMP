<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherJournalManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherJournalManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'TeacherJournalEdit.aspx', '', 960, 560, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherJournalEdit.aspx', 'id=' + id, 960, 500, 0);
        } function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherJournalDetail.aspx', 'id=' + id, 860, 470, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="著作管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

       <%-- <div class="dvTab">
            <ul class="menuall">
                <li class="tab "><a href="TeacherPaperManage.aspx">论文</a></li>
                <li class="tab"><a href="TeacherRewardManage.aspx">奖励</a></li>
                <li class="tab activeTab"><a href="TeacherJournalManage.aspx">著作</a></li>
                <li class="tab "><a href="TeacherGuidanceManage.aspx">指导学生获奖</a></li>
            </ul>
            <div class="dv"></div>
        </div>--%>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">姓名：</td>
                        <td width="100px">
                            <asp:TextBox ID="txt_TidName" runat="server" width="100"></asp:TextBox>
                        </td>
                        <td align="right" width="60">著作类别：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_JournalType" runat="server" width="90px"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">学科领域：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_SubjectArea" runat="server"></asp:DropDownList>
                        </td>
                        <td width="70" align="right">出版日期：</td>
                        <td width="200px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">是否上报：</td>
                        <td width="70">
                            <asp:DropDownList ID="ddl_IsReport" runat="server" width="70"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport" OnClick="btn_Report_Click" />
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
                        <th align="center">姓名</th>
                        <th align="center">著作名称</th>
                        <th align="center">著作类别</th>
                        <th align="center">学科领域</th>
                        <th align="center">出版日期</th>
                        <th align="center">是否上报</th>
                        <th width="195px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TPID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TPID") %>' id='ck_<%#Eval("TPID") %>' <%#Istrue(Eval("IsReport")) %> /></label>
                                </td>
                                <td align="center"><%#Eval("TidName")%></td>
                                <td align="center" title="<%#Eval("RewardName") %>"><%#GetCutStr( Eval("RewardName"),30) %></td>
                                <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.JournalType>( Eval("JournalType"))%></td>
                                <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.SubjectField>( Eval("SubjectArea"))%></td>
                                <td align="center"><%#Eval("PubDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TPID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField2" Value='<%#Eval("TPID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TPID") %>' OnClick="lbtn_Report_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("TPID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>




