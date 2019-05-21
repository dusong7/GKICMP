<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampusEdit.aspx.cs" Inherits="GKICMP.sysmanage.CampusEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">校区信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="110">校区名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CampusName" runat="server" datatype="*1-150" nullmsg="请填写校区名称" CssClass="searchbg"
                                MaxLength="150"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="180">校区地址：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ButtonCode" runat="server" datatype="*1-300" nullmsg="请填写校区地址" CssClass="searchbg"
                                MaxLength="300"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">校区联系电话：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LinkNum" runat="server" datatype="*" nullmsg="请填写校区联系电话" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">校区负责人：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_DutyUser" runat="server" datatype="ddl" errormsg="请选择校区负责人"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">校区面积：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AreaSize" runat="server" datatype="sum" nullmsg="请填写校区面积" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>（平方米）</td>
                        <td align="right">校区建筑面积：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_BuiltupAea" runat="server" datatype="sum" nullmsg="请填写校区建筑面积" CssClass="searchbg"
                                MaxLength="40"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>（平方米）</td>
                    </tr>
                    <tr>
                        <td align="right">校区固定资产总值：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_FixedAssets" runat="server" datatype="sum" nullmsg="请填写校区固定资产总值" CssClass="searchbg"
                                MaxLength="40"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>（万元）</td>
                        <td align="right">校区教学科研仪器设备总值：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_EquipmentValue" runat="server" datatype="sum" nullmsg="请填写校区教学科研仪器设备总值" CssClass="searchbg"
                                MaxLength="40"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>（万元）</td>
                    </tr>
                    <tr>
                        <td align="right">正式使用日期：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_BeginDate" runat="server" datatype="*" nullmsg="请选择正式使用日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <asp:Literal ID="ltl_BeginDate" runat="server" Visible="false"></asp:Literal>
                            <span style="color: Red; float: none" id="span1" runat="server">*</span>
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
