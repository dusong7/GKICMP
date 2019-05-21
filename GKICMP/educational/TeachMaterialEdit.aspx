<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachMaterialEdit.aspx.cs" Inherits="GKICMP.educational.TeachMaterialEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
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

        function succ() {
            var id = document.getElementById("hf_CID").value;
            window.parent.location.href = "TeachMaterialList.aspx?id=" + id;
        }
    </script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教材信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">教材名称：</td>
                        <td align="left" width="300px">
                            <asp:TextBox ID="txt_TMName" runat="server" datatype="*1-100" nullmsg="请填写教材名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="80">所属版本：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_TEdition" runat="server" datatype="ddl" errormsg="请选择所属版本"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属年级：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_GID" datatype="ddl" errormsg="请选择所属年级"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">学期：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_TermID" runat="server" datatype="ddl" errormsg="请选择学期"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <%-- <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />--%>
                            <input type="button" class="editor" id="return" value="返回" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

