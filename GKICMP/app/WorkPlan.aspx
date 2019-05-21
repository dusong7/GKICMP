<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlan.aspx.cs" Inherits="GKICMP.app.WorkPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />

    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
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
    <title>写计划</title>
    <%--    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />--%>
    <script src="../js/oa_iconfont.js"></script>
    <%--<script src="../js/jquery-1.11.0.min.js"></script>--%>

    <style>
        body {
            margin: 0px;
            padding: 0px;
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

        .mui-content-padded {
            margin-top: 0px;
        }

        .mui-checkbox input[type=checkbox] {
            display: inline-block;
            position: relative;
        }

        .mui-checkbox.mui-left label {
            padding: 10px 25px;
            width: 170px;
        }
        /*-----------新增内容-------------------*/
        .mui-input-group:before {
            background: #fff !important;
        }

        .wadd {
            color: #48bd81;
            text-align: center;
            line-height: 40px;
        }

            .wadd span {
                font-size: 20px;
            }

        .mui-input-row {
            position: relative;
        }

        .wdel {
            position: absolute;
            display: block;
            color: #48bd81;
            border-radius: 5px;
            right: 5px;
            top: 7px;
            text-align: center;
            font-size: 14px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('.mui-content-padded').on('click', '.wadd', function () {
                var txt1 = "<label>内容</label><textarea name='txt_ExamName' rows='1' cols='20'  placeholder='请填写单条内容'></textarea><span class='wdel'>删除</span>";
                var txt2 = "<div class='mui-input-group linght40'><div class='mui-input-row'><div class='wadd'><span>+</span> 新增内容</div></div></div>";
                $(this).after(txt1);
                $(this).parent().parent().after(txt2);
                $(this).remove();
            })
            $('.mui-content-padded').on('click', '.wdel', function () {
                if (confirm("确定删除内容")) {
                    $(this).parent().parent().remove();
                }
            })
        })
        $(function () {
            //获取部门
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET", async: false,
                data: "method=GetDepAPP&data=js",
                dataType: "json",
                success: function (d) {
                    if (d.result == "true") {
                        var item1 = "";
                        for (var i = 0; i < d.data.length; i++) {

                            item1 += "  <option value=\"" + d.data[i].value + "\">" + d.data[i].text + "</option>";
                        }
                        $("#dep").html(item1);
                        GetUserByDep();
                    }
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $('#dep').change(function () {
                GetUserByDep();
            })
            //获取人员
            function GetUserByDep() {
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET", async: false,
                    data: "method=GetUserByDep&dep=" + $("#dep").val(),
                    dataType: "json",
                    success: function (d) {
                        if (d.result == "true") {
                            var item1 = "";
                            for (var i = 0; i < d.data.length; i++) {

                                item1 += "  <option value=\"" + d.data[i].id + "\">" + d.data[i].text + "</option>";
                            }
                            $("#DutyUser").html(item1);
                        }
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
            }


            var all = $("#hf_UID").val();
            if (all == '0') {
                $(".parentli li").each(function () {
                    var a = this.innerText;
                    if (this.id == "0") {
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
                    }
                    else {
                        // alert(1);
                    }
                })


                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("selected");
                } else {
                    $(this).parent().siblings("span").addClass("selected");
                }
                $(this).parent("li").hasClass("selected")
                $("#dxseclet").val("全体人员");
                $("#hf_AllUsersText").val($("#dxseclet").val());
            }
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
                if ($(this))
                    selectoption();
            })
            function selectoption() {
                $("#hf_UID").val('');
                $("#dxseclet").val('');
                $(".parentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_UID").val($("#hf_UID").val() + this.id + ",");
                        //$("#hf_AllUsersText").val($("#dxseclet").val() );
                        //$("#txt_SDate").val();
                        $("#dxseclet").val($("#dxseclet").val() + this.title + ",");
                        $("#hf_AllUsersText").val($("#dxseclet").val());
                    }
                });
                if ($("#dxc .parentli").find("li").hasClass("noselect")) {
                    $("#allselect span").removeClass("selected");
                } else {
                    $("#allselect span").addClass("selected");
                }
            }


            if ($("#cb_IsWeb").is(":checked"))
            { document.getElementById("show").style.display = "block"; }
            else {
                document.getElementById("show").style.display = "none";
            };
            $("#cb_IsWeb").change(function () {
                if ($(this).is(":checked"))
                { document.getElementById("show").style.display = "block"; }
                else
                { document.getElementById("show").style.display = "none"; }
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_SelectedText" runat="server" />
        <asp:HiddenField ID="hf_UID" runat="server" />
        <asp:HiddenField ID="hf_AllUsersText" runat="server" />
        <asp:HiddenField ID="hf_begin" runat="server" />
        <asp:HiddenField ID="hf_end" runat="server" />
        <asp:HiddenField ID="hf_nr" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">周计划</h1>
        </header>
        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="WorkPlanList.aspx" class="mui-control-item ">读计划</a>
                    <a href="WorkPlan.aspx" class="mui-control-item mui-active">写计划</a>
                </div>
            </div>
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>学年度</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_EYear" placeholder="请填写学年度"></asp:TextBox>
                        <asp:HiddenField ID="hf_AID" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>学期</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_Term" placeholder="请选择学期"></asp:TextBox>
                        <asp:HiddenField ID="hf_Term" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周次</label>
                        <asp:TextBox runat="server" ID="txt_WeekNum" placeholder="请填写工作周"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周一</label>
                        <asp:TextBox TextMode="MultiLine" runat="server" MaxLength="200" Rows="1" placeholder="请填写单条内容"></asp:TextBox>
                    </div>
                </div>
                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周二</label>
                        <asp:TextBox TextMode="MultiLine" runat="server" MaxLength="200" Rows="1" placeholder="请填写单条内容"></asp:TextBox>
                    </div>
                </div>
                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周三</label>
                        <asp:TextBox TextMode="MultiLine" runat="server" MaxLength="200" Rows="1" placeholder="请填写单条内容"></asp:TextBox>
                    </div>
                </div>
                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周四</label>
                        <asp:TextBox TextMode="MultiLine" runat="server" MaxLength="200" Rows="1" placeholder="请填写单条内容"></asp:TextBox>
                    </div>
                </div>
                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>周五</label>
                        <asp:TextBox TextMode="MultiLine" runat="server" MaxLength="200" Rows="1" placeholder="请填写单条内容"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <div class="wadd">
                            <span>+</span>
                            新增内容
                        </div>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>部门</label>
                        <select id="dep"></select>
                        <%-- <asp:TextBox runat="server" name="shpdep" ID="txt_DepID" placeholder="请选择部门"></asp:TextBox>--%>
                        <asp:HiddenField ID="hf_DepID" runat="server" />
                       <%-- <asp:Button ID="btn_Serach" Style="display: none" OnClick="btn_Serach_Click" runat="server" />--%>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>责任人</label>
                        <select id="DutyUser"></select>
                        <%--<asp:TextBox runat="server" name="shpdep" ID="txt_DutyUser" placeholder="请选择责任人"></asp:TextBox>--%>
                        <asp:HiddenField ID="hf_DutyUser" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>参与人</label>
                        <input type="text" id="dxseclet" name="dxseclet" placeholder="点击此处选择参与人" />
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
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>开始日期</label>
                        <div id='demo7' data-options='{"type":"date","customData":{},"labels":["年", "月", "日"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>结束日期</label>
                        <%--<asp:TextBox runat="server" name="shpuser" ID="txt_EndDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" placeholder="请选择"></asp:TextBox>--%>
                        <div id='demo8' data-options='{"type":"date","customData":{},"labels":["年", "月", "日", "时段"]}' class="righttext btn" placeholder="选择日期 ..."></div>
                        <%-- <div id='result1' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row mui-checkbox mui-left" style="text-align: center">
                        <%--<asp:RadioButton ID="cb_IsWeb" Text="是否同步到网站" runat="server" />--%>
                        <asp:CheckBox ID="cb_IsWeb" runat="server" Text="是否同步到网站" />
                    </div>
                </div>
                <div class="mui-input-group linght40" id="show" style="display: none">
                    <div class="mui-input-row">
                        <label>显示栏目</label>
                        <%--<asp:TextBox runat="server" name="shpuser" ID="txt_EndDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" placeholder="请选择"></asp:TextBox>--%>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_Menu" placeholder="请选择栏目"></asp:TextBox>
                        <%-- <div id='result1' runat="server" style="margin-top: 8px;" class="ui-alert"></div>--%>
                        <asp:HiddenField ID="hf_Menu" runat="server" />
                    </div>
                </div>


                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClientClick="return check()" OnClick="btn_Sumbit_Click" />
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
        <asp:Literal ID="ltl_DutyUser" runat="server"></asp:Literal>
    </form>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);
                //$.ajax({
                //    url: "../ashx/GetBaseDate.ashx",
                //    cache: false, type: "GET",
                //    data: "method=GetDepAPP&data=js",
                //    dataType: "json",
                //    success: function (d) {
                //        userPicker.setData(
                //        d.data
                //        );
                //    },
                //    error: function () { alert("查询出错，请稍候再试"); }
                //});
                //var showUserPickerButton = doc.getElementById('txt_DepID');
                //var userResult = doc.getElementById('txt_DepID');
                //var userCustName = doc.getElementById('hf_DepID');
                //showUserPickerButton.addEventListener('tap', function (event) {
                //    userPicker.show(function (items) {
                //        userResult.value = items[0].text;
                //        userCustName.value = items[0].value;
                //        document.getElementById("btn_Serach").click();
                //    });
                //}, false);


                var userPicker1 = new $.PopPicker();
                // userPicker.setData([]);

                userPicker1.setData(
                     [
                      { value: '1', text: '上学期' },
                      { value: '2', text: '下学期' },
                     ]);

                var showUserPickerButton1 = doc.getElementById('txt_Term');
                var userResult1 = doc.getElementById('txt_Term');
                var userCustName1 = doc.getElementById('hf_Term');
                showUserPickerButton1.addEventListener('tap', function (event) {
                    userPicker1.show(function (items) {
                        userResult1.value = items[0].text;
                        userCustName1.value = items[0].value;
                    });
                }, false);




                var userPicker2 = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET",
                    data: "method=GetMenu",
                    dataType: "json",
                    success: function (d) {
                        userPicker2.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton2 = doc.getElementById('txt_Menu');
                var userResult2 = doc.getElementById('txt_Menu');
                var userCustName2 = doc.getElementById('hf_Menu');
                showUserPickerButton2.addEventListener('tap', function (event) {
                    userPicker2.show(function (items) {
                        userResult2.value = items[0].text;
                        userCustName2.value = items[0].value;
                    });
                }, false);


            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        function check() {
            var nr = "";
            $("#hf_DutyUser").val($("#DutyUser").val());//获取责任人
            $("#hf_DepID").val($("#dep").val());       //获取部门
            $(".mui-content-padded  textarea").each(function () {
                nr += $(this).val() + "&";   //获取内容
            })
            $("#hf_nr").val(nr);
            if ($("#txt_BeginDate").val() == "")
            { alert("请选择开始日期"); return false; }
            if ($("#txt_EndDate").val() == "")
            { alert("请选择结束日期"); return false; }
            var sText = $("#txt_Users").combotree("getText");
            document.getElementById("hf_Users").value = sText;
            if ($("#hf_nr").val() == "") {
                alert("请输入内容");
                return false;
            }
           
        }
    </script>

    <script>
        //(function ($, doc) {
        //    $.init();
        //    var result = $('#result')[0];
        //    var result1 = $('#result1')[0];
        //    var btns = $('.btn');
        //    btns.each(function (i, btn) {
        //        btn.addEventListener('tap', function () {
        //            var _self = this;
        //            if (_self.picker) {
        //                _self.picker.show(function (rs) {
        //                    if (i == 0) {
        //                        result.innerText = rs.text;
        //                        document.getElementById("hf_begin").value = rs.value;
        //                    }
        //                    if (i == 1) {
        //                        result1.innerText = rs.text;
        //                        document.getElementById("hf_end").value = rs.value;
        //                    }
        //                    _self.picker.dispose();
        //                    _self.picker = null;
        //                    //if (document.getElementById("hf_begin").value != "" && document.getElementById("hf_end").value != "")
        //                    //{
        //                    //    say();
        //                    //}
        //                });
        //            }
        //            else {
        //                var optionsJson = this.getAttribute('data-options') || '{}';
        //                var options = JSON.parse(optionsJson);
        //                _self.picker = new $.DtPicker(options);

        //            }

        //        }, false);
        //    });

        //})(mui, document);

        (function ($, doc) {
            $.init();
            var result = $('#demo7')[0];
            result.innerText = document.getElementById("hf_begin").value;
            var result1 = $('#demo8')[0];
            result1.innerText = document.getElementById("hf_end").value;
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


