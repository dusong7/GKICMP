<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineEdit.aspx.cs" Inherits="GKICMP.test.OnlineEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <title>Office在线编辑</title>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/script.js"></script>
    <style>
        html, body {
            margin: 0px;
            padding: 0px;
            height: 100%;
        }
    </style>

</head>
<body onload="InitEvent()">
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                <tr>
                    <td id="oframe1">
                        <object classid="clsid:00460182-9E5E-11d5-B7C8-B8269041DD57" id="oframe" width="100%" codebase="../ActiveX/DSOframer/DSOframer.CAB#version=1,0,0,0">
                            <param name="BorderStyle" value="1" />
                            <param name="TitlebarColor" value="52479" />
                            <param name="TitlebarTextColor" value="0" />
                            <param name="Menubar" value="1" />
                            <param name="Titlebar" value="0" />
                            <param name="Menubar" value="0" />
                        </object>
                    </td>
                </tr>
            </table>
            <div style="display: none">
                <object id="WebFile" classid="clsid:B8B4E744-E5E1-4674-87C6-8914B4E3CC4B" codebase="../ActiveX/WebFileHelper.cab#version=1.1.0.0" viewastext></object>
                <object id="WebFile2" classid="clsid:2D18530F-D21E-472F-99C9-96D881BD43BE" codebase="../ActiveX/WebFileHelper2.cab#version=2.2.0.0" viewastext></object>
            </div>
            <div>
                <asp:HiddenField ID="hf_LoadFile" runat="server" />
                <input id="btn_save" type="button" value="保存" style="background: #66ca7b; width: 100%; border: none; height: 40px; color: white" />
            </div>
            <div>
                <h5>如页面不能加载，请手动注册文件。</h5><h5>注册方法：1.点击下载下面的安装包。2.解压文件。3.打开文件找到【以管理员身份运行.bat】文件，以管理员身份运行，系统提示注册成功即可</h5>
                <h5>文件下载地址：<a href="../ActiveX/Register.rar">手动注册下载</a></h5>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript">
    $(function () {
        OpenWebWord("<%= DocUrl %>");
    })
    document.getElementById("btn_save").onclick = function () {
        UploadWord("<%= Request.Url.Authority %>", "<%= Path %>");
    }
    //alert(document.body.clientHeight);
    $("#oframe").height(document.body.clientHeight - 200);
    window.onresize = function () {
        $("#oframe").height(document.body.clientHeight - 200);
    }
</script>
</html>
