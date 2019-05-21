<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysConfig.aspx.cs" Inherits="GKICMP.sysmanage.SysConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">系统配置项</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">当前学年</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear"  runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100px">当前学期</td>
                        <td align="left">
                           <asp:DropDownList runat="server" ID="ddl_Term" Width="150"></asp:DropDownList>
                        </td>


                    </tr>
                    <tr>
                        <td align="right" width="100px">本学期第一周</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_TFirst" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right">区平台配置</td>
                        <td align="left" >
                            <asp:TextBox runat="server" ID="txt_ServerUrl" Width="90%"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>

                        <td align="right">学段设置</td>
                        <td align="left" colspan="3">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }

                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBoxList ID="cbl_XD" Class="edilab" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="2">小学</asp:ListItem>
                                <asp:ListItem Value="3">中学</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
