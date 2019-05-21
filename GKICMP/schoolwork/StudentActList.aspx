<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActList.aspx.cs" Inherits="GKICMP.schoolwork.StudentActList" %>

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
    <script type="text/javascript">
        var type = window.location.href.split("?");
    </script>
    <style>
        html, body,form,iframe {
        height:100%
        }
        tr:first-child td:nth-child(2) {
        height:100%
        }

    </style>
</head>

<body>
    <form id="form1" runat="server">
        <table width="100%" align="center" border="0" height="100%" cellpadding="0" cellspacing="0">
            <tr style="background: url(../images/tabimg/tabpic3.gif) bottom; vertical-align: middle; height: 30px">
                <td width="15%" class="tabfirst">
                    <div style="width: 100%; background: url(../images/yxj_cpzx.jpg); height: 40px; /*margin-top: 20px; border-radius: 5px;*/ color: #fff; line-height: 40px; text-align: left; text-indent: 20px; font-size: 14px; font-weight: bold">
                        活动列表
                    </div>
                </td>
                <td valign="top" rowspan="2">
                    <iframe scrolling="auto" width="100%" frameborder="0" src="StudentActTheme.aspx" name="framemain"
                        id="framemain" runat="server" height="550"></iframe>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 100%; background: #FFFFFF">
                    <div style="height: 100%; overflow-x: hidden; overflow-y: auto;">
                        <asp:TreeView ID="tv_Meun" ShowLines="True" Height="560px" MaxDataBindDepth="2" BackColor="White" BorderColor="#666666" 
                            runat="server" OnSelectedNodeChanged="tv_Meun_SelectedNodeChanged" NoExpandImageUrl="~/images/tree-ul-li.png" 
                            ExpandImageUrl="~/images/green_tree_13.png" LineImagesFolder="~/TreeLineImages" ForeColor="#333333">
                            <RootNodeStyle BackColor="#FFFFFF" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

