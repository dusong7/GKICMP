<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceManage.aspx.cs" Inherits="GKICMP.performance.PerformanceManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>考核管理</title>
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
                return openbox('A_id', 'PerformanceEdit.aspx', '', 700, 210, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PerformanceEdit.aspx', 'id=' + id, 700, 210, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ContractDetail.aspx', 'id=' + id, 960, 450, 4);
        }
        function admininfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '', 'id=' + id, 860, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考核管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">考核名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_PerName" Text="" runat="server"></asp:TextBox>
                        </td>

                        <td width="80" align="right">状态：</td>
                        <td width="130">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_IsUse" runat="server"></asp:DropDownList>
                            </div>
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
                        <th align="center">考核名称</th>
                        <th align="center">录入人</th>
                        <th align="center">录入日期</th>
                        <th align="center">状态</th>
                        <th align="center">禁用日期</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PFID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PFID")%>' id='ck_<%#Eval("PFID") %>' /></label>
                                </td>
                                <td><%#Eval("PerName") %></td>
                                <td><%#Eval("CreateUserName") %></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.State>(Eval("IsUse")) %></td>
                                <td><%#GetDate(Eval("StopDate")) %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField runat="server" ID="hf_PFID" Value='<%#Eval("PFID") %>' />
                                    <asp:LinkButton ID="lbtn_Add" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsUse").ToString()=="1" ? false:true %>' ToolTip="添加指标" CommandArgument='<%#Eval("PFID") %>' OnClick="lbtn_Add_Click">添加指标</asp:LinkButton>
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
