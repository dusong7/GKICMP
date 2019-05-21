<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="GKICMP.appstu.CourseDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>课程简介</title>

    <link href="../appcss/mui.css" rel="stylesheet" />

    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />

    <link href="../appcss/new_file.css" rel="stylesheet" />

    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../js/mui.min.js"></script>
    <script src="../js/oa_iconfont.js"></script>


    <link href="../EasyUI/themes/icon.css" rel="stylesheet" />


    <style>
        body {
            margin: 0px;
            padding: 0px;
            padding-bottom: 100px;
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
        input[type='button'], .mui-btn-primary, .mui-btn-blue {
            color: #fff;
            border: 1px solid #7e9bbb;
            background-color: #7e9bbb;
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
        <div class="mui-content bgcolor-white">

            <div class="mui-col-xs-11" style="margin: auto;">
                <h3 style="text-align: center; line-height: 1.5;">
                    <asp:Literal ID="ltl_CourseName" runat="server"></asp:Literal>
                </h3>

                <div style="line-height: 1.5;" id="zxyl">课程简介：
                    <asp:Literal ID="ltl_CourseDesc" runat="server"></asp:Literal>
                </div>
            </div>


            <div class="dmenu" id="subnav" >
                <ul>
                    <li >
                       <%-- <span class="iconfont icon-zhuanfa"></span>--%>
                        <span>
                            <input type="button" value="返回" onclick="javascript: window.history.back(-1);" /> 
                            <asp:Button ID="btn_Submit" runat="server" Text="确认 " OnClick="btn_CY_Click" />
                        </span>
                       
                    </li>
                    
                </ul>
            </div>
        </div>


         <nav class="mui-bar mui-bar-tab">
             <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a href="../app/UserInfo.aspx" class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>

            <a href="Stu_AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        <script src="../js/mui.min.js"></script>
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
        <script type='text/javascript'>
            var subnav = document.getElementById('subnav'),
				aLi = document.querySelectorAll('#subnav li'),
				w = subnav.offsetWidth / aLi.length; //通过容器的宽度除以li的个数来计算每个li的宽度
            for (var i = 0; i < aLi.length; i++) {
                aLi[i].style.width = w + 'px';
            }
        </script>
   

    </form>
</body>
</html>

