<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamPaperEdit.aspx.cs" Inherits="GKICMP.educational.ExamPaperEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function showbox() {
            return parent.openbox('W_id', 'ExerciseMore.aspx', 'nj=' + $val("ddl_GradeID") + '&xq=' + $val("ddl_Term") + '&kc=' + $val("ddl_CourseName"), 1120, 585, 8);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">试卷名称：
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_PaperName" CssClass="searchbg" runat="server" Width="90%" datatype="*" nullmsg="请输入试卷名称"></asp:TextBox>
                            <span style="color: Red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">年级：</td>
                        <td>
                            <asp:DropDownList ID="ddl_GradeID" CssClass="searchbg" datatype="ddl" errormsg="请选择年级"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right">学期：</td>
                        <td>
                            <asp:DropDownList ID="ddl_Term" CssClass="searchbg" runat="server" datatype="ddl" errormsg="请选择学期">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_CourseName" runat="server" datatype="ddl" errormsg="请选择学科名称">
                            </asp:DropDownList>
                        </td>
                        <td align="right">练习时间(分钟)：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Minutes" CssClass="searchbg" runat="server" datatype="zheng" nullmsg="请输入正确的练习时间"></asp:TextBox>
                            <span style="color: Red">*</span></td>
                    </tr>
                    <tr id="tr" runat="server">
                        <td align="right" width="120px">题目：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_Name" Width="90%"></asp:TextBox><img src="../images/selectbtn.png" onclick="showbox()" />
                            <asp:HiddenField runat="server" ID="hf_EID" />
                        </td>
                    </tr>
                </tbody>

            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



