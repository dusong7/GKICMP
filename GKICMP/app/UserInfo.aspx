<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="GKICMP.app.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>个人信息</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />    
    <link href="../appcss/mui.picker.min.css" rel="stylesheet" />
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <script src="../appjs/mui.picker.min.js"></script>
    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <header class="mui-bar mui-bar-nav">
            <a class=" iconfont icon-fanhui color-3 fhjt mui-pull-left" href="javascript:history.back();"></a>
            <h1 class="mui-title">个人信息</h1>
        </header>
        <div class="mui-content">
            <div class="mui-content-padded w100">

                <div class="mui-input-group hybt linght40">
                    <div class="mui-input-row">
                        <label style="font-weight: bold;">联系方式</label>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>帐号切换</label>
                        <asp:TextBox ID="txt_UserID" runat="server" name="showUserPicker" placeholder="请选择" CssClass="mui-icon-location"></asp:TextBox>
                        <asp:HiddenField ID="hf_UserID" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>姓名</label>
                        <asp:TextBox ID="txt_RealName" runat="server" CssClass="mui-icon-location"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>手机号码</label>
                        <asp:TextBox ID="txt_CellPhone" runat="server" CssClass="mui-icon-location"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>家庭住址</label>
                        <asp:TextBox ID="txt_Address" runat="server" CssClass="mui-icon-location" datatype="*1-100"
                            nullmsg="请填写家庭住址" placeholder="请在此填写家庭住址"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>邮箱</label>
                        <asp:TextBox ID="txt_MailNum" runat="server" CssClass="mui-icon-location" datatype="*1-50"
                            nullmsg="请填写邮箱" placeholder="请在此填写邮箱"></asp:TextBox>
                    </div>
                </div>

                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>办公座机</label>
                        <asp:TextBox ID="txt_CompanyNum" runat="server" CssClass="mui-icon-location" placeholder="请在此填写办公座机"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>微信号</label>
                        <asp:TextBox ID="txt_WeiNum" runat="server" CssClass="mui-icon-location" placeholder="请在此填写微信号"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>QQ号码</label>
                        <asp:TextBox ID="txt_QQNum" runat="server" CssClass="mui-icon-location" placeholder="请在此填写QQ号码"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group hybt linght40">
                    <div class="mui-input-row" style="font-weight: bold; color: #999999;">
                        <p style="padding: 0px 15px; margin-bottom: 0px">（注：如不需要修改密码请不要填写以下选项）</p>
                    </div>
                </div>

                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>原密码</label>
                        <asp:TextBox ID="txt_OldPwd" runat="server" placeholder="请在此填写原密码" CssClass="mui-icon-location" MaxLength="30" TextMode="Password"></asp:TextBox>
                        <asp:HiddenField ID="hf_OldPwd" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>新密码</label>
                        <asp:TextBox ID="txt_SysPwd" runat="server" placeholder="请在此填写密码" CssClass="mui-icon-location" TextMode="Password" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>重复密码</label>
                        <asp:TextBox ID="txt_AgainPwd" runat="server" placeholder="请在此填写重复密码" CssClass="mui-icon-location" MaxLength="30" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" OnClick="btn_Sumbit_Click" CssClass="mui-btn mui-btn-primary mui-btn-block bgcolor" />
                <asp:Button ID="btn_UChange" runat="server"  OnClick="btn_UChange_Click" style="display:none;" CssClass="mui-btn mui-btn-primary mui-btn-block bgcolor" />

            </div>
        </div>

        <nav class="mui-bar mui-bar-tab">
            <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a href="UserInfo.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>
            <%--  <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item  ">
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
        <script>
            (function ($, doc) {
                $.init();
                $.ready(function () {
                    var userPicker = new $.PopPicker();
                    $.ajax({
                        url: "../ashx/GetDataByApp.ashx",
                        cache: false, type: "GET",
                        data: "method=GetUList",
                        dataType: "json",
                        success: function (d) {
                            //alert(JSON.stringify(d));
                            userPicker.setData(
                            d.data
                            );
                        },
                        error: function () { alert("查询出错，请稍候再试"); }
                    });
                    var showUserPickerButton = doc.getElementById('txt_UserID');
                    var userResult = doc.getElementById('txt_UserID');
                    var userCustName = doc.getElementById('hf_UserID');
                    showUserPickerButton.addEventListener('tap', function (event) {
                        userPicker.show(function (items) {
                            userResult.value = items[0].text;
                            userCustName.value = items[0].value;
                            //$("#btn_UChange").click();
                            document.getElementById("btn_UChange").click()
                        });
                    }, false);
                });
            })(mui, document);

        </script>
    </form>
</body>
</html>
