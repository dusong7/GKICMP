<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrantManage.aspx.cs" Inherits="GKICMP.schoolwork.GrantManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园学生管理平台</title>
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
                return openbox('A_id', 'GrantEdit.aspx', '', 1060, 500, -1);
            });
            $('#btn_Audit').click(function () {
                var id = document.getElementById("hf_CheckIDS").value;
                if (id == "")
                {
                    alert("系统提示：请至少选择一条信息！");
                    return;
                }
                return openbox('A_id', 'GrantAuditEdit.aspx', 'id=' + id, 600, 270, 34)
            })
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'GrantEdit.aspx', 'id=' + id, 1060, 500, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'GrantDetail.aspx', 'id=' + id, 860, 350, 4);
        }
        function auditainfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'GrantAudita.aspx', 'id=' + id, 860, 300, 34);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="助学金管理"></asp:Label>
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
                            <asp:TextBox ID="txt_BName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">申请时间：</td>
                        <td width="250">
                            <asp:TextBox ID="txt_Begin" runat="server" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Width="75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Audit" runat="server" Text="审核" CssClass="listsummary" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">班级</th>
                        <th align="center">助学金类型</th>
                        <th align="center">申请时间</th>
                        <th align="center">审核时间</th>
                        <th align="center">审核人</th>
                        <th align="center">审核状态</th>
                        <th width="105px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("GID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("GID") %>' id='ck_<%#Eval("GID") %>' /></label>
                                </td>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("ClassName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.GrantType>(Eval("GType"))%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("AduitDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("AduitUserName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AduitState"))%></td>
                                <td>
                                    <div style="margin-left: 10px;">
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("AduitState").ToString()=="1"?true:false%>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("GID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("GID") %>' runat="server" />
                                        <%--<asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="audita" Visible='<%#Eval("AduitState").ToString()=="1"?true:false%>' ToolTip="审核" OnClientClick='return auditainfo(this);'></asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("GID") %>' runat="server" />--%>
                                    </div>
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
