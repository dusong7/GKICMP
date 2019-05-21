<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanManage.aspx.cs" Inherits="GKICMP.office.WorkPlanManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        return openbox('A_id', 'WorkPlanEdit.aspx', '', 960, 450, -1);
        //    });
        //});
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'WorkPlanEdit.aspx', 'id=' + id, 860, 450, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'WorkPlanDetail.aspx', 'id=' + id + '&flag=1', 960, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="工作计划"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">责任人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_DutyUser" runat="server" Style="width: 85px"></asp:TextBox>
                        </td>
                        <td align="right" width="60">结束时间：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">周号</th>
                        <th align="center">内容</th>
                        <th align="center">参与人</th>
                        <th align="center">部门</th>
                         <th align="center">责任人</th>
                        <th align="center">开始时间</th>
                        <th align="center">结束时间</th>
                        <th align="center">是否完成</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">

                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PlanID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PlanID") %>' <%#Eval("IsComplete").ToString()=="1"?"disabled":"" %> id='ck_<%#Eval("PlanID") %>' /></label>
                                </td>
                                <td title='<%#Eval("EYear")+"学年度"+GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term"))+"第"+Eval("WeekNum")+"周"%>'><%#Eval("EYear")+"学年度"+GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term"))+"第"+Eval("WeekNum")+"周"%></td>
                               <%-- <td><%#Eval("ExamName")%></td>--%>
                                <td><%#Eval("ExamName").ToString().Length>20?Eval("ExamName").ToString().Substring(0,19)+"…":Eval("ExamName").ToString()%></td>
                                <td title='<%#Eval("AllUsers") %>'><%#Eval("AllUsers").ToString().Length>30?Eval("AllUsers").ToString().Substring(0,30)+"...":Eval("AllUsers")%></td>
                                <td><%#Eval("DepName")%></td>
                                 <td><%#Eval("DutyUserName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("IsComplete").ToString()=="1"?"已完成":"<span style='color:red'>未完成</span>"%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" CommandArgument='<%#Eval("PlanID") %>' Visible='<%#Eval("IsComplete").ToString()=="1"?false:true %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                        <%-- <asp:HiddenField ID="HiddenField2" Value='<%#Eval("PlanID") %>' runat="server" />--%>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PlanID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Complete" runat="server" CssClass="listbtn btncompletecolor" CommandArgument='<%#Eval("PlanID") %>' Visible='<%#Eval("IsComplete").ToString()=="1"?false:true %>' CommandName="Comp" OnClick="lbtn_Complete_Click">完成</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField3" Value='<%#Eval("PlanID") %>' runat="server" />
                                    </div>
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



