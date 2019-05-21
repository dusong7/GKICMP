<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeEdit.aspx.cs" Inherits="GKICMP.app.OverTimeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>我的加班</title>
    <%--<link href="../css/mui.min.css" rel="stylesheet" />
    <link href="../css/new_file.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />--%>
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
    <style>
        body {
            margin: 0px;
            padding: 0px;
        }

        h4, h5 {
            text-align: center;
        }

        .mui-content-padded {
            margin: 10px 0px;
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
            z-index: 999;
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

                .allselect span.selected {
                    background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
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

        .selectdiv .parentli {
            border-bottom: 1px solid #DDDDDD;
            padding: 10px 10px;
        }

            .selectdiv .parentli.selected ul {
                display: block;
            }

            .selectdiv .parentli span.selected {
                background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
            }

            .selectdiv .parentli ul {
                display: none;
            }

            .selectdiv .parentli span {
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli img {
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli li {
                width: 70px;
                display: inline-block;
                border: 1px solid #dedede;
                margin-top: 10px;
                padding: 3px 5px;
                border-radius: 2px;
            }

                .selectdiv .parentli li.select {
                    background: url(../appimages/selectinfo.png) 50px center no-repeat #f5faff;
                    border-color: #1296db;
                    color: #1296db;
                }
    </style>
    <style>
        .allselect1 {
            float: left;
            margin: 5px;
            margin-left: 10px;
        }

            .allselect1 span {
                float: left;
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                margin-right: 5px;
            }

                .allselect1 span.selected {
                    background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
                }

        .selectdiv1 {
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

            .selectdiv1 li.select {
                background: url(../appimages/selectinfo.png) center right no-repeat #f5faff;
            }

            .selectdiv1 span.select {
                background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
            }

        .selectclose1 {
            float: right;
            display: block;
            border: 1px solid #989898;
            border-radius: 2px;
            padding: 3px 10px;
            margin: 5px;
            font-size: 14px;
        }

        .selectdiv1 ul, .selectdiv1 li {
            margin: 0px;
            list-style: none;
            padding: 0px;
        }

        .selectdiv1 li {
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

            .selectdiv1 li span {
                float: right;
                width: 65%;
            }

        .rbl1 label {
            float: none;
        }

        .rbl1 {
            padding: 11px 0px;
            display: inline-block;
        }

            .rbl1 input {
                height: 13px;
                float: none !important;
                width: auto !important;
            }

        .rylist1 span {
            display: inline-block;
            float: left;
            margin: 9px 20px 9px 3px;
            position: relative;
        }

            .rylist1 span a {
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

    <script type="text/javascript" charset="utf-8">
        mui.init();
        $(function () {
            var iscurrent = 0;
            var uid = '';
            $("#adduser").click(function () {
                var lid = document.getElementById("hf_LID").value;
                var a = document.getElementById("hf_begin").value;
                // var b = document.getElementById("hf_end").value;
                if (a == "") {
                    alert("请将上面信息填写完整后选择审核人");
                    return false;
                }
                else {

                    $("#dxc1").css("display", "block");
                }
            })

            $("#selectclose1").click(function () {
                //alert(uid);
                var cid = uid;
                var state = -1;
                var lid = document.getElementById("hf_LID").value;
                var aresult = 0;
                $.ajax({
                    url: "../ashx/LeaveAuditUserHandler.ashx",
                    cache: false,
                    type: "GET",
                    async: false,
                    //data: "method=AddLeaveAuditUser&uid=" + cid + "&lid=" + lid + '&state=' + state,
                    data: "method=AddLeaveAuditUser&uid=" + cid + "&lid=" + lid + '&state=' + state + "&iscur=" + iscurrent,
                    dataType: "json",
                    success: function (data) {
                        if (data.result == "fail") {
                            aresult = -1;
                        }
                        if (data.result == "same") {
                            aresult = -2;
                        }
                    }
                });
                if (aresult == -1) {
                    alert("系统提示：提交失败");
                }
                else if (aresult == -2) {
                    alert("系统提示：此审核人已存在，请重新选择");
                }

                $("#dxc1").css("display", "none");
                document.getElementById('btn_Search').click();


            })

            $(".parentli1 img").click(function () {
                if ($(this).parent("li").hasClass("selected")) {
                    $(this).parent("li").removeClass("selected");
                    $(this).attr("src", "images/allpic.png");
                } else {
                    $(this).parent("li").addClass("selected");
                    $(this).attr("src", "images/allinpic.png");
                }
            })
            $(".selectdiv1 li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("selected");
                } else {
                    $(this).parent().siblings("span").addClass("selected");
                }
                selectoption1();
            })
            $("#allselect1 span").click(function () {
                if ($(this).hasClass("select")) {
                    $(".allselect1 span").removeClass("select");
                    iscurrent = 0;
                } else {
                    $(".allselect1 span").addClass("select");
                    iscurrent = 1;
                }
                //alert(iscurrent);
                // selectoption();
            })
            function selectoption1() {
                //$("#hf_UID").val('');
                //$("#dxseclet").val('');
                //$("#dxseclet").html('');
                uid = "";
                $(".selectdiv1 li.select").each(function () {

                    uid = uid + this.id + ",";
                    if ($(this).hasClass("select")) {
                        uid = uid + this.id + ",";
                        //$("#dxseclet").val($("#dxseclet").val() + this.title + ",");
                        //$("#dxseclet").html($("#dxseclet").html() + this.title + ",");
                    }
                });
            }

            $(document).on('click', '#dxseclet1 span img', function (e) {
                $(this).parent().remove();
                $("#" + this.title).css("display", "block")
            });
        })
    </script>
    <script>
        $(function () {
            $(".parentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#dxseclet").click(function () {
                $("#dxc").css("display", "block");
            })

            $("#selectclose").click(function () {
                $("#dxc").css("display", "none");
            })

            $(".parentli img").click(function () {
                if ($(this).parent("li").hasClass("selected")) {
                    $(this).parent("li").removeClass("selected");
                    $(this).attr("src", "../appimages/allpic.png");
                } else {
                    $(this).parent("li").addClass("selected");
                    $(this).attr("src", "../appimages/allinpic.png");
                }
            })
            $("#allselect span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(".parentli span").removeClass("selected");
                    $(".parentli li").removeClass("select");
                    $(".parentli li").addClass("noselect");
                } else {
                    $(this).addClass("selected");
                    $(".parentli span").addClass("selected");
                    $(".parentli li").addClass("select");
                    $(".parentli li").removeClass("noselect");
                }
                selectoption();
            })

            $(".parentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("selected");
                } else {
                    $(this).parent().siblings("span").addClass("selected");
                }
                selectoption();
            })

            $(".parentli span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("selected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                selectoption();
            })

            function selectoption() {
                $("#hf_UID").val('');
                //$("#dxseclet").val('');
                $("#dxseclet").html('');
                $(".parentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_UID").val($("#hf_UID").val() + this.id + ",");
                        //$("#dxseclet").val($("#dxseclet").val() + this.title + ",");
                        $("#dxseclet").html($("#dxseclet").html() + this.title + ",");
                        $("#hf_UIDNames").val($("#dxseclet").html());
                    }
                });
                if ($("#dxc .parentli").find("li").hasClass("noselect")) {
                    $("#allselect span").removeClass("selected");
                } else {
                    $("#allselect span").addClass("selected");
                }
            }

        })
    </script>

