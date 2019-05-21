<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachMChapterDetail.aspx.cs" Inherits="GKICMP.educational.TeachMChapterDetail" %>

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

        function succ() {
            var tmid = document.getElementById("hf_TMID").value;
            window.location.href = "TeachMChapterManage.aspx";
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
        <asp:HiddenField runat="server" ID="hf_TMID" />
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="center">
                            <span style="color: #808080; font-weight: bold; font-size: 16px;">《<asp:Literal runat="server" ID="ltl_ChapterName"></asp:Literal>》
                            </span></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltl_ChapterContent"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

