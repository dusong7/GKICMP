<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAuditList.aspx.cs" Inherits="GKICMP.cms.NewsAuditList" %>

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
            $('#btn_Publish').click(function () {
                var ids = document.getElementById("hf_CheckIDS").value;
                if (checkselectones(ids) == false) {
                    alert("系统提示：请至少选择一条信息！");
                    return false;
                }
                else {
                    return true;
                }
            });
            var p = getUrlParam("flag")
            if (p == 2)
            {
                $("#select").addClass("selected");
                $("#selected").removeClass("selected");
            }
        });

        function audit(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'NewsAudit.aspx', 'id=' + id, 400, 200, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="网站管理"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="文章审核"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
            <tbody>
                <tr>
                    <th colspan="7" align="left" style="padding-left: 15px">
                        <div class="xxsm">
                            <ul>
                                <%--<li class="selected"><a href="TeacherEdit.aspx?TID=<%=TID %>">基本信息</a></li>--%>
                                <li id="selected" class="selected"><a href="NewsAuditList.aspx?flag=1">文章审核</a></li>
                                <li id="select"><a href="NewsAuditList.aspx?flag=2">全部文章</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
            </tbody>
        </table>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">文章标题：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_BName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">所属栏目：</td>
                        <td width="350">
                            <asp:DropDownList ID="ddl_MName" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">标题</th>
                        <th align="center">所属栏目</th>
                        <th align="center">发布日期</th>
                        <th align="center">作者</th>
                        <th align="center">图片新闻</th>
                        <th align="center">审核状态</th>
                        <th align="center">发布状态</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("NID")%>l'>
                                        <%--<input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("NID") %>' id='ck_<%#Eval("NID") %>' <%#Gettrue(Eval ("Nstate")) %> /></label>--%>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("NID") %>' id='ck_<%#Eval("NID") %>' <%#Gettrue(Eval("AuditState")) %> /></label>
                                </td>
                                <%-- <td><%#Eval("NewsTitle")%></td>--%>
                                <td title='<%#Eval("NewsTitle")%>'><%#Eval("NewsTitle").ToString().Length>30?Eval("NewsTitle").ToString().Substring(0,29)+"…":Eval("NewsTitle").ToString()%></td>
                                <td><%#Eval("MName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("NauthorName")%></td>
                                <td><%#Eval("IsImgNews").ToString()==""?"否":GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsImgNews"))%></td>
                                <td><%#Eval("AuditState").ToString()==""?"未审": GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NewsAuditState>(Eval("AuditState")).ToString() %></td>
                                <td><%#Eval("Nstate").ToString()=="1"?"已发布":"未发布"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("NID") %>' Visible='<%#Eval("AuditState").ToString()=="1"? false:true %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" CommandArgument='<%#Eval("NID") %>' OnClick="lbtn_Detail_Click">详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("NID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btnreportncolor" ToolTip="审核" OnClientClick='return audit(this);' Visible='<%#Eval("AuditState").ToString()=="1"? false:true %>'>审核</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("NID") %>' runat="server" />
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






