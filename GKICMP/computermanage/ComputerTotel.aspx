<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerTotel.aspx.cs" Inherits="GKICMP.computermanage.ComputerTotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/highcharts.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>

        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label>></span><asp:Label ID="lbl_Menuname" runat="server" Text="使用统计"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="100" align="right">登记日期：</td>

                        <td width="299">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="SetCanler()"></asp:TextBox>—<asp:TextBox
                                ID="txt_EDate" runat="server" Style="width: 85px" onfocus="SetCanler()"></asp:TextBox></td>


                        <td >
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Search_Click" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <div id="container" style="height: 380px; margin: 0 auto; width: 98%">
            </div>
        </div>
    </form>
</body>
</html>

