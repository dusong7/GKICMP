<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassScheduleAll.aspx.cs" Inherits="GKICMP.educationals.ClassScheduleAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script>
        function dr() {
            return openbox('A_id', 'ClassScheduleImport.aspx', '', 1100, 500, 3);
        }
    </script>
    <style>
        .listcent {
            min-width: 1048px;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 2px 4px;
        }

        table th {
            text-align: center;
        }

        #goodsList {
            padding: 0;
            overflow-y: scroll;
        }

        .table-bordered > thead > tr > th, .table-bordered > thead > tr > td {
            border-bottom-width: 1px;
        }

        .fixTable thead {
            background-color: #fff;
        }

        .fixTable {
            width: auto;
        }

        .content td {
            min-width: 30px;
            Text-align: center;
            border-left: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            padding: 2px 4px;
        }

        .content .contd1 {
            border-left: 0px;
            color: #48bd81;
            font-weight: bold;
        }

        .content .contd2 {
            border-left: 2px solid #cdcecf;
        }

        .content .contd3 {
            color: #fff;
            background: #ef5d5d;
        }

        .conth1 {
            background: #efefef;
            height: 40px;
            line-height: 40px;
            border-bottom: 1px solid #cdcecf;
            color: #48bd81;
        }

        .conth2 {
            background: #efefef;
            border-left: 2px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            color: #48bd81;
        }

        .conth3 {
            background: #f5f5f5;
            border-left: 2px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            color: #48bd81;
        }

        .showteacher {
            background: #48bd81;
        }


        .showteacherback {
            background: #fff;
        }

        #lbl td:hover {
            background: #C4C6C8;
        }

        #lbl .content .contd3:hover {
            color: #fff;
            background: #ef5d5d;
        }

        #menu {
            width: 100px;
            padding: 5px;
            font-size: 14px;
            border: #EEE 1px solid;
            margin-top: 0px;
            margin-left: 5px;
        }

            #menu a {
                font-size: 14px;
                color: black;
                text-decoration: none;
            }

            #menu h3 {
                font-size: 12px;
            }

            #menu ul {
                background: url("../images/ul-bg.gif") repeat-y 9px 5px;
                overflow: hidden;
            }

                #menu ul li {
                    padding: 0px 0 0px 15px;
                    line-height: 30px;
                    background: url("../images/green_tree-ul-li.png") no-repeat 9px -30px;
                }

                    #menu ul li ul {
                        /*display: none;*/
                    }

                    #menu ul li em {
                        cursor: pointer;
                        display: inline-block;
                        width: 18px;
                        float: left;
                        height: 18px;
                        margin-left: -14px;
                        background: url("../images/green_tree-ul-li.png") no-repeat -25px 5px;
                    }

                        #menu ul li em.off {
                            background-position: -13px -8px;
                        }

                    #menu ul li#end {
                        background-color: #F9F9F9;
                    }

                #menu ul.off {
                    display: block;
                }


        .myMenu {
            border: 1px solid #D8D8D8;
            background: #fff;
            padding: 10px 0px;
            box-shadow: #939393 3px 3px 3px;
        }

            .myMenu li {
                border-bottom: 1px dashed #f3e6e6;
                width: 100px;
                text-indent: 20px;
                line-height: 30px;
            }


                .myMenu li:hover {
                    background: #e8e5e5;
                }

                .myMenu li a {
                    display: block;
                }

                .myMenu li:hover a {
                    color: #fff;
                }

        .add li {
            width: 210px;
        }

        .add .select {
            cursor: pointer;
        }

        .add .noselect {
            color: #bdbcbc;
        }

            .add .noselect:hover {
                color: #bdbcbc;
                background: none;
            }

        #btn_Quote, #btn_PutKB {
            width: 75px;
            height: 27px;
            border: none;
            background-color: #4abd7a;
            padding: 0px;
            margin: 0px;
            color: #fff;
            font-size: 14px;
            text-align: left;
            text-indent: 10px;
            line-height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <audio id="tryListen" style="display: none;">
        </audio>
        <asp:HiddenField ID="hf_wdzw" runat="server" />
        <asp:Button ID="btn_Search1" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="全部课表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="40">学年度：</td>
                        <td width="180">
                            <asp:DropDownList ID="ddl_EYear" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="40">学期：</td>
                        <td width="280">
                            <asp:DropDownList ID="ddl_Term" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Searchs_Click" />
                            &nbsp;&nbsp;      &nbsp;&nbsp;       &nbsp;&nbsp;     &nbsp;&nbsp;      &nbsp;&nbsp;       &nbsp;&nbsp;
                            <asp:Button ID="btn_PutKB" runat="server" Text="导入课表" OnClientClick="return dr()" />
                            &nbsp;&nbsp;      &nbsp;&nbsp;       &nbsp;&nbsp;     &nbsp;&nbsp;      &nbsp;&nbsp;       &nbsp;&nbsp;
                            <asp:Button ID="btn_Quote" runat="server" Text="引用上学期课表" OnClick="btn_Quote_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="dv1" runat="server" style="text-align: center; height: 16px; margin-top: 10px;">
            <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
        </div>
        <div class="listcent pad0" style="position: relative;">
            <div style="text-align: center; padding-bottom: 30px; overflow-x: auto" id="goodsList">
                <asp:Label ID="lbl" runat="server"></asp:Label>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" style="position: absolute; bottom: 0px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Button ID="btn_OutPut" runat="server" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
