<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YardRoomList.aspx.cs" Inherits="GKICMP.assetmanage.YardRoomList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智慧校园基础管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="按场室查询"></asp:Label>
                </tr>
            </table>
        </div>
        <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr style="background: url(../images/tabimg/tabpic3.gif) bottom; vertical-align: middle; height: 30px">
                <td width="10%" class="tabfirst">
                    <div style="width: 100%; background: #1DA02B; height: 40px; margin-top: 10px; border-radius: 5px; color: #fff; line-height: 40px; text-align: left; text-indent: 20px; font-size: 14px; font-weight: bold">
                        场室列表
                    </div>
                </td>
                <td valign="top" rowspan="2">
                    <iframe scrolling="auto" width="100%" frameborder="0" src="YardRoomManage.aspx" name="framemain"
                        id="framemain" runat="server" height="800px;"></iframe>
                </td>
            </tr>
            <tr>
                <td valign="top" style="background: #FFFFFF">
                    <div>
                        <asp:TreeView ID="tv_Meun" ShowLines="True" Height="560px"
                            MaxDataBindDepth="2" BackColor="White" BorderColor="#666666" runat="server" OnSelectedNodeChanged="tv_Meun_SelectedNodeChanged" NoExpandImageUrl="~/images/tree-ul-li.png" ExpandImageUrl="~/images/green_tree_13.png" LineImagesFolder="~/treeimages" ForeColor="#333333">
                            <RootNodeStyle BackColor="#FFFFFF" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>



