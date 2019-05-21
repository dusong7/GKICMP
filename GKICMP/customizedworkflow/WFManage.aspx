<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFManage.aspx.cs" Inherits="GKICMP.customizedworkflow.WFManage" %>

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
                window.location.href = "WFFormEdit.html";
                return false;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                //var did = document.getElementById("hf_DID").value;
                //var hour = document.getElementById("ltl_TotelHour").innerText;
                //return openbox('A_id', 'TeacherPlaneEdit.aspx', '&did=' + did + '&totelhour=' + hour, 1060, 650, -1);

            });
        });

        function audit(e) {
            var id = $(e).parent().children().last().val();
            window.location.href = "FormAuditEdit.html?WFFID=" + id;
            return false;
            //var hour = document.getElementById("ltl_TotelHour").innerText;
            //return openbox('A_id', 'TeacherPlaneEdit.aspx', 'id=' + id + '&totelhour=' + hour, 960, 650, 0);
        }

        //function formuser(e) {

        //    var id = $(e).parent().next().children().last().val();
        //    window.location.href = "FormUserSel.html?WFFID=" + id;
        //    return false;

        //    //return openbox('A_id', 'TeacherPlaneEdit.aspx', 'id=' + id + '&totelhour=' + hour, 960, 650, 0);

        //}


        function editinfo(e) {
            var id = $(e).parent().children().last().val();
            //console.log(id);
            window.location.href = "WFFormEdit.html?WFFID=" + id;
            return false;
            //var hour = document.getElementById("ltl_TotelHour").innerText;
            //return openbox('A_id', 'TeacherPlaneEdit.aspx', 'id=' + id + '&totelhour=' + hour, 960, 650, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="流程管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hf_AvoidSubmit" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
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
                        <th align="center">工作流名称</th>
                        <th align="center">创建人</th>
                        <th align="center">创建时间</th>
                        <th align="center">审批人</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("FormName")%></td>
                                <td><%#Eval("CreateUserName") %></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Convert.ToInt32(Eval("IsSetAuditor"))==0?"未设置":"已设置"%></td>
                                <td>
                                    <asp:LinkButton ID="btn_PStateq" runat="server" CssClass="listbtn btneditcolor" CommandArgument='<%#Eval("WFFID") %>' CommandName='<%#Eval("IsEnable") %>' ToolTip='<%#Eval("IsEnable").ToString()=="1"?"禁用":"启用" %>' Text='<%#Eval("IsEnable").ToString()=="1"?"禁用":"启用" %>' OnClick="btn_PStateq_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="btn_Delete" runat="server" CssClass="listbtn btndeletecolor" ToolTip="删除" CommandArgument='<%#Eval("WFFID") %>' CommandName='<%#Eval("FormName") %>' OnClientClick='return confirm("确认删除数据吗？")' OnClick="btn_Delete_Click">删除</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btngraduationcolor" ToolTip="编辑表单" OnClientClick='return editinfo(this);'>编辑表单</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btnformedit" ToolTip="流程设置" OnClientClick='return audit(this);'>流程设置</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("WFFID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="5">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


