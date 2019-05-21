<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAuditEdit.aspx.cs" Inherits="GKICMP.app.LeaveAuditEdit" %>

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
    <title>请假审核</title>
</head>
<body>
    <form id="form1" runat="server">
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">
                <asp:Label ID="lbl_title" runat="server"></asp:Label></h1>
        </header>
        <div class="mui-content" style="background: #fff">
            <div class="mui-content-padded w100">
                <ul class="mui-table-view">
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            <asp:Label ID="lbl_User" runat="server"></asp:Label>人：<asp:Label ID="lbl_LeaveUser" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li class="mui-table-view-cell" id="lx" runat="server"  >
                        <div class="mui-col-xs-12">
                            类型：<asp:Label ID="lbl_LType" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            开始日期：<asp:Literal runat="server" ID="lbl_BeginDate"></asp:Literal>
                        </div>
                    </li>
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            结束日期：<asp:Label ID="lbl_EndDate" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            <asp:Label ID="lbl_Num" runat="server"></asp:Label>天数：<asp:Label ID="lbl_LeaveDays" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                  
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            课程是否已安排：<asp:Label ID="lbl_IsOK" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            <asp:Label ID="lbl_UserSeason" runat="server"></asp:Label>事由：<asp:Label ID="lbl_LeaveMark" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                      <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            状态：<asp:Label ID="lbl_LeaveState" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                </ul>
                <div id="oacontent" class="listname" style="border: 1px solid #e2e2e2; margin: 5px auto; padding: 10px">
                    <ul>
                        <asp:Repeater runat="server" ID="rp_List">
                            <ItemTemplate>
                                <li style="height:auto">
                                    <span style="max-width: 100%; width: 100%;font-size:12px;">
                                      <%--  <%#Eval("RealName") %>
                                        <span style="font-size: 12px; max-width: 100%; float: right; padding-right: 0px">
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



                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>审核结果</label>
                        <asp:TextBox ID="txt_AuditResult" runat="server" CssClass="mui-icon-location" placeholder="请选择"></asp:TextBox>
                        <asp:HiddenField ID="hf_AuditResult" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>审核意见</label>
                        <asp:TextBox ID="txt_AuditMark" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写审核意见"></asp:TextBox>
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
        <asp:Literal ID="ltl_User" runat="server"></asp:Literal>
    </form>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);

                userPicker.setData(
                [
                    { value: '2', text: '通过' },
                    { value: '3', text: '不通过' }
                ]
            );
                var showUserPickerButton = doc.getElementById('txt_AuditResult');
                var userResult = doc.getElementById('txt_AuditResult');
                var userCustName = doc.getElementById('hf_AuditResult');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                    });
                }, false);

            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>

