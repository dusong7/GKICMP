<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacChat.aspx.cs" Inherits="GKICMP.networkteach.TeacChat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.6.4.min.js"></script>
    <script src="../Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="../signalr/hubs"></script>
    <script>
        $(function () {
            $("#listdiv").height($(window).height() - 90);
            $("#rightdiv").height($(window).height() - 89);
            $(".commentslist").height($("#listdiv").height() - 39);
            $(window).resize(function () {
                //$(".commentslist").height($("#commentstd").height())
                $("#listdiv").height($(window).height() - 90);
                $("#rightdiv").height($(window).height() - 89);
                $(".commentslist").height($("#listdiv").height() - 39);
            })
        })
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_NTLID" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30"><span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><span ><asp:Label ID="lbl_ParentMenu" runat="server" Text="课程管理"></asp:Label></span><span>></span><span ><asp:Label ID="lbl_Menuname" runat="server" Text="网络课程"></asp:Label></span></td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass" id="listdiv">
            <div class="leftdiv" id="left">
                <div class="videodiv" id="commentstd">
                    <video controls width="100%" height="100%" id="commentsvideo">
                        您的浏览器不支持 video 标签。
        
                    </video>
                </div>
            </div>
            <div class="rightdiv" id="rightdiv">
                <div style="" class="commentslist">
                    <ul id="discussion">
                    </ul>
                </div>
                <div class="rightbotdiv">
                    <input type="text" class="commentstext" placeholder="评论内容..." id="message" />
                    <input type="button" value="" class="commentsinput" id="sendmessage" />
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById("message").onkeydown = function (e) {
            if (e.keyCode == 13 && e.ctrlKey) {
                // 这里实现换行
                document.getElementById("message").value += "\n";
            } else if (e.keyCode == 13) {
                // 避免回车键换行
                e.preventDefault();
                $("#sendmessage").click();
                // 下面写你的发送消息的代码
            }
        }
        $(function () {
            var id = getUrlParam('id');
            $.ajax({
                url: "../ashx/Chat.ashx",
                cache: false,
                async: false,
                type: "get",
                // async: false,
                data: "id=" + id,
                dataType: "text",
                success: function (data) {
                    //var src = ".." + data.replace(/\\/g, "/");
                    $("#commentsvideo").prop("src", data);
                },
                error: function () {
                    alert(2);
                }
            })
        })
        $(function () {
            var t = getUrlParam('type');
            if (t == 1) {
                //$.getJSON("../ashx/Chat.ashx?id=" + id, function (data) {
                //    var src = "../" + data;
                //    $("commentsvideo").prop("src", src)
                //})
                var chat = $.connection.roomHub;

                chat.client.sendMessage = function (message) {
                    var encodedName = $("<div/>").text(message.Name).html();
                    var encodedMsg = $("<div/>").text(message.Message).html();
                    var time1 = new Date().Format("yyyy-MM-dd HH:mm:ss");
                    $("#discussion").append('<li><strong>' + encodedName + '</strong>&nbsp;&nbsp ' + time1 + '<br/>&nbsp;&nbsp;' + encodedMsg + '</li>');
                };
                //var roo = Math.floor((Math.random() * 100) + 1);
                var roo = getUrlParam('roomid');
                //var roo = '45';
                //$("#userName").text('ABC');
                $("#message").val('').focus();

                $.connection.hub.start().done(function () {
                    chat.server.addToRoom(roo);
                    chat.server.send({
                        RoomId: roo,
                        Name: '系统消息',
                        Message: '<%=Name%>加入房间'
                    });
                    $("#sendmessage").click(function () {
                        //chat.server.send('111', $("#message").val());
                        chat.server.send({
                            RoomId: roo,
                            Name: '<%=Name%>',
                            Message: $("#message").val()
                        });
                        $.ajax({
                            url: "../ashx/Chat.ashx",
                            cache: false,
                            type: "POST",
                            // async: false,
                            data: { name: $("#userName").text(), text: $("#message").val(), ntid: getUrlParam('id') },
                            dataType: "json",
                            success: function (data) { }
                        })
                        $("#message").val('').focus();
                    });

                });
            }
            else {
                //$("#rightbotdiv").attr("disabled", "disabled");
                //$("#rightbotdiv").hide();
                $("#rightdiv").css('display', 'none');
                $("#left").addClass('leftdivnoright');
                //$("#message").attr("disabled", "disabled"); 
                //$("#sendmessage").attr("disabled", "disabled");
            }
        });
        function showTime() {
            var ntid = getUrlParam('id'); //获取UserID
            var ntlid = document.getElementById("hf_NTLID").value;
            if (ntid !== "") {
                $.ajax({
                    url: "../ashx/Chat.ashx",
                    cache: false,
                    type: "GET",
                    data: "method=time&ntid=" + ntid + "&ntlid=" + ntlid,
                    dataType: "json",
                    async: false,
                    success: function (data) {

                    }
                })
            }
            else {
                alert("查询出错，请重新操作");
            }
        }
        setInterval("showTime()", 300000);
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }
        Date.prototype.Format = function (fmt) {
            var o = {
                "M+": this.getMonth() + 1, //月份     
                "d+": this.getDate(), //日     
                "H+": this.getHours(), //小时     
                "m+": this.getMinutes(), //分     
                "s+": this.getSeconds(), //秒     
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度     
                "S": this.getMilliseconds() //毫秒     
            };
            if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        }
    </script>
</body>
</html>

