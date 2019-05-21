<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonComprehensive.aspx.cs" Inherits="GKICMP.lessonplan.LessonComprehensive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        function editinfo(e) {
            var id = $(e).next().val();
            var lid = document.getElementById("hf_LID").value;
            return openbox('A_id', 'LessonPlanBill.aspx', 'id=' + id + '&lid=' + lid, 940, 400, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField runat="server" ID="hf_LID" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="备课综合查询"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                            <td align="right" width="70">备课类型：</td>
                        <td>
                            <asp:DropDownList ID="ddl_LType" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="70">备课名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_LName" runat="server"></asp:TextBox>
                        </td>
                    
                        <td align="right" width="70">活动内容：</td>
                        <td width="150">
                            <asp:TextBox runat="server" ID="txt_AContent"></asp:TextBox>
                        </td>
                        <td align="right" width="80px">学年度/学期：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_LYear" size="8"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddl_TID"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">周次</th>
                        <th align="center">备课名称</th>
                        <th align="center">学年/学期</th>
                        <th align="center">备课类型</th>
                        <th align="center">时间</th>
                        <th align="center">活动内容</th>
                        <th align="center">执教教师</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td>第<%#Eval("WeekNum")%>周</td>
                                <td><%#Eval("LName") %></td>
                                <td><%#Eval("LYear") %><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TID")) %></td>
                                <td><%#Eval("TypeName") %></td>
                                <td><%#Eval("PDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("AContent")%></td>
                                <td><%#Eval("TeacherName") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

