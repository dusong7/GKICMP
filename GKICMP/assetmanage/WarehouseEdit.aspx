<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseEdit.aspx.cs" Inherits="GKICMP.assetmanage.WarehouseEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
     <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
                        <th colspan="2" align="left">基础数据信息</th>
                    </tr>
                   
                    <tr>
                        <td align="right">仓库名称：</td>
                        <td align="left">
                            <%--<asp:TextBox ID="txt_DataName" runat="server"  CssClass="searchbg" Width="200"></asp:TextBox>--%>
                            <asp:TextBox ID="txt_DataName" runat="server" datatype="*1-100" nullmsg="请填写数据名称"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Desc" TextMode="MultiLine" Rows="6" runat="server" Width="90%"></asp:TextBox>
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




