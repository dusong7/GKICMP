<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherChangesEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherChangesEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/jquery-1.8.2.min.js"></script>
     <script src="../js/jquery.min.js"></script>
     <script src="../js/jquery.easyui.min.js"></script>
     <link href="../css/easyui.css" rel="stylesheet" />
     <link href="../css/demo.css" rel="stylesheet" />
     
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#TeacherName').combotree({
        //        onSelect: function (node) {
        //            var val = node.id;
        //            document.getElementById("hf_SelectedValue").value = val;
        //        }
        //    });
        //    jQuery("#form1").Validform();
        //});

        $(function () {
            jQuery("#form1").Validform();
        });

   </script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
       
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" >姓名</td>
                        <td align="left" colspan="3">
                           <%-- <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server" />--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series" editable="true" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">异动类型</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CType" runat="server" datatype="ddl" nullmsg="请选择异动类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                       <td align="right">异动时间</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择合同开始日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">异动原因</td>
                        <td align="left" colspan="3">
                           <%-- <asp:TextBox ID="txt_ChangeReason" runat="server"  datatype="*" nullmsg="请填写学习或培训内容" Width="80%" Height="40"></asp:TextBox>--%>
                             <asp:TextBox ID="txt_ChangeReason" TextMode="MultiLine" Rows="6" runat="server" Width="90%"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                       
                     <tr runat="server" id="tr_file">
                        <td align="right">附件 </td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("CFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("CFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            <asp:HiddenField runat="server" ID="hf_file" />
                            <asp:HiddenField runat="server" ID="hf_RFile" />
                        </td>
                    </tr>

                   
                    <tr>
                         <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit"  OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
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

