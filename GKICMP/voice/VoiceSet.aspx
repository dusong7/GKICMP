<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoiceSet.aspx.cs" Inherits="GKICMP.voice.VoiceSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="本地配置"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">视频监控本地配置</th>
                    </tr>
                <tr>
                    <td class="tt">播放性能</td>
                    <td>
                        <select id="netsPreach" name="netsPreach" class="sel">
                            <option value="0">最短延时</option>
                            <option value="1">实时性好</option>
                            <option value="2">均衡</option>
                            <option value="3">流畅性好</option>
                        </select>
                    </td>
                    <td class="tt">图像尺寸</td>
                    <td>
                        <select id="wndSize" name="wndSize" class="sel">
                            <option value="0">充满</option>
                            <option value="1">4:3</option>
                            <option value="2">16:9</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tt">规则信息</td>
                    <td>
                        <select id="rulesInfo" name="rulesInfo" class="sel">
                            <option value="1">启用</option>
                            <option value="0">禁用</option>
                        </select>
                    </td>
                    <td class="tt">抓图文件格式</td>
                    <td>
                        <select id="captureFileFormat" name="captureFileFormat" class="sel">
                            <option value="0">JPEG</option>
                            <option value="1">BMP</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tt">录像文件打包大小</td>
                    <td>
                        <select id="packSize" name="packSize" class="sel">
                            <option value="0">256M</option>
                            <option value="1">512M</option>
                            <option value="2">1G</option>
                        </select>
                    </td>
                    <td class="tt">协议类型</td>
                    <td>
                        <select id="protocolType" name="protocolType" class="sel">
                            <option value="0">TCP</option>
                            <option value="2">UDP</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tt">录像文件保存路径</td>
                    <td colspan="3">
                        <input id="recordPath" type="text" class="txt" />&nbsp;<input type="button" class="btn" value="浏览" onclick="clickOpenFileDlg('recordPath', 0);" /></td>
                </tr>
                <tr>
                    <td class="tt">回放下载保存路径</td>
                    <td colspan="3">
                        <input id="downloadPath" type="text" class="txt" />&nbsp;<input type="button" class="btn" value="浏览" onclick="clickOpenFileDlg('downloadPath', 0);" /></td>
                </tr>
                <tr>
                    <td class="tt">预览抓图保存路径</td>
                    <td colspan="3">
                        <input id="previewPicPath" type="text" class="txt" />&nbsp;<input type="button" class="btn" value="浏览" onclick="clickOpenFileDlg('previewPicPath', 0);" /></td>
                </tr>
                <tr>
                    <td class="tt">回放抓图保存路径</td>
                    <td colspan="3">
                        <input id="playbackPicPath" type="text" class="txt" />&nbsp;<input type="button" class="btn" value="浏览" onclick="clickOpenFileDlg('playbackPicPath', 0);" /></td>
                </tr>
                <tr>
                    <td class="tt">回放剪辑保存路径</td>
                    <td colspan="3">
                        <input id="playbackFilePath" type="text" class="txt" />&nbsp;<input type="button" class="btn" value="浏览" onclick="clickOpenFileDlg('playbackFilePath', 0);" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button" class="editor" value="获取" onclick="clickGetLocalCfg();" />&nbsp;<input type="button" class="submit"  value="设置" onclick="    clickSetLocalCfg();" /></td>
                </tr>
                   
            </table>
        </div>

    </form>
</body>
</html>
