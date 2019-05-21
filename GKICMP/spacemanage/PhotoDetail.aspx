<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoDetail.aspx.cs" Inherits="GKICMP.spacemanage.PhotoDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/zstyle.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="infocss">
            <h3>
                <asp:Literal runat="server" ID="ltl_PhotoName"></asp:Literal></h3>
            <div class="infodiv" style="text-align: center;">
                <asp:Image runat="server" ID="img_photoUrl" Width="450px" /><br />
                <asp:Literal runat="server" ID="ltl_PhotoDesc"></asp:Literal>
            </div>
            <div class="infoo">
                <asp:Literal runat="server" ID="ltl_SysUserName"></asp:Literal><br>
                <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal>
            </div>
            <div style="clear: both"></div>
            <div style="border-top:1px dashed #808080">【照片评论】</div>
            <asp:Repeater runat="server" ID="rp_List">
                <ItemTemplate>
                    <div class="listm">
                        <div class="listi">
                            <%#Eval("MContent") %>
                        </div>
                        <div><span><%#Eval("CreateName") %></span></div>
                        <div class="listd"><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm:ss}") %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div runat="server" id="tr_null" style="text-align: center; height: 30px; line-height: 30px;">
                暂无记录                                              
            </div>
        </div>
    </form>
</body>
</html>
