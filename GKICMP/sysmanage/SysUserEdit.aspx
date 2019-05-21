<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUserEdit.aspx.cs" Inherits="GKICMP.sysmanage.SysUserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" />
        <asp:HiddenField runat="server" ID="hf_UState" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">用户信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">用户名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_UserName" runat="server" datatype="*1-50" nullmsg="请填写用户名" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">身份证号码：</td>
                        <td>
                            <asp:TextBox ID="txt_IDCard" runat="server" MaxLength="50" datatype="idcard" nullmsg="请填写正确身份证号码" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="90">姓名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RealName" runat="server" datatype="*1-50" nullmsg="请填写姓名" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">性别：</td>
                        <td>
                            <div class="sel" style="float: left">
                                <asp:DropDownList runat="server" ID="ddl_UserSex" datatype="ddl" errormsg="请选择性别"></asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">手机号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CellPhone" runat="server" datatype="m" nullmsg="请填写手机号码" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">座机：</td>
                        <td>
                            <asp:TextBox ID="txt_CompanyNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">出生年月：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BirthDay" runat="server" datatype="*" nullmsg="请选择出生年月" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">家庭地址：</td>
                        <td>
                            <asp:TextBox ID="txt_Address" runat="server" datatype="*1-50" nullmsg="请填写家庭地址" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="90">邮箱：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MailNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">QQ：</td>
                        <td>
                            <asp:TextBox ID="txt_QQNum" runat="server" MaxLength="15" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">微信号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_WeiNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right" width="90">民族：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择民族" ID="ddl_UserNation"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属校区：</td>
                        <td>
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择校区" ID="ddl_CID"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">所属部门：</td>
                        <td>
                            <asp:TextBox ID="DepID" runat="server" class="easyui-combotree" onlyLeafCheck="true" Width="90%"></asp:TextBox>
                             <span style="color: Red; float: none">*</span>
                            <%--<input id="DepID" name="DepID" style="width: 85%; height: 30px" class="easyui-combotree" />--%>
                            <%--<asp:HiddenField ID="hf_SelectedValue" runat="server" />--%>
                            <%--<asp:DropDownList ID="ddl_DepID" runat="server"></asp:DropDownList>--%>
                            <%--<asp:TextBox ID="txt_CardNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">角色：</td>
                        <td align="left" colspan="3" class="auto-style1">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }

                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBoxList ID="cbl_Role" Class="edilab" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >一卡通号</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_CardNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">照片：</td>
                        <td colspan="3">
                            <asp:Image ID="Image1" runat="server" Width="200px" Visible="false" />
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr runat="server" id="IsNot">
                        <td align="right" width="120">同步教师：</td>
                        <td colspan="3">

                            <asp:CheckBox ID="cb_IsOrNot" Class="edilab" runat="server" Text="是否同步录入教师信息" /><span style="color: red">如果非本校教职工请不要勾选</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_UserDesc" TextMode="MultiLine" Rows="6" Width="99%" Height="100px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit"  OnClientClick="setValue()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>

            </table>
        </div>
        <asp:HiddenField ID="hf_ID" runat="server" />
    </form>
    <script type="text/javascript">
        $(function () {
            //$.ajax({
            //    url: "../ashx/GetBaseDate.ashx",
            //    cache: false, type: "GET",
            //    data: "method=GetDep&data=js",
            //    dataType: "json",
            //    async: false,
            //    success: function (d) {
            //        $('#DepID').combotree({ data: d.data, multiple: false, });
            //        alert($("#hf_SelectedValue").val());
            //        $('#DepID').combotree("setValues", "1");
            //        //var c = $("#hf_DepID").val(); $('#DepID').combotree('setValues', [c]);
            //    },
            //    error: function () { alert("查询出错，请稍候再试"); }
            //});
            //$.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetDep";
            $.getJSON(url, function (data) {
                $('#DepID').combotree({
                    data: data.data,
                    multiple: true,
                    multiline: true,
                });
                //$('#DepID').combotree("setValues", $("#hf_SelectedValue").val());
                //var a = $("#hf_SelectedValue").val();
                //$('#DepID').combotree("setValue", [8]);
            });
            //$('#DepID').combotree({
            //    onSelect: function (node) {
            //        var val = node.id; document.getElementById("hf_SelectedValue").value = val;
            //    }
            //});
        });

        //function setValue() {
        //    var U = new Array();
        //    $($("#DepID").combotree("tree").tree("getChecked")).each(function () {
        //        if (this.children == null && $("#DepID").combotree("tree").tree("find", this.id) != null) {
        //            U.push(this.id);
        //            document.getElementById("hf_SelectedValue").value = U;
        //        }
        //    });
        //alert(U);
        //}
    </script>

</body>
</html>
