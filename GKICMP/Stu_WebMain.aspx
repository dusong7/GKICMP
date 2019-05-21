<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stu_WebMain.aspx.cs" Inherits="GKICMP.Stu_WebMain" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>智慧校园管理平台</title>
    <link rel="icon" href="gzimages/yghd_favicon.ico" type="image/x-icon" />
    <style type="text/css">
        frameset {
            border: 0px;
        }

        frame {
            border: 0px;
        }
    </style>

    <link rel="stylesheet" type="text/css" href="css/maincss.css" />
    <link rel="stylesheet" type="text/css" href="css/iconfont.css" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            jQuery.jqtab = function (tabtit, tab_conbox, shijian) {
                $(tab_conbox).find("li").hide();
                $(tabtit).find("li:first").addClass("thistab").show();
                $(tab_conbox).find("li:first").show();

                $(tabtit).find("li").bind(shijian, function () {
                    $(this).addClass("thistab").siblings("li").removeClass("thistab");
                    var activeindex = $(tabtit).find("li").index(this);
                    $(tab_conbox).children().eq(activeindex).show().siblings().hide();
                    return false;
                });
            };
            /*调用方法如下：*/
            $.jqtab("#tabs", "#tab_conbox", "click");
            $(".menuItem").click(function () { $("#mainiframe").attr("src", this.href); });
        });

        function initTree(t) {
            var tree = document.getElementById(t);
            var lis = tree.getElementsByTagName("a");
            //alert(lis.length);
            for (var i = 0; i < lis.length; i++) {
                lis[i].nu = i;
                lis[i].onclick = function () {
                    for (var j = 0; j < lis.length; j++) {
                        if (j == this.nu) {
                            this.className = "selecta";
                            document.body.focus();
                        } else {
                            lis[j].className = "selectb";
                        }
                    }
                }
            }
        }
        window.onload = function () {
            initTree("tab_conbox");
        };
        //$(function(){setTimeout(onWidthChange,1000);});此函数实时监测窗口大小

        //function onWidthChange()
        //{
        //    if( $(window).height() > 560 ) {
        //         top.leftset.cols = "247,*";
        // 
        //    }
        //	else{
        //		 top.leftset.cols = "80,*";
        //		}
        //    setTimeout(onWidthChange,1000);
        //}

        if ($(window).height() > 560) {//加载时判断窗口高度
            top.leftset.cols = "60,*";

        }
        else {
            top.leftset.cols = "80,*";
        }

        function leftset() {
            document.getElementById("bszt").value = "1";
            top.leftset.cols = "210,*";


        }
        window.onresize = function () {//此函数当窗口大小改变时调用
            if (document.getElementById("bszt").value == "0") {
                if ($(window).height() > 560) {
                    top.leftset.cols = "60,*";
                }
                else {
                    top.leftset.cols = "80,*";
                }
            }
            $(".menucs").css("height", $(window).height() - 74); $(".maindiv").css("height", $(window).height() - 78);
            $(".maindiv").css("width", $(window).width() - 265);
        }
        $(document).ready(function () {
            $(".menucs").css("height", $(window).height() - 74);
            $(".maindiv").css("width", $(window).width() - 265); $(".maindiv").css("height", $(window).height() - 78);
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="toplogo">
            <div class="logo">
                <img src="images/adminlogo.png">
            </div>
            <div class="topimg">
                <ul>
                    <div class="glyxx">
                        <div>
                            <asp:Image runat="server" ID="image1" />
                            <%--<img src="images/t_male.png">--%><span class="whi">欢迎您!</span><span>
                                <asp:Literal ID="ltl_UserName" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <li><a href="resourcesite/Res_NewMain.aspx" target="_blank"><i class="icon iconfont icon-rizhi"></i>资源平台</a></li>
                    <li><a href="/" target="_blank"><i class="icon iconfont icon-kongjian"></i>学校网站</a></li>
                    <li><a href=""><i class="icon iconfont icon-zhuye"></i>系统主页</a></li>
                    <li><a href="SysUserInfo.aspx" target="mainiframe"><i class="icon iconfont icon-yonghuxinxiB"></i>用户信息</a></li>
                    <li>
                        <asp:LinkButton ID="lbtn_Out" runat="server" OnClick="lbtn_Out_Click"><i class="icon iconfont icon-tuichu"></i>安全退出</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <input type="hidden" name="bszt" id="bszt" value="0" />
        <div class="menucs">
            <div id="tabbox">
                <ul class="tabs" id="tabs">
                    <li><a href="#"><i class="icon iconfont icon-richangbangong"></i>我的日常</a></li>
                    <li><a href="#"><i class="icon iconfont icon-ziyuanguanli"></i>我的学习</a></li>
                    <li><a href="#"><i class="icon iconfont icon-xueshengguanli"></i>我的档案</a></li>
                </ul>
                <div class="foldingbtn" onclick="folding();" title="收缩菜单"></div>
                <ul class="tab_conbox" id="tab_conbox">
                    <li class="tab_con">
                        <dl>
                            <dd class="menulist1"><a href="studentpage/HomeworkManage.aspx?SysMUID=59" target="mainiframe">我的作业</a> </dd>
                            <dd class="menulist1"><a href="office/LeaveList.aspx?flag=1&SysMUID=59" target="mainiframe">请假登记</a> </dd>
                            <dd class="menulist1"><a href="studentpage/MyQuestionList.aspx?SysMUID=59" target="mainiframe">我的问卷</a> </dd>
                            <dd class="menulist1"><a href="spacemanage/ClassSpace.aspx" target="mainiframe">我的班级</a> </dd>
                            <dd class="menulist1"><a href="spacemanage/PersonSpace.aspx" target="mainiframe">我的空间</a> </dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <%--<dd class="menulist1"><a href="office/LinkManage.aspx?SysMUID=59" target="mainiframe">我的作业</a> </dd>--%>
                            <dd class="menulist1"><a href="studentpage/MyClassSchedule.aspx?SysMUID=59" target="mainiframe">我的课表</a> </dd>
                            <dd class="menulist1"><a href="studentpage/MyExamManage.aspx?SysMUID=59" target="mainiframe">我的考试</a> </dd>
                            <dd class="menulist1"><a href="networkteach/NetworkTeachManageStu.aspx" target="mainiframe">在线学习</a> </dd>
                            <dd class="menulist1"><a href="educational/PersonPracticeManage.aspx" target="mainiframe">在线练习</a> </dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dd class="menulist1"><a href="studentpage/StudentInfo.aspx" target="mainiframe">我的档案</a> </dd>
                            <dd class="menulist1"><a href="studentpage/StuRewardList.aspx" target="mainiframe">我的奖惩</a> </dd>
                            <dd class="menulist1"><a href="studentpage/StuEvaluateManage.aspx?SysMUID=59" target="mainiframe">我的评语</a> </dd>
                            <dd class="menulist1"><a href="studentpage/StuPhysicalList.aspx?SysMUID=59" target="mainiframe">体质健康</a> </dd>
                        </dl>
                    </li>
                </ul>
            </div>
        </div>
        <div class="maindiv">
            <iframe name="mainiframe" id="mainiframe" width="100%" height="100%" src="Main.aspx" frameborder="0" seamless></iframe>
        </div>
    </form>
</body>
</html>
