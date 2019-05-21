<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveRecord.aspx.cs" Inherits="GKICMP.app.LeaveRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>备案登记</title>
    <%--<link href="../css/mui.min.css" rel="stylesheet" />
    <link href="../css/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />--%>


    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/mui.picker.min.css" rel="stylesheet" />
     <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/mui.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
   
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

                //if ($(this).parent().find("li").hasClass("noselect")) {
                //    $(this).parent().siblings("span").removeClass("select");
                //} else {
                //    $(this).parent().siblings("span").addClass("select");
                //}
                selectoption();
                //$("#dxseclet").remove();
                //$("#dxseclet").append("<span><img src='images/close.png' title='" + this.id + "'>" + this.title + "</span>");
                //var cid = this.id;
                //var state = -1;
                //var lid = document.getElementById("hf_LID").value;
                //var aresult = 0;
                //$.ajax({
                //    url: "../ashx/LeaveAuditUserHandler.ashx",
                //    cache: false,
                //    type: "GET",
                //    async: false,
                //    //data: "method=AddLeaveAuditUser&uid=" + cid + "&lid=" + lid + '&state=' + state,
                //    data: "method=AddLeaveAuditUser&uid=" + cid + "&lid=" + lid + '&state=' + state + "&iscur=" + iscurrent,
                //    dataType: "json",
                //    success: function (data) {
                //        if (data.result == "fail") {
                //            aresult = -1;
                //        }
                //        if (data.result == "same") {
                //            aresult = -2;
                //        }
                //    }
                //});
                //if (aresult == -1) {
                //    alert("系统提示：提交失败");
                //}
                //else if (aresult == -2) {
                //    alert("系统提示：此审核人已存在，请重新选择");
                //}
                //$(this).css("display", "none");
                //$("#dxc").css("display", "none");
                //document.getElementById('btn_Search').click();
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

            $(document).on('click', '#dxseclet span img', function (e) {
                $(this).parent().remove();
                $("#" + this.title).css("display", "block")
            });
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
        <h1 class="mui-title">备案管理</h1>
    </header>
    <div class="mui-content">
        <div style="padding: 10px 10px;">
            <div id="segmentedControl" class="mui-segmented-control">
                <a href="LeaveRecord.aspx" class="mui-control-item mui-active">备案登记</a>
                <a href="LeaveRecordList.aspx" class="mui-control-item">我的备案</a>
                <%--<a href="LeaveAudit.aspx" class="mui-control-item">我审批的</a>--%>
            </div>
        </div>
        <form class="mui-input-group" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:HiddenField ID="hf_begin" runat="server" />
            <asp:HiddenField ID="hf_end" runat="server" />
            <asp:HiddenField runat="server" ID="hf_LID" />
            <asp:HiddenField ID="hf_Url" runat="server" />
            <asp:HiddenField ID="hf_LeaveMark" runat="server" />
            <%--<asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />--%>
            <asp:Button ID="btn_Hqqjts" runat="server" Text="Button" OnClick="btn_Hqqjts_Click" Style="display: none" />

            <%-- <div class="mui-input-row">
                <label>选择类别</label>
                <asp:TextBox runat="server" ID="txt_LFlag" name="showUserPicker1" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_LFlag" runat="server" Value="1" />
            </div>--%>
           <%-- <div class="mui-input-row">
                <label>
                    <asp:Label ID="lbl_LType" runat="server" Text="请假类型"></asp:Label></label>
                <asp:TextBox runat="server" ID="txt_LType" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_LType" runat="server" />
            </div>--%>
            <asp:UpdatePanel ID="up_Rate" runat="server">
                <ContentTemplate>
                    <div class="mui-input-row">
                        <label>开始日期</label>
                        <div id='demo7' runat="server" data-options='{"type":"date","customData":{},"labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%--<div id='result' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                    </div>
                    <div class="mui-input-row">
                        <label>结束日期</label>
                        <div id='demo8' runat="server" data-options='{"type":"date","customData":{},"labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%-- <div id='result1' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                    </div>
                    <div class="mui-input-row">
                        <label>
                            <asp:Label ID="lbl_LeaveDays" runat="server" Text="外出天数"></asp:Label></label>
                        <asp:TextBox runat="server" ID="txt_LeaveDays" Enabled="false"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mui-input-row">
                <label>附件</label>
                <div class="righttext">
                    <span class="mui-icon mui-icon-paperclip file" id="upimage">
                        <input id="upimagebtn" type="file" onchange="fj(this)" accept="image/*,capture=camera" runat="server" /><br />
                    </span>
                </div>
                <div id="textName" style="width: 100%; padding: 0px 15px; clear: both; line-height: 20px;">
                    <img id="show" style="display: none" src="" height="32px" width="32px" alt="" />
                </div>
                <asp:HiddenField ID="hf_file" runat="server" />
            </div>
            <div contenteditable="true" id="div_LeaveMark" class="multipletext" placeholder="请在此填写事由(必填)" runat="server"></div>
            <asp:Button ID="btn" runat="server" Style="background-color: #48bd81;" CssClass="mui-btn mui-btn-primary mui-btn-block" OnClick="btn_Sumbit_Click" OnClientClick='tj()' Text="提交" />
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
                            if (document.getElementById("hf_begin").value != "" && document.getElementById("hf_end").value != "") {
                                say();
                            }
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
    function show(flag) {
        $("#btn_Search").click();
    }
    function say() {
        $("#btn_Hqqjts").click();
    }
    function tj() {
        $("#hf_LeaveMark").val($("#div_LeaveMark").text());
    }
    function fj(obj) {
        var arr = $(obj).val().split('\\');
        //document.getElementById('textName').innerHTML = arr[arr.length - 1];
        $("#hf_file").val(arr[arr.length - 1]);
        //var preview = document.querySelector('img');
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

