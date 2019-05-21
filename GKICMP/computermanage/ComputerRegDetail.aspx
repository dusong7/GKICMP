<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerRegDetail.aspx.cs" Inherits="GKICMP.computermanage.ComputerRegDetail" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html" charset="utf-8" />
    <title></title>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script type="text/javascript">
        function back() {
            var CssFlag = document.getElementById("hf_flag").value;
            document.getElementById("btn").href = "TeacherManage.aspx?flag=" + CssFlag;
            document.getElementById("btn").target = "main";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_flag" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th align="left" colspan="4">
                            <asp:Literal runat="server" ID="ltl_ChapterName1"></asp:Literal>登记详情
                        </th>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <asp:Literal runat="server" ID="ltl_SchoolName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left">
                            <asp:Literal ID="ltl_UserName" runat="server"></asp:Literal></td>
                        <td align="right">学科</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Subject"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">课题</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ChapterName"></asp:Literal></td>
                        <td align="right">计算机名</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ComputerName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">IP地址</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_IP"></asp:Literal></td>
                        <td align="right">登记时间</td>
                        <td align="ledt">
                            <asp:Literal runat="server" ID="ltl_RegDate"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right">图片</td>
                        <td align="left" colspan="3">
                            <div style="white-space: nowrap;">
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <%--<asp:Image ID="img_Simage" runat="server" ImageUrl='"data:image/png;base64,"+<%#Eval("Simage") %>' />
                                    <asp:Literal runat="server" ID="ltl_ImageDate"></asp:Literal>--%>
                                        <div style="width: 200px; height:220px; float: left;">
                                            <asp:Image ID="img_Simage"  Width="160px" Height="150px" runat="server" /><br />
                                            <asp:Literal runat="server" ID="ltl_ImageDate"></asp:Literal>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="7">
                            <asp:Button ID="btn_return" runat="server" Text="返回" class="editor" OnClick="btn_return_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


