<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvigilatorManage.aspx.cs" Inherits="GKICMP.educational.InvigilatorManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'CourseEdit.aspx', '', 740, 400, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'CourseEdit.aspx', 'id=' + id, 740, 400, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'CourseDetail.aspx', 'id=' + id, 740, 400, 4);
        }

        function admininfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '', 'id=' + id, 860, 450, 4);
        }
    </script>
    <style>
        .content td {
            /*min-width: 60px;*/
            Text-align: center;
            border-left: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            padding: 10px 4px;
            width: 30px;
        }

        .content th {
            border-left: 1px solid #cdcecf;
        }

            .content th:first-child, .content td:first-child {
                border-left: none;
            }

        .content .contd1 {
            color: #333;
            font-weight: bold;
        }

        .conth1 {
            background: #efefef;
            height: 40px;
            line-height: 40px;
            border-bottom: 1px solid #cdcecf;
            color: #48bd81;
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

        #btn_OutPut, #btn_OutPutWord {
            border: 1px solid #ff772d;
            border-radius: 2px;
            background: #ff9a37;
            color: #FFFFFF;
            width: 85px;
            height: 27px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
            float: right;
            margin-bottom: 2px;
            margin-top: 2px;
        }

        #btn_OutPutWord {
            background: #238839;
            border: 1px solid #5dc556;
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
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="listcent">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="ExamEdit.aspx?id=<%=EID%>">考试信息</a></li>
                                    <li><a href="ExamSubjectManage.aspx?id=<%=EID%>">考试设置</a></li>
                                    <li><a href="SeatingSequenceManage.aspx?id=<%=EID %>">考场座位表</a></li>
                                    <li class="selected"><a href="InvigilatorManage.aspx?id=<%=EID %>">监考表</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass" id="div_top" runat="server">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td style="text-align: center; width: 100%; font-size: 20px; font-weight: inherit; color: #455449">
                            <asp:Label ID="lbl_Title" runat="server"></asp:Label></td>
                        <td>
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出Excel" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="btn_OutPutWord" runat="server" Text="导出Word" OnClick="btn_OutPutWord_Click" />
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
