<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerOnLine.aspx.cs" Inherits="GKICMP.computermanage.ComputerOnLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script type="text/javascript">
        //$(function () {

        //    (function longPolling() {

        //        $.ajax({
        //            url: "../ashx/ComputersPic.ashx",
        //            data: "method=GetPic",
        //            dataType: "json",
        //            timeout: 5000,
        //            error: function (XMLHttpRequest, textStatus, errorThrown) {
        //                if (textStatus == "timeout") { // 请求超时
        //                    longPolling(); // 递归调用

        //                    // 其他错误，如网络错误等
        //                } else {
        //                    longPolling();
        //                }
        //            },
        //            success: function (data, textStatus) {
        //                for (var o in data.data) {
        //                                    var a = data.data[o].mac;
        //                                    var b = data.data[o].image;
        //                                    var c = data.data[o].mac1;
        //                                    var e = data.data[o].mac + "1";
        //                                    //  var f = "#" + e;
        //                                    var d = $("#"+a).attr('src');
        //                                    if (d == "data:image/png;base64," + b)
        //                                        document.getElementById(data.data[o].mac).src = "";
        //                                    else {
        //                                        document.getElementById(data.data[o].mac).src = "data:image/png;base64," + b;
        //                                        document.getElementById(data.data[o].mac + "1").innerHTML = c;
        //                                        var f = document.getElementById(e).innerHTML;
        //                                    }

        //                                }
        //                if (textStatus == "success") { // 请求成功
        //                    longPolling();
        //                }
        //            }
        //        });
        //    })();

        //});
        // runajax();
        $(function () {
            runajax();
            //alert("qwee");
            //定时请求刷新  
            setInterval(runajax, 5000);
        });
        function runajax() {
            $.ajax({
                url: "../ashx/ComputersPic.ashx",
                cache: false,
                type: "GET",
                // async: false,
                data: "method=GetPic",
                dataType: "json",
                success: function (data) {
                    for (var o in data.data) {
                        var a = data.data[o].mac;
                        var b = data.data[o].image;
                        var c = data.data[o].mac1;
                        var e = data.data[o].mac + "1";
                        //  var f = "#" + e;
                        //var d = $("#"+a).attr('src');
                        if (b == "")
                            document.getElementById(data.data[o].mac).src = "../images/diannaotu_05.png";
                        else {
                            document.getElementById(data.data[o].mac).src = "data:image/png;base64," + b;
                            document.getElementById(data.data[o].mac + "1").innerHTML = c;
                            var f = document.getElementById(e).innerHTML;
                        }
                    }
                },

            });
        };
    </script>
    <style>
        html, body, table, form {
            height: 100%;
        }
        .wenzi { margin-top:10px}
        .right ul li{ padding-left:0px}

        .right ul li {
     height: auto; 
     border: none; 
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" style="height: 30px">
                    <div class="positionc" style="width: 100%">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="18" valign="left" height="30">
                                    <span class="zcbz"></span></td>
                                <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="在线查看"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="1228" align="left" valign="top" class="computertable2">
                    <div class="right">
                     <%--    <ul>
                                                    <asp:Repeater runat="server" ID="rp_ImgList">
                                                        <ItemTemplate>
                                                            <li>
                                                                <img id='<%#Eval("mac").ToString()%>' width="132" height="74" src='<%#GetPic(Eval("guid")) %>' />
                                                                <div class="wenzi">设备名：<%#Eval("ComputerName") %></div>
                                                                <div class="wenzi2">在线时间：<%#Eval("OnLineMin").ToString()==""?"0分钟":Eval("OnLineMin") %></div>
                                                                <span id='<%#Eval("mac").ToString()%>1' style="display: none">0</span>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>--%>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                            <tbody>
                                <asp:Repeater runat="server" ID="rp_List" OnItemDataBound="rp_List_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align:left;background-color:#e5f6e3; line-height:15px"><span style="font-weight:900;font-size:large;"><%#Eval("CName")%></span>
                                                <asp:HiddenField ID="hfbid" runat="server" Value='<%#Eval("BID") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rp_ImgList">
                                                        <ItemTemplate>
                                                            <li style="cursor:pointer" title='在线时长：<%#Eval("OnLineMin").ToString()==""?"0分钟":Eval("OnLineMin") %>'>
                                                                <img id='<%#Eval("mac").ToString()%>' width="132" height="74" src='<%#GetPic(Eval("guid")) %>' />
                                                               <%-- <div class="wenzi"><%#Eval("ComputerName") %></div>--%>
                                                                 <div class="wenzi"><%#Eval("DepOtherName") %></div>
                                                               <%-- <div class="wenzi2">在线时间：<%#Eval("OnLineMin").ToString()==""?"0分钟":Eval("OnLineMin") %></div>--%>
                                                                <span id='<%#Eval("mac").ToString()%>1' style="display: none">0</span>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


