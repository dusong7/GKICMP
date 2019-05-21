<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLearnEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherLearnEdit" %>

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
<%--    <script type="text/javascript">
        $(function () {
            $('#TeacherName').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_SelectedValue").value = val;
                }
            });
            jQuery("#form1").Validform();
        });
   </script>--%>
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
                            <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server"  />
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">培训年份</td>
                        <td align="left">
                          <%--  <asp:TextBox ID="txt_Year" runat="server" datatype="zhengnum" nullmsg="请填写正确的年份"></asp:TextBox>--%>
                            <asp:TextBox ID="txt_Year" runat="server" nullmsg="请选择正确的培训年份" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">课时</td>
                        <td align="left">
                            <asp:TextBox ID="txt_THours" runat="server" datatype="zhengnum" nullmsg="请填写正确的课时"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始时间</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TStartDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择合同开始日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">结束时间 </td>
                        <td align="left">
                            <asp:TextBox ID="txt_TEndDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择合同结束日期" ckdate="txt_TStartDate"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学习或培训地点</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TrainAddress" runat="server" Width="80%" Height="40"></asp:TextBox>
                        </td>
                        <td align="right">学习或培训类型</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_TType" runat="server" datatype="ddl" nullmsg="请选择学习或培训类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学习或培训内容</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_TrainContent" runat="server"  datatype="*" nullmsg="请填写学习或培训内容" Width="80%" Height="40"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_TDesc" runat="server" Width="80%" Height="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                         <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit"  OnClientClick="SetValue()"  OnClick="btn_Sumbit_Click" />
                             <input id="cancell" class="editor" name="button" onclick="javascript: window.history.back(-1);" type="button" value="取消" />
                        </td>
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
                     $('#TeacherName').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                 },
                 error: function () { alert("查询出错，请稍候再试"); }
             });
             jQuery("#form1").Validform();
         });
         $(function () {
             $('#TeacherName').combotree('setValues', $("#hf_SelectedValue").val().split(','));
         });
    </script>
    <script>
        function SetValue() {
            var U = new Array();
            $($("#TeacherName").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#TeacherName").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                };
            });
            document.getElementById("hf_SelectedValue").value = U;
        };
    </script>
</body>
</html>
