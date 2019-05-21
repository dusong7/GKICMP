<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Res_Top.aspx.cs" Inherits="GKICMP.resourcesite.Res_Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源平台</title>
    <link href="../css/rourcecss.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background: url(../images/zy_1.png) center top no-repeat;
        }
    </style>
    <script type="text/javascript">
        //$("#li1").attr("class", "selected");
        function changecss(id) {
            if (id == 1) {
                document.getElementById("li1").className = "selected";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 2) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "selected";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 3) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "selected";            
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 4) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "selected";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 5) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "selected";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 6) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "selected";
                document.getElementById("li7").className = "";
            }
            else {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "selected";
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <div class="headcss">
            <div class="headlogo">
                <img src="../images/zy_2.png" />
            </div>
            <div class="headmenu">
                <ul>
                    <li>
                        <a href="Res_NewMain.aspx">
                            <asp:LinkButton ID="lbtn_FirstPage" runat="server" Text="首页" OnClick="lbtn_FirstPage_Click"></asp:LinkButton></a>
                        <%--<asp:LinkButton ID="LinkButton7" runat="server" Text="全部" CommandArgument="-2"></asp:LinkButton>--%></li>
                    <li id="li1">
                        <a href="Res_Main.aspx?RType=-2" target="main" onclick="changecss(1)">全部</a>
                        <%--<asp:LinkButton ID="LinkButton7" runat="server" Text="全部" CommandArgument="-2"></asp:LinkButton>--%></li>
                    <li id="li2">
                        <%--<asp:LinkButton ID="LinkButton8" runat="server" Text="课件" CommandArgument="1" OnClick="lbtn_All_Click"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton8" runat="server" Text="课件" CommandArgument="1"></asp:LinkButton>--%>
                        <a href="Res_Main.aspx?RType=1" target="main" onclick="changecss(2)">课件</a>
                    </li>
                    <li id="li3">
                        <a href="Res_Main.aspx?RType=2" target="main" onclick="changecss(3)">教案</a>
                        <%--<asp:LinkButton ID="LinkButton9" runat="server" Text="教案" CommandArgument="2"></asp:LinkButton>--%></li>
                    <li id="li4">
                        <a href="Res_Main.aspx?RType=3" target="main" onclick="changecss(4)">试卷</a>
                        <%--<asp:LinkButton ID="LinkButton10" runat="server" Text="试卷" CommandArgument="3"></asp:LinkButton>--%></li>
                    <li id="li5">
                        <a href="Res_Main.aspx?RType=4" target="main" onclick="changecss(5)">素材</a>
                        <%--<asp:LinkButton ID="LinkButton11" runat="server" Text="素材" CommandArgument="4"></asp:LinkButton>--%></li>
                    <li id="li6">
                        <a href="Res_Main.aspx?RType=5" target="main" onclick="changecss(6)">微课程</a>
                        <%--<asp:LinkButton ID="LinkButton12" runat="server" Text="微课程" CommandArgument="5"></asp:LinkButton>--%></li>
                    <li id="li7">
                        <a href="Res_Main.aspx?RType=7" target="main" onclick="changecss(7)">其他</a>
                        <%--<asp:LinkButton ID="LinkButton13" runat="server" Text="其他" CommandArgument="6"></asp:LinkButton>--%></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>

