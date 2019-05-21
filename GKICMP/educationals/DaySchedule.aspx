<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaySchedule.aspx.cs" Inherits="GKICMP.educationals.DaySchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <%--    <script src="../js/input_custom.js"></script>--%>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>

    <style>
        .content td {
            /*min-width: 60px;*/
            Text-align: center;
            border-left: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            padding: 2px 4px;
            width: 30px;
        }

        .content .contd1 {
            color: #48bd81;
            font-weight: bold;
            height: 40px;
            line-height: 40px;
        }

        .content .contd3 {
            color: #fff;
            background: #ef5d5d;
            width: 30px;
        }

        #lbl td:hover {
            background: #C4C6C8;
        }

        #lbl .content .contd1:hover {
            color: #48bd81;
            background: #fff;
        }

        #lbl .content .contd3:hover {
            color: #fff;
            background: #ef5d5d;
        }

        .listcent {
            width: 98%;
            border: 1px solid #94e7a3;
            border-radius: 2px;
            margin: auto;
            margin-top: 15px;
            box-shadow: 0px 0 0px red, /*左边阴影*/ 0px 0 0px yellow, /*右边阴影*/ 0 0px 0px blue, /*顶部阴影*/ 0 5px 15px #dadada;
            padding: 0px;
        }

        .searclass {
            background-color: #f5f5f5;
        }

        .listcent1 {
            width: 98%;
            border: 1px solid #94e7a3;
            border-radius: 2px;
            margin: auto;
            box-shadow: 0px 0 0px red, /*左边阴影*/ 0px 0 0px yellow, /*右边阴影*/ 0 0px 0px blue, /*顶部阴影*/ 0 5px 15px #dadada;
            padding: 0px;
        }

        .xxsm {
            margin-top: 10px;
        }

            .xxsm ul, .xxsm li {
                list-style: none;
                margin: 0px;
                padding: 0px;
            }

            .xxsm li {
                float: left;
                height: 32px;
                line-height: 32px;
                border: 1px solid #aaaaaa;
                border-bottom: none;
                border-top-left-radius: 4px;
                border-top-right-radius: 4px;
                margin-right: 6px;
                padding: 0px 28px;
                background: url(../images/SEARCH_06.png) repeat-x center center;
            }

                .xxsm li a {
                    color: #808080;
                    font-size: 14px;
                    font-weight: bold;
                    text-decoration: none;
                }

                .xxsm li.selected {
                    float: left;
                    height: 33px;
                    line-height: 34px;
                    border: 0px;
                    border-bottom: none;
                    border-top-left-radius: 4px;
                    border-top-right-radius: 4px;
                    margin-right: 6px;
                    padding: 0px 28px;
                    background: url(../images/green_xxsm.png) repeat-x center center;
                }

                    .xxsm li.selected a {
                        color: #fff;
                    }

                .xxsm li:first-child {
                    margin-left: 11px;
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="智能排课"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="周/日/节次课表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="WeekSchedule.aspx">周课表</a></li>
                                    <li class="selected"><a href="DaySchedule.aspx">日课表</a></li>
                                    <li><a href="SectionSchedule.aspx">节次课表</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="400">
                            <asp:DropDownList ID="ddl_Day" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" CssClass="btncss" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0" style="position: relative;">
            <div style="overflow-x: auto; overflow-y: hidden; width: 100%; text-align: center;">
                <asp:Label ID="lbl" runat="server"></asp:Label>
            </div>
        </div>

    </form>
</body>
</html>

