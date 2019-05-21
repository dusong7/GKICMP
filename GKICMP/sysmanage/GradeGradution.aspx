<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeGradution.aspx.cs" Inherits="GKICMP.sysmanage.GradeGradution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="120">毕业照：</td>
                        <td align="left" colspan="3">
                            <asp:Image ID="img_GraduatePhoto" runat="server" />
                            <div id="divimg">
                                <asp:FileUpload ID="fl_GraduatePhoto" runat="server" onchange="if(this.value)judgepic(this.value,this);showphoto();" />
                            </div>
                            <asp:HiddenField ID="hf_GraduatePhoto" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Notes" runat="server" TextMode="MultiLine"
                                Rows="3" Width="80%" Height="100px" CssClass="MultiLinebg" datatype="*1-100" nullmsg="请填写备注"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("B_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


