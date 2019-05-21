<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="GKICMP.test.Location" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script>
        //$(function () {
        //    $('a').click(function () {
        //        alert("111");
        //        var a = $(this).attr("href");
        //        var b = $(this).attr("title");
        //        $(this).attr("href", "#");
        //        document.getElementById("Button1").click();
        //    });
        //})
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <%--<a href="http://yjq.whsedu.cn/upload/file/20180109/6365108856590103538735966.doc" title="http://yjq.whsedu.cn/upload/file/20180109/6365108856590103538735966.doc" >55555555555555555555555555555</a>--%>
         <asp:Button ID="Button1" runat="server" Text="Button"  onclick="Button1_Click"/>  
    </div>
    </form>
</body>
</html>
