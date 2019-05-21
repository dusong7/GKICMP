<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamRoomEdit.aspx.cs" Inherits="GKICMP.educational.ExamRoomEdit" %>

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
        <asp:HiddenField runat="server" ID="hf_EID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">考场信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">考试名称：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_EID" datatype="ddl" errormsg="请选择年级信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td> </tr>
                    <tr>
                        <td align="right" width="120">教室名称：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_CRID" datatype="ddl" errormsg="请选择教室"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">考场号：</td>
                        <td align="left">
                            第<asp:TextBox ID="txt_RoomNum" runat="server" datatype="*" nullmsg="请填写考场号"></asp:TextBox>考场
                            <span style="color: Red; float: none">*</span>
                        </td> </tr>
                    <tr>
                        <td align="right" width="120">学生数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_StuNum" runat="server" datatype="*" nullmsg="请填写学生数" CssClass="searchbg" Text="30"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">教师数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TeaNum" runat="server" datatype="*" Width="135px" nullmsg="请填写教师数" Text="2" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
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



