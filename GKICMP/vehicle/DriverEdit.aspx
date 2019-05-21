<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriverEdit.aspx.cs" Inherits="GKICMP.vehicle.DriverEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server"></asp:HiddenField>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">司机信息管理</th>
                    </tr>
                    <tr>
                        <td align="right">司机名称：</td>
                        <td align="left" colspan="3">
                           <%-- <input id="tid" style="width: 80%;" runat="server" class="easyui-combotree" name="tid" />
                            <span style="color: Red; float: none">*</span>--%>
                            <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">驾驶证号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DriverCode" runat="server" datatype="*" nullmsg="请填写驾驶证号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">初次领证日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_FristGetDate" runat="server" datatype="*" nullmsg="请选择初次领证日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">准驾车型：</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList runat="server" ID="ddl_SType" datatype="ddl" errormsg="请选择准驾车型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_DDesc" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#tid').combotree({ data: d.data, multiple: false, /*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $('#tid').combotree({
                onSelect: function (node) {
                    document.getElementById("hf_SelectedValue").value = node.id;
                }
            }); jQuery("#form1").Validform();
        });
    </script>
    <script>
        $(function () {
            $('#tid').combotree('setValues', [$("#hf_SelectedValue").val()]);

        });
    </script>

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
<script>
    //function check() {
    //    if ($val("hf_SelectedValue") == "") {
    //        alert("司机不能为空");
    //    }
    //};
</script>

