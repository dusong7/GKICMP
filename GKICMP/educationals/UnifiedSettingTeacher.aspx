<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnifiedSettingTeacher.aspx.cs" Inherits="GKICMP.educationals.UnifiedSettingTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/common.js"></script>
    <script>
        function check() {
            if (document.getElementById("hf_TID").value == "") {
                alert("教师姓名不能为空");
                return false;
            }
        }
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
            $.getJSON(url, function (data) { $('#Series').combotree({ data: data.data, multiple: false, /*multiline: true,*/ }); });
            $('#Series').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_TID").value = val;
                }
            });
            jQuery("#form1").Validform();
        });

    </script>
    <script>
        $(function () {
            $('#Series').combotree('setValues', [$("#hf_TID").val()]);
        });
    </script>
    <style>
        .rb label {
            float: none;
        }

        .rb input {
            height: 13px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_TID" runat="server" />


        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">配置教师信息</th>
                    </tr>
                    <tr>
                        <td align="right">学科：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CourseName" runat="server" Width="90px" Enabled="false"></asp:TextBox>
                        </td>

                        <td align="right">教师：</td>
                        <td align="left">
                            <input id="Series" runat="server" class="easyui-combotree" editable="true"  name="Series" />
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">班级：</td>
                        <td align="left" colspan="3">
                            <asp:CheckBoxList ID="ckl_Claid" runat="server" CssClass="rb" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left">
                            <asp:Label ID="lbl_TeacherDetail" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick='return check()' />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                            <%--<input type="button" name="button" id="cancell" value="取消" class="editor" onclick="javascript: window.history.back(-1)" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


