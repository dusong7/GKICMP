<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherHolidayManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherHolidayManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
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
                return openbox('A_id', 'TeacherHolidayEdit.aspx', '', 900, 560, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherHolidayEdit.aspx', 'id=' + id, 900, 500, 0);
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="请假管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <%--      <div class="dvTab">
<ul class="menuall">
<li class="tab activeTab"><a href="TeacherHolidayManage.aspx">请假管理</a></li>

<li class="tab "><a href="AttendRecordManage.aspx">考勤打卡</a></li>

</ul>
<div class="dv"></div>
</div>--%>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>

                        <td width="127" align="right">长假类型：</td>
                        <td width="260">
                            <asp:DropDownList ID="ddl_HType" runat="server"></asp:DropDownList>
                        </td>
                        <td width="80" align="right">姓名：</td>
                        <td width="180">
                            <asp:TextBox ID="txt_TeacName" runat="server"></asp:TextBox>
                        </td>
                        <td width="127" align="right">所授学科：</td>
                        <td width="188">
                            <asp:DropDownList ID="ddl_TCourse" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click1" />
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
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
                        <%--<th align="center">单位</th>--%>
                        <th align="center">所授学科</th>
                        <th align="center">长假类型</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">天数</th>
                        <th align="center">休假备注</th>
                        <th align="center">是否上报</th>
                        <th width="80px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("THID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("THID") %>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("THID") %>' /></label>
                                </td>
                                <td align="center"><%#Eval("TeacherName")%></td>
                                <%--  <td align="center"><%#Eval("DepName")%></td>--%>
                                <td align="center"><%#Eval("CourseName") %></td>
                                <td align="center"><%#Eval("HTypeName") %></td>
                                <td align="center"><%#Eval("HStartDate","{0:yyyy-MM-dd}")%></td>
                                <td align="center"><%#Eval("HEndDate","{0:yyyy-MM-dd}")%></td>
                                <td align="center"><%#Eval("HDays")%></td>
                                <td align="center"><%#Eval("HolidayDesc")%></td>
                                <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("THID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("THID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("THID") %>' runat="server" />
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

