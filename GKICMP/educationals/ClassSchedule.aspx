<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassSchedule.aspx.cs" Inherits="GKICMP.educationals.ClassSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        function CellText(innerHtml) {
            var scid = innerHtml.substring(innerHtml.indexOf(":a:c") + 4, innerHtml.indexOf(":b:c"));
            if (scid != "" && scid != null) {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'SelectCourse.aspx', 'scid=' + scid, 750, 500, 49);
            }
        }
        function preview() {
            $("#div11").css("display", "block");
            var prnhtml = ($("#aa").html());
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
    </script>
    <style type="text/css">
        .datanone {
            height: 112px;
            background: url(../images/nores.png) left center no-repeat;
            padding-left: 150px;
            width: 390px;
            margin: auto;
            padding-top: 50px;
            line-height: 2;
        }

        .listadd {
            border: 1px solid #25a161;
            border-radius: 2px;
            background: #48bd81;
            color: #FFFFFF;
            width: 65px;
            height: 26px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
        }

        .listoutput {
            border: 1px solid #ff772d;
            border-radius: 2px;
            background: #ff9a37;
            color: #FFFFFF;
            width: 65px;
            height: 26px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
        }

        .listprint {
            border: 1px solid #4cb190;
            border-radius: 2px;
            background: #4cb190;
            color: #FFFFFF;
            width: 65px;
            height: 26px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
        }

        .listinfo td {
            line-height: 25px;
            padding-left: 0px;
            padding-right: 0px;
        }

        #lbl td:hover {
            background: #C4C6C8;
        }


        .content th {
            border-top: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            border-left: 1px solid #cdcecf;
        }

        .content td {
            /*min-width: 60px;*/
            Text-align: center;
            border-left: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            padding: 0px 4px;
        }

        .content th:last-child {
            border-right: 1px solid #cdcecf;
        }

        .content td:last-child {
            border-right: 1px solid #cdcecf;
        }

        .listcent .content .contd3 {
            color: #fff;
            background: #ef5d5d;
        }

        #lbl .content .contd3:hover {
            color: #fff;
            background: #ef5d5d;
        }

        #lbl .content .contd1:hover {
            color: #48bd81;
            background: #fff;
        }

        .content .contd1 {
            color: #48bd81;
            font-weight: bold;
        }

        .lxr {
            margin: 10px 0px 0px 10px;
            width: 200px;
        }

        .fileshowlist {
            float: left;
        }

        .lxr .filetitle {
            text-align: center;
            margin-left: 4px;
        }

        .filetitle {
            background: #c1ecbc;
            line-height: 30px;
        }

        #menu {
            width: 230px;
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
                width: 230px;
                text-indent: 20px;
                line-height: 30px;
            }

                .myMenu li:hover {
                    background: #e8e5e5;
                    cursor: pointer;
                }

                .myMenu li a {
                    display: block;
                }

                .myMenu li:hover a {
                    color: #fff;
                }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <tbody>
                    <tr>
                        <th style="text-align: left;">当前班级：<asp:Literal runat="server" ID="ltl_NowClass"></asp:Literal>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btn_OutPut" CssClass="listbtncss listoutput" runat="server" Text="导出" OnClick="btn_OutPut_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btn_Print" runat="server" Text="打印" CssClass="listprint" OnClientClick="preview()" />
                        </th>
                    </tr>
                    <tr style="height: 16px;">
                        <td id="aa" runat="server">
                            <div id="div11" style="display: none; text-align: center;">
                                <asp:Label ID="lblclass" runat="server"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <asp:Label ID="lbl" runat="server" Style="margin-right: 0px;"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="padbot" runat="server">
            <asp:Repeater runat="server" ID="rp_List">
                <ItemTemplate>
                    <div class="fileshowlist lxr" id="div-<%#Eval("SCID")%>">
                        <div class="filetitle">
                            <span class="filename"><%#Eval("CourseRepeat")+"("+Eval("TeacherRepeat")+")"%></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
<ul id="menu" class="myMenu" style="position: absolute; visibility: hidden;">
</ul>
<script>
    document.getElementById("lbl").oncontextmenu = new Function("event.returnValue=false;");
    function showadd(claid, pos) {
        var e = event || window.event;
        var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft;
        var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
        var x = e.pageX || e.clientX + scrollX;
        var y = e.pageY || e.clientY + scrollY;
        var add = document.getElementById("menu");
        if (document.body.scrollWidth - x > 230) {
            add.style.left = x + "px";
        }
        else {
            add.style.left = x - 230 + "px";
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
                                str += "<li type=\"button\"  onclick='add(\"" + data.data[i].SCID + "\",\"" + pos + "\")'>" + data.data[i].CIDName + "（" + data.data[i].TIDName + "）" + "（" + data.data[i].CRIDName + "）" + "</li>";
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
                $("#menu").html(str);
            }
            else {
                alert("暂无数据");
                add.style.visibility = "hidden";
            }

            document.onclick = function (event) {
                //当左键点击的时候隐藏右键菜单
                document.getElementById("menu").style.visibility = "hidden";
            }
        }
    }
    function add(scid, pos) {
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
                                $("#" + data.data[j].Position).remove();
                                $("#div-" + data.data[j].SCID).remove();
                                str = "<td id=" + data.data[j].Position + " onclick=\"CellText(this.innerHTML)\">" + data.data[j].CourseRepeat + " <br><span style=\"color:red\">" + data.data[j].TeacherRepeat + "</span><label style=\"display:none;\">:a:c" + data.data[j].SCID + ":b:c</label></td>";
                                if (data.data[j].Position == 101) {
                                    $("#201").before(str);
                                }
                                else {
                                    $("#" + (parseInt(data.data[j].Position) - 100)).after(str);
                                }
                                $("#menu").attr("style", "display:none;");
                                $("#menu").attr("style", "display:block;position: absolute;");
                            }
                        }
                    }
                })
            }
            else {
                //alert("提交失败！");
                return;
            }
            document.getElementById("menu").style.visibility = "hidden";

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
                    for (var i = 0; i < data.data.length; i++) {
                        $("#" + data.data[i].Position).remove();
                        str = "<td id=" + data.data[i].Position + " onclick=\"CellText(this.innerHTML)\">" + data.data[i].CourseRepeat + " <br><span style=\"color:red\">" + data.data[i].TeacherRepeat + "</span><label style=\"display:none;\">:a:c" + data.data[i].SCID + ":b:c</label></td>";
                        if (data.data[i].Position == 101) {
                            $("#201").before(str);
                        }
                        else {
                            $("#" + (parseInt(data.data[i].Position) - 100)).after(str);
                        }
                    }
                }
            }
        })
    }
</script>


