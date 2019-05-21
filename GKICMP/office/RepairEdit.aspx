<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairEdit.aspx.cs" Inherits="GKICMP.office.RepairEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
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
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField runat="server" ID="hf_Url" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">我的报修</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">报修设备：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_RepairObj" Width="500px" runat="server" datatype="*" nullmsg="请填写报修对象" CssClass="searchbg"
                                MaxLength="200"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>

                    </tr>
                      <tr>
                        <td align="right" width="120">受理部门：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_DutyDep" runat="server" datatype="ddl" nullmsg="请选择受理部门" AutoPostBack="true" OnSelectedIndexChanged="ddl_DutyDep_SelectedIndexChanged"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                       <%-- <td align="right" width="120">受理部门：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DutyDep" runat="server" Enabled="false"></asp:TextBox>
                            <asp:HiddenField ID="hf_DutyDep" runat="server" Visible="false" />
                        </td>--%>

                    </tr>
                    <tr>
                        <%--  <td align="right" width="120">受理部门：</td>
                        <td align="left">
                           <%-- <asp:DropDownList ID="ddl_DutyDep" runat="server" datatype="ddl" nullmsg="请选择受理部门" AutoPostBack="true" OnSelectedIndexChanged="ddl_DutyUser_SelectedIndexChanged"></asp:DropDownList>--%>
                        <%--  <asp:DropDownList ID="ddl_DutyDep" runat="server" datatype="ddl" nullmsg="请选择受理部门" AutoPostBack="true" OnSelectedIndexChanged="ddl_DutyUser_SelectedIndexChanged"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>--%>
                        <%--   </td>--%>

                        <td align="right" width="120">本校受理人：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_DutyUser" runat="server" datatype="ddl" nullmsg="请选择受理人"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">维修单位：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_D" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">附件：</td>
                        <td align="left" colspan="3">
                            <%--<table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" runat="server" CommandArgument='<%#Eval("ARFile") %>' CommandName="load"><%# getFileName(Eval("ARFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>--%>
                            <asp:Image ID="Image1" runat="server" Width="350px" Height="200px" Visible="false" />
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            <asp:HiddenField ID="hf_file" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">故障描述：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_RepairContent" runat="server" Width="70%" datatype="*" nullmsg="请填写故障描述" CssClass="searchbg" Style="resize: none" TextMode="MultiLine" Columns="6" Height="100px"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
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
