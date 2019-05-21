<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPlanEdit.aspx.cs" Inherits="GKICMP.lessonplan.LessonPlanEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_Teachers" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">备课计划信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_LName" runat="server" datatype="*1-200" nullmsg="请填写名称" Width="200px" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">学年：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_LYear" datatype="*" nullmsg="请填写学年"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">学期：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_TID" datatype="ddl" errormsg="请选择学期"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right">校区：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_CID" datatype="ddl" errormsg="请选择校区"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">类型：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_LType" datatype="ddl" errormsg="请选择类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">执教教师：</td>
                        <td colspan="3">
                            <asp:TextBox ID="TeachID" cascadeCheck="false" runat="server" multiline="true" multiple="true" name="TeachID" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetTeacher" CssClass="easyui-combotree" TextMode="MultiLine" Rows="3" Height="30px" Width="70%"></asp:TextBox>
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

