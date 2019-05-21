<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysRoleManage.aspx.cs" Inherits="GKICMP.sysmanage.SysRoleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
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
                return openbox('A_id', 'SysRoleEdit.aspx', '', 600, 320, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'SysRoleEdit.aspx', 'id=' + id, 600, 320, 0);
        }
        //function viewinfo(e) {
        //    var id = $(e).next().val();
        //    return openbox('A_id', 'SysRoleDetail.aspx', 'id=' + id, 860, 600, 4);
        //}
        function roleinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'RoleRight.aspx', 'id=' + id, 1040, 900, 0);
        }
        //function admininfo(e) {
        //    var id = $(e).next().val();
        //    return openbox('A_id', '', 'id=' + id, 860, 450, 4);
        //}
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="角色管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">角色名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RName" Text="" runat="server"></asp:TextBox>
                        </td>
                        
                        <%--<td width="70" align="right">教学楼类型：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_BType"></asp:DropDownList>
                        </td>--%>
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
                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />--%>
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
                        <th align="center">角色名称</th>
                        
                        <th align="center">角色备注</th>
                       
                        
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("RoleID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("RoleID")%>' id='ck_<%#Eval("RoleID") %>' /></label>
                                </td>
                                <td><%#Eval("RoleName")%></td>
                                
                                <td><%#Eval("RoleDesc")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit"  runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Role"  runat="server" CssClass="listbtn btnqxcolor" OnClientClick='return roleinfo(this);'>权限</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("RoleID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="6">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


