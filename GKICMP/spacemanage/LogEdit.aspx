<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogEdit.aspx.cs" Inherits="GKICMP.spacemanage.LogEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
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
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <th colspan="4" align="left">日志信息
                    </th>
                </tr>
                <tr>
                    <td align="right" width="100px">日志标题：</td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_LogTitle" Width="60%" datatype="*" nullmsg="请输入日志标题"></asp:TextBox>
                        <span style="color: red;">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">日志内容：</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">公开日志：</td>
                    <td colspan="3">
                        <asp:RadioButtonList runat="server" ID="rdo_IsPublish" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            <asp:ListItem Selected="True" Text="是" Value="1"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
    </script>
</body>
</html>

