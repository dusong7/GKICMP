<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseSelectionEdit.aspx.cs" Inherits="GKICMP.educational.CourseSelectionEdit" %>

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
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">         
        function setValue() {
            //var val = $('#Series').combotree('getValues');             获取包含上级id的集合
            //document.getElementById("hf_TID").value = val;
            var U = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                    document.getElementById("hf_TID").value = U;
                }
            });
            U = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.text);
                    document.getElementById("hf_CIDName").value = U;
                }
            });
        }  
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetCourse";
            $.getJSON(url, function (data) { $('#Series').combotree({ data: data.data, multiple: true, /*multiline: true,*/ }); });
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
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_TID" runat="server" />
        <asp:HiddenField ID="hf_CIDName" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">选课管理</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">学生姓名：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_UIDName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" runat="server" datatype="*" nullmsg="请填写学年度"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">学期：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term" datatype="ddl" errormsg="请选择学期信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">选课日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SelectDate" runat="server" datatype="*" nullmsg="请选择选课日期" Width="135px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">是否提交：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsSubmit" runat="server" CssClass="edilab" RepeatDirection="Horizontal"></asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">选课课程：</td>
                        <td align="left" colspan="3">
                            <input id="Series" name="Series" runat="server" style="width: 85%; height: 80px" class="easyui-combotree" /><span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick='setValue()' />
                            <%--<asp:Button ID="btn_Cancel" runat="server" Text="取消" CssClass=" editor" OnClick="btn_Cancel_Click" />--%>
                             <input type="button" class="editor" id="return" value="返回" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


