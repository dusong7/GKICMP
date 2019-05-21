<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetDepreDetail.aspx.cs" Inherits="GKICMP.assetmanage.AssetDepreDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>智慧校园行政办公平台</title>
   <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
             <asp:HiddenField ID="hf_face" runat="server" Value="" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">资产折旧信息</th>
                    </tr>

                    <tr>
                        <td align="right" width="100px">所属项目</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_ProName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Number" runat="server"></asp:Literal>编号</td>
                        <td align="left">
                            <asp:Label ID="lbl_DataDesc" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Name" runat="server"></asp:Literal>名称</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Type" runat="server"></asp:Literal>分类</td>
                        <td align="left">
                            <asp:Label ID="lbl_DataType" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">规格型号</td>
                        <td align="left">
                            <asp:Label ID="lbl_SpecificationModel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">品牌</td>
                        <td align="left">
                            <asp:Label ID="lbl_Brand" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">供应商</td>
                        <td align="left">
                            <asp:Label ID="lbl_Suppliers" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">价值</td>
                        <td align="left">
                            <asp:Label ID="lbl_APrice" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">计量单位</td>
                        <td align="left">
                            <asp:Label ID="lbl_AUnit" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">购置时间</td>
                        <td align="left">
                            <asp:Label ID="lbl_BuyDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">计划使用年限</td>
                        <td align="left">
                            <asp:Label ID="lbl_PlanYear" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">采购人</td>
                        <td align="left">
                            <asp:Label ID="lbl_BuyUser" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">数量</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="100px">所属校区</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_CID" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="100px">物品描述</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_AssetMark" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">物品图片</td>
                        <td align="left" colspan="3">
                             <asp:Image ID="imgs" runat="server" Width="200" Height="200" Visible="false" />
                        </td>
                    </tr>                    
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
