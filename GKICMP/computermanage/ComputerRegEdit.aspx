<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerRegEdit.aspx.cs" Inherits="GKICMP.computermanage.ComputerRegEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">班班通使用登记信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">课题：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_ChapterName" runat="server" datatype="*1-200" Width="80%" nullmsg="请填写课题"></asp:TextBox><span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">教师名称：</td>
                        <td align="left">
                            <asp:TextBox ID="Series" runat="server" name="Series" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree" Width="80%"></asp:TextBox><span style="color: Red">*</span>
                        </td>
                        <td align="right" width="100px">学科：
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_CourseID" datatype="ddl" errormsg="请选择学科"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Xyear" runat="server" datatype="*1-100" nullmsg="请填写学年度"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                        <td align="right">学期：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_XTerm"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">登记日期：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_RegDate" datatype="*" nullmsg="请填写登记日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $('#Series').combotree({
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined") {
                        alert("不能选择部门名称");
                        document.getElementsById("Series").value = ""
                    }
                }
            });
            jQuery("#form1").Validform();
        });
    </script>
</body>
</html>
