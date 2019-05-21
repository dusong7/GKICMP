<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolChangeEdit.aspx.cs" Inherits="GKICMP.studentmanage.SchoolChangeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_Stuid" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生变动信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80px">姓名：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_StuName" runat="server"></asp:Literal>
                        </td>

                        <td align="right">班级：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_DepID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">变动类别：</td>
                        <td>
                            <asp:DropDownList ID="ddl_SCType" runat="server" datatype="ddl" errormsg="请选择变动类别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">变动日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SCDate" runat="server" datatype="*" nullmsg="请选择变动日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">变动原因：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_SCReason" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg" datatype="*" nullmsg="请填写变动原因" Style="resize: none;"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">变动说明：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_SCDesc" runat="server" Rows="6" TextMode="MultiLine" Width="80%" Height="100px" CssClass="MultiLinebg" datatype="*" nullmsg="请填写变动说明" Style="resize: none;"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



