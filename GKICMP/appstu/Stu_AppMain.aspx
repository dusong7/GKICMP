<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stu_AppMain.aspx.cs" Inherits="GKICMP.appstu.Stu_AppMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>智慧校园</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../appjs/mui.min.js"></script>
    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hffth" runat="server" />
        <div class="mui-content padbot">
            <div class="pading5">
                <ul class="centmenu">
                    <li class="mui-col-xs-6 mui-col-sm-6">
                        <a href="SysNoticeManage.aspx" class="bgc1 mgr5">通知公告<span class="iconfont icon-tzgg"></span></a>
                    </li>
                    <li class="mui-col-xs-6 mui-col-sm-6">
                        <a href="#" class="bgc2 mgl5">我的空间<span class="iconfont icon-wdkj"></span></a>
                    </li>
                    <div style="clear: both;"></div>
                </ul>
                <ul class="mui-table-view mui-grid-view mui-grid-9">
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="ExamManage.aspx">
                            <span class="mui-icon iconfont icon-wdks "></span>
                            <div class="mui-media-body">我的考试</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="LinkManage.aspx">
                            <span class="mui-icon iconfont icon-txl"></span>
                            <div class="mui-media-body">通讯录</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="MyCourseList.aspx">
                            <span class="mui-icon iconfont icon-zbrz"></span>
                            <div class="mui-media-body">我的课表</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="HomeWorkManage.aspx">
                            <span class="mui-icon iconfont icon-zyb"></span>
                            <div class="mui-media-body">作业本</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="ElectiverList.aspx">
                            <span class="mui-icon iconfont icon-wdxk"></span>
                            <div class="mui-media-body">我的选课</div>
                        </a>
                    </li>
                     <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="ElectiverList.aspx">
                            <span class="mui-icon iconfont icon-wdxk"></span>
                            <div class="mui-media-body">问卷调查</div>
                        </a>
                    </li>
                   <%-- 
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="Leave.aspx">
                            <span class="mui-icon iconfont icon-qjwc"></span>
                            <div class="mui-media-body">我的请假</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AppointmentEdit.aspx">
                            <span class="mui-icon iconfont icon-bzrgzs"></span>
                            <div class="mui-media-body">我的奖惩</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="SpaceLogList.aspx">
                            <span class="mui-icon iconfont icon-xyhd"></span>
                            <div class="mui-media-body">我的评语</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="SpaceLogList.aspx">
                            <span class="mui-icon iconfont icon-xyhd"></span>
                            <div class="mui-media-body">体质健康</div>
                        </a>
                    </li>--%>

                </ul>
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
            <a href="Stu_AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>

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
