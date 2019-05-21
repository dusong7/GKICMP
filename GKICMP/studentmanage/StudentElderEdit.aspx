<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentElderEdit.aspx.cs" Inherits="GKICMP.studentmanage.StudentElderEdit" %>

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
                        <th colspan="2" align="left">家长信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="150">学生姓名：</td>
                        <td align="left">
                            <%--<asp:DropDownList ID="ddl_Type" runat="server" Width="120px" datatype="ddl" errormsg="请选择数据类型"></asp:DropDownList>
                            <span style="color: Red">*</span>--%>
                            <div class="sel" style="float: left">
                                <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">家长姓名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ElderName" runat="server" datatype="*" nullmsg="请填写姓名"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">手机号</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CellPhone" runat="server" datatype="*1-100" nullmsg="请填写手机号"></asp:TextBox><span style="color: Red">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">工作单位</td>
                        <td align="left">
                           <asp:TextBox ID="txt_PostDep" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">职务</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PostName" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right">关系</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ShipName" runat="server" datatype="*" nullmsg="请填写与学生关系"></asp:TextBox></asp:TextBox><span style="color: Red">*</span>
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




