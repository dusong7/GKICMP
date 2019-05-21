<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectStu.aspx.cs" Inherits="GKICMP.educational.SelectStu" %>

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
    <script src="../js/choice.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function addinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'SelectStu.aspx', 'id=' + id, 860, 450, 1)
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ExamPaperPracticeDetail.aspx', 'id=' + id, 860, 450, 4);
        }
        function showexercise(EPID, UID, EPPID, PScore) {
            if (PScore > 0 && EPID != "") {
                return openbox('S_id', 'SelectExercise.aspx', 'epid=' + EPID + '&eppid=' + EPPID + '&uid=' + UID, 1060, 650, 1)
            }
        }
    </script>
    <style>
        .listcent {
            min-width: 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">学生名称：</td>
                        <td width="80px">
                            <asp:TextBox ID="txt_PaperName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
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
                        <th align="center">性别</th>
                        <th align="center">班级</th>
                        <th align="center">总分</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("RealName") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("UserSex")) %></td>
                                <td><%#Eval("DIDName") %></td>
                                <td>
                                    <a href="#" onclick='<%#"showexercise(\""+Eval("EPID")+"\",\""+Eval("UID")+"\",\""+Eval("EPPID")+"\",\""+Eval("PScore")+"\")"%>'>
                                        <%#Eval("PScore").ToString()=="0.0"?"0":Eval("PScore").ToString() %></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


