<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusicLibEdit.aspx.cs" Inherits="GKICMP.speech.MusicLibEdit" %>

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


        function getfile() {
            var hfatta = $id("hf_UpFile");
            var careful = $id("more").getElementsByTagName("input");
            hfatta.value = careful.length;
        }
    </script>
    <style>
        .pz .select_box {
            display: none;
        }

        .listinfo label {
            float: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_imageurl" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Size" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>

                    <tr>
                        <td align="right" width="90px">音乐名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Name" Width="80%" CssClass="searchbg" datatype="*1-100" nullmsg="请填写音乐名称" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">附件：</td>
                        <td>
                            <div id="more">
                                <a href='<%=Url %>'><%=Name %> </a>
                                <br />
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgemp3(this.value,this);" />

                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


