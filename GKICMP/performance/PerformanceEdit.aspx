<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceEdit.aspx.cs" Inherits="GKICMP.performance.PerformanceEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">考核信息</th>
                    </tr>
                    <tr>
                        <td align="right">考核名称：</td>
                        <td align="left">
                            <asp:TextBox runat="server" datatype="*" errormsg="请填写考核名称" ID="txt_PerName"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">是否启用：</td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="rdo_IsUse" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>