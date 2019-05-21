<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassRoomManage.aspx.cs" Inherits="ICMP.assetmanage.ClassRoomManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
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
            var fid = document.getElementById("hf_FID").value;
            var flag = document.getElementById("hf_Flag").value;
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'ClassRoomEdit.aspx', 'fid=' + fid + '&flag=' + flag, 800, 450, -1);
            });

            $('#btn_Import').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'DormitoryImport.aspx', 'fid=' + fid, 800, 450, -1);
            });
        });
        function editinfo(e) {
            var fid = document.getElementById("hf_FID").value;
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'ClassRoomEdit.aspx', 'id=' + id + '&fid=' + fid + '&flag=' + flag, 800, 450, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_FID" runat="server" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">
                            <asp:Literal runat="server" ID="ltl_SName"></asp:Literal>名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RoomName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">是否可用：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_IsUseable"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="operation" runat="server">
                <tbody>
                    <tr>
                        <td style="color: red;">&nbsp;&nbsp;
                            当前所在楼层：<asp:Label ID="lbl_RoomName" runat="server"></asp:Label>
                        </td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <%--<asp:Button ID="btn_Import" runat="server" Text="导入"CssClass="listbtncss listoutput" />--%>
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
                        <th align="center">
                            <asp:Literal runat="server" ID="ltl_BName"></asp:Literal>名称</th>
                        <th align="center" <%=(Flag!=1?"style='display:none'":"")%> >所属班级</th>
                        <th align="center">备注</th>
                        <th align="center">是否可用</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("CRID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("CRID") %>' id='ck_<%#Eval("CRID") %>' /></label>
                                </td>
                                <td ><%#Eval("RoomName")%></td>
                                <td <%=(Flag!=1?"style='display:none'":"")%> ><%#Eval("DepName")%></td>
                                <td><%#Eval("RoomDesc")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.DorState>(Eval("IsUseable"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <%--<asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"   OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>--%>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("CRID") %>' runat="server" />

                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="5">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>

</body>
</html>
