<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppRepair.aspx.cs" Inherits="GKICMP.app.AppRepair" %>

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

</head>
<body>
    <header class="mui-bar mui-bar-nav">
        <span class="mui-icon mui-icon-left-nav mui-pull-left goback" onclick="javascript :history.back(-1);"></span>
        <h1 class="mui-title">报修管理</h1>
    </header>
    <div class="mui-content">
        <div style="padding: 10px 10px;">
            <div id="segmentedControl" class="mui-segmented-control">
                <a href="AppRepair.aspx" class="mui-control-item mui-active">报修登记</a>
                <a class="mui-control-item" href="RepairList.aspx">我的报修</a>
                <a href="PeopleRepail.aspx" class="mui-control-item">我受理的</a>
            </div>
        </div>
        <form class="mui-input-group" runat="server">
            <asp:HiddenField ID="hf_User" runat="server" />
            <asp:HiddenField ID="hf_FilePath" runat="server" />
            <asp:HiddenField ID="hf_PValue" runat="server" />
            <asp:HiddenField ID="hf_RepairContent" runat="server" />

            <div class="mui-input-row">
                <label>报修设备</label>
                <asp:TextBox ID="txt_RepairObj" runat="server" CssClass="mui-icon-location" placeholder="请说明报修设备"></asp:TextBox>
            </div>
            <div class="mui-input-row" id="selected">
                <label>受理部门</label>
                <%--<asp:DropDownList ID="ddl_Dep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Dep_SelectedIndexChanged" ></asp:DropDownList>--%>
                <asp:TextBox runat="server" name="shpdep" ID="txt_Dep" placeholder="请选择部门"></asp:TextBox>
                <asp:HiddenField ID="hf_Dep" runat="server" />
                <asp:Button ID="btn_SearchUser" runat="server" Style="display: none" OnClick="btn_SearchUser_Click" />
                <%-- <input id="Series" name="Series" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
            </div>
            <%--<div class="mui-input-row">--%>
            <%--<label>受理人员</label>--%>
            <%--<asp:DropDownList ID="ddl_User" runat="server"></asp:DropDownList>--%>
            <%--<asp:TextBox runat="server" name="shpuser" ID="txt_User" placeholder="请选择人员" Enabled="false"></asp:TextBox>--%>
            <%-- <asp:HiddenField ID="hf_User" runat="server" />--%>
            <%-- <input id="Series" name="Series" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
            <%--</div>--%>
            <div class="mui-input-row" style="display:none;">
                <label>维修单位</label>
                <%--<asp:DropDownList ID="ddl_Dep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Dep_SelectedIndexChanged" ></asp:DropDownList>--%>
                <asp:TextBox runat="server" name="shpdep" ID="txt_D" placeholder="请选择单位"></asp:TextBox>
                <asp:HiddenField ID="hf_D" runat="server" />
                <%-- <input id="Series" name="Series" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
            </div>
            <div class="mui-input-row">
                <label>图片</label>
                <div class="righttext">
                    <span class="mui-icon mui-icon-paperclip file" id="upimage">
                        <%--<input id="upimagebtn" type="file" accept="image/*,capture=camera" />--%>
                        <input id="upimagebtn" type="file" onchange="fj(this)" accept="image/*,capture=camera" />

                    </span>
                </div>
                <div id="textName" style="width: 100%; padding: 0px 15px; clear: both; line-height: 20px;">
                    <img id="show" style="display: none" src="" height="32px" width="32px" alt="" />
                </div>
                <asp:HiddenField ID="hf_file" runat="server" />
            </div>
            <div contenteditable="true" id="div_RepairContent" class="multipletext" placeholder="请说明故障内容，便于人员维修" runat="server"></div>
            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClientClick='return tj()' OnClick="btn_Sumbit_Click" />
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
    <asp:Literal ID="ltl_User" runat="server"></asp:Literal>
    
    <script>

        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET",
                    data: "method=GetDepAPPByRYFL",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_Dep');
                var userResult = doc.getElementById('txt_Dep');
                var userCustName = doc.getElementById('hf_Dep');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                        //document.getElementById("btn_SearchUser").click();
                        HtmlPursh(userCustName.value);
                    });
                }, false);


                var userPicker1 = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetSupp",
                    dataType: "json",
                    success: function (d) {
                        userPicker1.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_D');
                var userResult1 = doc.getElementById('txt_D');
                var userCustName1 = doc.getElementById('hf_D');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker1.show(function (items) {
                        userResult1.value = items[0].text;
                        userCustName1.value = items[0].value;
                    });
                }, false);

            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        function HtmlPursh(e) {
            $("div[name='depafter']").remove();
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false,
                type: "GET",
                data: "method=GetUserByType&dep=" + e,
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.result == 'true') {
                        var intem = "";
                        for (var j in data.data) {
                            //intem += "<li class='mui-table-view-cell'><a class='mui-navigate-right' href='javascript:void(0)' id='" + data.data[j].value + "'>" + data.data[j].text + "</a></li>";
                            intem += "<div class='mui-input-row mui-radio mui-right' name='depafter'><label>" + data.data[j].text + "</label><input name='radio' value='" + data.data[j].value + "' type='radio'></div> ";
                        }
                        //$("#pullrefresh").append(intem);

                        $("#selected").after(intem);
                    }
                    else {
                        //$("#pullrefresh").append("<div style='position: relative;padding: 8px 12px;text-align: center;'>暂无数据</div>");
                    }
                }
            });
        }

    </script>
