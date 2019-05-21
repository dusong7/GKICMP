<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendNews.aspx.cs" Inherits="GKICMP.cms.SendNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <style>
        body {
            font-family: "微软雅黑";
        }

        .ph-class {
            width: 290px;
            height: 591px;
            background: url(../images/phimg.png);
            margin: 10px auto;
        }

        .at-list1 {
            width: 250px;
            height: 444px;
            margin-left: 20px;
            margin-top: 74px;
            float: left;
            background: #EDEDED;
            overflow-y: auto;
        }

        .at-c-1 {
            margin: 10px;
            border-radius: 5px;
            background: #fff;
            overflow: hidden;
        }

            .at-c-1 img {
                width: 100%;
                height: 150px;
            }

            .at-c-1 .at-title {
                margin: 0px;
                padding: 5px;
                line-height: 1.5;
                font-size: 1.5em;
            }

            .at-c-1 .at-info {
                font-size: 12px;
            }

        .at-list2 {
            margin: 10px;
            border-radius: 5px;
            background: #fff;
            overflow: hidden;
            padding-bottom: 5px;
        }

            .at-list2 .at-c-1 {
                position: relative;
                margin: 0px;
                border-radius: 0px;
                background: #fff;
            }

                .at-list2 .at-c-1 .at-title {
                    position: absolute;
                    bottom: 0px;
                    left: 0px;
                    background: rgba(0,0,0,0.2);
                    width: 100%;
                    color: #fff;
                }

                .at-list2 .at-c-1 .at-info {
                    color: #fff;
                    font-size: 12px;
                }

        .at-listnews {
            margin: 0px 10px;
        }

            .at-listnews img {
                width: 45px;
                height: 45px;
                float: right;
            }

            .at-listnews li {
                margin: 0px 5px;
                padding: 5px 0px;
                border-bottom: 1px solid #ededed;
            }

                .at-listnews li span {
                    line-height: 1.5;
                    font-size: 14px;
                    height: 45px;
                    overflow: hidden;
                    display: block;
                }

        .send-btn {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 45px;
            border-radius: 23px;
            height: 45px;
            line-height: 45px;
            cursor: pointer;
        }

            .send-btn:hover {
                background: #3ba84e;
                color: #fff;
            }

        .add-btn {
            margin: 0px 10px;
            border: 1px solid #FFFFFF;
            text-align: center;
            padding: 5px;
            background: #fff;
            margin-bottom: 10px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30"><span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="日常办公"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="新闻推送"></asp:Label>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <div class="ph-class">
                <div class="at-list1">
                    <div id="news">
                        <div class="at-c-1" id="frist"></div>
                        <div class="at-listnews">
                            <ul id="NewsList">
                            </ul>
                        </div>
                    </div>
                    <div class="add-btn" title="点击添加新闻">
                        <img src="../images/add.png" onclick="add()"  /></div>
                </div>
                <div style="clear: both"></div>
                <div class="send-btn" onclick="tj()" title="点击发送后，关注企业号的人员将接收到所推送的新闻">发送</div>
            </div>
        </div>
    </form>
    <script>
        var newlist = new Array();
        
        function add() {
            return openbox('S_id', 'NewsSelect.aspx', '', 840, 500, 1);
        }
        function AddNews(nid, title, desc, url, picurl) {
            var html = "";
            var a = $("#frist").html();
            if ($("#frist").html() == "") {
                html = html + "<img src='" + picurl + "'  height='150px' overflow-y=' auto'><div class='at-title'>" + title + "<div class='at-info'>" + desc + "</div></div>";
                $("#frist").append(html);
            }
            else {
                $("#news").attr("class", "at-list2")
                html = html + "<li id='" + nid + "'><img src='" + picurl + "'><span>" + title + "</span></li>"
                $("#NewsList").append(html);
            }
            var news = {};
            news.id = nid,
            news.title = title;
            news.desc = desc,
            news.url = url,
            newlist.push(news);
            console.log(newlist);
        }
        function tj() {
            var b = newlist;
            var a = JSON.stringify(newlist);
            $.ajax({
                url: "../ashx/NewsSend.ashx?method=send",
                cache: false,
                type: "post",
                data: { 'newslist': JSON.stringify(newlist) },
                dataType: "json",
                //timeout: 1000,
                //async: false,
                success: function (data) {
                    alert("发送成功");
                    //newlist.push(data.data);
                }
            })
        }

        function del() {
            newlist = remove(newlist, "id", "68");
            console.log(newlist);
            var a = JSON.stringify(newlist);
            $("#68").remove();
        }
        function remove(arrPerson, objPropery, objValue) {
            return $.grep(arrPerson, function (cur, i) {
                return cur[objPropery] != objValue;
            });
        }
    </script>
</body>

</html>

