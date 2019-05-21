<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverScoreEdit.aspx.cs" Inherits="GKICMP.electiver.ElectiverScoreEdit" %>

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
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
        <asp:HiddenField runat="server" ID="hf_StID" />
        <asp:HiddenField runat="server" ID="hf_StuName" />
        <asp:Literal runat="server" ID="ltl_Stu"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_EleID" />
        <asp:HiddenField runat="server" ID="hf_TermID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">选课成绩信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">学年度/学期：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_EYear"></asp:Literal>学年度
                            <asp:Literal runat="server" ID="ltl_TermID"></asp:Literal>
                        </td>
                    <%--</tr>
                    <tr>
                        <td align="right">选课任务：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_EleID" datatype="ddl" errormsg="请选择选课任务" OnSelectedIndexChanged="ddl_EleID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>--%>
                        <td align="right" width="120">课程名称：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_CourseID" datatype="ddl" errormsg="请选择选课课程" OnSelectedIndexChanged="ddl_CourseID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学生姓名：</td>
                        <td align="left" width="400px;">
                            <%--<asp:TextBox ID="txt_StuName" runat="server" name="Series" url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree" Width="83%"></asp:TextBox>--%>
                            <input id="Series" name="Series" style="width: 65%" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">分数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Score" runat="server" datatype="zhengnum" nullmsg="请填写分数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick="javascript: history.back(-1);" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $('#Series').combotree('setValues', $("#hf_StID").val().split(','));
        });
        function SetValue() {
            var U = new Array();
            var A = new Array();
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id); A.push(this.text);
                }
            });
            document.getElementById("hf_StID").value = U;
            document.getElementById("hf_StuName").value = A;
        };
        //mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>
