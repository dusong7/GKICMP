<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeTableEdit.aspx.cs" Inherits="GKICMP.speech.TimeTableEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
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
        <div class="listcent    pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">作息时间</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">作息名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_RestName" runat="server" datatype="*" Width="50%" nullmsg="请填写作息名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginTime" runat="server" datatype="*1-50" nullmsg="请选择开始时间" MaxLength="50" CssClass="searchbg" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">结束时间：</td>
                        <td>
                            <asp:TextBox ID="txt_EndTime" runat="server" datatype="*1-50" nullmsg="请选择结束时间" MaxLength="50" CssClass="searchbg" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始铃声：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择开始铃声" ID="ddl_BMID"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="90">结束铃声：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择结束铃声" ID="ddl_EMID"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">是否预备：</td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rdo_IsGetSet" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab" OnSelectedIndexChanged="rdo_IsGetSet_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right" width="90">预备铃：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RMID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">适用星期：</td>
                        <td align="left">
                            <%--<asp:DropDownList runat="server" ID="ddl_Weeks" datatype="ddl" errormsg="请选择适用星期"></asp:DropDownList>--%>
                            <asp:CheckBoxList runat="server" ID="ck_Weeks" CssClass="edilab" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="1">星期一</asp:ListItem>
                                <asp:ListItem Value="2">星期二</asp:ListItem>
                                <asp:ListItem Value="3">星期三</asp:ListItem>
                                <asp:ListItem Value="4">星期四</asp:ListItem>
                                <asp:ListItem Value="5">星期五</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <%--<td align="right" width="90">是否允许录制：</td>
                        <td align="left">
                            <asp:TextBox ID="TextBox2" runat="server" datatype="m" nullmsg="请填写手机号码" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>--%>
                        <td align="right" width="90">是否启用：</td>
                        <td align="left" colspan="3">
                            <asp:RadioButtonList runat="server" ID="rdo_IsUse" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除" CssClass="addbtn" OnClick="btn_Delete_Click" />
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




