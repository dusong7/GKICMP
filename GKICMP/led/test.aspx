<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="GKICMP.led.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="ltl_Name" runat="server">品牌</asp:Literal><asp:TextBox ID="txt_Name" runat="server"></asp:TextBox><br />
            <asp:Literal ID="Literal1" runat="server">地址</asp:Literal><asp:TextBox ID="txt_IP" runat="server"></asp:TextBox><br />
            <asp:Literal ID="Literal2" runat="server">大小：</asp:Literal>宽<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>高<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:Literal ID="Literal3" runat="server">类型</asp:Literal>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">所有6代单色、双色、七彩卡</asp:ListItem>
                <asp:ListItem Value="2">所有6代全彩卡</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Literal ID="Literal4" runat="server">屏颜色</asp:Literal>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="1">单色</asp:ListItem>
                <asp:ListItem Value="2">双基色</asp:ListItem>
                <asp:ListItem Value="3">七彩</asp:ListItem>
                <asp:ListItem Value="4">全彩</asp:ListItem>
            </asp:DropDownList><br />
        </div>
        <br />
        <div>
             <asp:Literal ID="Literal5" runat="server">字体</asp:Literal><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Literal ID="Literal6" runat="server">像素</asp:Literal><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        </div>
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="打开/关闭" /><asp:Button ID="Button2" runat="server" Text="发送文字" />
        </div>
    </form>
</body>
</html>
