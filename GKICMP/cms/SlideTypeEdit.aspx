<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideTypeEdit.aspx.cs" Inherits="GKICMP.cms.SlideTypeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">类别信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">类别名称：</td>
                        <td>
                            <asp:TextBox ID="txt_STypeName" runat="server" datatype="*" nullmsg="请填写类别名称"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="100px">类别标识：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_TFlag" CssClass="searchbg" datatype="ddl" errormsg="请选择类别标识" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
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

