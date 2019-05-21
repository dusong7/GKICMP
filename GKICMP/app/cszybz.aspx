<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cszybz.aspx.cs" Inherits="GKICMP.app.cszybz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link rel="stylesheet" href="../appcss/iconfont.css" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script>
        wx.config({
            beta: true,// 必须这么写，否则wx.invoke调用形式的jsapi会有问题
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: '<%=corpId%>', // 必填，企业微信的corpID
            timestamp: '<%=timestamp%>', // 必填，生成签名的时间戳
            nonceStr: '<%=nonceStr%>', // 必填，生成签名的随机串
            signature: '<%=signature%>',// 必填，签名，见[附录1](#11974)
            jsApiList: ['startRecord', 'stopRecord', 'onVoiceRecordEnd', 'playVoice', 'stopVoice', 'onVoicePlayEnd', 'uploadVoice', 'chooseImage'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function () {
            //通过ready接口处理成功验证
            //alert("验证成功");

            //监听录音自动停止接口
            wx.onVoiceRecordEnd({
                // 录音时间超过一分钟没有停止的时候会执行 complete 回调
                complete: function (res) {
                    var localId = res.localId;
                    $("#localId").val(localId);
                }
            });

            //监听语音播放完毕接口
            wx.onVoicePlayEnd({
                success: function (res) {
                    var localId = res.localId; // 返回音频的本地ID
                    $("#localId").val(localId);
                    $("#ly").attr("style", "border-top: 0px; border-left: 0px; border-right: 0px; display: block;display:block;");
                    $("#count").val(1);
                }
            });
        });
        wx.error(function (res) {
            //alert(res);
            //通过ready接口处理失败验证
        });
        function fj(obj) {
            var arr = $(obj).val().split('\\');
            document.getElementById('textName').innerHTML = arr[arr.length - 1];
            $("#hf_file").val(arr[arr.length - 1]);
        }

        //开始录音接口
        function startRecord() {
            wx.startRecord();
        }
        //停止录音接口
        function stopRecord() {
            wx.stopRecord({
                success: function (res) {
                    var localId = res.localId;
                    $("#localId").val(localId);
                }
            });
        }
        //播放语音接口
        function playVoice() {
            wx.playVoice({
                localId: $("#localId").val()// 需要播放的音频的本地ID，由stopRecord接口获得
            });
        }
        //停止播放接口
        function stopVoice() {
            wx.stopVoice({
                localId: $("#localId").val()// 需要停止的音频的本地ID，由stopRecord接口获得
            });
        }

        function tj() {
            if ($("#hf_CID").val() == "") {
                alert("请选择学科");
            }
            else {
                if (isNaN($("#txt_CompleteTime").val())) {
                    alert("请录入正确的数字");
                    $("#txt_CompleteTime").val("");
                }
                else {
                    if ($("#txt_CompleteTime").val() <= 0) {
                        alert("请录入正确的数字");
                        $("#txt_CompleteTime").val("");
                    }
                    else {
                        if ($("#hf_DID").val() == "") {
                            alert("请选择班级");
                        }
                        else {
                            if ($("#localId").val() == "") {
                                if ($("#div_HomeWork").text() == "") {
                                    alert("请录入作业内容");
                                }
                                else {
                                    if ($("#hf_file").val() == "") {
                                        $.ajax({
                                            url: "../ashx/GetMainDate.ashx",
                                            cache: false,
                                            type: "get",
                                            async: false,
                                            data: "method=Sendzy&cid=" + $("#hf_CID").val() + "&homework=" + $("#div_HomeWork").text() + "&completeTime=" + $("#txt_CompleteTime").val() + "&did=" + $("#hf_DID").val() + "&claname=" + $("#hf_OtherName").val() + "&serverid=" + "&accessToken=",
                                            dataType: "json",
                                            success: function (data) {
                                                if (data.result == "true") {
                                                    alert("成功");
                                                }
                                                else {
                                                    alert("失败");
                                                }
                                            }
                                        })
                                    }
                                    else {
                                        $.ajax({
                                            url: "../ashx/GetMainDate.ashx",
                                            cache: false,
                                            type: "get",
                                            async: false,
                                            data: "method=Sendtwxx&accessToken=<%=accessToken%>" + "&wj=" + $("#hf_file").val(),
                                            dataType: "json",
                                            success: function (data) {
                                                if (data.result == "true") {
                                                    alert("成功");
                                                }
                                                else {
                                                    alert("失败");
                                                }
                                            }
                                        })
                                    }
                                }
                            }
                            else {
                                //上传语音接口  
                                wx.uploadVoice({
                                    localId: $("#localId").val(), // 需要上传的音频的本地ID，由stopRecord接口获得
                                    isShowProgressTips: 1, // 默认为1，显示进度提示
                                    success: function (res) {
                                        var serverId = res.serverId; // 返回音频的服务器端ID
                                        if (serverId != "") {
                                            $.ajax({
                                                url: "../ashx/GetMainDate.ashx",
                                                cache: false,
                                                type: "get",
                                                async: false,
                                                data: "method=Sendzy&cid=" + $("#hf_CID").val() + "&homework=" + $("#div_HomeWork").text() + "&completeTime=" + $("#txt_CompleteTime").val() + "&did=" + $("#hf_DID").val() + "&claname=" + $("#hf_OtherName").val() + "&serverid=" + serverId + "&accessToken=<%=accessToken%>",
                                                dataType: "json",
                                                success: function (data) {
                                                    if (data.result == "true") {
                                                        alert("成功");
                                                    }
                                                    else {
                                                        alert("失败");
                                                    }
                                                }
                                            })
                                        }
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
        var c = 0;
        var tz = "";
        function ly(obj) {
            c = 0;
            $("#bf").attr("style", "display:none;");
            $(".tcmain").attr("style", " display:block");
            $("#lbl_time").text(c + "''");
            tz = setInterval("startRequest()", 1000);
            startRecord();
        }

        function startRequest() {
            c += 1;
            if (c >= 60) {
                clearInterval(tz);
                gb();
            }
            else {
                $("#lbl_time").text(c + "''");
            }

        }
        function gb() {
            $(".tcmain").attr("style", "display:none;");
            $("#bf").attr("style", "border-top: 0px; border-left: 0px; border-right: 0px;display:block;");
            stopRecord();

        }
        function bf(obj) {
            var css = $("#count").val();
            if (css == "1") {
                playVoice();
                $(obj).prev().attr("style", "border-top: 0px; border-left: 0px; border-right: 0px; display: block;display:none;");
                $("#count").val(2);
            }
            else {
                stopVoice();
                $(obj).prev().attr("style", "border-top: 0px; border-left: 0px; border-right: 0px; display: block;display:block;");
                $("#count").val(1);
            }
        }
    </script>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 80px;
        }

        .multipletext {
            min-height: 200px;
        }
    </style>
    <style>
        body {
            margin: 0px;
            padding: 0px;
        }

        .selectdiv {
            display: none;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0px;
            left: 0px;
            background: #fff;
            color: #494949;
            overflow-y: auto;
            z-index: 999;
        }

        .allselect {
            float: left;
            margin: 5px;
            margin-left: 10px;
        }

            .allselect span {
                float: left;
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                margin-right: 5px;
            }

                .allselect span.selected {
                    background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
                }

        .selectclose {
            float: right;
            display: block;
            border: 1px solid #989898;
            border-radius: 2px;
            padding: 3px 10px;
            margin: 5px;
            font-size: 14px;
        }

        .selectdiv ul, .selectdiv li {
            margin: 0px;
            list-style: none;
            padding: 0px;
        }

        .selectdiv .parentli {
            border-bottom: 1px solid #DDDDDD;
            padding: 10px 10px;
        }

            .selectdiv .parentli.selected ul {
                display: block;
            }

            .selectdiv .parentli span.selected {
                background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
            }

            .selectdiv .parentli ul {
                display: none;
            }

            .selectdiv .parentli span {
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli img {
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli li {
                width: 70px;
                display: inline-block;
                border: 1px solid #dedede;
                margin-top: 10px;
                padding: 3px 5px;
                border-radius: 2px;
            }

                .selectdiv .parentli li.select {
                    background: url(../appimages/selectinfo.png) 50px center no-repeat #f5faff;
                    border-color: #1296db;
                    color: #1296db;
                }

        .mui-content-padded {
            margin-top: 0px;
        }
    </style>
    <script>
        $(function () {
            $(".parentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#dxseclet").click(function () {
                $("#dxc").css("display", "block");
            })

            $("#selectclose").click(function () {
                $("#dxc").css("display", "none");
            })

            $(".parentli img").click(function () {
                if ($(this).parent("li").hasClass("selected")) {
                    $(this).parent("li").removeClass("selected");
                    $(this).attr("src", "../appimages/allpic.png");
                } else {
                    $(this).parent("li").addClass("selected");
                    $(this).attr("src", "../appimages/allinpic.png");
                }
            })
            $("#allselect span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(".parentli span").removeClass("selected");
                    $(".parentli li").removeClass("select");
                    $(".parentli li").addClass("noselect");
                } else {
                    $(this).addClass("selected");
                    $(".parentli span").addClass("selected");
                    $(".parentli li").addClass("select");
                    $(".parentli li").removeClass("noselect");
                }
                selectoption();
            })

            $(".parentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("selected");
                } else {
                    $(this).parent().siblings("span").addClass("selected");
                }
                selectoption();
            })

            $(".parentli span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("selected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                selectoption();
            })
            function selectoption() {
                $("#hf_DID").val('');
                $("#dxseclet").val('');
                $(".parentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_DID").val($("#hf_DID").val() + this.id + ",");
                        $("#dxseclet").val($("#dxseclet").val() + this.title + ",");
                        $("#hf_OtherName").val($("#dxseclet").val());
                    }
                });
                if ($("#dxc .parentli").find("li").hasClass("noselect")) {
                    $("#allselect span").removeClass("selected");
                } else {
                    $("#allselect span").addClass("selected");
                }
            }

        })
    </script>
    <title>布置作业</title>
</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">布置作业</h1>
    </header>


    <div class="mui-content">
        <form class="mui-input-group" runat="server">
            <input type="hidden" id="count" value="1" />
            <input type="hidden" id="localId" />
            <input type="hidden" id="hf_time" />
            <asp:HiddenField ID="hf_DID" runat="server" />
            <asp:HiddenField ID="hf_OtherName" runat="server" />
            <div class="mui-input-row">
                <div contenteditable="true" id="div_HomeWork" class="multipletext" placeholder="请在此填写作业内容" runat="server"></div>
            </div>
            <div class="tcmain">
                <div class="tcdiv" onclick="gb()">
                    <div class="iconfont icon-ly lyfont">
                        <span style="margin-left: -60px; float: right; width: 80px;">
                            <label id="lbl_time"></label>
                        </span>
                    </div>
                    <div style="margin-top: 90px;">录音中,点击结束</div>
                </div>
            </div>
            <div class="mui-input-row">
                <label>附件</label>
                <div class="righttext">
                    <span class="mui-icon mui-icon-paperclip file" id="upimage">
                        <input id="upimagebtn" type="file" onchange="fj(this)" accept="image/*,capture=camera" runat="server" /></span>
                </div>
                <div id="textName" style="width: 100%; padding: 0px 15px; clear: both; line-height: 20px;"></div>
                <asp:HiddenField ID="hf_file" runat="server" />
            </div>
            <div class="mui-input-row">
                <div class="voice-btn">
                    <div class="mui-btn iconfont icon-wly" style="border-top: 0px; border-left: 0px; border-right: 0px; display: block;" id="ly" onclick="ly(this)"></div>
                    <div class="mui-btn iconfont icon-bf" style="border-top: 0px; border-left: 0px; border-right: 0px; display: none;" id="bf" onclick="bf(this)"></div>
                </div>
            </div>
            <div class="mui-input-row">
                <label>选择学科</label>
                <asp:TextBox runat="server" name="showUserPicker" ID="txt_CID" placeholder="请选择学科"></asp:TextBox>
                <asp:HiddenField ID="hf_CID" runat="server" />
            </div>
            <div class="mui-input-group linght40">
                <div class="mui-input-row">
                    <label>完成时间</label>
                    <asp:TextBox runat="server" ID="txt_CompleteTime" CssClass="mui-icon-location" placeholder="请填写"></asp:TextBox>
                </div>
            </div>
            <div class="mui-input-group linght40">
                <div class="mui-input-row">
                    <label>班级</label>
                    <input type="text" id="dxseclet" name="dxseclet" placeholder="请选择班级" />
                    <div class="selectdiv" id="dxc">
                        <div style="height: 30px">
                            <div class="allselect" id="allselect"><span></span>全选</div>
                            <span class="selectclose" id="selectclose">确定</span>
                        </div>
                        <ul>
                            <asp:Repeater ID="rpmodule" runat="server" OnItemDataBound="rpmodule_ItemDataBound">
                                <ItemTemplate>
                                    <li class='<%#Container.ItemIndex==0?"parentli selected":"parentli" %>'>
                                        <img src='<%#Container.ItemIndex==0?"../appimages/allinpic.png":"../appimages/allpic.png"%>' /><span></span><%#Eval("ShortGName") %>
                                        <asp:HiddenField runat="server" ID="hf_GID" Value='<%#Eval("GID") %>' />
                                        <ul>
                                            <asp:Repeater ID="rpnextModule" runat="server">
                                                <ItemTemplate>
                                                    <li id='<%#Eval("DID") %>' title='<%#Eval("OtherName") %>'><%#Eval("OtherName") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
            <input type="button" onclick="tj()" class="mui-btn mui-btn-primary mui-btn-block bgcolor" style="color: #fff" value="提交" />
        </form>
    </div>

    <nav class="mui-bar mui-bar-tab">
        <a href="/phone" class="mui-tab-item ">
            <span class="mui-icon mui-icon-home"></span>
            <span class="mui-tab-label">网站</span>
        </a>
        <a href="UserInfo.aspx" class="mui-tab-item">
            <span class="mui-icon iconfont icon-wd"></span>
            <span class="mui-tab-label">我的</span>
        </a>
        <%--   <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
        <a href="AppMain.aspx" class="mui-tab-item mui-active">
            <span class="mui-icon iconfont icon-zhxy"></span>
            <span class="mui-tab-label">智慧校园</span>
        </a>
    </nav>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET",
                    data: "method=GetXK",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_CID');
                var userResult = doc.getElementById('txt_CID');
                var userCustName = doc.getElementById('hf_CID');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);
            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>


