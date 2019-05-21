<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitManage.aspx.cs" Inherits="GKICMP.office.VisitManage" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'VisitEdit.aspx', '', 940, 530, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().next().val();
            return openbox('A_id', 'VisitEdit.aspx', 'id=' + id, 940, 530, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'VisitDetail.aspx', 'id=' + id, 840, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="来访登记"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">来访人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_VisitUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">来访日期：</td>
                        <td width="240">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                        <th align="center">来访人</th>
                        <th align="center">来访时间</th>
                        <th align="center">对接人</th>
                        <th align="center">联系电话</th>
                        <th align="center">离开时间</th>
                        <th align="center">登记人</th>
                        <th align="center">登记时间</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("VID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("VID") %>' id='ck_<%#Eval("VID") %>' /></label>
                                </td>
                                <td><%#Eval("VisitUser")%></td>
                                <td><%#Eval("VDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("SchoolUser")%></td>
                                <td><%#Eval("LinkNum")%></td>
                                <td><%#Eval("LeaveDate")%></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Out" runat="server" CssClass="listbtn btncompletecolor" CommandArgument='<%#Eval("VID") %>' OnClick="lbtn_Out_Click" ToolTip="离开" OnClientClick='return confirm("确认来访人员离开？");'>离开</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("VID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
