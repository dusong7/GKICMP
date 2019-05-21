<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExerciseEdit.aspx.cs" Inherits="GKICMP.educational.ExerciseEdit" %>

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
    <script type="text/javascript" charset="utf-8" src="../utf8-net/kityformula-plugin/addKityFormulaDialog.js"></script>
    <script type="text/javascript" charset="utf-8" src="../utf8-net/kityformula-plugin/getKfContent.js"></script>
    <script type="text/javascript" charset="utf-8" src="../utf8-net/kityformula-plugin/defaultFilterFix.js"></script>
    <script src="../js/common.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
    <style>
        .rbl label {
            float: none;
        }

        .rbl input {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_aa" runat="server" Value="1" />
        <asp:HiddenField ID="hf_Answer" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="90px">题目：
                        </td>
                        <td colspan="3" style="position: relative">
                            <asp:TextBox ID="txt_Ttile" Style='line-height: normal;' runat="server" Width="99%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; position: absolute; right: 0px; bottom: 0px">*</span>
                        </td>

                    </tr>

                    <tr>
                        <td align="right">题型：</td>
                        <td>
                            <asp:DropDownList ID="ddl_EType" CssClass="searchbg" datatype="ddl" errormsg="请选择题型"
                                runat="server" OnSelectedIndexChanged="ddl_EType_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>

                        <td align="right" width="60px">难易程度：</td>
                        <td>
                            <asp:DropDownList ID="ddl_Difficulty" CssClass="searchbg" runat="server" datatype="ddl" errormsg="请选择难易程度">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">年级：</td>
                        <td>
                            <asp:DropDownList ID="ddl_GradeID" CssClass="searchbg" datatype="ddl" errormsg="请选择年级"
                                runat="server">
                            </asp:DropDownList>
                            &nbsp;</td>

                        <td align="right" width="60px">学期：</td>
                        <td>
                            <asp:DropDownList ID="ddl_Term" CssClass="searchbg" runat="server" datatype="ddl" errormsg="请选择学期">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">课程：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_CourseName" runat="server" datatype="ddl" errormsg="请选择学科名称">
                            </asp:DropDownList>
                        </td>
                        <td align="right">分数：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Score" CssClass="searchbg" runat="server" datatype="zheng" nullmsg="请输入正确的分数"></asp:TextBox>
                            <span style="color: Red">*</span></td>
                    </tr>
                    <tr id="tr_xx" runat="server">
                        <td align="right">选项：</td>
                        <td colspan="3" style="position: relative;">
                            <asp:TextBox ID="txt_Options" Style='line-height: normal;' runat="server" Width="99%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; position: absolute; right: 0px; bottom: 0px">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">答案：</td>
                        <td colspan="3" style="position: relative">
                            <asp:TextBox ID="txt_Answer" runat="server" Rows="6" Style="resize: none;" Width="98%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; position: absolute; right: 0px; bottom: 0px">*</span>

                        </td>
                    </tr>
                    <%-- <tr id="tr_da" runat="server">
                        <td align="right">答案：</td>
                        <td colspan="3" style="position: relative">
                            <asp:TextBox ID="txt_Answer" Style='line-height: normal;' runat="server" Width="99%" Height="200px" TextMode="MultiLine" Visible="false"></asp:TextBox>
                            <asp:RadioButtonList ID="rbl_Answer" runat="server" CssClass="rbl" Visible="false" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                            <asp:CheckBoxList ID="ckl_Answer" runat="server" CssClass="rbl" Visible="false" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                            <span style="color: Red; position: absolute; right: 0px; bottom: 0px">*</span>
                        </td>
                    </tr>--%>
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
        <script type="text/javascript">
            //实例化编辑器
            //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
            var ue = UE.getEditor('txt_Ttile');
            if ($val("hf_aa") == "1") {
                var ve1 = UE.getEditor('txt_Options');
            }
            //if ($val("hf_aa") == "0") {
            //    var ve2 = UE.getEditor('txt_Answer');
            //}
        </script>
    </form>
</body>
</html>