<input type="hidden" id="scid" />
<input type="hidden" id="d" value="0" />
<input type="hidden" id="tid" value="wu" />
<ul id="menu" class="myMenu" style="position: absolute; visibility: hidden;">
    <li><a href="javascript:;" onclick="CellText()">调课</a></li>
    <li><a href="javascript:;" onclick="Delete()">删除</a></li>

</ul>


<ul id="add" class="myMenu add" style="position: absolute; visibility: hidden;">
</ul>


<script type="text/javascript">

    $(document).ready(function () {
        $("#goodsList").height(document.documentElement.clientHeight - 270);
        var $fixTable = $('#goodsList .fixTable');
        $('#goodsList').scroll(function () {
            var id = '#' + this.id;
            var scrollTop = $(id).scrollTop() || $(id).get(0).scrollTop,
                style = {
                    'position': 'absolute',
                    'left': '0',
                    'right': '0',
                    'top': '0px'
                };
            var tdwidth = $("#textTable").width() - 17;
            if ($fixTable.length) {
                (scrollTop === 0) ? $fixTable.addClass('hidden') : $fixTable.removeClass('hidden');
                $fixTable.css(style);
            } else {
                var html = $(id + ' .scrollTable thead').get(0).innerHTML;
                var table = $('<table border="0" cellpadding="0" cellspacing="0" class="content table table-bordered fixTable"><thead>' + html + '</thead></table>');
                table.css(style);
                $(id).append(table);
                $fixTable = $(this).find('.fixTable');
                var tdNum = $("#testTbody tr td").size() + 1;
                for (var i = 1; i < tdNum; i++) {
                    $(".fixTable td:nth-child(" + i + ")").width($("#testTbody td:nth-child(" + i + ")").width());
                }
                //$(".fixTable td").width($("#testTbody td:nth-child(3)").width());
                //$(".fixTable td:nth-child(1)").width($("#testTbody td:nth-child(1)").width());
                //$(".fixTable td.contd2").width($("#testTbody td.contd2").width());
            }
        });
    })
    $(window).resize(function () {
        var tdNum = $("#testTbody tr td").size() + 1;
        for (var i = 1; i < tdNum; i++) {
            $(".fixTable td:nth-child(" + i + ")").width($("#testTbody td:nth-child(" + i + ")").width());
        }
    });
</script>

