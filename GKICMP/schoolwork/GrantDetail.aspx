<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrantDetail.aspx.cs" Inherits="GKICMP.schoolwork.GrantDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
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
                        <th colspan="4" align="left">助学金信息
                        </th>
                    </tr>
                    <tr>
                        <td width="90px" align="right">学生姓名：</td>
                        <td align="left">
                            <asp:Label ID="lbl_UserName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">助学金类型 ：</td>
                        <td align="left">
                            <asp:Label ID="lbl_GrantType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">申请材料 ：</td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("ApplyUrl") %>' CommandName="load"
                                                    runat="server"><%# getFileName(Eval("ApplyUrl").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_Mark" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">审核信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right">审核人：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_AuditUser"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">审核时间：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_AuditDate"></asp:Literal>
                        </td>
                        <td align="right">审核结果：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_AuditState"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


