<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseTenderReturn.aspx.cs" Inherits="GKICMP.purchase.PurchaseTenderReturn" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>教装项目采购申请</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/select.js"></script>
    <script src="../js/common.js"></script>
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
                        <th colspan="4" align="left">项目保证金退还</th>
                    </tr>
                    <tr>
                    <tr>
                        <td align="right" valign="top" class="note">退还日期</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_BondDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择退还日期"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                        
                    </tr>
                  
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>