<script>
    document.getElementById("lbl").oncontextmenu = new Function("event.returnValue=false;");

    function showteacher(obj) {
        document.getElementById("add").style.visibility = "hidden";
        var css = "";
        var count = 0;
        var teachid = $(obj).attr("teacher");
        var teachername = $(obj).attr("teachername");
        var table = $(obj).parent().parent();
        if ($("#tid").val() != teachid) {
            if ($("#tid").val() == "wu") {
                if ($("#d").val() == 0) {
                    css = "showteacher";
                    $("#d").val(1);
                }
                $("#tid").val(teachid);
            }
            else {
                $("td").removeClass("showteacher");
                $("#tid").val(teachid);
                $("#d").val(1);
                css = "showteacher";
            }
        }
        else {
            $("td").removeClass("showteacher");
            if ($("#d").val() == 1) {
                $("#d").val(0);
            }
            $("#tid").val("wu");
        }
        for (var i = 0; i < table.children("tr").length; i++) {
            var dddd = table.children("tr").length;
            var trobj = table.children("tr")[i];
            for (var j = 1; j < $(trobj).children("td").length; j++) {
                var tdobj = $(trobj).children("td")[j];
                var aaaa = $(tdobj).attr("teacher");
                var bbbb = $("#tid").val();
                var cccc = $("#d").val();
                if ($(tdobj).attr("teacher") == $("#tid").val() && $("#d").val() == 1) {
                    //$(tdobj).attr("class", css);
                    $(tdobj).addClass(css);
                    count += 1;
                }
            }
        }
        if ($("#d").val() == 1) {
            var text = teachername + "共有" + count + "节课";
            document.getElementById("lbl_name").innerHTML = text;
            document.getElementById("tryListen").src = "../ashx/SwapCourseHandler.ashx?method=Read&aa=" + text;
            $("#tryListen")[0].play();
        }
        else {
            document.getElementById("lbl_name").innerHTML = "";
        }
        document.onclick = function (event) {
            //当左键点击的时候隐藏右键菜单
            document.getElementById("menu").style.visibility = "hidden";
        }
    }

    function showmenu(obj) {
        document.getElementById("add").style.visibility = "hidden";
        var e = event || window.event;
        var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft;
        var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
        var x = e.pageX || e.clientX + scrollX;
        var y = e.pageY || e.clientY + scrollY;
        var add = document.getElementById("menu");
        if (document.body.scrollWidth - x > 100) {
            add.style.left = x + "px";
        }
        else {
            add.style.left = x - 100 + "px";
        }
        add.style.top = y + "px";
        menu.style.visibility = "visible";
        $("#scid").val($(obj).attr("scid"));
        document.onclick = function (event) {
            //当左键点击的时候隐藏右键菜单
            document.getElementById("menu").style.visibility = "hidden";
            document.getElementById("add").style.visibility = "hidden";
        }
    }
    function CellText() {
        var scid = $("#scid").val();
        document.getElementById("menu").style.visibility = "hidden";
        if (scid != "" && scid != null) {
            //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
            return openbox('A_id', 'SelectCourse.aspx', 'scid=' + scid, 700, 500, 49);
        }
    }
    function Delete() {
        document.getElementById("menu").style.visibility = "hidden";
        var scid = $("#scid").val();
        if (scid != "" && scid != null) {
            var aresult = true;
            $.ajax({
                url: "../ashx/SwapCourseHandler.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=Del&scid=" + scid,
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = false;
                    }
                }
            });
            if (!aresult) {
                alert("系统提示：删除失败");
                return;
            }
            else {
                $.ajax({
                    url: "../ashx/SwapCourseHandler.ashx",
                    cache: false,
                    type: "get",
                    async: false,
                    data: "method=SEL&scid=" + scid,
                    dataType: "json",
                    success: function (data) {
                        if (data.result = true) {
                            for (var j = 0; j < data.data.length; j++) {
                                var str = "";
                                $("#" + data.data[j].id).remove();
                                //str = "<td id=" + data.data[j].Position + " onclick=\"CellText(this.innerHTML)\">" + data.data[j].CourseRepeat + " <br><span style=\"color:red\">" + data.data[j].TeacherRepeat + "</span><label style=\"display:none;\">:a:c" + data.data[j].SCID + ":b:c</label></td>";
                                if (data.data[j].id.substr(data.data[j].id.length - 1, 1) == 1) {
                                    str = "<td id=" + data.data[j].id + " class=\"contd2\" oncontextmenu=\"showadd(" + data.data[j].ClaID + "," + data.data[j].Position + ")\"></td>";
                                    $("#" + ((parseInt(data.data[j].id)) + 1)).before(str);
                                }
                                else {
                                    str = "<td id=" + data.data[j].id + " oncontextmenu=\"showadd(" + data.data[j].ClaID + "," + data.data[j].Position + ")\"></td>";
                                    $("#" + ((parseInt(data.data[j].id)) - 1)).after(str);
                                }
                                $("#menu").attr("style", "display:none;");
                                $("#menu").attr("style", "display:block;position: absolute;");
                            }
                        }
                    }
                })
            }
        }
    }

    function showadd(claid, pos) {
        document.getElementById("menu").style.visibility = "hidden";
        var e = event || window.event;
        var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft;
        var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
        var x = e.pageX || e.clientX + scrollX;
        var y = e.pageY || e.clientY + scrollY;
        var add = document.getElementById("add");
        if (document.body.scrollWidth - x > 210) {
            add.style.left = x + "px";
        }
        else {
            add.style.left = x - 210 + "px";
        }
        add.style.top = y + "px";  //
        add.style.visibility = "visible";
        var str = "";
        if (claid > 0 && pos != "") {
            var result = false;
            $.ajax({
                url: "../ashx/SwapCourseHandler.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=ShowAdd&claid=" + claid + "&pos=" + pos,
                dataType: "json",
                success: function (data) {
                    //alert(JSON.stringify(data));
                    if (data.result == 'true') {
                        for (var i = 0; i < data.data.length; i++) {
                            if (data.data[i].Flag == 1) {
                                str += "<li type=\"button\"  onclick='add(\"" + data.data[i].SCID + "," + pos + "\")' class=\"select\">" + data.data[i].CIDName + "（" + data.data[i].TIDName + "）" + "（" + data.data[i].CRIDName + "）" + "</li>";
                                result = true;
                            }
                            //else {
                            //    str += "<li type=\"button\" class=\"noselect\">" + data.data[i].CIDName + data.data[i].TIDName + "<li>";
                            //}
                        }

                    }
                }
            })
            if (result) {
                $("#add").html(str);
            }
            else {
                alert("暂无数据");
                add.style.visibility = "hidden";
            }
            document.onclick = function (event) {
                //当左键点击的时候隐藏右键菜单
                document.getElementById("add").style.visibility = "hidden";
            }
        }
    }
    function add(obj) {
        document.getElementById("menu").style.visibility = "hidden";
        var add = document.getElementById("add");
        var scid = obj.split(',')[0];
        var pos = obj.split(',')[1];
        if (scid != "" && pos != "") {
            var result = false;
            $.ajax({
                url: "../ashx/SwapCourseHandler.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=Add&scid=" + scid + "&pos=" + pos,
                dataType: "json",
                success: function (data) {
                    //alert(JSON.stringify(data));
                    if (data.result == 'true') {
                        result = true;
                    }
                }
            })
            if (result) {
                //alert("提交成功！");
                $.ajax({
                    url: "../ashx/SwapCourseHandler.ashx",
                    cache: false,
                    type: "get",
                    async: false,
                    data: "method=SEL&scid=" + scid,
                    dataType: "json",
                    success: function (data) {
                        var str = "";
                        if (data.result = true) {
                            for (var j = 0; j < data.data.length; j++) {
                                $("#" + data.data[j].id).remove();
                                if (data.data[j].id.substr(data.data[j].id.length - 1, 1) == 1) {
                                    str = "<td scid=\"" + data.data[j].SCID + "\" id=\"" + data.data[j].id + "\" title=\"" + data.data[j].title + "\" teacher=\"" + data.data[j].teacher + "\" teachername=\"" + data.data[j].TeacherRepeat + "\" onclick=\"showteacher(this)\"  class=\"contd2\" oncontextmenu=\"showmenu(this)\">" + data.data[j].aa + "</td>";
                                    $("#" + ((parseInt(data.data[j].id)) + 1)).before(str);
                                }
                                else {
                                    str = "<td scid=\"" + data.data[j].SCID + "\" id=\"" + data.data[j].id + "\" title=\"" + data.data[j].title + "\" teacher=\"" + data.data[j].teacher + "\" teachername=\"" + data.data[j].TeacherRepeat + "\" onclick=\"showteacher(this)\" oncontextmenu=\"showmenu(this)\">" + data.data[j].aa + "</td>";
                                    $("#" + ((parseInt(data.data[j].id)) - 1)).after(str);
                                }
                                $("#add").attr("style", "display:none;");
                                $("#add").attr("style", "display:block;position: absolute;");
                            }
                        }
                    }
                })
            }
            else {
                //alert("提交失败！");
                return;
            }
            add.style.visibility = "hidden";

        }
    }

    function say(pscid, cscid) {
        $.ajax({
            url: "../ashx/SwapCourseHandler.ashx",
            cache: false,
            type: "get",
            async: false,
            data: "method=SEL&scid=" + (pscid + "," + cscid),
            dataType: "json",
            success: function (data) {
                var str = "";
                if (data.result = true) {
                    for (var j = 0; j < data.data.length; j++) {
                        $("#" + data.data[j].id).remove();
                        if (data.data[j].id.substr(data.data[j].id.length - 1, 1) == 1) {
                            str = "<td scid=\"" + data.data[j].SCID + "\" id=\"" + data.data[j].id + "\" title=\"" + data.data[j].title + "\" teacher=\"" + data.data[j].teacher + "\" teachername=\"" + data.data[j].TeacherRepeat + "\" onclick=\"showteacher(this)\"  class=\"contd2\" oncontextmenu=\"showmenu(this)\">" + data.data[j].aa + "</td>";
                            $("#" + ((parseInt(data.data[j].id)) + 1)).before(str);
                        }
                        else {
                            str = "<td scid=\"" + data.data[j].SCID + "\" id=\"" + data.data[j].id + "\" title=\"" + data.data[j].title + "\" teacher=\"" + data.data[j].teacher + "\" teachername=\"" + data.data[j].TeacherRepeat + "\" onclick=\"showteacher(this)\" oncontextmenu=\"showmenu(this)\">" + data.data[j].aa + "</td>";
                            $("#" + ((parseInt(data.data[j].id)) - 1)).after(str);
                        }
                        $("#add").attr("style", "display:none;");
                        $("#add").attr("style", "display:block;position: absolute;");
                    }
                }
            }
        })
    }
</script>

