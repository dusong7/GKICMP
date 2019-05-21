<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxyy.aspx.cs" Inherits="GKICMP.test.wxyy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no, width=device-width" />
    <title></title>
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
            jsApiList: ['startRecord', 'stopRecord', 'onVoiceRecordEnd', 'playVoice', 'pauseVoice', 'stopVoice', 'onVoicePlayEnd', 'uploadVoice', 'downloadVoice'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
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
        //暂停播放接口
        function pauseVoice() {
            wx.pauseVoice({
                localId: $("#localId").val() // 需要暂停的音频的本地ID，由stopRecord接口获得
            });
        }
        //停止播放接口
        function stopVoice() {
            wx.stopVoice({
                localId: $("#localId").val()// 需要停止的音频的本地ID，由stopRecord接口获得
            });
        }
        //上传语音接口
        function uploadVoice() {
            wx.uploadVoice({
                localId: $("#localId").val(), // 需要上传的音频的本地ID，由stopRecord接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function (res) {
                    var serverId = res.serverId; // 返回音频的服务器端ID
                    $("#hf_serverId").val(serverId);
                }
            });
        }
        //下载语音接口
        function downloadVoice() {
            wx.downloadVoice({
                serverId: $("#hf_serverId").val(), // 需要下载的音频的服务器端ID，由uploadVoice接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function (res) {
                    var localId = res.localId; // 返回音频的本地ID
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="localId" />
            <asp:HiddenField ID="hf_serverId" runat="server" />

            <input onclick="startRecord()" type="button" value="开始录音 " />
            <br />
            <input onclick="stopRecord()" type="button" value="结束录音 " />
            <br />
            <input onclick="playVoice()" type="button" value="开始播放 " />
            <br />
            <input onclick="pauseVoice()" type="button" value="暂停播放 " />
            <br />
            <input onclick="stopVoice()" type="button" value="停止播放 " />
            <br />
            <input onclick="uploadVoice()" type="button" value="上传语音 " />
          <%--  <br />
            <asp:Button ID="btn" runat="server" Text="下载" OnClick="btn_Click" />
            <br />
            <input onclick="downloadVoice()" type="button" value="下载语音 " />--%>
        </div>
    </form>
</body>
</html>
