<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverCourse.aspx.cs" Inherits="GKICMP.electiver.ElectiverCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function showbox() {
            var eleid = getUrlParam("id");
            return openbox('S_id', 'ElectiverCourseEdit.aspx','&eleid=' + eleid, 850, 300, -1);
        }
    </script>
    <style>
        .listinfo td {
            line-height: 30px;
        }

        .listinfo tr:nth-child(2n+1) td {
            background: none;
        }

        table tr:last-child td {
            border-bottom: #e4e4e4 1px solid;
        }

        table tr td:last-child {
            border-right: #e4e4e4 1px solid;
        }
        .auto-style1 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_PID" />
        <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                   
                    <tr>
                        <th colspan="4" align="left">课程列表</th>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <img src="../images/addfile.gif" onclick="showbox()" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <table width="99%" id="tb_Right" style="border: 1px">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold;">课程
                                    </td>
                                    <td style="font-weight: bold;">等级
                                    </td>
                                    <td style="font-weight: bold;">人数
                                    </td>
                                    <td style="font-weight: bold; ">操作
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("CourseName")%></td>
                                       <%--     <asp:HiddenField ID="hf_BID" runat="server" Value='<%#Eval("BID") %>' />--%>
                                            <td align="center"><%#Eval("ClevelName") %></td>
                                            <td align="center"><%#Eval("MaxCount") %></td>
                                            <td align="center">
                                                <asp:LinkButton ID="lbtn_Delete" runat="server" ToolTip="删除" CommandArgument='<%#Eval("ECID") %>' OnClientClick="return confirm('确认删除选中信息');" OnClick="lbtn_Delete_Click">
                                                    <img src="../images/d13.png" />
                                                </asp:LinkButton>
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <%-- <script>
        function print()
        {
            
            //document.body.innerHTML = document.getElementById('print').innerHTML;
            WindowPrint.execwb(7, 1);
            //window.print();

            //alert("打印");
        }
    </script>--%>
</body>
</html>



