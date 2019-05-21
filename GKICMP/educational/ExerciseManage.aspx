<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExerciseManage.aspx.cs" Inherits="GKICMP.educational.ExerciseManage" %>

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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="题目管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">题型：</td>
                        <td width="80px">
                            <asp:DropDownList runat="server" ID="ddl_EType"></asp:DropDownList>
                        </td>
                        <td width="60" align="right">难易程度：</td>
                        <td width="80px">
                            <asp:DropDownList runat="server" ID="ddl_Difficulty"></asp:DropDownList>
                        </td>
                        <td align="right" width="40">课程：</td>
                        <td width="80px">
                            <asp:DropDownList ID="ddl_CID" runat="server"></asp:DropDownList>
                        </td>
                        <td width="40" align="right">年级：</td>
                        <td width="80px">
                            <asp:DropDownList runat="server" ID="ddl_GradeID"></asp:DropDownList>
                        </td>
                        <td width="40" align="right">学期：</td>
                        <td width="180px">
                            <asp:DropDownList runat="server" ID="ddl_Term"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Assembly" runat="server" Text="自动组卷" CssClass="listbtncss listedit" OnClick="btn_Assembly_Click" />
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
                        <th align="center">题型</th>
                        <th align="center">难易程度</th>
                        <th align="center">课程</th>
                        <th align="center">年级</th>
                        <th align="center">学期</th>
                        <th align="center">分数</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("EID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("EID")%>' id='ck_<%#Eval("EID") %>' /></label>
                                </td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ExerciseType>(Eval("EType")) %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.DifficultyType>(Eval("Difficulty")) %></td>
                                <td><%#Eval("CIDName") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NJ>(Eval("GradeID")) %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term")) %></td>
                                <td><%#Eval("Score")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("EID")%>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" CommandArgument='<%#Eval("EID")%>' OnClick="lbtn_Detail_Click">详细</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>




