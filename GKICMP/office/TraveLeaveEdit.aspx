<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraveLeaveEdit.aspx.cs" Inherits="GKICMP.office.TraveLeaveEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfatta = $id("hf_UpFile");
            var careful = $id("more").getElementsByTagName("input");
            hfatta.value = careful.length;
        }
        function showbox() {
            var lid = document.getElementById("hf_LID").value;
            var a = document.getElementById("txt_Begin").value;
            var b = document.getElementById("txt_End").value;
            var c = document.getElementById("txt_LeaveDays").value;
            var d = document.getElementById("txt_LeaveMark").value;
            if (a == "" || b == "" || c == "" || d == "") {
                alert("请将带'*'的填写完整后选择审核人");
                return false;
            }
            else {
                return parent.openbox('S_id', 'LeaveAuditUsers.aspx', 'lid=' + lid + '&flag=2', 540, 350, 50);
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
        <asp:HiddenField runat="server" ID="hf_LID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">外出登记信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">外出登记日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Begin" runat="server" datatype="*" Width="85px" nullmsg="请选择开始日期" onclick="WdatePicker({skin:'whyGreen'})" OnTextChanged="txt_Begin_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:DropDownList ID="ddl_Begin" runat="server" OnSelectedIndexChanged="ddl_Begin_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="7">上午</asp:ListItem>
                                <asp:ListItem Value="13">下午</asp:ListItem>
                            </asp:DropDownList>

                            至
                            <asp:TextBox ID="txt_End" runat="server" datatype="*" Width="85px" nullmsg="请选择结束日期" onclick="WdatePicker({skin:'whyGreen'})" OnTextChanged="txt_End_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:DropDownList ID="ddl_End" runat="server" OnSelectedIndexChanged="ddl_End_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="13">上午</asp:ListItem>
                                <asp:ListItem Value="18">下午</asp:ListItem>
                            </asp:DropDownList>


                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>


                        <td align="right">外出天数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LeaveDays" runat="server" Width="85px" Enabled="false" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">课程是否已安排：</td>
                        <td align="left">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbl_IsorNo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">申请材料：</td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" runat="server" CommandArgument='<%#Eval("LeaveFile") %>' CommandName="load"><%# getFileName(Eval("LeaveFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            <asp:HiddenField ID="hf_file" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">外出事由：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_LeaveMark" runat="server" CssClass="searchbg" Height="100px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="90%" datatype="*" nullmsg="请填写外出事由"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr runat="server" id="traudit">
                        <td align="right">外出审核人：</td>
                        <td align="left">
                            <asp:Repeater ID="rp_List" runat="server">
                                <ItemTemplate>
                                    <span><%#Eval("RealName") %>
                                        <asp:LinkButton ID="lbtn_Delete" OnClientClick="return  confirm('您确认删除选中的信息吗？');" CommandArgument='<%#Eval("LAID")%>' runat="server" OnClick="lbtn_Delete_Click"><img src="../images/del.png" /></asp:LinkButton>
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal runat="server" ID="ltl_Name" Text="暂无人员"></asp:Literal>
                            <img src="../images/selectbtn.png" onclick="return showbox();" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


