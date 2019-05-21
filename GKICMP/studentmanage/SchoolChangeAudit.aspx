<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolChangeAudit.aspx.cs" Inherits="GKICMP.studentmanage.SchoolChangeAudit" %>

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
        function auditinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'SchoolChangeAuditEdit.aspx', 'id=' + id, 800, 330, 34);
        }
        function editinfo(e) {
            var id = $(e).next().next().val();
            var stid = $(e).next().next().next().val();
            return openbox('A_id', 'SchoolChangeEdit.aspx', 'id=' + id + '&flag=2' + '&stid=' + stid, 960, 600, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SchoolChangeDetail.aspx', 'id=' + id, 840, 400, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学生变动审核管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>

                        <td align="right" width="60">姓名：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">变动类型：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_SCType" runat="server"></asp:DropDownList>
                        </td>
                        <td width="70" align="right">变动日期：</td>
                        <td width="230px">
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
            <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="lbtn_Audit" runat="server" Text="审核"  CssClass="listbtncss listadd" />
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
                        <th align="center">姓名</th>
                        <th align="center">班级</th>
                        <th align="center">变动类型</th>
                        <th align="center">变动日期</th>
                        <th align="center">审核状态</th>
                        <th align="center">审核人</th>
                        <th align="center">审核日期</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TID")%>' id='ck_<%#Eval("TID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("RealName") %></td>
                                <%-- <td><%# Eval("ClaIDName")%></td>--%>
                                <td><%# Eval("ClassName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BDLX>(Eval("SCType"))%></td>
                                <td><%#Eval("SCDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#GetColor(Eval("AduitState")) %></td>
                                <td><%#Eval("AduitUserName") %></td>
                                <td><%#Eval("AduitDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btnauditcolor" Visible='<%#(Eval("AduitState").ToString()=="2"||Eval("AduitState").ToString()=="3")?false:true %>' ToolTip="审核" OnClientClick='return auditinfo(this);'>审核</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("StuID") %>' runat="server" />
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
