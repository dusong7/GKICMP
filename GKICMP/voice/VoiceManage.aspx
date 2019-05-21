<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoiceManage.aspx.cs" Inherits="GKICMP.voice.VoiceManage" %>

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
                return openbox('A_id', 'VoiceEdit.aspx', '', 900, 460, -1);
            });
        });

       
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'VoiceEdit.aspx', 'id=' + id, 900, 460, 0);
        }
        function info(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'VoiceDetail.aspx', 'id=' + id, 900, 460, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="视频配置"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

     
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="80" align="right">设备名称：</td>
                        <td width="180">
                            <asp:TextBox ID="txt_EquipName" runat="server"></asp:TextBox>
                        </td>
                        <td width="80" align="right">用户名：</td>
                        <td width="180">
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
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
                        <th align="center">设备名称</th>
                        <th align="center">IP地址</th>
                        <th align="center">端口号</th>
                         <th align="center">用户名</th>
                        <th align="center">密码</th>
                        <th align="center">设备端口</th>
                        <th width="80px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("VID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("VID") %>' id='ck_<%#Eval("VID") %>' /></label>
                                </td>
                                <td align="center"><%#Eval("EquipName")%></td>
                                <td align="center"><%#Eval("EquipIP")%></td>
                                <td align="center"><%#Eval("PotNum")%></td>
                                <td align="center"><%#Eval("UserName")%></td>
                                <td align="center"><%#Eval("UserPwd")%></td>
                                <td align="center"><%#Eval("EquipPotNum")%></td>

                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_Info" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详情" OnClientClick='return info(this);'>详情</asp:LinkButton>--%>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("VID") %>' runat="server" />
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
