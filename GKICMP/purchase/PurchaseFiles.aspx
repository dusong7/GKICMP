<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseFiles.aspx.cs" Inherits="GKICMP.purchase.PurchaseFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文件管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
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
                return openbox('A_id', 'Purchase_FileEdit.aspx', '', 1000, 450, -1);
            });

        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'Purchase_FileEdit.aspx', 'id=' + id, 1000, 450, 0);
        }
        function deleteinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'Purchase_FileDelete.aspx', 'id=' + id, 1000, 450, 46);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PurchaseDetail.aspx', 'id=' + id, 960, 450, 4);
        }
        function admininfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '', 'id=' + id, 860, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="文件管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">采购名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_FileName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                            <asp:Button ID="btn_Add" runat="server" Text="添加" CssClass="btn_add_css" Style="border: 1px solid #ea6709;" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">


            <asp:Repeater runat="server" ID="rp_List" OnItemDataBound="rptypelist_ItemDataBound">
                <ItemTemplate>

                    <div class="fileshowlist">
                        <div class="filetitle">
                            <span class="filename"><%#Eval("PTitle")%></span>
                            <div class="filebtn">
                                <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("PID") %>' runat="server" />
                                <asp:LinkButton ID="lbtn_Edit" runat="server" ToolTip="编辑" OnClientClick='return editinfo(this);'><span class="icon iconfont icon-xiugai" style="color:#7d9d0f">编辑</span></asp:LinkButton>
                                <asp:HiddenField ID="hf_SelectID2" Value='<%#Eval("PID") %>' runat="server" />
                                <asp:LinkButton ID="btn_Delete" runat="server" ToolTip="删除" OnClientClick='return deleteinfo(this);'> <span class="icon iconfont icon-xiugai">删除</span></asp:LinkButton>
                                <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PID") %>' runat="server" />
                                <asp:LinkButton ID="lbtn_Report" runat="server" ToolTip="上报" CommandArgument='<%#Eval("PID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');"><span class="icon iconfont icon-xiugai">上报</span></asp:LinkButton>


                            </div>
                        </div>
                        <div class="filelist">
                            <ul>
                                <li>
                                    <asp:Repeater ID="rp_ListFile1" runat="server" OnItemCommand="rpfilelist_ItemCommand">
                                        <ItemTemplate>
                                        <span>
                                            <span><font class="fcolor">[<%#Eval("Name")%>]</font>
                                            <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("PFID") %>' CommandName="load"
                                                runat="server"><%# Eval("FileName")%></asp:LinkButton></span><span>  <%#Eval("UserName") %> &nbsp;<%#Eval("CreateDate","{0:yyyy-MM-dd}") %></span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </li>
                            </ul>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
