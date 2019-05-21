<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkManage.aspx.cs" Inherits="GKICMP.appstu.LinkManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>智慧校园</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../appcss/iconfont.css" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <style>
        .mui-bar .mui-title {
            left: 100px;
            right: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">通讯录</h1>
        </header>
        <div class="mui-content">
            <div class="mui-content-padded" style="margin: 5px 0px;">
                <div class="search">
                    <asp:TextBox runat="server" ID="txt_Name" class="mui-input-clear" placeholder="请输入姓名"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_Search" runat="server" CssClass="mui-icon mui-icon-search searchinput" OnClick="btn_Search_Click"></asp:LinkButton>
                </div>
            </div>
            <ul class="mui-table-view">
                <asp:Repeater ID="rp_List" runat="server">
                    <ItemTemplate>
                        <li class="mui-table-view-cell margin10">
                            <span>
                                <div class="mui-table">
                                    <div class="mui-table-cell mui-col-xs-10">
                                        <h4 class="mui-ellipsis color-2 mui-ellipsis"><%#Eval("RealName") %><span class="color-0" style="color: #47AE6F; font-size: 15px">[<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("UserSex")) %>]</span></h4>
                                        <p class="mui-h5 mui-ellipsis">
                                            <span>手机：<a href='tel://<%#Eval("CellPhone") %>'><%#Eval("CellPhone") %></a></span><span>&nbsp  QQ：<%#Eval("QQNum") %></span><br />
                                            <span>微信号：<%#Eval("WeiNum") %></span>
                                        </p>
                                    </div>
                                </div>
                            </span>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul runat="server" id="ul_null" style="text-align: center;" class="mui-table-view">
                <li class="mui-table-view-cell margin0">暂无记录</li>
            </ul>
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
