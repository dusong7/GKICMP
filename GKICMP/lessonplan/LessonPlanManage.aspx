<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPlanManage.aspx.cs" Inherits="GKICMP.lessonplan.LessonPlanManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LessonPlanEdit.aspx', '', 760, 290, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().next().val();
            return openbox('A_id', 'LessonPlanEdit.aspx', 'id=' + id, 760, 290, 0);
        }
        //备课计划清单添加
        function billinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'LessonPlanBill.aspx', 'lid=' + id, 940, 400, 0);
        }

        function billmanageinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LessonPlanBillManage.aspx', 'lid=' + id, 940, 400, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="备课管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">备课名称：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_LName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">备课类型：</td>
                        <td width="200">
                            <asp:DropDownList ID="ddl_LType" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">校区：</td>
                        <td width="200">
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
                        <th align="center">备课名称</th>
                        <th align="center">学年/学期</th>
                        <th align="center">备课类型</th>
                        <th align="center">校区</th>
                        <th align="center">执教教师</th>
                        <th align="center">录入人</th>
                        <th align="center">录入时间</th>
                        <th width="120px" align="center" runat="server" id="th1">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("LID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("LID") %>' id='ck_<%#Eval("LID") %>' /></label>
                                </td>
                                <td><%#Eval("LName")%></td>
                                <td><%#Eval("LYear")%><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TID")) %></td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("CapmusName") %></td>
                                <td><%#Eval("TeacherName") %></td>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td runat="server">
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" CommandArgument='<%#Eval("LID") %>' OnClientClick="return editinfo(this);">编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("LID") %>' CommandName='<%#Eval("LType") %>' OnClick="lbtn_Detail_Click" ToolTip="详情">详情</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Bill" runat="server" CssClass="listbtn btnimportcolor" CommandArgument='<%#Eval("LID") %>' CommandName='<%#Eval("LType") %>' OnClick="lbtn_Bill_Click">计划清单</asp:LinkButton>
                                        <%--<asp:LinkButton ID="lbtn_Prepare" runat="server" CssClass="listbtn btncompletecolor" OnClick="lbtn_Prepare_Click" CommandName='<%#Eval("LType") %>' CommandArgument='<%#Eval("LID") %>'>备课</asp:LinkButton>--%>
                                        <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("LID") %>' runat="server" />
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

