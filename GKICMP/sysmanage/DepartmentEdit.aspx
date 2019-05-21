<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="GKICMP.sysmanage.DepartmentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />

    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/common.js"></script>

    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {
            //$('#Series').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //        //alert(val);
            //    }
            //});

            jQuery("#form1").Validform();//验证控件
        });

        function succ() {
            window.parent.location.href = "DepartmentList.aspx";
        }

        //jQuery(document).ready(function () {
        //    jQuery("#form1").Validform();
        //});

        function showbox() {
            return parent.openbox('S_id', '../studentinfo/TeacherSelect.aspx', 'flag=7', 1160, 560, 13);
        }

        function SetValue() {
            var val = $('#Series').combotree('getValues');
            var depname = document.getElementById("txt_DepName").value;
            var order = document.getElementById("txt_DepOrder").value;
            var reg = "/^[0-9]\d*$/";
            if (order == "") {
                alert("请输入排序号");
                return false;
            }
            if (reg.match(order)) {
                alert("请填写大于0的正整数！");
                return false;
            }
            if (depname == "") {
                alert("请输入部门名称");
                return false;
            }

            document.getElementById("hf_SelectedValue").value = val;
            return true;
        }

        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_Dep" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" Value="2" />
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">
                            <asp:Literal ID="ltl_D" runat="server"></asp:Literal>列表
                        </th>
                    </tr>
                    <%--<tr>
                        <td align="right">上级部门名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PMName" runat="server" Enabled="false" Width="200"></asp:TextBox></td>
                    </tr>--%>

                     <tr runat="server" id="ddlcid" >
                        <td align="right" width="100px">所属校区：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CID" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">
                            <asp:Literal runat="server" ID="ltl_DepName"></asp:Literal>名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DepName" runat="server" datatype="*1-100" nullmsg="请填写名称" Width="200"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr id="depart" runat="server">
                        <td align="right" width="100px">
                            <asp:Literal runat="server" ID="ltl_OtherName"></asp:Literal>别名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_OtherName" runat="server" datatype="*1-100" nullmsg="请填写别名" Width="200"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" width="100px">部门类型：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_DepType" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right">
                            <asp:Literal runat="server" ID="ltl_Master"></asp:Literal>：</td>
                        <td align="left">
                            <%--<asp:TextBox ID="Series" runat="server" class="easyui-combotree"></asp:TextBox>--%>

                           <%-- <input id="Series" name="Series" runat="server" class="easyui-combotree"  />--%>
                            <asp:TextBox ID="Series"  name="Series" class="easyui-combotree"  runat="server"></asp:TextBox>
                           
                             <%--<asp:TextBox ID="txt_Master" runat="server" Enabled="false"></asp:TextBox>
                            <img src="../images/selectbtn.png" onclick="showbox()" />
                            <asp:HiddenField ID="hf_UID" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal runat="server" ID="ltl_DepMark"></asp:Literal>简述：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DepMark" TextMode="MultiLine" runat="server" Rows="6" Width="60%" Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">排序：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DepOrder" runat="server" Width="200" datatype="zheng" nullmsg="请输入排序号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">是否展现：</td>
                        <td align="left">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbol_MType" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>--%>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <%--     &nbsp; &nbsp;&nbsp;&nbsp; --%>
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        <%--    <asp:Button ID="btn_Deleted" runat="server" Text="删除" CssClass="editor" OnClientClick="return confirm('确认删除此条记录吗？')" OnClick="btn_Delete_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

