<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuEvaluateManage.aspx.cs" Inherits="GKICMP.studentmanage.StuEvaluateManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>学生评语管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
        //        //return openbox('A_id', 'StuEvaluateEdit.aspx', '', 840, 640, -1);
        //        //window.location.href = "StuEvaluateEdit.aspx";
        //    });
        //});

        function editinfo(e) {
            var id = $(e).next().val();
            //return openbox('A_id', 'StuEvaluateEdit.aspx', 'id=' + id, 840, 640, 0);
            //window.location.href = "StuEvaluateEdit.aspx?id="+id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学生评语管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">学生姓名：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80">学年度：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_EYear" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80">学期：</td>
                        <td width="299">
                            <asp:DropDownList ID="ddl_Term" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput"  OnClick="btn_OutPut_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" /></label>
                        </th>
                        <th align="center">学年度</th>
                        <th align="center">学期</th>
                        <th align="center">姓名</th>
                        <th align="center">班级</th>
                        <th align="center">评语内容</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("SEID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("SEID") %>' id='ck_<%#Eval("SEID") %>' /></label>
                                </td>
                                <td><%#Eval("EYear")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term"))%></td>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("CName")%></td>
                                <td title='<%#Eval("Evaluate") %>'><%#Eval("Evaluate").ToString().Length>20?Eval("Evaluate").ToString().Substring(0,20)+"...":Eval("Evaluate")%></td>
                                <td>
                                    <%--<asp:LinkButton ID="lbtn_Delete" runat="server" CssClass="listbtn btneditcolor" ToolTip="删除" CommandArgument='<%#Eval("SEID") %>' OnClientClick="return confirm('您确认删除选中的信息吗');" OnClick="lbtn_Delete_Click">删除</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑"  CommandArgument='<%#Eval("SEID") %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑"  OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>--%>
                                    <%--<asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("SEID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>--%>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("SEID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

