<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoCardApplicationAuditEdit.aspx.cs" Inherits="GKICMP.app.NoCardApplicationAuditEdit" %>

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
    <title>我的审核</title>
</head>
<body>
    <form id="form1" runat="server">
          <asp:HiddenField ID="hf_NoCardAuditDesc" runat="server" />
        <header class="mui-bar mui-bar-nav">
            <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
            <h1 class="mui-title">我的审核</h1>
        </header>
        <div class="mui-content" style="background: #fff">
            <div class="mui-content-padded w100">
                <ul class="mui-table-view">
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            补卡申请人：<asp:Label ID="lbl_NoCardApplyUser" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            补卡时间点：<asp:Literal runat="server" ID="lbl_NoCardApplyDate"></asp:Literal>
                        </div>
                    </li>

                    <li class="mui-table-view-cell">
                        <div class="mui-col-xs-12">
                            补卡说明：<asp:Literal runat="server" ID="ltl_NoCardApplyDesc"></asp:Literal>
                        </div>
                    </li>
                </ul>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>审核结果</label>
                        <asp:TextBox ID="txt_NoCardState" runat="server" CssClass="mui-icon-location" placeholder="请选择"></asp:TextBox>
                        <asp:HiddenField ID="hf_NoCardState" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <div contenteditable="true" style="height: 100px;" id="div_NoCardAuditDesc" class="multipletext" placeholder="请在此填写审核意见" runat="server"></div>
                    </div>
                </div>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" OnClientClick="tj()" />
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
    </form>

<script type="text/javascript">
    function tj() {
        $("#hf_NoCardAuditDesc").val($("#div_NoCardAuditDesc").text());
    }
</script>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);

                userPicker.setData(
                [
                    { value: '1', text: '通过' },
                    { value: '2', text: '驳回' }
                ]
            );
                var showUserPickerButton = doc.getElementById('txt_NoCardState');
                var userResult = doc.getElementById('txt_NoCardState');
                var userCustName = doc.getElementById('hf_NoCardState');
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

