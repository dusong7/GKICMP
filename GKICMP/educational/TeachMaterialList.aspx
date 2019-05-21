<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachMaterialList.aspx.cs" Inherits="GKICMP.educational.TeachMaterialList" %>

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
    <style>
        html, body, form {
            height: 100%;
        }

        tr:first-child td:nth-child(2) {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr style="background: url(../images/tabimg/tabpic3.gif) bottom; vertical-align: middle; height: 30px">
                <td width="15%" class="tabfirst">
                    <div style="width: 100%; background: #1DA02B; height: 40px; margin-top: 20px; border-radius: 5px; color: #ffffff; line-height: 40px; text-align: left; text-indent: 20px; font-size: 14px; font-weight: bold">
                        教材版本列表
                        <asp:LinkButton ID="btn_Import" runat="server" OnClick="btn_Import_Click"><span style="position:relative; top:12px; right:15px;  float:right;color:#ffffff;font-size:12px;font-weight:100;" >导入</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btn_Add" runat="server" OnClick="btn_Add_Click"><span style="position:relative; top:12px; right:5px;  float:right;color:#ffffff;font-size:12px;font-weight:100;" >教材添加</span>
                        </asp:LinkButton>
                    </div>
                </td>
                <td valign="top" rowspan="2">
                    <iframe scrolling="auto" width="100%" frameborder="0" name="framemain"
                        id="framemain" runat="server" height="700"></iframe>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 90%; background: #FFFFFF">
                    <div>
                        <asp:TreeView ID="tv_Meun" ShowLines="True" Height="700px"
                            MaxDataBindDepth="2" BackColor="White" BorderColor="#666666" runat="server" OnSelectedNodeChanged="tv_Meun_SelectedNodeChanged" NoExpandImageUrl="~/images/tree-ul-li.png" ExpandImageUrl="~/images/green_tree_13.png" LineImagesFolder="~/images" ForeColor="#333333">
                            <RootNodeStyle BackColor="#FFFFFF" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

