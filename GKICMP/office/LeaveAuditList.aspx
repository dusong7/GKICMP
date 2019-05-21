<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAuditList.aspx.cs" Inherits="GKICMP.office.LeaveAuditList" %>

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
            $('#btn_Audit').click(function () {
                var ids = document.getElementById("hf_CheckIDS").value;
                if (checkselectones(ids) == false) {
                    alert("系统提示：请至少选择一条信息！");
                    return false;
                }
                else {
                    return openbox('A_id', 'LeaveAuditEdit.aspx', 'id=' + ids, 860, 350, 29);
                }

            });
        });

        function auditainfo(e) {
            var id = $(e).next().next().next().val();
            var lid = $(e).next().next().val();
            var state = $(e).next().next().next().next().val();
            if (state == 1) {
                return openbox('A_id', 'LeaveAuditEdit.aspx', 'id=' + id + '&lid=' + lid, 860, 350, 29);
            }
            else {
                alert("请选择未审核数据进行审核");
                return;
            }
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '../office/LeaveDetail.aspx', 'id=' + id, 950, 550, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="请假审核"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">请假人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_LeaveUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="90">请假日期：</td>
                        <td width="190">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="90">类型：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_LType" runat="server"></asp:DropDownList>
                        </td>
                       <%-- <td align="right " width="60">状态：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_LeaveState" runat="server"></asp:DropDownList>
                        </td>--%>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Audit" runat="server" Text="审核"  CssClass="listbtncss listadd" />
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">请假人</th>
                        <th align="center">类型</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">天数</th>
                        <th align="center">审核人</th>
                        <th align="center">审核日期</th>
                        <th align="center">状态</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("LID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("LID") %>' id='ck_<%#Eval("LID") %>' <%#Istrue(Eval("LeaveState")) %> /></label>
                                </td>--%>
                                <td><%#Eval("LeaveUserName")%></td>
                                <td><%# Eval("LTypeName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("EndDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("LeaveDays")%></td>
                                <td><%#Eval("AuditUserName")%></td>
                                <td><%#Eval("AuditDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" OnClientClick='return auditainfo(this);' Visible='<%#Eval("AuditResult").ToString()=="1"?true:false%>'>审核</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("LID") %>' runat="server" />
                                        <asp:HiddenField ID="hf_LAID" Value='<%#Eval("LAID") %>' runat="server" />
                                        <asp:HiddenField ID="hf_AuditState" Value='<%#Eval("AuditResult") %>' runat="server" />
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


