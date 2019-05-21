<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassRoomEdit.aspx.cs" Inherits="ICMP.assetmanage.ClassRoomEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="left" colspan="2">
                            <asp:Literal runat="server" ID="ltl_BName"></asp:Literal>信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">
                            <asp:Literal runat="server" ID="ltl_Name"></asp:Literal>名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RoomName" runat="server" datatype="*" nullmsg="请填写名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr id="tr_DID" runat="server">
                        <td align="right">所属班级：</td>
                        <td>
                            <asp:DropDownList ID="ddl_DepID" runat="server" datatype="ddl" errormsg="请选择班级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">是否可用：</td>
                        <td>
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:CheckBox ID="cb_IsUseable" Class="edilab" runat="server" Text="是否可用" />
                            <%-- <asp:DropDownList ID="ddl_IsUseable" runat="server" datatype="ddl" errormsg="请选择信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>--%>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">管理员：
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_IsCome"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr_Ctype" runat="server">
                        <td align="right">场室类型：
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_CType" datatype="ddl" errormsg="请选择场室类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RoomDesc" TextMode="MultiLine" Rows="6" Width="60%" Height="100px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
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
