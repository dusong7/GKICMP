<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheFB.aspx.cs" Inherits="GKICMP.oamanage.AfficheFB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <%--<link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0" >
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">
                            <asp:Literal ID="ltl_AfficheTitle" runat="server" Text=""></asp:Literal></th>
                    </tr>
                    <tr>
                        <td>
                            <div id="oacontent">
                                <asp:Literal ID="ltl_AContent" runat="server" Text=""></asp:Literal>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td>接收人：
                            <asp:Literal ID="ltl_AcceptUser" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="发布" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




