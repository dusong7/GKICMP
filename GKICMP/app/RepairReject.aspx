<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairReject.aspx.cs" Inherits="GKICMP.app.RepairReject" %>

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
    <title>请假审核</title>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">
                <asp:Label ID="lbl_title" runat="server"></asp:Label></h1>
        </header>
        <div class="mui-content">
            <div class="mui-content-padded w100">
                
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>驳回意见</label>
                        <asp:TextBox ID="txt_AuditMark" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写驳回意见"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" />
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
        </div>
        <asp:Literal ID="ltl_User" runat="server"></asp:Literal>
    </form>
    <script>
        //(function ($, doc) {
        //    $.init();
        //    $.ready(function () {
        //        var userPicker = new $.PopPicker();
        //        // userPicker.setData([]);

        //        userPicker.setData(
        //        [
        //            { value: '2', text: '通过' },
        //            { value: '3', text: '不通过' }
        //        ]
        //    );
        //        var showUserPickerButton = doc.getElementById('txt_AuditResult');
        //        var userResult = doc.getElementById('txt_AuditResult');
        //        var userCustName = doc.getElementById('hf_AuditResult');
        //        showUserPickerButton.addEventListener('tap', function (event) {
        //            userPicker.show(function (items) {
        //                userResult.value = items[0].text;
        //                userCustName.value = items[0].value;
        //            });
        //        }, false);

        //    });
        //})(mui, document);
        //mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>


