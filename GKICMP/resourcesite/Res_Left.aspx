<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Res_Left.aspx.cs" Inherits="GKICMP.resourcesite.Res_Left" %>
<!doctype html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源平台</title>
    <link href="../css/rourcecss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="leftcss">
            <div class=" listcss">
                <div class="titlecss">最新资源</div>
                <asp:Repeater ID="rp_zxList" runat="server">
                    <ItemTemplate>
                        <ul>
                            <li><a href="Res_Detail.aspx?id=<%#Eval("Erid") %>" target="_blank" title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %></a></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div runat="server" id="tr_null1" style="text-align: center">
                    暂无记录
                </div>
            </div>
            <div class="listcss">
                <div class="titlecss">精品资源</div>
                <asp:Repeater ID="rp_jpList" runat="server">
                    <ItemTemplate>
                        <ul>
                            <li><a href="Res_Detail.aspx?id=<%#Eval("Erid") %>" target="_blank" title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %></a></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div runat="server" id="tr_null2" style="text-align: center">
                    暂无记录
                </div>
            </div>
        </div>

    </form>
</body>
</html>

