<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkManage.aspx.cs" Inherits="GKICMP.office.LinkManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师合同管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <link href="../css/iconfont.css" rel="stylesheet" />
    <style>
        .padbot {
            padding-bottom: 10px;
        }

        .lxr {
            margin: 10px 0px 0px 10px;
            width: 200px;
        }

            .lxr .filetitle {
                text-align: center;
            }

            .lxr .filename {
                float: none;
            }

            .lxr li {
                border-bottom: 1px solid #e6e6e6;
                padding: 0px 10px;
                width: auto;
            }

            .lxr ul {
                margin: 5px 0px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_TID" runat="server" />
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />

        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="通讯录"></asp:Label>
                    </td>
                </tr>
            </table>





            <div class="listcent pad10 padbot">
                <asp:Repeater runat="server" ID="rp_List" OnItemDataBound="rp_List_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hffid" runat="server" Value='<%#Eval("DID") %>' />
                        <div class="fileshowlist lxr">
                            <div class="filetitle">
                                <span class="filename"><%#Eval("DepName")%></span>
                            </div>
                            <div class="filelist">
                                <ul>
                                    <asp:Repeater runat="server" ID="rp_ListFile">
                                        <ItemTemplate>
                                            <li>
                                                <font class="fcolor"><%#Eval("RealName")%></font>
                                                <span><%#Eval("CellPhone") %></span>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="clear: both"></div>
            </div>
        </div>
    </form>
</body>
</html>
