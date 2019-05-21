<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingEdit.aspx.cs" Inherits="GKICMP.meeting.MeetingEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--<script src="../js/jquery.min.js"></script--%>
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_MID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">会议信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">会议主题</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MTitle" runat="server" datatype="*1-50" nullmsg="请填写会议主题" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="80">会议室</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_MeetingRoom" runat="server" datatype="ddl" errormsg="请选择会议室"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">联系人</td>
                        <td align="left">
                            <input id="DutyUser" name="DutyUser" style="width: 50%;" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">联系电话</td>
                        <td>
                            <asp:TextBox ID="txt_LinkNum" runat="server" datatype="m" nullmsg="请填写联系电话"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">会议时间</td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txt_MBegin" Width="120px" datatype="*" nullmsg="请选择会议开始时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_MEnd" Width="120px" datatype="*" nullmsg="请选择会议结束时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参会人员</td>
                        <td colspan="3">
                            <input id="AllUsersID" name="AllUsersID" style="width: 70%;" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">列席人员</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_UserList" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">会议内容</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_MContent" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" datatype="*" nullmsg="请填写会议内容"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_AllUsersText" runat="server" />
        <asp:HiddenField runat="server" ID="hf_DutyUser" />
        <asp:HiddenField runat="server" ID="hf_AlluserID" />
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
                    $('#DutyUser').combotree({ data: d.data, multiple: false, onlyLeafCheck: true, /*multiline: true,*/ });
                    $('#AllUsersID').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $('#DutyUser').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#DutyUser').combotree('clear');
                        alert("部门不能作为联系人，请重新选择");
                    }
                    else {
                        document.getElementById("hf_DutyUser").value = node.id;
                    }
                }
            });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#AllUsersID').combotree('setValues', $("#hf_AlluserID").val().split(','));
            $('#DutyUser').combotree('setValues', [$("#hf_DutyUser").val()]);
        });
    </script>
    <script>
        function SetValue() {
            var U = new Array();
            var A = new Array();
            $($("#AllUsersID").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#AllUsersID").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id); A.push(this.text);
                };
            });
            document.getElementById("hf_AlluserID").value = U;
            document.getElementById("hf_AllUsersText").value = A;
        };
    </script>
</body>
</html>
