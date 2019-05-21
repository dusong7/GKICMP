<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleManage.aspx.cs" Inherits="GKICMP.vehicle.VehicleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
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
                return openbox('A_id', 'VehicleEdit.aspx', '', 950, 600, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'VehicleEdit.aspx', 'id=' + id, 950, 600, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'VehicleDetail.aspx', 'id=' + id, 950, 400, 4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="车辆信息"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">车牌照：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_VehicleCode" runat="server"></asp:TextBox>
                        </td>
                        <td width="80" align="right">购置日期：</td>
                        <td width="230px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="60">车辆类型：</td>
                        <td width="90px" >
                            <asp:DropDownList ID="ddl_Vtype" runat="server"></asp:DropDownList>
                        </td>
                        <td width="70" align="right">状态：</td>
                        <td width="90px">
                            <asp:DropDownList ID="ddl_VState" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Search_Click" />
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
                        <th align="center">车辆名称</th>
                        <th align="center">车牌照</th>
                        <th align="center">车辆类型</th>
                        <th align="center">座位数</th>
                        <th align="center">购置日期</th>
                        <th align="center">购置金额</th>
                        <th align="center">状态</th>
                        <th width="140px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("VHID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("VHID") %>' id='ck_<%#Eval("VHID") %>' /></label>
                                </td>
                                <td align="center"><%#Eval("VehicleName")%></td>
                                <td align="center"><%#Eval("VehicleCode")%></td>
                                <td align="center"><%#Eval("VtypeName")%></td>
                                <td align="center"><%#Eval("CSeatNum")%></td>
                                <td align="center"><%#Eval("BuyDate","{0:yyyy-MM-dd}")%></td>
                                <td align="center"><%#Eval("Vcash")%></td>
                                <td align="center"><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.VState>(Eval("VState"))%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_TPID" Value='<%#Eval("VHID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
