<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerRoomEdit.aspx.cs" Inherits="GKICMP.computermanage.ComputerRoomEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
     <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
                        <th colspan="2" align="left">机房设备信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="150">计算机名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ComputerName" runat="server" datatype="*1-100" nullmsg="请填写计算机名称"></asp:TextBox><span style="color: Red">*</span>
                            <%--<asp:DropDownList ID="ddl_Type" runat="server" Width="120px" datatype="ddl" errormsg="请选择数据类型"></asp:DropDownList>
                            <span style="color: Red">*</span>--%>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">IP地址：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LanIP" runat="server" datatype="*1-100" nullmsg="请填写ip地址"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Mac（物理）地址：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Mac"  runat="server" datatype="*1-100" nullmsg="请填写物理地址" ></asp:TextBox><span style="color: Red">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">所属场室：</td>
                        <td align="left">
                             <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_CRID" runat="server" datatype="ddl" errormsg="请选择场室"></asp:DropDownList>
                                <span style="color: Red">*</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>





