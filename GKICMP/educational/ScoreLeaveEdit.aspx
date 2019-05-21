<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreLeaveEdit.aspx.cs" Inherits="GKICMP.educational.ScoreLeaveEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
    <style>
        .ckl label {
            float: none;
        }

        .ckl input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">分数等级信息</th>
                    </tr>
                    <tr>
                        <td align="right">年级：</td>
                        <td align="left">
                            <asp:CheckBoxList ID="ckl_GID" runat="server" CssClass="ckl" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学科名称：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseName" runat="server" datatype="ddl" nullmsg="请选择学科名称"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">分数等级：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_SLName" runat="server" datatype="ddl" nullmsg="请选择分数等级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">分数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BScore" runat="server" CssClass="searchbg" MaxLength="5" datatype="zheng" size="10" nullmsg="请输入正确的开始分数"></asp:TextBox>
                            ≤ 分数 ＜
                            <asp:TextBox ID="txt_EScore" runat="server" CssClass="searchbg" MaxLength="100" datatype="zheng" nullmsg="请输入正确的结束分数" size="10"></asp:TextBox>
                            <span style="color: Red; float: none">
                                <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>



                    <tr>
                        <td colspan="2" align="center">
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



