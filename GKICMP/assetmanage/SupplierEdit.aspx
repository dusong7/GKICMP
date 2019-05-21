<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="ICMP.assetmanage.SupplierEdit" %>

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
                        <th colspan="4" align="left">供应商信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">供应商名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SupplierName" runat="server" datatype="*1-200" nullmsg="请填写供应商名称" CssClass="searchbg"
                                MaxLength="200"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">企业性质：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Enterprise" runat="server" datatype="*1-100" nullmsg="请填写企业性质" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">业务联系人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LinkUser" runat="server" datatype="*1-50" nullmsg="请填写业务联系人" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox><span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">联系人职务：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LinkPost" runat="server" datatype="*1-50" nullmsg="请填写联系人职务" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox><span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">联系人电话：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LinkPhone" runat="server" datatype="m" nullmsg="请填写联系人电话" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">主要经营范围：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MainAssest" runat="server" datatype="*1-500" nullmsg="请填写主要经营范围" CssClass="searchbg"
                                MaxLength="500"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">开户行：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BankName" runat="server" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox></td>
                        <td align="right" width="120">开户账号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BankNum" runat="server" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td align="right" width="120">资信等级：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Qualifications" runat="server"  CssClass="searchbg"
                                MaxLength="50"></asp:TextBox></td>
                        <td align="right" width="120">企业法人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Legal" runat="server"  CssClass="searchbg"
                                MaxLength="50"></asp:TextBox></td>
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

