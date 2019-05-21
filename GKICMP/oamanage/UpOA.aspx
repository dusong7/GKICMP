<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpOA.aspx.cs" Inherits="GKICMP.oamanage.UpOA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        //function setValue() {
        //    var U = new Array();
        //    $($("#Series").combotree("tree").tree("getChecked")).each(function () {
        //        if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
        //            U.push(this.id);
        //            document.getElementById("hf_SelectedValue").value = U;
        //        }
        //    });
        //}
        $(function () {
            $('#Series').combotree({
                data: [<%=data%>],

                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#Series').combotree('clear');
                    }
                    else {
                        document.getElementById("hf_SelectedValue").value = node.id;
                        document.getElementById("hf_SelectedText").value = node.text;
                        //alert(document.getElementById("hf_SelectedValue").value)
                    }
                    //var val = node.text; document.getElementById("hf_SelectedValue").value = val;
                }
            });
        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" Value="" />
        <asp:HiddenField ID="hf_SelectedText" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">基本信息</th>
                    </tr>

                    <tr>
                        <td align="right" width="80px">政务标题</td>
                        <td align="left" colspan="5">

                            <asp:TextBox ID="txt_ETitle" runat="server" Width="80%" datatype="*" nullmsg="请填写政务标题"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">收件人</td>
                        <td align="left" colspan="5">
                            <input id="Series" name="Series" style="width: 85%; height: 80px" class="easyui-combotree" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">正文</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <%--<script id="editor" name="myContent" type="text/plain"  style="width: 100%; height: 300px;"></script>--%>
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="setValue()" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
        //$(function () {
        //    $.ajaxSettings.async = false;
        //    var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
        //    $.getJSON(url, function (data) {
        //        $('#Series').combotree({
        //            data: data.data,
        //            multiple: true,
        //            multiline: true,
        //        });
        //        $('#Series').combotree("setValues", $("#hf_SelectedValue").val().split(','));
        //    });
        //});
    </script>

</body>
</html>





