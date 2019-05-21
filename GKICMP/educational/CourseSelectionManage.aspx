<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseSelectionManage.aspx.cs" Inherits="GKICMP.educational.CourseSelectionManage" %>

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
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="选课管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">学生姓名：</td>
                        <td width="90px">
                            <asp:TextBox ID="txt_UIDName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">学年度：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_EYear" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">学期：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_Term" runat="server"></asp:DropDownList>
                        </td>
                        <td width="70" align="right">选课日期：</td>
                        <td>
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
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
                        <th align="center">学生姓名</th>
                        <th align="center">学年度</th>
                        <th align="center">学期</th>
                        <th align="center">选课名称</th>
                        <th align="center">选课日期</th>
                        <th align="center">是否提交</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("CSID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("CSID")%>' id='ck_<%#Eval("CSID") %>' /></label>
                                </td>
                                <td><%#Eval("UIDName")%></td>
                                <td><%#Eval("Eyear")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ >( Eval("Term"))%></td>
                                <td title='<%#Eval("CourseNames") %>'><%#GetCutStr( Eval("CourseNames"),20)%></td>
                                <td><%#Eval("SelectDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot >( Eval("IsSubmit"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" CommandArgument='<%#Eval("CSID") %>' ToolTip="编辑" OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    </div>
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

