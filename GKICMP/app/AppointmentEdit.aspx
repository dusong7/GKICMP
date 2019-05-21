<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentEdit.aspx.cs" Inherits="GKICMP.app.AppointmentEdit" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <title>场室预约</title>
    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <link href="../appcss/mui.picker.min.css" rel="stylesheet" />
    <script src="../appjs/mui.picker.min.js"></script>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_PValue" runat="server" />
        <asp:HiddenField ID="hf_begin" runat="server" />
        <asp:HiddenField ID="hf_end" runat="server" />
        <header class="mui-bar mui-bar-nav">
            <%--<a class="mui-pull-left iconfont icon-fanhui color-3 fhjt" href="javascript:history.back();"></a>--%>
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">场室预约</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="AppointmentEdit.aspx" class="mui-control-item mui-active">场室预约</a>
                    <a href="AppointmentManage.aspx" class="mui-control-item">场室管理</a>
                </div>
            </div>
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>预约场地</label>
                        <asp:TextBox runat="server" ID="txt_AID" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                        <asp:HiddenField ID="hf_AID" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>开始日期</label>
                        <div id='demo7' data-options='{"type":"datetime","customData":{},"labels":["年", "月", "日","时","分"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>结束日期</label>
                        <%--<asp:TextBox runat="server" name="shpuser" ID="txt_EndDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" placeholder="请选择"></asp:TextBox>--%>
                        <div id='demo8' data-options='{"type":"datetime","customData":{},"labels":["年", "月", "日","时","分"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%-- <div id='result1' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>预约说明</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_AppointmentDesc" placeholder="请填写说明"></asp:TextBox>
                        <asp:HiddenField ID="hf_AppointmentDesc" runat="server" />
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
    </form>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetAID",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_AID');
                var userResult = doc.getElementById('txt_AID');
                var userCustName = doc.getElementById('hf_AID');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);
            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });

    </script>

    <script>
        (function ($, doc) {
            $.init();
            var result = $('#demo7')[0];
            var result1 = $('#demo8')[0];
            var btns = $('.btn');
            btns.each(function (i, btn) {
                btn.addEventListener('tap', function () {
                    var _self = this;
                    if (_self.picker) {
                        _self.picker.show(function (rs) {
                            if (i == 0) {
                                result.innerText = rs.text;
                                document.getElementById("hf_begin").value = rs.value;
                            }
                            if (i == 1) {
                                result1.innerText = rs.text;
                                document.getElementById("hf_end").value = rs.value;
                            }
                            _self.picker.dispose();
                            _self.picker = null;

                        });
                    } else {
                        var optionsJson = this.getAttribute('data-options') || '{}';
                        var options = JSON.parse(optionsJson);
                        //var id = this.getAttribute('id');
                        _self.picker = new $.DtPicker(options);
                        //_self.picker.show(function (rs) {
                        //    _self.picker.dispose();
                        //    _self.picker = null;
                        //});
                    }

                }, false);
            });

        })(mui, document);
    </script>
</body>
</html>

