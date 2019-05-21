<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCourse.aspx.cs" Inherits="GKICMP.educationals.SelectCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        function CellText1(innerHtml) {
            var childscid = innerHtml.substring(innerHtml.indexOf(":a:c") + 4, innerHtml.indexOf(":b:c"));

            var parentscid = document.getElementById("hf_scid").value;
            var userid = document.getElementById("hf_UserID").value;
            var cname = document.getElementById("hf_cname").value;
            //如果不包含返回-1
            var isContains = innerHtml.indexOf("green");
            if (innerHtml != "" && innerHtml != null && isContains != -1) {
                $.ajax({
                    url: "../ashx/SwapCourseHandler.ashx",
                    cache: false,
                    type: "GET",
                    async: false,
                    data: "method=Tip&parentscid=" + parentscid + "&childscid=" + childscid,
                    dataType: "json",
                    success: function (data) {
                        //var res = window.confirm(data.result);
                        var res = true;
                        if (res) {
                            $.ajax({
                                url: "../ashx/SwapCourseHandler.ashx",
                                cache: false,
                                type: "GET",
                                async: false,
                                data: "method=Swap&parentscid=" + parentscid + "&childscid=" + childscid + "&userid=" + userid,
                                dataType: "json",
                                success: function (data) {
                                    if (data.result = "success") {
                                        //alert("调换成功！");
                                        // $.opener("A_id").document.getElementById('location_btn').click();
                                        //$.opener("A_id").parent.document.getElementById('location_btn').click();  
                                        parent.say(parentscid, childscid);
                                        $.close("A_id");
                                    }
                                    else {
                                        alert("调课失败！");
                                    }
                                }
                            });
                        }
                        else {
                            $.close("A_id");
                        }
                    }
                });
            }
        }
    </script>
    <style type="text/css">
        #content {
            padding: 20px;
        }

        #tab {
            border-collapse: collapse;
        }

            #tab tr td {
                border: 1px solid black;
                text-align: center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <asp:HiddenField ID="hf_scid" runat="server" />
            <asp:HiddenField ID="hf_UserID" runat="server" />
            <asp:HiddenField ID="hf_cname" runat="server" />
            <table width="98%" align="center" border="0" cellpadding="0" cellspacing="0">
                <tr style="background: url(../images/tabimg/tabpic3.gif) bottom; vertical-align: middle; height: 30px">
                    <td valign="top" rowspan="2">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="height: 30px;">当前班级：<asp:Literal runat="server" ID="ltl_NowClass"></asp:Literal>
                                    &nbsp;&nbsp;&nbsp;  <span style="color: red">注：1.红色-当前选中的课程2.绿色-可以调课的课程3.灰色-有冲突的课程4.红色背景框-该位置是禁止排课</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Table ID="tab" runat="server"></asp:Table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

