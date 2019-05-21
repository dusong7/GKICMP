<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActPersonManage.aspx.cs" Inherits="GKICMP.schoolwork.StudentActPersonManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'StudentActDetail.aspx', 'id=' + id, 860, 480, 4);
        }

        function enroll(e)
        {
            var id = $(e).next().next().val();
            return openbox('A_id', 'StudentActPersonEdit.aspx', 'id=' + id, 860, 480, 53);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学生活动管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70">活动名称：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_ActName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="70">活动类型：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_ActType" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="70">活动日期：</td>
                        <td width="220">
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">活动类型</th>
                        <th align="center">活动名称</th>
                        <th align="center">活动日期</th>
                        <th align="center">活动地点</th>
                        <th align="center">指导教师</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ActTypeName")%></td>
                                <td><%#Eval("ActName")%></td>
                                <td><%#Eval("ABegin","{0:yyyy-MM-dd}")%>至<%#Eval("AEnd","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("ActAddress")%></td>
                                <td><%#Eval("CounselorName")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Enroll" runat="server" CssClass="listbtn btneditcolor" OnClientClick="return enroll(this);">报名</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详情</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("SAID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
