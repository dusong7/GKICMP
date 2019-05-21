<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetworkTeachManageStu.aspx.cs" Inherits="GKICMP.networkteach.NetworkTeachManageStu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>网络课程管理</title>
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
                return openbox('A_id', 'NetworkTeachEdit.aspx', '', 700, 500, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'NetworkTeachEdit.aspx', 'id=' + id, 700, 500, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'NetworkTeachDetail.aspx', 'id=' + id, 960, 400, 4);
        }

    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="我的学习"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="在线学习"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">课程名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_NTTName" Text="" runat="server"></asp:TextBox>
                        </td>

                        <%--<td width="80" align="right">适合年级：</td>
                        <td width="130">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_EPID" runat="server"></asp:DropDownList>
                            </div>
                        </td>--%>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0 videolist">

            <ul>
                 <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                <li>
                    <a href='TeacChat.aspx?flag=1&id=<%#Eval("NTID")%>&roomid=<%#Eval("NRID")%>&type=<%#Eval("IsCommunication")%>' >
                        <img src='<%#Eval("ImgUrl")%>' />
                        <div></div>
                        <span title='<%#Eval("NTTName")%>'><%#Eval("NTTName")%></span>
                    </a>
                </li>
                            </ItemTemplate>
                    </asp:Repeater>
            </ul>
           
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


