<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairPeopleEdit.aspx.cs" Inherits="ICMP.assetmanage.RepairPeopleEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">受理报修管理</th>
                    </tr>

                    <tr>
                        <td align="right" width="120px">完成说明：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CompDesc" runat="server" Width="70%" datatype="*" nullmsg="请填写完成说明" CssClass="searchbg" Style="resize: none" TextMode="MultiLine" Columns="6" Height="100px"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>

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




