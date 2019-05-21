<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherChangesDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherChangesDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">异动类型</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CType"></asp:Literal></td>
                        <td align="right">异动时间 </td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CDate"></asp:Literal></td>

                    </tr>
                   
                    <tr>
                        <td align="right">异动原因</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_ChangeReason"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right">验收附件</td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("CFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("CFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="4">
                            <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

