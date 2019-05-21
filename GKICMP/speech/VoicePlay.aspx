<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoicePlay.aspx.cs" Inherits="GKICMP.speech.VoicePlay" %>

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
    <style>
        .editor {
            margin-top: 0px;
            display: inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="智能广播"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="语音播报"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">语音播报</th>
                    </tr>
                    <tr>
                        <td align="right" width="150">播报内容：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Content" runat="server" datatype="*" nullmsg="请填写内容" Font-Size="Larger" Font-Bold="true" MaxLength="200" Width="70%" Height="150px" CssClass="searchbg" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                            <audio id="tryListen" style="display: none;">
                                <source src="../ashx/Handler1.ashx?text=111" type="audio/mp3" /></audio>
                        </td>


                    </tr>
                    <tr>
                        <td align="right">发音人选择</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Select" runat="server">
                                <asp:ListItem Value="0">女声</asp:ListItem>
                                <asp:ListItem Value="1">男声</asp:ListItem>
                                <asp:ListItem Value="3">情感合成-男声</asp:ListItem>
                                <asp:ListItem Value="4">情感合成-女声</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <a id="btn_Try" title="本地试听" style="cursor: pointer" class="editor" onclick="Play()">本地试听</a>
                            <asp:Button ID="btn_Sumbit" runat="server" Text="立即播放" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
    <script>
        function Play() {
            var a = document.getElementById("tryListen").src;
            var b = $("#ddl_Select").val();
            document.getElementById("tryListen").src = "../ashx/Handler1.ashx?text=" + encodeURI($("#txt_Content").val()) + "&type=" + b;
            var b = document.getElementById("tryListen").src
            $("#tryListen")[0].play();
        }
    </script>
</body>
</html>


