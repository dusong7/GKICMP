<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherAssessmentManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherAssessmentManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        //return openbox('A_id', 'TeacherAssessmentEdit.aspx', 'id=' + id + '&flag=' + flag, 1100, 500, 0);
        //        return openbox('A_id', 'TeacherAssessmentEdit.aspx', '&flag=' + document.getElementById("hf_CID").value, 860, 500, -1);

        //    });
        //});
        //function editinfo(e) {
        //    var flag = document.getElementById("hf_CID").value;
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'TeacherAssessmentEdit.aspx', 'id=' + id + '&flag=' + flag, 860, 500, 0);
        //}
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherAssessmentDetail.aspx', 'id=' + id + '&flag=1', 400, 270, 4);
        }

    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考核管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_Name" Width="80" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">
                            <asp:Literal ID="ltl_Year" runat="server"></asp:Literal></td>
                        <td width="150">
                            <asp:TextBox ID="txt_TSYear" Width="80" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})"></asp:TextBox>
                        </td>
                        <td width="60" align="right">考核结果：</td>
                        <td width="100">
                            <asp:DropDownList runat="server" ID="ddl_AssResult"></asp:DropDownList>
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
                            <asp:Button ID="lbtn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport" OnClick="lbtn_MoreSB_Click" />
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
                        <th align="center">姓名</th>
                       <%-- <th align="center">身份证</th>--%>
                        <th align="center">性别</th>
                        <th align="center">
                            <asp:Literal ID="ltl_Years" runat="server"></asp:Literal></th>
                        <th align="center">考核结果</th>
                        <th align="center">备注</th>
                        <th align="center">是否上报</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TAID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TAID") %>' id='ck_<%#Eval("TAID") %>' <%#GetState(Eval("IsReport")) %> /></label>
                                </td>
                                <td><%#Eval("TName")%></td>
                              <%--  <td><%#Eval("IDCardNum")%></td>--%>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>
                                <td><%#Eval("TSYear","{0:yyyy}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.KHJG>(Eval("AssResult"))%></td>
                                <td><%#Eval("TSDesc")%></td>
                                 <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" CommandName='<%#Eval("TAID") %>' OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                        <%--<asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>--%>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TAID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TAID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                       
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