</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">加班管理</h1>
    </header>
    <div class="mui-content">
        <div style="padding: 10px 10px;">
            <div id="segmentedControl" class="mui-segmented-control">
                <a href="OverTimeEdit.aspx" class="mui-control-item mui-active">加班申请</a>
                <a href="OverTime.aspx" class="mui-control-item">我发起的</a>
                <a href="OverTimeAudit.aspx" class="mui-control-item">我审批的</a>

            </div>
        </div>
        <form class="mui-input-group" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:HiddenField ID="hf_UID" runat="server" />
            <asp:HiddenField ID="hf_UIDNames" runat="server" />
            <asp:HiddenField ID="hf_begin" runat="server" />
            <asp:HiddenField ID="hf_end" runat="server" />
            <asp:HiddenField runat="server" ID="hf_LID" />
            <asp:HiddenField ID="hf_Url" runat="server" />
            <asp:HiddenField ID="hf_LeaveMark" runat="server" />
            <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
            <asp:Button ID="btn_Hqqjts" runat="server" Text="Button" OnClick="btn_Hqqjts_Click" Style="display: none" />

            <%-- <div class="mui-input-row">
                <label>选择类别</label>
                <asp:TextBox runat="server" ID="txt_LFlag" name="showUserPicker1" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_LFlag" runat="server" Value="1" />
            </div>--%>
            <div class="mui-input-row">
                <label>
                    <asp:Label ID="lbl_LType" runat="server" Text="加班类型"></asp:Label></label>
                <asp:TextBox runat="server" ID="txt_OType" name="showUserPicker" placeholder="请选择"></asp:TextBox>
                <asp:HiddenField ID="hf_OType" runat="server" />
            </div>
            <asp:UpdatePanel ID="up_Rate" runat="server">
                <ContentTemplate>
                    <div class="mui-input-row">
                        <label>加班日期</label>
                        <div id='demo7' runat="server" data-options='{"type":"date","labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%--<div id='result' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                    </div>
                    <%-- <div class="mui-input-row">
                        <label>结束日期</label>
                        <div id='demo8' runat="server" data-options='{"type":"datetime","customData":{},"labels":["年", "月", "日", "时","分"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%-- <div id='result1' runat="server" style="margin-top: 8px;" class="ui-alert"></div>
                    </div>--%>
                    <div class="mui-input-row">
                        <label>
                            <asp:Label ID="lbl_LeaveDays" runat="server" Text="加班时长"></asp:Label></label>
                        <asp:TextBox runat="server" ID="txt_ODays"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="mui-input-group linght40">
                <div class="mui-input-row">
                    <label>参与人</label>
                    <div class="righttext mui-input-clear" id="dxseclet" runat="server" name="dxseclet" placeholder="点击此处选择参与人"></div>
                    <div class="selectdiv" id="dxc">
                        <div style="height: 30px">
                            <div class="allselect" id="allselect"><span></span>全选</div>
                            <span class="selectclose" id="selectclose">确定</span>
                        </div>
                        <ul>
                            <asp:Repeater ID="rpmodule" runat="server" OnItemDataBound="rpmodule_ItemDataBound">
                                <ItemTemplate>
                                    <li class='<%#Container.ItemIndex==0?"parentli selected":"parentli" %>'>
                                        <img src='<%#Container.ItemIndex==0?"../appimages/allinpic.png":"../appimages/allpic.png"%>' /><span></span><%#Eval("DepName") %>
                                        <asp:HiddenField runat="server" ID="hf_DID" Value='<%#Eval("DID") %>' />
                                        <ul>
                                            <asp:Repeater ID="rpnextModule" runat="server">
                                                <ItemTemplate>
                                                    <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="mui-input-group">
                <div class="mui-input-row" style="height: auto">
                    <label>
                        <asp:Label ID="lbl_sh" runat="server" Text="审核人"></asp:Label></label>
                    <div style="float: left; width: 65%" class="rylist">
                        <asp:Repeater ID="rp_List" runat="server">
                            <ItemTemplate>
                                <span><%#Eval("AuditName") %>
                                    <asp:LinkButton ID="lbtn_Delete" OnClientClick="return  confirm('您确认删除选中的信息吗？');" CommandArgument='<%#Eval("LAID")%>' runat="server" OnClick="lbtn_Delete_Click"><img src="../images/del.png" /></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal runat="server" ID="ltl_Name" Text="暂无人员"></asp:Literal>
                        <img src="../appimages/adduser.png" id="adduser" style="margin-left: 20px; margin-top: 5px" />
                    </div>

                    <div class="selectdiv1" id="dxc1">

                        <div style="height: 30px">
                            <div class="allselect1" id="allselect1"><span></span>是否关联</div>
                            <span class="selectclose" id="selectclose1">确定</span>
                        </div>
                        <asp:Repeater ID="rp_listshr" runat="server">
                            <ItemTemplate>
                                <ul>
                                    <li id='<%#Eval("UID") %>'><%#Eval("RealName") %><span><%#Eval("DepName") %></span><div style="clear: both"></div>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <div contenteditable="true" id="div_OMark" class="multipletext" placeholder="请在此填写事由" runat="server"></div>
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
                var userPicker = new $.PopPicker();
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetJB",
                    dataType: "json",
                    success: function (d) {
                        //alert(JSON.stringify(d));
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_OType');
                var userResult = doc.getElementById('txt_OType');
                var userCustName = doc.getElementById('hf_OType');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);
            });
            var result = $('#demo7')[0];
            //var result1 = $('#demo8')[0];
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
                            //if (i == 1) {
                            //    result1.innerText = rs.text;
                            //    document.getElementById("hf_end").value = rs.value;
                            //}
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
    function show(flag) {
        $("#btn_Search").click();
    }
    function say() {
        $("#btn_Hqqjts").click();
    }
    function tj() {
        $("#hf_LeaveMark").val($("#div_OMark").text());
    }
    function fj(obj) {
        var arr = $(obj).val().split('\\');
        document.getElementById('textName').innerHTML = arr[arr.length - 1];
        $("#hf_file").val(arr[arr.length - 1]);
    }
</script>

