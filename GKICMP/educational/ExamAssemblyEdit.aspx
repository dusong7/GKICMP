<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamAssemblyEdit.aspx.cs" Inherits="GKICMP.educational.ExamAssemblyEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../utf8-net/ueditor.configs.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <title>智慧校园门户管理平台</title>
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
                        <td align="right" width="120px">年级：</td>
                        <td>
                            <asp:DropDownList ID="ddl_GradeID" CssClass="searchbg" datatype="ddl" errormsg="请选择年级"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="80px">学期：</td>
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
                            <span style="color: Red">*</span></td>
                        <td align="right">难易程度：</td>
                        <td>
                            <asp:DropDownList ID="ddl_Difficulty" CssClass="searchbg" runat="server" datatype="ddl" errormsg="请选择难易程度">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120px">练习时间(分钟)：
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Minutes" CssClass="searchbg" runat="server" datatype="zheng" nullmsg="请输入正确的练习时间"></asp:TextBox>
                            <span style="color: Red">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120px">题数：
                        </td>
                        <td colspan="3">单项选：<asp:TextBox ID="txt_dxx" runat="server" Width="25px" Height="20px"></asp:TextBox>&nbsp;题&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                            多选题：<asp:TextBox ID="txt_dxt" runat="server" Width="25px" Height="20px"></asp:TextBox>&nbsp;题&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                            填空题：<asp:TextBox ID="txt_tkt" runat="server" Width="25px" Height="20px"></asp:TextBox>&nbsp;题&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                            判断题：<asp:TextBox ID="txt_pdt" runat="server" Width="25px" Height="20px"></asp:TextBox>&nbsp;题&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                            主观题：<asp:TextBox ID="txt_zgt" runat="server" Width="25px" Height="20px"></asp:TextBox>&nbsp;题&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        </td>

                    </tr>
                </tbody>

            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" class="editor" onclick="Javascript: window.history.go(-1);" value="返回" />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>




