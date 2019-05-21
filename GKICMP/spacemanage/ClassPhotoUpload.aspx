<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassPhotoUpload.aspx.cs" Inherits="GKICMP.spacemanage.ClassPhotoUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function getfile() {
            var hflogo = $id("hf_SImage");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <asp:HiddenField ID="hf_SID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <th colspan="4" align="left">图片上传信息
                    </th>
                </tr>
                <tr>
                    <td align="right" width="80px">照片名称：</td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_StuID" Width="60%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">图片：</td>
                    <td colspan="3">
                        <div id="divimg">
                            <asp:FileUpload ID="fl_SImage" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            <img src="../images/addfile.gif" alt="" style='cursor: pointer; margin-bottom: -3px'
                                onclick="addfile('divimg')" />
                        </div>
                        <asp:HiddenField ID="hf_SImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">描述：</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txt_SCReason" TextMode="MultiLine" Height="100px" Width="60%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="return getfile()" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
