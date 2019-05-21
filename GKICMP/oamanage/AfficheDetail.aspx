<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheDetail.aspx.cs" Inherits="GKICMP.oamanage.AfficheDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <%-- <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">通知公告信息</th>
                    </tr>
                    <tr>
                        <td align="right">公告标题： </td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_AfficheTitle" runat="server" Text=""></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">公告类型：</td>
                        <td align="left" width="40%">
                            <asp:Literal ID="ltl_AType" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">是否公示：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsDisplay" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="90px" align="right">发送人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SendUser" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">发送日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SendDate" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr id="aa" runat="server">
                        <td width="90px" align="right">接收人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_AcceptUser" runat="server"></asp:Literal>
                        </td>
                        <td width="90px" align="right">是否已读：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsRead" runat="server"></asp:Literal>
                        </td>
                    </tr>


                    <tr>
                        <td align="right">公告内容： </td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_AContent" runat="server" Text=""></asp:Literal>
                        </td>
                    </tr>
                    <tr runat="server" id="tr_return">
                        <td colspan="4" align="center">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="javascript:history.back();" />
                        </td>
                    </tr>
                     <tr runat="server" id="tr_audit" visible="false">
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="通过" CssClass="submit" OnClick="btn_Sumbit_Click"  />
                             <asp:Button ID="btn_BH" runat="server" Text="驳回" CssClass="editor" OnClick="btn_BH_Click"   />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



