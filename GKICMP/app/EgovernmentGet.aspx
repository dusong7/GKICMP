<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentGet.aspx.cs" Inherits="GKICMP.app.EgovernmentGet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>电子政务</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/oa_iconfont.js"></script>
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <style>
        .mui-bar .mui-title 
        {
            left: 100px;
            right: 100px;
            padding-bottom: 100px;
        }
        .mui-bar-nav ~ .mui-content 
        {
            padding-top: 44px;
            padding-bottom: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <a class="mui-pull-left iconfont icon-fanhui color-3 fhjt" href="javascript:history.back();"></a>
            <h1 class="mui-title">电子政务</h1>
        </header>
        <div class="mui-content">
            <div class="mui-content-padded" style="margin: 5px 0px 20px 0px;">
                <div class="search">
                    <asp:TextBox runat="server" ID="txt_Name" class="mui-input-clear" placeholder="请输入标题"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_Search" runat="server" CssClass="mui-icon mui-icon-search searchinput" OnClick="btn_Search_Click"></asp:LinkButton>
                    <input type="button" value="返回" onclick="javascript: window.history.back(-1);" />
                </div>
            </div>
            <ul class="mui-table-view">
                <asp:Repeater ID="rp_List" runat="server">
                    <ItemTemplate>
                        <li class="mui-table-view-cell margin10">
                            <span>
                                <div class="mui-table">
                                  
                                    <div class="mui-table-cell mui-col-xs-10">
                                        <a href='EgovernmentDetail.aspx?id=<%#Eval("FID") %>'>
                                            <h5 class="mui-ellipsis color-2 mui-ellipsis">
                                                <span class="color-0" style="color: #47AE6F; font-size: 14px">
                                                    <%#Eval("IsApproved").ToString()=="1"?"[公文]":"" %>
                                                </span>
                                               <%#Eval("Etitle") %>
                                            </h5>
                                        </a>
                                        <%--<h5 class="mui-ellipsis color-2 mui-ellipsis"><span class="color-0" style="color: #47AE6F; font-size: 14px"><%#Eval("IsApproved").ToString()=="1"?"[公文]":"" %></span><a href='EgovernmentDetail.aspx?id=<%#Eval("EID") %>'><%#Eval("Etitle") %></a></h5>--%>
                                     <a href='EgovernmentDetail.aspx?id=<%#Eval("FID") %>'>
                                        <p class="mui-h5 mui-ellipsis" style="float: right">
                                            <span>发件人:<%#Eval("CreateUserName") %></span>&nbsp
                                            <span>状态:
                                                <%--<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.GWType>(Eval("State")) %>--%>
                                                 <%#Eval("Completed").ToString()=="1"?"<span style='color:#FF83FA'>已归档</span>":getState(Eval("State"))%>
                                            </span>
                                        </p>
                                     </a>
                                    </div>
                                
                                </div>
                            </span>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="clear: both"></div>
            </ul>
            <ul runat="server" id="ul_null" style="text-align: center;" class="mui-table-view">
                <li class="mui-table-view-cell margin0">暂无记录</li>
            </ul>
            <wuc:PagerAPP ID="PagerAPP" runat="server" OnPageChanged="Pager_PageChanged" />
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
          <%--  <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
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
