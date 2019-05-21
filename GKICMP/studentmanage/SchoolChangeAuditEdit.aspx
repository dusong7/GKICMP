<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolChangeAuditEdit.aspx.cs" Inherits="GKICMP.studentmanage.SchoolChangeAuditEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生变动审核信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80px">审核状态：</td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rdo_AduitState" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Selected="True">通过</asp:ListItem>
                                <asp:ListItem Value="2">驳回</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">审核意见：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AduitDesc" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg" datatype="*" nullmsg="请填写审核意见" Style="resize: none;"></asp:TextBox>
                            <span style="color: red;">*</span>
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
