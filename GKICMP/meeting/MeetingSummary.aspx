<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingSummary.aspx.cs" Inherits="GKICMP.meeting.MeetingSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">会议纪要信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">主持人</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_MeetingHost" runat="server" datatype="ddl" errormsg="请选择主持人"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">缺席人员</td>
                        <td align="left">
                            <asp:CheckBoxList ID="chbl_AbsendUser" CssClass="edilab" runat="server" RepeatColumns="10" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">迟到人员</td>
                        <td align="left">
                            <asp:CheckBoxList ID="chbl_LateUser" CssClass="edilab" runat="server" RepeatColumns="10" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">会议纪要</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Minutes" TextMode="MultiLine" runat="server" MaxLength="100" datatyp="*" nullmsg="请选择主持人"
                                Rows="6" Width="70%" Height="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
