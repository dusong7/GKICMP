<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeAuditList.aspx.cs" Inherits="GKICMP.office.OverTimeAuditList" %>

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
        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'OverTimeEdit.aspx', '', 840, 450, -1);
            });
        });
        function auditainfo(e) {
            var id = $(e).next().next().val();
            var lid = $(e).next().next().next().val();
                return openbox('A_id', 'OverTimeAuditEdit.aspx', 'id=' + id + '&oid=' + lid, 860, 350, 29);
            
        }

        function viewinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'OverTimeDetail.aspx', 'id=' + id + '&flag=1', 840, 420, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="加班管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">申请人：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_ApplyUser" runat="server" Style="width: 85px"></asp:TextBox>
                        </td>
                        <td align="right" width="60">加班开始日期：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">类型：</td>
                        <td width="150">
                            <asp:DropDownList ID="ddl_OType" runat="server"></asp:DropDownList>
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
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">申请人</th>
                        <th align="center">加班时长</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">加班类型</th>
                        <th align="center">参与人员</th>
                        <th align="center">状态</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">

                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("OID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("OID") %>' id='ck_<%#Eval("OID") %>' <%#Eval("OState").ToString()=="1"?"disabled":"" %> /></label>
                                </td>
                                <td><%# Eval("ApplyUserName")%></td>
                                <td><%#Eval("ODay")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>

                                <td><%#Eval("OTypeName")%></td>
                                <td><%#Eval("UsersName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>( Eval("OState"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btneditcolor" ToolTip="审核" OnClientClick='return auditainfo(this);' Visible='<%#Eval("AuditResult").ToString()=="1"?true:false%>'>审核</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("LAID") %>' runat="server" />
                                         <asp:HiddenField ID="HiddenField2" Value='<%#Eval("OID") %>' runat="server" />
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







