<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoCardApplicationDetail.aspx.cs" Inherits="GKICMP.teachermanage.NoCardApplicationDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">考勤补卡信息</th>
                    </tr>
                   
                    <tr>
                        <td align="right">补卡申请人：</td>
                        <td>
                            <asp:Literal ID="ltl_NoCardApplyUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right">补卡时间点：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_NoCardApplyDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">补卡说明：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_NoCardApplyDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="90">发起时间：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>


                    <tr>
                        <td align="right" width="90">审核人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_NoCardAuditUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right">审核时间：</td>
                        <td>
                            <asp:Literal ID="ltl_NoCardAuditDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="90">审核状态：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_NoCardState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">审核说明：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_NoCardAuditDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    
                    

                   
                    
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

