<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractEdit.aspx.cs" Inherits="GKICMP.teachermanage.ContractEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html" charset="utf-8" />
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
        $(function () {
            //$('#TeacherName').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //    }
            //});
            jQuery("#form1").Validform();
        });
       
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }
        function showbox() {
            return parent.openbox('S_id', '../teachermanage/TeacherSelect.aspx', "&flag=10", 1190, 585, 8);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_IDCard" runat="server" />
        <asp:HiddenField ID="hf_Images" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">合同基本信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">教师姓名</td>
                        <td align="left"  colspan="3">
                            <%--<asp:TextBox ID="txt_TeacherName" runat="server" datatype="*" nullmsg="请选择教师信息"></asp:TextBox>
                            <span style="color: red;">*</span>
                            <img src="../images/selectbtn.png" id="btn_plancom" style="margin-top: 1px;" onclick="showbox()" />
                            <asp:HiddenField runat="server" ID="hf_TID" OnValueChanged="hf_TID_ValueChanged" />--%>

                            <%-- <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server"/>
                            <span style="color: red;">*</span>--%>
                             <asp:TextBox ID="Series"  runat="server" name="Series"  editable="true"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">合同类型
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_CType" datatype="ddl" errormsg="请选择合同类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="100px">合同周期</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_TCycle" Width="50px" datatype="zheng" nullmsg="请填写合同周期"></asp:TextBox>年
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">合同开始日期</td>
                        <td align="left">
                            <%--<asp:TextBox ID="txt_TStartDate" runat="server" onfocus="SetCanler()" datatype="*" nullmsg="请选择合同开始日期"></asp:TextBox>--%>
                            <asp:TextBox ID="txt_TStartDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择合同开始日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">合同结束日期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_TEndDate" runat="server"  onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" ckdate="txt_TStartDate" nullmsg="请选择合同结束日期" ></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">附件：  
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
                        <td style="text-align: center" colspan="4">
                           <asp:Button ID="btn_Sumbit" runat="server" Text="提交"  CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="getfile()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
     <%-- <script type="text/javascript" >
        function SetValues() {
            var val = $('#TeacherName').combotree('getValue');
            document.getElementById("hf_SelectedValue").value = val;
            alert(val);
            // alert(valage);
        }
      </script>--%>
    <script>
        $(function () {
            $('#Series').combotree({
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined")
                    {
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
