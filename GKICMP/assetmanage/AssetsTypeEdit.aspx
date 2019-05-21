<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsTypeEdit.aspx.cs" Inherits="ICMP.assetmanage.AssetsTypeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
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
                        <th colspan="4" align="left">
                            <asp:Literal ID="ltl_Type" runat="server"></asp:Literal></th>
                    </tr>
                    <tr runat="server" id="trpid">
                        <td align="right" width="120">上级名称</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_Parent" runat="server" Enabled="false"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">
                            <asp:Literal ID="ltl_Name" runat="server"></asp:Literal></td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_DataName" runat="server" datatype="*1-50" nullmsg="请填写基础数据类别名称" CssClass="searchbg" Width="220"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" class="note"><asp:Literal ID="ltl_DataDesc" runat="server"></asp:Literal></td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_DataDesc" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg"></asp:TextBox></td>
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

