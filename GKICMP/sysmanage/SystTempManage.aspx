<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystTempManage.aspx.cs" Inherits="GKICMP.sysmanage.SystTempManage" %>

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
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
        //        return openbox('A_id', 'GradeEdit.aspx', '', 800, 400, -1);
        //    });
        //});
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SystTempEdit.aspx', 'id=' + id, 800, 550, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="模板管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">模板名称</th>
                        <th align="center">更新日期</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("STID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("STID")%>' id='ck_<%#Eval("STID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("TempName")%></td>
                                <td><%#Convert.ToDateTime( Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("STID") %>' runat="server" />
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
