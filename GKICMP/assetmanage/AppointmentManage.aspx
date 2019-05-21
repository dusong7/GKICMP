<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentManage.aspx.cs" Inherits="GKICMP.assetmanage.AppointmentManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                return openbox('A_id', 'AppointmentEdit.aspx', '', 950, 560, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'AppointmentEdit.aspx', 'id=' + id, 950, 370, 0);
        }

        function viewinfo(e) {
            //var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'AppointmentDetail.aspx', 'id=' + id, 950, 560, 4);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Flag" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="室场预约"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
         <div class="listcent searclass">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="7" align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="AppointmentWeekView.aspx">周视图</a></li>
                                    <li class="selected"><a href="AppointmentManage.aspx">全部预约</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">预约人：</td>
                        <td width="170">
                            <asp:TextBox ID="txt_AppUser" runat="server"></asp:TextBox>
                        </td>
                        <%--<td align="right" width="100">分类：</td>
                        <td width="170">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_DataType" runat="server"></asp:DropDownList>
                            </div>
                        </td>--%>
                        <td align="right" width="60">预约时间：</td>
                        <td width="280">
                            <asp:TextBox ID="txt_BeginDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="btntab" runat="server">
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
                        <th align="center">预约场地</th>
                        <th align="center" width="80px">预约人</th>
                        <th align="center">预约使用时间</th>
                        <%--<th align="center">结束时间</th>--%>
                        <th align="center">预约日期</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("AID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("AID") %>' id='ck_<%#Eval("AID") %>' /></label>
                                </td>
                                <td><%#Eval("MRName") %></td>
                                <td><%#Eval("AppUserName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%>至<%#Eval("EndDate","{0:HH:mm}")%></td>
                                <%--<td><%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}")%></td>--%>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd }")%></td>
                                <%--  <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ABState>(Eval("ABState"))%></td>--%>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("AID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


