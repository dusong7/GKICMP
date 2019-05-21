<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YYXX.aspx.cs" Inherits="GKICMP.app.YYXX" %>

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
    <title>语音消息</title>
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
            jsApiList: ['startRecord', 'stopRecord', 'onVoiceRecordEnd', 'playVoice', 'stopVoice', 'onVoicePlayEnd', 'uploadVoice'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
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
                    $("#ly").attr("style", "width: 100%; margin-top: 5px;display:block;");
                    $("#count").val(1);
                }
            });
        });
        wx.error(function (res) {
            //alert(res);
            //通过ready接口处理失败验证
        });
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
                            data: "method=send&uid=" + $("#hf_AuditResult").val() + "&serverid=" + serverId + "&accessToken=<%=accessToken%>",
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
            $("#bf").attr("style", "display:block;");
            stopRecord();

        }
        function bf(obj) {
            var css = $("#count").val();
            if (css == "1") {
                playVoice();
                $(obj).prev().attr("style", "width: 100%; margin-top: 5px;display:none;");
                $("#count").val(2);
            }
            else {
                stopVoice();
                $(obj).prev().attr("style", "width: 100%; margin-top: 5px;display:block;");
                $("#count").val(1);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="count" value="1" />
        <input type="hidden" id="localId" />
        <input type="hidden" id="hf_time" />
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">
                <asp:Label ID="lbl_title" runat="server"></asp:Label></h1>
        </header>
        <div class="tcmain">
            <div class="tcdiv" onclick="gb()">
                <div class="iconfont icon-ly lyfont">
                    <span style="margin-left: -80px; float: right; width: 100px;">
                        <label id="lbl_time"></label>
                    </span>
                </div>
                <div style="margin-top: 90px;">录音中,点击结束</div>
            </div>
        </div>
        <div class="mui-content">
            <div class="mui-content-padded w100">

                <div class="voice-btn">
                    <div class="mui-btn iconfont icon-wly" style="width: 100%; margin-top: 5px; display: block;" id="ly" onclick="ly(this)"></div>
                    <div class="mui-btn iconfont icon-bf" style="width: 100%; margin-top: 5px; display: none;" id="bf" onclick="bf(this)"></div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <asp:TextBox ID="txt_AuditResult" runat="server" CssClass="mui-icon-location" placeholder="请选择人员"></asp:TextBox>
                        <asp:HiddenField ID="hf_AuditResult" runat="server" />
                    </div>
                </div>

                <div class="voice-btn">
                    <div class="mui-btn mui-btn-primary" style="width: 100%; margin-top: 5px;" onclick="tj()">提交</div>
                </div>
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
                <%--    <a class="mui-tab-item">
                    <span class="mui-icon iconfont icon-bj"></span>
                    <span class="mui-tab-label">班级</span>
                </a>--%>
                <a href="AppMain.aspx" class="mui-tab-item mui-active">
                    <span class="mui-icon iconfont icon-zhxy"></span>
                    <span class="mui-tab-label">智慧校园</span>
                </a>
            </nav>
        </div>
        <script>
            (function ($, doc) {
                $.init();
                $.ready(function () {
                    var userPicker = new $.PopPicker();
                    // userPicker.setData([]);

                    userPicker.setData(
                    [
                        { value: 'YinZhiRui', text: '殷志瑞' },
                        { value: '123999999', text: '刘福州' },
                        { value: 'GuiXiongLei', text: '管理员' }
                    ]
                );
                    var showUserPickerButton = doc.getElementById('txt_AuditResult');
                    var userResult = doc.getElementById('txt_AuditResult');
                    var userCustName = doc.getElementById('hf_AuditResult');
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
    </form>
</body>
</html>
