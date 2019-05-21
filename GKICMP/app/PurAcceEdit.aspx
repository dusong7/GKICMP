<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurAcceEdit.aspx.cs" Inherits="GKICMP.app.PurAcceEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>验收管理</title>
    <%--<link href="../css/mui.min.css" rel="stylesheet" />
    <link href="../css/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />--%>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.min.css" rel="stylesheet" />

    <script src="../js/editinfor.js"></script>
    <script src="../js/mui.min.js"></script>
    <%--<script src="../appjs/mui.min.js"></script>--%>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../appjs/mui.picker.min.js"></script>
    <script type="text/javascript" charset="utf-8">
        mui.init();
        $(function () {
            var iscurrent = 0;

            var uid = "";

            $(".parentli img").click(function () {
                if ($(this).parent("li").hasClass("selected")) {
                    $(this).parent("li").removeClass("selected");
                    $(this).attr("src", "images/allpic.png");
                } else {
                    $(this).parent("li").addClass("selected");
                    $(this).attr("src", "images/allinpic.png");
                }
            })

            $("#allselect span").click(function () {
                if ($(this).hasClass("select")) {
                    $(".allselect span").removeClass("select");
                    iscurrent = 0;
                } else {
                    $(".allselect span").addClass("select");
                    iscurrent = 1;
                }
                //alert(iscurrent);
                // selectoption();
            })

            $(".selectdiv li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                selectoption();
            })

            function selectoption() {
                uid = "";
                $(".selectdiv li.select").each(function () {
                    uid = uid + this.id + ",";
                    if ($(this).hasClass("select")) {
                        uid = uid + this.id + ",";
                    }
                });
            }
        })
    </script>
    <style>
        body {
            margin: 0px;
            padding: 0px;
        }

        .selectdiv .select {
            background: url(../appimages/selectinfo.png) center right no-repeat #f5faff;
        }

        .allselect {
            float: left;
            margin: 5px;
            margin-left: 10px;
        }

            .allselect span {
                float: left;
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                margin-right: 5px;
            }

        .selectdiv .selected {
            background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
        }

        .selectdiv {
            display: none;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0px;
            left: 0px;
            background: #fff;
            color: #494949;
            overflow-y: auto;
            z-index: 100;
        }

        .selectclose {
            float: right;
            display: block;
            border: 1px solid #989898;
            border-radius: 2px;
            padding: 3px 10px;
            margin: 5px;
            font-size: 14px;
        }

        .selectdiv ul, .selectdiv li {
            margin: 0px;
            list-style: none;
            padding: 0px;
        }

        .selectdiv li {
            width: 95%;
            margin: auto;
            display: block;
            box-sizing: border-box;
            border: 1px solid #dedede;
            margin-top: 10px;
            padding: 3px 10px;
            border-radius: 2px;
            cursor: pointer;
        }

            .selectdiv li span {
                float: right;
                width: 65%;
            }

        .rbl label {
            float: none;
        }

        .rbl {
            padding: 11px 0px;
            display: inline-block;
        }

            .rbl input {
                height: 13px;
                float: none !important;
                width: auto !important;
            }

        .rylist span {
            display: inline-block;
            float: left;
            margin: 9px 20px 9px 3px;
            position: relative;
        }

            .rylist span a {
                position: absolute;
                top: -10px;
                right: -15px;
                display: inline-block;
            }

        .mui-content {
            background: none;
        }

        .mui-input-group::after {
            background: none;
        }
    </style>
