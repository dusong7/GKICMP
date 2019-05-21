<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegManage.aspx.cs" Inherits="GKICMP.freshmen.StudentRegManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                //return openbox('A_id', 'StudentRegEdit.aspx', '', 1100, 600, -1);
                return openbox('A_id', 'StuDivideEdit.aspx', '', 1100, 600, -1);
            });
            $('#btn_Reg').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                //return openbox('A_id', 'StuPlacement.aspx', '', 860, 470, -1);
                return openbox('A_id', 'StuDivideClass.aspx', '', 860, 600, 62);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            //return openbox('A_id', 'StudentRegEdit.aspx', 'id=' + id, 1100, 600, 0);
            return openbox('A_id', 'StuDivideEdit.aspx', 'id=' + id, 1100, 600, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StudentRegDetail.aspx', 'id=' + id + '&flag=1', 1100, 600, 4);
        }

        function InputData(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StuUserImport.aspx', '', 860, 470, -1);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="迎新管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>

                    <tr>
                        <td width="100" align="right">所属校区：</td>
                        <td width="150">
                            <asp:DropDownList runat="server" ID="ddl_CID"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td width="100" align="right">身份证：</td>
                        <td width="180">
                           <asp:TextBox ID="txt_IDCard" runat="server"></asp:TextBox>
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
                        <td align="left"></td>
                        <td align="right" valign="middle">

                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd"  />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click"  />
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" OnClientClick="return InputData(this)" />
                            <asp:Button ID="btn_Reg" runat="server" Text="分班" CssClass="listbtncss listoutput"  />
                            <%--<asp:Button ID="btn_PassWord" runat="server" Text="密码重置" CssClass="listsub listpassword" OnClick="btn_PassWord_Click" />--%>
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
                       <%-- <th align="center">用户名</th>--%>
                        <th align="center">校区名称</th>
                        <th align="center">姓名</th>
                        <th align="center">性别</th>
                        <th align="center">民族</th>
                        <th align="center">身份证号码</th>
                        <th align="center">出生日期</th>
                        <th align="center">手机号码</th>
                        <th align="center">住址</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("UID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("UID") %>' id='ck_<%#Eval("UID") %>' </label>
                                </td>
                               <%-- <td><%#Eval("UserName")%></td>--%>
                                <td><%#Eval("CampusName")%></td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("UserSex"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.MZ>(Eval("Nation"))%></td>
                                <td><%#Eval("IDCard").ToString()==""?"暂无身份证信息":Eval("IDCard").ToString().Length>14?Eval("IDCard").ToString().Substring(0,4)+"******"+Eval("IDCard").ToString().Substring(14):"身份证有误，请修改"%></td>
                                <td><%#Convert.ToDateTime( Eval("BirthDay")).ToString("yyyy-MM") %></td>
                                <td><%#Eval("CellPhone")%></td>
                                <td><%#Eval("Address")%></td> 
                                <td>
                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("UID")%>' OnClientClick='return editinfo(this);' >编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("UID") %>' runat="server" />

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

