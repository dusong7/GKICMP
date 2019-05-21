<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceTotel.aspx.cs" Inherits="GKICMP.invoice.InvoiceTotel" %>

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
                return openbox('A_id', 'InvoiceEdit.aspx', '', 1000, 580, -1);
            });

            $('#lbtn_File').click(function () {
                var iids = document.getElementById("hf_CheckIDS").value;
                if (iids == "") {
                    alert("请至少选择一条信息");
                }
                return openbox('C_id', 'InvoiceFileEdit.aspx', 'iids=' + iids, 700, 200, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'InvoiceEdit.aspx', 'id=' + id, 1000, 580, 0);
        }

        function viewinfo(e) {
            var invmodel = document.getElementById("ddl_InvModel").value;
            var begin = document.getElementById("txt_Begin").value;
            var end = document.getElementById("txt_End").value;
            var type = $(e).next().val();
            return openbox('A_id', 'InvoiceTotelDetail.aspx', 'type=' + type + '&model=' + invmodel + '&begin=' + begin + '&end=' + end, 1200, 580, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="报销统计报表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <%--<td align="right" width="70px">报销类别：</td>
                        <td width="160px">
                            <asp:DropDownList runat="server" ID="ddl_InvType"></asp:DropDownList>
                        </td>--%>
                        <td align="right" width="70px">报销方式：</td>
                        <td width="100px">
                            <asp:DropDownList runat="server" ID="ddl_InvModel"></asp:DropDownList>
                        </td>
                        <td width="70px" align="right">报销日期：</td>
                        <td width="350px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
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
                        <th align="center">报销类别</th>
                        <th align="center">报销金额</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("SumCount")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick="return viewinfo(this);">详情</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("InvType") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="3">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

