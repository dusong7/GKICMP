<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachMaterialManage.aspx.cs" Inherits="GKICMP.educational.TeachMaterialManage" %>

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
                var cid = document.getElementById("hf_CID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'TeachMaterialEdit.aspx', '&cid=' + cid, 860, 280, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            var cid = document.getElementById("hf_CID").value;
            return openbox('A_id', 'TeachMaterialEdit.aspx', 'id=' + id + '&cid=' + cid, 860, 280, 0);
        }

        function succ() {
            var id = document.getElementById("hf_CID").value;
            window.parent.location.href = "TeachMaterialList.aspx?id=" + id;
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">教材名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_TMName" runat="server"></asp:TextBox>
                        </td>
                        <%--<td width="70" align="right">所属版本：</td>
                        <td width="200">
                            <asp:DropDownList runat="server" ID="ddl_TEdition"></asp:DropDownList>
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
                            <%--<asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">教材名称</th>
                        <th align="center">所属版本</th>
                        <th align="center">适用课程</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TMID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TMID")%>' id='ck_<%#Eval("TMID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("TMName")%></td>
                                <td><%#Eval("VersionName")%></td>
                                <td><%#Eval("CourseName")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Deleted" runat="server" CssClass="listbtn btndelcolor" CommandArgument='<%#Eval("TMID") %>' ToolTip="删除" OnClick="lbtn_Deleted_Click">删除</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TMID") %>' runat="server" />
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

