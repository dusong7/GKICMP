<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemarkDetail.aspx.cs" Inherits="GKICMP.studentmanage.RemarkDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                        <th colspan="4" align="left">评语库信息</th>
                    </tr>
                    <tr>
                        <td align="right">评语内容</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_RemarkContent" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">创建人</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CreateUser"></asp:Literal></td>
                        <td align="right">创建时间</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
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

