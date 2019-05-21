<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuEvaluateEdit.aspx.cs" Inherits="GKICMP.studentmanage.StuEvaluateEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <%--  <link href="../css/green_formcss.css" rel="stylesheet" />--%>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>

    <script>
        //$(function () {
        //    $('#StuName').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_SelectedValue").value = val;
        //            //alert(val);
        //        }
        //    });

        //    jQuery("#form1").Validform();
        //});

        function showbox() {
            return parent.openbox('S_id', '../teachermanage/TeacherSelect.aspx', 'flag=5', 1250, 585, 8);
        }
    </script>
    <script>
        function clickSelect() {
            var selid = document.getElementById("slwb");
            var str = "";
            var s = 0;
            if (selid == null || selid.lenght < 1) {
                return str;
            }
            var k = 0;
            for (var i = 0; i < selid.length; i++) {
                if (selid.options[i].selected) {
                    if (s == 0) {
                        k = i;
                        str = selid.options[i].value;
                    }
                    else {
                        str = str + "，" + selid.options[i].value;
                    }
                    s++;
                }
            } if (s > 0) {
                document.getElementById("txt_Evaluate").value = str;
            }
            else {
                document.getElementById("txt_Evaluate").value = "";
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>


        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">评语信息</th>
                    </tr>
                    <tr>
                        <td align="right">学生姓名</td>
                        <td colspan="3">
                            <%--<input id="StuName" name="StuName" style="width: 90%;" class="easyui-combotree" runat="server"/>--%>
                            <asp:TextBox ID="Series" runat="server" name="Series" multiline="true" multiple="true" onlyLeafCheck="true" url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree" Width="83%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="120">学期</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">评语：</td>
                        <td align="left" colspan="3">
                            <div class="pz" style="float: left; width: 35%; height:auto; height:110px">
                                <asp:DropDownList ID="slwb" runat="server" class="slwb"  multiple="multiple" onclick="clickSelect()" Style="width:100%"></asp:DropDownList>
                            </div>
                            <asp:TextBox ID="txt_Evaluate" runat="server" TextMode="MultiLine" Rows="3" Width="60%" Height="100px" MaxLength="300" CssClass="searchbg" Style="float:left; margin-left:10px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                      <style>.listinfo span input{ float:left} .listinfo span label{ margin-top:0px}</style>
                            <asp:CheckBox ID="cb_IsOrNot" Style="float: left;" runat="server" Text="是否更新到评语库" BorderStyle="None" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='window.history.go(-1)' />
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

