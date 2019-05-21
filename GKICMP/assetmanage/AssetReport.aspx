<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetReport.aspx.cs" Inherits="GKICMP.assetmanage.AssetReport" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
     <%--<link href="../css/green_list.css" rel="stylesheet" />--%>
    <script src="../js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script>
        function viewinfo(e) {
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'AssetDetail.aspx', 'id=' + id + '&flag=' + flag, 900, 460, 4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <div>
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                    <tr>
                        <th colspan="4" align="left">资产上报
                        </th>
                    </tr>
                  
                    <tr>
                        <td align="right">上报说明：</td>
                        <td>
                            <span style="color: red;">1.请先下载资产导入模板并按照模板录入数据；<br />
                                2.若无供应商数据，请置空；<br />
                                3.校区数据请根据：系统管理--&gt;校区管理的校区编号填写；<br />
                                4.每次上报系统默认选择前100条；超过100条请多次上传
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="上报" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
         <div class="listcent pad0">
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        
                        <th align="center">资产大类
                        </th>
                        <th align="center">
                            资产分类</th>
                        <th align="center">
                            资产名称</th>
                        <th align="center">
                            资产编号</th>
                        <th align="center">
                            资产数量</th>
                        <th align="center">品牌</th>
                        <th align="center">规格型号</th>
                        <th align="center">价值</th>
                        <th align="center">供应商</th>
                        <th align="center">购置时间</th>
                        <th align="center">所属校区</th>
                        <th align="center">资产分组</th>
                        <th width="100px" align="center">操作</th>
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
                                <td><%#Eval("AssetGroupName")%></td>
                                <td>
                                  
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("AID") %>' runat="server" />
                                 
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

