<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMain.aspx.cs" Inherits="GKICMP.WebMain" %>

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
            $(".menuItem").click(function () {
               // $("#mainiframe").attr("src", this.href);
                var thisa = this.id;
                var a = $(this).parents("li");
                var liid = a.attr("id");
                var show = false;
                if ($(this).hasClass("notice2")) {
                    // alert(this.id);
                    $.ajax({
                        url: "ashx/Tea.ashx",
                        cache: false,
                        type: "get",
                        async: false,
                        data: "method=RemindUpdate&mid=" + this.id,
                        dataType: "json",
                        success: function (data) {
                            if (data.result == "true") {
                                $("#" + thisa).removeClass("notice2");
                                var b = $(a).find("a");
                                for (var i = 0; i < b.length; i++) {
                                    if ($(b[i]).hasClass("notice2"))
                                    { show = true; break; }
                                }
                                if (!show)
                                    $("#P-" + liid).removeClass("notice");
                            }
                        }
                    });
                };
                $("#mainiframe").attr("src", this.href);
            });
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
                            $(lis[j]).removeClass("selecta");
                            $(lis[j]).addClass("selectb");
                            //lis[j].className = "selectb";
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

        function leftset(id) {
            $.ajax({
                url: "ashx/Tea.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=GetFUrl&mid=" + id + '&uid=' + $("#hf_uid").val(),
                dataType: "json",
                success: function (data) {
                    if (data.result == "true") {
                        window.parent.mainiframe.location.href = data.data[0].Name;
                    }
                }
            });
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
            $(".maindiv").css("width", $(window).width() - 248);
        }
        $(document).ready(function () {
            $(".menucs").css("height", $(window).height() - 74);
            $(".maindiv").css("width", $(window).width() - 248); $(".maindiv").css("height", $(window).height() - 78);
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_uid" runat="server" />
        <div class="toplogo">
            <div class="logo">
                <img src="gzimages/adminlogo.png">
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
                       <li><a href="BigDataAnalysis.html" target="_blank"><i class="icon iconfont icon-dashuju"></i>大数据分析</a></li>
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
                <%--<ul class="tabs" id="tabs">--%>
                <%--<li><a href="#"><i class="icon iconfont icon-richangbangong"></i>日常办公</a></li>
                    <li><a href="#"><i class="icon iconfont icon-hangzhengbangong"></i>电子政务</a></li>
                    <li><a href="#"><i class="icon iconfont icon-jiaoxueguanli"></i>教学管理</a></li>
                    <li><a href="#"><i class="icon iconfont icon-ziyuanguanli"></i>资源管理</a></li>


                    <li><a href="#"><i class="icon iconfont icon-xueshengguanli"></i>学生管理</a></li>
                    <li><a href="#"><i class="icon iconfont icon-jiaozhigongguanli"></i>教职工管理</a></li>
                    <li><a href="#"><i class="icon iconfont icon-wangzhanguanli"></i>网站管理</a></li>--%>
                <%--<li><a href="#"><i class="icon iconfont icon-houqinguanli"></i>后勤管理</a></li>--%>
                <%--  <li><a href="#"><i class="icon iconfont icon-svg33"></i>资产管理</a></li>
                    <li><a href="#"><i class="icon iconfont icon-xinxijiankong"></i>信息监控</a></li>
                    <li><a href="#"><i class="icon iconfont icon-xitongshezhi"></i>系统管理</a></li>--%>
                <%--  </ul>--%>
                <%-- <ul class="tab_conbox" id="tab_conbox">
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-richangbangong"></i>日常办公</dt>
                            <dd><a class="selecta menuItem" target="mainiframe" href="office/LinkManage.aspx">通讯录</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="office/WorkPlanManage.aspx">工作计划</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="office/DutyLogManage.aspx">值班日志</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="office/LeaveList.aspx">请假管理</a></dd>
                             <dd><a target="mainiframe" class="menuItem" href="office/TraveLeaveList.aspx">外出管理</a></dd>--%>
                <%--<dd><a target="mainiframe" class="menuItem" href="office/LeaveAuditList.aspx">请假审核</a></dd>--%>
                <%-- <dd><a target="mainiframe" class="menuItem" href="office/TraveLeaveAuditList.aspx">外出审核</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="office/RepairList.aspx">我的报修</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="office/HomeWorkManage.aspx">作业布置</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="questionnaire/AnswerQuestionList.aspx">我的问卷</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="questionnaire/QuestionnaireList.aspx">问卷管理</a></dd>
                             <dd><a target="mainiframe" class="menuItem" href="teachermanage/TeacherEdit.aspx?flag=1">我的档案</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-hangzhengbangong"></i>电子政务</dt>
                            <dd><a class="selecta menuItem" target="mainiframe" href="oamanage/AfficheManage.aspx">通知公告</a></dd>
                            <dd><a class="mainiframe" target="mainiframe" href="oamanage/EgovernmentIntends.aspx">拟办公文</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="oamanage/EgovernmentBeSend.aspx">已发政务</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="oamanage/EgovernmentTR.aspx">已收政务</a></dd>
                            <dd><a target="mainiframe" class="menuItem" href="oamanage/EgovernmentSearch.aspx">归档综合查询</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-jiaoxueguanli"></i>教学管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="educational/BaseSet.aspx">基础设置</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/CourseManage.aspx">课程管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/TeacherPlaneList.aspx?Flag=1">排课计划</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/TeacherPlaneList.aspx?Flag=3">班级课表</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/TPersonSchedule.aspx">我的课表</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/ExamManage.aspx">考试管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="educational/CourseSelectionManage.aspx">选课管理</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-ziyuanguanli"></i>资源管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="resource/GradeList.aspx?Flag=1">我的资源</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="resource/GradeList.aspx?Flag=2">资源管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="resource/EduResource.aspx">我关注的资源</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="http://www.pep.com.cn/products/">人教电子书</a></dd>

                        </dl>
                    </li>


                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-xueshengguanli"></i>学生管理</dt>
                            <dd><a class="menuItem" target="mainiframe" href="studentmanage/StudentManage.aspx">学生信息管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="studentmanage/SchoolChangeManage.aspx">学生变动管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="studentmanage/StuRewardManage.aspx">学生奖惩管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="studentmanage/StuEvaluateManage.aspx">学生评语管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="studentmanage/StuPhysicalManage.aspx">体质健康管理</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-jiaozhigongguanli"></i>教职工管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="teachermanage/TeacherManage.aspx">教师管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherEducationManage.aspx">学历管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherPaperManage.aspx">教科研管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherAssessmentManage.aspx?Flag=1">年度考核管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherAssessmentManage.aspx?Flag=2">师德考核管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherWorkExperienceManage.aspx">工作管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherClassHourManage.aspx">课时管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/ContractManage.aspx">合同管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherLearnManage.aspx">学习培训管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="teachermanage/TeacherHolidayManage.aspx">考勤管理</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-wangzhanguanli"></i>网站管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="cms/SiteEdit.aspx">站点管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/MenuManage.aspx">栏目管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/NewsManage.aspx">新闻管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/CommentManage.aspx?flag=2">评论管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/CommentManage.aspx?flag=1">留言管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/SlideManage.aspx?flag=1">友情链接管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/SlideManage.aspx?flag=2">幻灯片管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/SlideManage.aspx?flag=3">宣传标语管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="cms/SlideTypeManage.aspx">类别管理</a></dd>
                        </dl>

                    </li>--%>
                <%--          <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-houqinguanli"></i>后勤管理</dt>

                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/TBuildingManage.aspx">教学楼管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/TFloorManage.aspx">楼宇管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/ClassRoomManage.aspx">教室管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetMaterialsManage.aspx">耗材类别管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetManage.aspx?flag=2">耗材管理</a></dd>

                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/RepairPeopleList.aspx">受理报修</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/RepairALLList.aspx">报修查询</a></dd>


                        </dl>
                    </li>--%>
                <%--  <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-svg33"></i>资产管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="projectmanage/JZProjectManage.aspx">教装项目申报</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="projectmanage/JJProjectManage.aspx">基建项目申报</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetsFilesList.aspx">项目文件管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="projectmanage/ProTender.aspx">中标情况管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="projectmanage/JZProjectImport.aspx">供货清单管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="projectmanage/JZProjectCheckList.aspx">验收管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/SupplierList.aspx">供应商管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetsTypeManage.aspx">资产类别管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetManage.aspx?flag=1">校产管理</a></dd>

                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/ScrapManage.aspx">资产报废管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetManage.aspx?flag=1">校产管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="assetmanage/AssetAccountMange.aspx">资产盘点管理</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-xinxijiankong"></i>信息监控</dt>
                            <dd><a class="menuItem" target="mainiframe" href="computermanage/ComputerManage.aspx">设备管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="computermanage/ComputerOnLine.aspx">在线查看</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="computermanage/ComputerRegManage.aspx">登记管理</a></dd>
                            <dd><a class="menuItem" target="mainiframe" href="computermanage/ComputerTotel.aspx">使用统计</a></dd>
                        </dl>
                    </li>
                    <li class="tab_con">
                        <dl>
                            <dt><i class="icon iconfont icon-xitongshezhi"></i>系统管理</dt>
                            <dd><a class="selecta" target="mainiframe" href="sysmanage/SysUserManage.aspx">用户管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/DepartmentList.aspx?flag=1">部门管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/CampusManage.aspx">校区管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/GradeManage.aspx">年级管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/DepartmentList.aspx?flag=2">班级管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/SysRoleManage.aspx">角色管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/SysUserType.aspx">人员分类管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/ModuleManage.aspx">模块管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/SysDataManage.aspx">基础数据</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/SystTempManage.aspx">模板管理</a></dd>
                            <dd><a target="mainiframe" href="sysmanage/LogManage.aspx">系统日志</a></dd>
                        </dl>
                    </li>
                </ul>--%>

                <ul class="tabs" id="tabs">


                    <asp:Repeater ID="rpmodule" runat="server">
                        <ItemTemplate>

                            <%-- <li id='<%#Eval("ModuleIcon").ToString().Substring(0,Eval("ModuleIcon").ToString().Length-3) %>' onclick="picurl(this.id)">--%>
                            <li>
                                <a href="#" onclick='leftset(<%#Eval("ModuleID") %>);'>
                                    <i class='icon iconfont icon-<%#Eval("ModuleIcon")%> <%#Eval("IsClick").ToString()=="1"?"notice":""%>' id="P-<%#Eval("ModuleID")%>" ></i>
                                    <%#Eval("ModuleName") %>
                                    <%-- <img src='<%#GetIconUrl(Eval("ModuleIcon"),Container.ItemIndex )%>' width="31" height="31" id='<%#Eval("ModuleIcon") %>' /><br />--%>
                                </a>
                            </li>
                        </ItemTemplate>

                    </asp:Repeater>

                </ul>
                <div class="foldingbtn" onclick="folding();" title="收缩菜单"></div>
                <ul class="tab_conbox" id="tab_conbox">
                    <asp:Repeater ID="rpList" runat="server" OnItemDataBound='rpList_ItemDataBound'>
                        <ItemTemplate>
                            <li class="tab_con" id='<%#Eval("ModuleID") %>'>
                                <dl>
                                    <asp:HiddenField ID="hffid" runat="server" Value='<%#Eval("ModuleID") %>' />

                                    <asp:Repeater ID="rpnextModule" runat="server">
                                        <ItemTemplate>
                                            <%#GetMList(Eval("ModuleID"),Eval("ModuleUrl"),Eval("ModuleName"),Eval("Flag"),Eval("IsClick"))%>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </dl>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </div>
        <div class="maindiv">
            <iframe name="mainiframe" id="mainiframe" width="100%" height="100%" src="Main.aspx" frameborder="0" seamless></iframe>
        </div>
    </form>
</body>
</html>
