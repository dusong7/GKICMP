<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LectureScoreEdit.aspx.cs" Inherits="GKICMP.lecturemanage.LectureScoreEdit" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title>btable</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="format-detection" content="telephone=no">
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/layui.css" media="all" />
    <link rel="stylesheet" href="../css/jquery.treetable.theme.default.css">
    <style>
        #myMenu {
            border: 1px solid #D8D8D8;
            background: #fff;
            padding: 10px 0px;
            box-shadow: #939393 3px 3px 3px;
        }

            #myMenu li {
                border-bottom: 1px dashed #DDDDDD;
                width: 150px;
                text-indent: 20px;
                line-height: 30px;
            }

                #myMenu li:hover {
                    background: #5FB878;
                }

                #myMenu li a {
                    display: block;
                }

                #myMenu li:hover a {
                    color: #fff;
                }

        .layui-table tr:nth-child(2n) {
            background-color: #f8f8f8;
        }

        .layui-table td {
            padding: 0 0.5em;
            line-height: 40px;
        }

        #A_id_content {
            height: 410px;
        }
    </style>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/jquery.treetable.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>

</head>

<body style="background-color: #f5f5f5;">
    <%--<body>--%>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_LSID" />
        <asp:HiddenField runat="server" ID="hf_Value" />
        <div style="line-height: 26px; width: 98%; margin: auto; margin-top: 15px; font-size: 12px; font-family: 微软雅黑体; background: #f5f5f5;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span style="display: block; width: 100%; height: 90%; background: url(../images/green_yjqh_27.png) center center no-repeat;"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>公开课管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="听课打分"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="line-height: 26px; width: 98%; margin: auto; margin-top: 15px; font-size: 14px; font-family: 微软雅黑体; background: #f5f5f5;">
            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center" width="80px">听课时间：</td>
                    <td width="340px">
                        <asp:Literal runat="server" ID="ltl_DateTime"></asp:Literal></td>
                    <td align="center" width="80px">授课教师：</td>
                    <td>
                        <asp:Literal runat="server" ID="ltl_TeacherName"></asp:Literal></td>
                    <td align="center" width="50px">课程：</td>
                    <td>
                        <asp:Literal runat="server" ID="ltl_CourseName"></asp:Literal></td>
                    <td align="center" width="50px">班级：</td>
                    <td>
                        <asp:Literal runat="server" ID="ltl_ClassName"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px; background-color: white; margin: 0 10px;">
            <div id="content" style="width: 100%; height: 684px;">
                <div class="btable">
                    <div id="main">
                        <asp:Literal runat="server" ID="ltl_Content"></asp:Literal>
                    </div>
                    <div style="text-align: center; background-color: #f5f5f5;">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" Style="width: 98px; height: 39px; color: #fff; border: none; background: url(../images/green_sb_07.png); font-size: 18px; margin: 10px; padding: 0px; text-indent: 0px; text-align: center" OnClick="btn_Sumbit_Click" OnClientClick="return aa();" />
                    </div>
                    <script>
                        $("#example-advanced").treetable({ expandable: true });
                        window.onload = function () {
                            jQuery('#example-advanced').treetable('expandAll'); return false;
                        }
                    </script>
                </div>
            </div>
        </div>
    </form>
    <script>
        function aa() {
            var inputid = "";
            var inputArray = $("input[type='text']");//取到所有的input text 并且放到一个数组中  
            inputArray.each(//使用数组的循环函数 循环这个input数组  
                function () {
                    var input = $(this);//循环中的每一个input元素  
                    inputid += input.attr("id") + ":" + $('#' + input.attr("id")).val() + ",";//查看循环中的每一个input的id  
                }
            )
            document.getElementById("hf_Value").value = inputid
            return true;
        }
    </script>
</body>
</html>
