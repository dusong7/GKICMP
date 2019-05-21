<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherRewardDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherRewardDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../css/lrtk.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <link href="../css/green_formcss.css" rel="stylesheet" />
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
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">奖励详细信息</th>
                    </tr>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">获奖类别</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RewardType"></asp:Literal></td>
                        <td align="right">奖励名称</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RewardName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">获奖年月</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_PubDate"></asp:Literal></td>
                        <td align="right">奖励级别</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_RGrade"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">本人排名</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Ranking"></asp:Literal></td>
                        <td align="right">授奖单位</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Lunit"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">附件</td>
                        <td align="left" colspan="3">
                            <div id="div1" runat="server">
                                <table>
                                    <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("RFile") %>' CommandName="load"
                                                        runat="server"><%#getFileName(Eval("RFile").ToString())%></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <asp:Image ID="Image2" runat="server" Width="200px" Height="200px" />
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
