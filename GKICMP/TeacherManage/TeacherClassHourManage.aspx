<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherClassHourManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherClassHourManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
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
                return openbox('A_id', 'TeacherClassHourEdit.aspx', '', 1160, 560, -1);
            });

            $('#btn_Input').click(function () {
                return openbox('A_id', 'TeacherClassHourImport.aspx', '', 680, 360, 3);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherClassHourEdit.aspx', 'id=' + id, 1100, 500, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'TeacherClassHourDetail.aspx', 'id=' + id + '&flag=1', 860, 470, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="课时管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60" class="auto-style2">姓名：</td>
                        <td width="160" class="auto-style2">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80" class="auto-style2">主教学科：</td>
                        <td width="100" class="auto-style2">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_MainSubject" runat="server"></asp:DropDownList>
                            </div>
                        </td>
                        <td align="right" width="110" class="auto-style2">学年度/学期：</td>
                        <td width="180" class="auto-style2">
                            <div class="sel" style="float: left">
                                <asp:TextBox runat="server" ID="txt_SchoolYear" Width="75"></asp:TextBox>
                                <asp:DropDownList ID="ddl_Semester" runat="server"></asp:DropDownList>
                            </div>
                        </td>
                        <td class="auto-style2">
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table id="texcel" width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <%--<td width="59%" class="btn_op_css"><span style="font-weight:bold; ">说明：</span><span class="editora"></span><span>编辑;</span></td>--%>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="lbtn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport" OnClick="lbtn_MoreSB_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>

            <table width="100%" border='0' cellspacing='0' cellpadding="0" class='listinfoc'>
                <tbody>
                    <tr>
                        <th width="5%" align="center" rowspan="2">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)">
                            </label>
                        </th>
                        <th align="center" rowspan="2">学年度/学期</th>
                        <th align="center" width="75" rowspan="2">姓名</th>
                        <th align="center" rowspan="2">性别</th>
                        <th align="center" rowspan="2">年龄</th>
                        <th align="center" rowspan="2">所授年级</th>
                        <th align="center" colspan="2">主要任教学科及周课时</th>
                        <th align="center" colspan="2">兼教其他学科及周课时</th>
                        <th align="center" rowspan="2">周课时合计（纯课时）</th>
                        <th align="center" rowspan="2">语文、数学<br />
                            英语跨教情况</th>
                        <th align="center" rowspan="2">任行政、辅教<br />
                            或班主任情况</th>
                        <th align="center" rowspan="2">是否上报</th>
                        <th align="center" width="120px" rowspan="2">操作</th>
                    </tr>
                    <tr>
                        <th align="center" width="75">主教学科</th>
                        <th align="center">纯课时数</th>
                        <th align="center" width="75">兼教学科</th>
                        <th align="center">纯课时数</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("THID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("THID")%>' <%#GetState(Eval("IsReport")) %>  id='ck_<%#Eval("THID") %>' />
                                    </label>
                                </td>
                                <td><%#Eval("SchoolYear") %>学年度<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Semester"))%></td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>
                                <td><%#Eval("Age") %></td>
                                <%-- <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NJ>( Eval("GradeID")) %></td>--%>
                                <td><%#Eval("GradeName") %></td>
                                <td><%#Eval("MainName")%></td>
                                <td><%#Eval("MainHours")%></td>
                                <td><%#Eval("PartName")%></td>
                                <td><%#Eval("PartHours") %></td>
                                <%--<td><%#Eval("TotelHours")%></td>--%>
                                <td><%#Eval("TotelMainHours")%></td>
                                <td><%#Eval("SubDesc")%></td>
                                <td><%#Eval("Executive")%></td>
                                <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick="return editinfo(this);" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑">编辑</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("THID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("THID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr_null" runat="server">
                        <td colspan="15" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

