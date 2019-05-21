<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairPeopleList.aspx.cs" Inherits="ICMP.assetmanage.RepairPeopleList" %>

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
        function compinfo(e) {
            var id = $(e).next().val();
            var ARState = $(e).next().next().val();
            //if (ARState == 0) {
            return openbox('A_id', 'RepairPeopleEdit.aspx', 'id=' + id, 860, 440, 0);
            //}
            //else {
            //    alert("只能完成状态为已受理的数据");
            //    return false;
            //}
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '../office/RepairDetail.aspx', 'id=' + id, 860, 580, 4);
        }
        function reject(e)
        {
            var id = $(e).next().val();
            return openbox('A_id', '../office/RepairReject.aspx', 'id=' + id, 560, 280, 57);
        }
        function yj(e) {
            var id = $(e).next().val();
            return openbox('A_id', '../office/RepairTransfer.aspx','id=' + id, 500, 290, 60);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span><asp:Literal runat="server" ID="ltl_Sign"></asp:Literal></span><asp:Label ID="lbl_Menuname" runat="server" Text="报修记录"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">报修设备：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RepairObj" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">报修日期：</td>
                        <td width="260">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="40">状态：</td>
                        <td width="150">
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

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">报修设备</th>
                        <th align="center">报修人</th>
                        <th align="center">报修日期</th>
                        <th align="center">受理部门</th>
                        <th align="center">本校受理人</th>
                       <%-- <th align="center">维修单位</th>
                        <th align="center">联系方式</th>--%>
                        <th align="center">完成日期</th>

                        <th align="center">状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("RepairObj").ToString().Length>20?Eval("RepairObj").ToString().Substring(0,19)+"…":Eval("RepairObj").ToString()%></td>
                                <td><%#Eval("CreaterUserName")%></td>
                                <td><%#Eval("ARDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("DutyDepName")%></td>
                                <td><%#Eval("RealName")%></td>
                                <%--<td><%#Eval("SName")%></td>
                                <td><%#Eval("LinkPhone")%></td>--%>
                                <td><%#Eval("CompDate","{0:yyyy-MM-dd}").ToString()==""?"":Eval("CompDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GetState( Eval("ARState") )%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="listbtn btneditcolor" Visible='<%#int.Parse(Eval("ARState").ToString())==0 ? true:false %>' OnClientClick='return reject(this);'>驳回</asp:LinkButton>
                                         <asp:HiddenField ID="HiddenField3" Value='<%#Eval("ARID") %>' runat="server" />
                                         <asp:LinkButton ID="lbtn_YJ" runat="server" CssClass="listbtn btneditcolor" Visible='<%#int.Parse(Eval("ARState").ToString())==1 ? true:false %>' OnClientClick='return yj(this);' >移交</asp:LinkButton>
                                          <asp:HiddenField ID="HiddenField4" Value='<%#Eval("ARID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_SL" runat="server" CssClass="listbtn btneditcolor" Visible='<%#int.Parse(Eval("ARState").ToString())==0 ? true:false %>' CommandArgument='<%#Eval("ARID") %>' OnClientClick="return  confirm('您是否确认受理？');" OnClick="lbtn_SL_Click">受理</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Comp" runat="server" CssClass="listbtn btneditcolor" Visible='<%#int.Parse(Eval("ARState").ToString())==1 ? true:false %>' OnClientClick='return compinfo(this);'>完成</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("ARID") %>' runat="server" />
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("ARState") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("ARID") %>' runat="server" />
                                        <asp:HiddenField ID="hf_ARState" Value='<%#Eval("ARState") %>' runat="server" />
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



