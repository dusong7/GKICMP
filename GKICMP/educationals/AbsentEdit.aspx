<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbsentEdit.aspx.cs" Inherits="GKICMP.educationals.AbsentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园考试管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
     <style>
        .editor {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_09.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
        }
        .listinfo td {
            background-color: #efefef;
        }
        .tb {
            text-align: center;
            /*background-color: #efefef;*/
            color: black;
        }
        .tb th {
                color: #109c54;
                height: 60px;
                border: 1px solid #cdcecf;
            }
        .tb td {
                height: 60px;
                border: 1px solid #cdcecf;
            }
        .tb td.states1 {
                    background-color: #ef5d5d;
                    color: white;
                }
        .tb td.states2 {
                    background-color: #908a8a;
                    color: white;
                }

        /*#menu {
            width: 178px;
            padding: 5px;
            font-size: 14px;
            border: #EEE 1px solid;
            margin-top: 0px;
            margin-left: 5px;
        }*/

        #menu{width:970px;left:50%!important;top:50px!important;margin-left:-450px!important;border:1px solid #3c9962}

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
                    /*line-height: 30px;*/
                    background: url("../images/green_tree-ul-li.png") no-repeat 9px -30px;
            

                }
            .myMenu li{display:inline-block}

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
            box-shadow: 0 0px 10px rgba(0,0,0,.1);
        }

            .myMenu li {
                /*border-bottom: 1px dashed #f3e6e6;*/
                border-bottom: 1px dashed #3c9962;
                width: 242px;
                text-indent: 20px;
                line-height: 42px;text-align: left;
            }
        .myMenu li i{display:inline-block;* display:inline;zoom:1;font-style: normal;width: 60px;margin-right:5px;text-align: left;text-indent: 0}
        .myMenu li span{display:inline-block;* display:inline;zoom:1;font-size: 12px;color: #3c9962;text-align: left;text-indent: 0}
                .myMenu li:hover {
                    background: #e8e5e5;
                }

                .myMenu li a {
                    display: block;
                }

                .myMenu li:hover a {
                    color: #fff;
                }

        .menu li {
            width: 210px;
        }

        .menu .select {
            cursor: pointer;
        }

        .menu .noselect {
            color: #bdbcbc;
        }

            .menu .noselect:hover {
                color: #bdbcbc;
                background: none;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btn_Freash" runat="server" OnClick="btn_Freash_Click" Style="display: none;" />
        <div id="dv1" runat="server" style="text-align: center; margin-top: 10px;" visible="false">
            <asp:Label ID="lbl_Name" runat="server"></asp:Label>
        </div>
        <div class="listcent pad0">
            <asp:Label ID="lbl_SC" runat="server"></asp:Label>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <span style="font-size: x-large; float: left; margin-right: 5px;">
                            注：1.<span style="color:red;">深灰色</span>代表申请中，<span style="color:red;">红色</span>代表已完成，默认颜色代表可申请。<br/>
                            2.在课程上<span style="color:red;">右键</span>可以选择代课教师。
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Back" runat="server" CssClass="editor" Text="返回" OnClick="btn_Back_Click" />
                        <%--    <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' javascript: window.history.back(-1);' />--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<ul id="menu" class="myMenu" style="position: absolute; visibility: hidden;">
</ul>
<script type="text/javascript">
    document.getElementById("lbl_SC").oncontextmenu = function (e) {
        return false;
    }
    function showteacher(obj) {
        var tid = $(obj).attr("tid");
        var pos = $(obj).attr("pos");
        var datas = $(obj).attr("data");
        var cid = $(obj).attr("cid");
        var did = $(obj).attr("did");
        var lid = $(obj).attr("lid");
        var uid = $(obj).attr("uid");
        var e = event || window.event;
        var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft;
        var scrollY = document.documentElement.scrollTop || document.body.scrollTop;
        var x = e.pageX || e.clientX + scrollX;
        var y = e.pageY || e.clientY + scrollY;
        var add = document.getElementById("menu");
        add.style.left = x + "px";
        add.style.top = y + "px";
        add.style.visibility = "visible";
        if (tid != "" && pos != "" && datas != "" && cid != "" && did != "" && lid != "") {
            var str = "";
            var result = false;
            $.ajax({
                url: "../ashx/SwapCourseHandler.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=ShowTeacher&tid=" + tid + "&pos=" + pos + "&datas=" + datas,
                dataType: "json",
                success: function (data) {
                    //data = JSON.parse(data);
                    if (data.result == 'true') {
                        for (var i = 0; i < data.data.length; i++) {
                            //str += "<li type=\"button\" onclick='add(\"" + data.data[i].TID + "\",\"" + data.data[i].datas + "\",\"" + cid + "\",\"" + did + "\",\"" + lid + "\",\"" + pos + "\",\"" + uid + "\")'>" + data.data[i].TeacherName +'   ['+data.data[i].nj + ']'+ "</li>";
                              str += "<li type=\"button\" onclick='add(\"" + data.data[i].TID + "\",\"" + data.data[i].datas + "\",\"" + cid + "\",\"" + did + "\",\"" + lid + "\",\"" + pos + "\",\"" + uid + "\")'>" + "<i>" + data.data[i].TeacherName + "</i>" + "<span>" +'[' + data.data[i].nj + ']'+ "</span>" + "</li>";
                            result = true;
                        }
                    }
                }
            })

        }
        if (result) {
            $("#menu").html(str);
        }
        else {
            alert("暂无数据");
        }
        document.onclick = function (event) {
            //当左键点击的时候隐藏右键菜单
            document.getElementById("menu").style.visibility = "hidden";
        }
    }
    function add(SubUser, SubDate, SubCoruse, DID, LID, SubNum, UserID) {
        if (SubUser != "" && SubDate != "" && SubCoruse != "" && DID != "" && LID != "" && SubNum != "" && UserID != "") {
            var result = false;
            $.ajax({
                url: "../ashx/SwapCourseHandler.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=TeacherAdd&SubUser=" + SubUser + "&SubDate=" + SubDate + "&SubCoruse=" + SubCoruse + "&DID=" + DID + "&LID=" + LID + "&SubNum=" + SubNum + "&UID=" + UserID,
                dataType: "json",
                success: function (data) {
                    //alert(JSON.stringify(data));
                    if (data.result == 'true') {
                        result = true;
                    }
                }
            })
        }
        if (result) {
            //alert("保存成功");
            $("#btn_Freash").click();
        }
        else {
            alert("保存失败");
        }
        document.getElementById("menu").style.visibility = "hidden";
    }
    function TX(Flag) {
        if (Flag == 2) {
            alert("当前这节课代课老师正在申请中");
        }
        if (Flag == 3) {
            alert("当前这节课已有代课老师");
        }
    }
</script>
