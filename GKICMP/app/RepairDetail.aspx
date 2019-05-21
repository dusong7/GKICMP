<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairDetail.aspx.cs" Inherits="GKICMP.app.RepairDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>报修详情</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />
    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <style>
        .mui-content > .mui-table-view:first-child {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="mui-input-group">
         <asp:HiddenField ID="hf_Images" runat="server" />
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">报修详情</h1>
        </header>

        <div class="mui-content">
            <ul class="mui-table-view">

                 <style>		
                    .mui-table-view-cell{ margin: 0;padding: 12px;}
					.mui-table-view-cell span{color: #333;font-weight: normal;display: block;width: 67%;position: relative; box-sizing: border-box;padding: 12px 10px;margin-top: -12px;white-space:pre-wrap;word-wrap : break-word;margin-bottom: -12px;flex:1;}
					.mui-table-view-cell .xql{white-space:pre-wrap;word-wrap : break-word;width: 32%;height:auto;}
					.mui-table-view-cell .xql b{vertical-align:middle;display:inline-block;font-weight: normal;}
					.mui-table-view-cell .xql s{ vertical-align:middle;display:inline-block;height:100%;}
					.mui-table-view-cell span:before{position: absolute;left: 0;top:0px;display: block;width: 1px; height: 100%; background: #e4e3e6;content: '';min-height: 45px;}
					.mui-table-view-cell:nth-child(odd){background: #fbfafa}
					.litop{background: #fff;padding: 10px 12px 10px;font-weight: 600;color: #48bd81;}
					.litop:after{background-color:#3fa96b;height: 2px}
					.mui-col-xs-12:after {  content:"\200B"; display:block; height:0; clear:both; } 
					.mui-col-xs-12 {*zoom:1;display:flex;}				</style>
       <li class="mui-table-view-cell litop">报修信息</li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                         <div class="xql"><b>报修设备</b><s></s></div>
                        <asp:Label ID="lbl_RepairObj" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>故障描述</b><s></s></div>
                        <asp:Label ID="lbl_RepairContent" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                         <div class="xql"><b>报修人</b><s></s></div>
                        <asp:Label ID="lbl_CreaterUser" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                 <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                         <div class="xql"><b>报修日期</b><s></s></div>
                        <asp:Label ID="lbl_ARDate" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                       <%-- 受理部门：<asp:Literal runat="server" ID="lbl_DutyDep"></asp:Literal>--%>
                         <div class="xql"><b>受理部门</b><s></s></div>
                        <asp:Label runat="server" ID="lbl_DutyDept"></asp:Label>
                        <asp:Label runat="server" ID="lbl_DutyUser" ></asp:Label>
                    </div>
                </li>
               <%-- <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql">本校受理人</div>
                        <asp:Label ID="lbl_DutyUser" runat="server" Text=""></asp:Label>
                    </div>
                </li>--%>

       <li class="mui-table-view-cell litop">维修部门</li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                         <div class="xql"><b>维修单位</b><s></s></div>
                         <asp:Label ID="lbl_Sdid" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>联系人</b><s></s></div>
                        <asp:Label ID="lbl_LinkUser" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>联系方式</b><s></s></div>
                        <asp:Label ID="lbl_LinkNo" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>移交人</b><s></s></div>
                        <asp:Label ID="lbl_TransferName" runat="server"></asp:Label>
                    </div>
                </li>
                 <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>移交说明</b><s></s></div>
                        <asp:Label ID="lbl_TransferDesc" runat="server"></asp:Label>
                    </div>
                </li>
  <li class="mui-table-view-cell litop">维修结果</li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>状态</b><s></s></div>
                        <asp:Label ID="lbl_ARState" runat="server"></asp:Label>
                    </div>
                </li>
                 
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>完成日期</b><s></s></div>
                        <asp:Label ID="lbl_CompDate" runat="server" Text=""></asp:Label>
                    </div>
                </li>


                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>完成说明</b><s></s></div>
                        <asp:Label ID="lbl_CompDesc" runat="server" Text=""></asp:Label>
                    </div>
                </li>


                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>附件</b><s></s></div>
                        <asp:Image ID="Image1" class="pimg" runat="server" Width="150px" Height="100px" Visible="false" />
                       <%-- <img id="SImage" class="pimg" width="100px" height="100px" />--%>
                    </div>
                    <div id="outerdiv" style="position:fixed;top:0;left:0;background:rgba(0,0,0,0.7);z-index:2;width:100%;height:100%;display:none;">
                       <div id="innerdiv" style="position:absolute;">
                           <img id="bigimg" style="border:5px solid #fff;" src="" />
                       </div>
                   </div>
                </li>

            </ul>

            <%-- <div class="mui-button-row">
                <button type="button" class="mui-btn mui-btn-success" onclick="javascript: window.history.back(-1);">返回</button>
            </div>--%>
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
            <%--  <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        <script src="../js/mui.min.js"></script>
        <script type="text/javascript" charset="utf-8">
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



<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js" type="text/javascript"></script>
<script type="text/javascript" charset="utf-8">
    $(function () {
        $(".pimg").click(function () {
            var _this = $(this);//将当前的pimg元素作为_this传入函数
            imgShow("#outerdiv", "#innerdiv", "#bigimg", _this);
        });
    });
    function imgShow(outerdiv, innerdiv, bigimg, _this) {
        var src = _this.attr("src");//获取当前点击的pimg元素中的src属性
        //var src = $("#hf_Images").val();;//获取当前点击的pimg元素中的src属性
        $(bigimg).attr("src", src);//设置#bigimg元素的src属性

        /*获取当前点击图片的真实大小，并显示弹出层及大图*/
        $("<img/>").attr("src", src).load(function () {
            var windowW = $(window).width();//获取当前窗口宽度
            var windowH = $(window).height();//获取当前窗口高度
            var realWidth = this.width;//获取图片真实宽度
            var realHeight = this.height;//获取图片真实高度
            var imgWidth, imgHeight;
            var scale = 0.8;//缩放尺寸，当图片真实宽度和高度大于窗口宽度和高度时进行缩放

            if (realHeight > windowH * scale) {//判断图片高度
                imgHeight = windowH * scale;//如大于窗口高度，图片高度进行缩放
                imgWidth = imgHeight / realHeight * realWidth;//等比例缩放宽度
                if (imgWidth > windowW * scale) {//如宽度扔大于窗口宽度
                    imgWidth = windowW * scale;//再对宽度进行缩放
                }
            } else if (realWidth > windowW * scale) {//如图片高度合适，判断图片宽度
                imgWidth = windowW * scale;//如大于窗口宽度，图片宽度进行缩放
                imgHeight = imgWidth / realWidth * realHeight;//等比例缩放高度
            } else {//如果图片真实高度和宽度都符合要求，高宽不变
                imgWidth = realWidth;
                imgHeight = realHeight;
            }
            $(bigimg).css("width", imgWidth);//以最终的宽度对图片缩放

            var w = (windowW - imgWidth) / 2;//计算图片与窗口左边距
            var h = (windowH - imgHeight) / 2;//计算图片与窗口上边距
            $(innerdiv).css({ "top": h, "left": w });//设置#innerdiv的top和left属性
            $(outerdiv).fadeIn("fast");//淡入显示#outerdiv及.pimg
        });

        $(outerdiv).click(function () {//再次点击淡出消失弹出层
            $(this).fadeOut("fast");
        });
    }
</script>



    </form>

</body>
</html>
