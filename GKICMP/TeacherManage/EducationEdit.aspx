<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EducationEdit.aspx.cs" Inherits="GKICMP.teachermanage.EducationEdit" %>

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
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>

    <script>
        $(function () {
            //$('#TeacherName').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //        //alert(val);
            //    }
            //});

            jQuery("#form1").Validform();
        });

        function showbox() {
            return parent.openbox('S_id', '../teachermanage/TeacherSelect.aspx', 'flag=5', 1250, 585, 8);
        }
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
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学历信息</th>
                    </tr>
                    <tr>
                        <td align="right">教师姓名</td>
                        <td colspan="3">
                           <%-- <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">获得学历：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择获得学历" ID="ddl_Education"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">获得学历的国家(地区)：</td>
                        <td>
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择获得学历的国家(地区)" ID="ddl_EduCountry"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">获得学历的院校或机构：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EduSchool" runat="server" datatype="*1-50" nullmsg="请填写获得学历的院校或机构" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">所学专业：</td>
                        <td>
                            <asp:TextBox ID="txt_EMajor" runat="server" datatype="*1-50" nullmsg="请填写所学专业" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">入学年月：</td>
                        <td>
                            <asp:TextBox ID="txt_InDate" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                        </td>
                        <td align="right">毕业年月：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_OutDate" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否师范类专业：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsTeach" CssClass="edilab" runat="server" RepeatDirection ="Horizontal"></asp:RadioButtonList>
                        </td>
                        <td align="right">学位层次：</td>
                        <td>
                            <asp:DropDownList runat="server"  ID="ddl_DegreeLevel"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学位名称：</td>
                        <td align="left">
                            <asp:DropDownList runat="server"  ID="ddl_DegreeName"></asp:DropDownList>
                        </td>
                        <td align="right">获得学位的国家(地区)：</td>
                        <td>
                            <asp:DropDownList runat="server"  ID="ddl_GradeCountry"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">获得学位的院校或机构：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_GradeSchool" runat="server"  MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">学位授予年月：</td>
                        <td>
                            <asp:TextBox ID="txt_GrantDate" runat="server"  onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学习方式：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_StudyType"></asp:DropDownList>
                        </td>
                        <td align="right">在学单位类别：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_CompanyType"></asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Literal ID="ltl_getValue" runat="server"></asp:Literal>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
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
