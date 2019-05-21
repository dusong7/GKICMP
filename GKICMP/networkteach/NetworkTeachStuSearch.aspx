<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetworkTeachStuSearch.aspx.cs" Inherits="GKICMP.networkteach.NetworkTeachStuSearch" %>

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
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Import').click(function () {
                return openbox('A_id', 'AttendRecordImport.aspx', '', 860, 300, 3);
            });

            $('#btn_Analysis').click(function () {
                return openbox('A_id', 'AttendRecordSynchro.aspx', '', 650, 220, 58);
            });
        });
        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'PersonnelChangeEdit.aspx', 'id=' + id, 860, 500, 0);
        //}
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AttendRecordDetail.aspx', 'id=' + id, 960, 700, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学习统计"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="80">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80" class="auto-style2">班级：</td>
                        <td width="200">
                            <div class="sel" style="float: left">
                                <%--<asp:DropDownList ID="ddl_ClaID" runat="server"></asp:DropDownList>--%>
                                <asp:TextBox ID="txt_ClaID" runat="server" name="txt_ClaID" url="../ashx/GetBaseDate.ashx?method=GetGradeOut&data=-1" CssClass="easyui-combotree" Width="90%"></asp:TextBox>
                            </div>
                        </td>
                        <td align="right" width="80">登录开始时间：</td>
                        <td width="260">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">

                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="btn_Import" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_Analysis" runat="server" Text="分析" CssClass="listanalysis" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%-- <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <%-- <th align="center">工号</th>--%>
                        <th align="center">班级</th>
                        <th align="center">姓名</th>
                        <th align="center">在线次数</th>
                        <th align="center">在线时长</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ClassName")%></td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#Eval("OnlineCount")%></td>
                                <td><%#Eval("OnlineTime")%></td>
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
