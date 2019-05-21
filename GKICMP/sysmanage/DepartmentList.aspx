<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="GKICMP.sysmanage.DepartmentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
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
                var flag = getUrlParam("flag");
                return openbox('A_id', 'DepartmentEdit.aspx', '&flag=' + flag, 790, 500, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            var flag = getUrlParam("flag");
            return openbox('A_id', 'DepartmentEdit.aspx', 'id=' + id + '&flag=' + flag, 790, 500, 0);
        }

    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="基础数据管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                       <%-- <td align="right" width="60">所属校区：</td>
                        <td width="299">
                            <asp:DropDownList ID="ddl_CID" runat="server"></asp:DropDownList>
                        </td>--%>

                        <td align="right" width="60">
                            <asp:Literal ID="ltl_Search" runat="server">部门名称：</asp:Literal></td>
                        <td width="299">
                            <asp:TextBox ID="txt_DepName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="btntab">
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
                      <%-- <th align="center"> 
                           <asp:Literal ID="ltl_ID" runat="server">部门ID</asp:Literal></th>--%>
                         <th align="center">
                            <asp:Literal ID="ltl_DepName" runat="server">部门名称</asp:Literal></th>
                        <th align="center">负责人</th>
                        <th align="center">所属年级</th>
                         <th align="center">
                            <asp:Literal ID="ltl_name" runat="server">别名</asp:Literal></th>
                        <th align="center">所属校区</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("DID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("DID") %>' id='ck_<%#Eval("DID") %>' /></label>
                                </td>
                               <%--  <td><%#Eval("DID")%></td>--%>
                                <td><%#Eval("DepName")%></td>
                                <td><%#Eval("MasterName")%></td>
                                <td><%#Eval("GIDName")%></td>
                                <td><%#int.Parse(Eval("DepType").ToString())==(int)GK.GKICMP.Common.CommonEnum.DepType.职能部门?Eval("DepMark"):Eval("OtherName")%></td>
                                <td><%#Eval("CampusName")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("DID") %>' runat="server" />
                                    </div>
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


