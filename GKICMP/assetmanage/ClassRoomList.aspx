<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassRoomList.aspx.cs" Inherits="ICMP.assetmanage.ClassRoomList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教室管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr style="background: url(../images/tabimg/tabpic3.gif) bottom; vertical-align: middle; height: 30px">
                <td width="15%" class="tabfirst">
                    <div style="width: 100%; background: #e4e4e4; height: 40px; margin-top: 20px; border-radius: 5px; color: #808080; line-height: 40px; text-align: left; text-indent: 20px; font-size: 14px; font-weight: bold">
                        楼层列表
                    </div>
                </td>
                <td valign="top" rowspan="2">
                    <iframe scrolling="auto" width="100%" frameborder="0"  name="framemain"
                        id="framemain" runat="server" height="800px;"></iframe>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 90%; background: #FFFFFF">
                    <div>
                        <asp:TreeView ID="tv_Meun" ShowLines="True" Height="560px"
                            MaxDataBindDepth="2" BackColor="White" BorderColor="#666666" runat="server" OnSelectedNodeChanged="tv_Meun_SelectedNodeChanged" NoExpandImageUrl="~/images/tree-ul-li.png" ExpandImageUrl="~/images/green_tree_13.png" LineImagesFolder="~/TreeLineImages" ForeColor="#333333">
                            <RootNodeStyle BackColor="#FFFFFF" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
