<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourseIFly.aspx.cs" Inherits="GKICMP.resource.ResourseIFly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>



</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">课程：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_Course" runat="server">
                                <asp:ListItem Value="00010001000400010001">语文</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="60">学年：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_Year" runat="server">
                            </asp:DropDownList>
                        </td>
                        <%--<td width="70" align="right">教学楼类型：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_BType"></asp:DropDownList>
                        </td>--%>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">

                <tr>
                    <th align="center">备课明细ID</th>
                    <th align="center">文件id</th>
                    <th align="center">课程目录编码</th>
                    <th align="center">备课明细名称</th>

                   <%-- <th align="center">备课时段</th>--%>
                   <%-- <th align="center">推荐级别</th>--%>
                   <%-- <th align="center">集备状态</th>
                    <th align="center">学校ID</th>--%>

                   <%-- <th align="center">单位类型</th>--%>
                    <th align="center">作者</th>
                    <th align="center">创建时间</th>
                    <th align="center">最后修改时间</th>
                    <th align="center">分享标识</th>

                    <%--<th align="center">分享时间</th>--%>
                    <th align="center">导学案个数</th>
                    <th align="center">教学设计个数</th>
                    <th align="center">课件个数</th>

                    <th align="center">检测习题个数</th>
                    <th align="center">微课视频个数</th>
                    <th align="center">教学反思个数</th>
                  <%--  <th align="center">是否收藏</th>--%>
                    <th align="center">学年</th>
                </tr>
                <asp:Repeater runat="server" ID="rp_List">
                    <ItemTemplate>
                        <tr>

                            <td><%#Eval("PreInfoID")%></td>
                            <td><%#Eval("PrepareFileId")%></td>
                            <td><%#Eval("IndexCd")%></td>
                            <td><%#Eval("PreInfoName")%></td>

                          <%--  <td><%#Eval("Periods")%></td>--%>
                          <%--  <td><%#Eval("RecomLevel")%></td>--%>
                           <%-- <td><%#Eval("ReferenceType")%></td>--%>
                          <%--  <td><%#Eval("SchoolId")%></td>--%>

                          <%--  <td><%#Eval("OrgType")%></td>--%>
                             <td><%#Eval("Writer")%></td>
                            <td><%#GetDate(Eval("CrtDttm"))%></td>
                            <td><%#GetDate(Eval("LastupDttm"))%></td>
                            <td><%#Eval("ShareFlg")%></td>
                         <%--   <td><%#Eval("ShareDttm")%></td>--%>

                            <td><%#Eval("LearnGuideNum")%></td>
                            <td><%#Eval("TeachDesignNum")%></td>
                            <td><%#Eval("CourseWareNum")%></td>

                            <td><%#Eval("TestPaperNum")%></td>
                            <td><%#Eval("MinVideoNum")%></td>
                            <td><%#Eval("TeachThinkNum")%></td>
                           <%-- <td><%#Eval("IsCollect")%></td>--%>
                            <td><%#Eval("SchoolYear")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr runat="server" id="tr_null">
                    <td colspan="15">暂无记录</td>
                </tr>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />

    </form>
</body>
</html>
