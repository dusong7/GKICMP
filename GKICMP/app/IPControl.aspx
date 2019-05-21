<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPControl.aspx.cs" Inherits="GKICMP.app.IPControl" %>

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
    <title>报修登记</title>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 80px;
        }
    </style>

</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">广播管理</h1>
    </header>
    <div class="mui-content">

        <form class="mui-input-group" runat="server">



            <div class="mui-input-row" id="selected">
                <label>音乐库</label>
                <asp:TextBox runat="server" name="shpdep" ID="txt_Music" placeholder="请选择音乐"></asp:TextBox>
                <asp:HiddenField ID="hf_FilePath" runat="server" />
            </div>
            <%--<div class="mui-input-row" id="playMode">
                <label>播放模式</label>
                <asp:TextBox runat="server" name="shpdep" ID="txt_Mode" placeholder="请选择模式"></asp:TextBox>
                <asp:HiddenField ID="hf_Mode" runat="server" />
            </div>--%>
            <asp:Button ID="btn_Sumbit" runat="server" Text="播放" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" />
            <asp:Button ID="btn_Stop" runat="server" Text="暂停" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Stop_Click" />
            <%--  <asp:Button ID="btn_Prev" runat="server" Text="上一首" class="mui-btn mui-btn-primary mui-btn-block bgcolor"  OnClick="" />
            <asp:Button ID="btn_Next" runat="server" Text="下一首" class="mui-btn mui-btn-primary mui-btn-block bgcolor"  OnClick="" />--%>
        </form>
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
    <asp:Literal ID="ltl_User" runat="server"></asp:Literal>

    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                $.ajax({
                    url: "../ashx/IPControl.ashx",
                    cache: false, type: "GET",
                    data: "method=List",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_Music');
                var userResult = doc.getElementById('txt_Music');
                var userCustName = doc.getElementById('hf_FilePath');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);

                //var userPicker1 = new $.PopPicker();
                //userPicker1.setData(
                //    { "value": "1", "text": "单曲播放" },
                //    { "value": "2", "text": "单曲循环播放" },
                //    { "value": "3", "text": "顺序播放" },
                //    { "value": "4", "text": "循环播放" }

                //);
                //var showUserPickerButton1 = doc.getElementById('txt_Mode');
                //var userResult1 = doc.getElementById('txt_Mode');
                //var userCustName1 = doc.getElementById('hf_Mode');
                //showUserPickerButton1.addEventListener('tap', function (event) {
                //    userPicker1.show(function (items) {
                //        userResult1.value = items[0].text;
                //        userCustName1.value = items[0].value;
                //    });
                //}, false);

            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>

