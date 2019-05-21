<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TBuildingManage.aspx.cs" Inherits="ICMP.assetmanage.TBuildingManage" %>

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
                return openbox('A_id', 'TBuildingEdit.aspx', '', 900, 620, -1);
            });
        });
        function editinfo(e) {
            //var id = $(e).next().next().val();
            var id = $(e).next().val();
            return openbox('A_id', 'TBuildingEdit.aspx', 'id=' + id, 900, 620, 0);
        }
        function admininfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TBuildingAdmin.aspx', 'id=' + id, 900, 620, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教学楼管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">教学楼名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_BName" runat="server"></asp:TextBox>
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
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">教学楼名称</th>
                        <th align="center">教学楼代码</th>
                        <th align="center">所属校区</th>
                        <th align="center">层数</th>
                        <th align="center">总面积</th>
                        <th align="center">地址</th>
                        <th align="center">排序</th>
                        <th align="center">状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("BID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("BID") %>' id='ck_<%#Eval("BID") %>' /></label>
                                </td>
                                <td><%#Eval("BName")%></td>
                                <td><%#Eval("BNumber")%></td>
                                <td><%#Eval("CampusName")%></td>
                                <td><%#Eval("FloorNum")%></td>
                                <td><%#Eval("AllBuilding")%></td>
                                <td><%#Eval("BAddress")%></td>
                                <td><%#Eval("BOrder")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BState>(Eval("BState"))%></td>
                                <td>
                                    <div>
                                        <%--<asp:LinkButton ID="lbtn_Edit" Style="margin-left: 10px;" runat="server" CssClass="editora" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>--%>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor"  OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                       <%-- <asp:LinkButton ID="lbtn_Admin" runat="server" CssClass="listbtn btndetialcolor" ToolTip="设置管理员" OnClientClick='return admininfo(this);'>设置管理员</asp:LinkButton>--%>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("BID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


