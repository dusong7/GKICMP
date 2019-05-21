<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUserDetail.aspx.cs" Inherits="GKICMP.sysmanage.SysUserDetail" %>

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
                        <th colspan="4" align="left">用户信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">用户名：</td>
                        <td align="left">
                            <asp:Label ID="ltl_UserName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">身份证号码：</td>
                        <td>
                            <asp:Label Text="" ID="ltl_IDCard" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">姓名：</td>
                        <td align="left">

                            <asp:Label ID="ltl_RealName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">性别：</td>
                        <td>

                            <div class="sel" style="float: left">
                                <asp:Label ID="ltl_UserSex" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">手机号：</td>
                        <td align="left">
                            <asp:Label ID="ltl_CellPhone" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">座机：</td>
                        <td>
                            <asp:Label ID="ltl_CompanyNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">出生年月：</td>
                        <td align="left">
                            <asp:Label Text="" ID="ltl_BirthDay" runat="server"></asp:Label>
                        </td>
                        <td align="right">家庭地址：</td>
                        <td>
                            <asp:Label Text="" ID="ltl_Address" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">邮箱：</td>
                        <td align="left">
                            <asp:Label ID="ltl_MailNum" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">QQ：</td>
                        <td>
                            <asp:Label ID="ltl_QQNum" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">微信号：</td>
                        <td align="left">
                            <asp:Label ID="ltl_WeiNum" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="90">民族：</td>
                        <td align="left">
                            <asp:Label ID="ltl_UserNation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">所属校区：</td>
                        <td align="left">
                            <asp:Label ID="ltl_CampusName" runat="server"></asp:Label>
                        </td>
                        <td align="right">所属部门：</td>
                        <td>
                            <asp:Label ID="ltl_DepName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">角色：</td>
                        <td align="left" colspan="3" >
                             <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBoxList ID="cbl_Role" Class="edilab" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                           <%-- <asp:Label ID="ltl_UState" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="ltl_UserDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
