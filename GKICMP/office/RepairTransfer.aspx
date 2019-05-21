<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairTransfer.aspx.cs" Inherits="GKICMP.office.RepairTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">移交详情</th>
                    </tr>

                    <tr>

                        <td align="right" width="60px">移交人：</td>
                        <td>
                            <asp:DropDownList ID="ddl_TransferUser" datatype="ddl" errormsg="请选择移交人" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">移交说明：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TransferDesc" runat="server" CssClass="searchbg" Height="60px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="99%"></asp:TextBox>
                            <%-- <asp:TextBox ID="txt_HomeWork" runat="server" CssClass="searchbg" Height="120px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="80%"
                                datatype="*" nullmsg="请填写移交说明"></asp:TextBox>--%> </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>




