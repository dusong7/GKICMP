<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairList.aspx.cs" Inherits="GKICMP.office.RepairList" %>

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
                return openbox('A_id', 'RepairEdit.aspx', '', 860, 450, -1);
            });
        });

        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'RepairEdit.aspx', 'id=' + id, 860, 400, -1);
        //}

        function editinfo(e) {
            var id = $(e).next().next().val();
            var ARState = $(e).next().next().next().val();
            if (ARState == 0) {
                return openbox('A_id', 'RepairEdit.aspx', 'id=' + id, 860, 450, 0);
            }
            else {
                alert("只能编辑状态为未受理的数据");
                return false;
            }
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'RepairDetail.aspx', 'id=' + id, 860, 580, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的报修"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">报修设备：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RepairObj" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80">报修日期：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">受理人：</td>
                        <td width="150px">
                            <asp:TextBox ID="txt_DutyUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">状态：</td>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
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
                        <th align="center">报修设备</th>
                        <th align="center">报修日期</th>
                        <th align="center">受理部门</th>
                        <th align="center">本校受理人</th>
                        <th align="center">维修单位</th>
                        <th align="center">联系方式</th>
                        <th align="center">完成日期</th>
                        <th align="center">状态</th>
                        <th width="80px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("ARID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("ARID") %>' id='ck_<%#Eval("ARID") %>' <%#istrue(Eval ("ARState") )%> /></label>
                                </td>
                                <td><%#Eval("RepairObj")%></td>
                                <td><%#Eval("ARDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("DutyDepName")%></td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#Eval("SName")%></td>
                                <td><%#Eval("LinkPhone")%></td>
                                <td><%#Eval("CompDate","{0:yyyy-MM-dd}").ToString()==""?"":Eval("CompDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GetState( Eval("ARState"))%></td>
                                <td>
                                    <%-- <div class="operationd">--%>
                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="editora" Style="margin-left: 10px;" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="viewa" ToolTip="详细" OnClientClick='return viewinfo(this);'></asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#int.Parse(Eval("ARState").ToString())>0?false :true%>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("ARID") %>' runat="server" />
                                    <asp:HiddenField ID="hf_ARState" Value='<%#Eval("ARState") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_IsConfirm" runat="server" CssClass="listbtn btncompletecolor" Visible='<%#Eval("ARState").ToString()=="2"?true :false%>' CommandArgument='<%#Eval("ARID") %>' OnClientClick="return  confirm('您是否确认完成？');" OnClick="lbtn_IsConfirm_Click">确认完成</asp:LinkButton>
                                    <%--</div>--%>
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
