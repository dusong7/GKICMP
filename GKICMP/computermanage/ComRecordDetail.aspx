<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComRecordDetail.aspx.cs" Inherits="GKICMP.computermanage.ComRecordDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title><style>html,body,table,form{height:100%}</style>
      <link href="../css/green_list.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        var ccid = getUrlParam("id");
        $(function () {
            runajax();
           
            setInterval(runajax, 5000);
        });
        function runajax() {
            $.ajax({
                url: "../ashx/ComputersPic.ashx",
                cache: false,
                type: "GET",
                // async: false,
                data: "method=GetRecord&CCID=" + ccid,
                dataType: "json",
               // timeout:5000,
                success: function (data) {
                    for (var o in data) {
                        var a = data[o].Mac;
                        var b = data[o].RegDate;
                        var c = data[o].UserName;
                        $("#" + a).children("img").attr("src", "../images/register.jpg");
                        $("#" + a).children(".jfdj").remove();
                        $("#" + a).prepend("<span class='jfdj'>" + c + "</span>");
                    }
                    
                },  

            });
        };
    </script>
    <style>
        .right ul li{ position:relative}
        .jfdj{ position:absolute; display:block; width:80px; height:30px; line-height:30px; font-size:25px;font-weight:800; font-family:Arial; color:white;  text-align:center; top:40px; left:56px}</style>
</head>
<body >
    <form id="form1" runat="server">
        <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" style="height: 30px">
                    <div class="positionc" style="width: 100%">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="18" valign="left" height="30">
                                    <span class="zcbz"></span></td>
                                <td class="positiona"><a>首页</a><span>></span><span>机房登记管理</span><span>></span><span>在线查看</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="1228" align="left" valign="top" class="computertable2" colspan="2">
                    <div class="right">
                        <ul>
                            <asp:Repeater runat="server" ID="rp_ImgList">
                                <ItemTemplate>
                                    <li id='<%#Eval("MAC").ToString()%>'>
                                        <img width="132" height="74" src="../images/none.png" />
                                        <div class="wenzi">设备名：<%#Eval("ComputerName") %></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2"align="center">
                     <input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.location.href = "ComCourseManage.aspx";' />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
