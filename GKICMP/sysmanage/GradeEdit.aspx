<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeEdit.aspx.cs" Inherits="GKICMP.sysmanage.GradeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>

    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />


    <script type="text/javascript">
        function getfile() {
            var hflogo = $id("hf_GraduatePhoto");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>

    <script type="text/javascript">
        //$(function () {
        //    $('#sjr').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_SelectedValue").value = val;
        //            //  alert(val);
        //        }
        //    });
        //    jQuery(document).ready(function () {
        //        jQuery("#form1").Validform();
        //    });
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">年级信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">入学年份：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_GradeYear" runat="server" datatype="zheng" nullmsg="请填写入学年份" CssClass="searchbg"
                                MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                         
                    </tr>
                    <tr>
                        <td align="right" width="120">学段：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_ShortName" runat="server" Width="80" datatype="ddl" nullmsg="请选择学段"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" width="120" >班级数：</td>
                        <td align="left" >
                             <asp:TextBox ID="txt_ClassNum" runat="server" datatype="zheng" nullmsg="请填写入班级数" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">年级负责人：</td>
                        <td align="left" colspan="3">
                            <%--<input id="sjr" name="sjr" style="width: 85%; height: 80px" class="easyui-combotree" />
                                 <span style="color: Red; float: none">*</span>--%>
                              <asp:TextBox ID="txt_Duty"  runat="server" name="sjr"   CssClass="easyui-combotree"    ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
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
             $('#txt_Duty').combotree({
                 onSelect: function (node) {
                     if (typeof (node.children) != "undefined") {
                         alert("不能选择部门名称");
                         document.getElementsById("txt_Duty").value = ""
                     }
                     var val = node.id;
                     document.getElementById("hf_SelectedValue").value = val;
                 }
             });
            
             jQuery("#form1").Validform();
         });
    </script>
</body>
</html>

