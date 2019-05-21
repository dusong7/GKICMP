<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubstituteManage.aspx.cs" Inherits="GKICMP.educationals.SubstituteManage" %>

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
    <script type="text/javascript">
        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'SubstituteEdit.aspx', 'id=' + id, 600, 650, 0);
        //}
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SubstituteDetail.aspx', 'id=' + id, 840, 500, 1);
        }
    </script>
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="代课管理"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="40">代课人：</td>
                        <td width="80">
                            <asp:TextBox ID="txt_SubUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">代课日期：</td>
                        <td width="210">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="90">代课课程：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_SubCoruse" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="90">状态：</td>
                        <td width="280">
                            <asp:DropDownList ID="ddl_SubState" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                             <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
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
                        <th align="center">请假人</th>
                        <th align="center">代课人</th>
                        <th align="center">代课日期</th>
                        <th align="center">代课课程</th>
                        <th align="center">代课节次</th>
                        <th align="center">状态</th>
                        <th align="center" width="140px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("AbID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("AbID") %>' id='ck_<%#Eval("AbID") %>' <%#Istrue(Eval("SubState")) %> /></label>
                                </td>
                                <td><%#Eval("AbsentUserName")%></td>
                                <td><%#Eval("SubUserName")%></td>
                                <td><%#Eval("SubDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("SubCoruseName")%></td>
                                <td><%#Eval("SubNum")%></td>
                                <td><%# GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.PraState>( Eval("SubState"))%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" Visible='<%#Eval("SubState").ToString()=="1"?false:true %>' OnClick="lbtn_Edit_Click" CommandArgument='<%#Eval("AbID") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_AbID" runat="server" Value='<%#Eval("AbID") %>' />
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

