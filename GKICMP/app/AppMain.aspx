<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppMain.aspx.cs" Inherits="GKICMP.app.AppMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>智慧校园</title>
    <%--<link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../appjs/mui.min.js"></script>--%>
      <%--<link href="../appcss/iconfont-new.css" rel="stylesheet" />--%>
    <link href="../appcss/mui.min.css" rel="stylesheet"/>
    <link href="../appcss/iconfont-add.css" rel="stylesheet" />
    <link href="../appcss/iconfontxin.css" rel="stylesheet"/>
    <link href="../appcss/zzzhxy.css" rel="stylesheet"/>
    <script src="../appjs/iconfont.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" charset="utf-8">
        mui.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hffth" runat="server" />
        <%--<div class="mui-content padbot">   
            <div class="pading5">
                <ul class="centmenu">
                    <li class="mui-col-xs-6 mui-col-sm-6">
                        <a href="AfficheAcceptManage.aspx" class="bgc1 mgr5">通知公告<span class="iconfont icon-tzgg"></span></a>
                    </li>
                    <li class="mui-col-xs-6 mui-col-sm-6">
                        <a href="#" class="bgc2 mgl5">我的空间<span class="iconfont icon-wdkj"></span></a>
                    </li>
                    <div style="clear: both;"></div>
                </ul>
                <ul class="mui-table-view mui-grid-view mui-grid-9">
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="TreatedEgovernmentManage.aspx">
                            <span class="mui-icon iconfont icon-dzzw ">
                                <span class="mui-badge" id="msg">
                                    <asp:Literal ID="ltl_wdzw" runat="server"></asp:Literal>
                                </span>
                            </span>
                            <div class="mui-media-body">电子政务</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AppMailList.aspx">
                            <span class="mui-icon iconfont icon-txl"></span>
                            <div class="mui-media-body">通讯录</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AfficheEdit.aspx">
                            <span class="mui-icon iconfont icon-xiaoxuntong"></span>
                            <div class="mui-media-body">校讯通</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AppRepair.aspx">
                            <span class="mui-icon iconfont icon-zxbx"></span>
                            <div class="mui-media-body">在线报修</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="WorkPlanList.aspx">
                            <span class="mui-icon iconfont icon-zjh"></span>
                            <div class="mui-media-body">周计划</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="Leave.aspx">
                            <span class="mui-icon iconfont icon-qjsh"></span>
                            <div class="mui-media-body">我的请假</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="Trave.aspx">
                            <span class="mui-icon iconfont icon-wcsh"></span>
                            <div class="mui-media-body">我的外出</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="OverTimeEdit.aspx">
                            <span class="mui-icon iconfont icon-jiabanguanli"></span>
                            <div class="mui-media-body">我的加班</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="MyCourseList.aspx">
                            <span class="mui-icon iconfont icon-zbrz"></span>
                            <div class="mui-media-body">我的课表</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="PersonSubstituteManage.aspx">
                            <span class="mui-icon iconfont icon-wddk"></span>
                            <div class="mui-media-body">我的代课</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AppointmentEdit.aspx">
                            <span class="mui-icon iconfont icon-bzrgzs"></span>
                            <div class="mui-media-body">场室预约</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="Homework.aspx">
                            <span class="mui-icon iconfont icon-bzzy"></span>
                            <div class="mui-media-body">布置作业</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="PersonRewardEdit.aspx">
                            <span class="mui-icon iconfont icon-wdhj"></span>
                            <div class="mui-media-body">我的获奖</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="TeacherGuidanceEdit.aspx">
                            <span class="mui-icon iconfont icon-zdxshj"></span>
                            <div class="mui-media-body">指导学生获奖</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="StuAttendEdit.aspx">
                            <span class="mui-icon iconfont icon-cjsb"></span>
                            <div class="mui-media-body">晨检申报</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="StuLeaveManage.aspx">
                            <span class="mui-icon iconfont icon-kqtj"></span>
                            <div class="mui-media-body">学生考勤</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="SpaceLogList.aspx">
                            <span class="mui-icon iconfont icon-xyhd"></span>
                            <div class="mui-media-body">校园活动</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="WorkFlow.html">
                            <span class="mui-icon iconfont icon-wodeshiwu"></span>
                            <div class="mui-media-body">我的事务</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AttendanceList.aspx">
                            <span class="mui-icon iconfont icon-dqwz"></span>
                            <div class="mui-media-body">考勤签到</div>
                        </a>
                    </li>
                    <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="NoCardApplicationEdit.aspx">
                            <span class="mui-icon iconfont icon-dqwz"></span>
                            <div class="mui-media-body">补卡申请</div>
                        </a>
                    </li>
                     <li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="OnlineCourseManage.aspx">
                            <span class="mui-icon iconfont icon-bzrgzs"></span>
                            <div class="mui-media-body">在线选课</div>
                        </a>
                    </li>
                     <li runat="server" id="record" class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
                        <a href="AttendanceLists.aspx">
                            <span class="mui-icon iconfont icon-dqwz"></span>
                            <div class="mui-media-body">考勤统计</div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>--%>
    <div class="mui-content" style="padding-bottom: 90px">
		<div id="zz1_part1">
			<h4 class="tit">行政办公</h4>
			<div class="zz1_part1_box_wrapper fn-clear">
				<a class="zz1_part1_box flt" href="TreatedEgovernmentManage.aspx">
                    <div class="bg1 click tlc">
                        <em>
                            <asp:Literal ID="ltl_wdzw" runat="server"></asp:Literal>
                        </em>
                        <div class="zz1_part1_box_icon ">
                            <i class="iconfont  icon-dianzizhengwu"></i>
                        </div>
                        <h3>电子政务</h3>
                    </div>
				</a>
				<a class="zz1_part1_box flt" href="AfficheEdit.aspx">
					<div class="bg2 click tlc">
                        <div class="zz1_part1_box_icon ">
                            <i class="iconfont icon-tongzhigonggaotixing"></i>
                        </div>
                        <h3>通知公告</h3>
					</div>
				</a>
				<a class="zz1_part1_box flt" href="AppMailList.aspx">
					<div class="bg3 click tlc">
                        <div class="zz1_part1_box_icon ">
                            <i class="iconfont icon-tongxunlu"></i>
                        </div>
                        <h3>通讯录</h3>
					</div>
				</a>
				<a class="zz1_part1_box flt" href="AppRepair.aspx">
					<div class="bg4 click tlc">
                        <div class="zz1_part1_box_icon ">
                            <i class="iconfont icon-zaixianbaoxiu"></i>
                        </div>
                        <h3>在线报修</h3>
					</div>
				</a>
				<a class="zz1_part1_box flt" href="WorkPlanList.aspx">
					<div class="bg5 click tlc">
                        <div class="zz1_part1_box_icon ">
                            <i class="iconfont icon-gongzuojihua"></i>
                        </div>
                        <h3>周计划</h3>
					</div>
				</a>
				<a class="zz1_part1_box flt" href="Homework.aspx">
					<div class="bg6 click tlc">
                        <div class="zz1_part1_box_icon " >
                            <i class="iconfont icon-wodedangan"></i>
                        </div>
                        <h3>布置作业</h3>
					</div>
				</a>
                <a runat="server" id="record" class="zz1_part1_box flt" href="AttendanceLists.aspx" >
					<div class="bg14 click tlc">
                        <div class="zz1_part1_box_icon " >
                             <i class="iconfont icon-kaoqin1"></i>
                        </div>
                        <h3>考勤统计</h3>
					</div>
				</a>
			</div>
		</div>
		<div  id="zz1_part2">
			<h4 class="tit">我的事务</h4>
			<div class="zz1_part2_box_wrapper fn-clear bgfff">
				<a class="zz1_part2_box flt click" href="Leave.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-qingjia comain" style="font-size:51px"></i></div>
                    <h4>请假</h4>
				</a>
				<a class="zz1_part2_box flt click" href="Trave.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont  icon-waichu comain" style="font-size:39px"></i></div>
                    <h4>外出</h4>
				</a>
                <a href="NoCardApplicationEdit.aspx" class="zz1_part2_box flt click">
					<div class="zz1_part2_box_icon ">
                        <i class=" comain" style="font-size:30px;font-weight:600">
                            <style>
                                .icon {
                                    width: 1em;
                                    height: 1em;
                                    vertical-align: -0.1em;
                                    fill: currentColor;
                                    overflow: hidden;
                                }
                            </style>
                            <svg class="icon" aria-hidden="true">
                                <use xlink:href="#icon-buqia"></use>
                             </svg>
                        </i>
					</div>
                    <h4>补卡</h4>
				</a>
			</div>
		</div>
        <div  id="zz1_part5">
		  <div class="zz1_part2_box_wrapper fn-clear bgfff">              
				<a class="zz1_part2_box flt click" href="PersonRewardEdit.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont  icon-huojiangzuopin" style="font-size:25px"></i></div>
                    <h4>我的获奖</h4>
				</a>
                 <a href="TeacherGuidanceEdit.aspx" class="zz1_part2_box flt click">
					<div class="zz1_part2_box_icon ">
                        <i class="iconfont  icon-huodonghuojiang" style="font-size:25px"></i></div>
                    <h4>指导学生获奖</h4>
				</a>
               <a class="zz1_part2_box flt click" href="OverTimeEdit.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-jiaban"></i>
					</div>
                     <h4>加班</h4>
				</a>
			</div>          
		</div>
        <div  id="zz1_part9">
		  <div class="zz1_part2_box_wrapper fn-clear bgfff">
              <a class="zz1_part2_box flt click" href="LeaveRecord.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-shujiabanguanli cotwo" style="font-size:25px"></i>
					</div>
                     <h4>外出备案</h4>
				</a>
              <a class="zz1_part2_box flt click" href="Clock.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-kaoqin cotwo" style="font-size:25px"></i>
					</div>
                     <h4>考勤</h4>
				</a>
              <a class="zz1_part2_box flt click" href="AppointmentEdit.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-wodedangan cotwo" style="font-size:25px"></i>
					</div>
                     <h4>场室预约</h4>
               </a>			
			</div>
		</div>
        <div id="zzl_part9">
            <div class="zz1_part2_box_wrapper fn-clear bgfff">
               <a class="zz1_part2_box flt click" href="PurAcceEdit.aspx">
					<div class="zz1_part2_box_icon">
                        <i class="iconfont icon-wodedangan cotwo" style="font-size:25px"></i>
					</div>
                     <h4>验收管理</h4>
               </a>	
            </div>
        </div>
		<div  id="zz1_part3">
			<h4 class="tit">我的教学</h4>
			<div class="zz1_part3_box_wrapper fn-clear bgfff">
				<a class="zz1_part3_box flt click" href="MyCourseList.aspx">
					<div class="zz1_part3_box_icon bg7">
                        <i class="iconfont  icon-kebiao cofff" ></i></div>
                    <label style="width:4em;display: inline-block;text-align: left;">课表</label>
				</a>
				<a class="zz1_part3_box flt click" href="PersonSubstituteManage.aspx">
					<div class="zz1_part3_box_icon bg8">
                        <i class="iconfont icon-tiaokeshenqing cofff"></i></div>
                    <label style="width:4em;display: inline-block;text-align: left;">代课</label>
				</a>                          
			</div>
		</div>
        <div  id="zz1_part6">
			<div class="zz1_part3_box_wrapper fn-clear bgfff">
				<%--<a class="zz1_part3_box flt click" href="LeaveRecord.aspx">
					<div class="zz1_part3_box_icon bg14">
                        <i class="iconfont  icon-shujiabanguanli" ></i></div>
                    <label style="width:4em;display: inline-block;text-align: left;">外出备案</label>
				</a>
				  <a class="zz1_part3_box flt click" href="Clock.aspx">
					<div class="zz1_part3_box_icon bg3">
                        <i class="iconfont  icon-kaoqin" ></i></div>
                     <label style="width:4em;display: inline-block;text-align: left;">考勤</label>
				</a>--%>            
                <a class="zz1_part3_box flt click" href="StuAttendEdit.aspx">
					<div class="zz1_part3_box_icon bg14">
                        <i class="iconfont  icon-shujiabanguanli" ></i></div>
                    <label style="width:4em;display: inline-block;text-align: left;">晨检申报</label>
				</a>
                 <a class="zz1_part3_box flt click" href="AfficheResearch.aspx">
					<div class="zz1_part3_box_icon bg14">
                        <i class="iconfont  icon-jiaoyanrenwu" ></i></div>
                    <label style="width:4em;display: inline-block;text-align: left;">教研活动</label>
				</a>
			</div>
		</div>
        <div id="zz1_part4">
		  <h4 class="tit">待办政务</h4>
			<div class="zz1_part4_box_wrapper">
				<a class="zz1_part4_box click bgfff blk"  v-for="(list, index) in lists" :key="list.id" :src="list.src">
					<div class="zz1_part4_box_tit bg6 cofff">
                        <i class="iconfont icon-dqwz cofff"></i> &nbsp;
                        <span>{{list.h4}}</span>
					</div>
					<p class="zz1_part4_box_p1 mui-ellipsis">{{list.p2}}</p>
                    <p class="zz1_part4_box_p2 comain">状态 &nbsp;<span class="mui-badge" :class="{ 'mui-badge-warning':list.zhuangtai1=='待处理','mui-badge-success' :list.zhuangtai1=='已完成'}">
                        {{list.zhuangtai1}}</span>
                    </p>
				</a>		
			</div>
		</div>
	</div>
        <nav class="mui-bar mui-bar-tab">
		<a class="mui-tab-item " href="/phone">
			<span class="mui-icon mui-icon-home vam"></span>
			<span class="mui-tab-label vam">微官网</span>
		</a>
		<a class="mui-tab-item wgw " href="UserInfo.aspx">
			<div class="wgw_in">
				<div class="wgw_in_in">
					<span class="mui-icon mui-icon-contact mui-icon-icon-contact-filled vam"></span><i class="vam"></i>
					<span class="mui-tab-label ">我的</span>
				</div>
			</div>	
		</a>
		<a class="mui-tab-item  mui-active" href="AppMain.aspx">
			<span class="mui-icon mui-icon-contact iconfont icon-zhxy"></span>
			<span class="mui-tab-label vam">智慧校园</span>
		</a>
	</nav>
        <script type="text/javascript" charset="utf-8">
            $(function () {
                var content = $("#msg").text();
                if (content == 0) {
                    $("#msg").hide();
                }
            })
            mui.init({
                swipeBack: true //启用右滑关闭功能
            });
            var slider = mui("#slider");
            slider.slider({
                interval: 3000
            });
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        </script>
        <script src="../appjs/vue.min.js"></script>
        <script src="../appjs/vue-resource.js"></script>
        <script src="../appjs/zzzhxy.js"></script>
<script>
        /*列表data*/
        var Listdata = new Vue({
            el: '#zz1_part4',
            data: {
                lists: ""
            },
            created: function () {
                var url = "../ashx/GetMainDate.ashx";
                this.$http.get(url, { params: { method: "EgovernmentMain" } }).then(function (data) {
                    console.log(data.body);
                    var json = data.body;
                    console.log(eval("(" + json + ")"));

                    var jsonObj = eval("(" + json + ")");

                    this.lists = jsonObj;
                },
                function (data) {
                    console.info(data);
                })
            }
        });
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
</script>
    </form>
</body>
</html>
