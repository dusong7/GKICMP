<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSearchDetail.aspx.cs" Inherits="GKICMP.cms.NewsSearchDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园门户管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>

    <script type="text/javascript">
        function audit(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'NewsAudit.aspx', 'id=' + id, 400, 200, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <%--<div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">姓名：</td>
                        <td width="170">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">发布日期：</td>
                        <td width="350">
                            <asp:TextBox runat="server" ID="txt_BeginDate" Width="85px" onclick="WdatePicker({'skin':whyGreen})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_EndDate" Width="85px" onclick="WdatePicker({'skin':whyGreen})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">标题</th>
                        <th align="center">发布日期</th>
                        <th align="center">审核状态</th>
                        <th align="center">状态</th>
                        <%-- <th width="100px" align="center">操作</th>--%>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("NID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("NID") %>' id='ck_<%#Eval("NID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("NewsTitle")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NewsAuditState>(Eval("AuditState")).ToString() %></td>
                                <td><%#Eval("Nstate").ToString()=="1"?"已发布":"未发布"%></td>
                                <%--<td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细">详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='' runat="server" />                
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--<wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />--%>
    </form>
</body>
</html>
