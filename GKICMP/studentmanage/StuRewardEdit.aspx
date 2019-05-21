<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuRewardEdit.aspx.cs" Inherits="GKICMP.studentmanage.StuRewardEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script>
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;//获取FileUpload控件的个数
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField runat="server" ID="hf_TID" />
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_Images" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">奖惩信息</th>
                    </tr>
                    <tr>
                        <td align="right">学生姓名</td>
                        <td align="left" colspan="3">
                            <%--<input id="StuName" name="StuName" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
                             <asp:TextBox ID="txt_StuName"  runat="server" name="txt_StuName"    url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree"    Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" datatype="*" nullmsg="请填写学年度" runat="server"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">学期</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term" Width="150"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">奖励名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RewardName" runat="server" datatype="*" nullmsg="请填写奖励名称"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">奖励级别</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RewardGrade" Width="150" datatype="ddl" nullmsg="请选择奖励级别"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">奖励类别</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RewardType" Width="150" datatype="ddl" nullmsg="请选择奖励类别"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">奖励等级</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RewardRand" Width="150" datatype="ddl" nullmsg="请选择奖励等级"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">奖励类型</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_RStyle" Width="150" datatype="ddl" nullmsg="请选择奖励类型"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">奖励金额</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RewardCash" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">奖励单位</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RewardDep" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">奖励原因</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RewardReason" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">奖励方式</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RMode" Width="150" datatype="ddl" nullmsg="请选择奖励方式"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">奖励时间</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择奖励时间"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">辅导老师</td>
                        <td align="left">
                           <asp:TextBox ID="txt_Tea"  runat="server" multiline="true"   name="txt_StuName" onlyLeafCheck="true" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"   Width="90%"></asp:TextBox>
                        </td>
                        <%--<script>
                            $(function () {
                                var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
                                $.getJSON(url, function (data) {
                                    //alert(data.data);
                                    $('#TeaID').combotree(
                                        {
                                            data: data.data,
                                            multiple: false,
                                            /*multiline: true,*/
                                        });
                                    $('#TeaID').combotree('setValues', [$("#hf_TID").val()]); $('#StuName').combotree('setValues', [$("#hf_SelectedValue").val()]);
                                });

                            });
                        </script>--%>
                        <td align="right">是否计入绩效</td>
                        <td>
                            <asp:DropDownList ID="ddl_IsAchievement" runat="server" Width="150">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">证书附件：  
                        </td>
                        <td colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img width="40" height="40" src='<%#Eval("tcfile") %>' />

                                                <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png" CommandArgument='<%#Eval("tcfile") %>'
                                                    CommandName="del" OnClientClick='<%#"return delmessage(\"【"+Eval("tcfile")+"】\")" %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                                <img src="../images/addfile.gif" alt="" style='cursor: pointer; margin-bottom: -3px'
                                    onclick="addfile('more')" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>

                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="getfile()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        $(function () {
            $('#txt_Tea').combotree({  
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined")
                    {
                        alert("不能选择部门");
                        //document.getElementsByName("txt_Tea").value = ""
                        document.getElementsById("txt_Tea").value = ""
                    }
                }
            });
            $('#txt_StuName').combotree({
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined") {
                        alert("不能选择年级或班级");
                        //document.getElementsByName("txt_StuName").value = ""
                        document.getElementsById("txt_StuName").value = ""
                    }
                }
            });
            jQuery("#form1").Validform();
        });
    </script>
</body>
</html>


