<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LectureEdit.aspx.cs" Inherits="GKICMP.lecturemanage.LectureEdit" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CourseID" runat="server" Value="" />
        <asp:HiddenField ID="hf_ClaID" runat="server" Value="" />
        <asp:HiddenField ID="hf_TID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">听课登记</th>
                    </tr>
                    <tr>
                        <td align="right" width="70px">&nbsp;班级：
                        </td>
                        <td>
                            <input id="ClaID" name="ClaID" style="width: 70%;" class="easyui-combotree" runat="server" />
                            <span style="color: Red">*</span>
                        </td>
                        <td align="right">课程：</td>
                        <td>
                            <input id="CourseID" name="CourseID" style="width: 70%;" class="easyui-combotree" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">授课教师：</td>
                        <td>
                            <input id="UsersID" name="UsersID" style="width: 70%;" class="easyui-combotree" runat="server" />
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">听课时间</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <asp:TextBox runat="server" ID="txt_BeginDate" Width="150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" datatype="*" nullmsg="请选择开始时间"></asp:TextBox>--<asp:TextBox runat="server" ID="txt_EndDate" Width="150px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" datatype="*" nullmsg="请选择结束时间"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
    </script>

    <script>
        $(function () {
            //绑定班级
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetGrade&data=xs",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#ClaID').combotree({ data: d.data, multiple: false, onlyLeafCheck: true, /*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            //绑定课程
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetCourse",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#CourseID').combotree({ data: d.data, multiple: false, onlyLeafCheck: true, /*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            //绑定授课教师
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#UsersID').combotree({ data: d.data, multiple: false, onlyLeafCheck: true,/*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            //判断班级
            $('#ClaID').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#ClaID').combotree('clear');
                        alert("请选择班级");
                    }
                    else {
                        document.getElementById("hf_ClaID").value = node.id;
                    }
                }
            });
            //判断课程
            $('#CourseID').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#CourseID').combotree('clear');
                        alert("请选择课程");
                    }
                    else {
                        document.getElementById("hf_CourseID").value = node.id;
                    }
                }
            });
            //判断教师
            $('#UsersID').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#UsersID').combotree('clear');
                        alert("请选择教师");
                    }
                    else {
                        document.getElementById("hf_TID").value = node.id;
                    }
                }
            });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#UsersID').combotree('setValues', [$("#hf_TID").val()]);
            $('#CourseID').combotree('setValues', [$("#hf_CourseID").val()]);
            $('#ClaID').combotree('setValues', [$("#hf_ClaID").val()]);
        });
    </script>
    <%--<script>
        function SetValue() {
            var U = new Array();
            var A = new Array();
            $($("#AllUsersID").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#AllUsersID").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id); A.push(this.text);
                };
            });
            document.getElementById("hf_AlluserID").value = U;
            document.getElementById("hf_AllUsersText").value = A;
        };
    </script>--%>
</body>
</html>
