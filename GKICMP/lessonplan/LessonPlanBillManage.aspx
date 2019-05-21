<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPlanBillManage.aspx.cs" Inherits="GKICMP.lessonplan.LessonPlanBillManage" %>

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
                var lid = document.getElementById("hf_LID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LessonPlanBill.aspx', 'lid=' + lid, 940, 400, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            var lid = document.getElementById("hf_LID").value;
            return openbox('A_id', 'LessonPlanBill.aspx', 'id=' + id + '&lid=' + lid, 940, 400, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField runat="server" ID="hf_LID" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>备课计划管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="计划清单"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <%--<asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">周次</th>
                        <th align="center">时间</th>
                        <th align="center">活动内容</th>
                        <th align="center">
                            <asp:Literal runat="server" ID="ltl_TeacherName"></asp:Literal></th>
                        <th width="120px" align="center" runat="server">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td>第<%#Eval("WeekNum")%>周</td>
                                <td><%#Eval("PDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("AContent")%></td>
                                <td><%#Eval("TeacherName") %></td>
                                <td runat="server">
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" Visible='<%#Eval("IsPrepare").ToString()=="0"?true:false %>' CssClass="listbtn btneditcolor" OnClientClick="return editinfo(this);">编辑</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("LDID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Delete" runat="server" CssClass="listbtn btndelcolor" CommandArgument='<%#Eval("LDID") %>' OnClientClick="return confirm('确认此条备课计划清单吗？');" OnClick="lbtn_Delete_Click">删除</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("LDID") %>' runat="server" />
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
    </form>
</body>
</html>
