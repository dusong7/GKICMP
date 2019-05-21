<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitEdit.aspx.cs" Inherits="GKICMP.office.VisitEdit" %>

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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">来访登记信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">来访人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_VisitUser" runat="server" datatype="*" nullmsg="请填写来访人"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">来访时间：</td>
                        <td>
                            <asp:TextBox ID="txt_VDate" runat="server" datatype="*" nullmsg="请选择来访时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">对接人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SchoolUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">联系电话：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_LinkNum"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">来访人数：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_VisitCount" datatype="zheng" nullmsg="请填写来访人数"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">来访类型：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_VisitType" datatype="ddl" errormsg="请选择来访类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">来访事由：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_VisitReason" TextMode="MultiLine" Width="70%" Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_VMark" runat="server" Height="100px" Style="resize: none" TextMode="MultiLine" Width="70%"></asp:TextBox>
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

