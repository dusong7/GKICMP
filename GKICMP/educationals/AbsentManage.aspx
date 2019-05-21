<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbsentManage.aspx.cs" Inherits="GKICMP.educationals.AbsentManage" %>

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
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="代课安排"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="40">申请人：</td>
                        <td width="80">
                            <asp:TextBox ID="txt_LeaveUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">申请日期：</td>
                        <td width="210">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="90">类型：</td>
                        <td width="280">
                            <asp:DropDownList ID="ddl_LType" runat="server"></asp:DropDownList>
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
                        <th align="center">申请人</th>
                        <th align="center">类型</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">天数</th>
                        <th align="center">代课安排情况</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("LeaveUserName")%></td>
                                <td><%# Eval("LTypeName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("EndDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("LeaveDays")%></td>
                                <td><%#Eval("dksfwc").ToString()=="1"?"<span style='color:red'>未安排<span>":Eval("dksfwc").ToString()=="2"?"<span style='color:green'>安排中<span>":"<span style='color:blue'>已完成<span>"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_SubArrange" runat="server" CssClass="listbtn btneditcolor" ToolTip="代课安排" CommandArgument='<%#Eval("LID") %>' Visible='<%#Eval("dksfwc").ToString()=="3"? false:true %>' OnClick="lbtn_SubArrange_Click">代课安排</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_SubDetail" runat="server" CssClass="listbtn btneditcolor" ToolTip="详情" CommandArgument='<%#Eval("LID") %>' Visible='<%#Eval("dksfwc").ToString()=="3"? true:false %>'  OnClick="lbtn_SubDetail_Click">详情</asp:LinkButton>

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
