<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActPersonEdit.aspx.cs" Inherits="GKICMP.schoolwork.StudentActPersonEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">报名学生信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">参与人：</td>
                        <td align="left" colspan="3">
                            <%--<input id="ActUsers" name="ActUsers" style="width: 75%;" class="easyui-combotree" runat="server" />--%>
                            <asp:TextBox ID="ActUsers" runat="server" name="ActUsers" cascadeCheck="false" multiline="true" multiple="true" onlyLeafCheck="true" url="../ashx/Tea.ashx?method=GetUser&data=''" CssClass="easyui-combotree" Width="70%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_ActUsers" runat="server" />
    </form>
</body>
</html>

