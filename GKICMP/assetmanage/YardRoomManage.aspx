<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YardRoomManage.aspx.cs" Inherits="GKICMP.assetmanage.YardRoomManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />

    <script src="../js/jquery.min.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AssetDetail.aspx', 'id=' + id + '&flag=1', 900, 460, 4);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">资产编号：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_DataDesc" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">资产名称：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_AssetName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100">资产分类：</td>
                        <td width="200">
                            <div class="sel" style="float: left">
                                <asp:TextBox ID="txt_DataType1" cascadeCheck="false" runat="server" name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=1" CssClass="easyui-combotree"></asp:TextBox>
                            </div>
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
                            <span style="color: red; float: left; margin-left: 20px; font-size: 14px; font-weight: bold">
                                <asp:Literal ID="ltl_Sum" runat="server"></asp:Literal></span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">资产大类
                        </th>
                        <th align="center">资产分类</th>
                        <th align="center">资产名称</th>
                        <th align="center">资产编号</th>
                        <th align="center">资产数量</th>
                        <th align="center">品牌</th>
                        <th align="center">规格型号</th>
                        <th align="center">价值</th>
                        <th align="center">供应商</th>
                        <th align="center">购置时间</th>
                        <th align="center">所属校区</th>
                        <th align="center">是否上报</th>
                        <th width="75px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("MaxTypeName") %></td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("AssetName")%></td>
                                <td><%#Eval("DataDesc")%></td>
                                <td><%#Eval("AssetNum")%></td>
                                <td><%#Eval("Brand")%></td>
                                <td><%#Eval("SpecificationModel")%></td>
                                <td><%#Eval("APrice")%></td>
                                <td><%#Eval("SuppliersName")%></td>
                                <td><%#Eval("BuyDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("CName")%></td>
                                <td><%#Eval("IsReport").ToString()=="0"?"<span style='color:red'>未上报</span>":"已上报"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("AID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="14">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


