<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplayEmailEdit.aspx.cs" Inherits="GKICMP.mailmanage.ReplayEmailEdit" %>

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
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_EID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">回复消息</th>
                    </tr>
                    <tr>
                        <td align="right" width="70px">消息标题：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_EmailTitle" Width="600px" CssClass="searchbg" datatype="*1-100" nullmsg="请填写消息标题" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">正文：</td>

                        <td align="left" colspan="5" style="line-height: 20px;">
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
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
