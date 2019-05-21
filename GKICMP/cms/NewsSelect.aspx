<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSelect.aspx.cs" Inherits="GKICMP.cms.NewsSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园门户管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>

    <script type="text/javascript">
        function getvalue(e) {
            var nid = $(e).next().val();
            var title = $(e).next().next().val();
            var desc = $(e).next().next().next().val();
            var url = $(e).next().next().next().next().val();
            var picurl = $(e).next().next().next().next().next().val();
            window.parent.AddNews(nid, title, desc, url,picurl);
            $.close("S_id");
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="listcent searclass" style="min-width:100px">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">文章标题：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_BName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">所属栏目：</td>
                        <td width="350">
                            <asp:DropDownList ID="ddl_MName" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0" style="min-width:100px">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                        </th>
                        <th align="center">标题</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                   <a  id='<%# DataBinder.Eval(Container.DataItem, "NID")%>' href="#" onclick='getvalue(this)'>
                                        <img src="../images/accept.png" style="border: 0px; padding-top: 4px;" /></a>
                                    <asp:HiddenField ID="hf_NID" runat="server" Value='<%# Eval("NID") %>' />
                                    <asp:HiddenField ID="hf_NewsTitle" runat="server" Value='<%# Eval("NewsTitle") %>' />
                                    <asp:HiddenField ID="hf_NContent" runat="server" Value='<%#GetConntent(Eval("NContent")) %>' />
                                    <asp:HiddenField ID="hf_NUrl" runat="server" Value='<%# GetImgUrl(Eval("NContent")) %>' />   
                                    <asp:HiddenField ID="hf_PIC" runat="server" Value='<%# GetUrl(Eval("NContent")) %>' /> 
                                </td> 
                                <td><%#Eval("NewsTitle")%></td>
                               
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>






