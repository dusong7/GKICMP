<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoCardApplicationAudit.aspx.cs" Inherits="GKICMP.teachermanage.NoCardApplicationAudit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">补卡信息审核</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">审核结果：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_AuditResult" runat="server">
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">审核意见：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AuditMark" runat="server" datatype="*" nullmsg="请填写审核意见" CssClass="searchbg" Height="100px" Rows="6" Style="resize: none" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span> </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>