<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamPaperPracticeEdit.aspx.cs" Inherits="GKICMP.educational.ExamPaperPracticeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/My97/WdatePicker.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>

    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_gid" runat="server" />
        <asp:HiddenField ID="hf_AlluserID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">要求完成时间：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_CompleteDate" runat="server" datatype="*" Width="135px" nullmsg="请选择完成日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学生：</td>
                        <td align="left" colspan="3">
                            <input id="AllUsersID" name="AllUsersID" style="width: 90%;" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120px">练习要求：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ExcDesc" runat="server" Style="resize: none;" TextMode="MultiLine" Rows="6" Height="100px" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="javascript: window.history.back(-1)" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetStu&gid=" + $("#hf_gid").val(),
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#AllUsersID').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#AllUsersID').combotree('setValues', $("#hf_AlluserID").val().split(','));
        });
    </script>
    <script>
        function SetValue() {
            var U = new Array();
            $($("#AllUsersID").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#AllUsersID").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                };
            });
            document.getElementById("hf_AlluserID").value = U;
        };
    </script>
</body>
</html>



