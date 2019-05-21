<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideDetail.aspx.cs" Inherits="GKICMP.cms.SlideDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal runat="server" ID="ltl_SName"></asp:Literal>信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80px">类别：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_SType"></asp:Literal>
                        </td>
                        <td align="right" width="100px">
                            <asp:Literal runat="server" ID="ltl_Name"></asp:Literal>名称：
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_SlideName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">链接：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_SlideUrl"></asp:Literal>
                        </td>
                        <td align="right">失效日期：
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_InvalidDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">创建人：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateUser"></asp:Literal>
                        </td>
                        <td align="right">创建日期：
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">图片：</td>
                        <td colspan="3">
                            <asp:Image ID="img_SImage" runat="server" Width="200px" Visible="false" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

