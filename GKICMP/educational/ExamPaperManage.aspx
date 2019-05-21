<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamPaperManage.aspx.cs" Inherits="GKICMP.educational.ExamPaperManage" %>

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
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'ExamPaperEdit.aspx', '', 860, 300, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ExamPaperEdit.aspx', 'id=' + id, 860, 300, 0);
        }
        function replaceinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ExamPaperPracticeEdit.aspx', 'id=' + id, 860, 350, 55);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="试卷管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">试卷名称：</td>
                        <td width="80px">
                            <asp:TextBox ID="txt_PaperName" runat="server"></asp:TextBox>
                        </td>
                        <td width="40" align="right">学期：</td>
                        <td width="80px">
                            <asp:DropDownList runat="server" ID="ddl_Term"></asp:DropDownList>
                        </td>
                        <td width="40" align="right">年级：</td>
                        <td width="80px">
                            <asp:DropDownList runat="server" ID="ddl_GradeID"></asp:DropDownList>
                        </td>
                        <td align="right" width="40">课程：</td>
                        <td width="180px">
                            <asp:DropDownList ID="ddl_CID" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
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
                        <th align="center">试卷名称</th>
                        <th align="center">学期</th>
                        <th align="center">年级</th>
                        <th align="center">课程</th>
                        <th align="center">练习时间（分钟）</th>
                        <th align="center">及格分</th>
                        <th align="center">总分</th>
                        <th align="center">生成方式</th>
                        <th width="210px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("EPID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("EPID")%>' id='ck_<%#Eval("EPID") %>' /></label>
                                </td>
                                <td><%#Eval("PaperName") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term")) %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NJ>(Eval("GradeID")) %></td>
                                <td><%#Eval("CIDName") %></td>
                                <td><%#Eval("Minutes") %></td>
                                <td><%#Eval("PassScore")%></td>
                                <td><%#Eval("TotelScore")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.SCFS>(Eval("EType")) %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("EPID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="查看题目" CommandArgument='<%#Eval("EPID")%>' OnClick="lbtn_Detail_Click">查看题目</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_RelPractice" runat="server" CssClass="listbtn btnreplacecolor" ToolTip="发布练习" OnClientClick='return replaceinfo(this);'>发布练习</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_RelPractice" runat="server" CssClass="listbtn btnreplacecolor" ToolTip="发布练习" CommandArgument='<%#Eval("EPID")%>' CommandName='<%#Eval("GradeID") %>' OnClick="lbtn_RelPractice_Click">发布练习</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("EPID") %>' runat="server" />
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





