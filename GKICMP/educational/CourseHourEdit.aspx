<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseHourEdit.aspx.cs" Inherits="GKICMP.educational.CourseHourEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
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
                        <td align="right" >年级：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_GID"  cascadeCheck="false" runat="server" multiline="true" multiple="true"  name="txt_GID" onlyLeafCheck="true" MaxLength="100" url="../ashx/GetBaseDate.ashx?method=Grade" CssClass="easyui-combotree"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseName" runat="server" datatype="ddl" errormsg="请选择课程"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">系数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CHours" runat="server" CssClass="searchbg" MaxLength="100" datatype="sum" nullmsg="请输入正确的系数"></asp:TextBox>
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




