<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAllocationManage.aspx.cs" Inherits="GKICMP.assetmanage.AssetAllocationManage" %>

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
                var flag = $("#hf_Flag").val();
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'AssetAllocationEdit.aspx', 'flag=' + flag, 1150, 660, -1);
            });
        });
        function editinfo(e) {
            var flag = $("#hf_Flag").val();
            var id = $(e).next().next().val();
            return openbox('A_id', 'AssetAllocationEdit.aspx', 'id=' + id + '&flag=' + flag, 1150, 660, 0);
        }
        function viewinfo(e) {
            var flag = $("#hf_Flag").val();
            var id = $(e).next().val();
            return openbox('A_id', 'AssetAllocationDetail.aspx', 'id=' + id + '&flag=' + flag, 1150, 560, 4);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="资产调拨管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <div id="div" runat="server">
                            <td align="right" width="60">移交人：</td>
                            <td width="160px">
                                <asp:TextBox ID="txt_OutUser" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" width="60">接收人：</td>
                            <td width="160px">
                                <asp:TextBox ID="txt_AcceptUser" runat="server"></asp:TextBox>
                            </td>
                        </div>
                        <td align="right" width="60">
                            <asp:Literal ID="ltl_OutDep" runat="server"></asp:Literal></td>
                        <td width="160px">
                            <asp:TextBox ID="txt_OutDep" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">
                            <asp:Literal ID="ltl_Date" runat="server"></asp:Literal></td>
                        <td>
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                        <th align="center" id="td_outuser" runat="server">移交人</th>
                        <th align="center" id="td_acceptuser" runat="server">接收人</th>
                        <th align="center" id="td_outdep" runat="server">调出单位</th>
                        <th align="center" id="td_indep" runat="server">调入单位</th>
                        <th align="center" id="td_acceptdep" runat="server">接收部门</th>
                        <th align="center">
                            <asp:Literal ID="ltl_Data" runat="server"></asp:Literal></th>
                        <th width="130px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("AAID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("AAID")%>' id='ck_<%#Eval("AAID") %>' /></label>
                                </td>
                                <td id="td_outuser1" runat="server"><%#Eval("OutUser") %></td>
                                <td id="td_acceptuser1" runat="server"><%#Eval("AcceptUser") %></td>
                                <td id="td_outdep1" runat="server"><%#Eval("OutDep") %></td>
                                <td id="td_indep1" runat="server"><%#Eval("InDep") %></td>
                                <td id="td_acceptdep1" runat="server"><%#Eval("InDep") %></td>
                                <td><%#Eval("AllocationDate","{0:yyyy-MM-dd}") %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_AAID" runat="server" Value='<%#Eval("AAID") %>' />

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