</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">验收管理</h1>
    </header>
    <div class="mui-content">
        <div style="padding: 10px 10px;">
            <div id="segmentedControl" class="mui-segmented-control">
                <a href="PurAcceEdit.aspx" class="mui-control-item mui-active">验收登记</a>
                <a href="PurAcceManage.aspx" class="mui-control-item">验收管理</a>
            </div>
        </div>
        <form class="mui-input-group" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:HiddenField ID="hf_begin" runat="server" />
            <asp:HiddenField runat="server" ID="hf_LID" />
            <asp:HiddenField ID="hf_Url" runat="server" />
            <asp:HiddenField ID="hf_Opinion" runat="server" />
            <div class="mui-input-row">
                <label>项目名称</label>
                <asp:TextBox runat="server" ID="txt_ProName" name="showUserPicker" placeholder="请选择项目名称"></asp:TextBox>
                <asp:HiddenField ID="hf_ProName" runat="server" />
            </div>
            <%--<div class="mui-input-row">
                <label>验收内容</label>
                <div class="righttext mui-input-clear">
                </div>
            </div>--%>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">品牌场地是否正确</label>
                <asp:CheckBox ID="cb_BrandChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">规格型号是否正确</label>
                <asp:CheckBox ID="cb_SpecificationChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">配置是否正确</label>
                <asp:CheckBox ID="cb_ConfigChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">数量是否正确</label>
                <asp:CheckBox ID="cb_CountChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">安装调试是否正常</label>
                <asp:CheckBox ID="cb_DebuggingChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">是否有保修卡</label>
                <asp:CheckBox ID="cb_GuaranteeChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">是否包装完好</label>
                <asp:CheckBox ID="cb_PackingChecked" runat="server" />
            </div>
            <div class="mui-input-row mui-checkbox">
                <label style="width: 150px;">是否签订合同</label>
                <asp:CheckBox ID="cb_ContractChecked" runat="server" Text="" />
            </div>
            <div class="mui-input-row">
                <label>综合评价</label>
                <asp:TextBox runat="server" ID="txt_Evaluate" name="showUserPicker1" placeholder="请选择综合评价"></asp:TextBox>
                <asp:HiddenField ID="hf_Evaluate" runat="server" />
            </div>
            <asp:UpdatePanel ID="up_Rate" runat="server">
                <ContentTemplate>
                    <div class="mui-input-row">
                        <label>验收时间</label>
                        <div id='demo7' runat="server" data-options='{"type":"date","customData":"","labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期"></div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mui-input-row">
                <label>附件</label>
                <div class="righttext">
                    <span class="mui-icon mui-icon-paperclip file" id="upimage">
                        <input id="upimagebtn" type="file" onchange="fj(this)" accept="image/*,capture=camera" runat="server" /><br />
                        <%--<input id="upimagebtn" type="file" onchange="fj(this)" runat="server" />--%><br />
                    </span>
                </div>
                <div id="textName" style="width: 100%; padding: 0px 15px; clear: both; line-height: 20px;">
                    <img id="show" style="display: none" src="" height="32px" width="32px" alt="" />
                </div>
                <asp:HiddenField ID="hf_file" runat="server" />
            </div>
            <div contenteditable="true" id="div_Opinion" class="multipletext" placeholder="请在此填写验收意见" runat="server"></div>
            <asp:Button ID="btn" runat="server" Style="background-color: #48bd81;" CssClass="mui-btn mui-btn-primary mui-btn-block" OnClick="btn_Click" OnClientClick='tj()' Text="提交" />
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
                var userPicker = new $.PopPicker();
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetProList",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_ProName');
                var userResult = doc.getElementById('txt_ProName');
                var userCustName = doc.getElementById('hf_ProName');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);

                var userPicker1 = new $.PopPicker();
                userPicker1.setData(
                [
                    { value: '1', text: '好' },
                    { value: '2', text: '较好' },
                    { value: '3', text: '一般' },
                    { value: '4', text: '较差' }
                ]);
                var showUserPickerButton1 = doc.getElementById('txt_Evaluate');
                var userResult1 = doc.getElementById('txt_Evaluate');
                var userCustName1 = doc.getElementById('hf_Evaluate');
                showUserPickerButton1.addEventListener('tap', function (event) {
                    userPicker1.show(function (items) {
                        userResult1.value = items[0].text;
                        userCustName1.value = items[0].value;
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
                            if (document.getElementById("hf_begin").value != "") {
                                say();
                            }
                        });
                    } else {
                        var optionsJson = this.getAttribute('data-options') || '{}';
                        var options = JSON.parse(optionsJson);
                        _self.picker = new $.DtPicker(options);
                    }

                }, false);
            });
        })(mui, document);
    </script>
</body>
</html>
<script type="text/javascript">
    function tj() {
        $("#hf_Opinion").val($("#div_Opinion").text());
    }
    function fj(obj) {
        var arr = $(obj).val().split('\\');
        $("#hf_file").val(arr[arr.length - 1]);
        var preview = document.getElementById("show");
        var file = document.querySelector('input[type=file]').files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.src = reader.result;
        }

        if (file) {
            $("#show").css('display', 'block');
            reader.readAsDataURL(file);
        } else {
            $("#show").css('display', 'none');
            preview.src = "";
        }
    }
</script>

