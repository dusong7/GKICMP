<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentDetail.aspx.cs" Inherits="GKICMP.cms.CommentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/lrtk.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
</head>
<body>
   <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <th colspan="6" align="left">
                        <asp:Literal runat="server" ID="ltl_Name"></asp:Literal>详情
                    </th>
                </tr>
                <tr>
                    <td align="right">标题：</td>
                    <td colspan="5">
                        <asp:Literal runat="server" ID="ltl_title"></asp:Literal>
                    </td>
                </tr>

                 <tr>
                    <td align="right">内容：</td>
                    <td colspan="5">
                        <asp:Literal runat="server" ID="ltl_ComContent"></asp:Literal>
                    </td>
                </tr>

                <tr>
                    <td align="right" width="80px">联系人： </td>
                    <td>
                        <asp:Literal ID="ltl_LinkUser" runat="server" ></asp:Literal>
                    </td>
                    <td align="right">联系方式：</td>
                    <td>
                        <asp:Literal ID="ltl_LinkType" runat="server"></asp:Literal>
                    </td>
                     <td align="right">是否公开：</td>
                    <td>
                        <asp:Literal ID="ltl_IsPublish" runat="server"></asp:Literal>
                    </td>
                </tr>

                <tr>
                    <td align="right">回复内容：</td>
                    <td colspan="5">
                         <asp:Literal ID="ltl_ReplyContent" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
