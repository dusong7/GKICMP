<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatingSequenceManage.aspx.cs" Inherits="GKICMP.educational.SeatingSequenceManage" %>

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
                                    <li class="selected"><a href="SeatingSequenceManage.aspx?id=<%=EID%>">考场座位表</a></li>
                                    <li><a href="InvigilatorManage.aspx?id=<%=EID %>">监考表</a></li>
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
                        <td align="right" width="60">考场号：</td>
                        <td width="150">
                            <asp:DropDownList runat="server" ID="ddl_kch"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                            <asp:Button ID="btn_OutPutWord" runat="server" Text="导出Word" OnClick="btn_OutPutWord_Click" /><asp:Button ID="btn_OutPut" runat="server" Text="导出Excel" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">姓名</th>
                        <th align="center">班级</th>
                        <th align="center">考场号</th>
                        <th align="center">座位号</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("UIDName")%></td>
                                <td><%#Eval("ClassName")%></td>
                                <td><%#"第"+Eval("KCH").ToString()+"考场"%></td>
                                <td><%#Eval("ERID")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>



