<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceAuditManage.aspx.cs" Inherits="GKICMP.invoice.InvoiceAuditManage" %>

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
                return openbox('A_id', 'InvoiceEdit.aspx', '', 1000, 580, -1);
            });
        });

        function aduitinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'InvoiceAuditEdit.aspx', 'iid=' + id, 900, 360, 29);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'InvoiceDetail.aspx', 'id=' + id, 1000, 580, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="报销审核管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70px">报销类别：</td>
                        <td width="160px">
                            <asp:DropDownList runat="server" ID="ddl_InvType"></asp:DropDownList>
                        </td>
                        <td align="right" width="70px">报销方式：</td>
                        <td width="100px">
                            <asp:DropDownList runat="server" ID="ddl_InvModel"></asp:DropDownList>
                        </td>
                        <td width="70px" align="right">报销日期：</td>
                        <td width="250px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                        <td width="70px" align="right">报销人：</td>
                        <td width="350px">
                            <asp:TextBox ID="txt_CreateUser" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">报销单位</th>
                        <th align="center">报销金额</th>
                        <th align="center">报销类别</th>
                        <th align="center">报销方式</th>
                        <th align="center">报销人</th>
                        <th align="center">报销日期</th>
                        <th align="center">办理状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("IID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("IID") %>' id='ck_<%#Eval("IID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("AccountUnit")%></td>
                                <td><%#Eval("TotelCash")%></td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("ModelName")%></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("IState"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Aduit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" Visible='<%#Eval("IState").ToString()=="1"?true:false %>' OnClientClick='return aduitinfo(this);'>审核</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick="return viewinfo(this);">详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("IID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

