<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuRewardManage.aspx.cs" Inherits="GKICMP.studentmanage.StuRewardManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>学生评语管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'StuRewardEdit.aspx', '', 940, 700, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StuRewardEdit.aspx', 'id=' + id, 940, 700, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学生奖惩管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="50px">奖励名称：</td>
                        <td width="70px">
                            <asp:TextBox ID="txt_RewardName" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right" width="50px">学生姓名：</td>
                        <td width="70px">
                            <asp:TextBox ID="txt_UserName" runat="server" Width="90px"></asp:TextBox>
                        </td>
                        <td align="right" width="50px">学年度：</td>
                        <td width="70px">
                            <asp:TextBox ID="txt_EYear" runat="server" Width="90px"></asp:TextBox>
                        </td>
                        <td align="right" width="50px">学期：</td>
                        <td width="70px">
                            <asp:DropDownList ID="ddl_Term" runat="server" Width="80px"></asp:DropDownList>
                        </td>
                        <td align="right" width="50px">奖励级别：</td>
                        <td width="70px">
                            <asp:DropDownList ID="ddl_RewardGrade" runat="server" Width="120px"></asp:DropDownList>
                        </td>
                        <td >
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
                            <%-- <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput"  OnClick="btn_OutPut_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" /></label>
                        </th>
                        <th align="center">姓名</th>
                        <th align="center">班级</th>
                        <th align="center">奖励名称</th>
                        <th align="center">奖励级别</th>
                        <th align="center">奖励等级</th>
                        <th align="center">奖励类别</th>
                        <th align="center">辅导教师</th>
                        <th align="center">奖励单位</th>
                        <th align="center">奖励类型</th>
                        <th align="center">奖励方式</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("SRID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("SRID") %>' id='ck_<%#Eval("SRID") %>' /></label>
                                </td>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("ClassName")%></td>
                                <td><%#Eval("RewardName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RGrade>(Eval("RewardGrade"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RewardType>(Eval("RewardType"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RType>(Eval("RewardType"))%></td>
                                <td><%#Eval("TeacherName")%></td>
                                <td><%#Eval("RewardDep")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RStyle>(Eval("RStyle"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RMode>(Eval("RMode"))%></td>
                                <td>
                                    <%--<asp:LinkButton ID="lbtn_Delete" runat="server" CssClass="listbtn btneditcolor" ToolTip="删除" CommandArgument='<%#Eval("SEID") %>' OnClientClick="return confirm('您确认删除选中的信息吗');" OnClick="lbtn_Delete_Click">删除</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("SRID") %>' runat="server" />
                                   <%-- <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("SEID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("SRID") %>' runat="server" />--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="12" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

