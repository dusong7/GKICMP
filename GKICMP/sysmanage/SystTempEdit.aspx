<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystTempEdit.aspx.cs" Inherits="GKICMP.sysmanage.SystTempEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../EasyUI/jquery.min.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <link href="../EasyUI/themes/icon.css" rel="stylesheet" />
    <link href="../EasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../EasyUI/demo/demo.css" rel="stylesheet" />

    <script type="text/javascript">

        function getfile() {
            var hflogo = $id("hf_GraduatePhoto");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $('#sjr').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_SelectedValue").value = val;
                    //  alert(val);
                }
            });
            jQuery(document).ready(function () {
                jQuery("#form1").Validform();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">模板信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">模板内容：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TempContent" TextMode="MultiLine" runat="server" Rows="6" Width="100%" Height="300px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>

                        </td>
                         
                    </tr>
                    
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_TempContent');
    </script>
</body>
</html>
