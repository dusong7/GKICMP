<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairYJ.aspx.cs" Inherits="GKICMP.app.RepairYJ" %>

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
    <title>报修登记</title>
    <style>
        .mui-bar-nav ~ .mui-content .mui-pull-top-pocket {
            top: 80px;
        }
    </style>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false,
                type: "GET",
                data: "method=GetTransferUser",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        var intem = "";
                        for (var j in data.data) {
                            //intem += "<li class='mui-table-view-cell'><a class='mui-navigate-right' href='javascript:void(0)' id='" + data.data[j].value + "'>" + data.data[j].text + "</a></li>";
                            intem += "<div class='mui-input-row mui-radio mui-right'><label>" + data.data[j].text + "</label><input name='radio' value='" + data.data[j].value + "' type='radio'></div> ";
                        }
                        //$("#pullrefresh").append(intem);
                        $("#fresh").append(intem);
                    }
                    else {
                        //$("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
                    }
                }
            });

            //var list = document.querySelector('.mui-table-view.mui-table-view-radio');
            //list.addEventListener('selected', function (e) {
            //    //console.log("当前选中的为：" + e.detail.el.innerText);
            //    //console.log("当前选中的为：" + e.detail.el.firstChild.id);
            //    document.getElementById("hf_SelectedValue").value = e.detail.el.firstChild.id;
            //    document.getElementById("hf_SelectedText").value = e.detail.el.innerText;
            //});

            $("input[type='radio']").each(function () {
                $(this).click(function () {
                    document.getElementById("hf_SelectedValue").value = $(this).val();
                    //var a = $(this).prev("label").text();
                    document.getElementById("hf_SelectedText").value = $(this).prev("label").text();
                })
            });

        })
        function check() {
           // var val = $('input:radio[name="radio"]:checked').val();
            var val = document.getElementById("hf_SelectedValue").value;
            if (val == "") {
                alert("请选择人员");
                return false;
            }
            //alert(val);
            return true;
        }
    </script>
</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">报修管理</h1>
    </header>
    <div class="mui-content">

        <form class="mui-input-group" runat="server">
            <asp:HiddenField ID="hf_SelectedValue" runat="server" />
            <asp:HiddenField ID="hf_SelectedText" runat="server" />
            <div class="mui-content-padded w100">
                
                 <ul class="mui-table-view mui-table-view-radio" id="pullrefresh">
                     <%--  <li class="mui-table-view-cell">
                    <a class="mui-navigate-right" >Item 1</a>
                </li>
                <li class="mui-table-view-cell ">
                    <a class="mui-navigate-right">Item 2</a>
                </li>
                <li class="mui-table-view-cell">
                    <a class="mui-navigate-right">Item 3</a>
                </li>--%>
                    </ul>
                <div id="fresh">

                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>说明</label>
                        <asp:TextBox ID="txt_TransferDesc" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写说明"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="Button1" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClientClick=" return check()"  OnClick="btn_Sumbit_Click"/>
            </div>

        </form>
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
     <script>
       
         mui('body').on('tap', 'a', function () { document.location.href = this.href; });

    </script>

</body>
</html>

