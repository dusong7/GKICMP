<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomGroupingsEdit.aspx.cs" Inherits="GKICMP.oamanage.CustomGroupingsEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />

    <link href="../css/green_formcss.css" rel="stylesheet" />


    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_FID" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">分组信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">分组名称</td>
                        <td>
                            <asp:TextBox ID="txt_DepName" runat="server" datatype="*" nullmsg="请输入分组名称"></asp:TextBox>
                            <span style="color: red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">教师姓名</td>
                        <td>
                            <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server" /><span style="color: red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <input id="cancell" class="editor" name="button" onclick="javascript: window.history.back(-1);" type="button" value="取消" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#TeacherName').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#TeacherName').combotree('setValues', $("#hf_SelectedValue").val().split(','));
        });
    </script>
    <script>
        function SetValue() {
            var U = new Array();
            $($("#TeacherName").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#TeacherName").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                };
            });
            document.getElementById("hf_SelectedValue").value = $.unique(U);
        };
    </script>
</body>
</html>
