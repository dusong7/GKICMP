<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverManage.aspx.cs" Inherits="GKICMP.electiver.ElectiverManage" %>

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
            $('#btn_Add').click(function () {
                return openbox('A_id', 'ElectiverEdit.aspx', '', 980, 310, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'ElectiverEdit.aspx', 'id=' + id, 980, 310, 0);
        }
        //function viewinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'ElectiverDetail.aspx', 'id=' + id, 980, 510, 0);
        //}

        function setcourse(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ElectiverCourse.aspx', 'id=' + id, 980, 510, 56);
        }
        var a;
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="选课任务"></asp:Label></td>
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
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加" CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除" CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
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
                        <th align="center">任务名称</th>
                        <th align="center">学年度/学期</th>
                        <th align="center">报名时间</th>
                        <th align="center">预选日期</th>
                        <th align="center">任务结束日期</th>
                        <th align="center">任务状态</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("EleID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("EleID") %>' id='ck_<%#Eval("EleID") %>' /></label>
                                </td>
                                <td><%#Eval("ElectiverName")%></td>
                                <td><%#Eval("EYear")%>学年度<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TermID")) %></td>
                                <td><%#Eval("EBegin","{0:yyyy-MM-dd}")%>至<%#Eval("EEnd","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("EstimateBDate","{0:yyyy-MM-dd}").ToString()=="1900-01-01"?"无":(Eval("EstimateBDate","{0:yyyy-MM-dd}")+"至"+Eval("EstimateEDate","{0:yyyy-MM-dd}")) %></td>
                                <td><%#Eval("EStopDate","{0:yyyy-MM-dd}")%></td>

                                <td><%#GetStateName(Eval("EBegin"),Eval("EEnd"),Eval("EstimateBDate"),Eval("EstimateEDate"))%></td>
                                <td>

                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" Visible='<%# GetState(Eval("IsEstmate"),Eval("EBegin"), Eval("EEnd"), Eval("EstimateBDate"), Eval("EstimateEDate"))==1?true:false%>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Set" runat="server" CssClass="listbtn btnseatsequencecolor" ToolTip="开课设置" Visible='<%# GetState(Eval("IsEstmate"),Eval("EBegin"), Eval("EEnd"), Eval("EstimateBDate"), Eval("EstimateEDate"))==1?true:false%>' OnClientClick='return setcourse(this);'>开课设置</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("EleID") %>' runat="server" />

                                    <asp:LinkButton ID="lbtn_Stop" runat="server" CssClass="listbtn btndeletecolor" ToolTip="停止" Visible='<%# GetState(Eval("IsEstmate"),Eval("EBegin"), Eval("EEnd"), Eval("EstimateBDate"), Eval("EstimateEDate"))>1?GetState(Eval("IsEstmate"),Eval("EBegin"), Eval("EEnd"), Eval( "EstimateBDate"), Eval("EstimateEDate"))<4?true:false:false%>' CommandArgument='<%#Eval("EleID") %>' OnClick="lbtn_Stop_Click">停止</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_Stop" runat="server" CssClass="listbtn btndeletecolor" ToolTip="停止" Visible='<%#Eval("EState")=="4"? false:true%>' CommandArgument='<%#Eval("EleID") %>' OnClick="lbtn_Stop_Click">停止</asp:LinkButton>--%>

                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" CommandArgument='<%#Eval("EleID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>

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
