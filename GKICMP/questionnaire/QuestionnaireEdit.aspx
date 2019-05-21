<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionnaireEdit.aspx.cs" Inherits="GKICMP.questionnaire.QuestionnaireEdit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
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
        <asp:HiddenField runat="server" ID="hf_QID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">问卷信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">问卷名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_QuestName" runat="server" Width="80%" datatype="*" nullmsg="请填写问卷调查名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">注意事项：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Questxplain" TextMode="MultiLine" runat="server" Width="80%" Height="100px" datatype="*" nullmsg="请填写注意事项"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120" class="auto-style1">是否实名：</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_IsName" runat="server">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">投票角色：</td>
                        <td align="left" colspan="3">
                            <asp:CheckBoxList ID="cbl_Role" runat="server" CssClass="edilab" RepeatColumns="8" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">截止日期：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_LastDate" runat="server" datatype="*" nullmsg="请填写截止日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" width="120" class="auto-style1">是否发布：</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_IsPublish" runat="server">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
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



