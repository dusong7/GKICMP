<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCourseList.aspx.cs" Inherits="GKICMP.app.MyCourseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>我的课表</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        #page-wrapper {
            margin-bottom: 50px;
            margin-top: 45px;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
       <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">我的课表</h1>
        </header>

        <div id="page-wrapper">
            <div class="main-page">
                <div class="tables">
                    <div class="bs-example widget-shadow" data-example-id="bordered-table">
                        <asp:Label ID="lbl" runat="server">                   
                        </asp:Label>
                    </div>
                </div>
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
            <a href="AppMain.aspx" class="mui-tab-item  mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
    </form>
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
</body>
</html>
