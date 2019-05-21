<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuQualityEdit.aspx.cs" Inherits="GKICMP.studentmanage.StuQualityEdit" %>

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

    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生素质评价信息</th>
                    </tr>
                    <tr>
                        <td align="right">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" runat="server" datatype="*" nullmsg="请填写学年度" CssClass="searchbg" MaxLength="100"> </asp:TextBox>
                        </td>
                        <td align="right">学期：</td>
                        <td>
                            <asp:DropDownList ID="ddl_Term" runat="server" Height="30px"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学生：</td>
                        <td align="left" colspan="3"><%--onlyleafcheck="true"--%> 
                            <asp:TextBox ID="txt_StID"  runat="server" name="txt_StID" cascadeCheck="false" multiline="true" multiple="true" onlyLeafCheck="true"   url="../ashx/Stu.ashx?method=StuGrade"  CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">思想道德：</td>
                        <td>
                            <asp:DropDownList ID="ddl_SXDD" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>

                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">勤奋学习：</td>
                        <td>
                              <asp:DropDownList ID="ddl_QFXX" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>
                      
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="10%">身体素质：</td>
                        <td align="left">
                             <asp:DropDownList ID="ddl_STSZ" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>
                        
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="10%">审美塑美能力：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_SMSMNL" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>
                       
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">生活劳动技能：</td>
                        <td align="left">
                             <asp:DropDownList ID="ddl_SHLDJN" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>
                    
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">创造精神创造能力：</td>
                        <td align="left">
                             <asp:DropDownList ID="ddl_CZJSCZNL" runat="server">
                                <asp:ListItem Selected="True">优秀</asp:ListItem>
                                <asp:ListItem>良好</asp:ListItem>
                                <asp:ListItem>合格</asp:ListItem>
                                <asp:ListItem>不合格</asp:ListItem>
                            </asp:DropDownList>
               
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <%--<input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />--%>
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <asp:HiddenField ID="hf_DepID" runat="server" />
        <asp:HiddenField ID="hf_DutyUser" runat="server" />
        <asp:HiddenField ID="hf_AlluserID" runat="server" />
        <asp:HiddenField ID="hf_AllUsersText" runat="server" />
        <asp:Literal ID="ltl_Get" runat="server"></asp:Literal>
    </form>
    <script>
        //function check() {
        //    if ($("#hf_DutyUser").val() == "") { alert("请选择责任人"); return false; }
        //    if ($("#hf_DepID").val() == "") { alert("请选择部门"); return false; }
        //}
        //$(function () {
        //    $.ajax({
        //        url: "../ashx/GetBaseDate.ashx",
        //        cache: false, type: "GET",
        //        data: "method=GetDep&data=js",
        //        dataType: "json",
        //        async: false,
        //        success: function (d) {
        //            $('#DepID').combotree({ data: d.data, multiple: false, });
        //            //var c = $("#hf_DepID").val(); $('#DepID').combotree('setValues', [c]);
        //        },
        //        error: function () { alert("查询出错，请稍候再试"); }
        //    });
        //    $.ajax({
        //        url: "../ashx/GetBaseDate.ashx",
        //        cache: false, type: "GET",
        //        data: "method=GetUser&data=js",
        //        dataType: "json",
        //        async: false,
        //        success: function (d) {
        //            $('#DutyUser').combotree({ data: d.data, multiple: false, onlyLeafCheck: true, /*multiline: true,*/ });
        //            $('#AllUsersID').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
        //            //var a = $("#hf_AlluserID").val().split(',');
        //            //var c = $("#hf_DutyUser").val();
        //            //$('#AllUsers').combotree('setValues', $("#hf_AlluserID").val().split(','));
        //            //$('#DutyUser').combotree('setValues', [$("#hf_DutyUser").val()]);
        //        },
        //        error: function () { alert("查询出错，请稍候再试"); }
        //    });
        //    $('#DutyUser').combotree({
        //        onSelect: function (node) {
        //            var tree = $(this).tree;
        //            //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
        //            var isLeaf = tree('isLeaf', node.target);
        //            if (!isLeaf) {
        //                //清除选中  
        //                $('#DutyUser').combotree('clear');
        //            }
        //            else {
        //                document.getElementById("hf_DutyUser").value = node.id;
        //                //alert(document.getElementById("hf_SelectedValue").value)
        //            }
        //            //var val = node.id;
        //            //document.getElementById("hf_DutyUser").value = val;
        //        }
        //    });
        //    $('#DepID').combotree({
        //        onSelect: function (node) {
        //            var tree = $(this).tree;
        //            //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
        //            var isLeaf = tree('isLeaf', node.target);
        //            if (!isLeaf) {
        //                //清除选中  
        //                $('#DepID').combotree('clear');
        //            }
        //            else {
        //                document.getElementById("hf_DepID").value = node.id;
        //                //alert(document.getElementById("hf_SelectedValue").value)
        //            }
        //            //  var val = node.id; document.getElementById("hf_DepID").value = val;
        //        }
        //    });
        //    //$('#AllUsers').combotree({
        //    //    onSelect: function (node) {
        //    //        alert(node.text);
        //    //        var val = node.id;
        //    //        document.getElementById("hf_DepID").value = val;
        //    //    }
        //    //});
        //    jQuery("#form1").Validform();
        //});
        //$(function () {
        //    var c = $("#hf_DepID").val(); $('#DepID').combotree('setValues', [c]);
        //    $('#AllUsersID').combotree('setValues', $("#hf_AlluserID").val().split(','));
        //    $('#DutyUser').combotree('setValues', [$("#hf_DutyUser").val()]);
        //});
    </script>
    <%--<script>
        function SetValue() {
            var U = new Array();
            var A = new Array();
            // var t = $("#AllUsersID").combotree("tree")
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







