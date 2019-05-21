<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuAttendEdit.aspx.cs" Inherits="GKICMP.studentmanage.StuAttendEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajaxSettings.async = false;
            //var DID = "../ashx/GetBaseDate.ashx?method=GetGrade";
            //$.getJSON(DID, function (data) { $('#DID').combotree({ data: data.data, /*multiple: true,/*multiline: true,*/ }); });
            var LeaveUser = "../ashx/GetBaseDate.ashx?method=GetStuID&did=" + $("#hf_DID").val();
            $.getJSON(LeaveUser, function (data) { $('#LeaveUser').combotree({ data: data.data, multiple: true,/*multiline: true,*/ }); });
            var Compassionate = "../ashx/GetBaseDate.ashx?method=GetStuID&did=" + $("#hf_DID").val();
            $.getJSON(Compassionate, function (data) { $('#Compassionate').combotree({ data: data.data, multiple: true,/*multiline: true,*/ }); });
            var Sick = "../ashx/GetBaseDate.ashx?method=GetStuID&did=" + $("#hf_DID").val();
            $.getJSON(Sick, function (data) { $('#Sick').combotree({ data: data.data, multiple: true,/*multiline: true,*/ }); });
            var Infectious = "../ashx/GetBaseDate.ashx?method=GetStuID&did=" + $("#hf_DID").val();
            $.getJSON(Infectious, function (data) { $('#Infectious').combotree({ data: data.data, multiple: true,/*multiline: true,*/ }); });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#LeaveUser').combotree('setValues', $("#hf_LeaveUser").val().split(','));
            $('#Compassionate').combotree('setValues', $("#hf_Compassionate").val().split(','));
            $('#Sick').combotree('setValues', $("#hf_Sick").val().split(','));
            $('#Infectious').combotree('setValues', $("#hf_Infectious").val().split(','));
        });
        function setValue() {

            var V = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#LeaveUser").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#LeaveUser").combotree("tree").tree("find", this.id) != null) {
                    V.push(this.id);
                    document.getElementById("hf_LeaveUser").value = V;
                }
            });
            var W = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Infectious").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Infectious").combotree("tree").tree("find", this.id) != null) {
                    W.push(this.id);
                    document.getElementById("hf_Infectious").value = W;
                }
            });
            var X = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Compassionate").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Compassionate").combotree("tree").tree("find", this.id) != null) {
                    X.push(this.id);
                    document.getElementById("hf_Compassionate").value = X;
                }
            });
            var Y = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Sick").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Sick").combotree("tree").tree("find", this.id) != null) {
                    Y.push(this.id);
                    document.getElementById("hf_Sick").value = Y;
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz1" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz2" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz3" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz4" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_STID" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />
        <asp:HiddenField ID="hf_LeaveUser" runat="server" />
        <asp:HiddenField ID="hf_Infectious" runat="server" />
        <asp:HiddenField ID="hf_Compassionate" runat="server" />
        <asp:HiddenField ID="hf_Sick" runat="server" />
        <div class="listcent pad0">
            <asp:Label ID="lbl_xs" runat="server" Style="height: 40px; font-size: 22px;"></asp:Label>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" width="120">班级：</td>
                        <td align="left">
                            <asp:Label ID="lbl_DID" runat="server"></asp:Label></td>
                        <td align="right" width="120">晨检日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_CreateDate" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td align="right" width="120">迟到：</td>
                        <td align="left" colspan="3">
                            <input id="LeaveUser" name="LeaveUser" class="easyui-combotree" style="width: 80%" /></td>

                    </tr>
                    <tr>
                        <td align="right" width="120">事假：</td>
                        <td align="left" colspan="3">
                            <input id="Compassionate" name="Series" class="easyui-combotree" style="width: 80%" /></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">病假：</td>
                        <td align="left" colspan="3">
                            <input id="Sick" name="Series" class="easyui-combotree" style="width: 80%" /></td>

                    </tr>
                    <tr>
                        <td align="right" width="120">传染病：</td>
                        <td align="left" colspan="3">
                            <input id="Infectious" name="Series" class="easyui-combotree" style="width: 80%" /></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">应到人数：</td>
                        <td align="left">
                            <asp:Label ID="lbl_AllIns" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td align="right" width="120">实到人数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RealCOunt" runat="server" datatype="zheng" nullmsg="请填写实到人数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" Style="margin-top: 10px;" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick='setValue()' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


