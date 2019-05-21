<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetBorrowDetail.aspx.cs" Inherits="GKICMP.assetmanage.AssetBorrowDetail" %>

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
                        <th colspan="4" align="left">
                            <asp:Literal ID="lbl_Type1" runat="server"></asp:Literal>信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Name" runat="server"></asp:Literal>名称</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Number" runat="server"></asp:Literal>编号</td>
                        <td align="left">
                            <asp:Label ID="lbl_DataDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Type" runat="server"></asp:Literal>分类</td>
                        <td align="left">
                            <asp:Label ID="lbl_DataType" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px"><asp:Literal ID="lbl_ABUserName" runat="server"></asp:Literal>人</td>
                        <td align="left">
                            <asp:Label ID="lbl_ABUser" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Num" runat="server"></asp:Literal>数量</td>
                        <td align="left">
                            <asp:Label ID="lbl_AssetNum" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Date" runat="server"></asp:Literal>时间</td>
                        <td align="left">
                            <asp:Label ID="lbl_UserDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id ="back">
                        <td align="right" width="100px"><asp:Literal ID="lbl_Back" runat="server"></asp:Literal>日期</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_BackDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="100px"><asp:Literal ID="lbl_Make" runat="server"></asp:Literal>说明</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_ABMak" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                                      
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