</body>
</html>
<script>
    var baseimage = '';
    $('#upimagebtn').change(function () {
        uploadBtnChange();

    });
    function uploadBtnChange() {
        var scope = this;
        if (window.File && window.FileReader && window.FileList && window.Blob) {
            //获取上传file
            var filefield = document.getElementById('upimagebtn'),
                file = filefield.files[0];
            //获取用于存放压缩后图片base64编码
            var compressValue = document.getElementById('compressValue');
            processfile(file, compressValue);
        } else {
            alert("此浏览器不完全支持压缩上传图片");
        }
    }

    function processfile(file) {
        //var reader = new FileReader();

        ////reader.readAsDataURL(file);
        ////reader.readAsArrayBuffer(file);
        //reader.onload = function (event) {
        //    var blob = new Blob([event.target.result]);
        //    window.URL = window.URL || window.webkitURL;
        //    var blobURL = window.URL.createObjectURL(blob);
        //    var image = new Image();
        //    image.src = blobURL;
        //   // preview.src = reader.result;
        //    image.onload = function () {
        //        var resized = resizeMe(image);
        //        //compressValue.value = resized;
        //        baseimage = resized;
        //       // upfile();
        //    }
        //    //if (baseimage != '')
        //    //    upfile();

        //};
        //reader.readAsDataURL(file);


        var reader = new FileReader();
        reader.onload = function (event) {

            var blob = new Blob([event.target.result]);
            window.URL = window.URL || window.webkitURL;
            var blobURL = window.URL.createObjectURL(blob);
            $("#show").css('display', 'block');
            var preview = document.getElementById("show");
            preview.src = blobURL;
            var image = new Image();
            image.src = blobURL;
            image.onload = function () {
                var resized = resizeMe(image);
                baseimage = resized;
            }
        };
        reader.readAsArrayBuffer(file);
    }

    function resizeMe(img) {

        var max_width = 1280;
        var max_height = 1024;

        var canvas = document.createElement('canvas');
        var width = img.width;
        var height = img.height;
        ///alert("width:" + width + ";height:" + height + "  7");
        if (width > height) {
            if (width > max_width) {
                height = Math.round(height *= max_width / width);
                width = max_width;
                //  alert("width:" + width + ";height:" + height+"  8");
            }
        } else {
            if (height > max_height) {
                width = Math.round(width *= max_height / height);
                height = max_height;
                //console.log("width:" + width + ";height:" + height + "  9");
                // alert("width:" + width + ";height:" + height + "  9");
            }
        }

        canvas.width = width;
        canvas.height = height;

        var ctx = canvas.getContext("2d");
        ctx.drawImage(img, 0, 0, width, height);
        //压缩率
        return canvas.toDataURL("image/jpeg", 0.5);


        //var ctx = canvas.getContext("2d");
        //ctx.drawImage(img, 0, 0, img.width, img.height);
        ////压缩率
        //return canvas.toDataURL("image/jpeg", 0.5);
    }
    function upfile() {

        $.ajax({
            url: "../ashx/file.ashx",
            type: "POST",
            data: { 'imgBase64': baseimage, "Name": name },
            dataType: 'json',
            async: false,
            cache: false,
            success: function (json) {
                //alert(json);
                document.getElementById("hf_FilePath").value = json.path;
            },
            error: function () {
                //console.log(baseimage);
                alert('图片保存失败，请重新上传');
                a = false;
                a = false;
            }
        });


        //var a = parseInt(Math.random() * 8999 + 1000);
        //var name = new Date().Format("yyyyMMddHHmmss") + a;
        //document.getElementById("hf_FilePath").value = name;

        //// console.log(baseimage);
        //$.ajax({
        //    url: "../ashx/file.ashx",
        //    type: "POST",
        //    data: { 'imgBase64': baseimage, "Name": name },
        //    dataType: 'json',
        //    async: true,
        //    cache: false,
        //    success: function (json) {
        //        // alert(json);
        //        //document.getElementById("hf_FilePath").value = json.path;
        //    },
        //    error: function () {
        //        // console.log(baseimage);
        //        //alert('图片保存失败，请重新上传');
        //        // a= false;
        //    }
        //});
    }
