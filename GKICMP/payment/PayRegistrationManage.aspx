<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayRegistrationManage.aspx.cs" Inherits="GKICMP.payment.PayRegistrationManage" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'PayRegistrationEdit.aspx', '', 960, 400, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'PayRegistrationEdit.aspx', 'id=' + id, 960, 400, 0);
        }
        function viewinfo(e) {
            //var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'PayRegistrationDetail.aspx', 'id=' + id, 950, 560, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="缴费登记"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">学生姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_StuName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">缴费日期：</td>
                        <td width="280">
                            <asp:TextBox ID="txt_BeginDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">缴费项目：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_PIID" runat="server"></asp:DropDownList>
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
                        <th align="center">学生姓名</th>
                        <th align="center">缴费项目</th>
                        <th align="center">缴费金额</th>
                        <th align="center">缴费日期</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PRID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PRID")%>' id='ck_<%#Eval("PRID") %>'  /></label>
                                </td>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("PName")%></td>
                                <td><%#Eval("RegCount")%></td>
                                 <td><%#Eval("RegDate","{0:yyyy-MM-dd}")%></td>
                                <%--<td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsDisable")) %></td>--%>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor"  ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PRID") %>' runat="server" />
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





