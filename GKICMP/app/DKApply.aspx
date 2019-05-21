<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DKApply.aspx.cs" Inherits="GKICMP.app.DKApply" %>

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
    <title>代课申请</title>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <%--<a class="mui-pull-left iconfont icon-fanhui color-3 fhjt" href="javascript:history.back();"></a>--%>
              <a class="mui-action-back mui-icon mui-icon-left-nav mui-pull-left" ></a>
            <h1 class="mui-title">代课申请</h1>
        </header>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_PValue" runat="server" />
        <div class="mui-content">
            <div class="mui-content-padded w100">
               
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>开始时间</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_BeginTime" placeholder="请选择" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    </div>
                </div>

                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>结束时间</label>
                        <asp:TextBox runat="server" name="shpuser" ID="txt_EndTime" placeholder="请选择" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    </div>
                </div>
              
                <div class="textarea-div">
                    <div class="mui-input-group hybt linght40">
                        <p>代课原因</p>
                        <asp:TextBox ID="txt_ApplyReason" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写代课原因"></asp:TextBox>
                    </div>
                </div>


                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" />
            </div>
            <nav class="mui-bar mui-bar-tab">
               <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
                <a class="mui-tab-item">
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
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET",
                    data: "method=GetDepAPP&data=js",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_Dep');
                var userResult = doc.getElementById('txt_Dep');
                var userCustName = doc.getElementById('hf_Dep');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                        document.getElementById("btn_SearchUser").click();
                    });
                }, false);


                var userPicker1 = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetSupp",
                    dataType: "json",
                    success: function (d) {
                        userPicker1.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_D');
                var userResult1 = doc.getElementById('txt_D');
                var userCustName1 = doc.getElementById('hf_D');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker1.show(function (items) {
                        userResult1.value = items[0].text;
                        userCustName1.value = items[0].value;
                    });
                }, false);

            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>

</body>
</html>

