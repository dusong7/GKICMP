<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveRecordEdit.aspx.cs" Inherits="GKICMP.office.LeaveRecordEdit" %>

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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_LID" />
        <asp:HiddenField runat="server" ID="hf_Url" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">外出信息</th>
                    </tr>
                    <tr id="trSubject" runat="server">
                     
                        <td align="right" width="100px">外出日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Begin" runat="server" datatype="*" Width="85px" nullmsg="请选择开始日期" onclick="WdatePicker({skin:'whyGreen'})" OnTextChanged="txt_Begin_TextChanged" AutoPostBack="true"></asp:TextBox>
                            至
                            <asp:TextBox ID="txt_End" runat="server" datatype="*" Width="85px" nullmsg="请选择结束日期" onclick="WdatePicker({skin:'whyGreen'})" OnTextChanged="txt_End_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">天数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LeaveDays" runat="server" Width="85px" Enabled="false" CssClass="searchbg"></asp:TextBox>
                        </td>
                       
                    </tr>

                    <tr>
                        <td align="right">申请材料： </td>
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
                            <asp:TextBox ID="txt_LeaveMark" runat="server" CssClass="searchbg" datatype="*" nullmsg="请填写请假事由" Height="70px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span> </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


