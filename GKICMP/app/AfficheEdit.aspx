<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheEdit.aspx.cs" Inherits="GKICMP.app.AfficheEdit" %>

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

    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/oa_iconfont.js"></script>
    <script src="../js/jquery-1.11.0.min.js"></script>

    <title>校讯通</title>
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
    </style>
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
                $("#dxseclet").val('');
                $(".parentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_UID").val($("#hf_UID").val() + this.id + ",");
                        $("#dxseclet").val($("#dxseclet").val() + this.title + ",");
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
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_UID" runat="server" />
        <header class="mui-bar mui-bar-nav">
            <%--<a class="mui-pull-left iconfont icon-fanhui color-3 fhjt" href="javascript:history.back();"></a>--%>
              <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">校讯通</h1>
        </header>
        <div class="mui-content">

             <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="AfficheEdit.aspx" class="mui-control-item mui-active">校讯通</a>
                    <a href="AfficheSendManage.aspx" class="mui-control-item">已发通知</a>
                    <a href="AfficheAcceptManage.aspx" class="mui-control-item">已收通知</a>
                </div>
            </div>

            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>公告标题</label>
                        <asp:TextBox ID="txt_AfficheTitle" runat="server" CssClass="mui-icon-location" placeholder="请填写公告标题"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>公告类型</label>
                        <asp:TextBox runat="server" name="showType" ID="txt_AType" placeholder="请选择公告类型"></asp:TextBox>
                        <asp:HiddenField ID="hf_Type" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>是否公示</label>
                        <asp:TextBox ID="txt_IsDisplay" name="shpdisplay" runat="server" placeholder="请选择是否公示"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hf_Display" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>接收人员</label>
                        <input type="text" id="dxseclet" name="dxseclet" placeholder="点击此处选择接收人员"/>
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
                <div class="textarea-div">
                    <div class="mui-input-group hybt linght40">
                        <p>公告内容</p>
                        <asp:TextBox ID="txt_AContent" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写公告内容"></asp:TextBox>
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
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetType",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_AType');
                var userResult = doc.getElementById('txt_AType');
                var userCustName = doc.getElementById('hf_Type');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);


                var userPicker1 = new $.PopPicker();
                userPicker1.setData(
                [
                    { value: '1', text: '是' },
                    { value: '0', text: '否' }
                ]);
                var showUserPickerButton = doc.getElementById('txt_IsDisplay');
                var userResult1 = doc.getElementById('txt_IsDisplay');
                var userCustName1 = doc.getElementById('hf_Display');
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

