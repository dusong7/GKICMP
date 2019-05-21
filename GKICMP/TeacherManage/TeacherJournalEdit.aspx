<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherJournalEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherJournalEdit" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/common.js"></script>


    <script type="text/javascript">
        //function check() {
        //    if (document.getElementById("hf_TID").value == "") {
        //        alert("教师姓名不能为空");
        //        return false;
        //    }
        //}
        //$(function () {
        //    $.ajaxSettings.async = false;
        //    var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
        //    $.getJSON(url, function (data) { $('#Series').combotree({ data: data.data, multiple: false, /*multiline: true,*/ }); });
        //    $('#Series').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_TID").value = val;
        //        }
        //    });
        //    jQuery("#form1").Validform();
        //});
    </script>
    <script>
        //$(function () {
        //    $('#Series').combotree('setValues', [$("#hf_TID").val()]);
        //});
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">著作信息</th>
                    </tr>
                    <tr>
                        <td align="right">教师姓名：</td>
                        <td align="left" colspan="3">
                           <%-- <input id="Series" name="Series" runat="server" style="width: 80%" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">著作类别：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_JournalType" runat="server" datatye="ddl" errormsg="请选择著作类别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">学科领域：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_SubjectArea" runat="server" datatye="ddl" errormsg="请选择学科领域"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">著作名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_RewardName" runat="server" Style="width: 80%" datatype="*" nullmsg="请填写著作名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">出版社名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_PubName" runat="server" Style="width: 80%" datatype="*" nullmsg="请填写出版社名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">出版日期：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_PubDate" runat="server" datatype="*" Width="135px" nullmsg="请选择出版日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">出版号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PubNum" runat="server" datatype="*" nullmsg="请填写出版号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">是否上报：</td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rdo_IsReport" CssClass="edilab" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">本人撰写字数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_OnwerNum" runat="server" datatype="zheng" nullmsg="请填写本人撰写字数"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">总字数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TotelNum" runat="server" datatype="zheng" nullmsg="请填写总字数"></asp:TextBox><span style="color: Red; float: none">*</span>
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



