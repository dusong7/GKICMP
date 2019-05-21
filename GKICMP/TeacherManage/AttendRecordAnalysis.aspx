<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendRecordAnalysis.aspx.cs" Inherits="GKICMP.teachermanage.AttendRecordAnalysis" %>

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
            $('#btn_Import').click(function () {
                return openbox('A_id', 'AttendRecordImport.aspx', '', 860, 300, 3);
            });

            $('#btn_Analysis').click(function () {
                return openbox('A_id', 'AttendRecordSynchro.aspx', '', 650, 220, 58);
            });
        });

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AttendRecordDetail.aspx', 'id=' + id, 960, 700, 4);
        }

        function show(obj) {
            var a = $(obj).attr("tid");
            var b = $(obj).attr("IsAnalysis");
            var c = $("#txt_SDate").val();
            var d = $("#txt_EDate").val();
            //return openbox('A_id', 'AttendRecordDetail.aspx', 'id=' + a, 960, 700, 4);
            return openbox('A_id', 'AttendRecordSelectCD.aspx', 'id=' + a + '&IsAnalysis=' + b + '&Begin=' + c + '&End=' + d, 960, 550, 1);

            //return openbox('A_id', 'TeacherAssessmentEdit.aspx','id=' + id + '&flag=' + flag, 860, 500, 0);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_IsIsAnalysis" runat="server" />
        <asp:HiddenField ID="hf_Begin" runat="server" />
        <asp:HiddenField ID="hf_End" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="考勤分析"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div class="dvTab">
   <ul class="menuall">
      <li class="tab "><a href="TeacherHolidayManage.aspx">请假管理</a></li>
      <li class="tab activeTab"><a href="AttendRecordManage.aspx">考勤打卡</a></li>
  </ul>
<div class="dv"></div>
</div>--%>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <%-- <td align="right" width="80">工号：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_UserNum" runat="server"></asp:TextBox>
                        </td>--%>
                        <td align="right" width="80">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_TeaIDName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="80">打卡时间：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                        </td>
                        <td align="right" width="80" runat="server">部门：</td>
                        <td width="150" runat="server">
                            <asp:DropDownList ID="ddl_DepName" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <%-- <asp:Button ID="btn_Import" runat="server" Text="导入"   CssClass="listbtncss listinput" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

