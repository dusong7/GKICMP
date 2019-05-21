<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuAttendEdit.aspx.cs" Inherits="GKICMP.app.StuAttendEdit" %>

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
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/jquery.easyui.mobile.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <title>晨检申报登记</title>


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




    <script src="../js/oa_iconfont.js"></script>
    <script src="../js/jquery-1.11.0.min.js"></script>

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

        .selectdiv .classparentli, .selectdiv .cdparentli, .selectdiv .sjparentli, .selectdiv .bjparentli, .selectdiv .crbparentli {
            border-bottom: 1px solid #DDDDDD;
            padding: 10px 10px;
        }

            .selectdiv .classparentli.classselected ul, .selectdiv .cdparentli.cdselected ul, .selectdiv .sjparentli.sjselected ul, .selectdiv .bjparentli.bjselected ul, .selectdiv .crbparentli.crbselected ul {
                display: block;
            }

            .selectdiv .classparentli span.classselected, .selectdiv .cdparentli span.cdselected, .selectdiv .sjparentli span.sjselected, .selectdiv .bjparentli span.bjselected, .selectdiv .crbparentli span.crbselected {
                background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
            }

            .selectdiv .classparentli ul, .selectdiv .cdparentli ul, .selectdiv .sjparentli ul, .selectdiv .bjparentli ul, .selectdiv .crbparentli ul {
                display: none;
            }

            .selectdiv .classparentli span, .selectdiv .cdparentli span, .selectdiv .sjparentli span, .selectdiv .bjparentli span, .selectdiv .crbparentli span {
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                float: left;
                margin-right: 5px;
            }

            .selectdiv .classparentli img, .selectdiv .cdparentli img, .selectdiv .sjparentli img, .selectdiv .bjparentli img, .selectdiv .crbparentli img {
                float: left;
                margin-right: 5px;
            }

            .selectdiv .classparentli li, .selectdiv .cdparentli li, .selectdiv .sjparentli li, .selectdiv .bjparentli li, .selectdiv .crbparentli li {
                width: 95px;
                display: inline-block;
                border: 1px solid #dedede;
                margin-top: 10px;
                padding: 3px 5px;
                border-radius: 2px;
            }

            .selectdiv .cdparentli li, .selectdiv .sjparentli li, .selectdiv .bjparentli li, .selectdiv .crbparentli li {
                width: 70px;
            }

                .selectdiv .classparentli li.select, .selectdiv .cdparentli li.select, .selectdiv .sjparentli li.select, .selectdiv .bjparentli li.select, .selectdiv .crbparentli li.select {
                    background: url(../appimages/selectinfo.png) 75px center no-repeat #f5faff;
                    border-color: #1296db;
                    color: #1296db;
                }

                .selectdiv .cdparentli li.select, .selectdiv .sjparentli li.select, .selectdiv .bjparentli li.select, .selectdiv .crbparentli li.select {
                    background: url(../appimages/selectinfo.png) 50px center no-repeat #f5faff;
                }
    </style>
    <%-- 班级选择 --%>
    <script>
        $(function () {
            $(".classparentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#classseclet").click(function () {
                $("#classdxc").css("display", "block");
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#" + $("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1)).attr('class', 'select');
                }
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) == 0) {
                    $(this).removeClass("classselected");
                    $(this).parent().find("li").addClass("noselect");
                }
            })

            $("#classselectclose").click(function () {
                $("#classdxc").css("display", "none");
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#btn_Search").click();
                }
            })

            $(".classparentli img").click(function () {
                if ($(this).parent("li").hasClass("classselected")) {
                    $(this).parent("li").removeClass("classselected");
                    $(this).attr("src", "../appimages/allpic.png");
                } else {
                    $(this).parent("li").addClass("classselected");
                    $(this).attr("src", "../appimages/allinpic.png");
                }
            })

            $(".classparentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $('.classparentli li').removeClass("select");
                    $('.classparentli li').addClass("noselect");
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("classselected");
                } else {
                    $(this).parent().siblings("span").addClass("classselected");
                }
                selectoption();
            })

            $(".classparentli span").click(function () {
                if ($(this).hasClass("classselected")) {
                    $(this).removeClass("classselected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("classselected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                selectoption();
            })
            function selectoption() {
                $("#hf_DID").val('');
                $("#classseclet").val('');
                $(".classparentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_DID").val($("#hf_DID").val() + this.id + ",");
                        $("#classseclet").val($("#classseclet").val() + this.title + ",");
                        $("#hf_DIDName").val($("#classseclet").val());
                    }
                });
                $("#classseclet").val($("#classseclet").val().substr(0, $("#classseclet").val().length - 1));
            }
        })
    </script>
    <%-- 迟到人员选择 --%>
    <script>
        $(function () {
            $(".cdparentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#cddxseclet").click(function () {
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#cddxc").css("display", "block");
                }
            })

            $("#cdselectclose").click(function () {
                $("#cddxc").css("display", "none");
            })

            $(".cdparentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }
                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("cdselected");
                } else {
                    $(this).parent().siblings("span").addClass("cdselected");
                }
                LeaveUser();
            })

            $(".cdparentli span").click(function () {
                if ($(this).hasClass("cdselected")) {
                    $(this).removeClass("cdselected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("cdselected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                LeaveUser();
            })
            function LeaveUser() {
                $("#hf_LeaveUser").val('');
                $("#cddxseclet").val('');
                $(".cdparentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_LeaveUser").val($("#hf_LeaveUser").val() + this.id + ",");
                        $("#cddxseclet").val($("#cddxseclet").val() + this.title + ",");
                        $("#hf_LeaveUserName").val($("#cddxseclet").val());
                    }
                });
                $("#cddxseclet").val($("#cddxseclet").val().substr(0, $("#cddxseclet").val().length - 1));
            }

        })
    </script>
    <%-- 事假人员选择 --%>
    <script>
        $(function () {
            $(".sjparentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#sjdxseclet").click(function () {
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#sjdxc").css("display", "block");
                }
            })

            $("#sjselectclose").click(function () {
                $("#sjdxc").css("display", "none");
            })

            $(".sjparentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }
                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("sjselected");
                } else {
                    $(this).parent().siblings("span").addClass("sjselected");
                }
                Compassionate();
            })

            $(".sjparentli span").click(function () {
                if ($(this).hasClass("sjselected")) {
                    $(this).removeClass("sjselected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("sjselected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                Compassionate();
            })
            function Compassionate() {
                $("#hf_Compassionate").val('');
                $("#sjdxseclet").val('');
                $(".sjparentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_Compassionate").val($("#hf_Compassionate").val() + this.id + ",");
                        $("#sjdxseclet").val($("#sjdxseclet").val() + this.title + ",");
                        $("#hf_CompassionateName").val($("#sjdxseclet").val());
                    }
                });
                $("#sjdxseclet").val($("#sjdxseclet").val().substr(0, $("#sjdxseclet").val().length - 1));
            }

        })
    </script>
    <%-- 病假人员选择 --%>
    <script>
        $(function () {
            $(".bjparentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#bjdxseclet").click(function () {
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#bjdxc").css("display", "block");
                }
            })

            $("#bjselectclose").click(function () {
                $("#bjdxc").css("display", "none");
            })

            $(".bjparentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }
                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("bjselected");
                } else {
                    $(this).parent().siblings("span").addClass("bjselected");
                }
                Sick();
            })

            $(".bjparentli span").click(function () {
                if ($(this).hasClass("bjselected")) {
                    $(this).removeClass("bjselected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("bjselected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                Sick();
            })
            function Sick() {
                $("#hf_Sick").val('');
                $("#bjdxseclet").val('');
                $(".bjparentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_Sick").val($("#hf_Sick").val() + this.id + ",");
                        $("#bjdxseclet").val($("#bjdxseclet").val() + this.title + ",");
                        $("#hf_SickName").val($("#bjdxseclet").val());
                    }
                });
                $("#bjdxseclet").val($("#bjdxseclet").val().substr(0, $("#bjdxseclet").val().length - 1));
            }

        })
    </script>
    <%-- 传染病 --%>
    <script>
        $(function () {
            $(".crbparentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#crbdxseclet").click(function () {
                if ($("#hf_DID").val().substr(0, $("#hf_DID").val().length - 1) > 0) {
                    $("#crbdxc").css("display", "block");
                }
            })

            $("#crbselectclose").click(function () {
                $("#crbdxc").css("display", "none");
            })

            $(".crbparentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }
                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("crbselected");
                } else {
                    $(this).parent().siblings("span").addClass("crbselected");
                }
                Sick();
            })

            $(".crbparentli span").click(function () {
                if ($(this).hasClass("crbselected")) {
                    $(this).removeClass("crbselected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("crbselected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                Sick();
            })
            function Sick() {
                $("#hf_Infectious").val('');
                $("#crbdxseclet").val('');
                $(".crbparentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_Infectious").val($("#hf_Infectious").val() + this.id + ",");
                        $("#crbdxseclet").val($("#crbdxseclet").val() + this.title + ",");
                        $("#hf_InfectiousName").val($("#crbdxseclet").val());
                    }
                });
                $("#crbdxseclet").val($("#crbdxseclet").val().substr(0, $("#crbdxseclet").val().length - 1));
            }

        })
    </script>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 80px;
        }

        .mui-content-padded {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
        <%-- 班级 --%>
        <asp:HiddenField ID="hf_DID" runat="server" />
        <asp:HiddenField ID="hf_DIDName" runat="server" />
        <%-- 迟到 --%>
        <asp:HiddenField ID="hf_LeaveUser" runat="server" />
        <asp:HiddenField ID="hf_LeaveUserName" runat="server" />
        <%-- 事假 --%>
        <asp:HiddenField ID="hf_Compassionate" runat="server" />
        <asp:HiddenField ID="hf_CompassionateName" runat="server" />
        <%-- 病假 --%>
        <asp:HiddenField ID="hf_Sick" runat="server" />
        <asp:HiddenField ID="hf_SickName" runat="server" />
        <%-- 传染病 --%>
        <asp:HiddenField ID="hf_Infectious" runat="server" />
        <asp:HiddenField ID="hf_InfectiousName" runat="server" />

        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">晨检申报</h1>
        </header>

        <div class="mui-content">
            <div style="padding: 10px 10px;">
                <div id="segmentedControl" class="mui-segmented-control">
                    <a href="StuAttendEdit.aspx" class="mui-control-item mui-active">晨检申报登记</a>
                    <a href="StuAttendManage.aspx" class="mui-control-item">晨检申报</a>
                </div>
            </div>
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>班级</label>
                        <input type="text" id="classseclet" runat="server" name="dxseclet" placeholder="点击此处选择班级" />
                        <div class="selectdiv" id="classdxc">
                            <div style="height: 30px">
                                <span class="selectclose" id="classselectclose">确定</span>
                            </div>
                            <ul>
                                <asp:Repeater ID="rp_Class" runat="server" OnItemDataBound="rp_Class_ItemDataBound">
                                    <ItemTemplate>
                                        <li class='<%#Container.ItemIndex==0?"classparentli classselected":"classparentli" %>'>
                                            <img src='<%#Container.ItemIndex==0?"../appimages/allinpic.png":"../appimages/allpic.png"%>' />
                                            <%#Eval("ShortGName") %>
                                            <asp:HiddenField runat="server" ID="hf_GID" Value='<%#Eval("GID") %>' />
                                            <ul>
                                                <asp:Repeater ID="rp_Classall" runat="server">
                                                    <ItemTemplate>
                                                        <li id='<%#Eval("DID") %>' title='<%#Eval("OtherName") %>'><%#Eval("OtherName") %></li>
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
                        <label>晨检日期</label>
                        <asp:TextBox runat="server" ID="txt_CreateDate" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>迟到</label>
                        <input type="text" id="cddxseclet" runat="server" name="dxseclet" placeholder="点击此处选择迟到人员" />
                        <div class="selectdiv" id="cddxc">
                            <div style="height: 30px">
                                <span class="selectclose" id="cdselectclose">确定</span>
                            </div>
                            <ul>
                                <li class="cdparentli cdselected"><span></span>
                                    <input type="block" id="LeaveUser" runat="server" />
                                    <ul>
                                        <asp:Repeater ID="rp_LeaveUserall" runat="server">
                                            <ItemTemplate>
                                                <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>事假</label>
                        <input type="text" id="sjdxseclet" name="dxseclet" placeholder="点击此处选择事假人员" />
                        <div class="selectdiv" id="sjdxc">
                            <div style="height: 30px">
                                <span class="selectclose" id="sjselectclose">确定</span>
                            </div>
                            <ul>
                                <li class="sjparentli sjselected"><span></span>
                                    <input type="block" id="Compassionate" runat="server" />
                                    <ul>
                                        <asp:Repeater ID="rp_Compassionateall" runat="server">
                                            <ItemTemplate>
                                                <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>病假</label>
                        <input type="text" id="bjdxseclet" name="dxseclet" placeholder="点击此处选择病假人员" />
                        <div class="selectdiv" id="bjdxc">
                            <div style="height: 30px">
                                <span class="selectclose" id="bjselectclose">确定</span>
                            </div>
                            <ul>
                                <li class="bjparentli bjselected"><span></span>
                                    <input type="block" id="Sick" runat="server" />
                                    <ul>
                                        <asp:Repeater ID="rp_Sickall" runat="server">
                                            <ItemTemplate>
                                                <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>传染病</label>
                        <input type="text" id="crbdxseclet" name="dxseclet" placeholder="点击此处选择传染病人员" />
                        <div class="selectdiv" id="crbdxc">
                            <div style="height: 30px">
                                <span class="selectclose" id="crbselectclose">确定</span>
                            </div>
                            <ul>
                                <li class="crbparentli crbselected"><span></span>
                                    <input type="block" id="Infectious" runat="server" />
                                    <ul>
                                        <asp:Repeater ID="rp_Infectious" runat="server">
                                            <ItemTemplate>
                                                <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>

                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>应到人数</label>
                        <asp:TextBox ID="txt_AllIns" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>实到人数</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_RealCOunt" placeholder="请填写实到人数"></asp:TextBox>
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
        <script type="text/javascript" charset="utf-8">
            mui('body').on('tap', 'a', function () {
                document.location.href = this.href;
            });
        </script>
    </form>
</body>
</html>
<script>
    function check() {
        if ($("#txt_RealCOunt").val() == "") {
            alert("请填写实到人数");
            return false;
        }
        if ($("#txt_AllIns").val() < $("#txt_RealCOunt").val()) {
            alert("实到人数大于应到人数");
            return false;
        }
    }
</script>
