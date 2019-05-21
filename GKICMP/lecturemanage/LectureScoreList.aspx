<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LectureScoreList.aspx.cs" Inherits="GKICMP.lecturemanage.LectureScoreList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LectureEdit.aspx', '', 980, 310, -1);
            });
        });
        function viewinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'EmailDetail.aspx', 'id=' + id + '&flag=1', 860, 450, 4);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="听课打分"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70px">班级：</td>
                        <td width="160px">
                            <asp:TextBox runat="server" ID="txt_ClassName"></asp:TextBox>
                        </td>
                        <td align="right" width="70px">授课教师：</td>
                        <td width="100px">
                            <asp:TextBox runat="server" ID="txt_TeacherName"></asp:TextBox>
                        </td>
                        <td width="70px" align="right">听课时间：</td>
                        <td width="350px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
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
                        <th align="center">班级</th>
                        <th align="center">课程</th>
                        <th align="center">授课教师</th>
                        <th align="center">听课时间</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ClassName")%></td>
                                <td><%#Eval("CourseName")%></td>
                                <td><%#Eval("TeacherName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}")%>--<%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Score" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("isornot").ToString()=="1"?false:true %>' CommandArgument='<%#Eval("LID") %>' OnClick="lbtn_Score_Click">评分</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("LID") %>' OnClick="lbtn_Detail_Click">详情</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="6">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
