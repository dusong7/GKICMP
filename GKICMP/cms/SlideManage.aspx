<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideManage.aspx.cs" Inherits="GKICMP.cms.SlideManage" %>

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
        $(function () {
            $('#btn_Add').click(function () {
                var flag = document.getElementById("hf_Flag").value;
                return openbox('A_id', 'SlideEdit.aspx', 'flag=' + flag, 960, 440, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            var flag = document.getElementById("hf_Flag").value;
            return openbox('A_id', 'SlideEdit.aspx', 'id=' + id + '&flag=' + flag, 960, 440, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            var flag = document.getElementById("hf_Flag").value;
            return openbox('A_id', 'SlideDetail.aspx', 'id=' + id + '&flag=' + flag, 960, 380, 1);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Flag" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="幻灯片管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">类别：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_SType" runat="server"></asp:DropDownList>
                        </td>
                        <td width="100" align="right">
                            <asp:Literal runat="server" ID="ltl_Name"></asp:Literal>名称：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_SlideName" runat="server"></asp:TextBox>
                        </td>
                        <td width="80" align="right">创建日期：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_BeginDate" Width="85px" onclick="WdatePicker({skin:'whyGreen' ,startDate:'%y-%M-%d %H:%m:&s',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_EndDate" Width="85px" onclick="WdatePicker({skin:'whyGreen' ,startDate:'%y-%M-%d %H:%m:&s',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
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
                        <th align="center">类别</th>
                        <th align="center">
                            <asp:Literal runat="server" ID="ltl_SlideName"></asp:Literal>名称</th>
                        <th align="center">链接</th>
                        <th align="center">失效日期</th>
                        <th align="center">创建人</th>
                        <th align="center">创建日期</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("SliID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("SliID") %>' id='ck_<%#Eval("SliID") %>' /></label>
                                </td>
                                <td><%#Eval("STypeName")%></td>
                                <td><%#Eval("SlideName")%></td>
                                <td><%#Eval("SlideUrl")%></td>
                                <td><%#Eval("InvalidDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("SliID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

