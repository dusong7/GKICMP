<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrantEdit.aspx.cs" Inherits="GKICMP.schoolwork.GrantEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#StuName').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_SelectedValue").value = val;
        //            //alert(val);
        //        }
        //    });

        //    jQuery("#form1").Validform();
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:Literal runat="server" ID="ltl_JQ"></asp:Literal>
        <asp:Literal runat="server" ID="ltl_xz"></asp:Literal>

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">助学金信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">学生：</td>
                        <td align="left">
                            <%--<asp:TextBox runat="server" ID="txt_RealName" datatype="*" nullmsg="请选择学生" Enabled="false"></asp:TextBox><img src="../images/selectbtn.png" id="btn_plancom" onclick="showbox()" />--%>
                            <%--<input id="StuName" name="StuName" style="width: 90%;" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree"    Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">助学金类型： </td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_GrantType" runat="server" datatype="ddl" errormsg="请选择类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">申请材料 ：</td>
                        <td align="left">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("ApplyUrl") %>' CommandName="load"
                                                    runat="server"><%# getFileName(Eval("ApplyUrl").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            <asp:HiddenField runat="server" ID="hf_file" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注 ：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_GDesc" TextMode="MultiLine" Rows="6" runat="server" Height="100px" Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
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
