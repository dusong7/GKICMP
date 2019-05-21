<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysRoleEdit.aspx.cs" Inherits="GKICMP.sysmanage.SysRoleEdit" %>

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

    </script>
    <style type="text/css">
        /*.listinfo input {
            height: auto;
        }*/

        .listinfo label {
            float: none;
            line-height: inherit;
        }

        select {
            height: 30px;
            border: 1px solid #79A3E2;
            border-radius: 2px;
        }

        option {
            border: 1px solid red;
        }

        input {
            border: 1px solid #79A3E2;
            /* height: 26px; */
            line-height: 26px;
            border-radius: 2px;
            text-indent: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">角色信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">角色名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RoleName" runat="server" datatype="*1-100" nullmsg="请填写角色名称" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">角色备注：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RoleDesc" runat="server" TextMode="MultiLine"
                                Rows="3" Width="80%" Height="60px" CssClass="MultiLinebg" MaxLength="100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">手机端权限：</td>
                        <td>
                            <asp:CheckBoxList ID="cbl_Button" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" RepeatLayout="Flow"></asp:CheckBoxList></td>
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

