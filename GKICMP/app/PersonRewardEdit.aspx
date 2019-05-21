<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonRewardEdit.aspx.cs" Inherits="GKICMP.app.PersonRewardEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>获奖管理</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <script src="../js/mui.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <link href="../appcss/mui.picker.min.css" rel="stylesheet" />
    <script src="../appjs/mui.picker.min.js"></script>
</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">获奖管理</h1>
    </header>
    <div class="mui-content">
        <div style="padding: 10px 10px;">
            <div id="segmentedControl" class="mui-segmented-control">
                <a href="PersonRewardEdit.aspx" class="mui-control-item mui-active">获奖添加</a>
                <a href="PersonRewardManage.aspx" class="mui-control-item">我的获奖</a>
            </div>
        </div>
        <form class="mui-input-group" runat="server">
            <asp:HiddenField ID="hf_begin" runat="server" />

             <div class="mui-input-row">
                <label>奖励名称</label>
                <asp:TextBox runat="server" ID="txt_RewardName" placeholder="请填写奖励名称"></asp:TextBox>
            </div>
             <div class="mui-input-row">
                <label>授奖单位</label>
                <asp:TextBox runat="server" ID="txt_Lunit" placeholder="请填写授奖单位"></asp:TextBox>
            </div>
            <div class="mui-input-row">
                <label>奖励类别</label>
                <asp:TextBox runat="server" ID="txt_RewardType" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_RewardType" runat="server" />
            </div>
           <div class="mui-input-row">
                <label>奖励级别</label>
                <asp:TextBox runat="server" ID="txt_RGrade" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_RGrade" runat="server" />
            </div>
            <div class="mui-input-row">
                <label>获奖年月</label>
                <div id='demo7' runat="server" data-options='{"type":"date","labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期 ..."></div>
            </div>
            <div class="mui-input-row">
                <label>本人排名</label>
                <asp:TextBox runat="server" ID="txt_Ranking" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_Ranking" runat="server" />
            </div>
            <div class="mui-input-row">
                <label>图片</label>
                <div class="righttext">
                    <span class="mui-icon mui-icon-paperclip file" id="upimage">
                        <input id="upimagebtn" type="file" onchange="fj(this)" accept="image/*,capture=camera" runat="server" /></span>
                </div>

                <div id="textName" style="width: 100%; padding: 0px 15px; clear: both; line-height: 20px;">
                   <%--  <img id="show" style="display: none" src="" height="32px" width="32px" alt="" />--%>

                </div>
                
                <asp:HiddenField ID="hf_file" runat="server" />

            </div>
            <asp:Button ID="btn" runat="server" Style="background-color: #48bd81;" CssClass="mui-btn mui-btn-primary mui-btn-block" OnClick="btn_Sumbit_Click" Text="提交" />
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
        <%--      <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
        <a href="AppMain.aspx" class="mui-tab-item  mui-active">
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
                var RewardTypeuserPicker = new $.PopPicker();
                RewardTypeuserPicker.setData(
                [
                 { value: '1', text: '特等' },
                 { value: '2', text: '一等' },
                 { value: '3', text: '二等' },
                 { value: '4', text: '三等' },
                 { value: '5', text: '四等' },
                 { value: '6', text: '未评等级' },
                 { value: '7', text: '其他' },
                ]);
                var RewardType = doc.getElementById('txt_RewardType');
                var RewardTypeResult = doc.getElementById('txt_RewardType');
                var RewardTypeuserCustName = doc.getElementById('hf_RewardType');
                RewardType.addEventListener('tap', function (event) {
                    RewardTypeuserPicker.show(function (items) {
                        RewardTypeResult.value = items[0].text;
                        RewardTypeuserCustName.value = items[0].value;
                    });
                }, false);

                var RGradeuserPicker = new $.PopPicker();
                RGradeuserPicker.setData(
              [
               { value: '1', text: '国家级' },
               { value: '2', text: '教育部' },
               { value: '3', text: '中央其他部委' },
               { value: '4', text: '省级或自治区直辖市级' },
               { value: '5', text: '省教育行政部门级' },
               { value: '6', text: '省级其他部门' },
               { value: '7', text: '地市州级' },
               { value: '8', text: '地级教育行政部门级' },
               { value: '9', text: '地级其他部门' },
               { value: '10', text: '县级' },
               { value: '11', text: '县级教育行政部门' },
               { value: '12', text: '县级其他部门' },
               { value: '13', text: '乡镇级' },
               { value: '14', text: '学校级' },
               { value: '15', text: '国际级' },
               { value: '16', text: '其他' },
              ]);
                var RGrade = doc.getElementById('txt_RGrade');
                var RGradeuserResult = doc.getElementById('txt_RGrade');
                var RGradeuserCustName = doc.getElementById('hf_RGrade');
                RGrade.addEventListener('tap', function (event) {
                    RGradeuserPicker.show(function (items) {
                        RGradeuserResult.value = items[0].text;
                        RGradeuserCustName.value = items[0].value;
                    });
                }, false);

                var RankinguserPicker = new $.PopPicker();
                RankinguserPicker.setData(
              [
               { value: '0', text: '一' },
               { value: '1', text: '二' },
               { value: '2', text: '三' },
               { value: '3', text: '无' },
               { value: '4', text: '其他' },
              ]);
                var Ranking = doc.getElementById('txt_Ranking');
                var RankinguserResult = doc.getElementById('txt_Ranking');
                var RankinguserCustName = doc.getElementById('hf_Ranking');
                Ranking.addEventListener('tap', function (event) {
                    RankinguserPicker.show(function (items) {
                        RankinguserResult.value = items[0].text;
                        RankinguserCustName.value = items[0].value;
                    });
                }, false);
            });
            var result = $('#demo7')[0];
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
<script type="text/javascript">
    function fj(obj) {
        var arr = $(obj).val().split('\\');
        document.getElementById('textName').innerHTML = arr[arr.length - 1];
        $("#hf_file").val(arr[arr.length - 1]);
    }
</script>
