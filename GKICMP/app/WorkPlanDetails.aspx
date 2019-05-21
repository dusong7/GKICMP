<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanDetails.aspx.cs" Inherits="GKICMP.app.WorkPlanDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>计划详情</title>

    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/oa_iconfont.css" rel="stylesheet" />

    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />

    <link href="../appcss/new_file.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server" class="mui-input-group">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_SelectedText" runat="server" />
        <asp:HiddenField ID="hf_UID" runat="server" />

            <header class="mui-bar mui-bar-nav">
			    <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
			    <h1 class="mui-title">计划详情</h1>
		    </header>

      <div class="mui-content">
			
            <ul class="mui-table-view">
                            <li class="mui-table-view-cell">
					            <div class="mui-col-xs-12">
						             学年度/学期：<asp:Label ID="lbl_ETitle" runat="server" Text=""></asp:Label>
					            </div>
				            </li>
				            <li class="mui-table-view-cell">
					            <div class="mui-col-xs-12">
						             部门：<asp:Label ID="ltl_DepID" runat="server" Text=""></asp:Label>
					            </div>
				            </li>
                            <li class="mui-table-view-cell">
					            <div class="mui-col-xs-12">
						             责任人：<asp:Literal runat="server" ID="lbl_SendDate"></asp:Literal>
					            </div>
				            </li>
                             <li class="mui-table-view-cell">
					             <div class="mui-col-xs-12">
						             参与人：<asp:Label ID="ltl_AllUsers" runat="server" Text=""></asp:Label>
					             </div>
				              </li>
                           <li class="mui-table-view-cell">
					            <div class="mui-col-xs-12">
						             内容：<asp:Label ID="lbl_EContent" runat="server" Text=""></asp:Label>
					            </div>
				            </li>
                             <li class="mui-table-view-cell">
					             <div class="mui-col-xs-12">
						             开始时间：<asp:Label ID="ltl_BeginDate" runat="server" Text=""></asp:Label>
						          </div>
				             </li>
                             <li class="mui-table-view-cell">
					              <div class="mui-col-xs-12">
						               结束时间：<asp:Label ID="ltl_EndDate" runat="server" Text=""></asp:Label>
					              </div>
				             </li>
			</ul>

            <div class="mui-button-row">
				 <button type="button" class="mui-btn mui-btn-success" onclick="javascript: window.history.back(-1);">返回</button>
                 <asp:Button ID="btn_YY" runat="server" Text="完成" class="mui-btn mui-btn-primary iconfont icon-chuanyue" OnClick="btn_YY_Click"/>
            </div>

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
        
  </form>

</body>
</html>
