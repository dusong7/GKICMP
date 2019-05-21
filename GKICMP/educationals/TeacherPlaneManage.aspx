<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPlaneManage.aspx.cs" Inherits="GKICMP.educationals.TeacherPlaneManage" %>

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
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                var did = document.getElementById("hf_DID").value;
                var hour = document.getElementById("ltl_TotelHour").innerText;
                return openbox('A_id', 'TeacherPlaneEdit.aspx', '&did=' + did + '&totelhour=' + hour, 880, 560, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            var hour = document.getElementById("ltl_TotelHour").innerText;
            return openbox('A_id', 'TeacherPlaneEdit.aspx', 'id=' + id + '&totelhour=' + hour, 880, 560, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />

        <asp:HiddenField ID="hf_AvoidSubmit" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td style="color: red;">&nbsp;&nbsp;
                            <asp:Label ID="lbl_ClaidName" runat="server"></asp:Label>课时总数：<asp:Label runat="server" ID="ltl_TotelHour"></asp:Label></td>
                        <%-- <td align="right" valign="middle">--%>
                        <%--<asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />--%>
                        <%--<asp:Button ID="btn_ScheduleStart" runat="server" Text="开始排课" CssClass="listback" OnClick="btn_ScheduleStart_Click" />--%>
                        <%--<asp:Button ID="btn_SCAll" runat="server" Text="全部排课" CssClass="listback" OnClientClick='return confirm("全部排课会删除所有课表,确定全部排课！")' OnClick="btn_ScheduleCourseAll_Click" />--%>
                        <%--</td>--%>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">学科名称</th>
                        <th align="center">任课教师</th>
                        <th align="center">节数</th>
                       <%-- <th align="center">连节</th>--%>
                        <th align="center">连次</th>
                        <th align="center">场地要求</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TPID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TPID") %>' id='ck_<%#Eval("TPID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("CourseName")%></td>
                                <td><%#Eval("TeacherName")%></td>
                                <td><%#Eval("JieShu")%></td>
                               <%-- <td><%#Eval("LianJie")%></td>--%>
                                <td><%#Eval("LianCi")%></td>
                                <td><%#Eval("CRIDName")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TPID") %>' runat="server" />
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
        <%--<wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />--%>
    </form>
</body>
</html>


