<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LEDEdit.aspx.cs" Inherits="GKICMP.led.LEDEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">终端设备信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">品牌：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Brand" runat="server" ></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LName" runat="server" MaxLength="200" datatype="*" nullmsg="请输入品牌名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">通讯方式：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LCType" runat="server" ></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">IP地址：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_LIP" ></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">类型：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LType" runat="server" ></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">颜色：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LColor" runat="server" ></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">宽： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_SizeW" runat="server" name="Series"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">高： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_SizeH" runat="server" name="Series"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">亮度： </td>
                        <td align="left">
                             <asp:DropDownList ID="ddl_LBright" runat="server" >
                                 <asp:ListItem Value="1">1</asp:ListItem>
                                 <asp:ListItem Value="2">2</asp:ListItem>
                                 <asp:ListItem Value="3">3</asp:ListItem>
                                 <asp:ListItem Value="4">4</asp:ListItem>
                                 <asp:ListItem Value="5">5</asp:ListItem>
                                 <asp:ListItem Value="6">6</asp:ListItem>
                                 <asp:ListItem Value="7">7</asp:ListItem>
                                 <asp:ListItem Value="8">8</asp:ListItem>
                                 <asp:ListItem Value="9">9</asp:ListItem>
                                 <asp:ListItem Value="10">10</asp:ListItem>
                                 <asp:ListItem Value="11">11</asp:ListItem>
                                 <asp:ListItem Value="12">12</asp:ListItem>
                                 <asp:ListItem Value="13">13</asp:ListItem>
                                 <asp:ListItem Value="14">14</asp:ListItem>
                                 <asp:ListItem Value="15" Selected="True">15</asp:ListItem>
                             </asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick="$.close('A_id')" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        </form>
</body>
</html>

