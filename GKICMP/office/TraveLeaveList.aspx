<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraveLeaveList.aspx.cs" Inherits="GKICMP.office.TraveLeaveList" %>

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
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'TraveLeaveEdit.aspx', '', 840, 450, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            var state = $(e).next().next().next().val();
            if (state == 1) {
                return openbox('A_id', 'TraveLeaveEdit.aspx', 'id=' + id, 840, 450, 0);
            } else {
                alert("只能编辑未审核的数据！");
                return;
            }
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TraveLeaveDetail.aspx', 'id=' + id, 840, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="外出登记"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">外出登记人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_LeaveUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">登记日期：</td>
                        <td width="190">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right " width="60">状态：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_LeaveState" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出Word"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                             <asp:Button runat="server" ID="btn_AllOut" Text="导出Excel" CssClass="listbtncss listoutput" OnClick="btn_AllOut_Click" />
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

                        <th align="center">登记人</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">天数</th>
                        <th align="center">状态</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("LID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("LID") %>' id='ck_<%#Eval("LID") %>' <%#Flag==2?"":Eval("LeaveState").ToString()=="1"?"":"disabled" %>
                                            /></label>
                                </td>
                                <td><%#Eval("LeaveUserName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("EndDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("LeaveDays")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>( Eval("LeaveState"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" Visible="<%# GetIsshow() %>" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("LID") %>' runat="server" />
                                        <asp:HiddenField ID="hf_Leavestate" Value='<%#Eval("LeaveState") %>' runat="server" />
                                    </div>
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


