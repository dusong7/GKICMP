<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverScoreManage.aspx.cs" Inherits="GKICMP.electiver.ElectiverScoreManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />

    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>

    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script>
        $(function () {
            //$('#btn_Add').click(function () {
            //    return openbox('A_id', 'ElectiverScoreEdit.aspx', '', 980, 310, -1);
            //});

            $('#btn_Import').click(function () {
                return openbox('A_id', 'ElectiverScoreImport.aspx', '', 980, 410, -1);
            });
        });

        function importdata(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'ElectiverScoreImport.aspx', 'id=' + id, 980, 410, 3);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考试成绩"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">任务名称：</td>
                        <td width="80">
                            <asp:TextBox ID="txt_ElectiverName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">学年度/学期：</td>
                        <td width="240">
                            <asp:TextBox ID="txt_EYear" runat="server" Width="70"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddl_TermID"></asp:DropDownList>
                        </td>
                        <%--<td align="right" width="100px">课程名称：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Course"></asp:DropDownList></td>--%>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_Import" runat="server" Text="导入"   CssClass="listbtncss listinput" />
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
                        <th align="center">学年/学期</th>
                        <th align="center">任务名称</th>
                        <th align="center">课程名称</th>
                        <th align="center">学生姓名</th>
                        <th align="center">分数</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("SSID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("SSID") %>' id='ck_<%#Eval("SSID") %>' /></label>
                                </td>
                                <td><%#Eval("EYear")%>学年度<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TermID")) %></td>
                                <td><%#Eval("ElectiverName") %></td>
                                <td><%#Eval("CourseName")%></td>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("Score")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("SSID") %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("SSID") %>'>详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_EleID" Value='<%#Eval("SSID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10">暂无记录</td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <%--<asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_Import" runat="server" Text="导入"   CssClass="listbtncss listinput" />--%>
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
                        <th align="center">学年/学期</th>
                        <th align="center">任务名称</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("EleID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("EleID") %>' id='ck_<%#Eval("EleID") %>' /></label>
                                </td>
                                <td><%#Eval("EYear")%>学年度<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TermID")) %></td>
                                <td><%#Eval("ElectiverName") %></td>
                                <td>
                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("SSID") %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("SSID") %>'>详情</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Add" runat="server" CssClass="listbtn btneditcolor" ToolTip="添加成绩" CommandArgument='<%#Eval("EleID") %>' OnClick="lbtn_Add_Click">添加成绩</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Import" runat="server" CssClass="listbtn btnimportcolor" ToolTip="导入" OnClientClick="return importdata(this);">导入</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("EleID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_EleID" Value='<%#Eval("EleID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
