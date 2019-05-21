<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysNoticeDetail.aspx.cs" Inherits="GKICMP.appstu.SysNoticeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>智慧校园</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />
    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/mui.min.js"></script>
    <script src="../js/oa_iconfont.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">通知公告</h1>
        </header>
        <div class="mui-content bgcolor-white">
            <div class="mui-col-xs-11" style="margin: auto;">
                <h4 style="text-align: center; line-height: 1; font-size: 10px; color: #929292;">发送人：
                    <asp:Label ID="lbl_SendUserName" runat="server" Text=""></asp:Label>
                    时间：  
                    <asp:Literal runat="server" ID="lbl_SendDate"></asp:Literal>
                </h4>
                <div style="text-align: center; line-height: 2; font-size: 14px; color: #e60d0d">
                    是否已读：  
                    <asp:Literal runat="server" ID="lbl_IsRead"></asp:Literal>
                </div>
                <div style="line-height: 2;">
                    <asp:Label ID="lbl_AContent" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <nav class="mui-bar mui-bar-tab">
             <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a href="../app/UserInfo.aspx" class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>
            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        <script src="/js/mui.min.js"></script>
        <script type="text/javascript" charset="utf-8">
            mui.init({
                swipeBack: true //启用右滑关闭功能
            });
            var slider = mui("#slider");
            slider.slider({
                interval: 3000
            });
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        </script>
    </form>
</body>
</html>