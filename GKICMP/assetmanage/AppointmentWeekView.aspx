<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentWeekView.aspx.cs" Inherits="GKICMP.assetmanage.AppointmentWeekView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'AppointmentEdit.aspx', '', 950, 560, -1);
            });
        });
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Flag" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="室场预约"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
         <div class="listcent searclass">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="7" align="left">
                            <div class="xxsm">
                                <ul>
                                    <li class="selected"><a href="AppointmentWeekView.aspx">周视图</a></li>
                                    <li ><a href="AppointmentManage.aspx">全部预约</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">预约时间：</td>
                        <td width="280">
                            <asp:TextBox ID="txt_MDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="btntab" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                        </td>
                    </tr>
                </tbody>
            </table>
             <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <thead>
                    <tr>
                        <td style="font-weight: bold; border-right: 1px solid #cccccc; text-align: center; border-top: 1px solid #cccccc;">会议室名称
                        </td>
                        <asp:Literal ID="ltl_Days" runat="server"></asp:Literal>
                    </tr>
                </thead>
                <asp:Literal ID="ltl_Rooms" runat="server"></asp:Literal>
            </table>
        </div>
        </div>
    </form>
</body>
</html>


