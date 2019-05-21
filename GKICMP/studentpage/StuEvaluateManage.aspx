<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuEvaluateManage.aspx.cs" Inherits="GKICMP.studentpage.StuEvaluateManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>学生评语管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'StuEvaluateEdit.aspx', '', 840, 400, -1);
            });
        });

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StuEvaluateDetail.aspx', 'id=' + id, 840, 400, 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>我的档案<span>></span>我的评语
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">学年度：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_EYear" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80">学期：</td>
                        <td width="299">
                            <asp:DropDownList ID="ddl_Term" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle"></td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">学年度</th>
                        <th align="center">学期</th>
                        <th align="center">班级</th>
                        <th align="center">姓名</th>
                        <th align="center">评语内容</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("EYear")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("Term"))%></td>
                                <td><%#Eval("CName")%></td>
                                <td><%#Eval("StuName")%></td>
                                <td><%#Eval("Evaluate").ToString().Length>30?Eval("Evaluate").ToString().Substring(0,15)+"...":Eval("Evaluate")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详情" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("SEID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="6" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
