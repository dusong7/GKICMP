<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUserTypeEdit.aspx.cs" Inherits="GKICMP.sysmanage.SysUserTypeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../css/green_formcss.css" rel="stylesheet" />
     <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
     <script src="../js/jquery.min.js"></script>
    
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
   <script type="text/javascript">
       $(function () {
           jQuery("#form1").Validform();
       });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server"></asp:HiddenField>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">人员分类管理</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">类型：</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_SType" runat="server" datatype="ddl" errormsg="请选择人员类型"></asp:DropDownList>
                                <span style="color: red;">*</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">人员：</td>
                        <td align="left">
                            <%--<input id="tid" style="width: 80%;" runat="server" class="easyui-combotree" name="tid" />
                            <span style="color: Red; float: none">*</span>--%>
                              <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script src="../js/jquery.easyui.min.js"></script>
   <%-- <script>
     $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
            $.getJSON(url, function (data) { 
                $('#tid').combotree({
                    data: data.data,
                    multiple: false,
                    onSelect: function (node) {
                        //返回树对象  
                        //var tree = $(this).tree;
                        ////选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                        //var isLeaf = tree('isLeaf', node.target);
                        //if (!isLeaf) {
                        //    //清除选中  
                        //    $('#Series').combotree('clear');
                        //}
                        //else {
                            document.getElementById("hf_SelectedValue").value = node.id;
                            //alert(document.getElementById("hf_SelectedValue").value)
                        //}
                    }
                    /*multiline: true,*/ }); 
                /*$('#Included').combotree('setValues', [$("#hf_Included").val()]);*/
            });
            $('#tid').combotree('setValues', [$("#hf_SelectedValue").val()]);
            jQuery("#form1").Validform();
        });
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
