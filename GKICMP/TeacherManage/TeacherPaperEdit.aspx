<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPaperEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherPaperEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_SubjectArea" runat="server" />
        <asp:HiddenField ID="hf_Included" runat="server" />
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">论文信息</th>
                    </tr>
                    <tr>
                        <td align="right">姓名：</td>
                        <td align="left" colspan="3">
                           <%-- <input id="tid" style="width: 80%;" runat="server" class="easyui-combotree" name="tid" />
                            <span style="color: Red; float: none">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">论文名称：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_PaperName" runat="server" Style="width: 80%;" datatype="*" nullmsg="请填写论文名称" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="10%">发表刊物名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Publication" runat="server" Style="width: 80%;" datatype="*" nullmsg="请填写发表刊物名称" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">发表年月：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PubDate" runat="server" datatype="*" nullmsg="请选择发表年月" CssClass="searchbg" MaxLength="100" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">卷号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Volume" runat="server" datatype="zheng" nullmsg="请填写卷号" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">期号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TermNum" runat="server" datatype="zheng" nullmsg="请填写期号" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">起始页码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginPage" runat="server" datatype="zheng" nullmsg="请填写起始页码" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">结束页码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EndPage" runat="server" datatype="zheng" nullmsg="请填写结束页码" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">本人角色：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_URoles" runat="server" datatype="ddl" nullmsg="请选择本人角色"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学科领域：</td>
                        <td align="left" width="40%">
                            <input id="SubjectArea" runat="server" class="easyui-combotree" name="SubjectArea" style="width: 90%;" /><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="13%">论文收录情况：</td>
                        <td align="left" width="40%">
                            <input id="Included" runat="server" class="easyui-combotree" name="SubjectArea" style="width: 90%;" />
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return check()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        function check() {
            //if ($("#hf_SelectedValue").val() == "") { alert("姓名不能为空"); return false; }
            if ($("#hf_SubjectArea").val() == "") { alert("学科领域不能为空"); return false; }
            if ($("#hf_Included").val() == "") { alert("论文收录情况不能为空"); return false; }
        }
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetBaseDate&data=xk";
            var url1 = "../ashx/GetBaseDate.ashx?method=GetBaseDate&data=lw";
            $.getJSON(url1, function (data) {
                $('#Included').combotree({
                    data: data.data,
                    multiple: false,
                    onlyLeafCheck: true,
                    /*multiline: true,*/
                });
                //$('#Included').combotree('setValues', [$("#hf_Included").val()]);
            });
            $.getJSON(url, function (data) {
                $('#SubjectArea').combotree({
                    data: data.data, multiple: false, onlyLeafCheck: true,/*multiline: true,*/
                });
                //$('#SubjectArea').combotree("setValues", $("#hf_SubjectArea").val()); $('#tid').combotree("setValues", $("#hf_SelectedValue").val());
            });
            $('#tid').combotree({
                onSelect: function (node) {
                    var val = node.id; document.getElementById("hf_SelectedValue").value = val;
                }
            });
            $('#SubjectArea').combotree({

                onSelect: function (node) {
                    var val = node.id; document.getElementById("hf_SubjectArea").value = val;
                }
            });
            $('#Included').combotree({
                onSelect: function (node) {
                    var val = node.id; document.getElementById("hf_Included").value = val;
                }
            });
            jQuery("#form1").Validform();
            $('#tid').combotree("setValues", $("#hf_SelectedValue").val());
            $('#Included').combotree("setValues", $("#hf_Included").val());
            $('#SubjectArea').combotree("setValues", $("#hf_SubjectArea").val());
        });
    </script>

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


