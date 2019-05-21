<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherClassHourEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherClassHourEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />

     <script src="../js/jquery-1.8.2.min.js"></script>
     <script src="../js/jquery.min.js"></script>
     <script src="../js/jquery.easyui.min.js"></script>
     <link href="../css/easyui.css" rel="stylesheet" />
     <link href="../css/demo.css" rel="stylesheet" />

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //$('#TeacherName').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //    }
            //});
            jQuery("#form1").Validform();
        });
        //jQuery(document).ready(function () {
        //    jQuery("#form1").Validform();
        //});
    </script>
</head>
<body>
   <form id="form1" runat="server">
       <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_IDCard" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">课时基本信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="220px">教师姓名</td>
                        <td align="left">
                           <%-- <asp:TextBox ID="txt_TeacherName" runat="server" datatype="*" nullmsg="请选择教师信息"></asp:TextBox>
                            <span style="color: red;">*</span>
                            <img src="../images/selectbtn.png" id="btn_plancom" style="margin-top: 1px;" onclick="showbox()" />
                            <asp:HiddenField runat="server" ID="hf_TID" />--%>
                             <%--<input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server"/>
                             <span style="color: red;">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>

                        </td>
                        <td align="right" width="100px">所授年级</td>
                        <td align="left">
                            <%--<asp:DropDownList runat="server" ID="ddl_GradeID" datatype="ddl" mullmsg="请选择所授年级"></asp:DropDownList>--%>
                            <%--<asp:DropDownList runat="server" ID="ddl_GradeID">
                                <asp:ListItem Value="1" Selected></asp:ListItem>
                            </asp:DropDownList>--%>
                             <asp:DropDownList ID="ddl_GradeID" runat="server" datatype="ddl" errormsg="请选择所属年级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">主教学科</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_MainSubject" runat="server" datatype="ddl" errormsg="请选择主教学科"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">纯课时数</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MainHours" runat="server" datatype="zheng" nullmsg="纯课时数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">兼教学科</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_PartSubject"></asp:DropDownList>
                        </td>
                        <td align="right">兼课时数</td>
                        <td align="ledt">
                            <asp:TextBox ID="txt_PartHours" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">任行政教辅或班主任课时数</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Executive" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">学年度/学期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SchoolYear" runat="server" Width="85px" MaxLength="10"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddl_Semester" datatype="ddl" errormsg="请选择学年度/学期"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">语文、英语、数学跨教情况</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_SubDesc" TextMode="MultiLine" Rows="6" Width="60%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_THDesc" TextMode="MultiLine" Rows="6" Width="60%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="4">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <%--<asp:Button ID="btn_return" runat="server" Text="返回" class="editor" OnClick="btn_return_Click" />--%>
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
      <%-- <script type="text/javascript" >
        function SetValues() {
            var val = $('#TeacherName').combotree('getValue');
            document.getElementById("hf_SelectedValue").value = val;
            alert(val);
            // alert(valage);
        }
      </script>--%>
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
