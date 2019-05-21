<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPlanBill.aspx.cs" Inherits="GKICMP.lessonplan.LessonPlanBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%--<link href="../css/demo.css" rel="stylesheet" />--%>
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">备课计划清单信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">周次：</td>
                        <td align="left">第<asp:TextBox ID="txt_WeekNum" runat="server" datatype="zheng" nullmsg="请填写周次" CssClass="searchbg" Width="50"></asp:TextBox>周
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="100">日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PDate" runat="server" datatype="*1-200" nullmsg="请填写日期" onclick="WdatePicker({skin:'whyGreen'})" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动内容：</td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txt_AContent" TextMode="MultiLine" datatype="*" nullmsg="请填写活动内容" Height="100px" Width="70%"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">指导教师：</td>
                        <td colspan="3">
                            <%--<asp:TextBox ID="TeachID" cascadeCheck="false" runat="server" multiline="true" multiple="true" name="TeachID" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetLessonTeacher" CssClass="easyui-combotree" TextMode="MultiLine" Rows="3" Height="30px" Width="70%"></asp:TextBox>--%>
                            <asp:CheckBoxList runat="server" ID="chk_TeachID" CssClass="edilab" RepeatDirection="Horizontal" RepeatColumns="14" RepeatLayout="Flow"></asp:CheckBoxList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

