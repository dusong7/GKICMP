<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherGuidanceDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherGuidanceDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../EasyUI/jquery.min.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <link href="../EasyUI/themes/icon.css" rel="stylesheet" />
    <link href="../EasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../EasyUI/demo/demo.css" rel="stylesheet" />
     
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#TeacherName').combotree({
                onSelect: function (node) {
                    var val = node.id;
                    document.getElementById("hf_SelectedValue").value = val;
                }
            });
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }

    </script>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_Images" runat="server" />

        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">获奖情况管理
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">教师姓名</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="TeacherName" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                         <td align="right" >奖励名称</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="txt_RewardName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >奖励单位</td>
                        <td align="left">
                            <asp:Literal ID="txt_Lunit" runat="server"></asp:Literal>
                        </td>
                       
                        <td align="right">本人角色：</td>
                        <td align="left">
                            <asp:Literal ID="ddl_GRoles" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">奖励等级：</td>
                        <td align="left">
                            <asp:Literal ID="txt_RGrade" runat="server"></asp:Literal>
                         <td align="right">获奖年月：</td>
                        <td align="left" >
                            <asp:Literal ID="txt_PubDate" runat="server"></asp:Literal>
                        </td>
                        
                    </tr>
                    <tr>
                       
                        <td align="right">本人承担<br />工作描述：</td>
                        <td align="left"  colspan="3">
                            <asp:Literal ID="txt_GuiDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="right">附件：</td>
                        <td align="left" colspan="3">
                           <%-- <table>
                                    <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img width="40" height="40" src='<%#Eval("tcfile") %>' />
                                                   
                                                     <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png"  CommandArgument='<%#Eval("tcfile") %>'
                                                        CommandName="del" OnClientClick='<%#"return delmessage(\"【"+Eval("tcfile")+"】\")" %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>--%>
                             <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("RFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("RFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:Image ID="Image2" runat="server" Width="200px" Height="200px" />
                        </td>
                    </tr>


                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


