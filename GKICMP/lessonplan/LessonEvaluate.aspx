<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonEvaluate.aspx.cs" Inherits="GKICMP.lessonplan.LessonEvaluate" %>

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
                        <th colspan="3" align="left">历史评价记录</th>
                    </tr>
                   
                   
                       
                                <asp:Repeater ID="rp_List" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                         <tr>
                                           <td>
                                               评价等级： <%#Eval("Degree") %>
                                            </td>
                                             <td>
                                                评价时间：<%#Eval("EvalDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                            <td>
                                                <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png" CommandArgument='<%#Eval("LEID") %>'
                                                    CommandName="del" />
                                            </td>
                                        </tr>
                                      <tr>
                                           
                                            <td colspan="3">
                                                <%#Eval("Remark") %>
                                            </td>
                                        </tr>
                                       
                                    </ItemTemplate>
                                </asp:Repeater>
                                
                         
                      
                        <tr runat="server" id="tr_null" >
                                    <td colspan="3" align="center">暂无记录</td>
                                </tr>
                    
                      <tr>
                        <th colspan="3" align="left">本次评价</th>
                    </tr>
                    <tr>
                        <td align="right">等级
                        </td>
                        <td align="left" colspan="2">
                            <asp:DropDownList runat="server" ID="ddl_Degree" datatype="ddl" errormsg="请选择等级">
                                <asp:ListItem Value="优秀">优秀</asp:ListItem>
                                <asp:ListItem Value="良好">良好</asp:ListItem>
                                <asp:ListItem Value="合格">合格</asp:ListItem>
                                <asp:ListItem Value="不合格">不合格</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" >评语</td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txt_Remark" runat="server" TextMode="MultiLine" Width="80%" datatype="*" nullmsg="请填写评语" Height="160px"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>

                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="getfile()" />
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

