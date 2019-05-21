<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GKICMP.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" 
"http://www.w3.org/TR/html4/strict.dtd">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园管理平台</title>
    <link rel="icon" href="gzimages/yghd_favicon.ico" type="image/x-icon" />
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="http://rescdn.qqmail.com/node/ww/wwopenmng/js/sso/wwLogin-1.0.0.js"></script>
    <script>


        function Qrcode() {
            if (document.getElementById("Qrcode").style.display == "none") {

                document.getElementById("Qrcode").style.display = "block";
                document.getElementById("Qrcodeimg").src = "images/timg1.png";
                document.getElementById("denglu1").style.display = "none";
            }
            else {

                document.getElementById("Qrcode").style.display = "none";
                document.getElementById("Qrcodeimg").src = "images/timg.png";
                document.getElementById("denglu1").style.display = "block";
            }

        }
        function loginwx() {

            document.getElementById("Qrcodeform").style.display = "block";
            if ($(".result_text").length > 0) {
                $(".result_text").innerHtml("若要使用扫码登录，必须配置企业微信");
            }
            var url = window.location.href;
            var link = '';
            if (url.indexOf('Default') > 0)
                link = window.location.href.replace('Default', 'wxlogin') + "?id=Main";
            else
                link = window.location.href + 'wxlogin.aspx' + "?id=Main";
            var a= window.WwLogin({
                "id": "formdiv",
                "appid": "<%=corpId%>",
                "agentid": "<%=agentId%>",
                "redirect_uri": link,
                "state": "",
                "href": "",
            });
        }
        function loginwxclose() {
            document.getElementById("Qrcodeform").style.display = "none";
        }
        function cc() {
            var iframe = document.getElementsByTagName('iframe')[0];
            var ifr_document = iframe.contentWindow.document;
            var a = ifr_document.getElementsByClassName("result_text")
        }

    </script>
    <style>
        #Qrcode {
            position: absolute;
            right: 2px;
            background: rgba(255, 255, 255, 0.3);
            border-radius: 8px;
            width: 100%;
            height: 100%;
            display: none;
        }

        #Qrcodebtn {
            position: absolute;
            right: 2px;
            border-radius: 0px 8px 0px 0px;
            width: 142px;
            cursor: pointer;
        }

        #Qrcodeform {
            position: absolute;
            right: 2px;
            background: rgba(255, 255, 255, 1);
            border-radius: 8px;
            width: 100%;
            height: 100%;
            display: none;
            text-align: center;
        }

        #Qrcodeimg {
            border-radius: 0px 8px 0px 0px;
            width: 142px;
        }

        .formbtn {
            cursor: pointer;
        }
    </style>
</head>

<body>
    <form id="frome1" runat="server">
        <div class="main">
            <div class="denglu">
                <div id="Qrcode" style="display: none">
                    <img src="gzimages/qrcode.png" style="margin: 80px;">
                </div>
                <div onclick="Qrcode()" id="Qrcodebtn">
                    <img src="images/timg.png" id="Qrcodeimg">
                </div>
                <div id="Qrcodeform" style="display: none;">

                    <div id="formdiv" style="margin-top: 20px;"></div>
                    <div class="formbtn" style="display: block; font-size: 12px; position: absolute; right: 20px; bottom: 20px; padding: 5px 

10px; border: 1px solid #43ba52; border-radius: 2px;"
                        onclick="loginwxclose()">
                        密码登录
                    </div>
                </div>
                <center>
                <div class="denglu1" id="denglu1" style="display:block">
                    <div class="yonghudenglu">用户登录</div>
                    <div class="maininput">
                        <asp:TextBox ID="txt_UserName" runat="server" MaxLength="28" placeholder="学号/身份证/用户名"></asp:TextBox>
                    </div>
                    <div class="maininput2">
                        <asp:TextBox ID="txt_PassWord" MaxLength="30" TextMode="Password" placeholder="密码" runat="server"></asp:TextBox>
                    </div>
                    <div class="zhaohuimima"> <span class="formbtn" onclick="loginwx()">二维码登录</span></div>

                    <div class="dengluanniu">
                        <asp:ImageButton ID="ibtn_Login" runat="server" ImageUrl="~/images/deng_09.png" OnClick="ibtn_Login_Click" Width="100%" />
                       
                    </div>
        
                </div>
                </center>
            </div>
        </div>
        <div class="banquan">版权所有    芜湖市高科电子有限公司  版本号：v2.1</div>
    </form>
</body>
</html>


