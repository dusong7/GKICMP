<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentEdit.aspx.cs" Inherits="GKICMP.assetmanage.AppointmentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />

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
                        <th colspan="4" align="left">场地预约</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">预约场地：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_MRID" runat="server" datatype="ddl" errormsg="请选择信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>

                        <td align="right">预约人：</td>
                        <td>
                            <asp:Label ID="lbl_TeacherName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">预约使用日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Width="80px" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="120">预约使用时段：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_begin" runat="server" Width="40px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})" datatype="*" nullmsg="请选择时段"></asp:TextBox>--
                            <asp:TextBox ID="txt_end" runat="server" Width="40px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})" datatype="*" nullmsg="请选择时段"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">预约说明：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_AppointmentDesc" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
