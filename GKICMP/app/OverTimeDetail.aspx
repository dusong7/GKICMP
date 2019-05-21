<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeDetail.aspx.cs" Inherits="GKICMP.app.OverTimeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>加班详情</title>

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
            <h1 class="mui-title">加班详情</h1>
        </header>
        <div class="mui-content" style="background:#fff">
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
					.mui-col-xs-12 {*zoom:1;display:flex;}
			 </style>
       <li class="mui-table-view-cell litop">加班信息</li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                         <div class="xql"><b>申请人</b><s></s></div>
                        <asp:Label ID="ltl_ApplyUser" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>类型</b><s></s></div>
                        <asp:Label ID="ltl_OType" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>加班时长</b><s></s></div>
                        <asp:Label ID="ltl_ODays" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>参与人</b><s></s></div>
                        <asp:Label ID="ltl_UsersName" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>开始日期</b><s></s></div>
                       <%-- <asp:Literal runat="server" ID="ltl_BeginDate"></asp:Literal>--%>
                         <asp:Label runat="server" ID="ltl_BeginDate"></asp:Label>
                    </div>
                </li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>结束日期</b><s></s></div>
                        <asp:Label ID="ltl_EndDate" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>加班事由</b><s></s></div>
                        <asp:Label ID="ltl_OMark" runat="server" Text=""></asp:Label>
                    </div>
                </li>
        <li class="mui-table-view-cell litop">审核流程</li>
                <li class="mui-table-view-cell">
                    <div class="mui-col-xs-12">
                        <div class="xql"><b>状态</b><s></s></div>
                        <asp:Label ID="ltl_OState" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                
            </ul>
              <div id="oacontent" class="listname" style="border:1px solid #e2e2e2; margin:5px auto; padding:10px">
                <ul>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <li style="height:auto">
                                <span style="max-width:100%; width:100%;font-size:12px;">
                                    <%-- <%#Eval("RealName").ToString().Split(',').Length>1?Eval("AuditResult").ToString()!="1"? (Eval("AuditName")+"   审核"):(Eval("RealName")):(Eval("RealName"))%>
                                    <span style="font-size:12px; max-width:100%; float:right; padding-right:0px">
                                    <%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>&nbsp;&nbsp;
                                        <%#Eval("AuditDate","{0:yyyy-MM-dd HH:mm}")%>
                                    </span>--%>
                                        
                                        <%#Eval("RealName").ToString().Split(',').Length>1 ? Eval("AuditResult").ToString()!="1" ? (Eval("RealName")+"<br/>"+(Eval("AuditName")+"&nbsp;&nbsp;审核")) :(Eval("RealName")):(Eval("RealName"))%>
                                       
                                        <span style="font-size: 12px; max-width: 100%; float: right; padding-right: 47px">
                                            <%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>&nbsp;&nbsp;
                                            <%#Eval("AuditDate","{0:yyyy-MM-dd HH:mm}")%>
                                        </span>

                                </span>
                            </li>
                            <li style="font-size:12px">
                                 <%#Eval("AuditMark")%>
                                
                               
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="clear: both"></div>
                </ul>
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