</script>
<script type="text/javascript">
    function tj() {
        var a = true;
        $("#hf_RepairContent").val($("#div_RepairContent").text());
        var val = $('input:radio[name="radio"]:checked').val();
        if (typeof (val) == "undefined") {
            alert("请选择受理人");
            return false;
        }
        if (baseimage != "") {
            $.ajax({
                url: "../ashx/file.ashx",
                type: "POST",
                data: { 'imgBase64': baseimage, "Name": name },
                dataType: 'json',
                async: false,
                cache: false,
                success: function (json) {
                    // alert(json);
                    document.getElementById("hf_FilePath").value = json.path;
                },
                error: function () {
                    console.log(baseimage);
                    alert('图片保存失败，请重新上传');
                    a = false;
                    a = false;
                }
            });
        }
        document.getElementById("hf_User").value = val;
        return a;
    }
    function fj(obj) {
        //var arr = $(obj).val().split('\\');
        //document.getElementById('textName').innerHTML = arr[arr.length - 1];
        //$("#hf_file").val(arr[arr.length - 1]);
        //var arr = $(obj).val().split('\\');
        ////document.getElementById('textName').innerHTML = arr[arr.length - 1];
        //$("#hf_file").val(arr[arr.length - 1]);
        ////var preview = document.querySelector('img');
        //var preview = document.getElementById("show");
        //var file = document.querySelector('input[type=file]').files[0];
        //var reader = new FileReader();

        //reader.onloadend = function () {
        //    preview.src = reader.result;
        //}

        //if (file) {
        //    $("#show").css('display', 'block');
        //    reader.readAsDataURL(file);
        //} else {
        //    $("#show").css('display', 'none');
        //    preview.src = "";
        //}
    }

    Date.prototype.Format = function (fmt) { //author: meizz   
        var o = {
            "M+": this.getMonth() + 1, //月份   
            "d+": this.getDate(), //日   
            "H+": this.getHours(), //小时   
            "m+": this.getMinutes(), //分   
            "s+": this.getSeconds(), //秒   
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
            "S": this.getMilliseconds() //毫秒   
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }
</script>
