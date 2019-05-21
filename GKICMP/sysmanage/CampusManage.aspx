<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampusManage.aspx.cs" Inherits="GKICMP.sysmanage.CampusManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园基础管理平台</title>
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
                return openbox('A_id', 'CampusEdit.aspx', '', 1060, 480, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'CampusEdit.aspx', 'id=' + id, 1060, 480, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="校区管理"></asp:Label>
                    </td>
                </tr>
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
                         <th align="center">校区编号</th>
                        <th align="center">校区名称</th>
                        <th align="center">校区地址</th>
                        <th align="center">校区联系电话</th>
                        <th align="center">校区负责人</th>
                        <th align="center">校区面积</th>
                        <th align="center">校区建筑面积</th>
                        <th align="center">校区教学科研仪器设备总值</th>
                        <th align="center">校区固定资产总值</th>
                        <th align="center">正式使用日期</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("CID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("CID") %>' id='ck_<%#Eval("CID") %>' /></label>
                                </td>
                                <td><%#Eval("CID")%></td>
                                <td><%#Eval("CampusName")%></td>
                                <td><%#Eval("ButtonCode")%></td>
                                <td><%#Eval("LinkNum")%></td>
                                <td><%# Eval("DutyUserName")%></td>
                                <td><%#Eval("AreaSize")%></td>
                                <td><%#Eval("BuiltupAea")%></td>
                                <td><%#Eval("EquipmentValue")%></td>
                                <td><%#Eval("FixedAssets")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td>
                                    <div style="margin-left: 25px">
                                       <%-- <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="editora" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>--%>
                                        <asp:LinkButton ID="lbtn_Edit"  runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("CID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="12">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
