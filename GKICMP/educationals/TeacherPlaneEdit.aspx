<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPlaneEdit.aspx.cs" Inherits="GKICMP.educationals.TeacherPlaneEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
   
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/common.js"></script>
    <script>
        function check() {
            if (document.getElementById("hf_TID").value == "") {
                alert("教师姓名不能为空");
                return false;
            }
        }
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
            $.getJSON(url, function (data) { $('#Series').combotree({ data: data.data, multiple: false, /*multiline: true,*/ }); });
            $('#Series').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_TID").value = val;
                }
            });
            jQuery("#form1").Validform();

            Init();
        });

    </script>
    <script>
        $(function () {
            $('#Series').combotree('setValues', [$("#hf_TID").val()]);
        });
    </script>


    <style>
        .rec {
            /*background-color: #34b171;*/
            background: none;
            color: white;
            height: 35px;
            cursor: pointer;
        }

        .forbid {
            /*background-color: #ef5d5d;*/
            background: none;
            color: white;
            height: 35px;
            cursor: pointer;
        }

        .nec {
            /*background-color: blue;*/
            background: none;
            color: white;
            height: 35px;
            cursor: pointer;
        }

        .normal {
            /*background-color: white;*/
            background: none;
            color: white;
            height: 35px;
            cursor: pointer;
        }

        .no {
            background: none;
            color: white;
            height: 35px;
            cursor: none;
        }

        #timetable input {
            border: none;
        }

        .list td {
            padding-left: 0px;
        }
    </style>

    <script type="text/javascript">

        function Init() {
            var week = $("#hf_Week").val();
            var mornumber = $("#hf_MorningPitch").val();
            var aftnumber = $("#hf_AfterPitch").val();
            var evenumber = $("#hf_EveningPitch").val();
            //需要初始化（哪些位置不能排课，之前的排课策略是什么           
            buildtimetable(week, mornumber, aftnumber, evenumber);

        }

        function buildtimetable(week, mor, aft, eve) {
            var html = "";
            var forbidts = $("#hf_deffordibts").val();
            var rec = $("#hf_rec").val();
            var forbid = $("#hf_forbid").val();
            var nec = $("#hf_nec").val();

            //console.log(forbidts);
            for (var i = 0; i <= parseInt(mor) + parseInt(aft) + parseInt(eve) ; i++) {
                html = html + "<tr>";
                if (i == 0) {
                    html = html + "<td align=\"center\">课表时段</td>";
                    for (var j = 1; j <= week; j++) {
                        html = html + "<td align=\"center\">" + "星期" + (j == 1 ? "一" : j == 2 ? "二" : j == 3 ? "三" : j == 4 ? "四" : j == 5 ? "五" : j == 6 ? "六" : "日") + "</td>";
                    }
                } else {
                    var timestr = "";
                    if (i <= parseInt(mor)) {
                        timestr = "上午";
                        if (i == 1) {
                            html = html + "<td rowspan=" + parseInt(mor) + " align=\"center\">" + timestr + "</td>";
                        }
                    }
                    else if (i <= parseInt(mor) + parseInt(aft)) {
                        timestr = "下午";
                        if (i == parseInt(mor) + 1) {
                            html = html + "<td rowspan=" + parseInt(aft) + " align=\"center\">" + timestr + "</td>";
                        }
                    }
                    else {
                        timestr = "晚上";
                        if (i == parseInt(mor) + parseInt(aft) + 1) {
                            html = html + "<td rowspan=" + parseInt(eve) + " align=\"center\">" + timestr + "</td>";
                        }
                    }
                    for (var j = 1; j <= week; j++) {
                        //需要初始化
                        if (forbidts.indexOf(j + "0" + i + "|") == 0 || forbidts.indexOf("|" + j + "0" + i) > 0 || forbidts == j + "0" + i) {
                            html = html + "<td  style=\"height:35px;background-color: black;\" id=\"btn" + j + "-" + i + "\"><input class=\"no\" style=\"width:100%;\" type=\"button\"  value=\"不排课\" /></td>";
                        }
                        else {
                            //判断是否属于其他状态
                            if (rec.indexOf(j + "0" + i + "|") == 0 || rec.indexOf("|" + j + "0" + i) > 0 || rec == j + "0" + i) {
                                html = html + "<td  style=\"height:35px;background-color: #34b171;\" id=\"btn" + j + "-" + i + "\"><input class=\"rec\" style=\"width:100%;\" type=\"button\" onclick=\"ChangeState(" + j + "," + i + ",this)\" value=\"推荐\" /></td>";
                            }
                            else if (forbid.indexOf(j + "0" + i + "|") == 0 || forbid.indexOf("|" + j + "0" + i) > 0 || forbid == j + "0" + i) {
                                html = html + "<td  style=\"height:35px;background-color: #ef5d5d;\" id=\"btn" + j + "-" + i + "\"><input class=\"forbid\" style=\"width:100%;\" type=\"button\" onclick=\"ChangeState(" + j + "," + i + ",this)\" value=\"禁止\" /></td>";
                            }
                            else if (nec.indexOf(j + "0" + i + "|") == 0 || nec.indexOf("|" + j + "0" + i) > 0 || nec == j + "0" + i) {
                                html = html + "<td  style=\"height:35px;background-color:#3367D6; \" id=\"btn" + j + "-" + i + "\"><input class=\"nec\" style=\"width:100%;\" type=\"button\" onclick=\"ChangeState(" + j + "," + i + ",this)\"  value=\"必须\" /></td>";
                            }
                            else {
                                html = html + "<td  style=\"height:35px;background-color:#908a8a; \" id=\"btn" + j + "-" + i + "\"><input class=\"normal\" style=\"width:100%;\" type=\"button\" onclick=\"ChangeState(" + j + "," + i + ",this)\"  value=\"普通\" /></td>";
                            }


                        }

                    }
                }
                html = html + "</tr>";
            }
            $("#timetable").html(html);
        }

        function ChangeState(week, num, obj) {
            var btn = jQuery("#btn" + week + "-" + num);
            var type = btn.children("input").val();
            switch (type) {
                case "普通":
                    if (jQuery("#hf_nec").val().length > 0) {
                        jQuery("#hf_nec").val(jQuery("#hf_nec").val() + "|" + week + "0" + num);
                    } else {
                        jQuery("#hf_nec").val(week + "0" + num);
                    }
                    btn.children("input").val("必须");
                    //btn.attr("class", "nec");
                    btn.attr("style", " background-color:#3367D6; color:white;height: 35px;cursor: pointer;");
                    btn.children("input").attr("style", "width:100%;color:white;")
                    break;
                case "必须":
                    if (jQuery("#hf_forbid").val().length > 0) {
                        jQuery("#hf_forbid").val(jQuery("#hf_forbid").val() + "|" + week + "0" + num);
                    } else {
                        jQuery("#hf_forbid").val(week + "0" + num);
                    }
                    jQuery("#hf_nec").val(replace(jQuery("#hf_nec").val(), week + "0" + num, "", "|"));
                    btn.children("input").val("禁止");
                    //btn.attr("class", "forbid");
                    btn.attr("style", " background-color: #ef5d5d; color: white;height: 35px;cursor: pointer;");
                    btn.children("input").attr("style", "width:100%;color:white;")
                    break;
                case "禁止":
                    if (jQuery("#hf_rec").val().length > 0) {
                        jQuery("#hf_rec").val(jQuery("#hf_rec").val() + "|" + week + "0" + num);
                    } else {
                        jQuery("#hf_rec").val(week + "0" + num);
                    }
                    jQuery("#hf_forbid").val(replace(jQuery("#hf_forbid").val(), week + "0" + num, "", "|"));
                    btn.children("input").val("推荐");
                    //btn.attr("class", "rec");
                    btn.attr("style", " background-color: #34b171; color: white;height: 35px;cursor: pointer;");
                    btn.children("input").attr("style", "width:100%;color:white;")
                    break;
                case "推荐":
                    jQuery("#hf_rec").val(replace(jQuery("#hf_rec").val(), week + "0" + num, "", "|"));
                    btn.children("input").val("普通");
                    //btn.attr("class", "normal");
                    btn.attr("style", " background-color:#908a8a;color:white;height:35px;cursor: pointer;");
                    btn.children("input").attr("style", "width:100%;color:white;")
                    break;
            }

        }

        function replace(data, data2, data3, splitstr) {
            if (data == data2) {
                return data3;
            } else {
                if (data3.length > 0) {
                    data = data.replace(splitstr + data2 + splitstr, splitstr + data3 + splitstr);
                } else {
                    data = data.replace(splitstr + data2 + splitstr, splitstr);
                }

                if (data.indexOf(data2 + splitstr) == 0) {

                    if (data3.length > 0) {
                        data = data3 + splitstr + data.substring((data2 + splitstr).length);
                    } else {
                        data = data.substring((data2 + splitstr).length);
                    }

                }
                if (data.indexOf(splitstr + data2) > 0 && data.indexOf(splitstr + data2) == data.length - (data2 + splitstr).length) {
                    if (data3.length > 0) {
                        data = data.substring(0, data.indexOf(splitstr + data2)) + splitstr + data3;
                    } else {
                        data = data.substring(0, data.indexOf(splitstr + data2));
                    }

                }
            }
            return data;
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_DID" runat="server" />
        <asp:HiddenField ID="hf_JieShu" runat="server" />
        <asp:HiddenField ID="hf_TID" runat="server" />

        <asp:HiddenField ID="hf_Week" runat="server" />
        <asp:HiddenField ID="hf_MorningPitch" runat="server" />
        <asp:HiddenField ID="hf_AfterPitch" runat="server" />
        <asp:HiddenField ID="hf_EveningPitch" runat="server" />

        <asp:HiddenField ID="hf_deffordibts" runat="server" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">排课计划信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">学科名称：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseName" runat="server" datatype="ddl" errormsg="请选择学科名称" Enabled="false"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>

                        <td align="right">每周节数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Jieshu" runat="server" datatype="zhengnum" Width="35px" nullmsg="请填写每周节数" Enabled="false"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">连堂次数：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LianCi" runat="server"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">任课教师：</td>
                        <td align="left">
                            <input id="Series" name="Series" runat="server" editable="true" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">是否同步教师：</td>
                        <td align="left">
                            <asp:CheckBox ID="chk_TbTeacher" runat="server" /></td>
                        <td align="right">场地要求：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CRID" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="padding: 0px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                                <tbody id="timetable">
                                </tbody>
                            </table>


                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return check()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField runat="server" ID="hf_rec" />
            <asp:HiddenField runat="server" ID="hf_forbid" />
            <asp:HiddenField runat="server" ID="hf_nec" />



        </div>
    </form>
</body>
</html>


