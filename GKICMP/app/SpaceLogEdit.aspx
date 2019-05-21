<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpaceLogEdit.aspx.cs" Inherits="GKICMP.app.SpaceLogEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>日志</title>
    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/bootstrap.css" rel="stylesheet" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/jquery.easyui.mobile.js"></script>
    <link href="../appcss/style.css" rel="stylesheet" />
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
           <%-- <a class=" iconfont icon-fanhui color-3 fhjt mui-pull-left" href="AfterSaleManage.aspx"></a>--%>
             <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title"><asp:Label ID="lbl_ActName" runat="server" Text=""></asp:Label></h1>
        </header>

        
        <div class="mui-col-xs-11" style="margin-top:50px;">
           <%-- <h4 style="text-align: center; line-height: 1; font-size: 10px; color: #929292;">活动管理员：
                    <asp:Label ID="lbl_CreateUser" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                录入时间：  
                    <asp:Label runat="server" ID="lbl_CreateDate"></asp:Label>
            </h4>--%>
            <h4 style="text-align: center; line-height: 1; font-size: 10px; color: #929292;">
                指导教师：
                    <asp:Label ID="lbl_Counselor" runat="server"></asp:Label>&nbsp;&nbsp;
                活动类型：
                <asp:Label runat="server" ID="lbl_ActType"></asp:Label>
            </h4>
            <div style="text-align: center; line-height: 2; font-size: 14px; color: #e60d0d">
                报名截止日期：
                <asp:Label runat="server" ID="lbl_ClosingDate"></asp:Label>
            </div>
            <div style="line-height: 2;text-align:center;">
                <asp:Label ID="lbl_ActContent" runat="server"></asp:Label>
            </div>
        </div>


        <div class="mui-content">
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>日志标题：</label>
                        <asp:TextBox runat="server" ID="txt_LogTitle" CssClass="mui-icon-location" placeholder="请填写日志标题"></asp:TextBox>
                    </div>
                </div>
                <div class="textarea-div">
                    <div class="mui-input-group hybt linght40">
                        <p>日志内容：</p>
                        <asp:TextBox ID="txt_Content" runat="server" Rows="3" placeholder="请在此填写日志内容" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" />
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
            <%--   <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>

         <script type="text/javascript" charset="utf-8">
           mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        </script>

    </form>
</body>
</html>
