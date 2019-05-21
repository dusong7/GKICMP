<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerRegManage.aspx.cs" Inherits="GKICMP.computermanage.ComputerRegManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>班班通登记管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        $(function () {
            $('#btn_RecAdd').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'ComputerRegEdit.aspx', '', 840, 400, -1);
            });
        });

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ComputerRegDetail.aspx', 'id=' + id, 840, 400, 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="登记管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">姓名：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                        </td>

                        <td align="right" width="80">登记时间：</td>
                        <td width="299">
                            <asp:TextBox runat="server" ID="txt_BeginDate" onfocus="SetCanler()" Width="75px"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_EndDate" onfocus="SetCanler()" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
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
                           <asp:Button ID="btn_RecAdd" runat="server" Text="补录"  CssClass="listbtncss listadd" />
                            <%-- <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />--%>
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput"  OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" /></label>
                        </th>--%>
                        <th align="center">姓名</th>
                        <th align="center">学科</th>
                        <th align="center">课题</th>
                        <th align="center">计算机名</th>
                        <th align="center">IP地址</th>
                        <th align="center">登记形式</th>
                        <th align="center">登记时间</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("CRID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("CRID") %>' id='ck_<%#Eval("CRID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("CName")%></td>
                                <td><%#Eval("ChapterName")%></td>
                                <td><%#Eval("ComputerName")%></td>
                                <td><%#Eval("IP")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RegType>(Eval("RegType")) %></td>
                                <td><%#Eval("RegDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                <td>
                                    <asp:LinkButton ID="btn_Delete" runat="server" CssClass="listbtn btneditcolor" ToolTip="删除" CommandArgument='<%#Eval("CRID") %>' OnClientClick="return confirm('您确认删除选中的信息吗？');" OnClick="lbtn_Delete_Click">删除</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("CRID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("CRID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

