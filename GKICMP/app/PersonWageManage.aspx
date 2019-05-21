<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonWageManage.aspx.cs" Inherits="GKICMP.app.PersonWageManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link href="../appcss/bootstrap.css" rel="stylesheet" />
    <title>我的工资</title>
    <style type="text/css">
        .mui-table-view-cell {
            padding: 0px 15px;
        }

        .user_info h5 {
            text-align: center;
        }

        #page-wrapper {
            margin-bottom: 50px;
            margin-top: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <a class="mui-icon mui-icon-left-nav mui-pull-left goback""></a>
            <h1 class="mui-title">我的工资</h1>
        </header>
        <div id="page-wrapper">
            <div class="main-page">
                <div class="tables">
                    <div class="mui-content">
                        <div class="mui-table-view mui-table-view-striped mui-table-view-condensed">
                            <div class="mui-table-view-cell user_info">
                                <div class="mui-table">
                                    <div class="mui-table-cell mui-col-xs-7">
                                        <div id="d1" runat="server">
                                            <h5 class="mui-ellipsis">
                                                <asp:Literal ID="ltl_WYear" runat="server"></asp:Literal>年<asp:Literal ID="ltl_WMonth" runat="server"></asp:Literal>月
                                                <asp:Literal ID="ltl_TIDName" runat="server"></asp:Literal></h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="d2" runat="server">
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">岗位工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_PostWage" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">薪级工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_SalaryScale" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">教龄津贴</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Allowance" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">教护</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_TeachNursing" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">基础性绩效工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_BasicPay" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">奖励性绩效工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Rewarding" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">提租补贴</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_RentalFee" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">20%工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Serious" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">应发小计</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_ShouldWage" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">公积金</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Accumulation" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">失业保险</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Unemployment" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">医保费</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_MedicalFee" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">养老保险</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Insurance" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">工会费</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Union" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">考核工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_AssessWage" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">个人所得税</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Income" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">代扣小计</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_Withhold" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">实发工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_ActualWages" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                   
                                    <div class="mui-table">

                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">备注</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_WDesc" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="d3" runat="server">
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">基本工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_jbgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">岗位工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_gwgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">学历工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_xlgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">应发工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_yfgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">养老保险</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_ylbx" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">失业保险</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_sybx" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">住房公积金</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_zfgjj" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">上月绩效工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_syjxgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">大病救助</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_dbjz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">医保</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_yb" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">代扣小计</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_dkxj" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">工会扣除</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_ghkc" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="mui-table-view-cell">
                                    <div class="mui-table">
                                        <div class="mui-table-cell mui-col-xs-7">
                                            <h5 class="mui-ellipsis">实发工资</h5>
                                        </div>
                                        <div class="mui-table-cell mui-col-xs-5 mui-text-right">
                                            <span class="mui-h5">
                                                <asp:Literal ID="ltl_sfgz" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mui-table-view-cell user_info" runat="server">
                                <div class="mui-table">
                                    <div class="mui-table-cell mui-col-xs-7">
                                        <div id="d4" runat="server">
                                            <h5 class="mui-ellipsis">暂无数据</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
            <a href="AppMain.aspx" class="mui-tab-item  mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        <script src="/js/mui.min.js"></script>
        <script type="text/javascript" charset="utf-8">
            mui.init({
                swipeBack: true //启用右滑关闭功能
            });
            var slider = mui("#slider");
            slider.slider({
                interval: 3000
            });
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });
            mui('body').on('tap', '.goback', function () { window.history.go(-1) });
        </script>
    </form>
</body>
</html>


