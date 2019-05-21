<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairALLList.aspx.cs" Inherits="ICMP.assetmanage.RepairALLList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '../office/RepairDetail.aspx', 'id=' + id, 860, 580, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="报修查询"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">报修对象：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RepairObj" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">报修日期：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">受理人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_DutyUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">状态：</td>
                        <td>
                            <asp:DropDownList ID="ddl_ARState" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">报修对象</th>
                        <th align="center">报修人</th>
                        <th align="center">报修日期</th>
                        <th align="center">受理部门</th>
                        <th align="center">本校受理人</th>
                      <%--  <th align="center">维修单位</th>
                        <th align="center">联系方式</th>--%>
                        <th align="center">完成日期</th>
                        <th align="center">完成说明</th>
                        <th align="center">状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                               <%-- <td><%#Eval("RepairObj")%></td>--%>
                                 <td><%#Eval("RepairObj").ToString().Length>20?Eval("RepairObj").ToString().Substring(0,19)+"…":Eval("RepairObj").ToString()%></td>
                                <td><%#Eval("CreaterUserName")%></td>
                                <td><%#Eval("ARDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("DutyDepName")%></td>
                                <td><%#Eval("RealName")%></td>
                              <%--  <td><%#Eval("SName")%></td>
                                <td><%#Eval("LinkPhone")%></td>--%>
                                <td><%#Eval("CompDate","{0:yyyy-MM-dd}").ToString()==""?"":Eval("CompDate","{0:yyyy-MM-dd}")%></td>
                                <td title='<%#Eval("CompDesc") %>'><%#GetCutStr( Eval("CompDesc"),15)%></td>
                                <td><%#GetState( Eval("ARState") )%></td>
                                <td>
                                    <div>
                                        <%--<asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="viewa" ToolTip="详细" OnClientClick='return viewinfo(this);'></asp:LinkButton>--%>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("ARID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


