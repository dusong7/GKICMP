<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="GKICMP.test.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
     <script>
         $(function () {
             var availableTags = [
               "ActionScript",
               "AppleScript",
               "Asp",
               "BASIC",
               "C",
               "C++",
               "Clojure",
               "COBOL",
               "ColdFusion",
               "Erlang",
               "Fortran",
               "Groovy",
               "Haskell",
               "Java",
               "JavaScript",
               "Lisp",
               "Perl",
               "PHP",
               "Python",
               "Ruby",
               "Scala",
               "Scheme"
             ];
             $("#tags").autocomplete({
                 source: availableTags
             });
         });
    </script>--%>

   
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_UpFile" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> 
        <%--   <div class="ui-widget">
        <label for="tags">Tags: </label>
        <input id="tags" />--%>
    </div>
       
    </form>
</body>
</html>
