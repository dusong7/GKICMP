<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DKAuditEdit.aspx.cs" Inherits="GKICMP.educational.DKAuditEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园考试管理</title>
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_EID" />
        <asp:HiddenField runat="server" ID="hf_begin" />
        <asp:HiddenField runat="server" ID="hf_end" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    
                    <tr>
                        <td align="right">申请人</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ApplyUserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">代课时间</td>
                        <td align="left">
                           <asp:Literal ID="ltl_SubBegin" runat="server"></asp:Literal>
                        </td>
                       <%-- <td align="right">节次</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SubName" runat="server" CssClass="searchbg"></asp:TextBox>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">申请原因</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_ApplyReason" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">代课人</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_SubUser" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="showokwin()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


