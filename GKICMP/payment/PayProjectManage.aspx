<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayProjectManage.aspx.cs" Inherits="GKICMP.payment.PayProjectManage" %>

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

    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                //return openbox('A_id', 'PayProjectEdit.aspx', '', 960, 600, -1);
                return openbox('A_id', 'PayEdit.aspx', '', 960, 600, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'PayEdit.aspx', 'id=' + id, 960, 600, 0);
        }

        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'PayEdit.aspx', 'id=' + id, 960, 600, 0);
        //}

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PayProjectDetail.aspx', 'id=' + id, 960, 600, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="缴费项目"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">缴费项目名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_ProjectName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">是否停用：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_IsDisable" runat="server"></asp:DropDownList>
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
                            <%--<asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click"  />--%>
                             <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd"   />
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
                        <th align="center">缴费项目名称</th>
                        <th align="center">缴费总金额</th>
                        <th align="center">是否停用</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PPID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PPID")%>' id='ck_<%#Eval("PPID") %>' <%#Eval("IsDisable").ToString()=="1"?"disabled":"" %> /></label>
                                </td>
                                <td><%#Eval("ProjectName")%></td>
                                <td><%#Eval("PayCount")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsDisable")) %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsDisable").ToString()=="1"? false:true %>' ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>

                                     <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="设置" CommandName="set" CommandArgument='<%#Eval("PPID") %>' OnClick="lbtn_Set_Click" >编辑</asp:LinkButton>--%>

                                     <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细"  OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PPID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_IsDisable" runat="server" CssClass="listbtn btnkskccolor" ToolTip="停用" CommandArgument='<%#Eval("PPID") %>' OnClick="lbtn_IsDisable_Click" OnClientClick="return  confirm('您确认要停用吗？');">停用</asp:LinkButton>
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
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>





