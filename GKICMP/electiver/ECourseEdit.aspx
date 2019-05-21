<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECourseEdit.aspx.cs" Inherits="GKICMP.electiver.ECourseEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">选修课课程信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">课程编码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CourseOther" runat="server" datatype="*" nullmsg="请填写课程编码" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="80">课程名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CourseName" runat="server" CssClass="searchbg" datatype="*" nullmsg="请填写课程名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="80">课程等级：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseGrade" runat="server" datatype="ddl" errormsg="请选择课程等级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="80">课程类别：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseType" runat="server" datatype="ddl" errormsg="请选择课程类别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="80">课程简介：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_CourseDesc" runat="server" Rows="6" Height="200px" Width="82%" TextMode="MultiLine" Style="resize: none" datatype="*" nullmsg="请填写课程简介"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>

                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



