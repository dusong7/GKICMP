<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="GKICMP.educational.CourseEdit" %>

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
                        <th colspan="4" align="left">课程信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">课程名称：</td>
                        <td align="left" width="400px;">
                            <asp:TextBox ID="txt_CourseName" runat="server" datatype="*1-100" nullmsg="请填写年级名称" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">课程别名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CourseOther" runat="server" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否开设：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsOpen" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                                <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">课程等级：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseGrade" runat="server" datatype="ddl" nullmsg="请选择课程等级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否主课：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsMain" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否选修课程：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsElective" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
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


