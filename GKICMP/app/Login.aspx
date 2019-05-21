<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GKICMP.app.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <script src="https://g.alicdn.com/ilw/ding/0.9.2/scripts/dingtalk.js"></script>
    <title></title>
     

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_Code" runat="server" Text="Button"  Style="display: none" 
                OnClick="btn_Code_Click" />
            <asp:HiddenField runat="server" ID="hf_Code"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hf_OpenID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hf_Access_Token"></asp:HiddenField>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    var _config = {
        agentId: '<%=agentId%>',
             corpId: 'dingbc5b86cca0a36b29',
             timeStamp: '<%=timestamp%>',
             nonce: 'sgffd674efdgs',
             signature: '<%=signature%>'
         };
         dd.config({
             agentId: _config.agentId,
             corpId: _config.corpId,
             timeStamp: _config.timeStamp,
             nonceStr: _config.nonce,
             signature: _config.signature,
             jsApiList: ['runtime.info', 'biz.contact.choose',
                     'device.notification.confirm', 'device.notification.alert',
                     'device.notification.prompt', 'biz.ding.post',
                     'biz.util.openLink']
         });
         dd.ready(function () {
             dd.runtime.permission.requestAuthCode({
                 corpId: _config.corpId,
                 onSuccess: function (info) {
                     var code = info.code;
                     document.getElementById("hf_Code").value = code;
                     document.getElementById('btn_Code').click();
                 },
                 onFail: function (err) {
                     alert('fail: ' + JSON.stringify(err));
                 }
             });
         });
         dd.error(function (err) {
             alert('dd error: ' + JSON.stringify(err));
         });

    </script>