<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuPhysicalEdit.aspx.cs" Inherits="GKICMP.studentmanage.StuPhysicalEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
   <script src="../js/jquery.min.js"></script>
     <script src="../js/jquery.easyui.min.js"></script>
     <link href="../css/easyui.css" rel="stylesheet" />
     <link href="../css/demo.css" rel="stylesheet" />

    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/common.js"></script>
    

    <script type="text/javascript">
        //$(function () {
        //    $('#Series').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_TID").value = val;
        //            //alert(val);
        //        }
        //    });

        //    jQuery("#form1").Validform();//验证控件
        //});

       

        //function check() {
        //    if (document.getElementById("hf_TID").value == "") {
        //        alert("学生姓名不能为空");
        //        return false;
        //    }
        //}
        //$(function () {
        //    $.ajaxSettings.async = false;
        //    var url = "../ashx/Stu.ashx?method=StuGrade";
        //    //var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
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
     <%-- <script>
          $(function () {
              $('#Series').combotree('setValues', [$("#hf_TID").val()]);
          });
    </script>--%>

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
                        <th colspan="4" align="left">体质健康信息</th>
                    </tr>
                    <tr>
                        <td align="right">学生姓名：</td>
                        <td align="left" colspan="3">
                           <%-- <input id="Series" name="Series" runat="server" style="width: 80%" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>--%>
                            <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree"    Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" runat="server" datatype="*" nullmsg="请填写学年度"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                         <td align="right" width="120">学期：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term" datatype="ddl" errormsg="请选择学期信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">体重：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_StuWeight" runat="server"  datatype="sum" nullmsg="请填写体重"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">身高：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_StuHeight" runat="server"  datatype="sum" nullmsg="请填写身高"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    
                    <tr>
                        <td align="right" width="120">胸围：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Bust" runat="server" datatype="sum" nullmsg="请填写胸围"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">肺活量：</td>
                        <td align="left">
                           <asp:TextBox ID="txt_Vitalcapacity" runat="server" datatype="sum" nullmsg="请填写肺活量"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">左视力：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LVision" runat="server" datatype="sum" nullmsg="请填写左视力"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">右视力：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RVision" runat="server" datatype="sum" nullmsg="请填写右视力"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">左听力：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Lhearing" runat="server" datatype="sum" nullmsg="请填写左听力"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">右听力：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Rhearing" runat="server" datatype="sum" nullmsg="请填写右听力"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否有龋齿：</td>
                        <td align="left" colspan="3">
                           <%-- <asp:DropDownList runat="server" ID="ddl_DentalCaries" datatype="ddl" errormsg="请选择龋齿"></asp:DropDownList>
                             <span style="color: Red; float: none">*</span>--%>
                            <asp:RadioButtonList runat="server" ID="ddl_DentalCaries1" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList>
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
                         alert("不能选择年级或班级");
                         document.getElementsById("Series").value = ""
                     }
                 }
             });
             jQuery("#form1").Validform();
         });
    </script>

</body>
</html>
