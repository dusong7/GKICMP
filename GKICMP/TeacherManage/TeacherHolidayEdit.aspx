<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherHolidayEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherHolidayEdit" %>


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
    <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">长假信息</th>
                    </tr>
                    <tr>
                        <td align="right">教师姓名</td>
                        <td align="left" colspan="3">
                            <%-- <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server"/>--%>
                            <asp:TextBox ID="Series" runat="server" name="Series" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree" Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">长假类型</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_HType" runat="server" datatype="ddl" errormsg="请选择长假类型"></asp:DropDownList>

                        </td>
                        <td align="right">天数</td>
                        <td align="left">
                             <asp:TextBox ID="txt_HDays" runat="server" datatype="bigzero" nullmsg="请填写天数" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_HStartDate" runat="server" datatype="*" nullmsg="请选择开始时间" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">结束时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_HEndDate" runat="server" ckdate="txt_HStartDate" datatype="*" nullmsg="请选择结束时间" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">请假原因：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_HolidayDesc" runat="server" TextMode="MultiLine" Rows="3" Width="80%" Height="90px" MaxLength="500" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">附件：</td>
                        <td colspan="3">
                            <asp:Image ID="img_SImage" runat="server" Width="150" Height="100" />
                            <div id="divimg">
                                <asp:FileUpload ID="fl_SImage" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_SImage" runat="server" />
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
