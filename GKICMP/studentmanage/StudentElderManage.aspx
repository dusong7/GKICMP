<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentElderManage.aspx.cs" Inherits="GKICMP.studentmanage.StudentElderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'StudentElderEdit.aspx', 'sid=' + document.getElementById("hf_TID").value, 1160, 560, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StudentElderEdit.aspx', 'id=' + id + '&sid=' + document.getElementById("hf_TID").value, 1100, 470, 0);
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="positionc" id="div_top" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="家庭信息"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
            <tbody>
                <tr>
                    <th align="left">
                        <div class="xxsm" >
                            <ul>
                                <li><a href="StudentEdit.aspx?id=<%=StuID %>">基本信息</a></li>
                                <li class="selected"><a href="StudentElderManage.aspx?id=<%=StuID %>">家庭信息</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
            </tbody>
        </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="left"></td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfoc">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">家长姓名</th>
                        <th align="center">手机号</th>
                        <th align="center">工作单位</th>
                        <th align="center">职务</th>
                        <th align="center">关系</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PID") %>' id='ck_<%#Eval("PID") %>' /></label>
                                    <%--<input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TEID") %>' id='ck_<%#Eval("TEID") %>' <%#GetState(Eval("UserType")) %> /></label>--%>
                                </td>
                                <td><%#Eval("ElderName")%></td>
                                <td><%#Eval("CellPhone")%></td>
                                <td><%#Eval("PostDep")%></td>
                                <td><%#Eval("PostName")%></td>
                                <td><%#Eval("ShipName")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                <%--    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>--%>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("PID") %>' runat="server" />
                                    <%--</div>--%>
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




    </form>
</body>
</html>

