<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayRegistrationEdit.aspx.cs" Inherits="GKICMP.payment.PayRegistrationEdit" %>

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
        $(function () {
            $('#Series').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_TID").value = val;
                    //alert(val);
                }
            });
            jQuery("#form1").Validform();//验证控件
        });
    </script>
    
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
                        <th colspan="4" align="left">缴费登记</th>
                    </tr>
                    <tr>
                        <td align="right">学生姓名：</td>
                        <td align="left" colspan="3">
                           <%-- <input id="Series" name="Series" runat="server" style="width: 80%" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">缴费项目：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_PIID" datatype="ddl" errormsg="请选择缴费项" OnSelectedIndexChanged="ddl_Professional_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">缴费金额：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RegCount" runat="server" datatype="bigzero" nullmsg="请填写缴费金额"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
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
