<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendVacationManage.aspx.cs" Inherits="GKICMP.teachermanage.AttendVacationManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>  
     <script src="../EasyUI/jquery.min.js"></script>
    <%--<script src="../js/jquery-3.1.1.min.js"></script>--%>
    <%--<script src="../js/jquery.easyui.min.js"></script>--%>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
   
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <%--<script src="../js/jquery.min.js"></script>--%>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
  
    <script type="text/javascript">

        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'AttendVacationEdit.aspx', '', 800, 460, -1);
            });
        });

        function info(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AttendVacationEdit.aspx', 'id=' + id, 800, 460, 0);
        }
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'AttendVacationEdit.aspx', 'id=' + id, 800, 460, 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="假期管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

     
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="80" align="right">名称：</td>
                        <td width="180">
                            <asp:TextBox ID="txt_VacName" runat="server"></asp:TextBox>
                        </td>
                        <td width="127" align="right">开始时间：</td>
                        <td width="300">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                        <th align="center">名称</th>
                        <th align="center">开始时间</th>
                        <th align="center">结束时间</th>
                       <%-- <th width="80px" align="center">操作</th>--%>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("Vid")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("Vid") %>' id='ck_<%#Eval("Vid") %>' /></label>
                                </td>
                                <td align="center"><%#Eval("VacName")%></td>
                                <td align="center"><%#Eval("VBegin","{0:yyyy-MM-dd}")%></td>
                                <td align="center"><%#Eval("VEnd","{0:yyyy-MM-dd}")%></td>
                                <%--<td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Info" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详情" OnClientClick='return info(this);'>详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TPID") %>' runat="server" />
                                </td>--%>
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