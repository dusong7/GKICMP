<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LectureStandardEdit.aspx.cs" Inherits="GKICMP.lecturemanage.LectureStandardEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <asp:HiddenField runat="server" ID="hf_PID" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">评分标准</th>
                    </tr>
                    <%--<tr>
                        <td align="right" width="70px">上级标准：
                        </td>
                        <td colspan="3">
                            <asp:DropDownList runat="server" ID="ddl_PID" Width="300px"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right" width="70px">分值：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_LScore" datatype="bigzero" nullmsg="请填写分值"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">排序：</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <asp:TextBox runat="server" ID="txt_SOrder" datatype="zhengnum" nullmsg="请填写排序"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">评分标准：</td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txt_StandardContent" Height="100px" Width="70%" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

