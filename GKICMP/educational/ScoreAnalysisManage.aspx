<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreAnalysisManage.aspx.cs" Inherits="GKICMP.educational.ScoreAnalysisManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智慧校园基础管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
  
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考试管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">年级：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_GID" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">学年度：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_EYear" runat="server" Width="80px"></asp:TextBox>
                        </td>
                        <td align="right" width="60">学期：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_Term" runat="server" width="80"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">考试名称：</td>
                        <td width="100px">
                            <asp:TextBox ID="txt_ExamName" runat="server" Width="90px"></asp:TextBox>
                        </td>
                        <td width="70" align="right">考试时间：</td>
                        <td width="200px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                          <%--  <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />--%>
                            <%--<asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">年级</th>
                        <th align="center" >学年度</th>
                        <th align="center">学期</th>
                        <th align="center">考试名称</th>
                        <th align="center">考试时间</th>
                       <%-- <th align="center">座位生成方式</th>--%>
                        <th width="130px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("GIDName")%></td>
                                <td><%#Eval("Eyear")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ >( Eval("Term"))%></td>
                                <td><%#Eval("ExamName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%>--<%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td>
                                    <div>
                                         <asp:LinkButton ID="lbtn_ScoreAnalysis" runat="server" CssClass="listbtn btnreportncolor" ToolTip="成绩分析" CommandName="fx"  CommandArgument='<%#Eval("EID") %>' OnClick="lbtn_Set_Click" >成绩分析</asp:LinkButton>
                                         <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btncompletecolor" ToolTip="成绩详情" CommandName="xq"  CommandArgument='<%#Eval("EID") %>' OnClick="lbtn_Set_Click" >成绩详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("EID") %>' runat="server" />
                                    </div>
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



