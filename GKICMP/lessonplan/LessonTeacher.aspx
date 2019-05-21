<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonTeacher.aspx.cs" Inherits="GKICMP.lessonplan.LessonTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
      
        function Evaluate(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LessonEvaluate.aspx', 'id=' + id, 860, 640, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            var y1 = $("#txt_Year").val();
            var y = document.getElementById("txt_Year").value;
            var t = $("#ddl_Term").val();
            return openbox('A_id', 'LessonDetail.aspx', 'id=' + id + '&term=' + t + '&year=' + y, 860, 650, 4);
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
                    <td class="positiona"><a>首页</a><span>></span>学工管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="助学金管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">教师姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_TName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">学年：</td>
                        <td width="250">
                            <asp:TextBox ID="txt_Year" runat="server"  ></asp:TextBox>
                        </td>
                        <td width="70" align="right">学期：</td>
                        <td width="250">
                            <asp:DropDownList ID="ddl_Term" runat="server"></asp:DropDownList>
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
                        <th align="center">教师姓名</th>
                        <th align="center">计划备课数</th>
                        <th align="center">已备课数</th>
                        <th width="105px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("tname")%></td>
                                <td><%#Eval("JH")%></td>
                                <td><%#Eval("YB")%></td>
                                <td>
                                    <div style="margin-left: 10px;">
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("nid") %>' OnClick="lbtn_Detail_Click"  ToolTip="详情">详情</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("nid") %>' runat="server" />
                                         <asp:LinkButton ID="lbtn_Evaluate" runat="server" CssClass="listbtn btneditcolor"  ToolTip="评价" OnClientClick='return Evaluate(this);'>评价</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("nid") %>' runat="server" />
                                        <%--<asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="audita" Visible='<%#Eval("AduitState").ToString()=="1"?true:false%>' ToolTip="审核" OnClientClick='return auditainfo(this);'></asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("GID") %>' runat="server" />--%>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

