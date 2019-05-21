<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseSet.aspx.cs" Inherits="GKICMP.educationals.BaseSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>

    <style>
        .pk {
            background: none;
            height: 50px;
        }

        .dispk {
            background: none;
            height: 50px;
        }

        #timetable input {
            border: none;
        }
    </style>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();

            //初始化数据
            Init();

            $('#txt_CourseDay').bind('input propertychange', function () {
                Init();
            });

            $('#txt_MorningPitch').bind('input propertychange', function () {
                Init();
            });

            $('#txt_AfterPitch').bind('input propertychange', function () {
                Init();
            });

            $('#txt_EveningPitch').bind('input propertychange', function () {
                Init();
            });

        });

        function Init() {
            var week = $("#txt_CourseDay").val();
            var mornumber = $("#txt_MorningPitch").val();
            var aftnumber = $("#txt_AfterPitch").val();
            var evenumber = $("#txt_EveningPitch").val();
            buildtimetable(week, mornumber, aftnumber, evenumber);
        }

        function buildtimetable(week, mor, aft, eve) {
            var html = "";
            var forbidts = $("#hf_timetable").val();
            for (var i = 0; i <= parseInt(mor) + parseInt(aft) + parseInt(eve) ; i++) {
                html = html + "<tr>";
                if (i == 0) {
                    html = html + "<td align=\"center\">课表时段</td>";
                    for (var j = 1; j <= week; j++) {
                        html = html + "<td align=\"center\">" + "星期" + (j == 1 ? "一" : j == 2 ? "二" : j == 3 ? "三" : j == 4 ? "四" : j == 5 ? "五" : j == 6 ? "六" : "日") + "</td>";
                    }
                }
                else {
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
                        if (forbidts.indexOf(j + "0" + i + "|") == 0 || forbidts.indexOf("|" + j + "0" + i) > 0 || forbidts == j + "0" + i) {
                            html = html + "<td style=\"height:50px;background-color: #ef5d5d;\" id=\"btn" + j + "-" + i + "\"><input class=\"dispk\" style=\"width:100%;color:white;\" type=\"button\" onclick=\"SetTS(" + j + "," + i + ")\" value=\"不排课\" /></td>";
                        }
                        else {
                            html = html + "<td style=\"height:50px;background-color: #34b171;\" id=\"btn" + j + "-" + i + "\"><input class=\"pk\" style=\"width:100%;color:white;\" type=\"button\" onclick=\"SetTS(" + j + "," + i + ")\" value=\"排课\" /></td>";
                        }
                    }
                }
                html = html + "</tr>";
            }
            $("#timetable").html(html);
        }

        function SetTS(week, num) {
            var btn = $("#btn" + week + "-" + num);
            if (btn.children("input").val() == "排课") {
                if ($("#hf_timetable").val().length > 0) {
                    $("#hf_timetable").val($("#hf_timetable").val() + "|" + week + "0" + num);
                }
                else {
                    $("#hf_timetable").val(week + "0" + num);
                }

                btn.children("input").val("不排课");
                btn.attr("style", "height: 50px;background-color: #ef5d5d;color:white;");
            }
            else {
                $("#hf_timetable").val(replace($("#hf_timetable").val(), week + "0" + num, "", "|"));
                btn.children("input").val("排课");
                btn.attr("style", "height: 50px;background-color: #34b171;color:white;");
            }

        }

        function replace(data, data2, data3, splitstr) {
            if (data == data2) {
                return data3;
            }
            else {
                if (data3.length > 0) {
                    data = data.replace(splitstr + data2 + splitstr, splitstr + data3 + splitstr);
                }
                else {
                    data = data.replace(splitstr + data2 + splitstr, splitstr);
                }

                if (data.indexOf(data2 + splitstr) == 0) {

                    if (data3.length > 0) {
                        data = data3 + splitstr + data.substring((data2 + splitstr).length);
                    }
                    else {
                        data = data.substring((data2 + splitstr).length);
                    }

                }
                if (data.indexOf(splitstr + data2) > 0 && data.indexOf(splitstr + data2) == data.length - (data2 + splitstr).length) {
                    if (data3.length > 0) {
                        data = data.substring(0, data.indexOf(splitstr + data2)) + splitstr + data3;
                    }
                    else {
                        data = data.substring(0, data.indexOf(splitstr + data2));
                    }

                }
            }
            return data;
        }
    </script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="排课设置"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="8" align="left">排课计划基础设置</th>
                    </tr>
                    <tr>
                        <td align="right" width="150px">每周上课天数：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_CourseDay" datatype="zheng" nullmsg="请填写每周上课天数" Width="60px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120px">上午节数：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_MorningPitch" datatype="zheng" nullmsg="请填写上午节数" Width="60px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                
                        <td align="right">下午节数：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_AfterPitch" datatype="zheng" nullmsg="请填写下午节数" Width="60px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">晚上节数：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_EveningPitch" datatype="zhengnum" nullmsg="请填写晚上节数" Width="60px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>

                    <tr>
                        <td colspan="8" style="padding: 0px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tbody id="timetable">
                                </tbody>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="8" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" CssClass="submit" Text="提交" OnClientClick='return confirm("修改基础设置需要重新排课才能生效")' OnClick="btnSave_Click" /></td>
                    </tr>

                </tbody>
            </table>
            <asp:HiddenField runat="server" ID="hf_timetable" />
        </div>
    </form>
</body>
</html>

